using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_abastecimentoArlaBLL
    {
        public static void InserirBLL(sys_abastecimentosMDL mdlLocal)
        {
            sys_abastecimentosMDL mdlLocalBLL = new sys_abastecimentosMDL();
            try
            {
                sys_abastecimentoArlaDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void AtualizarBLL(sys_abastecimentosMDL mdlLocal)
        {
            try
            {
                sys_abastecimentoArlaDAL.AtualizarDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void DeletarBLL(int id)
        {
            try
            {
                sys_abastecimentoArlaDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static sys_abastecimentosMDL MostrarBLL(int id)
        {
            sys_abastecimentosMDL mdlLocalBLL = new sys_abastecimentosMDL();
            try
            {
                mdlLocalBLL = sys_abastecimentoArlaDAL.MostrarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return mdlLocalBLL;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipo"> tudo - lista tudo
        ///                     placa - todos os registros da placa
        ///                     plData- todos os registros do mês de det. placa</param>
        /// <param name="indexPlaca">id do veiculo (placa)</param>
        /// <param name="data">data para listagem</param>
        /// <returns></returns>
        public static DataTable ListarBLL(string tipo, string indexPlaca, DateTime data)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_abastecimentoArlaDAL.ListarDAL(tipo, indexPlaca, data);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipo"> comparativo - lista todos os caminhões, todos os meses de um ano
        ///                     evolutivo - lista todos os meses de um ano do mesmo cainhão
        ///                     ambos- todos os registros do mês de det. placa</param>
        /// <param name="indexPlaca">id do veiculo (placa)</param>
        /// <param name="data">data para listagem</param>
        /// <returns></returns>
        public static DataTable ListarRelatorioBLL(string tipo, string indexPlaca, DateTime data)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_abastecimentoArlaDAL.ListarRelatorioDAL(tipo, indexPlaca, data);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
