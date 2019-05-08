using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace Facturador1._0._0
{
	public class GeneraArchivos
	{
		//CAB
		public static void GenCAB(int docEntry, string TipDoc)
		{
			string Nombre = Settings1.Default.RUC + "-" + TipDoc + "-" + Settings1.Default.SerieFactura + "-" + docEntry + ".CAB";
			string ruta = Settings1.Default.DirectorioDATA + Nombre;
			DataSet ds = Conexion.Ejecutar_ds(string.Format("EXECUTE ConFac_CAB @DocEntry ={0}", docEntry));

			StreamWriter writer = new StreamWriter(ruta);
			for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
			{
				writer.Write(ds.Tables[0].Rows[0].ItemArray[i].ToString() + "|");
			}
			writer.Close();
		}
		public static void GenDET (int docEntry, string TipDoc)
		{
			string Nombre = Settings1.Default.RUC + "-" + TipDoc + "-" + Settings1.Default.SerieFactura + "-" + docEntry + ".DET";
			string ruta = Settings1.Default.DirectorioDATA + Nombre;
			DataSet ds = Conexion.Ejecutar_ds(string.Format("EXECUTE ConFac_DET @DocEntry ={0}", docEntry));
			StreamWriter writer = new StreamWriter(ruta);
			for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
			{
				for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
				{
					writer.Write(ds.Tables[0].Rows[j].ItemArray[i].ToString() + "|");
				}
				writer.WriteLine();
			}
			writer.Close();
		}
		public static void GenTRI(int docEntry, string TipDoc) 
		{
			string Nombre = Settings1.Default.RUC + "-" + TipDoc + "-" + Settings1.Default.SerieFactura + "-" + docEntry + ".TRI";
			string ruta = Settings1.Default.DirectorioDATA + Nombre;
			DataSet ds = Conexion.Ejecutar_ds(string.Format("EXECUTE ConFac_TRI @DocEntry ={0}", docEntry));
			StreamWriter writer = new StreamWriter(ruta);
			for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
			{
				writer.Write(ds.Tables[0].Rows[0].ItemArray[i].ToString() + "|");
			}
			writer.Close();
		}
		public static void GenLEY(int docEntry, string TipDoc)
		{
			string Nombre = Settings1.Default.RUC + "-" + TipDoc + "-" + Settings1.Default.SerieFactura + "-" + docEntry + ".LEY";
			string ruta = Settings1.Default.DirectorioDATA + Nombre;
			DataSet ds = Conexion.Ejecutar_ds(string.Format("EXECUTE ConFac_LEY @DocEntry ={0}", docEntry));
			StreamWriter writer = new StreamWriter(ruta);
			string Campo0 = ds.Tables[0].Rows[0].ItemArray[0].ToString();
			string Campo1 = Funciones.enletras(ds.Tables[0].Rows[0].ItemArray[1].ToString());

			writer.Write(Campo0 + "|" + Campo1+" Soles");
			writer.Close();

		}
		public static void GenACA(int docEntry, string TipDoc) 
		{
			string Nombre = Settings1.Default.RUC + "-" + TipDoc + "-" + Settings1.Default.SerieFactura + "-" + docEntry + ".ACA";
			string ruta = Settings1.Default.DirectorioDATA + Nombre;
			DataSet ds = Conexion.Ejecutar_ds(string.Format("EXECUTE ConFac_ACA @DocEntry ={0}", docEntry));
			StreamWriter writer = new StreamWriter(ruta);
			for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
			{
				writer.Write(ds.Tables[0].Rows[0].ItemArray[i].ToString() + "|");
			}
			writer.Close();
		}
	}
}
