using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UTTTClient
{
    class UTTT
    {
        private PictureBox field;
        private Graphics fieldGraphics, imageGraphics;
        private Bitmap image;

        private int size;
        private int big_square_size;
        private int small_square_size;
        private int delta_size;

        private int delta_position = 0;

        private Point lastBig, lastSmall;

        private Pen pen;

        private Color x_color,
                      o_color,
                      area_color,
                      x_win_color,
                      o_win_color;

        private SmallBoard[,] board;
        private bool[,] areas;

        private bool gameIsEnded;

        private bool analysis = false;
        private String scores;

        public UTTT(PictureBox box)
        {
            field = box;

            if (field.Size.Height < field.Size.Width)
            {
                size = field.Size.Height;
            }
            else
            {
                size = field.Size.Width;
            }

            delta_position = (field.Size.Width - size) / 2;

            big_square_size = size / 3;
            small_square_size = (int)(big_square_size / 3 * 0.8);
            delta_size = (int)((big_square_size / 3 - small_square_size) * 1.5);

            image = new Bitmap(size, size);

            fieldGraphics = field.CreateGraphics();
            imageGraphics = Graphics.FromImage(image);

            fieldGraphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            imageGraphics.InterpolationMode = InterpolationMode.HighQualityBilinear;

            fieldGraphics.SmoothingMode = SmoothingMode.HighQuality;
            imageGraphics.SmoothingMode = SmoothingMode.HighQuality;

            pen = new Pen(Color.Black, 2);

            x_color = Color.FromArgb(70, 215, 255);
            o_color = Color.FromArgb(255, 95, 92);

            area_color = Color.FromArgb(255, 254, 120);
            x_win_color = Color.FromArgb(204, 245, 255);
            o_win_color = Color.FromArgb(255, 219, 213);

            board = new SmallBoard[3, 3];
            areas = new bool[3, 3];

            lastBig = new Point(-1, -1);
            lastSmall = new Point(-1, -1);

            gameIsEnded = false;

            for (int row = 0; row < 3; ++row)
            {
                for (int column = 0; column < 3; ++column)
                {
                    board[row, column] = new SmallBoard();
                    areas[row, column] = true;
                }
            }
        }

        public void Resize()
        {
            if (size != field.Size.Height && field.Size.Height != 0)
            {
                if (field.Size.Height < field.Size.Width)
                {
                    size = field.Size.Height;
                }
                else
                {
                    size = field.Size.Width;
                }

                delta_position = (field.Size.Width - size) / 2;

                big_square_size = size / 3;
                small_square_size = (int)(big_square_size / 3 * 0.8);
                delta_size = (int)((big_square_size / 3 - small_square_size) * 1.5);

                image = new Bitmap(size, size);

                fieldGraphics = field.CreateGraphics();
                imageGraphics = Graphics.FromImage(image);

                imageGraphics.InterpolationMode = InterpolationMode.HighQualityBilinear;


                imageGraphics.SmoothingMode = SmoothingMode.HighQuality;
            }
        }

        public void Draw()
        {
            Resize();

            imageGraphics.Clear(Color.White);

            DrawAreas();
            CalculateAllowedMoves();
            DrawScores();
            DrawBigField();
            DrawMarks();

            fieldGraphics.DrawImage(image, new Point(delta_position, 0));
        }

        private void DrawBigField()
        {

            for (int line = 1; line <= 2; ++line)
            {
                imageGraphics.DrawLine(pen,
                                       new Point(line * big_square_size, size),
                                       new Point(line * big_square_size, 0));

                imageGraphics.DrawLine(pen,
                                       new Point(size, line * big_square_size),
                                       new Point(0, line * big_square_size));
            }

            for (int row = 0; row < 3; ++row)
            {
                for (int column = 0; column < 3; ++column)
                {
                    DrawSmallField(new Point(row * big_square_size + delta_size,
                                             column * big_square_size + delta_size));
                }
            }
        }

        private void DrawSmallField(Point point)
        {
            for (int line = 1; line <= 2; ++line)
            {
                int delta = small_square_size * line;
                int size = small_square_size * 3;

                imageGraphics.DrawLine(Pens.Black,
                                       new Point(point.X + delta, point.Y + 0),
                                       new Point(point.X + delta, point.Y + size));


                imageGraphics.DrawLine(Pens.Black,
                                       new Point(point.X + size, point.Y + delta),
                                       new Point(point.X + 0, point.Y + delta));

            }

        }

        private void DrawMarks()
        {
            for (int row = 0; row < 3; ++row)
            {
                for (int column = 0; column < 3; ++column)
                {
                    Player[,] smallBoard = board[row, column].GetField();
                    
                    for (int smallRow = 0; smallRow < 3; ++smallRow)
                    {
                        for (int smallColumn = 0; smallColumn < 3; ++smallColumn)
                        {
                            int x = row * big_square_size + delta_size;
                            int y = column * big_square_size + delta_size;

                            DrawMark(x + (int)((smallRow + 0.18) * small_square_size),
                                     y + (int)((smallColumn + 0.18) * small_square_size),
                                     smallBoard[smallRow, smallColumn]);
                        }
                    }
                }
            }
        }

        private void DrawMark(int x, int y, Player cell)
        {
            int mark_size = (int)(small_square_size * 0.7);

            switch (cell)
            {
                case Player.NONE: return;

                case Player.X:
                    DrawRoundRect(x_color, x, y, mark_size, mark_size);
                    break;

                case Player.O:
                    DrawRoundRect(o_color, x, y, mark_size, mark_size);
                    break;
            } 
        }

        private void DrawRoundRect(Color color, float x, float y, float width, float height)
        {
            GraphicsPath graphicsPath = new GraphicsPath();

            float radius = small_square_size * 0.1f;

            graphicsPath.AddLine(x + radius, y, x + width - (radius * 2), y); // Line
            graphicsPath.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90); // Corner
            graphicsPath.AddLine(x + width, y + radius, x + width, y + height - (radius * 2)); // Line
            graphicsPath.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90); // Corner
            graphicsPath.AddLine(x + width - (radius * 2), y + height, x + radius, y + height); // Line
            graphicsPath.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90); // Corner
            graphicsPath.AddLine(x, y + height - (radius * 2), x, y + radius); // Line
            graphicsPath.AddArc(x, y, radius * 2, radius * 2, 180, 90); // Corner
            graphicsPath.CloseFigure();

            imageGraphics.DrawPath(new Pen(color), graphicsPath);
            imageGraphics.FillPath(new SolidBrush(color), graphicsPath);
            graphicsPath.Dispose();
        }

        private void DrawAreas()
        {
            for (int row = 0; row < 3; ++row)
            {
                for (int column = 0; column < 3; ++column)
                {
                    if (areas[row, column] && !analysis)
                    {
                        imageGraphics.FillRectangle(new SolidBrush(area_color),
                                                    row * big_square_size + delta_size,
                                                    column * big_square_size + delta_size,
                                                    small_square_size * 3,
                                                    small_square_size * 3);
                    }

                    switch (board[row, column].WhoIsWon())
                    {
                        case Player.X:
                            imageGraphics.FillRectangle(new SolidBrush(x_win_color),
                                                    row * big_square_size,
                                                    column * big_square_size,
                                                    big_square_size,
                                                    big_square_size);
                            break;

                        case Player.O:
                            imageGraphics.FillRectangle(new SolidBrush(o_win_color),
                                                    row * big_square_size,
                                                    column * big_square_size,
                                                    big_square_size,
                                                    big_square_size);
                            break;
                    }
                }
            }
        }

        public String SetMark(Point point, Player cell)
        {
            if (gameIsEnded)
            {
                return "ERROR";
            }
            int bigX = (point.X - delta_position) / big_square_size;
            int bigY = point.Y / big_square_size;

            int newX = point.X - bigX * big_square_size - delta_size - delta_position;
            int newY = point.Y - bigY * big_square_size - delta_size;

            int smallX = newX / small_square_size;
            int smallY = newY / small_square_size;

            if ((bigX >= 3 || bigX < 0 || bigY >= 3 || bigY < 0) ||
                (smallX >= 3 || smallX < 0 || smallY >= 3 || smallY < 0) ||
                areas[bigX, bigY] == false ||
                board[bigX, bigY].GetField()[smallX, smallY] != Player.NONE)
            {
                return "ERROR";
            }

            lastBig = new Point(bigX, bigY);
            lastSmall = new Point(smallX, smallY);

            board[bigX, bigY].SetCell(smallX, smallY, cell);

            String move = bigX.ToString() +
                          bigY.ToString() +
                          smallX.ToString() +
                          smallY.ToString();
            if (cell == Player.X)
            {
                return "X" + move;
            }
            else
            {
                return "O" + move;
            }
        }

        public void SetMark(String move, bool log = false)
        {
            if (move == null ||
                move == String.Empty ||
                gameIsEnded)
            {
                return;
            }
            

            int bigX = move[1] - '0';
            int bigY = move[2] - '0';
            int smallX = move[3] - '0';
            int smallY = move[4] - '0';



            if ((bigX >= 3 || bigX < 0 || bigY >= 3 || bigY < 0) ||
                (smallX >= 3 || smallX < 0 || smallY >= 3 || smallY < 0) ||
                areas[bigX, bigY] == false ||
                board[bigX, bigY].GetField()[smallX, smallY] != Player.NONE)
            {
                //return;
            }



            lastBig = new Point(bigX, bigY);
            lastSmall = new Point(smallX, smallY);

            Player cell;

            if (move[0] == 'X')
            {
                cell = Player.X;
            }
            else
            {
                cell = Player.O;
            }

            board[bigX, bigY].SetCell(smallX, smallY, cell);

            if (log)
            {
                int x = bigX * 3 + smallX;
                int y = bigY * 3 + smallY;
                String output = x.ToString() + " " + y.ToString();

                if (File.Exists("Game.ai"))
                {
                    StreamReader reader = new StreamReader("Game.ai");
                    string content = reader.ReadToEnd();
                    reader.Close();

                    int len = content.Split('\n').First().Length;

                    content = (int.Parse(content.Substring(0, len)) + 1).ToString() + content.Substring(len);

                    StreamWriter writer = new StreamWriter("Game.ai");
                    writer.Write(content);
                    writer.Close();

                    StreamWriter sw = File.AppendText("Game.ai"); sw.WriteLine(output);
                    sw.Close();
                }
                else
                {
                    StreamWriter sw = File.AppendText("Game.ai");
                    sw.WriteLine("1\r\n" + output);
                    sw.Close();
                }
            }


            CalculateAllowedMoves();
        }

        private void DrawScores()
        {
            if (!analysis || gameIsEnded)
            {
                return;
            }

            String[] scoresArray = scores.Substring(5).Split('|');

            int min = int.MaxValue, max = int.MinValue;

            foreach (String score in scoresArray)
            {
                String[] parameters = score.Split(';');

                int s = int.Parse(parameters[2]);
                int x = int.Parse(parameters[0]);
                int y = int.Parse(parameters[1]);

                int bigX = x / 3;
                int bigY = y / 3;
                if (areas[bigX, bigY])
                {
                    if (s < min) min = s;
                    if (s > max) max = s;
                }
            }

            int delta = max - min;

            int bestBigX =0;
            int bestBigY  =0;
            int bestSmallX =0;
            int bestSmallY =0;
            int bestScore = int.MinValue;

            foreach (String score in scoresArray)
            {
                String[] parameters = score.Split(';');
                int x = int.Parse(parameters[0]);
                int y = int.Parse(parameters[1]);
                int s = int.Parse(parameters[2]) - min;

                int bigX = x / 3;
                int bigY = y / 3;
                int smallX = x % 3;
                int smallY = y % 3;

                if (areas[bigX, bigY])
                {
                    if (s > bestScore)
                    {
                        bestBigX = bigX;
                        bestBigY = bigY;
                        bestSmallX = smallX;
                        bestSmallY = smallY;
                        bestScore = s;
                    }

                    if (delta == 0)
                    {
                        delta = 1;
                        s = 1;
                    }

                    int per = s * 255 / delta;
                    
                    int r = 127, g = per, b = 0; 

                    imageGraphics.FillRectangle(new SolidBrush(Color.FromArgb(r, g, b)),
                                                        bigX * big_square_size + delta_size + smallX * small_square_size,
                                                        bigY * big_square_size + delta_size + smallY * small_square_size,
                                                        small_square_size,
                                                        small_square_size);
                }
            }

            int x1 = scores[0] - '0';
            int y1 = scores[1] - '0';
            int x2 = scores[2] - '0';
            int y2 = scores[3] - '0';

            if (areas[x1, y1])
            {


                imageGraphics.DrawRectangle(pen,
                                        x1 * big_square_size + delta_size + x2 * small_square_size,
                                        y1 * big_square_size + delta_size + y2 * small_square_size,
                                        small_square_size,
                                        small_square_size);
            }
            else
            {
                imageGraphics.DrawRectangle(pen,
                                        bestBigX * big_square_size + delta_size + bestSmallX * small_square_size,
                                        bestBigY * big_square_size + delta_size + bestSmallY * small_square_size,
                                        small_square_size,
                                        small_square_size);
            }


        }

        private void CalculateAllowedMoves()
        {
            if (gameIsEnded)
            {
                FillAreas(false);
                return;
            }
            if (lastSmall.X == -1 ||
                board[lastSmall.X, lastSmall.Y].WhoIsWon() != Player.NONE)
            {
                FillAreas(true);
                return;
            }
            else
            {
                FillAreas(false);
                areas[lastSmall.X, lastSmall.Y] = true;
            }
        }

        public Player WhoIsWon()
        {
            if (board[0, 0].WhoIsWon() == board[0, 1].WhoIsWon() && 
                board[0, 0].WhoIsWon() == board[0, 2].WhoIsWon() &&
                board[0, 0].WhoIsWon() != Player.NONE)
            {
                return board[0, 0].WhoIsWon();
            }

            if (board[1, 0].WhoIsWon() == board[1, 1].WhoIsWon() &&
                board[1, 0].WhoIsWon() == board[1, 2].WhoIsWon() &&
                board[1, 0].WhoIsWon() != Player.NONE)
            {
                return board[1, 0].WhoIsWon();
            }

            if (board[2, 0].WhoIsWon() == board[2, 1].WhoIsWon() &&
                board[2, 0].WhoIsWon() == board[2, 2].WhoIsWon() &&
                board[2, 0].WhoIsWon() != Player.NONE)
            {
                return board[2, 0].WhoIsWon();
            }

            if (board[0, 0].WhoIsWon() == board[1, 0].WhoIsWon() &&
                board[0, 0].WhoIsWon() == board[2, 0].WhoIsWon() &&
                board[0, 0].WhoIsWon() != Player.NONE)
            {
                return board[0, 0].WhoIsWon();
            }

            if (board[0, 1].WhoIsWon() == board[1, 1].WhoIsWon() &&
                board[0, 1].WhoIsWon() == board[2, 1].WhoIsWon() &&
                board[0, 1].WhoIsWon() != Player.NONE)
            {
                return board[0, 1].WhoIsWon();
            }

            if (board[0, 2].WhoIsWon() == board[1, 2].WhoIsWon() &&
                board[0, 2].WhoIsWon() == board[2, 2].WhoIsWon() &&
                board[0, 2].WhoIsWon() != Player.NONE)
            {
                return board[0, 2].WhoIsWon();
            }

            if (board[0, 0].WhoIsWon() == board[1, 1].WhoIsWon() &&
                board[0, 0].WhoIsWon() == board[2, 2].WhoIsWon() &&
                board[0, 0].WhoIsWon() != Player.NONE)
            {
                return board[0, 0].WhoIsWon();
            }

            if (board[0, 2].WhoIsWon() == board[1, 1].WhoIsWon() &&
                board[0, 2].WhoIsWon() == board[2, 0].WhoIsWon() &&
                board[0, 2].WhoIsWon() != Player.NONE)
            {
                return board[0, 2].WhoIsWon();
            }

            bool isDraw = true;

            for (int row = 0; row < 3; ++row)
            {
                for (int column = 0; column < 3; ++column)
                {
                    if (board[row, column].WhoIsWon() == Player.NONE)
                    {
                        isDraw = false;
                    }
                }
            }

            if (isDraw)
            {
                return Player.DRAW;
            }

            return Player.NONE;
        }

        public void EnableAnalysis(String score)
        {
            Console.WriteLine(scores);
            scores = score;
            analysis = true;
        }

        public void DisableAnalysis()
        {
            analysis = false;
        }

        public void EndGame()
        {
            Draw();
            gameIsEnded = true;
        }

        public bool GameIsEnded()
        {
            return gameIsEnded;
        }

        public String gameStateToString()
        {
            String result = String.Empty;

            for (int row = 0; row < 9; ++row)
            {
                for (int column = 0; column < 9; ++column)
                {
                    int big_row = row / 3;
                    int big_column = column / 3;

                    int small_row = row % 3;
                    int small_column = column % 3;

                    result += board[big_row, big_column].getCell(small_row, small_column);

                }
            }

            return result;
        }


        private void FillAreas(bool value)
        {
            for (int row = 0; row < 3; ++row)
            {
                for (int column = 0; column < 3; ++column)
                {
                    Player winner = board[row, column].WhoIsWon();
                    if (winner == Player.X ||
                        winner == Player.O ||
                        winner == Player.DRAW)
                    {
                        areas[row, column] = false;
                    }
                    else
                    {
                        areas[row, column] = value;
                    }
                }
            }
        }

        public void SelectField(Point point)
        {
            int x = point.X / big_square_size;
            int y = point.Y / big_square_size;

            areas[x, y] = true;
        }
    }

    class SmallBoard
    {
        Player[,] field;

        public SmallBoard()
        {
            field = new Player[3, 3];
            for (int row = 0; row < 3; ++row)
            {
                for (int column = 0; column < 3; ++column)
                {
                    field[row, column] = Player.NONE;
                }
            }
        }

        public String getCell(int row, int column)
        {
            switch (field[row, column])
            {
                case Player.X:
                    return "X";


                case Player.O:
                    return "O";
            }

            return "-";
        }

        public void SetCell(int x, int y, Player cell)
        {
            if (x > 2 || y > 2 || x < 0 || y < 0)
            {
                return;
            }
            field[x, y] = cell;
        }

        public Player[,] GetField()
        {
            return field;
        }

        public Player WhoIsWon()
        {
            if (field[0, 0] == field[0, 1] && field[0, 0] == field[0, 2] && field[0, 0] != Player.NONE)
            {
                return field[0, 0];
            }

            if (field[1, 0] == field[1, 1] && field[1, 0] == field[1, 2] && field[1, 0] != Player.NONE)
            {
                return field[1, 0];
            }

            if (field[2, 0] == field[2, 1] && field[2, 0] == field[2, 2] && field[2, 0] != Player.NONE)
            {
                return field[2, 0];
            }

            if (field[0, 0] == field[1, 0] && field[0, 0] == field[2, 0] && field[0, 0] != Player.NONE)
            {
                return field[0, 0];
            }

            if (field[0, 1] == field[1, 1] && field[0, 1] == field[2, 1] && field[0, 1] != Player.NONE)
            {
                return field[0, 1];
            }

            if (field[0, 2] == field[1, 2] && field[0, 2] == field[2, 2] && field[0, 2] != Player.NONE)
            {
                return field[0, 2];
            }

            if (field[0, 0] == field[1, 1] && field[0, 0] == field[2, 2] && field[0, 0] != Player.NONE)
            {
                return field[0, 0];
            }

            if (field[0, 2] == field[1, 1] && field[0, 2] == field[2, 0] && field[0, 2] != Player.NONE)
            {
                return field[0, 2];
            }

            bool isDraw = true;

            for (int row = 0; row < 3; ++row)
            {
                for (int column = 0; column < 3; ++column)
                {
                    if (field[row, column] == Player.NONE)
                    {
                        isDraw = false;
                    }
                }
            }

            if (isDraw)
            {
                return Player.DRAW;
            }

            return Player.NONE;
        }

    }

    enum Player
    {
        NONE,
        X,
        O, 
        DRAW
    }
}
