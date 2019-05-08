using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBase1;
using TextBoxButtonControl;
using System.Data.SqlClient;


namespace Facturador1._0._0.Forms
{
    public partial class FormEntreg : formBaseMark 
    {
        string oFormMode;
        int oDocEntry;
        SqlConnection con = Conexion.cn();
        public FormEntreg(string FormMode) //: base("ENTMER", "NTMER1")
        {
            InitializeComponent();
            oFormMode = FormMode;

            //((MDIParent2)this.MdiParent).toolStripStatusLabel1.Text = "";
            //((MDIParent2)this.MdiParent).toolStripStatusLabel1.BackColor = DefaultForeColor;

            switch (FormMode)
            { case "Crear":

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
           
            
            /**/
            
        }


        void InsLineas()
        {
            try
            {
                SqlCommand NueRegLinEntMer = new SqlCommand("INSERT INTO NTMER1 VALUES( @DocEntry,@NumLin,@RefBas,@tipBas,@LinBas,@RefObj,@TipObj,@LinObje,@EstLin,@CodArt,@Descri,@Cantid,@Precio,@PreBru,@RatImp,@Impues,@CodUni,@TotLine,@TotBru,(SELECT CODSUN FROM ARTICU WHERE CodArt =@CodArt ))", con);

                con.Open();
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {

                    NueRegLinEntMer.Parameters.Clear();

                    float s = float.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
                    float t = float.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());
                    float im = t - s;

                    NueRegLinEntMer.Parameters.AddWithValue("@DocEntry",oDocEntry );
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
                SqlCommand NueRegEntMer = new SqlCommand("INSERT INTO ENTMER VALUES ( @NumDoc, @SerDoc, @Estado, @FecReg, @FecVen, @FecDoc, @CodSoc, @NomSoc, @RucSoc, @RefDoc, @ConPag, @SubTot, @Impues, @TotDoc, @Coment, @SerCor, @NumCor, @EstSun, @CodHas, @CadQr,@dirEnt)", con);
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
                command.Parameters.AddWithValue("@TipObj", 3);
                command.ExecuteNonQuery();
                //seleccionar docEntri para las lineas
                DataSet data = Conexion.Ejecutar_ds("select MAX(DocEntry) from ENTMER");
                oDocEntry = int.Parse(data.Tables[0].Rows[0].ItemArray[0].ToString());
                con.Close();
                textBoxNumDoc.Text = oDocEntry.ToString();
                #endregion

                #region Lineas de entrega


                SqlCommand NueRegLinEntMer = new SqlCommand("INSERT INTO NTMER1 VALUES( @DocEntry,@NumLin,@RefBas,@tipBas,@LinBas,@RefObj,@TipObj,@LinObje,@EstLin,@CodArt,@Descri,@Cantid,@Precio,@PreBru,@RatImp,@Impues,@CodUni,@TotLine,@TotBru,(SELECT CODSUN FROM ARTICU WHERE CodArt =@CodArt ))", con);

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

                MessageBox.Show("Documento generado con Exito","",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
				this.Close();
                
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.ToString(),"Error de registro",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

            while (dataGridView1.RowCount>1)
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

#region ejempplo de codigo para guardar datos de form   

/*
//ENTMER//
string cmd = "";
cmd= string.Format("EXEC	[dbo].[NueRegEntMer] @NumDoc = {0},@SerDoc = N'Default',@Estado = N'O',@FecReg = '{1}',@FecVen = '{2}',@FecDoc = '{3}',@CodSoc = '{4}',@NomSoc = '{5}',@RucSoc = {6},@RefDoc = null,@ConPag = {7},@SubTot = {8},@Impues = {9},@TotDoc = {10},@Coment = '{11}',@SerCor = '{12}',@NumCor = {13},@EstSun = 0,@CodHas = null,@CadQr = null", textBoxNumDoc.Text, textBoxButtonFecReg.Text, textBoxButtonFecVen.Text, textBoxButtonFecDoc.Text, textBoxButtonCodCli.Text, textBoxButtonNomCli.Text, textBoxButtonRucCli.Text, comboBoxConPag.SelectedValue.ToString(), float.Parse(textBoxSubTot.Text.Substring(3)), float.Parse(textBoxImpues.Text.Substring(3)),  float.Parse(textBoxTotDoc.Text.Substring(3)), textBoxComent.Text, textBoxSerCor.Text, textBoxNumDoc.Text);
textBoxComent.Text = cmd;
Conexion.Ejecutar_ds(cmd);
*/
//NTMER1//
/*

try
{
    foreach (DataGridViewRow i in dataGridView1.Rows)
    {
        string cmd1 = "";
        double Cant = double.Parse(i.Cells[2].Value.ToString());
        double prec = double.Parse(i.Cells[3].Value.ToString());
        double impu = (prec * 0.18) * Cant;


        cmd1 = string.Format("EXECUTE  [dbo].[NueRegLinEntMer] @DocEntry={0},@NumLin={1},@RefBas= null,@tipBas= null,@LinBas= null,@RefObj= null,@TipObj= null,@LinObje= null,@EstLin='O',@CodArt='{2}',@Descri='{3}',@Cantid={4},@Precio={5},@PreBru={6},@RatImp=null,@Impues={7},@CodUni='{8}',@TotLine={9},@TotBru={10}", textBoxNumDoc.Text, i.Index, i.Cells[0].Value, i.Cells[1].Value, float.Parse(i.Cells[2].Value.ToString()), float.Parse(i.Cells[3].Value.ToString()), float.Parse(i.Cells[4].Value.ToString()), impu, i.Cells[6].Value, float.Parse(i.Cells[7].Value.ToString()), float.Parse(i.Cells[8].Value.ToString()));

        Conexion.Ejecutar_ds(cmd1);
    }
}
catch (Exception ex)
{
    MessageBox.Show("Lineas  " + ex.Message + "\b\r" + ex.InnerException.ToString());
    Conexion.Ejecutar_ds(string.Format("DELETE FROM [dbo].[ENTMER]WHERE NumDoc ={0}", textBoxNumDoc.Text));
    Conexion.Ejecutar_ds(string.Format("DELETE FROM [dbo].[NTMER1]WHERE DocEntry ={0}", textBoxNumDoc.Text));

}
*/
#endregion