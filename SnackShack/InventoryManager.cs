namespace SnackShack
{
    public class InventoryManager
    {
        private readonly IInventory _out;
        private readonly IInventory _in;

        public IInventory Inventory { get; set; }
        public int Count { get; private set; }

        public InventoryManager(int count)
        {
            _out = new OutOfStock(this);
            _in = new InStock(this);

            Count = count;
            Inventory = Count > 0 ? _in : _out;
        }

        public void reduce(int amount)
        {
            do
            {
                Inventory.pull();
                amount--;
            } while (amount!=0);                        
        }

        public void deduct()
        {
            if (Count > 0)
            {
                Count--;
            }
        }

        public IInventory Out()
        {
            return _out;
        }

        public IInventory In()
        {
            return _in;
        }
    }
    public interface IInventory
    {
        void pull();
    }

    public class InStock : IInventory
    {
        private readonly InventoryManager _item;

        public InStock(InventoryManager item)
        {
            _item = item;
        }

        public void pull()
        {
            _item.deduct();
            _item.Inventory = _item.Count > 0 ? _item.In() : _item.Out();
        }
    }

    public class OutOfStock : IInventory
    {
        public OutOfStock(InventoryManager item)
        {
            Item = item;
        }

        public InventoryManager Item { get; set; }

        public void pull()
        {
        }
    }

}