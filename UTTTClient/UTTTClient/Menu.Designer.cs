namespace UTTTClient
{
    partial class Menu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabs = new System.Windows.Forms.TabControl();
            this.rooms = new System.Windows.Forms.TabPage();
            this.login = new System.Windows.Forms.Label();
            this.mmr = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ranked = new System.Windows.Forms.CheckBox();
            this.matchTime = new System.Windows.Forms.TrackBar();
            this.roomsList = new System.Windows.Forms.ListView();
            this.player = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.state = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.create = new System.Windows.Forms.Button();
            this.connect = new System.Windows.Forms.Button();
            this.practice = new System.Windows.Forms.TabPage();
            this.botField = new System.Windows.Forms.PictureBox();
            this.diff = new System.Windows.Forms.ListBox();
            this.analysis = new System.Windows.Forms.CheckBox();
            this.gameState = new System.Windows.Forms.Label();
            this.firstMove = new System.Windows.Forms.CheckBox();
            this.hardBot = new System.Windows.Forms.Button();
            this.normalBot = new System.Windows.Forms.Button();
            this.easyBot = new System.Windows.Forms.Button();
            this.leaderboard = new System.Windows.Forms.TabPage();
            this.leaderboardList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.matchHistory = new System.Windows.Forms.TabPage();
            this.watch = new System.Windows.Forms.Button();
            this.matchesList = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.achievements = new System.Windows.Forms.TabPage();
            this.achievementsList = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.update = new System.Windows.Forms.Timer(this.components);
            this.botTimer = new System.Windows.Forms.Timer(this.components);
            this.unmake = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.rooms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matchTime)).BeginInit();
            this.practice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.botField)).BeginInit();
            this.leaderboard.SuspendLayout();
            this.matchHistory.SuspendLayout();
            this.achievements.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.rooms);
            this.tabs.Controls.Add(this.practice);
            this.tabs.Controls.Add(this.leaderboard);
            this.tabs.Controls.Add(this.matchHistory);
            this.tabs.Controls.Add(this.achievements);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.ItemSize = new System.Drawing.Size(135, 30);
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Multiline = true;
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(680, 454);
            this.tabs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabs.TabIndex = 2;
            this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabs.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabs_Selecting);
            // 
            // rooms
            // 
            this.rooms.Controls.Add(this.login);
            this.rooms.Controls.Add(this.mmr);
            this.rooms.Controls.Add(this.label1);
            this.rooms.Controls.Add(this.ranked);
            this.rooms.Controls.Add(this.matchTime);
            this.rooms.Controls.Add(this.roomsList);
            this.rooms.Controls.Add(this.create);
            this.rooms.Controls.Add(this.connect);
            this.rooms.Location = new System.Drawing.Point(4, 34);
            this.rooms.Name = "rooms";
            this.rooms.Padding = new System.Windows.Forms.Padding(3);
            this.rooms.Size = new System.Drawing.Size(672, 416);
            this.rooms.TabIndex = 0;
            this.rooms.Text = "Rooms";
            this.rooms.UseVisualStyleBackColor = true;
            // 
            // login
            // 
            this.login.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.login.AutoSize = true;
            this.login.Location = new System.Drawing.Point(513, 17);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(47, 17);
            this.login.TabIndex = 8;
            this.login.Text = "Login:";
            // 
            // mmr
            // 
            this.mmr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mmr.AutoSize = true;
            this.mmr.Location = new System.Drawing.Point(513, 46);
            this.mmr.Name = "mmr";
            this.mmr.Size = new System.Drawing.Size(78, 17);
            this.mmr.TabIndex = 7;
            this.mmr.Text = "Your rank: ";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(513, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "1 min                 60 min\r\n";
            // 
            // ranked
            // 
            this.ranked.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ranked.AutoSize = true;
            this.ranked.Location = new System.Drawing.Point(510, 297);
            this.ranked.Name = "ranked";
            this.ranked.Size = new System.Drawing.Size(113, 21);
            this.ranked.TabIndex = 4;
            this.ranked.Text = "ranked game";
            this.ranked.UseVisualStyleBackColor = true;
            // 
            // matchTime
            // 
            this.matchTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.matchTime.Location = new System.Drawing.Point(510, 352);
            this.matchTime.Maximum = 60;
            this.matchTime.Minimum = 1;
            this.matchTime.Name = "matchTime";
            this.matchTime.Size = new System.Drawing.Size(154, 56);
            this.matchTime.TabIndex = 3;
            this.matchTime.Value = 15;
            // 
            // roomsList
            // 
            this.roomsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roomsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.player,
            this.rank,
            this.time,
            this.type,
            this.state});
            this.roomsList.FullRowSelect = true;
            this.roomsList.Location = new System.Drawing.Point(8, 6);
            this.roomsList.MultiSelect = false;
            this.roomsList.Name = "roomsList";
            this.roomsList.Size = new System.Drawing.Size(496, 402);
            this.roomsList.TabIndex = 2;
            this.roomsList.UseCompatibleStateImageBehavior = false;
            this.roomsList.View = System.Windows.Forms.View.Details;
            // 
            // player
            // 
            this.player.Text = "Player";
            this.player.Width = 113;
            // 
            // rank
            // 
            this.rank.Text = "Rank";
            this.rank.Width = 72;
            // 
            // time
            // 
            this.time.Text = "Match time";
            this.time.Width = 103;
            // 
            // type
            // 
            this.type.Text = "Game type";
            this.type.Width = 104;
            // 
            // state
            // 
            this.state.Text = "Game state";
            this.state.Width = 100;
            // 
            // create
            // 
            this.create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.create.Location = new System.Drawing.Point(508, 243);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(156, 32);
            this.create.TabIndex = 1;
            this.create.Text = "Create room";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // connect
            // 
            this.connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.connect.Location = new System.Drawing.Point(508, 205);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(156, 32);
            this.connect.TabIndex = 0;
            this.connect.Text = "Connect to room";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // practice
            // 
            this.practice.Controls.Add(this.unmake);
            this.practice.Controls.Add(this.botField);
            this.practice.Controls.Add(this.diff);
            this.practice.Controls.Add(this.analysis);
            this.practice.Controls.Add(this.gameState);
            this.practice.Controls.Add(this.firstMove);
            this.practice.Controls.Add(this.hardBot);
            this.practice.Controls.Add(this.normalBot);
            this.practice.Controls.Add(this.easyBot);
            this.practice.Location = new System.Drawing.Point(4, 34);
            this.practice.Name = "practice";
            this.practice.Size = new System.Drawing.Size(672, 416);
            this.practice.TabIndex = 4;
            this.practice.Text = "Practice";
            this.practice.UseVisualStyleBackColor = true;
            // 
            // botField
            // 
            this.botField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.botField.BackColor = System.Drawing.Color.Transparent;
            this.botField.Location = new System.Drawing.Point(264, 10);
            this.botField.Name = "botField";
            this.botField.Size = new System.Drawing.Size(400, 400);
            this.botField.TabIndex = 3;
            this.botField.TabStop = false;
            this.botField.MouseClick += new System.Windows.Forms.MouseEventHandler(this.botField_MouseClick);
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
            this.diff.Location = new System.Drawing.Point(31, 337);
            this.diff.Name = "diff";
            this.diff.Size = new System.Drawing.Size(203, 52);
            this.diff.TabIndex = 7;
            this.diff.SelectedIndexChanged += new System.EventHandler(this.diff_SelectedIndexChanged);
            // 
            // analysis
            // 
            this.analysis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.analysis.AutoSize = true;
            this.analysis.Location = new System.Drawing.Point(152, 296);
            this.analysis.Name = "analysis";
            this.analysis.Size = new System.Drawing.Size(82, 21);
            this.analysis.TabIndex = 6;
            this.analysis.Text = "Analysis";
            this.analysis.UseVisualStyleBackColor = true;
            this.analysis.CheckedChanged += new System.EventHandler(this.analysis_CheckedChanged);
            // 
            // gameState
            // 
            this.gameState.AutoSize = true;
            this.gameState.Location = new System.Drawing.Point(28, 30);
            this.gameState.Name = "gameState";
            this.gameState.Size = new System.Drawing.Size(45, 17);
            this.gameState.TabIndex = 5;
            this.gameState.Text = "State:";
            // 
            // firstMove
            // 
            this.firstMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.firstMove.AutoSize = true;
            this.firstMove.Checked = true;
            this.firstMove.CheckState = System.Windows.Forms.CheckState.Checked;
            this.firstMove.Location = new System.Drawing.Point(31, 296);
            this.firstMove.Name = "firstMove";
            this.firstMove.Size = new System.Drawing.Size(87, 21);
            this.firstMove.TabIndex = 4;
            this.firstMove.Text = "Start first";
            this.firstMove.UseVisualStyleBackColor = true;
            // 
            // hardBot
            // 
            this.hardBot.Location = new System.Drawing.Point(31, 179);
            this.hardBot.Name = "hardBot";
            this.hardBot.Size = new System.Drawing.Size(203, 30);
            this.hardBot.TabIndex = 2;
            this.hardBot.Text = "Hard-level bot";
            this.hardBot.UseVisualStyleBackColor = true;
            this.hardBot.Click += new System.EventHandler(this.hardBot_Click);
            // 
            // normalBot
            // 
            this.normalBot.Location = new System.Drawing.Point(31, 139);
            this.normalBot.Name = "normalBot";
            this.normalBot.Size = new System.Drawing.Size(203, 30);
            this.normalBot.TabIndex = 1;
            this.normalBot.Text = "Normal-level bot";
            this.normalBot.UseVisualStyleBackColor = true;
            this.normalBot.Click += new System.EventHandler(this.normalBot_Click);
            // 
            // easyBot
            // 
            this.easyBot.Location = new System.Drawing.Point(31, 99);
            this.easyBot.Name = "easyBot";
            this.easyBot.Size = new System.Drawing.Size(203, 30);
            this.easyBot.TabIndex = 0;
            this.easyBot.Text = "Easy-level bot";
            this.easyBot.UseVisualStyleBackColor = true;
            this.easyBot.Click += new System.EventHandler(this.easyBot_Click);
            // 
            // leaderboard
            // 
            this.leaderboard.Controls.Add(this.leaderboardList);
            this.leaderboard.Location = new System.Drawing.Point(4, 34);
            this.leaderboard.Name = "leaderboard";
            this.leaderboard.Padding = new System.Windows.Forms.Padding(3);
            this.leaderboard.Size = new System.Drawing.Size(672, 416);
            this.leaderboard.TabIndex = 1;
            this.leaderboard.Text = "Leaderboard";
            this.leaderboard.UseVisualStyleBackColor = true;
            // 
            // leaderboardList
            // 
            this.leaderboardList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.leaderboardList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.leaderboardList.FullRowSelect = true;
            this.leaderboardList.Location = new System.Drawing.Point(8, 8);
            this.leaderboardList.Name = "leaderboardList";
            this.leaderboardList.Size = new System.Drawing.Size(656, 400);
            this.leaderboardList.TabIndex = 0;
            this.leaderboardList.UseCompatibleStateImageBehavior = false;
            this.leaderboardList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Login";
            this.columnHeader1.Width = 131;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Rank";
            this.columnHeader2.Width = 131;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Games played";
            this.columnHeader3.Width = 130;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Games won";
            this.columnHeader4.Width = 130;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Winrate";
            this.columnHeader5.Width = 130;
            // 
            // matchHistory
            // 
            this.matchHistory.Controls.Add(this.watch);
            this.matchHistory.Controls.Add(this.matchesList);
            this.matchHistory.Location = new System.Drawing.Point(4, 34);
            this.matchHistory.Name = "matchHistory";
            this.matchHistory.Size = new System.Drawing.Size(672, 416);
            this.matchHistory.TabIndex = 3;
            this.matchHistory.Text = "Match History";
            this.matchHistory.UseVisualStyleBackColor = true;
            // 
            // watch
            // 
            this.watch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.watch.Location = new System.Drawing.Point(544, 378);
            this.watch.Name = "watch";
            this.watch.Size = new System.Drawing.Size(120, 30);
            this.watch.TabIndex = 1;
            this.watch.Text = "Watch game";
            this.watch.UseVisualStyleBackColor = true;
            this.watch.Click += new System.EventHandler(this.watch_Click);
            // 
            // matchesList
            // 
            this.matchesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.matchesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.matchesList.FullRowSelect = true;
            this.matchesList.Location = new System.Drawing.Point(8, 8);
            this.matchesList.Name = "matchesList";
            this.matchesList.Size = new System.Drawing.Size(656, 358);
            this.matchesList.TabIndex = 0;
            this.matchesList.UseCompatibleStateImageBehavior = false;
            this.matchesList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Players";
            this.columnHeader6.Width = 257;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Date";
            this.columnHeader7.Width = 131;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Time";
            this.columnHeader8.Width = 131;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Winner";
            this.columnHeader9.Width = 131;
            // 
            // achievements
            // 
            this.achievements.Controls.Add(this.achievementsList);
            this.achievements.Location = new System.Drawing.Point(4, 34);
            this.achievements.Name = "achievements";
            this.achievements.Size = new System.Drawing.Size(672, 416);
            this.achievements.TabIndex = 2;
            this.achievements.Text = "Achievements";
            this.achievements.UseVisualStyleBackColor = true;
            // 
            // achievementsList
            // 
            this.achievementsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.achievementsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.achievementsList.FullRowSelect = true;
            this.achievementsList.Location = new System.Drawing.Point(8, 8);
            this.achievementsList.Name = "achievementsList";
            this.achievementsList.Size = new System.Drawing.Size(656, 400);
            this.achievementsList.TabIndex = 0;
            this.achievementsList.UseCompatibleStateImageBehavior = false;
            this.achievementsList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Title";
            this.columnHeader10.Width = 120;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Description";
            this.columnHeader11.Width = 450;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Received";
            this.columnHeader12.Width = 80;
            // 
            // update
            // 
            this.update.Enabled = true;
            this.update.Interval = 300;
            this.update.Tick += new System.EventHandler(this.Update_Tick);
            // 
            // botTimer
            // 
            this.botTimer.Enabled = true;
            this.botTimer.Tick += new System.EventHandler(this.botTimer_Tick);
            // 
            // unmake
            // 
            this.unmake.Location = new System.Drawing.Point(31, 243);
            this.unmake.Name = "unmake";
            this.unmake.Size = new System.Drawing.Size(203, 30);
            this.unmake.TabIndex = 8;
            this.unmake.Text = "Unmake last move";
            this.unmake.UseVisualStyleBackColor = true;
            this.unmake.Click += new System.EventHandler(this.unmake_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 454);
            this.Controls.Add(this.tabs);
            this.MinimumSize = new System.Drawing.Size(698, 501);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ultimate TicTacToe";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_FormClosed);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.tabs.ResumeLayout(false);
            this.rooms.ResumeLayout(false);
            this.rooms.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matchTime)).EndInit();
            this.practice.ResumeLayout(false);
            this.practice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.botField)).EndInit();
            this.leaderboard.ResumeLayout(false);
            this.matchHistory.ResumeLayout(false);
            this.achievements.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage rooms;
        private System.Windows.Forms.TabPage leaderboard;
        private System.Windows.Forms.TabPage achievements;
        private System.Windows.Forms.TabPage matchHistory;
        private System.Windows.Forms.TabPage practice;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.ListView roomsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ranked;
        private System.Windows.Forms.TrackBar matchTime;
        private System.Windows.Forms.ColumnHeader player;
        private System.Windows.Forms.ColumnHeader rank;
        private System.Windows.Forms.ColumnHeader time;
        private System.Windows.Forms.ColumnHeader type;
        private System.Windows.Forms.ColumnHeader state;
        private System.Windows.Forms.Label mmr;
        private System.Windows.Forms.Label login;
        private System.Windows.Forms.Timer update;
        private System.Windows.Forms.ListView leaderboardList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListView matchesList;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button watch;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ListView achievementsList;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Button hardBot;
        private System.Windows.Forms.Button normalBot;
        private System.Windows.Forms.Button easyBot;
        private System.Windows.Forms.Label gameState;
        private System.Windows.Forms.CheckBox firstMove;
        private System.Windows.Forms.Timer botTimer;
        private System.Windows.Forms.CheckBox analysis;
        private System.Windows.Forms.ListBox diff;
        private System.Windows.Forms.PictureBox botField;
        private System.Windows.Forms.Button unmake;
    }
}

