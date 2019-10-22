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
       public void ValBtnInserir()
      {
         if (txtNome.Text != "" && txtApelido.Text != "")  //Se as textbox's tiverem as 2 preenchidas
            if (numDistancia.ReadOnly == false || numTempo.ReadOnly == false)
            {
               btnInserir.Enabled = true;
               return;
            }
         btnInserir.Enabled = false;        
      }
       public int IsInList()
      {
         foreach (TreeNode Parent in tvwProvas.Nodes)
            if (Parent.Text == cbbProva.SelectedItem.ToString())
               foreach (TreeNode Child in Parent.Nodes)
                  if (Child.Text == (txtNome.Text + " " + txtApelido.Text))
                     return 1;

         return 0;
      }
       public TreeNode ProcProva()
      {
         foreach (TreeNode Parent in tvwProvas.Nodes)         
            if (Parent.Text == cbbProva.SelectedItem.ToString())
               return Parent;
         
         return null;
      }
       public void GetClassifications()
      {
         bool BiggerWins;
         TreeNode First,Second,Third;
         First = Second = Third = new TreeNode();
         double firstN, secondN, thirdN,FilhoN ;
        
         foreach (TreeNode Pai in tvwProvas.Nodes)
         {
            if (Pai.ImageIndex == 0)
               BiggerWins = false;
            else
               BiggerWins = true;
            foreach(TreeNode Filho in Pai.Nodes)
            {
               if (BiggerWins == true)
               {
                  First.Tag = Second.Tag = Third.Tag = -2;

                  firstN = Convert.ToDouble(First.Tag);
                  secondN = Convert.ToDouble(Second.Tag);
                  thirdN = Convert.ToDouble(Third.Tag);
                  FilhoN = Convert.ToDouble(Filho.Tag);


                  if (FilhoN > firstN)
                  {
                     Second = First;
                     First = Filho;
                     firstN = Convert.ToDouble(First.Tag);
                     secondN = Convert.ToDouble(Second.Tag);
                  }
                  if (FilhoN > secondN && FilhoN < firstN)
                  {
                     Third = Second;
                     Second = Filho;
                     secondN = Convert.ToDouble(Second.Tag);
                     thirdN = Convert.ToDouble(Third.Tag);
                  }

                  if (FilhoN > thirdN && FilhoN < secondN)
                  { 
                     Third = Filho;
                     thirdN = Convert.ToDouble(Third.Tag);
                   }

            }
                  else
               {

                  First.Tag = Second.Tag = Third.Tag = 1000;

                  firstN = Convert.ToDouble(First.Tag);
                  secondN = Convert.ToDouble(Second.Tag);
                  thirdN = Convert.ToDouble(Third.Tag);
                  FilhoN = Convert.ToDouble(Filho.Tag);


                  if (FilhoN < firstN)    //MUDAR OS SINAIS AQUI
                  {
                     Second = First;
                     First = Filho;
                     firstN = Convert.ToDouble(First.Tag);
                     secondN = Convert.ToDouble(Second.Tag);
                  }
                  if (FilhoN < secondN && FilhoN > firstN)
                  {
                     Third = Second;
                     Second = Filho;
                     secondN = Convert.ToDouble(Second.Tag);
                     thirdN = Convert.ToDouble(Third.Tag);
                  }

                  if (FilhoN < thirdN && FilhoN > secondN)
                  {
                     Third = Filho;
                     thirdN = Convert.ToDouble(Third.Tag);
                  }
               }

            }
            //Atribuir Medalhas (Imagens)   //2 , 3 , 4 e 5
            foreach (TreeNode Filho in Pai.Nodes)
               if (Filho == First)
               {
                  Filho.ImageIndex = 2;
                  Filho.SelectedImageIndex = 2;
                     }
               else if (Filho == Second) { 
                  Filho.ImageIndex = 3;
                  Filho.SelectedImageIndex = 3;
                     }
               else if (Filho == Third) { 
                  Filho.ImageIndex = 4;
                  Filho.SelectedImageIndex = 4;
                     }
               else
               { 
                  Filho.ImageIndex = 5;
                  Filho.SelectedImageIndex = 5;
                     }
         
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
            ValBtnInserir(); 
      }


      private void txtNome_TextChanged(object sender, EventArgs e)
      {
         ValBtnInserir();
      }

      private void txtApelido_TextChanged(object sender, EventArgs e)
      {
         ValBtnInserir();
      }

      private void cbbProva_SelectedValueChanged(object sender, EventArgs e)
      {
         ValBtnInserir();
      }

      private void btnInserir_Click(object sender, EventArgs e)
      {
         TreeNode provaNova = new TreeNode(),
                  pessoa = new TreeNode(),
                  prova = new TreeNode();
                  

         if (IsInList()==1)
         {
            MessageBox.Show("Esse Registo já existe!", "ERRO",MessageBoxButtons.OK);
            return;
         }
         if (EntreAB(cbbProva.SelectedIndex, 0, 3) == 1) //Se estiver selecionada uma prova de tempo (está por ordem)        
            pessoa.Tag = numTempo.Value;
         else
            pessoa.Tag = numDistancia.Value;


            pessoa.Text = txtNome.Text + " " + txtApelido.Text;
         

         if( (prova = ProcProva() ) == null ) //Se não for encontrada a modalidade selecionada
         {
            provaNova.Text = cbbProva.SelectedItem.ToString();

            if (EntreAB(cbbProva.SelectedIndex, 0, 3) == 1) //Se estiver selecionada uma prova de tempo (está por ordem)        
            {
               provaNova.ImageIndex = 0;
               provaNova.SelectedImageIndex = 0;
            }
            else
            {
               provaNova.ImageIndex = 1;
               provaNova.SelectedImageIndex = 1;
            }
            tvwProvas.Nodes.Add(provaNova);
            provaNova.Nodes.Add(pessoa);
         }
         else         
            prova.Nodes.Add(pessoa);

         GetClassifications();
      }

      private void tvwProvas_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
      {
         
            var node = sender as TreeNode;   // O node que deu origem ao evento como TreeNode

            if (e.Node.Nodes.Count > 0)
               return;
            else
            {
               e.Node.ToolTipText = e.Node.Tag.ToString();
               toolTipScore.Show(e.Node.Tag.ToString(), tvwProvas);
            }
         
      }

      private void lsvBoard_SelectedIndexChanged(object sender, EventArgs e)
      {

      }
   }
}
