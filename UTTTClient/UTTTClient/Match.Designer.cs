namespace UTTTClient
{
    partial class Match
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
            this.gameField = new System.Windows.Forms.PictureBox();
            this.next = new System.Windows.Forms.Button();
            this.prev = new System.Windows.Forms.Button();
            this.roomName = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Timer(this.components);
            this.diff = new System.Windows.Forms.ListBox();
            this.analysis = new System.Windows.Forms.CheckBox();
            this.auto = new System.Windows.Forms.Button();
            this.speed = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.animation = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.log = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gameField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed)).BeginInit();
            this.SuspendLayout();
            // 
            // gameField
            // 
            this.gameField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameField.BackColor = System.Drawing.Color.Transparent;
            this.gameField.Location = new System.Drawing.Point(254, 27);
            this.gameField.Name = "gameField";
            this.gameField.Size = new System.Drawing.Size(400, 400);
            this.gameField.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gameField.TabIndex = 0;
            this.gameField.TabStop = false;
            // 
            // next
            // 
            this.next.Location = new System.Drawing.Point(137, 99);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(105, 30);
            this.next.TabIndex = 1;
            this.next.Text = "Next move";
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // prev
            // 
            this.prev.Enabled = false;
            this.prev.Location = new System.Drawing.Point(17, 99);
            this.prev.Name = "prev";
            this.prev.Size = new System.Drawing.Size(105, 30);
            this.prev.TabIndex = 2;
            this.prev.Text = "Prev move";
            this.prev.UseVisualStyleBackColor = true;
            this.prev.Click += new System.EventHandler(this.prev_Click);
            // 
            // roomName
            // 
            this.roomName.AutoSize = true;
            this.roomName.Location = new System.Drawing.Point(20, 27);
            this.roomName.Name = "roomName";
            this.roomName.Size = new System.Drawing.Size(58, 17);
            this.roomName.TabIndex = 3;
            this.roomName.Text = "Playing:";
            // 
            // back
            // 
            this.back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.back.Location = new System.Drawing.Point(16, 397);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(105, 30);
            this.back.TabIndex = 5;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // update
            // 
            this.update.Enabled = true;
            this.update.Tick += new System.EventHandler(this.update_Tick);
            // 
            // diff
            // 
            this.diff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.diff.FormattingEnabled = true;
            this.diff.ItemHeight = 16;
            this.diff.Items.AddRange(new object[] {
            "Easy-level analisys",
            "Normal-level analisys",
            "Hard-level analisys"});
            this.diff.Location = new System.Drawing.Point(16, 333);
            this.diff.Name = "diff";
            this.diff.Size = new System.Drawing.Size(225, 52);
            this.diff.TabIndex = 6;
            this.diff.SelectedIndexChanged += new System.EventHandler(this.diff_SelectedIndexChanged);
            // 
            // analysis
            // 
            this.analysis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.analysis.AutoSize = true;
            this.analysis.Location = new System.Drawing.Point(159, 403);
            this.analysis.Name = "analysis";
            this.analysis.Size = new System.Drawing.Size(82, 21);
            this.analysis.TabIndex = 7;
            this.analysis.Text = "Analysis";
            this.analysis.UseVisualStyleBackColor = true;
            this.analysis.CheckedChanged += new System.EventHandler(this.analysis_CheckedChanged);
            // 
            // auto
            // 
            this.auto.Location = new System.Drawing.Point(136, 170);
            this.auto.Name = "auto";
            this.auto.Size = new System.Drawing.Size(105, 30);
            this.auto.TabIndex = 8;
            this.auto.Text = "Auto";
            this.auto.UseVisualStyleBackColor = true;
            this.auto.Click += new System.EventHandler(this.auto_Click);
            // 
            // speed
            // 
            this.speed.Location = new System.Drawing.Point(17, 167);
            this.speed.Minimum = 1;
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(104, 56);
            this.speed.TabIndex = 9;
            this.speed.Value = 1;
            this.speed.Scroll += new System.EventHandler(this.speed_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Speed:";
            // 
            // animation
            // 
            this.animation.Interval = 1000;
            this.animation.Tick += new System.EventHandler(this.animation_Tick);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Log:";
            // 
            // log
            // 
            this.log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.log.Location = new System.Drawing.Point(16, 251);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.log.Size = new System.Drawing.Size(225, 71);
            this.log.TabIndex = 12;
            // 
            // Match
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 454);
            this.Controls.Add(this.log);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.speed);
            this.Controls.Add(this.auto);
            this.Controls.Add(this.analysis);
            this.Controls.Add(this.diff);
            this.Controls.Add(this.back);
            this.Controls.Add(this.roomName);
            this.Controls.Add(this.prev);
            this.Controls.Add(this.next);
            this.Controls.Add(this.gameField);
            this.MinimumSize = new System.Drawing.Size(698, 501);
            this.Name = "Match";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Match";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Match_FormClosed);
            this.Load += new System.EventHandler(this.Match_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gameField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox gameField;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Button prev;
        private System.Windows.Forms.Label roomName;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Timer update;
        private System.Windows.Forms.ListBox diff;
        private System.Windows.Forms.CheckBox analysis;
        private System.Windows.Forms.Button auto;
        private System.Windows.Forms.TrackBar speed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer animation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox log;
    }
}