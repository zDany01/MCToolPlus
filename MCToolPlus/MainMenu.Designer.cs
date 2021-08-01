
namespace MCToolPlus
{
    partial class MainMenu
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.WorldManagerBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WorldManagerBtn
            // 
            this.WorldManagerBtn.Location = new System.Drawing.Point(70, 12);
            this.WorldManagerBtn.Name = "WorldManagerBtn";
            this.WorldManagerBtn.Size = new System.Drawing.Size(114, 39);
            this.WorldManagerBtn.TabIndex = 1;
            this.WorldManagerBtn.Text = "World Manager";
            this.WorldManagerBtn.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 62);
            this.Controls.Add(this.WorldManagerBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.Text = "Minecraft Tools";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button WorldManagerBtn;
    }
}

