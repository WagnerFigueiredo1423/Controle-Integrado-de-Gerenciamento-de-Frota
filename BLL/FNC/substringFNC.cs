namespace FNC
{
    public static class substringFNC
    {
        public static string substring(string fullString, string subsTring)
        {
            string retorno = null;
            int lenght_fullString = fullString.Length;
            int lenght_substring = subsTring.Length;

            retorno = fullString.Substring(0,lenght_fullString - lenght_substring);

            return retorno;
        }
    }
}
