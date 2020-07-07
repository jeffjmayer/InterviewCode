using System;

namespace SnackShack
{
    abstract public class Sandwich
    {
        private const int ThirtySeconds = 30;
        private const int SevenSeconds = 7;
        private const int Minute = 1;
        private const int Zero = 0;
        private const int One = 1;
        
        private int _rejectLimit = 5;
        
        protected Sandwich(string type)
        {
            this.type = type;

            sandwichTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Zero, Zero, Zero);
            jacketTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Zero, Zero, Zero);             
        }

        public string type { get; set; }
        public DateTime sandwichTime { get; set; }
        public DateTime jacketTime { get; set; }
        public int amount { get; set; }
        public bool addJacketPotatoes { get; set; }

        public bool Estimate()
        {
            int multiplier = amount;

            if (addJacketPotatoes)
            {
                _rejectLimit = SevenSeconds;
                multiplier = (amount + 4);
            }

            return sandwichTime.AddMinutes(amount).Minute + sandwichTime.AddSeconds(ThirtySeconds * multiplier).Minute <= _rejectLimit;
        }

        public void Make()
        {
            if (addJacketPotatoes && sandwichTime.ToString("m:ss") == "0:00")
            {
                sandwichTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Zero, Zero, One);
                Console.WriteLine("\n" + jacketTime.ToString("m:ss") + " Put jacket potato in microwave");
            }
            
            for (var sandwich = One; sandwich <= amount; sandwich++)
            {
                if (!addJacketPotatoes && sandwichTime.ToString("m:ss") == "0:00")
                {
                    Console.WriteLine("\n" + sandwichTime.ToString("m:ss") + " " + amount + " sandwich orders placed, start making " + type + " " + sandwich);
                }
                else
                {
                    Console.WriteLine(sandwichTime.ToString("m:ss") + " make " + type + " " + sandwich);
                }

                sandwichTime = sandwichTime.AddMinutes(Minute); 
                Console.WriteLine(sandwichTime.ToString("m:ss") + " serve " + type + " " + sandwich);
                sandwichTime = sandwichTime.AddSeconds(ThirtySeconds);       
            }

            if (addJacketPotatoes)
            {
                Console.WriteLine(sandwichTime.ToString("m:ss") + " take jacket potato out of microwave");
                sandwichTime = sandwichTime.AddSeconds(ThirtySeconds);
                Console.WriteLine(sandwichTime.ToString("m:ss") + " top jacket potato");
                sandwichTime = sandwichTime.AddSeconds(ThirtySeconds);
                Console.WriteLine(sandwichTime.ToString("m:ss") + " serve jacket potato");
                sandwichTime = sandwichTime.AddSeconds(ThirtySeconds);
            }            
        }

        public void Reject()
        {
            Console.WriteLine("\n" + "Order rejected! Customer won't wait." + "\n");
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