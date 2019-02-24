using System.Linq;

namespace CodingKatas
{
    public static class ExesAndOhs
    {
        public static bool XO(string input)
        {
            var upperInput = input.ToUpper();
            return upperInput.Split('O').Count() == upperInput.Split('X').Count();
        }
    }

    public static class ExesAndOhsSolution
    {
        public static bool XO(string input)
        {
            return input.ToLower().Count(x => x == 'x') == input.ToLower().Count(x => x == 'o');
        }
    }
}
