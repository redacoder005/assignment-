namespace assignment_8
{
    using System;

    struct DeliveryAddress
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

    interface ITrackable
    {
        string GetTrackingStatus();
    }

    interface IInsurable
    {
        decimal CalculateInsurance();
    }

    abstract class Shipment
    {
        private string trackingCode;
        private string description;
        private decimal weight;
        private decimal deliveryFee;

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
        }

        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0)
            {
                DeliveryFee = newFee;
            }
        }

        public abstract decimal EstimatedCost { get; }

        public abstract void PrintShipment();
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
            Console.WriteLine("Estimated Cost: " + EstimatedCost + " EGP");
        }

        public string GetTrackingStatus()
        {
            return "Shipment " + TrackingCode + " is Ready.";
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
            Console.WriteLine("Estimated Cost: " + EstimatedCost + " EGP");
        }

        public string GetTrackingStatus()
        {
            return "Shipment " + TrackingCode + " is Out for Delivery.";
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

        public string GetTrackingStatus()
        {
            return "Shipment " + TrackingCode + " has been Delivered.";
        }

        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.12m;
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
                    ITrackable shipment =
                        (ITrackable)shipments[i];

                    Console.WriteLine(
                        shipment.GetTrackingStatus());
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
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

            DeliveryCenter center =
                new DeliveryCenter("Main Delivery Center");

            center.AddShipment(standard);
            center.AddShipment(express);
            center.AddShipment(international);

            Console.WriteLine("==========================================");
            Console.WriteLine("Delivery Center");
            Console.WriteLine("==========================================");

            center.PrintAllShipments();

            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("Tracking Status");
            Console.WriteLine("==========================================");

            center.PrintTrackingStatuses();

            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("Insurance");
            Console.WriteLine("==========================================");

            DeliveryReport report =
                new DeliveryReport();

            report.PrintInsurance(standard);
            report.PrintInsurance(express);
            report.PrintInsurance(international);

            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("ITrackable Array");
            Console.WriteLine("==========================================");

            ITrackable[] trackableShipments =
            {
                standard,
                express,
                international
            };

            for (int i = 0; i < trackableShipments.Length; i++)
            {
                Console.WriteLine(
                    trackableShipments[i].GetTrackingStatus());
            }

            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("IInsurable Array");
            Console.WriteLine("==========================================");

            IInsurable[] insurableShipments =
            {
                standard,
                express,
                international
            };

            for (int i = 0; i < insurableShipments.Length; i++)
            {
                Console.WriteLine(
                    "Insurance : "
                    + insurableShipments[i].CalculateInsurance()
                    + " EGP");
            }
        }
    }
}