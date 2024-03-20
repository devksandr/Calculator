namespace Calculator.Backend.Data.Extensions
{
    public static class StringCompareExtension
    {
        public static bool IsEqualsIgnoreCase(this string str1, string str2) 
            => str1.ToLower() == str2.ToLower();
    }
}
