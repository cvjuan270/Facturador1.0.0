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
    public partial class FormCalendario : Form
    {
       
        //
        string oTipFec;
        public FormCalendario(string TipFec,int x, int y)
        {
            InitializeComponent();
            oTipFec = TipFec;
            this.StartPosition = FormStartPosition.Manual;
            this.DesktopLocation = new Point(x, y);
            
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            
            switch (oTipFec)
            {
                
                case "FecReg":
                    formBaseMark formBase = Owner as formBaseMark;
                    formBase.textBoxButtonFecReg.Text = monthCalendar1.SelectionStart.ToString("dd/MM/yyyy");
                    break;
                case "FecVen":
                    formBaseMark formBase1 = Owner as formBaseMark;
                    formBase1.textBoxButtonFecVen.Text = monthCalendar1.SelectionStart.ToString("dd/MM/yyyy");
                    break;
                case "FecDoc":
                    formBaseMark formBase2 = Owner as formBaseMark;
                    formBase2.textBoxButtonFecDoc.Text = monthCalendar1.SelectionStart.ToString("dd/MM/yyyy");
                    break;
            }
             // Form1 form1 = Owner as Form1;
             //form1.textBoxButton1.Text = monthCalendar1.SelectionStart.ToString("dd/MM/yyyy");

        }






    }
}
