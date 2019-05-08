using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace FormBase1
{
    public partial class FormBaseBusc : Form
    {
        string Query, oDescri, oTipBut;

        public FormBaseBusc(string TipBut, string oQuery, int x, int y)
        {
            InitializeComponent();
            Query = oQuery;
            this.StartPosition = FormStartPosition.Manual;
            this.DesktopLocation = new Point(x, y);
            oTipBut = TipBut;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                switch (oTipBut)
                {
                    case "CodSoc":
						// Busca por codigo
						this.Text = "Buscar SN por código";
                        string cmd = string.Format("SELECT CodSoc,NomSoc,RucSoc,DirFac FROM SOCNEG WHERE TipSoc = 1 AND CodSoc LIKE '%{0}%'", textBox1.Text);
                        DataTable dt = Conexion.Ejecutar_dt(cmd);
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns[3].Visible = false;
                        //
                        break;
                    case "NomSoc":
						//buscar por nombre de socio de negocios
						this.Text = "Buscar SN por Nombre";
						string cmd1 = string.Format("SELECT CodSoc,NomSoc,RucSoc,DirFac FROM SOCNEG WHERE TipSoc = 1 AND NomSoc LIKE '%{0}%'", textBox1.Text);
                        DataTable dt1 = Conexion.Ejecutar_dt(cmd1);
                        dataGridView1.DataSource = dt1;
                        dataGridView1.Columns[3].Visible = false;


                        break;

                    case "RucSoc":

						//buscar por Ruc socio de negocios
						this.Text = "Buscar SN por RUC";
						string cmd2 = string.Format("SELECT CodSoc,NomSoc,RucSoc ,DirFac FROM SOCNEG WHERE TipSoc = 1 AND RucSoc LIKE '%{0}%'", textBox1.Text);
                        DataTable dt2 = Conexion.Ejecutar_dt(cmd2);
                        dataGridView1.DataSource = dt2;
                        //dataGridView1.Columns[3].Visible = false;
                        break;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }




        }

        private void buttonSel_Click(object sender, EventArgs e)
        {

            PasarDatos();
            this.Close();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PasarDatos();
            this.Close();

        }

        private void buttonNue_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Boton desactivado");
        }

        private void FormBaseBusc_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                PasarDatos();
                this.Close();
            }
            else if(e.KeyCode == Keys.Escape)
       
            {
                this.Close();
            }
        }

        void PasarDatos()
        {
            formBaseMark form = Owner as formBaseMark;
            form.textBoxButtonCodCli.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            form.textBoxButtonNomCli.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            form.textBoxButtonRucCli.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            form.textBoxDire.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            string cmd = string.Format("SELECT t1.Descri FROM SOCNEG t0 inner join CONPAG t1 on t1.CodCon = t0.ConPag  WHERE t0.CodSoc = '{0}'", dataGridView1.CurrentRow.Cells["CodSoc"].Value.ToString());
            DataSet ds = Conexion.Ejecutar_ds(cmd);
            form.comboBoxConPag.Text = (string)ds.Tables[0].Rows[0][0];
        }

        private void buttonCan_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
