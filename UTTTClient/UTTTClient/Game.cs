using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UTTTClient
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
        }

        private UTTT game;

        private bool isMyTurn = false;
        private Player player = Player.NONE;
        private String gameHistory = String.Empty;

        private void leave_Click(object sender, EventArgs e)
        {
            if (leave.Text == "Close room")
            {
                Client.SendMessage("cancelGame;" + Client.GetLogin());
            }
            Application.OpenForms[1].Visible = true;
            Application.OpenForms[2].Dispose();
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms[0].Close();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            game = new UTTT(gameField);
            Update_Tick(sender, e);
            GameUpdate();
        }

        private void Update_Tick(object sender, EventArgs e)
        {        
            RoomUpdate(sender, e);  
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            GameUpdate();
        }

        private void RoomUpdate(object sender, EventArgs e)
        {
            String response = Client.SendMessage("getRoomInfo;" + Client.GetSelectedGame());
            if (response == "gameIsCanceled")
            {
                leave_Click(sender, e);
                MessageBox.Show("Game is canceled");
            }
            String[] tokens = response.Split(';');

            if (response.Split(';').First() == Client.GetLogin())
            {
                leave.Text = "Close room";
            }

           

            if (response.Contains(";Playing"))
            {
                leave.Text = "Leave room";
                accept.Enabled = false;

                this.Text = "Playing:    " + tokens[0] + " [" + tokens[1] + "] " + " - " +
                                             tokens[2] + " [" + tokens[3] + "] ";

                time.Text = "Time:\r\n\r\n" + tokens[0] + ":  " + ToClockFormat(tokens[4]) +
                                     "\r\n" + tokens[2] + ":  " + ToClockFormat(tokens[5]);

                turn.Text = tokens[9] + "'S TURN";

                if (tokens[9] == Client.GetLogin())
                {
                    isMyTurn = true;
                }
                else
                {
                    isMyTurn = false;
                }

                if (tokens[10] == "X")
                {
                    player = Player.X;
                }

                if (tokens[10] == "O")
                {
                    player = Player.O;
                }

                    String history = response.Split('{')[1].Split('}').First();

                    if (gameHistory != history)
                    {
                        gameHistory = history;
                        game = new UTTT(gameField);
                        String[] moves = history.Split(';');
                        foreach (String move in moves)
                        {
                            game.SetMark(move);
                        }
                    }
                
            }
            else if (response.Contains(";Ended"))
            {
                if (!game.GameIsEnded())
                {
                    game.EndGame();
                }

                if (response.Contains('{'))
                {
                
                    String history = response.Split('{')[1].Split('}').First();

                    if (gameHistory != history)
                    {
                        gameHistory = history;
                        game = new UTTT(gameField);
                        String[] moves = history.Split(';');
                        foreach (String move in moves)
                        {
                            game.SetMark(move);
                        }
                    }
                }
            }
            else if (response.Contains(";Created"))
            {
                accept.Enabled = true;
                turn.Text = "";
                this.Text = Client.GetSelectedGame() + "'s room";
                time.Text = "Time: " + (int.Parse(tokens[2]) / 60).ToString() + " minutes.";
            }


            if (response.Split(';').First() == Client.GetLogin())
            {
                accept.Enabled = false;
            }

            chat.Text = tokens.Last();
        }

        private void GameUpdate()
        {
            game.Draw();
            if (!game.GameIsEnded())
            {
                Player winner = game.WhoIsWon();

                if (winner != Player.NONE)
                {
                    game.EndGame();
                    Client.SendMessage("endGame;" +
                                       Client.GetSelectedGame() + ";" +
                                       winner);
                    turn.Text = "";
                    switch (winner)
                    {
                        case Player.X:
                            turn.Text = "Blue player wins!";
                            break;

                        case Player.O:
                            turn.Text = "Red player wins!";
                            break;

                        case Player.DRAW:
                            turn.Text = "Draw!";
                            break;
                    }
                }

            }
        }

        private String ToClockFormat(String time)
        {
            int minutes = int.Parse(time);
            String seconds = (minutes % 60).ToString();
            if (seconds.Length == 1)
            {
                seconds = "0" + seconds;
            }
            return (minutes / 60).ToString() + ":" + seconds;
        }

        private void send_Click(object sender, EventArgs e)
        {
            if (message.Text != String.Empty)
            {
                Client.SendMessage("sendMessage;" +
                                   Client.GetSelectedGame() + ";" +
                                   Client.GetLogin() + ";" +
                                   message.Text);
            }

            message.Text = String.Empty;
        }

        private void accept_Click(object sender, EventArgs e)
        {
            Client.SendMessage("acceptGame;" + Client.GetSelectedGame() + ";" + Client.GetToken());
        }

        private void gameField_MouseClick(object sender, MouseEventArgs e)
        {
            if (isMyTurn && !game.GameIsEnded())
            {
                if (e.Button == MouseButtons.Left)
                {
                    String move = game.SetMark(new Point(e.X, e.Y), player);

                    Client.SendMessage("setMove;" + Client.GetSelectedGame() + ";" + move);
                }
            }
        }
    }
}
