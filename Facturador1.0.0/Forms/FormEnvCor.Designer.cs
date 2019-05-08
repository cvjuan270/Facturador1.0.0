namespace Facturador1._0._0.Forms
{
	partial class FormEnvCor
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtMensaje = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtArchivoAdjunto = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtAsunto = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtReceptor = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnEnviar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtMensaje
			// 
			this.txtMensaje.BackColor = System.Drawing.SystemColors.Info;
			this.txtMensaje.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtMensaje.ForeColor = System.Drawing.Color.Black;
			this.txtMensaje.Location = new System.Drawing.Point(99, 88);
			this.txtMensaje.Multiline = true;
			this.txtMensaje.Name = "txtMensaje";
			this.txtMensaje.Size = new System.Drawing.Size(257, 102);
			this.txtMensaje.TabIndex = 17;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 91);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(82, 13);
			this.label4.TabIndex = 16;
			this.label4.Text = "Archivo Adjunto";
			// 
			// txtArchivoAdjunto
			// 
			this.txtArchivoAdjunto.BackColor = System.Drawing.SystemColors.Info;
			this.txtArchivoAdjunto.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtArchivoAdjunto.ForeColor = System.Drawing.Color.Black;
			this.txtArchivoAdjunto.Location = new System.Drawing.Point(99, 62);
			this.txtArchivoAdjunto.Name = "txtArchivoAdjunto";
			this.txtArchivoAdjunto.Size = new System.Drawing.Size(257, 13);
			this.txtArchivoAdjunto.TabIndex = 15;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 65);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(82, 13);
			this.label3.TabIndex = 14;
			this.label3.Text = "Archivo Adjunto";
			// 
			// txtAsunto
			// 
			this.txtAsunto.BackColor = System.Drawing.SystemColors.Info;
			this.txtAsunto.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtAsunto.ForeColor = System.Drawing.Color.Black;
			this.txtAsunto.Location = new System.Drawing.Point(99, 36);
			this.txtAsunto.Name = "txtAsunto";
			this.txtAsunto.Size = new System.Drawing.Size(257, 13);
			this.txtAsunto.TabIndex = 13;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 12;
			this.label2.Text = "Asunto";
			// 
			// txtReceptor
			// 
			this.txtReceptor.BackColor = System.Drawing.SystemColors.Info;
			this.txtReceptor.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtReceptor.ForeColor = System.Drawing.Color.Black;
			this.txtReceptor.Location = new System.Drawing.Point(99, 10);
			this.txtReceptor.Name = "txtReceptor";
			this.txtReceptor.Size = new System.Drawing.Size(257, 13);
			this.txtReceptor.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "Para:";
			// 
			// btnEnviar
			// 
			this.btnEnviar.Location = new System.Drawing.Point(281, 196);
			this.btnEnviar.Name = "btnEnviar";
			this.btnEnviar.Size = new System.Drawing.Size(75, 23);
			this.btnEnviar.TabIndex = 9;
			this.btnEnviar.Text = "Enviar";
			this.btnEnviar.UseVisualStyleBackColor = true;
			this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
			// 
			// FormEnvCor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(368, 235);
			this.Controls.Add(this.txtMensaje);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtArchivoAdjunto);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtAsunto);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtReceptor);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnEnviar);
			this.Name = "FormEnvCor";
			this.Text = "FormEnvCor";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtMensaje;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtArchivoAdjunto;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtAsunto;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtReceptor;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnEnviar;
	}
}