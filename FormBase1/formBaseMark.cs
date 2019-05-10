using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace FormBase1
{
    public partial class formBaseMark : Form
    {
		string oTabEnc, oTabLin;

        string oQuery;

        double oCantid =1;
        double oPreUni = 0;
        double oPreBru = 0;
        double oImpu = 0;
        double oTotal = 0;
        double oTotBru = 0;

        //
        //int orow, oCell;
        //navegador para consulta por ruc a sunat
        WebBrowser navegador = new WebBrowser();

        public formBaseMark()//string TabEnc, string TabLin
		{
            InitializeComponent();
			try
			{
				//oTabEnc = TabEnc;
				//oTabLin = TabLin;



				textBoxButtonFecReg.Text = DateTime.Now.ToString("dd/MM/yyyy");
				textBoxButtonFecVen.Text = DateTime.Now.ToString("dd/MM/yyyy");
				textBoxButtonFecDoc.Text = DateTime.Now.ToString("dd/MM/yyyy");

				/*consiciones de pago*/
				DataTable dt = Conexion.Ejecutar_dt("SELECT * FROM CONPAG");
				comboBoxConPag.DisplayMember = "Descri";
				comboBoxConPag.ValueMember = "CodCon";
				comboBoxConPag.DataSource = dt;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);	
				ElogFormBase.save(this,ex);
			}
           


            //Data grid

        }

        #region DatagridView

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
			try
			{
				if (dataGridView1.CurrentCell.ColumnIndex == 0 || dataGridView1.CurrentCell.ColumnIndex == 1)
				{
					if (textBoxButtonCodCli.Text == "")
					{

						textBoxButtonCodCli.Focus();
						MessageBox.Show("Ingresar Codigo de SN");

					}
					else
					{
						dataGridView1.BeginEdit(true);
					}
				}
			}
			catch (Exception ex)
			{

				//MessageBox.Show(ex.Message);
				ElogFormBase.save(this, ex);
			}
			
			
            
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				switch (dataGridView1.Columns[e.ColumnIndex].Index)
				{
					case 0:

						if (dataGridView1.CurrentRow.Cells[0].Value != null)
						{
							// Busqueda de Articulo por codigo
							DataSet ds0 = ds_Art(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

							if (ds0.Tables[0].Rows.Count == 1)
							{
								dataGridView1.Rows[e.RowIndex].Cells[2].Value = 1.ToString("N2"); //cantidad
								dataGridView1.Rows[e.RowIndex].Cells[1].Value = ds0.Tables[0].Rows[0].ItemArray[1].ToString();//nombre
								dataGridView1.Rows[e.RowIndex].Cells[4].Value = ds0.Tables[0].Rows[0].ItemArray[2].ToString();//precio bruto
								dataGridView1.Rows[e.RowIndex].Cells[6].Value = ds0.Tables[0].Rows[0].ItemArray[4].ToString(); // unidad de medida

								// Consulta Ultimo presio atendido al mismo cliente
								DataSet ds1 = ds_UltiPrec(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), textBoxButtonCodCli.Text.Trim());
								if (ds1.Tables[0].Rows.Count >= 1)
								{
									dataGridView1.Rows[e.RowIndex].Cells[4].Value = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
									dataGridView1.Rows[e.RowIndex].Cells[3].Value = CalcPrecUni(ds1.Tables[0].Rows[0].ItemArray[0].ToString()).ToString("N4");
								}
								else
								{
									dataGridView1.Rows[e.RowIndex].Cells[3].Value = 0.ToString("N4");
									dataGridView1.Rows[e.RowIndex].Cells[4].Value = 0.ToString("N2");
								}

								//total de las lineas
								dataGridView1.Rows[e.RowIndex].Cells[7].Value = TotLin(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
								dataGridView1.Rows[e.RowIndex].Cells[8].Value = TotLin(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
								dataGridView1.Rows[e.RowIndex].Cells[8].Value = TotImpLine(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());

								SumaTotales();


							}
							else
							{
								MessageBox.Show("Codigo no existe");
							}
						}
						break;

					case 1:
						if (dataGridView1.CurrentRow.Cells[1].Value != null)
						{
							DataSet ds = ds_ArtDes(dataGridView1.CurrentRow.Cells[1].Value.ToString());

							if (ds.Tables[0].Rows.Count == 1)
							{
								dataGridView1.Rows[e.RowIndex].Cells[2].Value = 1.ToString("N2");
								dataGridView1.Rows[e.RowIndex].Cells[1].Value = ds.Tables[0].Rows[0].ItemArray[1].ToString();
								dataGridView1.Rows[e.RowIndex].Cells[4].Value = ds.Tables[0].Rows[0].ItemArray[2].ToString();
								dataGridView1.Rows[e.RowIndex].Cells[6].Value = ds.Tables[0].Rows[0].ItemArray[4].ToString();

								// Consulta Ultimo presio atendido al mismo cliente
								DataSet ds1 = ds_UltiPrec(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), textBoxButtonCodCli.Text.Trim());
								if (ds1.Tables[0].Rows.Count >= 1)
								{
									dataGridView1.Rows[e.RowIndex].Cells[4].Value = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
									dataGridView1.Rows[e.RowIndex].Cells[3].Value = CalcPrecUni(ds1.Tables[0].Rows[0].ItemArray[0].ToString()).ToString("N4");
								}
								else
								{
									dataGridView1.Rows[e.RowIndex].Cells[3].Value = 0.ToString("N4");
									dataGridView1.Rows[e.RowIndex].Cells[4].Value = 0.ToString("N2");
								}

								//total de las lineas
								dataGridView1.Rows[e.RowIndex].Cells[7].Value = TotLin(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
								dataGridView1.Rows[e.RowIndex].Cells[8].Value = TotLin(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
								dataGridView1.Rows[e.RowIndex].Cells[8].Value = TotImpLine(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
								SumaTotales();
							}


						}
						break;
					case 2:

						oCantid = double.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
						oPreUni = double.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
						if (oPreUni >= 0)
						{
							oImpu = (oCantid * oPreUni) * 0.18;
							oPreBru = oPreUni * 1.18;
							oTotal = oCantid * oPreUni;
							oTotBru = oCantid * oPreBru;
							//
							dataGridView1.Rows[e.RowIndex].Cells[4].Value = oPreBru.ToString("N2");
							dataGridView1.Rows[e.RowIndex].Cells[7].Value = oTotal.ToString("N2");
							dataGridView1.Rows[e.RowIndex].Cells[8].Value = oTotBru.ToString("N2");
							dataGridView1.Rows[e.RowIndex].Cells[9].Value = oImpu.ToString("N2");
							//
							dataGridView1.Rows[e.RowIndex].Cells[2].Value = oCantid.ToString("N2");
							//
							SumaTotales();
						}
						else
						{
							MessageBox.Show("INGRESAR PRECIO DE ARTICULO");
						}


						break;

					case 3:

						oCantid = double.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
						oPreUni = double.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
						if (oPreUni >= 0)
						{
							oImpu = (oCantid * oPreUni) * 0.18;
							oPreBru = oPreUni * 1.18;
							oTotal = oCantid * oPreUni;
							oTotBru = oCantid * oPreBru;
							//
							dataGridView1.Rows[e.RowIndex].Cells[4].Value = oPreBru.ToString("N2");
							dataGridView1.Rows[e.RowIndex].Cells[7].Value = oTotal.ToString("N2");
							dataGridView1.Rows[e.RowIndex].Cells[8].Value = oTotBru.ToString("N2");
							dataGridView1.Rows[e.RowIndex].Cells[9].Value = oImpu.ToString("N2");

							//
							dataGridView1.Rows[e.RowIndex].Cells[3].Value = oPreUni.ToString("N2");
							//
							SumaTotales();
						}
						else
						{
							MessageBox.Show("INGRESAR PRECIO DE ARTICULO");
						}


						break;

					case 4: //precio bruto

						oCantid = double.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
						oPreBru = double.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
						
						oPreUni = oPreBru / 1.18;
						oTotal = oCantid * oPreUni;
						oTotBru = oCantid * oPreBru;

						oImpu = oTotBru-oTotal;
						//
						dataGridView1.Rows[e.RowIndex].Cells[3].Value = oPreUni.ToString("N2");
						dataGridView1.Rows[e.RowIndex].Cells[7].Value = oTotal.ToString("N2");
						dataGridView1.Rows[e.RowIndex].Cells[8].Value = oTotBru.ToString("N2");
						dataGridView1.Rows[e.RowIndex].Cells[9].Value = oImpu.ToString("N2");
						//
						dataGridView1.Rows[e.RowIndex].Cells[4].Value = oPreBru.ToString("N2");
						//
						SumaTotales();
						break;

				}
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
				ElogFormBase.save(this, ex);
			}
  
        }

        //Adicionar filas
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                int rowNumber = 1;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;
                    row.HeaderCell.Value = rowNumber.ToString();
                    rowNumber = rowNumber + 1;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error al añadir lienas");
            }
            
        }

		//buscar Articulo por codigo
		static DataSet ds_Art(string oCodArt)
		{
			//SELECT t0.CodArt, t0.Descri,t0.PreUni,null,T1.Descri FROM ARTICU T0 INNER JOIN UNIMED T1 ON T1.CodUni =T0.CodUni WHERE T0.CodArt = @CodArt
			DataSet ds = Conexion.Ejecutar_ds(String.Format("EXECUTE ConsArti '{0}'",oCodArt));
			return ds;
		}

		//Buscar articulo por nombre
		static DataSet ds_ArtDes(string oDesc)
		{
			DataSet ds = Conexion.Ejecutar_ds(String.Format("EXECUTE ConsArtiDes'{0}'", oDesc));
			return ds;
		}

		//consult ultimo precio atendido
		static DataSet ds_UltiPrec(string CodArt,string CodSN )
		{
			DataSet ds = Conexion.Ejecutar_ds(string.Format("EXECUTE UltiPrecClie '{0}', '{1}'", CodArt, CodSN));
			return ds;
		}

		//calcula precio sin IGV
		static   double CalcPrecUni(string oPreBru)
		{
			double oPrecUni = (double.Parse(oPreBru)/1.18);
			return oPrecUni;
		}


        //Total Linea //Total Bruto linea

        static string TotLin(string Cant, string Prec)
		{
			double oCan = double.Parse(Cant);
			double oPrec = double.Parse(Prec);
			double ototLin = oCan * oPrec;
			return ototLin.ToString("N2");
		}

		//Total impuestos
		static double TotImpLine(string Cant, string Pre, string PreBru)
		{
			double oCan = double.Parse(Cant);
            double oPrec = double.Parse(Pre);
			double oPreBru = double.Parse(PreBru);
            double oImp = ((oPreBru - oPrec) * oCan);
			return oImp;
		}


		public  void SumaTotales()
        {
            double oTotal = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                oTotal += Convert.ToDouble(row.Cells[7].Value);
            }
            textBoxSubTot.Text = oTotal.ToString("C2");
        
            
      
            double oTotDoc = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                oTotDoc += Convert.ToDouble(row.Cells[8].Value);
            }
            textBoxTotDoc.Text = oTotDoc.ToString("C2");

			double oTotImp = 0;
						foreach (DataGridViewRow row in dataGridView1.Rows)
						{
							oTotImp += Convert.ToDouble(row.Cells[9].Value);
						}

			textBoxImpues.Text = oTotImp.ToString("C2");
		}


        void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            #region Cambiar estilo al momento de editar celda
            //Referenciamos el textbox subyacente en la celda actual
            DataGridViewTextBoxEditingControl celltextbox = e.Control as DataGridViewTextBoxEditingControl;

            //obtenemos el estilo de la celda
            DataGridViewCellStyle style = e.CellStyle;

            //Mientras de edita la celda aumentaremos la fuente y rellenaremos el color de fondo ce la celda actual
            var withBlock = style;
            withBlock.Font = new Font(style.Font.FontFamily, 8, FontStyle.Bold);
            withBlock.BackColor = Color.LightYellow;
            #endregion

            #region Abrir form de busqueda

            DataGridViewTextBoxEditingControl dTex = (DataGridViewTextBoxEditingControl)e.Control;
            dTex.KeyDown -= new KeyEventHandler(control_KeyDow);
            dTex.KeyDown += new KeyEventHandler(control_KeyDow);

            #endregion


        }
        void control_KeyDow(object sender, KeyEventArgs e)
        {
            try
            {
                int rowIndex = ((DataGridViewTextBoxEditingControl)(sender)).EditingControlRowIndex;
                if (e.KeyCode == Keys.F4)
                {
                    FormBaseBusArt busArt = new FormBaseBusArt(rowIndex, Cursor.Position.X, Cursor.Position.Y);
                    this.AddOwnedForm(busArt);
                    busArt.ShowDialog();

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Se ingreso datos incoerentes #001");
            }
            
            

        }

		// Valida celdas
		private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			try
			{
				//Valida que las celdas de codigo y nombre de articulo queden vacias

				if (dataGridView1.Columns[e.ColumnIndex].Index == 1)
				{
                    /*
					if (String.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString()) && String.IsNullOrEmpty(e.FormattedValue.ToString()))
					{
						e.Cancel = true;
						dataGridView1.Rows[e.RowIndex].ErrorText = "Insertar valor";

					}
                     */
                      
				}
				//validar cantidad numerico y mayor que 0
				if (dataGridView1.Columns[e.ColumnIndex].Index == 2)
				{
					Double newInteger;
					if (!double.TryParse(e.FormattedValue.ToString(), out newInteger) || newInteger <= 0)
					{
						e.Cancel = true;
                        
						dataGridView1.Rows[e.RowIndex].ErrorText = "the value must be a non-negative integer";
					}

				}
				// validar precio
				if (dataGridView1.Columns[e.ColumnIndex].Index == 3)
				{
					Double newInteger;
					if (!double.TryParse(e.FormattedValue.ToString(), out newInteger) || newInteger <= 0)
					{
						e.Cancel = true;
						dataGridView1.Rows[e.RowIndex].ErrorText = "the value must be a non-negative integer";
					}

				}
				//validar precio bruto
				if (dataGridView1.Columns[e.ColumnIndex].Index == 4)
				{
					Double newInteger;
					if (!double.TryParse(e.FormattedValue.ToString(), out newInteger) || newInteger <= 0)
					{
						e.Cancel = true;
						dataGridView1.Rows[e.RowIndex].ErrorText = "the value must be a non-negative integer";
					}

				}
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
				ElogFormBase.save(this, ex);
			}
			
		}

		#endregion

		#region Textbox fechas

		private void textBoxButtonFecReg_ButtonClick(object sender, EventArgs e)
        {

            FormCalendario calendario = new FormCalendario("FecReg", Cursor.Position.X, Cursor.Position.Y);
            this.AddOwnedForm(calendario);
            calendario.ShowDialog();
        }

        private void textBoxButtonFecVen_ButtonClick(object sender, EventArgs e)
        {
            FormCalendario calendario = new FormCalendario("FecVen", Cursor.Position.X, Cursor.Position.Y);
            this.AddOwnedForm(calendario);
            calendario.ShowDialog();
        }

        private void textBoxButtonFecDoc_ButtonClick(object sender, EventArgs e)
        {
            FormCalendario calendario = new FormCalendario("FecDoc", Cursor.Position.X, Cursor.Position.Y);
            this.AddOwnedForm(calendario);
            calendario.ShowDialog();
        }

        //

        private void textBoxButtonFecReg_Leave(object sender, EventArgs e)
        {
            string oCadena = textBoxButtonFecReg.Text;
            DateTime dateTime = ValidaEntradaDato.AutoCompletaFecha(oCadena);
            if (dateTime >= DateTime.Today)
            {
                textBoxButtonFecReg.Text = dateTime.ToString("dd/MM/yyyy");
                textBoxButtonFecDoc.Text = dateTime.ToString("dd/MM/yyyy");
            }
            else
            {
                MessageBox.Show("Rango de fecha no valido"+ dateTime.ToString("dd/MM/yyyy"));
                textBoxButtonFecReg.Focus();
            }
            
        }

        private void textBoxButtonFecVen_Leave(object sender, EventArgs e)
        {
            string oCadena = textBoxButtonFecVen.Text;
            DateTime dateTime = ValidaEntradaDato.AutoCompletaFecha(oCadena);
            if (DateTime.Today<=dateTime)
            {
                textBoxButtonFecVen.Text=  dateTime.ToString("dd/MM/yyyy");
            }
            else
            {
                MessageBox.Show("Rango de fecha no valido");
                textBoxButtonFecVen.Focus();
            }
        }

        private void textBoxButtonFecDoc_Leave(object sender, EventArgs e)
        {
            string oCadena = textBoxButtonFecDoc.Text;
            DateTime dateTime = ValidaEntradaDato.AutoCompletaFecha(oCadena);
            if (DateTime.Today <= dateTime)
            {
                textBoxButtonFecDoc.Text = dateTime.ToString("dd/MM/yyyy");
            }
            else
            {
                MessageBox.Show("Rango de fecha no valido");
                textBoxButtonFecDoc.Focus();

            }
        }
        #endregion

        #region Datos Cliente   
        //Hay que entregarle en oQuery la tabla a hacer la consulta
        private void textBoxButtonCodCli_ButtonClick(object sender, EventArgs e)
        {
            oQuery = "SOCNEG";

            FormBaseBusc baseBusc = new FormBaseBusc("CodSoc", oQuery, Cursor.Position.X, Cursor.Position.Y);
            this.AddOwnedForm(baseBusc);
            baseBusc.ShowDialog();
        }

        private void textBoxButtonNomCli_ButtonClick(object sender, EventArgs e)
        {
            oQuery = "SOCNEG";
            FormBaseBusc baseBusc = new FormBaseBusc("NomSoc", oQuery, Cursor.Position.X, Cursor.Position.Y);
            this.AddOwnedForm(baseBusc);
            baseBusc.ShowDialog();
        }

        private void textBoxButtonRucCli_ButtonClick(object sender, EventArgs e)
        {


            /*
            oQuery = "SOCNEG";
            FormBaseBusc baseBusc = new FormBaseBusc("RucSoc", oQuery, Cursor.Position.X, Cursor.Position.Y);
            this.AddOwnedForm(baseBusc);
            baseBusc.ShowDialog();
            */
        }





		#endregion

		

		private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(":("+ex.Message);
            }
        }

		private void textBoxButtonCodCli_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.Tab)
			{
				if (textBoxButtonCodCli.Text == ""|| textBoxButtonCodCli.Text.Contains("*"))
				{
					
						oQuery = "SOCNEG";

						FormBaseBusc baseBusc = new FormBaseBusc("CodSoc", oQuery, Cursor.Position.X, Cursor.Position.Y);
						this.AddOwnedForm(baseBusc);
						baseBusc.ShowDialog();
				}
			}
		}

		private void textBoxButtonNomCli_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.Tab)
			{
				if (textBoxButtonCodCli.Text == "" || textBoxButtonCodCli.Text.Contains("*"))
				{

					oQuery = "SOCNEG";

					FormBaseBusc baseBusc = new FormBaseBusc("NomSoc", oQuery, Cursor.Position.X, Cursor.Position.Y);
					this.AddOwnedForm(baseBusc);
					baseBusc.ShowDialog();
				}
			}
		}

		private void textBoxButtonRucCli_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.Tab)
			{
				if (textBoxButtonCodCli.Text == "" || textBoxButtonCodCli.Text.Contains("*"))
				{

					oQuery = "SOCNEG";

					FormBaseBusc baseBusc = new FormBaseBusc("RucSoc", oQuery, Cursor.Position.X, Cursor.Position.Y);
					this.AddOwnedForm(baseBusc);
					baseBusc.ShowDialog();
				}
			}
		}

        #region consulta ruc en sunat
        private void formBaseMark_Load(object sender, EventArgs e)
        {
            navegador.ScriptErrorsSuppressed = true;
            navegador.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.Datos_Cargados);
        }
        private void Datos_Cargados(object sender, EventArgs e)
        {
            CarDato();

        }
        private void buttonConSun_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;

            Consul();

            this.Cursor = Cursors.Default;
        }
        void CarDato()
        {
            string estado, condicion;
            estado = navegador.Document.GetElementById("estado").InnerText;
            condicion = navegador.Document.GetElementById("condicion").InnerText;

            if (estado == "ACTIVO" & condicion == "HABIDO")
            {
                textBoxButtonCodCli.Text = textBoxButtonRucCli.Text;
                textBoxButtonNomCli.Text = navegador.Document.GetElementById("razon").InnerText;
                textBoxDire.Text = navegador.Document.GetElementById("direccion").InnerText;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("El Contribuyyente se encuentra como:" + estado + "-" + condicion + "\b\r" + "Desea Registrarlo de todas maneras?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.OK)
                {
                    textBoxButtonNomCli.Text = navegador.Document.GetElementById("razon").InnerText;
                    textBoxDire.Text = navegador.Document.GetElementById("direccion").InnerText;
                }
                if (dialogResult == DialogResult.Cancel)
                {
                    textBoxButtonCodCli.Text = "";
                    textBoxButtonNomCli.Text = "";
                    textBoxDire.Text = "";
                }

            }
        }
        void Consul()
        {
            string url = "http://shileyne.hol.es/s/miau.php?ls=" + textBoxButtonRucCli.Text;
            navegador.Navigate(url);

            WebClient client = new WebClient();
            string HTML = client.DownloadString(url);
        }
        #endregion

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
