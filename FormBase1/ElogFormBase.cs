using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace FormBase1
{
	public class ElogFormBase
	{
		public static void save(object obj, Exception ex)
		{
			string fecha = DateTime.Now.ToString("dd/MM/yyyy");
			string hora = DateTime.Now.ToString("HH:mm:ss");
			StreamWriter sw = new StreamWriter("LogformBase.txt", true);

			StackTrace stackTrace = new StackTrace();
			sw.WriteLine(obj.GetType().FullName + " " + hora);
			sw.WriteLine(stackTrace.GetFrame(1).GetMethod().Name + " - " + ex.Message);
			sw.WriteLine("");

			sw.Flush();
			sw.Close();
		}
	}
}
