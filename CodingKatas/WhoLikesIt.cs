using System.Text;

namespace CodingKatas
{
    public static class WhoLikesIt
    {
        public static string Likes(string[] names)
        {
            int numberOfNamesToList = names.Length == 3 ? 3 : 2;

            if (names.Length == 0)
                return "no one likes this";
            else if (names.Length == 1)
                return $"{names[0]} likes this";
            else
            {
                var builder = new StringBuilder();
                builder.Append($"{names[0]}");
                for (int i = 1; i < names.Length && i <= numberOfNamesToList; i++)
                {
                    if (i == 1 && names.Length > 2)
                        builder.Append($", {names[i]}");
                    else if (i != numberOfNamesToList)
                         builder.Append($" and {names[i]}");
                    else
                        builder.Append($" and {names.Length - i} others");
                }

                builder.Append($" like this");
                return builder.ToString();
            }
        }
    }

    public static class WhoLikesItSolution
    {
        public static string Likes(string[] names)
        {
            switch (names.Length)
            {
                case 0: return "no one likes this";
                case 1: return $"{names[0]} likes this";
                case 2: return $"{names[0]} and {names[1]} like this";
                case 3: return $"{names[0]}, {names[1]} and {names[2]} like this";
                default: return $"{names[0]}, {names[1]} and {names.Length - 2} others like this";
            }
        }
    }
}
