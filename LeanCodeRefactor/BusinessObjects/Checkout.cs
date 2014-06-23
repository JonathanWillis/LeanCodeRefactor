namespace LeanCodeRefactor.BusinessObjects
{
    public class Checkout
    {
        private int value;

        private readonly IInputParser _ip;
        private readonly IItemService _is;
        private readonly IDiscountService _ds;

        public Checkout() : this(new InputParser(), new ItemService(), new DiscountService()) { }

        public Checkout(IInputParser ip, IItemService iss, IDiscountService ds)
        {
            _ip = ip;
            _is = iss;
            _ds = ds;
        }

        public string Scan(string input)
        {
            var items = _ip.Parse(input);
            foreach (var item in items)
            {
                value += _is.PriceFor(item);
                value -= _ds.PriceAdjustment(item);
            }

            return value.ToString();
        }
    }
}