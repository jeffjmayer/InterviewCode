namespace SnackShack
{
    public class Factory
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
}