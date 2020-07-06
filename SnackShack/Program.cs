using System;


namespace SnackShack
{
    class SnackShack
    {
        static void Main(string[] args)
        {
            var factory = new SnackShackFactory();
            var store = new SnackShackStore(factory);
            var time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            
            Sandwich order = new StandardSandwich();

            const int amount = 4;
            
            for (int sandwich = 1; sandwich <= amount; sandwich++)
            {
                order = store.OrderSandwich("standard", time, sandwich, amount);
                time = order.time;                
            }

            Console.WriteLine(order.time.ToString("m:ss") + " take a well earned break!" + "\n");

            if (time.Minute > 5)
            {
                Console.Clear();
                Console.WriteLine("Order rejected due to time contraints!");
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

        public Sandwich OrderSandwich(string type, DateTime time, int sandwich, int amount)
        {
            var order = _factory.MakeSandwich(type);
            order.time = time;
            order.sandwiches = sandwich;
            order.amount = amount;
            order.Make();
            order.Serve();
           
            return order;
        }
    }
    
    abstract public class Sandwich
    {
        protected Sandwich(string type)
        {
            this.type = type;
            
            time = time;
            sandwiches = sandwiches;
        }

        public string type { get; set; }
        public DateTime time { get; set; }
        public int sandwiches { get; set; }
        public int amount { get; set; }

        public void Make()
        {            
            if (time.ToString("m:ss") == "0:00")
            {
                Console.WriteLine(time.ToString("m:ss") + " " + amount + " sandwich orders placed, start making " + type + " " + sandwiches);
            }
            else
            {
                Console.WriteLine(time.ToString("m:ss") + " make " + type + " " + sandwiches);
            }

            time = time.AddMinutes(1);
        }

        public void Serve()
        {
            Console.WriteLine(time.ToString("m:ss") + " serve " + type + " " + sandwiches);
            time = time.AddSeconds(30);
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

