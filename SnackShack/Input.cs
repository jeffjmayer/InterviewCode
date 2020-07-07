using System;

namespace SnackShack
{
    public class Input : InputImplementation
    {        
        public override int CustomerWants(string quesiton, string type, InventoryManager inventory)
        {
            return GetUserInput(quesiton, type, inventory);
        }

        public int GetUserInput(string question, string type, InventoryManager inventory)
        {
            Console.WriteLine(question);

            try
            {
                int answer = Convert.ToInt32(Console.ReadLine());

                ProcessAnswer(answer, type, inventory);                
            }
            catch
            {                
                Console.WriteLine("IO error trying to read your answer needs to be a small integer" + "\n");                
            }

            CustomerInput(question, type, inventory);

            return 0;
        }
    }
}