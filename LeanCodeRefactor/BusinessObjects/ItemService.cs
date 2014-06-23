namespace LeanCodeRefactor.BusinessObjects
{
    public interface IItemService
    {
        int PriceFor(string item);
    }

    public class ItemService : IItemService
    {
        public int PriceFor(string item)
        {
            switch (item)
            {
                case "Bananas":
                    return 150;
                case "Cherries":
                    return 75;
                case "Melon":
                    return 200;
                case "Apples":
                    return 100;
                case "Mele":
                case "Pommes":
                    return 100;
            }
            return 0;
        }
    }
}