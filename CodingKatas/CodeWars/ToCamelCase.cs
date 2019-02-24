namespace CodingKatas
{
    public static class ToCamelCaseKata
    {
        public static string ToCamelCase(string str)
        {
            var splitArray = str.Split(new[] { '-', '_' });

            for (int i = 1; i < splitArray.Length; i++)
                splitArray[i] = splitArray[i][0].ToString().ToUpper() + splitArray[i].Substring(1);
            
            return string.Join("", splitArray);
        }
    }
}
