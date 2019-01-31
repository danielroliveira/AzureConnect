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
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLiberar = new System.Windows.Forms.Button();
            this.vPanel1 = new VIBlend.WinForms.Controls.vPanel();
            this.lblIP = new System.Windows.Forms.Label();
            this.cmbFilial = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCommand = new System.Windows.Forms.Label();
            this.vPanel1.Content.SuspendLayout();
            this.vPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Meu IP Atual";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.ForeColor = System.Drawing.Color.DarkRed;
            this.btnClose.Location = new System.Drawing.Point(184, 256);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 44);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Fechar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLiberar
            // 
            this.btnLiberar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLiberar.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnLiberar.Location = new System.Drawing.Point(23, 256);
            this.btnLiberar.Name = "btnLiberar";
            this.btnLiberar.Size = new System.Drawing.Size(154, 44);
            this.btnLiberar.TabIndex = 2;
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
            this.vPanel1.Content.Name = "Content";
            this.vPanel1.Content.Size = new System.Drawing.Size(265, 39);
            this.vPanel1.Content.TabIndex = 3;
            this.vPanel1.CustomScrollersIntersectionColor = System.Drawing.Color.Empty;
            this.vPanel1.Location = new System.Drawing.Point(23, 42);
            this.vPanel1.Name = "vPanel1";
            this.vPanel1.Opacity = 1F;
            this.vPanel1.PanelBorderColor = System.Drawing.Color.Transparent;
            this.vPanel1.Size = new System.Drawing.Size(267, 41);
            this.vPanel1.TabIndex = 3;
            this.vPanel1.Text = "vPanel1";
            this.vPanel1.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // lblIP
            // 
            this.lblIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIP.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIP.Location = new System.Drawing.Point(0, 0);
            this.lblIP.Name = "lblIP";
            this.lblIP.Padding = new System.Windows.Forms.Padding(6);
            this.lblIP.Size = new System.Drawing.Size(265, 39);
            this.lblIP.TabIndex = 0;
            this.lblIP.Text = "label2";
            this.lblIP.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbFilial
            // 
            this.cmbFilial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilial.FormattingEnabled = true;
            this.cmbFilial.Location = new System.Drawing.Point(23, 127);
            this.cmbFilial.Name = "cmbFilial";
            this.cmbFilial.Size = new System.Drawing.Size(154, 26);
            this.cmbFilial.TabIndex = 4;
            this.cmbFilial.SelectedIndexChanged += new System.EventHandler(this.cmbFilial_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Escolha a Filial:";
            // 
            // lblCommand
            // 
            this.lblCommand.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommand.Location = new System.Drawing.Point(29, 169);
            this.lblCommand.Name = "lblCommand";
            this.lblCommand.Size = new System.Drawing.Size(260, 67);
            this.lblCommand.TabIndex = 6;
            this.lblCommand.Text = "label3";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 310);
            this.Controls.Add(this.lblCommand);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFilial);
            this.Controls.Add(this.vPanel1);
            this.Controls.Add(this.btnLiberar);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liberar Porta no Azure";
            this.Shown += new System.EventHandler(this.frmPrincipal_Shown);
            this.vPanel1.Content.ResumeLayout(false);
            this.vPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnLiberar;
        private VIBlend.WinForms.Controls.vPanel vPanel1;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.ComboBox cmbFilial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCommand;
    }
}

