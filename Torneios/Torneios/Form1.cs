﻿using System;
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

            if (char.IsLetter(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == (char)Keys.Space || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)8)
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

            foreach (TreeNode Pai in tvwProvas.Nodes)
            {
                if (Pai.ImageIndex == 0)
                    BiggerWins = false;
                else
                    BiggerWins = true;
                foreach (TreeNode Filho in Pai.Nodes)
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
                    else if (Filho == Second)
                    {
                        Filho.ImageIndex = 3;
                        Filho.SelectedImageIndex = 3;
                    }
                    else if (Filho == Third)
                    {
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

        public void UpdateColor()
        {
            int idx, idx2, bestMark, bestTotal = 0, idxPontos, idxPontosTotal;

            for (idx = 0; idx < lsvBoard.Items.Count; idx++)
                lsvBoard.Items[idx].Tag = 0;

            
            for (idx = 0; idx < lsvBoard.Items.Count; idx++)
            {

                bestMark = 0;
                if (lsvBoard.Items[idx].Tag.Equals(0))
                {
                    for (idx2 = idx; idx2 < lsvBoard.Items.Count; idx2++)
                    {

                        if (lsvBoard.Items[idx].SubItems[1].Text == lsvBoard.Items[idx2].SubItems[1].Text)
                        {
                            idxPontos = Convert.ToInt32(lsvBoard.Items[idx2].SubItems[3].Text);
                            idxPontosTotal = Convert.ToInt32(lsvBoard.Items[idx2].SubItems[4].Text);
                            if (idxPontos > bestMark)
                                bestMark = idxPontos;

                            if (idxPontosTotal > bestTotal)
                                bestTotal = idxPontosTotal;

                            lsvBoard.Items[idx2].Tag = 1;

                        }
                    }
                    for (idx2 = idx; idx2 < lsvBoard.Items.Count; idx2++) // Mudar a cor dos registos de provas com melhor marca na prova selecionada
                    {
                        idxPontos = Convert.ToInt32(lsvBoard.Items[idx2].SubItems[3].Text);
                        if (lsvBoard.Items[idx].SubItems[1].Text == lsvBoard.Items[idx2].SubItems[1].Text)
                        {
                            if (idxPontos == bestMark)
                            {
                                lsvBoard.Items[idx2].BackColor = Color.LightGreen;
                            }
                            else
                            {

                                lsvBoard.Items[idx2].BackColor = Color.White;
                            }
                        }
                    }
                }
            }

            for (idx = 0; idx < lsvBoard.Items.Count; idx++)
            {
                idxPontos = Convert.ToInt32(lsvBoard.Items[idx].SubItems[4].Text);
                if (idxPontos == bestTotal)
                {
                    lsvBoard.Items[idx].BackColor = Color.Gold;
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
            if (EntreAB(cbbProva.SelectedIndex, 0, 3) == 1) //Se estiver selecionada uma prova de tempo (está por ordem)
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
            int soma = 0;
            TreeNode provaNova = new TreeNode(),
                     pessoa = new TreeNode(),
                     prova = new TreeNode();


            if (IsInList() == 1)
            {
                MessageBox.Show("Esse Registo já existe!", "ERRO", MessageBoxButtons.OK);
                return;
            }
            if (EntreAB(cbbProva.SelectedIndex, 0, 3) == 1) //Se estiver selecionada uma prova de tempo (está por ordem)        
                pessoa.Tag = numTempo.Value;
            else
                pessoa.Tag = numDistancia.Value;


            pessoa.Text = txtNome.Text + " " + txtApelido.Text;


            if ((prova = ProcProva()) == null) //Se não for encontrada a modalidade selecionada
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
            soma = CalcPontos(cbbProva.SelectedIndex, P);
            lvsi.Text = Convert.ToString(soma);


            lvi.SubItems.Add(lvsi);

            //Somatório

            lvsi = new ListViewItem.ListViewSubItem();

            for (int idx = 0; idx < lsvBoard.Items.Count; idx++)
            {
                if (lsvBoard.Items[idx].Text == lvi.Text)
                {
                    soma += Convert.ToInt32(lsvBoard.Items[idx].SubItems[3].Text);
                }
            }
            lvsi.Text = soma.ToString();
            lvi.SubItems.Add(lvsi);

            lsvBoard.Items.Add(lvi);
            UpdateColor();

            //Reset dos campos
            txtNome.Text = "";
            txtApelido.Text = "";
            numDistancia.Value = 0;
            numTempo.Value = 0;
            txtNome.Focus();
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

    }
}
