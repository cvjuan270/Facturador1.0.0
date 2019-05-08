using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormBase1
{
    public class ValidaEntradaDato
    {
        public static DateTime Fecha;
        public static string ofecha;

        public static DateTime AutoCompletaFecha(string CadeFech)
        {
            try
            {
                Fecha = DateTime.Now;

                string dia, mes, año;
                int l;

                if (CadeFech == "*")
                {

                    ofecha = DateTime.Now.ToString("dd/MM/yyyy");
                    Fecha = Convert.ToDateTime(ofecha);
                }

                else
                {
                    dia = DateTime.Now.Day.ToString();
                    mes = DateTime.Now.Month.ToString("00");
                    año = DateTime.Now.Year.ToString();
                    string odia, omes, oaño;
                    l = CadeFech.Length;
                    switch (l)
                    {
                        case 1:
                            ofecha = "0" + CadeFech + "/" + mes + "/" + año;
                            Fecha = Convert.ToDateTime(ofecha);
                            break;
                        case 2:
                            ofecha = CadeFech + "/" + mes + "/" + año;
                            Fecha = Convert.ToDateTime(ofecha);
                            break;
                        case 3:
                            MessageBox.Show("No se reconoce fecha");
                            break;

                        case 4:
                            odia = CadeFech.Substring(0, 2);
                            omes = CadeFech.Substring(2, 2);
                            ofecha = odia + "/" + omes + "/" + año;
                            Fecha = Convert.ToDateTime(ofecha);
                            break;
                        case 5:
                            MessageBox.Show("No se reconoce fecha");
                            break;
                        case 6:
                            odia = CadeFech.Substring(0, 2);
                            omes = CadeFech.Substring(2, 2);
                            int a = int.Parse(CadeFech.Substring(4, 2)) + 2000;
                            ofecha = odia + "/" + omes + "/" + a.ToString();
                            Fecha = Convert.ToDateTime(ofecha);
                            break;
                        case 7:
                            break;
                        case 8:
                            odia = CadeFech.Substring(0, 2);
                            omes = CadeFech.Substring(2, 2);
                            oaño = CadeFech.Substring(4, 4);
                            ofecha = odia + "/" + omes + "/" + oaño;
                            Fecha = Convert.ToDateTime(ofecha);
                            break;
                        case 9:
                            break;
                        case 10:
                            Fecha = Convert.ToDateTime(CadeFech);
                            break;
                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Fecha = DateTime.Now;
            }
            return Fecha;
        }
    }
}
