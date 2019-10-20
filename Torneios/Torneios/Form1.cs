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

      //Fim das Funções

      private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
      { 
         e.Handled = TextBoxVal(e);
      }
      private void txtApelido_KeyPress(object sender, KeyPressEventArgs e)
      {
         e.Handled = TextBoxVal(e);
      }
   }
}
