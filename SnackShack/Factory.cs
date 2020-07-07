namespace SnackShack
{
    public class Factory
    {
        public MakeOrder MakeSandwich(string type)
        {
            MakeOrder makeOrder = null;
            switch (type)
            {
                case "standard": makeOrder = new Standard(); break;
            }
            return makeOrder;
        }
    }
}