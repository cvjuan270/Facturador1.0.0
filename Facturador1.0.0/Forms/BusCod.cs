using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Facturador1._0._0.Forms
{
    public partial class BusCod : Form
    {
        string oDescri;
        public BusCod()
        {
            InitializeComponent();
        }

        private void buttonSel_Click(object sender, EventArgs e)
        {

            oDescri = dataGridView1.CurrentRow.Cells["Descri"].Value.ToString();
            FormDatoMaesArti form = Owner as FormDatoMaesArti;
            form.comboBox_CodSun.Text = oDescri;
            this.Close();
        }

     

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string cmd = string.Format("SELECT * FROM CODSUN WHERE DESCRI LIKE '%'+'{0}'+'%'", textBox1.Text);
            DataTable dt = Conexion.Ejecutar_dt(cmd);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            oDescri = dataGridView1.CurrentRow.Cells["Descri"].Value.ToString();
            FormDatoMaesArti form = Owner as FormDatoMaesArti;
            form.comboBox_CodSun.Text = oDescri;
            this.Close();
        }
    }
}
