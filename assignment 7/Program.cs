namespace assignment_7
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


   

    class Shipment
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


        
        public virtual decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5);
            }
        }


        
        public Shipment(string trackingCode)
        {
            this.trackingCode = trackingCode;

            description = "Unknown";
            weight = 1;
            deliveryFee = 50;

            Destination = new DeliveryAddress(
                "Unknown",
                "Unknown",
                0);
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


        
        public void UpdateWeight(decimal newWeight)
        {
            if (newWeight > 0)
            {
                Weight = newWeight;
            }
        }


       
        public void UpdateWeight(decimal newWeight, decimal packingWeight)
        {
            if (newWeight > 0)
            {
                Weight = newWeight + packingWeight;
            }
        }


        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0)
            {
                DeliveryFee = newFee;
            }
        }


       
        public virtual void PrintShipment()
        {
            Console.WriteLine("Tracking Code : " + TrackingCode);
            Console.WriteLine("Description : " + Description);
            Console.WriteLine("Weight : " + Weight + " KG");
            Console.WriteLine("Delivery Fee : " + DeliveryFee + " EGP");
            Console.WriteLine("Estimated Cost : " + EstimatedCost + " EGP");
        }
    }


    

    class StandardShipment : Shipment
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


        
        public override void PrintShipment()
        {
            Console.WriteLine("Standard Shipment");
            base.PrintShipment();
        }
    }


    

    class ExpressShipment : Shipment
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

            base.PrintShipment();

            Console.WriteLine("Extra Fee : " + ExtraFee + " EGP");
        }
    }


    

    class InternationalShipment : Shipment
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


        public virtual string GenerateCustomsReport()
        {
            return "Customs Report for " + DestinationCountry;
        }


        public override void PrintShipment()
        {
            Console.WriteLine("International Shipment");

            base.PrintShipment();

            Console.WriteLine(
                "Destination Country : " + DestinationCountry);

            Console.WriteLine(
                "Customs Fee : " + CustomsFee + " EGP");
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
            return "Priority Customs Report for "
                + DestinationCountry;
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

                    Console.WriteLine();
                }
            }
        }
    }


   

    static class DeliveryHelper
    {
        public static void PrintShipmentDetails(Shipment shipment)
        {
            shipment.PrintShipment();
        }
    }


   
    class Program
    {
        static void Main(string[] args)
        {
            

            Driver driver = new Driver(
                1,
                "Ahmed Mohamed",
                "01012345678");


            

            DeliveryCenter center =
                new DeliveryCenter("Main Delivery Center");

            center.Driver = driver;


           

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


            

            center.AddShipment(standard);
            center.AddShipment(express);
            center.AddShipment(international);


            

            Console.WriteLine("==========================================");
            Console.WriteLine("Delivery Center");
            Console.WriteLine("==========================================");

            Console.WriteLine("Driver : " + center.Driver.FullName);

            Console.WriteLine("------------------------------------------");


           

            center.PrintAllShipments();


           

            Console.WriteLine("==========================================");
            Console.WriteLine("Printing Using DeliveryHelper");
            Console.WriteLine("==========================================");

            DeliveryHelper.PrintShipmentDetails(standard);

            Console.WriteLine();

            DeliveryHelper.PrintShipmentDetails(express);

            Console.WriteLine();

            DeliveryHelper.PrintShipmentDetails(international);


            

            Console.WriteLine("==========================================");
            Console.WriteLine("Updating Weight");
            Console.WriteLine("==========================================");

            Console.WriteLine("Original Weight : " + standard.Weight + " KG");

            standard.UpdateWeight(5);

            Console.WriteLine(
                "Updated Weight : " + standard.Weight + " KG");

            standard.UpdateWeight(5, 0.5m);

            Console.WriteLine(
                "Updated Weight After Packing : "
                + standard.Weight + " KG");


            

            Console.WriteLine("==========================================");
            Console.WriteLine("Printing Using Shipment[]");
            Console.WriteLine("==========================================");

            Shipment[] allShipments =
            {
            standard,
            express,
            international
        };


            for (int i = 0; i < allShipments.Length; i++)
            {
                allShipments[i].PrintShipment();

                Console.WriteLine();
            }


           

            Console.WriteLine("==========================================");
            Console.WriteLine("Sealed Method");
            Console.WriteLine("==========================================");

            PriorityInternationalShipment priority =
                new PriorityInternationalShipment(
                    "SH004",
                    "Documents",
                    2,
                    100,
                    address3,
                    "France",
                    50);

            Console.WriteLine(
                priority.GenerateCustomsReport());


            

            CompletedShipment completed =
                new CompletedShipment(
                    "SH005",
                    "Package",
                    4,
                    70,
                    address1);

            Console.WriteLine();
            Console.WriteLine("Completed Shipment:");
            completed.PrintShipment();


          
        }
    }
}
