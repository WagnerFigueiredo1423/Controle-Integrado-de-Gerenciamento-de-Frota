using BrazilHolidays.Net;
using DAL;
using MDL;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FNC
{
    public static class sys_funcoesFNC
    {
        public static sys_mediaMDL calculaMedia(string tipo, string placa, DateTime data)
        {
            sys_mediaMDL mdlLocal = new sys_mediaMDL();
            DataTable dtb = new DataTable();
            DataTable dtb1 = new DataTable();
            DateTime data1 = data.AddMonths(-1);
            DataRow newRow = dtb.NewRow();
            float totLitros = 0;
            float totKms = 0;
            float somaLitros = 0;
            float somaMedias = 0;


            dtb = sys_abastecimentosDAL.ListarDAL(tipo, placa, data);
            dtb1 = sys_abastecimentosDAL.ListarDAL(tipo, placa, data1);

            if (dtb.Rows.Count != 0)
            {
                dtb.Columns.Add("media", typeof(float));

                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    if (i == 0 && dtb1.Rows.Count == 0)
                    {
                        dtb.Rows[i]["media"] = 0;
                    }
                    else if (i == 0 && placa != "8")
                    {
                        dtb.Rows[i]["media"] = ((float.Parse(dtb.Rows[i]["km"].ToString()) -
                                                         float.Parse(dtb1.Rows[dtb1.Rows.Count - 1]["km"].ToString())) /
                                                         float.Parse(dtb.Rows[i]["litros"].ToString())).ToString("0.##");
                    }
                    else if (i == 0 && placa == "8")
                    {

                        dtb.Rows[i]["media"] = (float.Parse(dtb.Rows[i]["litros"].ToString()) /
                                               (float.Parse(dtb.Rows[i]["km"].ToString()) - float.Parse(dtb1.Rows[dtb1.Rows.Count - 1]["km"].ToString()))).ToString("0.##");
                    }
                    else if (i != 0 && placa != "8")
                    {
                        dtb.Rows[i]["media"] = ((float.Parse(dtb.Rows[i]["km"].ToString()) -
                                                 float.Parse(dtb.Rows[i - 1]["km"].ToString())) /
                                                 float.Parse(dtb.Rows[i]["litros"].ToString())).ToString("0.##");
                    }
                    else if (i != 0 && placa == "8")
                    {
                        dtb.Rows[i]["media"] = (float.Parse(dtb.Rows[i]["litros"].ToString()) /
                                              (float.Parse(dtb.Rows[i]["km"].ToString()) - float.Parse(dtb.Rows[i - 1]["km"].ToString()))).ToString("0.##");
                    }
                    somaLitros += float.Parse(dtb.Rows[i]["litros"].ToString());
                }

                mdlLocal.RETORNO = dtb;
                mdlLocal.TOTLITRO = totLitros = float.Parse(dtb.Compute("Sum(litros)", "").ToString());
                somaMedias = float.Parse(dtb.Compute("Sum(media)", "").ToString());
                mdlLocal.TOTKM = totKms = float.Parse(dtb.Rows[dtb.Rows.Count - 1]["km"].ToString()) - float.Parse(dtb.Rows[0]["km"].ToString());
                if (totKms == 0.0 && somaLitros == 0.0)
                {
                    mdlLocal.MEDTOT = 0;
                }
                else
                {
                    mdlLocal.MEDTOT = somaMedias / dtb.Rows.Count;
                }

            }
            return mdlLocal;
        }
        public static sys_mediaMDL calculaMediaArla(string tipo, string placa, DateTime data)
        {
            sys_mediaMDL mdlLocal = new sys_mediaMDL();
            DataTable dtb = new DataTable();
            DataTable dtb1 = new DataTable();
            DateTime data1 = data.AddMonths(-1);
            DataRow newRow = dtb.NewRow();
            float totLitros = 0;
            float totKms = 0;
            float somaLitros = 0;
            float somaMedias = 0;


            dtb = sys_abastecimentoArlaDAL.ListarDAL(tipo, placa, data);
            dtb1 = sys_abastecimentoArlaDAL.ListarDAL(tipo, placa, data1);

            if (dtb.Rows.Count != 0)
            {
                dtb.Columns.Add("media", typeof(float));

                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    if (i == 0 && dtb1.Rows.Count == 0)
                    {
                        dtb.Rows[i]["media"] = 0;
                    }
                    else if (i == 0 && placa != "8")
                    {
                        dtb.Rows[i]["media"] = ((float.Parse(dtb.Rows[i]["km"].ToString()) -
                                                         float.Parse(dtb1.Rows[dtb1.Rows.Count - 1]["km"].ToString())) /
                                                         float.Parse(dtb.Rows[i]["litros"].ToString())).ToString("0.##");
                    }
                    else if (i == 0 && placa == "8")
                    {

                        dtb.Rows[i]["media"] = (float.Parse(dtb.Rows[i]["litros"].ToString()) /
                                               (float.Parse(dtb.Rows[i]["km"].ToString()) - float.Parse(dtb1.Rows[dtb1.Rows.Count - 1]["km"].ToString()))).ToString("0.##");
                    }
                    else if (i != 0 && placa != "8")
                    {
                        dtb.Rows[i]["media"] = ((float.Parse(dtb.Rows[i]["km"].ToString()) -
                                                 float.Parse(dtb.Rows[i - 1]["km"].ToString())) /
                                                 float.Parse(dtb.Rows[i]["litros"].ToString())).ToString("0.##");
                    }
                    else if (i != 0 && placa == "8")
                    {
                        dtb.Rows[i]["media"] = (float.Parse(dtb.Rows[i]["litros"].ToString()) /
                                              (float.Parse(dtb.Rows[i]["km"].ToString()) - float.Parse(dtb.Rows[i - 1]["km"].ToString()))).ToString("0.##");
                    }
                    somaLitros += float.Parse(dtb.Rows[i]["litros"].ToString());
                }

                mdlLocal.RETORNO = dtb;
                mdlLocal.TOTLITRO = totLitros = float.Parse(dtb.Compute("Sum(litros)", "").ToString());
                somaMedias = float.Parse(dtb.Compute("Sum(media)", "").ToString());
                mdlLocal.TOTKM = totKms = float.Parse(dtb.Rows[dtb.Rows.Count - 1]["km"].ToString()) - float.Parse(dtb.Rows[0]["km"].ToString());
                if (totKms == 0.0 && somaLitros == 0.0)
                {
                    mdlLocal.MEDTOT = 0;
                }
                else
                {
                    mdlLocal.MEDTOT = somaMedias / dtb.Rows.Count;
                }

            }
            return mdlLocal;
        }
        public static sys_efetivFNCMDL calculaTotaisEfetividadeCaminhoes(DateTime data, string indexPlaca)
        {
            sys_efetivFNCMDL mdlLocal = new sys_efetivFNCMDL();

            DataTable dtb = new DataTable();

            DateTime horaMadEnt = new DateTime();
            DateTime horaMadSai = new DateTime();
            DateTime horaManEnt = new DateTime();
            DateTime horaManSai = new DateTime();
            DateTime horaTarEnt = new DateTime();
            DateTime horaTarSai = new DateTime();
            DateTime horaNoiEnt = new DateTime();
            DateTime horaNoiSai = new DateTime();
            TimeSpan HrsMad = TimeSpan.Zero;
            TimeSpan HrsMan = TimeSpan.Zero;
            TimeSpan HrsTar = TimeSpan.Zero;
            TimeSpan HrsNoi = TimeSpan.Zero;
            TimeSpan totHrsNormDia = TimeSpan.Zero;
            TimeSpan HrsExtrMad = TimeSpan.Zero;
            TimeSpan HrsExtrMan = TimeSpan.Zero;
            TimeSpan HrsExtrTar = TimeSpan.Zero;
            TimeSpan HrsExtrNoi = TimeSpan.Zero;
            TimeSpan totHrsExtraDia = TimeSpan.Zero;
            TimeSpan totHrsDia = TimeSpan.Zero;
            TimeSpan totHrNormMes = TimeSpan.Zero;
            TimeSpan totHrExtrMes = TimeSpan.Zero;
            TimeSpan totHrsMes = TimeSpan.Zero;


            try
            {

                dtb = sys_efetividadeDAL.ListarDAL(data, indexPlaca);
                dtb.Columns.Add("total_hrs_normais", typeof(string));
                dtb.Columns.Add("total_hrs_extras", typeof(string));
                if (dtb.Rows.Count != 0)
                {
                    string teste = string.Empty;
                    for (int j = 0; j < dtb.Rows.Count; j++)
                    {
                        HrsExtrMad = new TimeSpan(0, 0, 0);
                        HrsMad = new TimeSpan(0, 0, 0);
                        HrsExtrMan = new TimeSpan(0, 0, 0);
                        HrsMan = new TimeSpan(0, 0, 0);
                        HrsExtrTar = new TimeSpan(0, 0, 0);
                        HrsTar = new TimeSpan(0, 0, 0);
                        HrsExtrNoi = new TimeSpan(0, 0, 0);
                        HrsNoi = new TimeSpan(0, 0, 0);

                        if (dtb.Rows[j]["hora_madrugada_entrada"].ToString() == "") horaMadEnt = Convert.ToDateTime("00:00");
                        else horaMadEnt = Convert.ToDateTime(dtb.Rows[j]["hora_madrugada_entrada"].ToString());

                        if (dtb.Rows[j]["hora_madrugada_saida"].ToString() == "") horaMadSai = Convert.ToDateTime("00:00");
                        else horaMadSai = Convert.ToDateTime(dtb.Rows[j]["hora_madrugada_saida"].ToString());

                        if (dtb.Rows[j]["hora_manha_entrada"].ToString() == "") horaManEnt = Convert.ToDateTime("00:00");
                        else horaManEnt = Convert.ToDateTime(dtb.Rows[j]["hora_manha_entrada"].ToString());

                        if (dtb.Rows[j]["hora_manha_saida"].ToString() == "") horaManSai = Convert.ToDateTime("00:00");
                        else horaManSai = Convert.ToDateTime(dtb.Rows[j]["hora_manha_saida"].ToString());

                        if (dtb.Rows[j]["hora_tarde_entrada"].ToString() == "") horaTarEnt = Convert.ToDateTime("00:00");
                        else horaTarEnt = Convert.ToDateTime(dtb.Rows[j]["hora_tarde_entrada"].ToString());

                        if (dtb.Rows[j]["hora_tarde_saida"].ToString() == "") horaTarSai = Convert.ToDateTime("00:00");
                        else horaTarSai = Convert.ToDateTime(dtb.Rows[j]["hora_tarde_saida"].ToString());

                        if (dtb.Rows[j]["hora_noite_entrada"].ToString() == "") horaNoiEnt = Convert.ToDateTime("00:00");
                        else horaNoiEnt = Convert.ToDateTime(dtb.Rows[j]["hora_noite_entrada"].ToString());

                        if (dtb.Rows[j]["hora_noite_saida"].ToString() == "") horaNoiSai = Convert.ToDateTime("00:00");
                        else horaNoiSai = Convert.ToDateTime(dtb.Rows[j]["hora_noite_saida"].ToString());

                        if (Convert.ToBoolean(dtb.Rows[j]["hora_extra_madrugada"].ToString()))
                        {
                            HrsExtrMad = new TimeSpan(horaMadSai.Hour - horaMadEnt.Hour, horaMadSai.Minute - horaMadEnt.Minute, 0);
                        }
                        else HrsMad = new TimeSpan(horaMadSai.Hour - horaMadEnt.Hour, horaMadSai.Minute - horaMadEnt.Minute, 0);

                        if (Convert.ToBoolean(dtb.Rows[j]["hora_extra_manha"].ToString()))
                        {
                            HrsExtrMan = new TimeSpan(horaManSai.Hour - horaManEnt.Hour, horaManSai.Minute - horaManEnt.Minute, 0);
                        }
                        else HrsMan = new TimeSpan(horaManSai.Hour - horaManEnt.Hour, horaManSai.Minute - horaManEnt.Minute, 0);

                        if (Convert.ToBoolean(dtb.Rows[j]["hora_extra_tarde"].ToString()))
                        {
                            HrsExtrTar = new TimeSpan(horaTarSai.Hour - horaTarEnt.Hour, horaTarSai.Minute - horaTarEnt.Minute, 0);
                        }
                        else HrsTar = new TimeSpan(horaTarSai.Hour - horaTarEnt.Hour, horaTarSai.Minute - horaTarEnt.Minute, 0);

                        if (Convert.ToBoolean(dtb.Rows[j]["hora_extra_noite"].ToString()))
                        {
                            HrsExtrNoi = new TimeSpan(horaNoiSai.Hour - horaNoiEnt.Hour, horaNoiSai.Minute - horaNoiEnt.Minute, 0);
                        }
                        else HrsNoi = new TimeSpan(horaNoiSai.Hour - horaNoiEnt.Hour, horaNoiSai.Minute - horaNoiEnt.Minute, 0);

                        totHrsNormDia = new TimeSpan(HrsMad.Hours + HrsMan.Hours + HrsTar.Hours + HrsNoi.Hours, HrsMad.Minutes + HrsMan.Minutes + HrsTar.Minutes + HrsNoi.Minutes, 0);

                        totHrsExtraDia = new TimeSpan(HrsExtrMad.Hours + HrsExtrMan.Hours + HrsExtrTar.Hours + HrsExtrNoi.Hours, HrsExtrMad.Minutes + HrsExtrMan.Minutes + HrsExtrTar.Minutes + HrsExtrNoi.Minutes, 0);

                        totHrNormMes += totHrsNormDia;
                        totHrExtrMes += totHrsExtraDia;
                        totHrsMes += (totHrsNormDia + totHrsExtraDia);

                        dtb.Rows[j]["total_hrs_normais"] = formataSomaHora(totHrsNormDia);
                        dtb.Rows[j]["total_hrs_extras"] = formataSomaHora(totHrsExtraDia);

                    }
                    mdlLocal.DATA = dtb;
                    mdlLocal.TOTHRNORM = formataSomaHora(totHrNormMes);
                    mdlLocal.TOTHREXTRA = formataSomaHora(totHrExtrMes);
                    mdlLocal.TOTHR = formataSomaHora(totHrsMes);
                }
            }
            catch (Exception erro)
            {
                throw erro;
            }

            return mdlLocal;
        }
        public static sys_horaExtraMDL horasExtras(DateTime data, string indexMotorista)
        {
            sys_horaExtraMDL mdlLocal = new sys_horaExtraMDL();
            int j = 0, k = 0, l = 0, m = 0;
            string placa = string.Empty;
            DataTable dtb = new DataTable();
            bool feriado = false;

            DataTable dias = new DataTable();
            DataColumn DataDia = dias.Columns.Add("Data", typeof(string));
            DataColumn PlacaDia = dias.Columns.Add("Placa", typeof(string));
            DataColumn HorasMadDia = dias.Columns.Add("Horas Madrugada", typeof(string));
            DataColumn HorasManDia = dias.Columns.Add("Horas Manha", typeof(string));
            DataColumn HorasTarDia = dias.Columns.Add("Horas Tarde", typeof(string));
            DataColumn HorasNoiDia = dias.Columns.Add("Horas Noite", typeof(string));
            DataColumn HorasTotDia = dias.Columns.Add("Total", typeof(string));

            DataTable domingos = new DataTable();
            DataColumn DataDom = domingos.Columns.Add("Data", typeof(string));
            DataColumn PlacaDom = domingos.Columns.Add("Placa", typeof(string));
            DataColumn HorasMadDom = domingos.Columns.Add("Horas Madrugada", typeof(string));
            DataColumn HorasManDom = domingos.Columns.Add("Horas Manha", typeof(string));
            DataColumn HorasTarDom = domingos.Columns.Add("Horas Tarde", typeof(string));
            DataColumn HorasNoiDom = domingos.Columns.Add("Horas Noite", typeof(string));
            DataColumn HorastOTDom = domingos.Columns.Add("Total", typeof(string));

            DataTable feriados = new DataTable();
            DataColumn DataFer = feriados.Columns.Add("Data", typeof(string));
            DataColumn PlacaFer = feriados.Columns.Add("Placa", typeof(string));
            DataColumn HorasMadFer = feriados.Columns.Add("Horas Madrugada", typeof(string));
            DataColumn HorasManFer = feriados.Columns.Add("Horas Manha", typeof(string));
            DataColumn HorasTarFer = feriados.Columns.Add("Horas Tarde", typeof(string));
            DataColumn HorasNoiFer = feriados.Columns.Add("Horas Noite", typeof(string));
            DataColumn HorasTotFer = feriados.Columns.Add("Total", typeof(string));

            DataTable madrugadas = new DataTable();
            DataColumn DataMad = madrugadas.Columns.Add("Data", typeof(string));
            DataColumn PlacaMad = madrugadas.Columns.Add("Placa", typeof(string));
            DataColumn HorasMadMad = madrugadas.Columns.Add("Horas Madrugada", typeof(string));

            DateTime dia = new DateTime();

            DateTime horaMadEnt = new DateTime();
            DateTime horaMadSai = new DateTime();
            DateTime horaManEnt = new DateTime();
            DateTime horaManSai = new DateTime();
            DateTime horaTarEnt = new DateTime();
            DateTime horaTarSai = new DateTime();
            DateTime horaNoiEnt = new DateTime();
            DateTime horaNoiSai = new DateTime();

            TimeSpan horasMadrugada = TimeSpan.Zero;
            TimeSpan horasManha = TimeSpan.Zero;
            TimeSpan horasTarde = TimeSpan.Zero;
            TimeSpan horasNoite = TimeSpan.Zero;

            TimeSpan somaHorasDias = TimeSpan.Zero;
            TimeSpan somaHorasDomingo = TimeSpan.Zero;
            TimeSpan somaHorasFeriado = TimeSpan.Zero;
            TimeSpan somaHorasMadrugada = TimeSpan.Zero;

            TimeSpan totHrsDia = TimeSpan.Zero;
            TimeSpan totHrsMes = TimeSpan.Zero;

            Holiday.GetAllByYear(Convert.ToInt16(data.Year));

            dtb = sys_efetividadeDAL.ListarPorMotoristaDAL(data, indexMotorista);
            dtb.Columns.Add("Total", typeof(string));
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                feriado = false;
                //ler a data de cada linha da dtb
                dia = Convert.ToDateTime(dtb.Rows[i]["data"].ToString());
                placa = dtb.Rows[i]["placa"].ToString();
                //ler o total de horas da madrugada de cada linha
                if (dtb.Rows[i]["hora_madrugada_entrada"].ToString() == "") horaMadEnt = Convert.ToDateTime("00:00");
                else horaMadEnt = Convert.ToDateTime(dtb.Rows[i]["hora_madrugada_entrada"].ToString());

                if (dtb.Rows[i]["hora_madrugada_saida"].ToString() == "") horaMadSai = Convert.ToDateTime("00:00");
                else horaMadSai = Convert.ToDateTime(dtb.Rows[i]["hora_madrugada_saida"].ToString());

                if (dtb.Rows[i]["hora_manha_entrada"].ToString() == "") horaManEnt = Convert.ToDateTime("00:00");
                else horaManEnt = Convert.ToDateTime(dtb.Rows[i]["hora_manha_entrada"].ToString());

                if (dtb.Rows[i]["hora_manha_saida"].ToString() == "") horaManSai = Convert.ToDateTime("00:00");
                else horaManSai = Convert.ToDateTime(dtb.Rows[i]["hora_manha_saida"].ToString());

                if (dtb.Rows[i]["hora_tarde_entrada"].ToString() == "") horaTarEnt = Convert.ToDateTime("00:00");
                else horaTarEnt = Convert.ToDateTime(dtb.Rows[i]["hora_tarde_entrada"].ToString());

                if (dtb.Rows[i]["hora_tarde_saida"].ToString() == "") horaTarSai = Convert.ToDateTime("00:00");
                else horaTarSai = Convert.ToDateTime(dtb.Rows[i]["hora_tarde_saida"].ToString());

                if (dtb.Rows[i]["hora_noite_entrada"].ToString() == "") horaNoiEnt = Convert.ToDateTime("00:00");
                else horaNoiEnt = Convert.ToDateTime(dtb.Rows[i]["hora_noite_entrada"].ToString());

                if (dtb.Rows[i]["hora_noite_saida"].ToString() == "") horaNoiSai = Convert.ToDateTime("00:00");
                else horaNoiSai = Convert.ToDateTime(dtb.Rows[i]["hora_noite_saida"].ToString());

                totHrsDia = new TimeSpan((horaMadSai.Hour - horaMadEnt.Hour) + (horaManSai.Hour - horaManEnt.Hour) + (horaTarSai.Hour - horaTarEnt.Hour) + (horaNoiSai.Hour - horaNoiEnt.Hour), (horaMadSai.Minute - horaMadEnt.Minute) + (horaManSai.Minute - horaManEnt.Minute) + (horaTarSai.Minute - horaTarEnt.Minute) + (horaNoiSai.Minute - horaNoiEnt.Minute), 0);
                dtb.Rows[i]["Total"] = formataSomaHora(totHrsDia);

                totHrsMes += totHrsDia;

                horasMadrugada = new TimeSpan(horaMadSai.Hour - horaMadEnt.Hour, horaMadSai.Minute - horaMadEnt.Minute, 0);
                horasManha = new TimeSpan(horaManSai.Hour - horaManEnt.Hour, horaManSai.Minute - horaManEnt.Minute, 0);
                horasTarde = new TimeSpan(horaTarSai.Hour - horaTarEnt.Hour, horaTarSai.Minute - horaTarEnt.Minute, 0);
                horasNoite = new TimeSpan(horaNoiSai.Hour - horaNoiEnt.Hour, horaNoiSai.Minute - horaNoiEnt.Minute, 0);

                if (dia.IsHoliday())
                {
                    DataRow row = feriados.NewRow();
                    feriado = true;
                    row["Data"] = dia.ToShortDateString();
                    row["placa"] = placa;
                    row["Horas Madrugada"] = formataSomaHora(horasMadrugada);
                    row["Horas Manha"] = formataSomaHora(horasManha);
                    row["Horas Tarde"] = formataSomaHora(horasTarde);
                    row["Horas Noite"] = formataSomaHora(horasNoite);
                    row["Total"] = formataSomaHora(totHrsDia);
                    if (formataSomaHora(horasMadrugada) != "0:00" || formataSomaHora(horasManha) != "0:00" || formataSomaHora(horasTarde) != "0:00" || formataSomaHora(horasNoite) != "0:00")
                    {
                        feriados.Rows.InsertAt(row, k);
                        somaHorasFeriado += totHrsDia;
                        k++;
                    }
                }
                if (dia.DayOfWeek == DayOfWeek.Sunday)
                {
                    DataRow row = domingos.NewRow();

                    row["Data"] = dia.ToShortDateString();
                    row["placa"] = placa;
                    row["Horas Madrugada"] = formataSomaHora(horasMadrugada);
                    row["Horas Manha"] = formataSomaHora(horasManha);
                    row["Horas Tarde"] = formataSomaHora(horasTarde);
                    row["Horas Noite"] = formataSomaHora(horasNoite);
                    row["Total"] = formataSomaHora(totHrsDia);
                    if (formataSomaHora(horasMadrugada) != "0:00" || formataSomaHora(horasManha) != "0:00" || formataSomaHora(horasTarde) != "0:00" || formataSomaHora(horasNoite) != "0:00")
                    {
                        domingos.Rows.InsertAt(row, j);
                        somaHorasDomingo += totHrsDia;
                        j++;
                    }
                }
                else if (formataSomaHora(horasMadrugada) != "0:00")
                {
                    DataRow row = madrugadas.NewRow();

                    row["Data"] = dia;
                    row["placa"] = placa;
                    row["Horas Madrugada"] = formataSomaHora(horasMadrugada);
                    madrugadas.Rows.InsertAt(row, l);
                    somaHorasMadrugada += horasMadrugada;
                    l++;
                }
                else if (formataSomaHora(horasMadrugada) == "0:00" && dia.DayOfWeek != DayOfWeek.Sunday && feriado == false)
                {
                    DataRow row = dias.NewRow();

                    row["Data"] = dia;
                    row["placa"] = placa;
                    row["Horas Madrugada"] = formataSomaHora(horasMadrugada);
                    row["Horas Manha"] = formataSomaHora(horasManha);
                    row["Horas Tarde"] = formataSomaHora(horasTarde);
                    row["Horas Noite"] = formataSomaHora(horasNoite);
                    row["Horas Noite"] = formataSomaHora(horasNoite);
                    row["Total"] = formataSomaHora(totHrsDia);
                    somaHorasDias += totHrsDia;
                    dias.Rows.InsertAt(row, m);
                    m++;
                }
            }
            mdlLocal.TOTAL = dtb;
            mdlLocal.HORASTOTAIS = formataSomaHora(totHrsMes);

            mdlLocal.DIAS = dias;
            mdlLocal.HORASNORMAIS = formataSomaHora(somaHorasDias);

            mdlLocal.DOMINGOS = domingos;
            mdlLocal.HORASDOMINGO = formataSomaHora(somaHorasDomingo);

            mdlLocal.FERIADOS = feriados;
            mdlLocal.HORASFERIADO = formataSomaHora(somaHorasFeriado);

            mdlLocal.MADRUGADAS = madrugadas;
            mdlLocal.HORASMADRUGADA = formataSomaHora(somaHorasMadrugada);
            return mdlLocal;
        }
        private static string formataSomaHora(TimeSpan time)
        {
            string retorno = string.Empty;

            retorno = string.Format("{0}:{1}", time.Days > 0 ? ((time.Days * 24) + time.Hours) : time.Hours,
                                        time.Minutes < 10 ? ("0" + time.Minutes) : time.Minutes.ToString());
            return retorno;
        }
        public static DataTable dtbCopy(DataTable dtb)
        {
            DataTable retorno = dtb.Clone();
            try
            {
                dtb.AsEnumerable().ToList().ForEach(row => retorno.ImportRow(row));
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return retorno;
        }
        public static DataTable dtbSelectString(DataTable dtb, string parametros)
        {
            DataTable retorno = dtb.Clone();
            DataRow[] result = dtb.Select(parametros);
            foreach (DataRow row in result)
            {
                retorno.ImportRow(row);
            }
            return retorno;
        }
        public static DataGridViewRow DataGridViewCloneRow(DataGridViewRow row)
        {
            DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
            for (Int32 index = 0; index < row.Cells.Count; index++)
            {
                clonedRow.Cells[index].Value = row.Cells[index].Value;
            }
            return clonedRow;
        }
        public static DataTable GetDataTableFromGridview(DataGridView dtg)
        {
            DataTable dt = new DataTable();

            // add the columns to the datatable            
            if (dtg.Columns != null)
            {

                for (int i = 0; i < dtg.Columns.Count; i++)
                {
                    dt.Columns.Add(dtg.Columns[i].Name.ToString());
                }
            }

            //  add each of the data rows to the table
            foreach (DataGridViewRow row in dtg.Rows)
            {
                DataRow dr;
                dr = dt.NewRow();

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dr[i] = row.Cells[i].Value.ToString();
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        public static DataTable SetColumnsOrder(this DataTable table, params String[] columnNames)
        {
            int columnIndex = 0;
            foreach (var columnName in columnNames)
            {
                table.Columns[columnName].SetOrdinal(columnIndex);
                columnIndex++;
            }
            return table;
        }
        public static DataTable adicionaLinhaSelecionada(DataTable dtb1, DataGridView dtg1, params string[] colunas)
        {
            if (dtb1 == null)
            {
                for (int i = 0; i < colunas.Length; i++)
                {
                    dtb1.Columns.Add(colunas[i]);
                }
            }
            DataRow dtbRow = dtb1.NewRow();
            for (int i = 0; i < dtb1.Columns.Count; i++)
            {
                if (dtb1.Columns[i].Namespace == dtg1.Columns[i].HeaderText)
                {
                    dtbRow[i] = dtg1.CurrentRow.Cells[i].Value;
                }
            }
            dtg1.Rows.Add(dtbRow);
            return dtb1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoRegistro">geraLog = cria um log com data e usuario
        ///                            escreveLog = só escreve evento no final da linha</param>
        /// <param name="form"></param>
        /// <param name="usuario"></param>
        /// <param name="evento"></param>
        public static void geraLog(string Path, string tipoRegistro, string form, string usuario, string evento)
        {
            string nome_arquivo = Path + "log.txt";
            FileInfo aFile = new FileInfo(nome_arquivo);
            StreamWriter valor = null;
            if (aFile.Exists)
            {
                valor = File.AppendText(nome_arquivo);
            }
            else
            {
                valor = new StreamWriter(nome_arquivo, false, Encoding.ASCII);
            }
            if (tipoRegistro == "geraLog") valor.Write("[" + DateTime.Now.ToString() + "] - USUARIO: " + usuario + " " + evento);
            else if (tipoRegistro == "escreveLog") valor.Write(evento);
            valor.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdlCliente"></param>
        /// <returns>true para existir, falso para não existir</returns>
        public static bool exiteClienteNoBanco(sys_clientesMDL mdlCliente)
        {
            bool retorno = false;
            if (mdlCliente.REGISTRO == "000.000.000-00" || mdlCliente.REGISTRO == "00.000.000/0000-00")
            {
                bool existeNome = sys_FNCDAL.jaExisteNoBancoDAL("sys_clientes", "nome", mdlCliente.NOME);
                bool existeFone = false;
                if (mdlCliente.FONE1 == "(  )    -")
                {
                    bool existeFone1 = sys_FNCDAL.jaExisteNoBancoDAL("sys_clientes", "fone1", mdlCliente.FONE2);
                    bool existeFone2 = sys_FNCDAL.jaExisteNoBancoDAL("sys_clientes", "fone2", mdlCliente.FONE2);
                    if (existeFone1 == true || existeFone2 == true) existeFone = true;
                }
                else if (mdlCliente.FONE2 == "(  )    -")
                {
                    bool existeFone1 = sys_FNCDAL.jaExisteNoBancoDAL("sys_clientes", "fone1", mdlCliente.FONE1);
                    bool existeFone2 = sys_FNCDAL.jaExisteNoBancoDAL("sys_clientes", "fone2", mdlCliente.FONE1);
                    if (existeFone1 == true || existeFone2 == true) existeFone = true;
                }
                else
                {
                    bool existeFone1 = sys_FNCDAL.jaExisteNoBancoDAL("sys_clientes", "fone1", mdlCliente.FONE1);
                    bool existeFone2 = sys_FNCDAL.jaExisteNoBancoDAL("sys_clientes", "fone2", mdlCliente.FONE1);
                    bool existeFone3 = sys_FNCDAL.jaExisteNoBancoDAL("sys_clientes", "fone1", mdlCliente.FONE2);
                    bool existeFone4 = sys_FNCDAL.jaExisteNoBancoDAL("sys_clientes", "fone2", mdlCliente.FONE2);
                    if (existeFone1 == true || existeFone2 == true || existeFone3 == true || existeFone4 == true) existeFone = true;
                }
                if (existeNome == true && existeFone == true) retorno = true;
            }
            else retorno = sys_FNCDAL.jaExisteNoBancoDAL("sys_clientes", "registro", mdlCliente.REGISTRO);
            return retorno;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longintude"></param>
        /// <returns>true para existir, falso para não existir</returns>
        public static bool exiteEnderecoNoBanco(string endereco)
        {
            bool retorno = false;
            if (sys_FNCDAL.jaExisteNoBancoDAL("sys_enderecos", "endereco", endereco) == true)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent">datagridview</param>
        /// <param name="indexColuna">a index da coluna a ser organizada</param>
        /// <returns></returns>
        public static DataTable sortDataGridView(Control parent, int indexColuna)
        {
            DataTable retorno = null;
            if (object.ReferenceEquals(parent.GetType(), typeof(DataGridView)))
            {
                DataGridViewColumn newColumn = ((DataGridView)parent).Columns[indexColuna];
                DataGridViewColumn oldColumn = ((DataGridView)parent).SortedColumn;
                DataView dv = ((DataTable)(((DataGridView)parent).DataSource)).DefaultView;

                // If oldColumn is null, then the DataGridView is not sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (((DataGridView)parent).SortOrder == System.Windows.Forms.SortOrder.Ascending)
                    {
                        dv.Sort = oldColumn.Name + " asc";
                    }
                    else
                    {
                        // Sort a new column and remove the old SortGlyph.
                        dv.Sort = oldColumn.Name + " desc";
                        oldColumn.HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.None;
                    }
                }
                else
                {
                    dv.Sort = newColumn.Name + " asc";
                }

                // Sort the selected column.
                newColumn.HeaderCell.SortGlyphDirection =
                    ((DataGridView)parent).SortOrder == System.Windows.Forms.SortOrder.Ascending ?
                    System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending;
                return (dv.ToTable());
            }
            else
            {
                return retorno;
            }
        }
    }
}
