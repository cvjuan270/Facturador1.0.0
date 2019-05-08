using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net.Mime;
using System.Diagnostics;

namespace Facturador1._0._0.Forms
{
	public partial class FormEnvCor : Form
	{
		public FormEnvCor( string Asunto, string RazonS, string rutaPdf)
		{
			InitializeComponent();
			
			txtAsunto.ReadOnly = true;
			txtArchivoAdjunto.ReadOnly = true;
			/**/
			
			txtAsunto.Text = "Documento electrónico"+ Asunto;
			txtMensaje.Text = "Estimado cliente:  " + RazonS + ".\n Se adjunta a este E-mail el documento electrónico :" + Asunto;
			txtArchivoAdjunto.Text = rutaPdf;
			txtReceptor.Focus();

		}

		private void btnEnviar_Click(object sender, EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.AppStarting;

				MailMessage mail = new MailMessage();
				mail.To.Add(new MailAddress(this.txtReceptor.Text));
				mail.From = new MailAddress(Settings1.Default.Correo);
				mail.Subject = txtAsunto.Text;
				mail.Body = txtMensaje.Text;
				mail.IsBodyHtml = false;

				/**/
				Attachment data = new Attachment(txtArchivoAdjunto.Text, MediaTypeNames.Application.Octet);
				mail.Attachments.Add(data);

				/**/

				SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
				
					client.Credentials = new System.Net.NetworkCredential(Settings1.Default.Correo, Settings1.Default.PassCorreo);
					client.EnableSsl = true;
					client.Send(mail);
				

				MessageBox.Show("Email enviado con exito.");
				this.Cursor = Cursors.AppStarting;
				this.Close();
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
		}
	}
}
