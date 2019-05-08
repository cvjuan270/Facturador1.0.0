using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBase1;
using System.Data.SqlClient;

namespace Facturador1._0._0.Forms
{
	public partial class FormFactur : formBaseMark
	{
		string oFormMode;
		int oDocEntry;
		SqlConnection con = Conexion.cn();
		public FormFactur(string FormMode)
		{

			InitializeComponent();
			oFormMode = FormMode;

			switch (FormMode)
			{
				case "Crear":

					buttonOk.Text = "Crear";
					buttonCopDe.Enabled = true;
					buttonCopA.Enabled = false;
					break;
				case "Buscar":

					buttonOk.Text = "Buscar";
					buttonCopDe.Enabled = false;
					buttonCopA.Enabled = false;
					break;
				case "Ver":

					buttonOk.Text = "Ok";
					buttonCopDe.Enabled = false;
					buttonCopA.Enabled = true;
					break;
			}
		}

		private void buttonOk_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.AppStarting;

			switch (buttonOk.Text)
			{
				case "Crear":
					if (textBoxButtonCodCli.Text != "" && textBoxButtonRucCli.Text != null)
					{

						NuevoRegistroEntrega();


					}
					else
					{
						MessageBox.Show("Ingresar Datos de SN.");
					}

					break;
				default:
					break;
			}

