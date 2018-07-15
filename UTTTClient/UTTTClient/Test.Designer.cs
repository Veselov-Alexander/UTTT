namespace UTTTClient
{
    partial class Test
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
            this.field = new System.Windows.Forms.PictureBox();
            this.update = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.field)).BeginInit();
            this.SuspendLayout();
            // 
            // field
            // 
            this.field.Location = new System.Drawing.Point(22, 24);
            this.field.Name = "field";
            this.field.Size = new System.Drawing.Size(400, 400);
            this.field.TabIndex = 0;
            this.field.TabStop = false;
            this.field.MouseClick += new System.Windows.Forms.MouseEventHandler(this.field_MouseClick);
            // 
            // update
            // 
            this.update.Enabled = true;
            this.update.Tick += new System.EventHandler(this.Update_Tick);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(454, 454);
            this.Controls.Add(this.field);
            this.Name = "Test";
            this.Text = "Test";
            this.Load += new System.EventHandler(this.Test_Load);
            ((System.ComponentModel.ISupportInitialize)(this.field)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox field;
        private System.Windows.Forms.Timer update;
    }
}