using System;

namespace SnackShack
{
    public class Input : InputImplementation
    {        
        public override int CustomerWants(string quesiton, string type)
        {
            return GetUserInput(quesiton, type);
        }

        public int GetUserInput(string question, string type)
        {
            Console.WriteLine(question);

            try
            {
                int answer = Convert.ToInt32(Console.ReadLine());

                ProcessAnswer(answer, type);                
            }
            catch
            {                
                Console.WriteLine("IO error trying to read your answer needs to be a small integer" + "\n");                
            }

            CustomerInput(question, type);

            return 0;
        }
    }
}