			this.Cursor = Cursors.Default;

		}
/// <summary>
/// 
/// </summary>
		void InsLineas()
		{
			try
			{
				SqlCommand NueRegLinEntMer = new SqlCommand("INSERT INTO ACCLI1 VALUES( @DocEntry,@NumLin,@RefBas,@tipBas,@LinBas,@RefObj,@TipObj,@LinObje,@EstLin,@CodArt,@Descri,@Cantid,@Precio,@PreBru,@RatImp,@Impues,@CodUni,@TotLine,@TotBru,(SELECT CODSUN FROM ARTICU WHERE CodArt =@CodArt ))", con);

				con.Open();
				for (int i = 0; i < dataGridView1.RowCount - 1; i++)
				{

					NueRegLinEntMer.Parameters.Clear();

					float s = float.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
					float t = float.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());
					float im = t - s;

					NueRegLinEntMer.Parameters.AddWithValue("@DocEntry", oDocEntry);
					NueRegLinEntMer.Parameters.AddWithValue("@NumLin", i);
					NueRegLinEntMer.Parameters.AddWithValue("@RefBas", DBNull.Value);
					NueRegLinEntMer.Parameters.AddWithValue("@tipBas", DBNull.Value);
					NueRegLinEntMer.Parameters.AddWithValue("@LinBas", DBNull.Value);
					NueRegLinEntMer.Parameters.AddWithValue("@RefObj", DBNull.Value);
					NueRegLinEntMer.Parameters.AddWithValue("@TipObj", DBNull.Value);
					NueRegLinEntMer.Parameters.AddWithValue("@LinObje", DBNull.Value);
					NueRegLinEntMer.Parameters.AddWithValue("@EstLin", "O");
					NueRegLinEntMer.Parameters.AddWithValue("@CodArt", dataGridView1.Rows[i].Cells[0].Value.ToString().Trim());
					NueRegLinEntMer.Parameters.AddWithValue("@Descri", dataGridView1.Rows[i].Cells[1].Value);
					NueRegLinEntMer.Parameters.AddWithValue("@Cantid", float.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()));
					NueRegLinEntMer.Parameters.AddWithValue("@Precio", float.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()));
					NueRegLinEntMer.Parameters.AddWithValue("@PreBru", float.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()));
					NueRegLinEntMer.Parameters.AddWithValue("@RatImp", DBNull.Value);
					NueRegLinEntMer.Parameters.AddWithValue("@Impues", im);
					NueRegLinEntMer.Parameters.AddWithValue("@CodUni", "NIU");
					NueRegLinEntMer.Parameters.AddWithValue("@TotLine", float.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString()));
					NueRegLinEntMer.Parameters.AddWithValue("@TotBru", float.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString()));

					NueRegLinEntMer.ExecuteNonQuery();
				}
				con.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error En lineas de documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				con.Close();
			}
		}
		void NuevoRegistroEntrega()
		{
			try
			{
				#region Encabezado de entrega     
				con.Open();
				SqlCommand NueRegEntMer = new SqlCommand("INSERT INTO FACCLI VALUES ( @NumDoc, @SerDoc, @Estado, @FecReg, @FecVen, @FecDoc, @CodSoc, @NomSoc, @RucSoc, @RefDoc, @ConPag, @SubTot, @Impues, @TotDoc, @Coment, @SerCor, @NumCor, @EstSun, @CodHas, @CadQr,@dirEnt)", con);
				NueRegEntMer.Parameters.Clear();
				NueRegEntMer.Parameters.AddWithValue("@Numdoc", DBNull.Value);
				NueRegEntMer.Parameters.AddWithValue("@SerDoc", textBoxSerNum.Text);
				NueRegEntMer.Parameters.AddWithValue("@Estado", "O");
				NueRegEntMer.Parameters.AddWithValue("@FecReg", textBoxButtonFecReg.Text);
				NueRegEntMer.Parameters.AddWithValue("@FecVen", textBoxButtonFecVen.Text);
				NueRegEntMer.Parameters.AddWithValue("@FecDoc", textBoxButtonFecDoc.Text);
				NueRegEntMer.Parameters.AddWithValue("@CodSoc", textBoxButtonCodCli.Text.Trim());
				NueRegEntMer.Parameters.AddWithValue("@NomSoc", textBoxButtonNomCli.Text);
				NueRegEntMer.Parameters.AddWithValue("@RucSoc", textBoxButtonRucCli.Text);
				NueRegEntMer.Parameters.AddWithValue("@RefDoc", textBoxRefere.Text);
				NueRegEntMer.Parameters.AddWithValue("@ConPag", (int)comboBoxConPag.SelectedValue);
				NueRegEntMer.Parameters.AddWithValue("@SubTot", float.Parse(textBoxSubTot.Text.Substring(3)));
				NueRegEntMer.Parameters.AddWithValue("@Impues", float.Parse(textBoxImpues.Text.Substring(3)));
				NueRegEntMer.Parameters.AddWithValue("@TotDoc", float.Parse(textBoxTotDoc.Text.Substring(3)));
				NueRegEntMer.Parameters.AddWithValue("@Coment", textBoxComent.Text);
				NueRegEntMer.Parameters.AddWithValue("@SerCor", textBoxSerCor.Text);
				NueRegEntMer.Parameters.AddWithValue("@NumCor", textBoxNumDoc.Text);
				NueRegEntMer.Parameters.AddWithValue("@EstSun", 0);
				NueRegEntMer.Parameters.AddWithValue("@CodHas", "");
				NueRegEntMer.Parameters.AddWithValue("@CadQr", "");
				NueRegEntMer.Parameters.AddWithValue("@DirEnt", textBoxDire.Text);

				NueRegEntMer.ExecuteNonQuery();
				con.Close();

				//Actualizar tablade datos generales
				con.Open();
				SqlCommand command = new SqlCommand("EXECUTE  [dbo].[Inc_DatObj] @TipObj", con);
				command.Parameters.AddWithValue("@TipObj", 4);
				command.ExecuteNonQuery();
				//seleccionar docEntri para las lineas
				DataSet data = Conexion.Ejecutar_ds("select MAX(DocEntry) from FACCLI");
				oDocEntry = int.Parse(data.Tables[0].Rows[0].ItemArray[0].ToString());
				con.Close();
				textBoxNumDoc.Text = oDocEntry.ToString();
				#endregion

				#region Lineas de entrega


				SqlCommand NueRegLinEntMer = new SqlCommand("INSERT INTO ACCLI1 VALUES( @DocEntry,@NumLin,@RefBas,@tipBas,@LinBas,@RefObj,@TipObj,@LinObje,@EstLin,@CodArt,@Descri,@Cantid,@Precio,@PreBru,@RatImp,@Impues,@CodUni,@TotLine,@TotBru,(SELECT CODSUN FROM ARTICU WHERE CodArt =@CodArt ))", con);

				con.Open();
				for (int i = 0; i < dataGridView1.RowCount - 1; i++)
				{

					NueRegLinEntMer.Parameters.Clear();

					float s = float.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
					float t = float.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());
					float im = t - s;

					NueRegLinEntMer.Parameters.AddWithValue("@DocEntry", oDocEntry);
					NueRegLinEntMer.Parameters.AddWithValue("@NumLin", i);
					NueRegLinEntMer.Parameters.AddWithValue("@RefBas", DBNull.Value);
					NueRegLinEntMer.Parameters.AddWithValue("@tipBas", DBNull.Value);
					NueRegLinEntMer.Parameters.AddWithValue("@LinBas", DBNull.Value);
					NueRegLinEntMer.Parameters.AddWithValue("@RefObj", DBNull.Value);
					NueRegLinEntMer.Parameters.AddWithValue("@TipObj", DBNull.Value);
					NueRegLinEntMer.Parameters.AddWithValue("@LinObje", DBNull.Value);
					NueRegLinEntMer.Parameters.AddWithValue("@EstLin", "O");
					NueRegLinEntMer.Parameters.AddWithValue("@CodArt", dataGridView1.Rows[i].Cells[0].Value.ToString().Trim());
					NueRegLinEntMer.Parameters.AddWithValue("@Descri", dataGridView1.Rows[i].Cells[1].Value);
					NueRegLinEntMer.Parameters.AddWithValue("@Cantid", float.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()));
					NueRegLinEntMer.Parameters.AddWithValue("@Precio", float.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()));
					NueRegLinEntMer.Parameters.AddWithValue("@PreBru", float.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()));
					NueRegLinEntMer.Parameters.AddWithValue("@RatImp", DBNull.Value);
					NueRegLinEntMer.Parameters.AddWithValue("@Impues", im);
					NueRegLinEntMer.Parameters.AddWithValue("@CodUni", "NIU");
					NueRegLinEntMer.Parameters.AddWithValue("@TotLine", float.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString()));
					NueRegLinEntMer.Parameters.AddWithValue("@TotBru", float.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString()));

					NueRegLinEntMer.ExecuteNonQuery();
				}
				con.Close();

				#endregion

				MessageBox.Show("Documento generado con Exito", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

				#region Genera archivos

				this.Enabled = false;
				try
				{
					DataSet ds = Conexion.Ejecutar_ds("select top(1) DocEntry from FACCLI    order by docentry desc");
					int oDocEntry = int.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString());

					GeneraArchivos.GenCAB(oDocEntry, "01");
					GeneraArchivos.GenDET(oDocEntry, "01");
					GeneraArchivos.GenTRI(oDocEntry, "01");
					GeneraArchivos.GenLEY(oDocEntry, "01");
					GeneraArchivos.GenACA(oDocEntry, "01");

				}
				catch (Exception ex)
				{

					MessageBox.Show(ex.Message, "Error al generar archivos");
				}
				
				#endregion


				this.Close();

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				con.Close();
			}

		}
		void ActualizarForm()
		{
			textBoxButtonCodCli.Text = "";
			textBoxButtonNomCli.Text = "";
			textBoxButtonRucCli.Text = "";

			while (dataGridView1.RowCount > 1)
			{
				dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
			}
			textBoxSubTot.Text = "";
			textBoxImpues.Text = "";
			textBoxTotDoc.Text = "";
			textBoxNumCor.Text = (int.Parse(textBoxNumCor.Text) + 1).ToString();
		}

		
	}
}
