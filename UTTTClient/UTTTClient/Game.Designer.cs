namespace UTTTClient
{
    partial class Game
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
            this.send = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.TextBox();
            this.chat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gameField = new System.Windows.Forms.PictureBox();
            this.turn = new System.Windows.Forms.Label();
            this.leave = new System.Windows.Forms.Button();
            this.time = new System.Windows.Forms.Label();
            this.accept = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Timer(this.components);
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gameField)).BeginInit();
            this.SuspendLayout();
            // 
            // send
            // 
            this.send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.send.Location = new System.Drawing.Point(173, 413);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(83, 28);
            this.send.TabIndex = 0;
            this.send.Text = "Send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // message
            // 
            this.message.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.message.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.message.Location = new System.Drawing.Point(12, 413);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(155, 27);
            this.message.TabIndex = 1;
            // 
            // chat
            // 
            this.chat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chat.BackColor = System.Drawing.SystemColors.Window;
            this.chat.Location = new System.Drawing.Point(12, 175);
            this.chat.Multiline = true;
            this.chat.Name = "chat";
            this.chat.ReadOnly = true;
            this.chat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chat.Size = new System.Drawing.Size(244, 232);
            this.chat.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chat:";
            // 
            // gameField
            // 
            this.gameField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameField.Location = new System.Drawing.Point(268, 42);
            this.gameField.Name = "gameField";
            this.gameField.Size = new System.Drawing.Size(400, 400);
            this.gameField.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gameField.TabIndex = 6;
            this.gameField.TabStop = false;
            this.gameField.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gameField_MouseClick);
            // 
            // turn
            // 
            this.turn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.turn.AutoSize = true;
            this.turn.Location = new System.Drawing.Point(265, 13);
            this.turn.Name = "turn";
            this.turn.Size = new System.Drawing.Size(38, 17);
            this.turn.TabIndex = 7;
            this.turn.Text = "Turn";
            // 
            // leave
            // 
            this.leave.Location = new System.Drawing.Point(143, 98);
            this.leave.Name = "leave";
            this.leave.Size = new System.Drawing.Size(113, 31);
            this.leave.TabIndex = 8;
            this.leave.Text = "Leave room";
            this.leave.UseVisualStyleBackColor = true;
            this.leave.Click += new System.EventHandler(this.leave_Click);
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Location = new System.Drawing.Point(14, 13);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(43, 17);
            this.time.TabIndex = 9;
            this.time.Text = "Time:";
            // 
            // accept
            // 
            this.accept.Enabled = false;
            this.accept.Location = new System.Drawing.Point(12, 98);
            this.accept.Name = "accept";
            this.accept.Size = new System.Drawing.Size(110, 31);
            this.accept.TabIndex = 10;
            this.accept.Text = "Accept game";
            this.accept.UseVisualStyleBackColor = true;
            this.accept.Click += new System.EventHandler(this.accept_Click);
            // 
            // update
            // 
            this.update.Enabled = true;
            this.update.Interval = 300;
            this.update.Tick += new System.EventHandler(this.Update_Tick);
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 50;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 454);
            this.Controls.Add(this.accept);
            this.Controls.Add(this.time);
            this.Controls.Add(this.leave);
            this.Controls.Add(this.turn);
            this.Controls.Add(this.gameField);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chat);
            this.Controls.Add(this.message);
            this.Controls.Add(this.send);
            this.MinimumSize = new System.Drawing.Size(698, 501);
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Game";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Game_FormClosed);
            this.Load += new System.EventHandler(this.Game_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gameField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button send;
        private System.Windows.Forms.TextBox message;
        private System.Windows.Forms.TextBox chat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox gameField;
        private System.Windows.Forms.Label turn;
        private System.Windows.Forms.Button leave;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Button accept;
        private System.Windows.Forms.Timer update;
        private System.Windows.Forms.Timer gameTimer;
    }
}