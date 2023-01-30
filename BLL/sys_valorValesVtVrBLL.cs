using DAL;
using MDL;
using System;

namespace BLL
{
    public class sys_valorValesVtVrBLL
    {
        public static void AtualizarBLL(sys_valorValesVtVrMDL mdlLocal)
        {
            try
            {
                sys_valorValesVtVrDAL.AtualizarDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static sys_valorValesVtVrMDL MostrarBLL()
        {
            sys_valorValesVtVrMDL mdlLocalBLL = new sys_valorValesVtVrMDL();
            try
            {
                mdlLocalBLL = sys_valorValesVtVrDAL.MostrarDAL();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return mdlLocalBLL;
        }
    }
}
