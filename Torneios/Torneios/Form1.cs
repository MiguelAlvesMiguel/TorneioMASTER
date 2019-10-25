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
         TreeNode First, Second, Third;
         First = Second = Third = new TreeNode();
         double firstN, secondN, thirdN, FilhoN;
         int cnt1, cnt2, cnt3;

         cnt1 = cnt2 = cnt3 = 0;
         firstN = secondN = thirdN = FilhoN = 0;
      
         foreach (TreeNode Pai in tvwProvas.Nodes)
         {
            if (Pai.ImageIndex == 0)
               BiggerWins = false;
            else
               BiggerWins = true;

            First.Tag = Second.Tag = Third.Tag = -2;

            First = ReturnBigger();

            foreach (TreeNode Filho in Pai.Nodes)
            {

               if (BiggerWins == true)    //Num Distância
               {

                  firstN = Convert.ToDouble(First.Tag);
                  secondN = Convert.ToDouble(Second.Tag);
                  thirdN = Convert.ToDouble(Third.Tag);
                  FilhoN = Convert.ToDouble(Filho.Tag);

                  if (FilhoN >= firstN)   //PARA A MEDALHA DE OURO
                  {
                     if (FilhoN == firstN) //Se for igual fica também com OURO
                     {
                        Filho.ImageIndex = 2;
                        Filho.SelectedImageIndex = 2;
                        cnt1++;
                        if(cnt1>=3)
                        {
                           DownGrade(3);
                           DownGrade(4);
                        }
                        continue;
                     }
                     else     //Se for maior fica com ouro e quem tinha ouro fica com prata
                     {
                        DownGrade(2);

                        Filho.ImageIndex = 2;
                        Filho.SelectedImageIndex = 2;
                        cnt1++;

                        //e quem tinha ouro fica com prata

                        First = Filho;
                        firstN = Convert.ToDouble(First.Tag);
                        First.Tag = Convert.ToDouble(First.Tag);
                        continue;
                     }
                  }
                  if (FilhoN >= secondN && FilhoN < firstN && FilhoN > thirdN) //PARA E MEDALHA DE PRATA
                  {
                     if (cnt1 >= 3) //Se houver 3 ou mais medalhas de ouro mais ninguem ganha nada
                     {
                        Filho.ImageIndex = 5;
                        Filho.SelectedImageIndex = 5;
                        continue;
                     }


                     if (FilhoN == secondN)
                     {
                        if (cnt1 == 2) //Se houver 2 medalhas de ouro o segundo fica com o bronze
                        {
                           Filho.ImageIndex = 4;
                           Filho.SelectedImageIndex = 4;
                           continue;
                        }

                        //Se só houver 1 medalha de ouro fica com a prata
                        Filho.ImageIndex = 3;
                        Filho.SelectedImageIndex = 3;
                        cnt2++;
                        if ((cnt1 + cnt2) >= 3)                        
                           DownGrade(4);
                        
                           continue;
                     }
                     if (cnt1 == 2) //Se houver 2 medalhas de ouro o segundo fica com o bronze
                     {
                        DownGrade(4);
                        Filho.ImageIndex = 4;
                        Filho.SelectedImageIndex = 4;                      
                        continue;
                     }

                     DownGrade(3); //Downgrade em quem estava em segundo
                     Filho.ImageIndex = 3;
                     Filho.SelectedImageIndex = 3;
                     cnt2++;
                     

                     Second = Filho;
                     secondN = Convert.ToDouble(Second.Tag);
                     //thirdN = Convert.ToDouble(Third.Tag);

                     continue;
                  }

                  if (FilhoN > thirdN && FilhoN < secondN)  //PARA A MEDALHA DE BRONZE
                  {
                     if ((cnt1 + cnt2) >= 3)
                     {
                        Filho.ImageIndex = 5;
                        Filho.SelectedImageIndex = 5;
                        continue;
                     }
                     Filho.ImageIndex = 4;
                     Filho.SelectedImageIndex = 4;
                     Third = Filho;
                     thirdN = Convert.ToDouble(Third.Tag);
                  }

               }

               else //Se for de tempo mudar os sinais
               {

                  firstN = Convert.ToDouble(First.Tag);
                  secondN = Convert.ToDouble(Second.Tag);
                  thirdN = Convert.ToDouble(Third.Tag);
                  FilhoN = Convert.ToDouble(Filho.Tag);

                  if (FilhoN <= firstN)   //PARA A MEDALHA DE OURO
                  {
                     if (FilhoN == firstN) //Se for igual fica também com OURO
                     {
                        Filho.ImageIndex = 2;
                        Filho.SelectedImageIndex = 2;
                        cnt1++;
                        if (cnt1 >= 3)
                        {
                           DownGrade(3);
                           DownGrade(4);
                        }
                        continue;
                     }
                     else     //Se for maior fica com ouro e quem tinha ouro fica com prata
                     {
                        DownGrade(2);

                        Filho.ImageIndex = 2;
                        Filho.SelectedImageIndex = 2;
                        cnt1++;

                        //e quem tinha ouro fica com prata

                        First = Filho;
                        firstN = Convert.ToDouble(First.Tag);
                        First.Tag = Convert.ToDouble(First.Tag);
                        continue;
                     }
                  }
                  if (FilhoN <= secondN && FilhoN > firstN && FilhoN < thirdN) //PARA E MEDALHA DE PRATA
                  {
                     if (cnt1 >= 3) //Se houver 3 ou mais medalhas de ouro mais ninguem ganha nada
                     {
                        Filho.ImageIndex = 5;
                        Filho.SelectedImageIndex = 5;
                        continue;
                     }


                     if (FilhoN == secondN)
                     {
                        if (cnt1 == 2) //Se houver 2 medalhas de ouro o segundo fica com o bronze
                        {
                           Filho.ImageIndex = 4;
                           Filho.SelectedImageIndex = 4;
                           continue;
                        }

                        //Se só houver 1 medalha de ouro fica com a prata
                        Filho.ImageIndex = 3;
                        Filho.SelectedImageIndex = 3;
                        cnt2++;
                        if ((cnt1 + cnt2) >= 3)
                           DownGrade(4);

                        continue;
                     }
                     if (cnt1 == 2) //Se houver 2 medalhas de ouro o segundo fica com o bronze
                     {
                        DownGrade(4);
                        Filho.ImageIndex = 4;
                        Filho.SelectedImageIndex = 4;
                        continue;
                     }

                     DownGrade(3); //Downgrade em quem estava em segundo
                     Filho.ImageIndex = 3;
                     Filho.SelectedImageIndex = 3;
                     cnt2++;


                     Second = Filho;
                     secondN = Convert.ToDouble(Second.Tag);
                     //thirdN = Convert.ToDouble(Third.Tag);

                     continue;
                  }

                  if (FilhoN < thirdN && FilhoN > secondN)  //PARA A MEDALHA DE BRONZE
                  {
                     if ((cnt1 + cnt2) >= 3)
                     {
                        Filho.ImageIndex = 5;
                        Filho.SelectedImageIndex = 5;
                        continue;
                     }
                     Filho.ImageIndex = 4;
                     Filho.SelectedImageIndex = 4;
                     Third = Filho;
                     thirdN = Convert.ToDouble(Third.Tag);
                  }

               }

            }

         }

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
      public int CalcPontos(int idxProva, double P)
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
            if (idxProva <= 3)
               return (int)(A * Math.Pow(B - P, C));
            else
               return (int)(A * Math.Pow(P - B, C));
         }
      }
      public void DownGrade(int PastIndex)
      {
         foreach (TreeNode Parent in tvwProvas.Nodes)
            if (Parent.Text == cbbProva.SelectedItem.ToString())
               foreach (TreeNode Child in Parent.Nodes)
                  if (Child.ImageIndex == PastIndex)
                  {
                     Child.ImageIndex++;
                     Child.SelectedImageIndex++;
                  }
      }
      public TreeNode ReturnBigger()
      {
         TreeNode maior = new TreeNode();
         if (EntreAB(cbbProva.SelectedIndex, 0, 3) == 1) //Se for de tempo
            maior.Tag = 1000;
         else
            maior.Tag = -2;

         foreach (TreeNode Parent in tvwProvas.Nodes)
            if (Parent.Text == cbbProva.SelectedItem.ToString())
               foreach (TreeNode Child in Parent.Nodes)             
                  if ((Convert.ToDouble(Child.Tag)) > (Convert.ToDouble(maior.Tag)))
                  maior = Child;

         return maior;
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
                  tempo -= min * 60;
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
      private void tvwProvas_AfterSelect(object sender, TreeViewEventArgs e)
      {

      }
   }
}
