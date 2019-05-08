using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Facturador1._0._0.Forms
{
	public partial class FormNavFacSun : Form
	{
		public FormNavFacSun()
		{
			InitializeComponent();
			 webBrowser1.Navigate(Settings1.Default.RutaSFS);
			

			DataTable dt = Conexion.Ejecutar_dt(string.Format("select NomSoc, TotDoc, SerCor , convert(varchar(10), NumCor), FecDoc from FACCLI where FecDoc between '{0}' and '{1}'", dateTimePickerFecIni.Value.ToShortDateString(), dateTimePickerFecFin.Value.ToShortDateString()));

			dataGridView1.DataSource = dt;
			dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
			dataGridView1.Columns[1].Width = 63;
			dataGridView1.Columns[2].Width = 63;
			dataGridView1.Columns[3].Width = 50;
			dataGridView1.Columns[4].Width = 100;

			dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			dataGridView1.Columns[1].DefaultCellStyle.Format = "N2";
			dataGridView1.Columns[3].DefaultCellStyle.Format = "N";

			dataGridView1.Columns[3].DefaultCellStyle.BackColor = Color.LightGreen;
			
		}

		private void dateTimePickerFecIni_ValueChanged(object sender, EventArgs e)
		{
			DataTable dt = Conexion.Ejecutar_dt(string.Format("select NomSoc, TotDoc, SerCor , convert(varchar(10), NumCor), FecDoc from FACCLI where FecDoc between '{0}' and '{1}'", dateTimePickerFecIni.Value.ToShortDateString(), dateTimePickerFecFin.Value.ToShortDateString()));
			dataGridView1.DataSource = dt;

		}

		private void dateTimePickerFecFin_ValueChanged(object sender, EventArgs e)
		{
			DataTable dt = Conexion.Ejecutar_dt(string.Format("select NomSoc, TotDoc, SerCor , convert(varchar(10), NumCor), FecDoc from FACCLI where FecDoc between '{0}' and '{1}'", dateTimePickerFecIni.Value.ToShortDateString(), dateTimePickerFecFin.Value.ToShortDateString()));
			dataGridView1.DataSource = dt;
		}

		

		private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			webBrowser1.Document.Body.Style = "font-size:90%;";

		}

		private void panel3_Paint(object sender, PaintEventArgs e)
		{

		}

//actualizar
		private void button3_Click(object sender, EventArgs e)
		{
			DataTable dt = Conexion.Ejecutar_dt(string.Format("select NomSoc, TotDoc, SerCor , convert(varchar(10), NumCor), FecDoc from FACCLI where FecDoc between '{0}' and '{1}'", dateTimePickerFecIni.Value.ToShortDateString(), dateTimePickerFecFin.Value.ToShortDateString()));
			dataGridView1.DataSource = dt;
		}

//IMPRIMIR	
		private void button1_Click(object sender, EventArgs e)
		{
			//20558326256-01-F001-1
			string serie = dataGridView1.CurrentRow.Cells[2].Value.ToString();
			string numero = dataGridView1.CurrentRow.Cells[3].Value.ToString();
			string nombre = Settings1.Default.RUC + "-" + "01" + "-" + serie + "-" + numero + ".pdf";

			try
			{
				Process p = new Process();
				p.StartInfo = new ProcessStartInfo()
				{
					CreateNoWindow = true,
					Verb = "print",
					FileName = Settings1.Default.DirectorioREPO + nombre//path //put the correct path here
				};
				p.Start();
				p.WaitForExit(1000);
			}
			catch (Exception ex)
			{

				MessageBox.Show("Factura" + nombre + ex.Message);
			}
		}

		private void buttonEnvCor_Click(object sender, EventArgs e)
		{
			string NomSN = dataGridView1.CurrentRow.Cells[0].Value.ToString();
			string serie = dataGridView1.CurrentRow.Cells[2].Value.ToString();
			string numero = dataGridView1.CurrentRow.Cells[3].Value.ToString();
			string asunto = Settings1.Default.RUC + "-" + "01" + "-" + serie + "-" + numero;
			string nombre = Settings1.Default.RUC + "-" + "01" + "-" + serie + "-" + numero + ".pdf";
			string ruta = Settings1.Default.DirectorioREPO + nombre;

			Forms.FormEnvCor formEnvCor = new FormEnvCor(asunto, NomSN, ruta);
			formEnvCor.ShowDialog();
		}




		/*
				private void webBrowserFS_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
				{

				}
		*/
	}
}
