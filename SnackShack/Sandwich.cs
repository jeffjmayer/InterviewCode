using System;

namespace SnackShack
{
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
                    Console.WriteLine("\n" + time.ToString("m:ss") + " " + amount + " sandwich orders placed, start making " + type + " " + sandwich);
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
            Console.WriteLine("\n" + "Order rejected!" + "\n");
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