using System.Linq;

namespace LeanCodeRefactor.BusinessObjects
{
    public interface IInputParser
    {
        string[] Parse(string input);
    }

    public class InputParser : IInputParser
    {
        public string[] Parse(string input)
        {
            var noOfItems = input.Count(character => character == ',' || character == ';') + 1;
            int currentItem = 0;
            var items = new string[noOfItems];
            foreach (var character in input)
            {
                if (character == ',' || character == ';')
                {
                    currentItem++;
                    continue;
                }
                items[currentItem] += character;
            }
            return items;
        }
    }
}