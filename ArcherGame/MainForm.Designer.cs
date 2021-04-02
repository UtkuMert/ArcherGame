namespace ArcherGame
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.archerPanel = new System.Windows.Forms.Panel();
            this.puanLabel = new System.Windows.Forms.Label();
            this.ballonPanel = new System.Windows.Forms.Panel();
            this.sureLabel = new System.Windows.Forms.Label();
            this.infoLabel = new System.Windows.Forms.Label();
            this.archerPanel.SuspendLayout();
            this.ballonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // archerPanel
            // 
            this.archerPanel.BackColor = System.Drawing.SystemColors.HighlightText;
            this.archerPanel.Controls.Add(this.puanLabel);
            this.archerPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.archerPanel.Location = new System.Drawing.Point(0, 0);
            this.archerPanel.Name = "archerPanel";
            this.archerPanel.Size = new System.Drawing.Size(102, 453);
            this.archerPanel.TabIndex = 0;
            // 
            // puanLabel
            // 
            this.puanLabel.AutoSize = true;
            this.puanLabel.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.puanLabel.Location = new System.Drawing.Point(12, 9);
            this.puanLabel.Name = "puanLabel";
            this.puanLabel.Size = new System.Drawing.Size(45, 16);
            this.puanLabel.TabIndex = 1;
            this.puanLabel.Text = "PUAN";
            // 
            // ballonPanel
            // 
            this.ballonPanel.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ballonPanel.Controls.Add(this.infoLabel);
            this.ballonPanel.Controls.Add(this.sureLabel);
            this.ballonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ballonPanel.Location = new System.Drawing.Point(102, 0);
            this.ballonPanel.Name = "ballonPanel";
            this.ballonPanel.Size = new System.Drawing.Size(737, 453);
            this.ballonPanel.TabIndex = 1;
            // 
            // sureLabel
            // 
            this.sureLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sureLabel.Font = new System.Drawing.Font("TeamViewer15", 10.5F, System.Drawing.FontStyle.Bold);
            this.sureLabel.Location = new System.Drawing.Point(661, 9);
            this.sureLabel.Name = "sureLabel";
            this.sureLabel.Size = new System.Drawing.Size(64, 37);
            this.sureLabel.TabIndex = 0;
            this.sureLabel.Text = "0:00";
            this.sureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(138, 113);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(442, 182);
            this.infoLabel.TabIndex = 1;
            this.infoLabel.Text = resources.GetString("infoLabel.Text");
            this.infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 453);
            this.Controls.Add(this.ballonPanel);
            this.Controls.Add(this.archerPanel);
            this.Name = "MainForm";
            this.Text = "Archer Game";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.archerPanel.ResumeLayout(false);
            this.archerPanel.PerformLayout();
            this.ballonPanel.ResumeLayout(false);
            this.ballonPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel archerPanel;
        private System.Windows.Forms.Panel ballonPanel;
        private System.Windows.Forms.Label sureLabel;
        private System.Windows.Forms.Label puanLabel;
        private System.Windows.Forms.Label infoLabel;
    }
}

