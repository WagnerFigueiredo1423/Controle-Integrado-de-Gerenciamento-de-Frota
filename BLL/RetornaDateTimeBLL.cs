using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

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
