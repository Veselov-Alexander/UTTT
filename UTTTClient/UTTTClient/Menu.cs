using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UTTTClient
{
    public partial class Menu : Form
    {
        private String roomsListString = "null";
        private String matchesInformation;
        private bool online;


        public Menu(bool is_online)
        {
            InitializeComponent();

            online = is_online;

            if (!online)
            {
                tabs.SelectedIndex = 1;
            }
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            if (online)
            {
                GetUserInfo();
            }
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms[0].Close();
        }

        private void create_Click(object sender, EventArgs e)
        {
            String message = "createRoom;" +
                             Client.GetToken() + ";" +
                             matchTime.Value.ToString() + ";" +
                             (ranked.Checked ? "Ranked;" : "Unranked;");

            Client.SendMessage(message);


            Client.SelectGame(Client.GetLogin());
            OpenGame();
        }

        private void AddRoom(String player, String rank, String time, String ranked, String status)
        {
            ListViewItem item = new ListViewItem(player);
            item.SubItems.Add(rank);
            item.SubItems.Add((int.Parse(time) / 60).ToString());
            item.SubItems.Add(ranked);
            item.SubItems.Add(status);
            roomsList.Items.Add(item);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!online)
            {
                return;
            }

            switch (tabs.SelectedTab.Text)
            {
                case "Rooms":
                    GetUserInfo();
                    break;

                case "Leaderboard":
                    GetLeaderboard();
                    break;

                case "Match History":
                    GetMatches();
                    break;

                case "Achievements":
                    GetAchievements();
                    break;
            }
        }

        private void GetAchievements()
        {
            achievementsList.Items.Clear();
            String response = Client.SendMessage("getAchievements;" + Client.GetLogin());
            foreach (String achievement in response.Split('|'))
            {
                String[] attributes = achievement.Split(';');
                AddAchievement(attributes[1],
                               attributes[2],
                               attributes[0]);
            }
        }

        private void AddAchievement(String title, String description, String recieved)
        {
            ListViewItem item = new ListViewItem(title);
            item.SubItems.Add(description);
            item.SubItems.Add(recieved);
            achievementsList.Items.Add(item);
        }

        private void GetLeaderboard()
        {
            leaderboardList.Items.Clear();
            String response = Client.SendMessage("getLeaderboard");
            foreach (String player in response.Split('|'))
            {
                String[] attributes = player.Split(';');
                AddPlayerToLeaderboardList(attributes[0],
                                           attributes[1],
                                           attributes[2],
                                           attributes[3],
                                           attributes[4]);
            }
        }

        private void AddPlayerToLeaderboardList(String player, String rank, String played, String won, String winrate)
        {
            ListViewItem item = new ListViewItem(player);
            item.SubItems.Add(rank);
            item.SubItems.Add(played);
            item.SubItems.Add(won);
            item.SubItems.Add(winrate.Substring(0, 5) + "%");
            leaderboardList.Items.Add(item);
        }

        private void GetMatches()
        {
            matchesList.Items.Clear();
            matchesInformation = Client.SendMessage("getMatches;" + Client.GetLogin());

            foreach (String player in matchesInformation.Split('|'))
            {
                String[] attributes = player.Split(';');
                AddMatchToList(attributes[1],
                               attributes[2],
                               attributes[3],
                               attributes[4]);
            }
        }

        private void AddMatchToList(String first_player,
                                    String second_player, 
                                    String date,
                                    String winner)
        {
            ListViewItem item = new ListViewItem(first_player + " : " + second_player);
            item.SubItems.Add(date.Split(' ')[0]);
            item.SubItems.Add(date.Split(' ')[1]);
            item.SubItems.Add(winner);
            matchesList.Items.Add(item);
        }

        public void GetUserInfo()
        {
            String request = "getUserInfo;" + Client.GetToken();
            String response = Client.SendMessage(request);
            String[] tokens = response.Split(';');
            Client.SetRank(tokens[1]);

            login.Text = "Login: " + Client.GetLogin();
            mmr.Text = "Rank: " + Client.GetRank();
        }

        private void Update_Tick(object sender, EventArgs e)
        {
            if (!online)
            {
                return;
            }
            String response = Client.SendMessage("getRooms");
            if (response != null && response != String.Empty && response != roomsListString)
            {
                roomsListString = response;
                roomsList.Items.Clear();
                foreach (String room in response.Split('?'))
                {
                    if (room == String.Empty || response.Length < 5) continue;
                    String[] roomInfo = room.Split(';');

                    AddRoom(roomInfo[0],
                            roomInfo[1],
                            roomInfo[2],
                            roomInfo[3],
                            roomInfo[4]);
                }
            }
            if (roomsList.SelectedItems.Count == 0)
            {
                connect.Enabled = false;
            }
            else
            {
                connect.Enabled = true;
            }

            if (matchesList.SelectedItems.Count == 0)
            {
                watch.Enabled = false;
            }
            else
            {
                watch.Enabled = true;
            }

            if (roomsListString.Contains(Client.GetLogin()))
            {
                create.Enabled = false;
            }
            else
            {
                create.Enabled = true;
            }

        }

        private void connect_Click(object sender, EventArgs e)
        {
            Client.SelectGame(roomsList.SelectedItems[0].Text);
            OpenGame();
        }

        private void OpenGame()
        {
            Game g = new Game();
            g.Left = this.Left;
            g.Top = this.Top;
            g.Location = this.Location;
            g.Show();
            this.Hide();
        }

        private void OpenMatch(String history)
        {
            Match g = new Match(history);
            g.Left = this.Left;
            g.Top = this.Top;
            g.Location = this.Location;
            g.Show();
            this.Hide();
        }

        private void watch_Click(object sender, EventArgs e)
        {
            OpenMatch(matchesInformation.Split('|')[matchesList.SelectedIndices[0]]);
        }

        private void tabs_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!online)
            {
                if (e.TabPage != practice)
                {
                    e.Cancel = true;
                }
            }
        }

        private UTTT botGame;
        private UTTT botGameCopy;
        private Player playerColor = Player.X;
        private Player botColor = Player.O;
        private bool botGameIsPlaying = false;

        private Bot bot;

        private void easyBot_Click(object sender, EventArgs e)
        {
            botGameInit(BotLevel.EASY);
        }

        private void normalBot_Click(object sender, EventArgs e)
        {
            botGameInit(BotLevel.NORMAL);
        }

        private void hardBot_Click(object sender, EventArgs e)
        {
            botGameInit(BotLevel.HARD);
        }

        private void botGameInit(BotLevel level)
        {
            botGameIsPlaying = true;
            if (!firstMove.Checked)
            {
                playerColor = Player.O;
                botColor = Player.X;
            }

            botGame = new UTTT(botField);
            bot = new Bot(level, botColor);

            if (!firstMove.Checked)
            {
                botGame.SetMark(bot.NextMove(botGame.gameStateToString()));
            }

            analysis.Checked = false;
            diff.SelectedIndex = 0;
        }

        private void botField_MouseClick(object sender, MouseEventArgs e)
        {
            if (botGameIsPlaying)
            {
                botGameCopy = botGame.Clone();

                if (botGame.SetMark(new Point(e.X, e.Y), playerColor) == "ERROR")
                {
                    return;
                }

                CheckGameState();



                if (!botGame.GameIsEnded())
                {
                    String gameState = botGame.gameStateToString();
                    String botMove = bot.NextMove(gameState);
                    Console.WriteLine(botMove);

                    botGame.SetMark(botMove);

                    CheckGameState();

                    if (analysis.Checked && botGameIsPlaying)
                    {
                        botGame.DisableAnalysis();
                        botGame.Draw();
                        String scores = bot.Analysis(botGame.gameStateToString());
                        botGame.EnableAnalysis(scores);
                    }
                }
                botGame.Draw();
            }
        }

        private void CheckGameState()
        {
            Player winner = botGame.WhoIsWon();
            if (winner != Player.NONE)
            {
                botGame.EndGame();
                botGameIsPlaying = false;
            }
            if (winner == Player.X)
            {
                MessageBox.Show("Blue player won!");
            }
            else if (winner == Player.O)
            {
                MessageBox.Show("Red player won!");
            }
            else if (winner == Player.DRAW)
            {
                MessageBox.Show("Draw!");
            }
        }

        private void botTimer_Tick(object sender, EventArgs e)
        {
            if (botGame == null || !botGameIsPlaying)
            {
                diff.Enabled = false;
                analysis.Enabled = false;
                return;
            }
            else
            {
                diff.Enabled = true;
                analysis.Enabled = true;
            }

            if (botGameCopy == null)
            {
                unmake.Enabled = false;
            }
            else
            {
                unmake.Enabled = true;
            }

            botGame.Draw();

            if (botGame.GameIsEnded())
            {
                botGameIsPlaying = false;
                return;
            }
        }

        private void analysis_CheckedChanged(object sender, EventArgs e)
        {
            if (analysis.Checked)
            {
                bot.ChangeDifficulty(diff.SelectedIndex);
                String scores = bot.Analysis(botGame.gameStateToString());
                botGame.EnableAnalysis(scores);
            }
            else
            {
                botGame.DisableAnalysis();
            }
        }

        private void UnmakeLastMove()
        {
            botGame = botGameCopy.Clone();
            botGameCopy = null;
        }

        private void diff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (analysis.Checked)
            {
                bot.ChangeDifficulty(diff.SelectedIndex);
                String scores = bot.Analysis(botGame.gameStateToString());
                botGame.EnableAnalysis(scores);
            }
            else
            {
                botGame.DisableAnalysis();
            }
        }

        private void unmake_Click(object sender, EventArgs e)
        {
            UnmakeLastMove();
            unmake.Enabled = false;
        }
    }
}
