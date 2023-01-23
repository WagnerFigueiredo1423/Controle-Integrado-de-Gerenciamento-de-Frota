using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    public static class RetornaDateTimeDAL
    {
        public static DateTime _retornaDateTimeDAL(string data)
        {
            DateTime date = new DateTime();
            try
            {
                string CurrentPattern = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                string[] Split = new string[] { "-", "/", @"\", "." };
                string[] Patternvalue = CurrentPattern.Split(Split, StringSplitOptions.None);
                string[] DateSplit = data.Split(Split, StringSplitOptions.None);
                string NewDate = "";
                if (Patternvalue[0].ToLower().Contains("d") == true && Patternvalue[1].ToLower().Contains("m") == true && Patternvalue[2].ToLower().Contains("y") == true)
                {
                    NewDate = DateSplit[1] + "/" + DateSplit[0] + "/" + DateSplit[2];
                }
                else if (Patternvalue[0].ToLower().Contains("m") == true && Patternvalue[1].ToLower().Contains("d") == true && Patternvalue[2].ToLower().Contains("y") == true)
                {
                    NewDate = DateSplit[0] + "/" + DateSplit[1] + "/" + DateSplit[2];
                }
                else if (Patternvalue[0].ToLower().Contains("y") == true && Patternvalue[1].ToLower().Contains("m") == true && Patternvalue[2].ToLower().Contains("d") == true)
                {
                    NewDate = DateSplit[2] + "/" + DateSplit[0] + "/" + DateSplit[1];
                }
                else if (Patternvalue[0].ToLower().Contains("y") == true && Patternvalue[1].ToLower().Contains("d") == true && Patternvalue[2].ToLower().Contains("m") == true)
                {
                    NewDate = DateSplit[2] + "/" + DateSplit[1] + "/" + DateSplit[0];
                }
                date = DateTime.Parse(NewDate, Thread.CurrentThread.CurrentCulture);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return date;
        }
    }
}
