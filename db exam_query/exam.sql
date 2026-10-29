alter authorization on database :: [UniversityResearchSystem] to[sa]


------------------------------------------------------------
-- Trigger 3: Audit grant amount changes
------------------------------------------------------------
CREATE TABLE dbo.GrantAudit (
    AuditId INT IDENTITY(1,1) PRIMARY KEY,
    GrantId INT,
    OldAmount DECIMAL(18,2),
    NewAmount DECIMAL(18,2),
    ModifiedBy SYSNAME,
    ModifiedDate DATETIME2
);
GO
CREATE OR ALTER TRIGGER dbo.TR_Grants_Audit
ON dbo.Grants
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.GrantAudit
        (GrantId, OldAmount, NewAmount, ModifiedBy, ModifiedDate)
    SELECT I.Id, D.Amount, I.Amount, SYSTEM_USER, SYSDATETIME()
    FROM inserted AS I
    JOIN deleted AS D ON D.Id = I.Id;
END;
GO

------------------------------------------------------------
-- Transaction: create project, assign leader, allocate grant
------------------------------------------------------------
BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @NewProjectId INT;
    DECLARE @LeaderId INT = 1; -- Replace with a valid researcher ID
    DECLARE @GrantId INT = 1;  -- Replace with a valid grant ID

    IF NOT EXISTS (SELECT 1 FROM dbo.Researcher WHERE Id = @LeaderId)
        THROW 50020, 'Leader does not exist.', 1;
    IF NOT EXISTS (SELECT 1 FROM dbo.Grants WHERE Id = @GrantId)
        THROW 50021, 'Grant does not exist.', 1;

    INSERT INTO dbo.ResearchProject (Title, StartDate, EndDate, Budget, Status)
    VALUES ('New Research Project', CAST(GETDATE() AS DATE), NULL, 120000, 'Pending');

    SET @NewProjectId = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO dbo.WorksOn (ResearcherId, ProjectId, JoinDate, Role, HoursPerWeek)
    VALUES (@LeaderId, @NewProjectId, CAST(GETDATE() AS DATE), 'Leader', 10);

    INSERT INTO dbo.Funds (GrantId, ProjectId, AllocationAmount)
    VALUES (@GrantId, @NewProjectId, 120000);

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    THROW;
END CATCH;
GO

------------------------------------------------------------
-- Q51. Permissions
------------------------------------------------------------
GRANT SELECT, INSERT, UPDATE, DELETE ON SCHEMA::dbo TO ResearchManager;
GRANT SELECT, INSERT ON dbo.Researcher TO ResearchAssistant;
GRANT SELECT, INSERT ON dbo.Publication TO ResearchAssistant;
-- Grant DataAnalyst SELECT on each view individually (repeat for all views):
GRANT SELECT ON dbo.ActiveProjectSummary TO DataAnalyst;
GRANT SELECT ON dbo.ResearcherPublicationStats TO DataAnalyst;
-- Do not grant SELECT on SCHEMA::dbo to DataAnalyst, as that includes tables.

------------------------------------------------------------
-- Q52. Revoke INSERT and UPDATE on Researcher from ResearchAssistant
------------------------------------------------------------
REVOKE INSERT, UPDATE ON dbo.Researcher FROM ResearchAssistant;

------------------------------------------------------------
-- EXISTS vs IN comparison for project P001
------------------------------------------------------------
SELECT R.*
FROM dbo.Researcher AS R
WHERE R.Id IN (
    SELECT W.ResearcherId
    FROM dbo.WorksOn AS W
    WHERE W.ProjectId = 'P001'
);

SELECT R.*
FROM dbo.Researcher AS R
WHERE EXISTS (
    SELECT 1
    FROM dbo.WorksOn AS W
    WHERE W.ResearcherId = R.Id AND W.ProjectId = 'P001'
);

------------------------------------------------------------
-- Performance indexes for active projects and researcher joins
------------------------------------------------------------
CREATE NONCLUSTERED INDEX IX_ResearchProject_Status_StartDate_Title
ON dbo.ResearchProject (Status, StartDate DESC)
INCLUDE (Id, Title);

CREATE NONCLUSTERED INDEX IX_WorksOn_ProjectId_ResearcherId
ON dbo.WorksOn (ProjectId, ResearcherId)
INCLUDE (HoursPerWeek, Role);

-- If Researcher.Id is already the clustered primary key, this extra index may not be needed:
CREATE NONCLUSTERED INDEX IX_Researcher_Id_Names
ON dbo.Researcher (Id)
INCLUDE (FirstName, LastName);

------------------------------------------------------------
-- Q49. Top 10 cited publications and their authors (includes ties)
------------------------------------------------------------
WITH RankedPublications AS (
    SELECT P.Id, P.Title, P.CitationCount,
           RANK() OVER (ORDER BY P.CitationCount DESC) AS CitationRank
    FROM dbo.Publication AS P
)
SELECT RP.Id AS PublicationId, RP.Title, RP.CitationCount,
       R.FirstName, R.LastName, PU.AuthorOrder
FROM RankedPublications AS RP
JOIN dbo.Publishes AS PU ON PU.PublicationId = RP.Id
JOIN dbo.Researcher AS R ON R.Id = PU.ResearcherId
WHERE RP.CitationRank <= 10
ORDER BY RP.CitationRank, RP.Title, PU.AuthorOrder;