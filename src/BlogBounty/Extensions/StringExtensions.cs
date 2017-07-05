namespace BlogBounty.Extensions
{
    public static class StringExtensions
    {
        public static string Normalised(this string str)
        {
            return str.ToLowerInvariant().Trim();
        }

        public static bool Matches(this string str, string match)
        {
            return str.Normalised().Contains(match.Normalised());
        }
    }
}