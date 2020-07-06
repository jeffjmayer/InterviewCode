using System;


namespace SnackShack
{
    public class SnackShack
    {
        static void Main()
        {
            var factory = new SnackShackFactory();
            var store = new SnackShackStore(factory);
           
            store.OrderSandwich("standard", 1);
            store.OrderSandwich("standard", 2);
            store.OrderSandwich("standard", 3);
            store.OrderSandwich("standard", 4);
            
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

        public void OrderSandwich(string type, int amount)
        {
            var order = _factory.MakeSandwich(type);
            order.amount = amount;

            if (order.Estimate())
            {
                order.Make();
                Console.WriteLine(order.time.ToString("m:ss") + " take a well earned break!" + "\n");
            }
            else
            {
                order.Reject();
            }          
        }
    }
    
    abstract public class Sandwich
    {
        const int Seconds = 30;
        const int Minute = 1;
        const int Zero = 0;
        const int RejectLimit = 5;
        const int One = 1;
        
        protected Sandwich(string type)
        {
            this.type = type;
            time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Zero, Zero, Zero);             
        }

        public string type { get; set; }
        public DateTime time { get; set; }
        public int amount { get; set; }

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

       public void Reject()
        {
            Console.WriteLine("Order rejected due to time contraints!");
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

