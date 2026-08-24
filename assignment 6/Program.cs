namespace assignment_6
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
                    weight = value;
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
                    deliveryFee = value;
            }
        }

        public virtual decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + Weight * 5;
            }
        }

        public Shipment(string trackingCode)
        {
            this.trackingCode = trackingCode;
            description = "Unknown";
            weight = 1;
            deliveryFee = 50;
            Destination = new DeliveryAddress("Unknown", "Unknown", 0);
        }

        public Shipment(string trackingCode, string description,
            decimal weight, decimal deliveryFee,
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
                DeliveryFee = newFee;
        }

        public virtual void PrintShipment()
        {
            Console.WriteLine("Tracking Code: " + TrackingCode);
            Console.WriteLine("Description: " + Description);
            Console.WriteLine("Weight: " + Weight);
            Console.WriteLine("Delivery Fee: " + DeliveryFee);
            Console.WriteLine("Destination: " + Destination.GetFullAddress());
            Console.WriteLine("Estimated Cost: " + EstimatedCost);
        }
    }


    class StandardShipment : Shipment
    {
        public StandardShipment(string trackingCode, string description,
            decimal weight, decimal deliveryFee,
            DeliveryAddress destination)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
        }
    }


    class ExpressShipment : Shipment
    {
        public decimal ExtraFee { get; set; }

        public ExpressShipment(string trackingCode, string description,
            decimal weight, decimal deliveryFee,
            DeliveryAddress destination, decimal extraFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            ExtraFee = extraFee;
        }

        public override decimal EstimatedCost
        {
            get
            {
                return base.EstimatedCost + ExtraFee;
            }
        }

        public override void PrintShipment()
        {
            base.PrintShipment();
            Console.WriteLine("Extra Fee: " + ExtraFee);
        }
    }


    class InternationalShipment : Shipment
    {
        public string DestinationCountry { get; set; }
        public decimal CustomsFee { get; set; }

        public InternationalShipment(string trackingCode, string description,
            decimal weight, decimal deliveryFee,
            DeliveryAddress destination,
            string destinationCountry, decimal customsFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }

        public override decimal EstimatedCost
        {
            get
            {
                return base.EstimatedCost + CustomsFee;
            }
        }

        public override void PrintShipment()
        {
            base.PrintShipment();
            Console.WriteLine("Destination Country: " + DestinationCountry);
            Console.WriteLine("Customs Fee: " + CustomsFee);
        }
    }


    class DeliveryCenter
    {
        private Shipment[] shipments = new Shipment[20];

        public string CenterName { get; set; }

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


    class Program
    {
        static void Main(string[] args)
        {
            DeliveryAddress address1 =
                new DeliveryAddress("Cairo", "Nasr Street", 10);

            DeliveryAddress address2 =
                new DeliveryAddress("Giza", "Main Street", 20);

            DeliveryAddress address3 =
                new DeliveryAddress("Alexandria", "Corniche", 30);


            StandardShipment standard =
                new StandardShipment(
                    "S001",
                    "Books",
                    2,
                    50,
                    address1);

            ExpressShipment express =
                new ExpressShipment(
                    "E001",
                    "Laptop",
                    3,
                    60,
                    address2,
                    30);

            InternationalShipment international =
                new InternationalShipment(
                    "I001",
                    "Clothes",
                    5,
                    100,
                    address3,
                    "USA",
                    50);


            DeliveryCenter center =
                new DeliveryCenter("Main Center");

            center.AddShipment(standard);
            center.AddShipment(express);
            center.AddShipment(international);


            Console.WriteLine("All Shipments");
            Console.WriteLine();

            center.PrintAllShipments();


            Console.WriteLine("Search Shipment");

            Shipment shipment = center["E001"];

            if (shipment != null)
            {
                shipment.PrintShipment();
            }
            else
            {
                Console.WriteLine("Shipment not found");
            }


            Console.WriteLine();
            Console.WriteLine("Remove Shipment");

            if (center.RemoveShipment("S001"))
            {
                Console.WriteLine("Shipment removed");
            }


            Console.WriteLine();
            Console.WriteLine("Remaining Shipments");
            Console.WriteLine();

            center.PrintAllShipments();
        }
    }
}