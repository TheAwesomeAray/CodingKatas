namespace CodingKatas
{
    public abstract class Rot13
    {
        private static int min;
        private static int max;
        private static int ROTNumber = 13;

        public static string Decipher(string input)
        {
            var arr = input.ToCharArray();

            for (int i = 0; i < arr.Length; i++)
            {
                if (char.IsUpper(arr[i]))
                {
                    min = UpperRot13.MIN;
                    max = UpperRot13.MAX;
                }
                else
                {
                    min = LowerRot13.MIN;
                    max = LowerRot13.MAX;
                }

                if (char.IsLetter(arr[i]))
                {
                    arr[i] = DecipherCharacter(arr[i]);
                }
            }

            return new string(arr);
        }

        public static char DecipherCharacter(char c)
        {
            int newChar = c + ROTNumber > max ? 
                min + c + ROTNumber - max - 1 : 
                c + ROTNumber;

            return (char)newChar;
        }
    }

    public static class UpperRot13
    {
        public static int MIN = 'A';
        public static int MAX = 'Z';
    }

    public static class LowerRot13
    {
        public static int MIN = 'a';
        public static int MAX = 'z';
    }

}
