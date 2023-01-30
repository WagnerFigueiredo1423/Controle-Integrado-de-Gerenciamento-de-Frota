using DAL;
using System;

namespace BLL
{
    public static class RetornaDateTimeBLL
    {
        public static DateTime _retornaDateTimeBLL(string data)
        {
            DateTime _data = new DateTime();
            try
            {
                RetornaDateTimeDAL._retornaDateTimeDAL(data);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return _data;
        }
    }
}
