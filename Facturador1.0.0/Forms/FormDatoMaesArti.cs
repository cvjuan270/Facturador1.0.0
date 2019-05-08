using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;


namespace Facturador1._0._0.Forms
{
    public partial class FormDatoMaesArti : Form
    {
        public string oMod;
        public FormDatoMaesArti(string Mod)
        {
            InitializeComponent();

            try
            {
                //Codigo sunat
                DataTable dt = Conexion.Ejecutar_dt("select  * from CODSUN ");

                comboBox_CodSun.DisplayMember = "Descri";
                comboBox_CodSun.ValueMember = "CodSun";
                comboBox_CodSun.DataSource = dt;
                comboBox_CodSun.Text = "__Seleccione una obción__";


                //Grupo de articulos
                DataTable dt1 = Conexion.Ejecutar_dt("select CodGru ,Descri from GRUART");
                comboBoxGruArt.DisplayMember = "Descri";
                comboBoxGruArt.ValueMember = "CodGru";
                comboBoxGruArt.DataSource = dt1;
                comboBoxGruArt.Text = "__Seleccione una obción__";


                //Unidad de medida
                DataTable dt2 = Conexion.Ejecutar_dt("select CodUni ,Descri from UNIMED");
                comboBoxUniMed.DisplayMember = "Descri";
                comboBoxUniMed.ValueMember = "CodUni";
                comboBoxUniMed.DataSource = dt2;
                comboBoxUniMed.Text = "UNIDAD (BIENES)";

                //Lista de precios
                DataTable dt3 = Conexion.Ejecutar_dt("select CodLis ,Descri from LISPRE");
                comboBoxLisPre.DisplayMember = "Descri";
                comboBoxLisPre.ValueMember = "CodList";
                comboBoxLisPre.DataSource = dt3;
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
           
            switch (Mod)
            {
                case "Cre":
                    buttonAce.Text = "Crear";
                    oMod = "Cre";
                    //

                    break;
                case "Ver":
                    buttonAce.Text = "Aceptar";
                    break;

            }

        }

        private void button_buscaCodiSunat_Click(object sender, EventArgs e)
        {
            BusCod busCod = new BusCod();
            AddOwnedForm(busCod);
            busCod.Show();
        }


        private void comboBox_CodiSunat_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBoxPreUni_Enter(object sender, EventArgs e)
        {
            // El control TextBox ha tomado el foco.
            //
            // Referenciamos el control TextBox que ha
            // desencadenado el evento.
            //
            TextBox tb = (TextBox)sender;

            // Mostramos en el control TextBox el valor
            // de la propiedad Tag sin formatear.
            //
            tb.Text = Convert.ToString(tb.Tag);
        }

        private void textBoxPreUni_Leave(object sender, EventArgs e)
        {
            // El control TextBox ha perdido el foco.
            //
            // Referenciamos el control TextBox que ha
            // desencadenado el evento.
            //
            TextBox tb = (TextBox)sender;

            // Primero verificamos si el valor se puede convertir a Decimal.
            //
            decimal numero = default(decimal);
            bool bln = decimal.TryParse(tb.Text, out numero);

            if ((!(bln)))
            {
                // No es un valor decimal válido; limpiamos el control.
                tb.Clear();
                return;
            }

            // En la propiedad Tag guardamos el valor con todos los decimales.
            //
            tb.Tag = numero;

            // Y acto seguido formateamos el valor
            // a monetario con dos decimales.
            //
            tb.Text = string.Format("{0:N2}", numero);
        }

        private void buttonCan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAce_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            try
            {
                switch (oMod)
                {
                    case "Cre":

                        int oArtInv, oArtCom, oArtVen, oArtAct, oArtIna;
                        oArtInv = checkBoxArti_Inventario.Checked ? 1 : 0;
                        oArtCom = checkBoxArti_Compra.Checked ? 1 : 0;
                        oArtVen = checkBoxArti_Venta.Checked ? 1 : 0;
                        oArtAct = radioButton_Activo.Checked ? 1 : 0;
                        oArtIna = radioButton_Inactivo.Checked ? 1 : 0;


                        string cmd = string.Format("EXECUTE  [dbo].[NueRegArt] @CodArt = {0} ,@Descri='{1}' ,@CodSun='{2}' ,@GruArt={3},@PreUni={4},@CodUni='{5}',@ArtInv={6},@ArtCom={7},@ArtVen={8},@ArtAct={9},@ArtIna={10}", textBoxCodArt.Text, textBoxDescri.Text, comboBox_CodSun.SelectedValue.ToString(), comboBoxGruArt.SelectedValue.ToString(), textBoxPreUni.Text,  comboBoxUniMed.SelectedValue.ToString(), oArtInv, oArtCom, oArtVen, oArtAct, oArtIna);
                        
                        Conexion.Ejecutar_ds(cmd);

                        MessageBox.Show("Nuevo Registro generado con Exito");

                        /*LIMPIAR CAMPOS*/
                        textBoxCodArt.Text = "";
                        textBoxDescri.Text = "";

                        /**/

                        break;

                        //FALTA CORREGIR REGISTRO DE LISTA DE PRECIOS
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }

        
    }
}