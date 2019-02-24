namespace CodingKatas
{
    public static class RemoveUrlAnchorKata
    {
        public static string RemoveUrlAnchor(string url)
        {
            return url.Substring(0, url.IndexOf('#') > 0 ? url.IndexOf('#') : url.Length);
        }
    }
}
