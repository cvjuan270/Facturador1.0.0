using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Facturador1._0._0
{

    public partial class MDIParent2 : Form
    {
		
		private int childFormNumber = 0;
		
		public MDIParent2()
        {
            InitializeComponent();
			MonitorArchivos.main();
		}

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

//cargar from Datos maestros de clientes
        private void button5_Click(object sender, EventArgs e)
        {
            
            this.Cursor = Cursors.AppStarting;
            Forms.FormOfeVen formDatoMaesArti = new Forms.FormOfeVen();
            formDatoMaesArti.MdiParent = this;
            formDatoMaesArti.Show();
            this.Cursor = Cursors.Default;
        }

//Cargar Form de ENTREGAS
        private void button4_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            Forms.FormEntreg formEntreg = new Forms.FormEntreg("Crear");
            formEntreg.MdiParent = this;
            //
            DataSet ds= Conexion.Ejecutar_ds("SELECT TipObj,Serie,NextDocNum,SerCor,NexNumCor FROM DATOBJ WHERE TipObj = 3 ");
			formEntreg.textBoxSerNum.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
			formEntreg.textBoxNumDoc.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
			formEntreg.textBoxSerCor.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
			formEntreg.textBoxNumCor.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
			//
			formEntreg.Show();
            this.Cursor = Cursors.Default;
        }

//Cargar Form de FACTURAS
		private void button3_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.AppStarting;

			Forms.FormFactur formFactur = new Forms.FormFactur("Crear");
			formFactur.MdiParent = this;
			DataSet ds = Conexion.Ejecutar_ds("SELECT TipObj,Serie,NextDocNum,SerCor,NexNumCor FROM DATOBJ WHERE TipObj = 4");
			formFactur.textBoxSerNum.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
			formFactur.textBoxNumDoc.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
			formFactur.textBoxSerCor.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
			formFactur.textBoxNumCor.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
			//
			formFactur.Show();

			this.Cursor = Cursors.Default;
		}

		private void button7_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.AppStarting;

			Forms.FormNavFacSun formNavFacSun = new Forms.FormNavFacSun();
			formNavFacSun.MdiParent = this;
			formNavFacSun.Show();

			this.Cursor = Cursors.Default;

		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.AppStarting;

			Forms.FormDatoMaesArti datoMaesArti = new Forms.FormDatoMaesArti("Cre");
			datoMaesArti.MdiParent = this;
			DataSet ds = Conexion.Ejecutar_ds("SELECT TipObj,Serie,NextDocNum,SerCor,NexNumCor FROM DATOBJ WHERE TipObj = 4");

			//
			datoMaesArti.Show();

			this.Cursor = Cursors.Default;
		}
	}
}
