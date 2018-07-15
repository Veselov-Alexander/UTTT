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
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        UTTT game;

        

        private void Test_Load(object sender, EventArgs e)
        {
            game = new UTTT(field);
        }

        private void Update_Tick(object sender, EventArgs e)
        {
            if (!game.GameIsEnded())
            {
                game.Draw();

                switch (game.WhoIsWon())
                {
                    case Player.X:
                        game.EndGame();
                        MessageBox.Show("X");
                        break;

                    case Player.O:
                        game.EndGame();
                        MessageBox.Show("O");
                        break;

                    case Player.DRAW:
                        game.EndGame();
                        MessageBox.Show("DRAW");
                        break;
                }
            }
        }

        private void field_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                game.SetMark(new Point(e.X, e.Y), Player.X);
            }

            if (e.Button == MouseButtons.Right)
            {
                game.SetMark(new Point(e.X, e.Y), Player.O);
            }

            if (e.Button == MouseButtons.Middle)
            {
                game.SelectField(new Point(e.X, e.Y));
            }

        }
    }
}
