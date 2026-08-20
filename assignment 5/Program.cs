namespace assignment_5
{
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

    struct Shipment
    {
        private string trackingCode;
        private string description;
        private double weight;
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
                if (!string.IsNullOrWhiteSpace(value))
                {
                    description = value;
                }
            }
        }

        public double Weight
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

        public decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + ((decimal)Weight * 5);
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
            double weight,
            decimal deliveryFee,
            DeliveryAddress destination)
        {
            this.trackingCode = trackingCode;

            if (string.IsNullOrWhiteSpace(description))
            {
                this.description = "Unknown";
            }
            else
            {
                this.description = description;
            }

            if (weight > 0)
            {
                this.weight = weight;
            }
            else
            {
                this.weight = 1;
            }

            if (deliveryFee > 0)
            {
                this.deliveryFee = deliveryFee;
            }
            else
            {
                this.deliveryFee = 50;
            }

            Destination = destination;
        }

        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0)
            {
                DeliveryFee = newFee;
            }
        }

        public void PrintShipment()
        {
            Console.WriteLine("Tracking Code: " + TrackingCode);
            Console.WriteLine("Description: " + Description);
            Console.WriteLine("Weight: " + Weight);
            Console.WriteLine("Delivery Fee: " + DeliveryFee);
            Console.WriteLine("Destination: " + Destination.GetFullAddress());
            Console.WriteLine("Estimated Cost: " + EstimatedCost);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DeliveryAddress address1 =
                new DeliveryAddress("Cairo", "Nasr Street", 10);

            Shipment shipment1 =
                new Shipment(
                    "S001",
                    "Books",
                    2,
                    50,
                    address1);

            shipment1.PrintShipment();

            Console.WriteLine();

            DeliveryAddress address2 = address1;

            address2.City = "Giza";
            address2.BuildingNumber = 20;

            Console.WriteLine("Original Address:");
            Console.WriteLine(address1.GetFullAddress());

            Console.WriteLine("Copied Address:");
            Console.WriteLine(address2.GetFullAddress());
        }
    }
}
