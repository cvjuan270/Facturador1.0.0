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
    public partial class FormBaseBusArt : Form
    {
        int RowIndex;
        public FormBaseBusArt(int rowIndex,int x, int y)
        {
            InitializeComponent();
            this.DesktopLocation = new Point(x, y);
            this.StartPosition = FormStartPosition.Manual;

            RowIndex = rowIndex;
        }

        private void buttonCan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string cmd = string.Format("select CodArt,Descri from ARTICU where Descri like '%{0}%'", textBox1.Text);
                DataTable dt = Conexion.Ejecutar_dt(cmd);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                formBaseMark baseMark = Owner as formBaseMark;
                DataGridViewRow row = baseMark.dataGridView1.Rows[RowIndex];
                row.Cells[0].Value = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                row.Cells[1].Value = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            
        }

        private void buttonSel_Click(object sender, EventArgs e)
        {
            try
            {
                formBaseMark baseMark = Owner as formBaseMark;
                DataGridViewRow row = baseMark.dataGridView1.Rows[RowIndex];
                row.Cells[0].Value = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                row.Cells[1].Value = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

		private void FormBaseBusArt_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				try
				{

					formBaseMark baseMark = Owner as formBaseMark;
					DataGridViewRow row = baseMark.dataGridView1.Rows[RowIndex];
					row.Cells[0].Value = dataGridView1.CurrentRow.Cells[0].Value.ToString();
					row.Cells[1].Value = dataGridView1.CurrentRow.Cells[1].Value.ToString();

					this.Close();

				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);

				}

			}
		}

		private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				try
				{

					formBaseMark baseMark = Owner as formBaseMark;
					DataGridViewRow row = baseMark.dataGridView1.Rows[RowIndex];
					row.Cells[0].Value = dataGridView1.CurrentRow.Cells[0].Value.ToString();
					row.Cells[1].Value = dataGridView1.CurrentRow.Cells[1].Value.ToString();

					this.Close();

				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);

				}

			}
		}

		private void dataGridView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				try
				{

					formBaseMark baseMark = Owner as formBaseMark;
					DataGridViewRow row = baseMark.dataGridView1.Rows[RowIndex];
					row.Cells[0].Value = dataGridView1.CurrentRow.Cells[0].Value.ToString();
					row.Cells[1].Value = dataGridView1.CurrentRow.Cells[1].Value.ToString();

					this.Close();

				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);

				}

			}
		}
	}
}
