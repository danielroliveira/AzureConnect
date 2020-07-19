namespace AzureConnect
{
	partial class frmPrincipal
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
			this.components = new System.ComponentModel.Container();
			this.lblConta = new System.Windows.Forms.Label();
			this.mnuConexao = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuItemConectar = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuItemDesconectar = new System.Windows.Forms.ToolStripMenuItem();
			this.btnFechar = new System.Windows.Forms.Button();
			this.btnLiberar = new System.Windows.Forms.Button();
			this.vPanel1 = new VIBlend.WinForms.Controls.vPanel();
			this.lblIP = new System.Windows.Forms.Label();
			this.cmbFilial = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lblCommand = new System.Windows.Forms.Label();
			this.txtGrupo = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtServer = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.mnuConexao.SuspendLayout();
			this.vPanel1.Content.SuspendLayout();
			this.vPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(89, 0);
			this.lblTitulo.Size = new System.Drawing.Size(192, 50);
			this.lblTitulo.Text = "Azure IP Connect";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(281, 0);
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// panel1
			// 
			this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel1.Size = new System.Drawing.Size(321, 50);
			// 
			// lblConta
			// 
			this.lblConta.ContextMenuStrip = this.mnuConexao;
			this.lblConta.Location = new System.Drawing.Point(25, 70);
			this.lblConta.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.lblConta.Name = "lblConta";
			this.lblConta.Size = new System.Drawing.Size(268, 18);
			this.lblConta.TabIndex = 0;
			this.lblConta.Text = "Conta Azure Conectada";
			this.lblConta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// mnuConexao
			// 
			this.mnuConexao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuConexao.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemConectar,
            this.mnuItemDesconectar});
			this.mnuConexao.Name = "mnuConexao";
			this.mnuConexao.Size = new System.Drawing.Size(249, 64);
			// 
			// mnuItemConectar
			// 
			this.mnuItemConectar.Image = global::AzureConnect.Properties.Resources.accept_24;
			this.mnuItemConectar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuItemConectar.Name = "mnuItemConectar";
			this.mnuItemConectar.Size = new System.Drawing.Size(248, 30);
			this.mnuItemConectar.Text = "Conectar a conta Azure";
			this.mnuItemConectar.Click += new System.EventHandler(this.Conectar_Click);
			// 
			// mnuItemDesconectar
			// 
			this.mnuItemDesconectar.Image = global::AzureConnect.Properties.Resources.block_24;
			this.mnuItemDesconectar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuItemDesconectar.Name = "mnuItemDesconectar";
			this.mnuItemDesconectar.Size = new System.Drawing.Size(248, 30);
			this.mnuItemDesconectar.Text = "Desconectar da Conta";
			this.mnuItemDesconectar.Click += new System.EventHandler(this.Desconectar_Click);
			// 
			// btnFechar
			// 
			this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnFechar.ForeColor = System.Drawing.Color.DarkRed;
			this.btnFechar.Location = new System.Drawing.Point(187, 455);
			this.btnFechar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnFechar.Name = "btnFechar";
			this.btnFechar.Size = new System.Drawing.Size(106, 44);
			this.btnFechar.TabIndex = 9;
			this.btnFechar.Text = "&Fechar";
			this.btnFechar.UseVisualStyleBackColor = true;
			this.btnFechar.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnLiberar
			// 
			this.btnLiberar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnLiberar.ForeColor = System.Drawing.Color.MidnightBlue;
			this.btnLiberar.Location = new System.Drawing.Point(25, 455);
			this.btnLiberar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnLiberar.Name = "btnLiberar";
			this.btnLiberar.Size = new System.Drawing.Size(154, 44);
			this.btnLiberar.TabIndex = 8;
			this.btnLiberar.Text = "&Liberar Porta";
			this.btnLiberar.UseVisualStyleBackColor = true;
			this.btnLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
			// 
			// vPanel1
			// 
			this.vPanel1.AllowAnimations = true;
			this.vPanel1.BackColor = System.Drawing.Color.White;
			this.vPanel1.BorderRadius = 0;
			// 
			// vPanel1.Content
			// 
			this.vPanel1.Content.AutoScroll = true;
			this.vPanel1.Content.BackColor = System.Drawing.Color.White;
			this.vPanel1.Content.Controls.Add(this.lblIP);
			this.vPanel1.Content.Location = new System.Drawing.Point(1, 1);
			this.vPanel1.Content.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.vPanel1.Content.Name = "Content";
			this.vPanel1.Content.Size = new System.Drawing.Size(266, 39);
			this.vPanel1.Content.TabIndex = 3;
			this.vPanel1.CustomScrollersIntersectionColor = System.Drawing.Color.Empty;
			this.vPanel1.Location = new System.Drawing.Point(25, 102);
			this.vPanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.vPanel1.Name = "vPanel1";
			this.vPanel1.Opacity = 1F;
			this.vPanel1.PanelBorderColor = System.Drawing.Color.Transparent;
			this.vPanel1.Size = new System.Drawing.Size(268, 41);
			this.vPanel1.TabIndex = 3;
			this.vPanel1.Text = "vPanel1";
			this.vPanel1.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			// 
			// lblIP
			// 
			this.lblIP.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblIP.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblIP.Location = new System.Drawing.Point(0, 0);
			this.lblIP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblIP.Name = "lblIP";
			this.lblIP.Padding = new System.Windows.Forms.Padding(2, 6, 2, 6);
			this.lblIP.Size = new System.Drawing.Size(266, 39);
			this.lblIP.TabIndex = 0;
			this.lblIP.Text = "label2";
			this.lblIP.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// cmbFilial
			// 
			this.cmbFilial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFilial.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbFilial.FormattingEnabled = true;
			this.cmbFilial.Location = new System.Drawing.Point(68, 187);
			this.cmbFilial.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.cmbFilial.Name = "cmbFilial";
			this.cmbFilial.Size = new System.Drawing.Size(183, 26);
			this.cmbFilial.TabIndex = 2;
			this.cmbFilial.SelectedIndexChanged += new System.EventHandler(this.cmbFilial_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(85, 163);
			this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(146, 18);
			this.label2.TabIndex = 1;
			this.label2.Text = "Escolha a Regra:";
			// 
			// lblCommand
			// 
			this.lblCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblCommand.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCommand.Location = new System.Drawing.Point(28, 378);
			this.lblCommand.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblCommand.Name = "lblCommand";
			this.lblCommand.Size = new System.Drawing.Size(260, 67);
			this.lblCommand.TabIndex = 7;
			this.lblCommand.Text = "Texto do Commando Azure CLI";
			this.lblCommand.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lblCommand.DoubleClick += new System.EventHandler(this.lblCommand_Click);
			// 
			// txtGrupo
			// 
			this.txtGrupo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtGrupo.Location = new System.Drawing.Point(68, 252);
			this.txtGrupo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.txtGrupo.Name = "txtGrupo";
			this.txtGrupo.ReadOnly = true;
			this.txtGrupo.Size = new System.Drawing.Size(183, 27);
			this.txtGrupo.TabIndex = 4;
			this.txtGrupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(128, 227);
			this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 18);
			this.label3.TabIndex = 3;
			this.label3.Text = "Grupo:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(125, 290);
			this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(66, 18);
			this.label4.TabIndex = 5;
			this.label4.Text = "Server:";
			// 
			// txtServer
			// 
			this.txtServer.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtServer.Location = new System.Drawing.Point(68, 314);
			this.txtServer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.txtServer.Name = "txtServer";
			this.txtServer.ReadOnly = true;
			this.txtServer.Size = new System.Drawing.Size(183, 27);
			this.txtServer.TabIndex = 6;
			this.txtServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(112, 354);
			this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "Comando:";
			// 
			// frmPrincipal
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(321, 511);
			this.Controls.Add(this.txtServer);
			this.Controls.Add(this.txtGrupo);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lblCommand);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cmbFilial);
			this.Controls.Add(this.vPanel1);
			this.Controls.Add(this.btnLiberar);
			this.Controls.Add(this.btnFechar);
			this.Controls.Add(this.lblConta);
			this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.Name = "frmPrincipal";
			this.ShowInTaskbar = true;
			this.Text = "Liberar IP no Azure";
			this.Shown += new System.EventHandler(this.frmPrincipal_Shown);
			this.Controls.SetChildIndex(this.lblConta, 0);
			this.Controls.SetChildIndex(this.btnFechar, 0);
			this.Controls.SetChildIndex(this.btnLiberar, 0);
			this.Controls.SetChildIndex(this.vPanel1, 0);
			this.Controls.SetChildIndex(this.cmbFilial, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.lblCommand, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.txtGrupo, 0);
			this.Controls.SetChildIndex(this.txtServer, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.panel1.ResumeLayout(false);
			this.mnuConexao.ResumeLayout(false);
			this.vPanel1.Content.ResumeLayout(false);
			this.vPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label lblConta;
		private System.Windows.Forms.Button btnFechar;
		private System.Windows.Forms.Button btnLiberar;
		private VIBlend.WinForms.Controls.vPanel vPanel1;
		private System.Windows.Forms.Label lblIP;
		private System.Windows.Forms.ComboBox cmbFilial;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblCommand;
		private System.Windows.Forms.TextBox txtGrupo;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtServer;
		private System.Windows.Forms.ContextMenuStrip mnuConexao;
		private System.Windows.Forms.ToolStripMenuItem mnuItemConectar;
		private System.Windows.Forms.ToolStripMenuItem mnuItemDesconectar;
		private System.Windows.Forms.Label label1;
	}
}

