using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hotel2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmb_n1.SelectedItem == null || cmb_n2.SelectedItem == null)
            {
                MessageBox.Show("è sbagliato,riprova");
                return;
            }
            else
            {
                int Ngiorni;
                string stanze = cmb_n1.Text, stagioni = cmb_n2.Text;
                bool parcheggio = chk_n1.Checked;
                double costogiornaliero = 0, sconto1 = 0.75, sconto2 = 0.65, costostanza = 0;

                if (!int.TryParse(txt_n1.Text, out Ngiorni) || Ngiorni <= 0)
                {
                    MessageBox.Show("inserisci un numero valido)(maggiore di 0).", "input non valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                

                if(stanze == "base")
                {
                    if(stagioni =="Bassa Stagione")
                    {
                        costogiornaliero = 15;
                    }
                    else if(stagioni =="media stagione")
                    {
                        costogiornaliero = 20;
                    }
                    else if(stagioni == "alta stagione")
                    {
                        costogiornaliero = 25;
                    }
                }
                else if(stanze == "media")
                {
                    if(stagioni =="bassa stagione")
                    {
                        costogiornaliero = 30;
                    }
                    else if (stagioni == "media stagione")
                    {
                        costogiornaliero = 35;
                    }
                    else if (stagioni == "alta stagione")
                    {
                        costogiornaliero = 40;
                    }
                }
                else if (stanze == "alta")
                {
                    if (stagioni == "bassa stagione")
                    {
                        costogiornaliero = 45;
                    }
                    else if (stagioni == "media stagione")
                    {
                        costogiornaliero = 50;
                    }
                    else if (stagioni == "alta stagione")
                    {
                        costogiornaliero = 55;
                    }
                }
                if(Ngiorni<=2)
                {
                    costostanza = Ngiorni * costogiornaliero;
                }
                else if(Ngiorni <= 7)
                {
                    double primi2giorni = 2 * costogiornaliero;
                    double giornirimasti = (Ngiorni - 2) * (costogiornaliero * sconto1);
                    costostanza = primi2giorni + giornirimasti;
                }
                else
                {
                    double primi2giorni = 2 * costogiornaliero;
                    double successivi5giorni = 5 * (costogiornaliero * sconto1);
                    double oltre7giorni = (primi2giorni - 7) * (costogiornaliero * sconto2);
                    costostanza = primi2giorni + successivi5giorni + oltre7giorni;
                }


            }
    }
}
