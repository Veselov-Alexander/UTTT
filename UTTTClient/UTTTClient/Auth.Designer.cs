namespace UTTTClient
{
    partial class Auth
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
            this.loginField = new System.Windows.Forms.TextBox();
            this.LogIn = new System.Windows.Forms.Button();
            this.SignIn = new System.Windows.Forms.Button();
            this.passwordField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.connectionStatus = new System.Windows.Forms.Label();
            this.update = new System.Windows.Forms.Timer(this.components);
            this.offline = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginField
            // 
            this.loginField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.loginField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginField.Location = new System.Drawing.Point(105, 61);
            this.loginField.Name = "loginField";
            this.loginField.Size = new System.Drawing.Size(154, 27);
            this.loginField.TabIndex = 0;
            this.loginField.Text = "Alexander";
            // 
            // LogIn
            // 
            this.LogIn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LogIn.Enabled = false;
            this.LogIn.Location = new System.Drawing.Point(277, 60);
            this.LogIn.Name = "LogIn";
            this.LogIn.Size = new System.Drawing.Size(80, 30);
            this.LogIn.TabIndex = 1;
            this.LogIn.Text = "LogIn";
            this.LogIn.UseVisualStyleBackColor = true;
            this.LogIn.Click += new System.EventHandler(this.LogIn_Click);
            // 
            // SignIn
            // 
            this.SignIn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SignIn.Enabled = false;
            this.SignIn.Location = new System.Drawing.Point(277, 100);
            this.SignIn.Name = "SignIn";
            this.SignIn.Size = new System.Drawing.Size(80, 30);
            this.SignIn.TabIndex = 2;
            this.SignIn.Text = "SignIn";
            this.SignIn.UseVisualStyleBackColor = true;
            this.SignIn.Click += new System.EventHandler(this.SignIn_Click);
            // 
            // passwordField
            // 
            this.passwordField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordField.Location = new System.Drawing.Point(105, 101);
            this.passwordField.Name = "passwordField";
            this.passwordField.PasswordChar = '*';
            this.passwordField.Size = new System.Drawing.Size(154, 27);
            this.passwordField.TabIndex = 3;
            this.passwordField.Text = "228322";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Login:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password:";
            // 
            // connectionStatus
            // 
            this.connectionStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.connectionStatus.AutoSize = true;
            this.connectionStatus.Location = new System.Drawing.Point(26, 175);
            this.connectionStatus.Name = "connectionStatus";
            this.connectionStatus.Size = new System.Drawing.Size(152, 17);
            this.connectionStatus.TabIndex = 6;
            this.connectionStatus.Text = "Status: server is offline";
            // 
            // update
            // 
            this.update.Enabled = true;
            this.update.Interval = 300;
            this.update.Tick += new System.EventHandler(this.Update_Tick);
            // 
            // offline
            // 
            this.offline.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.offline.Location = new System.Drawing.Point(203, 167);
            this.offline.Name = "offline";
            this.offline.Size = new System.Drawing.Size(154, 30);
            this.offline.TabIndex = 7;
            this.offline.Text = "Play offline";
            this.offline.UseVisualStyleBackColor = true;
            this.offline.Click += new System.EventHandler(this.offline_Click);
            // 
            // Auth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 215);
            this.Controls.Add(this.offline);
            this.Controls.Add(this.connectionStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordField);
            this.Controls.Add(this.SignIn);
            this.Controls.Add(this.LogIn);
            this.Controls.Add(this.loginField);
            this.MinimumSize = new System.Drawing.Size(398, 262);
            this.Name = "Auth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auth";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Auth_FormClosing);
            this.Load += new System.EventHandler(this.Auth_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loginField;
        private System.Windows.Forms.Button LogIn;
        private System.Windows.Forms.Button SignIn;
        private System.Windows.Forms.TextBox passwordField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label connectionStatus;
        private System.Windows.Forms.Timer update;
        private System.Windows.Forms.Button offline;
    }
}