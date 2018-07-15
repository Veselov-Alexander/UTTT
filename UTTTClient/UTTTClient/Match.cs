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
    public partial class Match : Form
    {
        private String gameHistory;
        public Match(String history)
        {
            InitializeComponent();
            gameHistory = history;
        }

        private UTTT game;
        private int current_step;

        private void Match_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms[0].Close();
        }

        private void Match_Load(object sender, EventArgs e)
        {
            game = new UTTT(gameField);
            current_step = 0;

            String[] moves = gameHistory.Split(';');
            roomName.Text = "Playing:\r\n\r\n" + moves[1] + " - " + moves[2];

            bot = new Bot(BotLevel.EASY, Player.O);

            analysis.Checked = false;
            diff.SelectedIndex = 0;
        }

        private void update_Tick(object sender, EventArgs e)
        {
            game.Draw();

            if (analysis.Checked)
            {
                diff.Enabled = true;
            }
            else
            {
                diff.Enabled = false;
            }
        }

        private void SelectMove(int step)
        {
            game = new UTTT(gameField);

            String[] moves = gameHistory.Split(';');

            File.Delete("Game.ai");
            for (int move = 5; move < 5 + step; ++move)
            {
                game.SetMark(moves[move], true);
            }
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (next.Enabled == false && current_step == gameHistory.Split(';').Length - 5)
            {
                return;
            }
            SelectMove(++current_step);

            if (current_step == gameHistory.Split(';').Length - 5)
            {
                next.Enabled = false;
            }

            prev.Enabled = true;

            Analisys();
        }

        private void prev_Click(object sender, EventArgs e)
        {
            SelectMove(--current_step);

            if (current_step == 0)
            {
                prev.Enabled = false;
            }

            next.Enabled = true;

            Analisys();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Application.OpenForms[1].Visible = true;
            Application.OpenForms[2].Dispose();
        }

        private void auto_Click(object sender, EventArgs e)
        {
            if (animation.Enabled)
            {
                auto.Text = "Auto";
                animation.Enabled = false;
            }
            else
            {
                auto.Text = "Stop";
                animation.Enabled = true;
            }
        }

        private void animation_Tick(object sender, EventArgs e)
        {
            next_Click(sender, e);
        }

        private void speed_Scroll(object sender, EventArgs e)
        {
            animation.Interval = (1100 - speed.Value * 100);
        }




        private Bot bot;




        private void Analisys()
        {
            if (analysis.Checked)
            {
                bot.ChangeDifficulty(diff.SelectedIndex);
                Console.WriteLine(game.gameStateToString());
                String scores = bot.Analysis(game.gameStateToString());
                AppendLog(scores);
                game.EnableAnalysis(scores);
            }
            else
            {
                game.DisableAnalysis();
            }
        }

        private void AppendLog(String scores)
        {
            log.AppendText("Move:\r\n");
            String[] scoresArray = scores.Substring(5).Split('|');
            foreach (String score in scoresArray)
            {
                String[] parameters = score.Split(';');
                int x = int.Parse(parameters[0]);
                int y = int.Parse(parameters[1]);
                int s = int.Parse(parameters[2]) ;

                int bigX = x / 3;
                int bigY = y / 3;
                int smallX = x % 3;
                int smallY = y % 3;

                log.AppendText(bigX.ToString() + bigY.ToString() + smallX.ToString() + smallY.ToString() + " = " + s + "\r\n");

            }
            log.AppendText("\r\n");
        }

        

        private void analysis_CheckedChanged(object sender, EventArgs e)
        {
            Analisys();
        }

        private void diff_SelectedIndexChanged(object sender, EventArgs e)
        {
            Analisys();
        }
    }
}
