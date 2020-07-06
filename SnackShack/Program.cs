using System;


namespace SnackShack
{
    public class SnackShack
    {
        static void Main()
        {
            var factory = new SnackShackFactory();
            var store = new SnackShackStore(factory);
           
            var order = store.OrderSandwich("standard", 3, 45);
            order.inventory = order.inventory-3;

            order = store.OrderSandwich("standard", 4, order.inventory);
            
            for (int i = 0; i < 15; i++) 
            {
                store.OrderSandwich("standard", 3, order.inventory);
                order.inventory = order.inventory - 3;            
            }
            
            Console.ReadKey();
        }
    }
   
    public class SnackShackStore
    {
        private readonly SnackShackFactory _factory;

        public SnackShackStore(SnackShackFactory factory)
        {
            _factory = factory;
        }

        public Sandwich OrderSandwich(string type, int amount, int inventory)
        {
            var order = _factory.MakeSandwich(type);
            order.amount = amount;
            order.inventory = inventory;

            if (order.Estimate())
            {
                if (inventory > 0)
                {
                    order.Make();
                    Console.WriteLine(order.time.ToString("m:ss") + " take a well earned break!" + "\n");                    
                }
                else
                {
                    order.Reject("Inventory");
                }
            }
            else
            {
                order.Reject("time");
            }
            return order;
        }
    }
    
    abstract public class Sandwich
    {
        private const int Seconds = 30;
        private const int Minute = 1;
        private const int Zero = 0;
        private const int RejectLimit = 5;
        private const int One = 1;
        
        protected Sandwich(string type)
        {
            this.type = type;
            time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Zero, Zero, Zero);             
        }

        public string type { get; set; }
        public DateTime time { get; set; }
        public int amount { get; set; }
        public int inventory { get; set; }

        public bool Estimate()
        {
            
            return time.AddMinutes(amount).Minute + time.AddSeconds(Seconds * amount).Minute <= RejectLimit;
        }

        public void Make()
        {
            for (var sandwich = One; sandwich <= amount; sandwich++)
            {
                if (time.ToString("m:ss") == "0:00")
                {
                    Console.WriteLine(time.ToString("m:ss") + " " + amount + " sandwich orders placed, start making " + type + " " + sandwich);
                }
                else
                {
                    Console.WriteLine(time.ToString("m:ss") + " make " + type + " " + sandwich);
                }

                time = time.AddMinutes(Minute); 
                Console.WriteLine(time.ToString("m:ss") + " serve " + type + " " + sandwich);
                time = time.AddSeconds(Seconds);       
            }
           
        }

       public void Reject(string type)
        {
            Console.WriteLine("Order rejected due to " + type + " Contraints!" + "\n");
        }
    }

    public class SnackShackFactory
    {
        public Sandwich MakeSandwich(string type)
        {
            Sandwich sandwich = null;
            switch (type)
            {
                case "standard": sandwich = new StandardSandwich(); break;
            }
            return sandwich;
        }
    }

    public class StandardSandwich : Sandwich
    {
        public StandardSandwich() :
            base("sandwich")
        {
        }
    }   
}

