using System;
using System.Collections.Generic;
using System.Text;

namespace SnackShack
{
    class SnackShack
    {
        static void Main(string[] args)
        {
            var factory = new SnackShackFactory();
            var store = new SnackShackStore(factory);

            var sandwich = store.OrderSandwich("standard");
            Console.WriteLine("Take a break from making " + sandwich.name + "\n");
            
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

        public Sandwich OrderSandwich(string type)
        {
            Sandwich sandwich = _factory.MakeSandwich(type);

            sandwich.Making();
            sandwich.Serve();
           
            return sandwich;
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
            Console.WriteLine(sandwich);
            return sandwich;
        }
    }

    abstract public class Sandwich
    {
        private string _name;
        protected Sandwich(string name)
        {
            _name = name;           
        }

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public void Making()
        {
            Console.WriteLine("Making " + _name);
        }

        public void Serve()
        {
            Console.WriteLine("Serve " + _name);
        }

        public override string ToString()
        {
            var display = new StringBuilder();
            display.Append("---- " + _name + " ----\n");
        
            return display.ToString();
        }
    }

    public class StandardSandwich : Sandwich
    {
        public StandardSandwich() :
            base("Standard Sandwich")
        {
        }
    }
    
    // added an example of extending the kind of sandwiches
    public class DeluxeSandwich : Sandwich
    {
        public DeluxeSandwich() :
            base("Deluxe Sandwich")
        {
        }
    }
   
}

