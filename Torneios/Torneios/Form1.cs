using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Torneios
{
   public partial class Form1 : Form
   {
      public Form1()
      {
         InitializeComponent();
      }

      //Inicio das funções
       public bool TextBoxVal(KeyPressEventArgs e)
      {
         bool handled;

         if (char.IsLetter(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == (char)Keys.Space || e.KeyChar == (char) Keys.Delete || e.KeyChar == (char) 8)
            handled = false;
         else
            handled = true;

         return handled;
      }
       public int EntreAB(int x, int min, int max)
      {
         if (x < min || x > max)
            return 0;
         else
            return 1;
      }
       public void ValInserir()
      {
         if (txtNome.Text != "" && txtApelido.Text != "")  //Se as textbox's tiverem as 2 preenchidas
            if (numDistancia.ReadOnly == false || numTempo.ReadOnly == false)
            {
               btnInserir.Enabled = true;
               return;
            }
         btnInserir.Enabled = false;        
      }
       
        public int TipoProva()
        {
            if (cbbProva.Text.IndexOf("Corrida") != -1)
            {
                return 0;
            }

            if (cbbProva.Text.IndexOf("Salto") != -1)
            {
                return 1;
            }

            if (cbbProva.Text.IndexOf("Lançamento") != -1)
            {
                return 2;
            }
            return -1;
        }

        public int CalcPontos (int idxProva, double P)
        {
            double A = 0, B = 0, C = 0;

            switch (idxProva)
            {
                case 0: //Corrida 100m
                    A = 25.4347;
                    B = 18;
                    C = 1.81;

                    break;
                case 1: //Corrida 400m
                    A = 1.53775;
                    B = 82;
                    C = 1.81;

                    break;
                case 2: //Corrida 1500m
                    A = 0.03768;
                    B = 480;
                    C = 1.85;

                    break;
                case 3: //Corrida 110m barreiras
                    A = 5.74352;
                    B = 28.5;
                    C = 1.92;

                    break;
                case 4: //Salto em Comprimento
                    A = 0.14354;
                    B = 220;
                    C = 1.4;
                    P *= 100;
                    break;
                case 5: //Lançamento do peso
                    A = 51.39;
                    B = 1.5;
                    C = 1.05;

                    break;
                case 6: //Salto em Altura 
                    A = 0.8465;
                    B = 75;
                    C = 1.42;
                    P *= 100;
                    break;
                case 7: //Lançamento do disco
                    A = 12.91;
                    B = 4;
                    C = 1.1;

                    break;
                case 8: //Salto com Vara
                    A = 0.2797;
                    B = 100;
                    C = 1.35;
                    P *= 100;
                    break;
                case 9: //Lançamento do dardo
                    A = 10.14;
                    B = 7;
                    C = 1.08;

                    break;
            }
            if (P == -1)
                return 0;
            else
            {
                if (idxProva <=3 )
                    return (int)(A * Math.Pow(B - P, C));
                else
                    return (int)(A * Math.Pow(P - B, C));
            }
        }
      //Fim das Funções

      private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
      { 
         e.Handled = TextBoxVal(e);
      }
      private void txtApelido_KeyPress(object sender, KeyPressEventArgs e)
      {
         e.Handled = TextBoxVal(e);
      }
      private void cbbProva_SelectedIndexChanged(object sender, EventArgs e)
      {       
         if (EntreAB(cbbProva.SelectedIndex,0,3) == 1) //Se estiver selecionada uma prova de tempo (está por ordem)
         {
            numTempo.ReadOnly = false;
            numDistancia.Value = 0;
            numDistancia.ReadOnly = true;       
         }
         else
         { 
            numDistancia.ReadOnly = false;
            numTempo.Value = 0;
            numTempo.ReadOnly = true;
         }
            ValInserir(); 
      }

      private void txtNome_TextChanged(object sender, EventArgs e)
      {
         ValInserir();
      }

      private void txtApelido_TextChanged(object sender, EventArgs e)
      {
         ValInserir();
      }

      private void cbbProva_SelectedValueChanged(object sender, EventArgs e)
      {
         ValInserir();
      }

        private void BtnInserir_Click(object sender, EventArgs e)
        {

            // 4. Inserir na list view

            //Atleta
            ListViewItem lvi = new ListViewItem();

            lvi.Text = txtNome.Text + ' ' + txtApelido.Text;

            //Prova
            ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem();

            lvsi.Text = cbbProva.Text;
            lvi.SubItems.Add(lvsi);

            //Marca
            lvsi = new ListViewItem.ListViewSubItem();

            switch (TipoProva())
            {
                case 0:
                    double tempo = Convert.ToDouble(numTempo.Value);
                    if (tempo >= 60)
                    {
                        int min = (int)tempo / 60;
                        tempo -= min*60;
                        lvsi.Text = min.ToString() + ':';
                    }
                    lvsi.Text += tempo.ToString() + " s";
                    break;
                case 1:
                case 2:
                    lvsi.Text = numDistancia.Value.ToString() + " m";
                    break;
                default:
                    break;
            }

            if (lvsi.Text.Equals("-1 s") == true)
            lvsi.Text = "Inválido";

            lvi.SubItems.Add(lvsi);

            //Pontos
            lvsi = new ListViewItem.ListViewSubItem();

            double P;
            if (TipoProva() == 0)
            {
                P = (double)numTempo.Value;
            }
            else
            {
                P = (double)numDistancia.Value;
            }
            lvsi.Text = Convert.ToString(CalcPontos(cbbProva.SelectedIndex, P));
           
            lvi.SubItems.Add(lvsi);

            //Somatório

            lsvBoard.Items.Add(lvi);
         }
    }
}
