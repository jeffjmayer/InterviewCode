using System;

namespace SnackShack
{
    abstract public class MakeOrder
    {
        private const int ThirtySeconds = 30;
        private const int SevenSeconds = 7;
        private const int Minute = 1;
        private const int Zero = 0;
        private const int One = 1;
        
        private int _rejectLimit = 5;
        
        protected MakeOrder(string type)
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
            int lineNumber = 1;

            if (addJacketPotatoes && sandwichTime.ToString("m:ss") == "0:00")
            {
                sandwichTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Zero, Zero, One);
                Console.WriteLine("\n" + lineNumber + ". " + jacketTime.ToString("m:ss") + " Put jacket potato in microwave");
            }
            
            for (var sandwich = One; sandwich <= amount; sandwich++)
            {
                if (!addJacketPotatoes && sandwichTime.ToString("m:ss") == "0:00")
                {
                    Console.WriteLine("\n" + lineNumber + ". " + sandwichTime.ToString("m:ss") + " " + amount + " sandwich orders placed, start making " + type + " " + sandwich);
                }
                else
                {
                    lineNumber++;
                    Console.WriteLine(lineNumber + ". " + sandwichTime.ToString("m:ss") + " make " + type + " " + sandwich);
                }

                lineNumber++;
                sandwichTime = sandwichTime.AddMinutes(Minute); 
                Console.WriteLine(lineNumber + ". " + sandwichTime.ToString("m:ss") + " serve " + type + " " + sandwich);
                sandwichTime = sandwichTime.AddSeconds(ThirtySeconds);       
            }

            if (addJacketPotatoes)
            {
                lineNumber++;
                Console.WriteLine(lineNumber + ". " + sandwichTime.ToString("m:ss") + " take jacket potato out of microwave");
                sandwichTime = sandwichTime.AddSeconds(ThirtySeconds);
                lineNumber++;
                Console.WriteLine(lineNumber + ". " + sandwichTime.ToString("m:ss") + " top jacket potato");
                sandwichTime = sandwichTime.AddSeconds(ThirtySeconds);
                lineNumber++;
                Console.WriteLine(lineNumber + ". " + sandwichTime.ToString("m:ss") + " serve jacket potato");
                sandwichTime = sandwichTime.AddSeconds(ThirtySeconds);
            }

            string message = addJacketPotatoes ? "take a break!" : "take a well earned break!";
            lineNumber++;
            Console.WriteLine(lineNumber + ". " + sandwichTime.ToString("m:ss") + " " + message + "\n"); 
        }

        public void Reject()
        {
            Console.WriteLine("\n" + "Order rejected! Customer won't wait." + "\n");
        }
    }
    
    public class Standard : MakeOrder
    {
        public Standard() :
            base("sandwich")
        {
        }
    }
}