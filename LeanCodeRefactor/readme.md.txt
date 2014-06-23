The lean code refactor.

Requirements
Items
 - Banana - £1.5
 - Apple - £1
 - Mele - £1
 - Pommes - £1
 - Cherries £0.75

Input
 - One item per line 
 - Many items comma seprated (CSV)

Offers
 - 2x Cherry, £0.20p off
 - Banana B1G1F (£1.50 off)
 - 3x pommes, £1 off
 - 2x mele, £0.50 off
 - Any 4x apples, £1 off
 - Any 5 fruit, £2 off

The original (simplest) solution to the challenge.

 public class Checkout
    {
        private int _total;
        private int _bananaCount;
        private int _cherriesCount;
        private int _appleCount;
        private int _meleCount;
        private int _pommesCount;
        private int _fruitCount;

        public string Scan(string input)
        {
            var items = input.Split(',');
            foreach (var item in items)
            {
                switch (item)
                {
                    case "Bananas":
                        _total += 150;
                        break;
                    case "Cherries":
                        _total += 75;
                        break;
                    case "Apples":
                        _total += 100;
                        break;
                    case "Mele":
                        _total += 100;
                        break;
                    case "Pommes":
                        _total += 100;
                        break;
                }

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

                if (_bananaCount == 2)
                {
                    _bananaCount = 0;
                    _total -= 150;
                }
                if (_cherriesCount == 2)
                {
                    _cherriesCount = 0;
                    _total -= 20;
                }
                if (_meleCount == 2)
                {
                    _meleCount = 0;
                    _total -= 50;
                }
                if (_pommesCount == 3)
                {
                    _pommesCount = 0;
                    _total -= 100;
                }
                if (_appleCount == 4)
                {
                    _appleCount = 0;
                    _total -= 100;
                }
                if (_fruitCount == 5)
                {
                    _fruitCount = 0;
                    _total -= 200;
                }
            }

            return _total.ToString();
        }
    }

