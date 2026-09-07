namespace assignment_9
{
    using System;

    class DeliveryAddress
    {
        public string City;
        public string Street;
        public int BuildingNumber;

        public DeliveryAddress(string city, string street, int buildingNumber)
        {
            City = city;
            Street = street;
            BuildingNumber = buildingNumber;
        }

        public string GetFullAddress()
        {
            return City + ", " + Street + ", Building " + BuildingNumber;
        }
    }

    interface ITrackable
    {
        string GetTrackingStatus();
    }

    interface IInsurable
    {
        decimal CalculateInsurance();
    }

    class Driver
    {
        public int DriverId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public Driver(int driverId, string fullName, string phoneNumber)
        {
            DriverId = driverId;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }
    }

    partial class Shipment
    {
        private string trackingCode;
        private string description;
        private decimal weight;
        private decimal deliveryFee;

        public static int TotalShipmentsCreated;

        public DeliveryAddress Destination { get; set; }

        public string TrackingCode
        {
            get
            {
                return trackingCode;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public decimal Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value > 0)
                {
                    weight = value;
                }
            }
        }

        public decimal DeliveryFee
        {
            get
            {
                return deliveryFee;
            }
            private set
            {
                if (value > 0)
                {
                    deliveryFee = value;
                }
            }
        }

        public Shipment(
            string trackingCode,
            string description,
            decimal weight,
            decimal deliveryFee,
            DeliveryAddress destination)
        {
            this.trackingCode = trackingCode;
            this.description = description;
            this.weight = weight;
            this.deliveryFee = deliveryFee;
            Destination = destination;

            TotalShipmentsCreated++;
        }

        static Shipment()
        {
            TotalShipmentsCreated = 0;
            Console.WriteLine("Shipment System Initialized");
        }

        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0)
            {
                DeliveryFee = newFee;
            }
        }

        public virtual decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5);
            }
        }

        public virtual void PrintShipment()
        {
            Console.WriteLine("Tracking Code : " + TrackingCode);
            Console.WriteLine("Description : " + Description);
            Console.WriteLine("Estimated Cost : " + EstimatedCost + " EGP");
        }

        public static int GetTotalShipmentsCreated()
        {
            return TotalShipmentsCreated;
        }

        public Shipment CopyShipment()
        {
            return DeepCopy();
        }

        public Shipment ShallowCopy()
        {
            return (Shipment)MemberwiseClone();
        }

        public Shipment DeepCopy()
        {
            Shipment copy = (Shipment)MemberwiseClone();

            copy.Destination = new DeliveryAddress(
                Destination.City,
                Destination.Street,
                Destination.BuildingNumber);

            return copy;
        }
    }

    partial class Shipment
    {
        private string trackingStatus;

        public string TrackingStatus
        {
            get
            {
                return trackingStatus;
            }
        }

        public void SetTrackingStatus(string status)
        {
            trackingStatus = status;
        }

        public void UpdateTrackingStatus(string newStatus)
        {
            trackingStatus = newStatus;

            OnTrackingStatusChanged(newStatus);
        }

        public string GetTrackingStatus()
        {
            return trackingStatus;
        }

        private void OnTrackingStatusChanged(string newStatus)
        {
            Console.WriteLine("Tracking status changed to: " + newStatus);
        }
    }

    class StandardShipment : Shipment, ITrackable, IInsurable
    {
        public StandardShipment(
            string trackingCode,
            string description,
            decimal weight,
            decimal deliveryFee,
            DeliveryAddress destination)
            : base(
                trackingCode,
                description,
                weight,
                deliveryFee,
                destination)
        {
            SetTrackingStatus("In Transit");
        }

        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5);
            }
        }

        public override void PrintShipment()
        {
            Console.WriteLine("Standard Shipment");
            Console.WriteLine("Tracking Code : " + TrackingCode);
            Console.WriteLine("Description : " + Description);
            Console.WriteLine("Estimated Cost : " + EstimatedCost + " EGP");
        }

        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.05m;
        }
    }

    class ExpressShipment : Shipment, ITrackable, IInsurable
    {
        public decimal ExtraFee { get; set; }

        public ExpressShipment(
            string trackingCode,
            string description,
            decimal weight,
            decimal deliveryFee,
            DeliveryAddress destination,
            decimal extraFee)
            : base(
                trackingCode,
                description,
                weight,
                deliveryFee,
                destination)
        {
            ExtraFee = extraFee;
            SetTrackingStatus("Out For Delivery");
        }

        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5) + ExtraFee;
            }
        }

        public override void PrintShipment()
        {
            Console.WriteLine("Express Shipment");
            Console.WriteLine("Tracking Code : " + TrackingCode);
            Console.WriteLine("Extra Fee : " + ExtraFee + " EGP");
            Console.WriteLine("Estimated Cost : " + EstimatedCost + " EGP");
        }

        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.08m;
        }
    }

    class InternationalShipment : Shipment, ITrackable, IInsurable
    {
        public string DestinationCountry { get; set; }

        public decimal CustomsFee { get; set; }

        public InternationalShipment(
            string trackingCode,
            string description,
            decimal weight,
            decimal deliveryFee,
            DeliveryAddress destination,
            string destinationCountry,
            decimal customsFee)
            : base(
                trackingCode,
                description,
                weight,
                deliveryFee,
                destination)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;

            SetTrackingStatus("Delivered");
        }

        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5) + CustomsFee;
            }
        }

        public override void PrintShipment()
        {
            Console.WriteLine("International Shipment");
            Console.WriteLine("Tracking Code : " + TrackingCode);
            Console.WriteLine(
                "Destination Country : " + DestinationCountry);
            Console.WriteLine(
                "Estimated Cost : " + EstimatedCost + " EGP");
        }

        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.12m;
        }

        public virtual string GenerateCustomsReport()
        {
            return "Customs Report for " + TrackingCode;
        }
    }

    class PriorityInternationalShipment : InternationalShipment
    {
        public PriorityInternationalShipment(
            string trackingCode,
            string description,
            decimal weight,
            decimal deliveryFee,
            DeliveryAddress destination,
            string destinationCountry,
            decimal customsFee)
            : base(
                trackingCode,
                description,
                weight,
                deliveryFee,
                destination,
                destinationCountry,
                customsFee)
        {
        }

        public sealed override string GenerateCustomsReport()
        {
            return "Priority Customs Report for " + TrackingCode;
        }
    }

    sealed class CompletedShipment : Shipment
    {
        public CompletedShipment(
            string trackingCode,
            string description,
            decimal weight,
            decimal deliveryFee,
            DeliveryAddress destination)
            : base(
                trackingCode,
                description,
                weight,
                deliveryFee,
                destination)
        {
            SetTrackingStatus("Delivered");
        }

        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5);
            }
        }

        public override void PrintShipment()
        {
            Console.WriteLine("Completed Shipment");
            Console.WriteLine("Tracking Code : " + TrackingCode);
            Console.WriteLine(
                "Estimated Cost : " + EstimatedCost + " EGP");
        }
    }

    class DeliveryCenter
    {
        private Shipment[] shipments = new Shipment[20];

        public string CenterName { get; set; }

        public Driver Driver { get; set; }

        public DeliveryCenter(string centerName)
        {
            CenterName = centerName;
        }

        public Shipment this[int index]
        {
            get
            {
                return shipments[index];
            }

            set
            {
                shipments[index] = value;
            }
        }

        public Shipment this[string trackingCode]
        {
            get
            {
                for (int i = 0; i < shipments.Length; i++)
                {
                    if (shipments[i] != null &&
                        shipments[i].TrackingCode == trackingCode)
                    {
                        return shipments[i];
                    }
                }

                return null;
            }
        }

        public bool AddShipment(Shipment shipment)
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] == null)
                {
                    shipments[i] = shipment;
                    return true;
                }
            }

            return false;
        }

        public bool RemoveShipment(string trackingCode)
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] != null &&
                    shipments[i].TrackingCode == trackingCode)
                {
                    shipments[i] = null;
                    return true;
                }
            }

            return false;
        }

        public void PrintAllShipments()
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] != null)
                {
                    shipments[i].PrintShipment();

                    Console.WriteLine("------------------------------------------");
                }
            }
        }

        public void PrintTrackingStatuses()
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] != null)
                {
                    Console.WriteLine(
                        shipments[i].GetTrackingStatus());
                }
            }
        }
    }

    class DeliveryReport
    {
        public void PrintShipment(ITrackable shipment)
        {
            Console.WriteLine(shipment.GetTrackingStatus());
        }

        public void PrintInsurance(IInsurable shipment)
        {
            Console.WriteLine(
                "Insurance : "
                + shipment.CalculateInsurance()
                + " EGP");
        }
    }

    static class DeliveryUtilities
    {
        public static void PrintSeparator()
        {
            Console.WriteLine("==========================================");
        }

        public static void PrintSystemTitle()
        {
            PrintSeparator();
            Console.WriteLine("Smart Delivery Management System");
            PrintSeparator();
        }
    }

    static class ShipmentExtensions
    {
        public static string GetSummary(this Shipment shipment)
        {
            string type = shipment.GetType().Name;

            if (type == "StandardShipment")
            {
                type = "Standard";
            }
            else if (type == "ExpressShipment")
            {
                type = "Express";
            }
            else if (type == "InternationalShipment")
            {
                type = "International";
            }

            return shipment.TrackingCode
                + " | "
                + type
                + " | "
                + shipment.Weight
                + " KG | "
                + shipment.GetTrackingStatus();
        }

        public static bool IsDelivered(this Shipment shipment)
        {
            return shipment.GetTrackingStatus() == "Delivered";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DeliveryUtilities.PrintSystemTitle();

            Console.WriteLine("Creating Shipments...");
            DeliveryUtilities.PrintSeparator();

            DeliveryAddress address1 =
                new DeliveryAddress(
                    "Cairo",
                    "Nasr Street",
                    10);

            DeliveryAddress address2 =
                new DeliveryAddress(
                    "Giza",
                    "Main Street",
                    20);

            DeliveryAddress address3 =
                new DeliveryAddress(
                    "Alexandria",
                    "Corniche",
                    30);

            StandardShipment standard =
                new StandardShipment(
                    "SH001",
                    "Laptop",
                    3,
                    80,
                    address1);

            ExpressShipment express =
                new ExpressShipment(
                    "SH002",
                    "Mobile Phone",
                    2,
                    60,
                    address2,
                    30);

            InternationalShipment international =
                new InternationalShipment(
                    "SH003",
                    "Television",
                    8,
                    120,
                    address3,
                    "Germany",
                    100);

            Console.WriteLine("Standard Shipment Created");
            Console.WriteLine("Express Shipment Created");
            Console.WriteLine("International Shipment Created");

            Console.WriteLine(
                "Total Shipments Created : "
                + Shipment.GetTotalShipmentsCreated());

            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Object Copying");
            DeliveryUtilities.PrintSeparator();

            Shipment shipment1 = standard;
            Shipment shipment2 = shipment1;

            Console.WriteLine(
                "Original Shipment : "
                + shipment1.TrackingCode);

            Console.WriteLine(
                "Assigned Shipment : "
                + shipment2.TrackingCode);

            Console.WriteLine(
                "Same Object : "
                + Object.ReferenceEquals(
                    shipment1,
                    shipment2));

            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Shallow Copy");
            DeliveryUtilities.PrintSeparator();

            Shipment shallowCopy = standard.ShallowCopy();

            Console.WriteLine(
                "Original Shipment Address : "
                + standard.Destination.City);

            Console.WriteLine(
                "Copied Shipment Address : "
                + shallowCopy.Destination.City);

            Console.WriteLine("Changing copied shipment address...");

            shallowCopy.Destination.City = "Giza";

            Console.WriteLine(
                "Original Shipment Address : "
                + standard.Destination.City);

            Console.WriteLine(
                "Copied Shipment Address : "
                + shallowCopy.Destination.City);

            Console.WriteLine(
                "Same DeliveryAddress Object : "
                + Object.ReferenceEquals(
                    standard.Destination,
                    shallowCopy.Destination));

            standard.Destination.City = "Cairo";

            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Deep Copy");
            DeliveryUtilities.PrintSeparator();

            Shipment deepCopy = standard.DeepCopy();

            Console.WriteLine(
                "Original Shipment Address : "
                + standard.Destination.City);

            Console.WriteLine(
                "Copied Shipment Address : "
                + deepCopy.Destination.City);

            Console.WriteLine("Changing copied shipment address...");

            deepCopy.Destination.City = "Giza";

            Console.WriteLine(
                "Original Shipment Address : "
                + standard.Destination.City);

            Console.WriteLine(
                "Copied Shipment Address : "
                + deepCopy.Destination.City);

            Console.WriteLine(
                "Same DeliveryAddress Object : "
                + Object.ReferenceEquals(
                    standard.Destination,
                    deepCopy.Destination));

            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Extension Methods");
            DeliveryUtilities.PrintSeparator();

            Console.WriteLine(standard.GetSummary());
            Console.WriteLine(express.GetSummary());
            Console.WriteLine(international.GetSummary());

            Console.WriteLine(
                "SH001 Is Delivered : "
                + standard.IsDelivered());

            Console.WriteLine(
                "SH003 Is Delivered : "
                + international.IsDelivered());

            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Tracking Status");
            DeliveryUtilities.PrintSeparator();

            express.UpdateTrackingStatus("Out For Delivery");

            DeliveryUtilities.PrintSeparator();

            DeliveryCenter center =
                new DeliveryCenter(
                    "Main Delivery Center");

            center.AddShipment(standard);
            center.AddShipment(express);
            center.AddShipment(international);

            center.PrintAllShipments();

            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Static Utilities");
            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Delivery Center");

            Console.WriteLine(
                "Total Shipments Created : "
                + Shipment.GetTotalShipmentsCreated());

            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Partial Method");
            DeliveryUtilities.PrintSeparator();

            international.UpdateTrackingStatus("Delivered");

            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Assignment Completed");
            DeliveryUtilities.PrintSeparator();
        }
    }
}
