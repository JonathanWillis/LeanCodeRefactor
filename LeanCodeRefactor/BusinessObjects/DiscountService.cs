namespace LeanCodeRefactor.BusinessObjects
{
    public interface IDiscountService
    {
        int PriceAdjustment(string item);
    }

    public class DiscountService : IDiscountService
    {
        private int _bananaCount;
        private int _cherriesCount;
        private int _appleCount;
        private int _meleCount;
        private int _pommesCount;
        private int _fruitCount;

        public int PriceAdjustment(string item)
        {
            switch (item)
            {
                case "Bananas":
                    _bananaCount++;
                    _fruitCount++;
                    break;
                case "Cherries":
                    _cherriesCount++;
                    _fruitCount++;
                    break;
                case "Apples":
                    _appleCount++;
                    _fruitCount++;
                    break;
                case "Mele":
                    _meleCount++;
                    _appleCount++;
                    _fruitCount++;
                    break;
                case "Pommes":
                    _pommesCount++;
                    _fruitCount++;
                    _appleCount++;
                    break;
            }

            var discount = 0;
            if (_bananaCount == 2)
            {
                _bananaCount = 0;
                discount += 150;
            }
            if (_cherriesCount == 2)
            {
                _cherriesCount = 0;
                discount += 20;
            }
            if (_meleCount == 2)
            {
                _meleCount = 0;
                discount += 50;
            }
            if (_pommesCount == 3)
            {
                _pommesCount = 0;
                discount += 100;
            }
            if (_appleCount == 4)
            {
                _appleCount = 0;
                discount += 100;
            }
            if (_fruitCount == 5)
            {
                _fruitCount = 0;
                discount += 200;
            }

            return discount;
        }
    }
}