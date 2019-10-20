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

         if (char.IsLetter(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == (char)Keys.Space)
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
         if(EntreAB(cbbProva.SelectedIndex,0,3) == 1) //Se estiver selecionada uma prova de tempo (está por ordem)
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
      }
   }
}
