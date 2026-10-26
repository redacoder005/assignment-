select P.DOB ,P.Name , P.Id, P.WardId,W.Name as ward_name
from Patients P
Join Wards W
on P.WardId=W.Id; 
 



select DA.DATE,DA.Dosage,DA.DrugCode,DA.NurseId,DA.PatientId,DA.Time ,P.Name as patient_name
from DrugAdministrations DA 
inner join Patients P 
on DA.PatientId=P.Id

select p.DOB,p.Id,p.Name,p.WardId,c.Name as consultant_name
from PatientExaminations PE
inner join Patients p
on PE.PatientId=p.Id
inner join Consultants c
on PE.ConsultantId =c.Id

select w.Id,w.Name,p.DOB,p.Id,p.Name,p.WardId
from Wards w
left join Patients p
on w.Id=p.WardId

select p.DOB,p.Id,p.Name,p.WardId,c.Name as consultant_name
from PatientExaminations PE
inner join Patients p
on PE.PatientId=p.Id
right join Consultants c
on PE.ConsultantId =c.Id

select c.Id,c.Name,c.Salary,PCA.ConsultantId,PCA.PatientId 
from Consultants c
left join PatientConsultantAssignments PCA
on c.Id=PCA.ConsultantId

select p.DOB,p.Id,p.Name,p.WardId,w.Name
from Patients p 
full join Wards w
on p.WardId=w.Id

select c.Id,c.Name,c.Salary,PCA.ConsultantId,PCA.PatientId 
from Consultants c
full join PatientConsultantAssignments PCA
on c.Id=PCA.ConsultantId

select n.Address,n.ManagerId,n.Name as nurse_name,n.Number,n.Salary,n.ServesInWardId,n.SupervisedWardId,M.Name as manager_name
from Nurses n
 join Nurses M
on n.ManagerId=M.Number

select n.ManagerId,n.Name as nurse_name,M.Name as manager_name
from Nurses n
 join Nurses M
on n.ManagerId=M.Number





select p.DOB,p.Id,p.Name,p.WardId,c.Id,c.Name,c.Salary
from Patients p
cross join Consultants c


select w.Id ,w.Name,c.Id,c.Name,c.Salary
from Wards w
cross join Consultants c

select p.Name,p.WardId,c.Name as consultant_name
from PatientExaminations PE
inner join Patients p
on PE.PatientId=p.Id
inner join Consultants c
on PE.ConsultantId =c.Id

select p.Name as patient_name,n.Name as nurse_name,DA.DrugCode
from DrugAdministrations DA
inner join Patients p
on DA.PatientId=p.Id
inner join Nurses n
on n.Number=DA.NurseId


select p.Name as patient_name,p.WardId,n.Name as nurse_name,DA.Dosage
from DrugAdministrations DA
inner join Patients p
on DA.PatientId=p.Id
inner join Nurses n
on n.Number=DA.NurseId



select p.Name as patient_name,w.Name as ward_name,c.Name as consultant_name
from Patients p
inner join Wards w
on w.Id=p.WardId
inner join PatientExaminations PA
on PA.PatientId =p.Id
inner join Consultants c
on PA.ConsultantId=c.Id

select p.Name ,n.Name,DA.DrugCode,DA.Dosage,DA.DATE,DA.Time
from DrugAdministrations DA
inner join Patients p
on DA.PatientId=p.Id
inner join Nurses n
on n.Number=DA.NurseId 

select c.Name,c.Id,c.Salary,
row_number()over(order by c.Salary desc) as rank_row
from Consultants c


select c.Name,c.Id,c.Salary,
row_number()over(order by c.Salary asc) as rank_row
from Consultants c

select c.Name,c.Id,c.Salary,
row_number()over(  order by c.Salary asc,c.Name asc) as rank_row
from Consultants c

select c.Name,c.Id,c.Salary,
DENSE_RANK()over(order by salary desc) as rank_row
from Consultants c

select c.Name,c.Id,c.Salary,
DENSE_RANK()over(order by salary asc) as rank_row
from Consultants c

select c.Name,c.Id,
DENSE_RANK()over(order by salary desc) as salary_rank
from Consultants c

select c.Name,c.Id,
DENSE_RANK()over(order by salary desc) as dense_rank
from Consultants c
select c.Name,c.Id,
RANK()over(order by salary desc) as rank
from Consultants c

select c.Name,c.Id,c.salary,
NTILE(2)over(order by salary desc)
as group_number
from Consultants c

select c.Name,c.Id,c.salary,
NTILE(3)over(order by salary desc)
as group_number
from Consultants c


select c.Name,c.Id,c.salary,
NTILE(4)over(order by salary desc)
as group_number
from Consultants c

select n.number,n.Name,n.Address,n.ServesInWardId,n.salary,
DENSE_RANK()over(partition by n.ServesInWardId  order by n.salary desc)
as rank_row
from Nurses n

SELECT
    N.Name,
    N.Number,
    N.Salary,
    N.ServesInWardId,
    ROW_NUMBER() OVER (
        PARTITION BY N.ServesInWardId
        ORDER BY N.Salary ASC
    ) AS rank_row
FROM Nurses N;

SELECT
    N.Name,
    N.Number,
    N.Salary,
    N.ServesInWardId,
    dense_rank() OVER (
        PARTITION BY N.ServesInWardId
        ORDER BY N.Salary ASC
    ) AS rank_row
FROM Nurses N;

SELECT
    N.Name,
    N.Number,
    N.Salary,
    N.ServesInWardId,
    ntile(2) OVER (
        PARTITION BY N.ServesInWardId
        ORDER BY N.Salary ASC
    ) AS rank_row
FROM Nurses N;

select P.DOB,P.name,P.Id,P.WardId,C.Name as consultant_name,C.Salary,
DENSE_RANK()over(order by C.salary desc) as salary_rank
from Patients P
inner join PatientExaminations PE
on p.Id=PE.PatientId
inner join Consultants C
on C.Id=PE.ConsultantId



select  P.DOB,P.name,P.Id,N.Name as nurse_name,N.Salary as nurse_salary,DA.Dosage as drug_dosage,
DENSE_RANK()over( order by N.salary desc) as salary_rank
from Patients P
inner join DrugAdministrations DA
on p.Id = DA.PatientId
inner join Nurses N
ON N.Number=DA.NurseId
