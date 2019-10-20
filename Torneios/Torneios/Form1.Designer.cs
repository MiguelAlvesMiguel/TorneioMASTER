﻿namespace Torneios
{
   partial class Form1
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.txtNome = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.txtApelido = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.cbbProva = new System.Windows.Forms.ComboBox();
         this.numDistancia = new System.Windows.Forms.NumericUpDown();
         this.numTempo = new System.Windows.Forms.NumericUpDown();
         this.btnClassificação = new System.Windows.Forms.Button();
         this.btnInserir = new System.Windows.Forms.Button();
         this.btnEliminar = new System.Windows.Forms.Button();
         this.grbVista = new System.Windows.Forms.GroupBox();
         this.rdbÍcones = new System.Windows.Forms.RadioButton();
         this.rdbDetalhes = new System.Windows.Forms.RadioButton();
         this.tvwProvas = new System.Windows.Forms.TreeView();
         this.lsvBoard = new System.Windows.Forms.ListView();
         this.Atleta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.Prova = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.Marca = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.Pontos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.Somatório = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.btnFechar = new System.Windows.Forms.Button();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.numDistancia)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numTempo)).BeginInit();
         this.grbVista.SuspendLayout();
         this.SuspendLayout();
         // 
         // txtNome
         // 
         this.txtNome.Location = new System.Drawing.Point(27, 31);
         this.txtNome.Name = "txtNome";
         this.txtNome.Size = new System.Drawing.Size(229, 20);
         this.txtNome.TabIndex = 0;
         this.txtNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNome_KeyPress);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(27, 13);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(46, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "Nome(s)";
         // 
         // txtApelido
         // 
         this.txtApelido.Location = new System.Drawing.Point(27, 83);
         this.txtApelido.Name = "txtApelido";
         this.txtApelido.Size = new System.Drawing.Size(229, 20);
         this.txtApelido.TabIndex = 0;
         this.txtApelido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApelido_KeyPress);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(27, 65);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(53, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "Apelido(s)";
         // 
         // cbbProva
         // 
         this.cbbProva.Anchor = System.Windows.Forms.AnchorStyles.Top;
         this.cbbProva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cbbProva.FormattingEnabled = true;
         this.cbbProva.Items.AddRange(new object[] {
            " Corrida 100 Metros",
            "Salto em Comprimento",
            "Lançamento Do Peso",
            "Salto em Altura",
            "Corrida 400 Metros",
            "Corrida 110 metros Barreiras",
            "Lançamento do Disco",
            "Salto com Vara",
            "Lançamento do Dardo",
            "Corrida 1500 Metros"});
         this.cbbProva.Location = new System.Drawing.Point(279, 30);
         this.cbbProva.Name = "cbbProva";
         this.cbbProva.Size = new System.Drawing.Size(193, 21);
         this.cbbProva.TabIndex = 2;
         // 
         // numDistancia
         // 
         this.numDistancia.Anchor = System.Windows.Forms.AnchorStyles.Top;
         this.numDistancia.DecimalPlaces = 2;
         this.numDistancia.Location = new System.Drawing.Point(279, 82);
         this.numDistancia.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
         this.numDistancia.Name = "numDistancia";
         this.numDistancia.ReadOnly = true;
         this.numDistancia.Size = new System.Drawing.Size(74, 20);
         this.numDistancia.TabIndex = 3;
         this.numDistancia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // numTempo
         // 
         this.numTempo.Anchor = System.Windows.Forms.AnchorStyles.Top;
         this.numTempo.DecimalPlaces = 2;
         this.numTempo.Location = new System.Drawing.Point(366, 82);
         this.numTempo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
         this.numTempo.Name = "numTempo";
         this.numTempo.ReadOnly = true;
         this.numTempo.Size = new System.Drawing.Size(106, 20);
         this.numTempo.TabIndex = 3;
         this.numTempo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // btnClassificação
         // 
         this.btnClassificação.Anchor = System.Windows.Forms.AnchorStyles.Top;
         this.btnClassificação.Location = new System.Drawing.Point(478, 28);
         this.btnClassificação.Name = "btnClassificação";
         this.btnClassificação.Size = new System.Drawing.Size(106, 23);
         this.btnClassificação.TabIndex = 4;
         this.btnClassificação.Text = "Classificação";
         this.btnClassificação.UseVisualStyleBackColor = true;
         // 
         // btnInserir
         // 
         this.btnInserir.Anchor = System.Windows.Forms.AnchorStyles.Top;
         this.btnInserir.Enabled = false;
         this.btnInserir.Location = new System.Drawing.Point(605, 28);
         this.btnInserir.Name = "btnInserir";
         this.btnInserir.Size = new System.Drawing.Size(86, 23);
         this.btnInserir.TabIndex = 4;
         this.btnInserir.Text = "Inserir";
         this.btnInserir.UseVisualStyleBackColor = true;
         // 
         // btnEliminar
         // 
         this.btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.Top;
         this.btnEliminar.Enabled = false;
         this.btnEliminar.Location = new System.Drawing.Point(605, 76);
         this.btnEliminar.Name = "btnEliminar";
         this.btnEliminar.Size = new System.Drawing.Size(86, 23);
         this.btnEliminar.TabIndex = 4;
         this.btnEliminar.Text = "Eliminar";
         this.btnEliminar.UseVisualStyleBackColor = true;
         // 
         // grbVista
         // 
         this.grbVista.Anchor = System.Windows.Forms.AnchorStyles.Top;
         this.grbVista.Controls.Add(this.rdbÍcones);
         this.grbVista.Controls.Add(this.rdbDetalhes);
         this.grbVista.Location = new System.Drawing.Point(707, 28);
         this.grbVista.Name = "grbVista";
         this.grbVista.Size = new System.Drawing.Size(125, 75);
         this.grbVista.TabIndex = 5;
         this.grbVista.TabStop = false;
         this.grbVista.Text = "Vista";
         // 
         // rdbÍcones
         // 
         this.rdbÍcones.AutoSize = true;
         this.rdbÍcones.Location = new System.Drawing.Point(18, 42);
         this.rdbÍcones.Name = "rdbÍcones";
         this.rdbÍcones.Size = new System.Drawing.Size(57, 17);
         this.rdbÍcones.TabIndex = 0;
         this.rdbÍcones.Text = "Ícones";
         this.rdbÍcones.UseVisualStyleBackColor = true;
         // 
         // rdbDetalhes
         // 
         this.rdbDetalhes.AutoSize = true;
         this.rdbDetalhes.Checked = true;
         this.rdbDetalhes.Location = new System.Drawing.Point(18, 19);
         this.rdbDetalhes.Name = "rdbDetalhes";
         this.rdbDetalhes.Size = new System.Drawing.Size(67, 17);
         this.rdbDetalhes.TabIndex = 0;
         this.rdbDetalhes.TabStop = true;
         this.rdbDetalhes.Text = "Detalhes";
         this.rdbDetalhes.UseVisualStyleBackColor = true;
         // 
         // tvwProvas
         // 
         this.tvwProvas.Location = new System.Drawing.Point(27, 132);
         this.tvwProvas.Name = "tvwProvas";
         this.tvwProvas.Size = new System.Drawing.Size(229, 322);
         this.tvwProvas.TabIndex = 6;
         // 
         // lsvBoard
         // 
         this.lsvBoard.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Atleta,
            this.Prova,
            this.Marca,
            this.Pontos,
            this.Somatório});
         this.lsvBoard.Location = new System.Drawing.Point(279, 132);
         this.lsvBoard.Name = "lsvBoard";
         this.lsvBoard.Size = new System.Drawing.Size(550, 322);
         this.lsvBoard.TabIndex = 7;
         this.lsvBoard.UseCompatibleStateImageBehavior = false;
         this.lsvBoard.View = System.Windows.Forms.View.Details;
         // 
         // Atleta
         // 
         this.Atleta.Text = "Atleta";
         this.Atleta.Width = 174;
         // 
         // Prova
         // 
         this.Prova.Text = "Prova";
         this.Prova.Width = 106;
         // 
         // Marca
         // 
         this.Marca.Text = "Marca";
         this.Marca.Width = 92;
         // 
         // Pontos
         // 
         this.Pontos.Text = "Pontos";
         this.Pontos.Width = 93;
         // 
         // Somatório
         // 
         this.Somatório.Text = "Somatório";
         this.Somatório.Width = 81;
         // 
         // btnFechar
         // 
         this.btnFechar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
         this.btnFechar.Location = new System.Drawing.Point(366, 464);
         this.btnFechar.Name = "btnFechar";
         this.btnFechar.Size = new System.Drawing.Size(106, 23);
         this.btnFechar.TabIndex = 4;
         this.btnFechar.Text = "Fechar";
         this.btnFechar.UseVisualStyleBackColor = true;
         // 
         // label3
         // 
         this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(276, 13);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(35, 13);
         this.label3.TabIndex = 1;
         this.label3.Text = "Prova";
         // 
         // label4
         // 
         this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(276, 65);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(51, 13);
         this.label4.TabIndex = 1;
         this.label4.Text = "Distância";
         // 
         // label5
         // 
         this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(363, 65);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(40, 13);
         this.label5.TabIndex = 1;
         this.label5.Text = "Tempo";
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(841, 499);
         this.Controls.Add(this.lsvBoard);
         this.Controls.Add(this.tvwProvas);
         this.Controls.Add(this.grbVista);
         this.Controls.Add(this.btnEliminar);
         this.Controls.Add(this.btnInserir);
         this.Controls.Add(this.btnFechar);
         this.Controls.Add(this.btnClassificação);
         this.Controls.Add(this.numTempo);
         this.Controls.Add(this.numDistancia);
         this.Controls.Add(this.cbbProva);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.txtApelido);
         this.Controls.Add(this.txtNome);
         this.Name = "Form1";
         this.Text = "Teste";
         ((System.ComponentModel.ISupportInitialize)(this.numDistancia)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numTempo)).EndInit();
         this.grbVista.ResumeLayout(false);
         this.grbVista.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox txtNome;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox txtApelido;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.ComboBox cbbProva;
      private System.Windows.Forms.NumericUpDown numDistancia;
      private System.Windows.Forms.NumericUpDown numTempo;
      private System.Windows.Forms.Button btnClassificação;
      private System.Windows.Forms.Button btnInserir;
      private System.Windows.Forms.Button btnEliminar;
      private System.Windows.Forms.GroupBox grbVista;
      private System.Windows.Forms.RadioButton rdbÍcones;
      private System.Windows.Forms.RadioButton rdbDetalhes;
      private System.Windows.Forms.TreeView tvwProvas;
      private System.Windows.Forms.ListView lsvBoard;
      private System.Windows.Forms.ColumnHeader Atleta;
      private System.Windows.Forms.ColumnHeader Prova;
      private System.Windows.Forms.ColumnHeader Marca;
      private System.Windows.Forms.ColumnHeader Pontos;
      private System.Windows.Forms.ColumnHeader Somatório;
      private System.Windows.Forms.Button btnFechar;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
   }
}

