using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Facturador1._0._0
{
	public class MonitorArchivos
	{
		public static void main() 
		{
			FileSystemWatcher observador = new FileSystemWatcher(Settings1.Default.DirectorioREPO);
			observador.NotifyFilter = (
				NotifyFilters.DirectoryName |
				NotifyFilters.FileName);

			observador.Created += AlCambiar;
			observador.EnableRaisingEvents = true;
		}

		private static void AlCambiar(object source, FileSystemEventArgs e) 
		{
			WatcherChangeTypes TipoDeCambio = e.ChangeType;
			string tc =TipoDeCambio.ToString();
			//MANDA IMPRESION A IMPRESORA POR DEFECTO
			
			if (tc == "Created")
			{
				try
				{
					Process p = new Process();
					p.StartInfo = new ProcessStartInfo()
					{
						CreateNoWindow = true,
						Verb = "print",
						FileName = e.FullPath
						
					};
					p.Start();
					p.WaitForExit(1000);
				}
				catch (Exception ex)
				{

					MessageBox.Show("Factura" + e.Name + ex.Message);
				}
			}

		}
		
		
	}
}
