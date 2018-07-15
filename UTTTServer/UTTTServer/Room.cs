using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTTTServer
{
    class Room
    {
        private String chat;
        private String first_player;
        private String second_player;

        private int first_player_time;
        private int second_player_time;

        private bool turn;

        private int time;
        private bool is_ranked;
        private bool is_playing;

        private bool gameIsEnded = false;

        private String first_player_color = "X",
                       second_player_color = "O";

        private String gameHistory;

        public Room(String creator, String game_time, String ranked)
        {
            first_player = creator;
            time = int.Parse(game_time) * 60;
            if (ranked == "Ranked")
            {
                is_ranked = true;
            }
            else
            {
                is_ranked = false;
            }
            is_playing = false;

            Database.UnlockAchievement(creator, "1");
        }

        public void BeginGame(String player)
        {
            second_player = player;
            first_player_time = time;
            second_player_time = time;
            if ((new Random().Next() & 1) == 0)
            {
                turn = true;
            }
            else
            {
                turn = false;
            }
            is_playing = true;
        }

        public bool UpdateGame()
        {
            if (!is_playing || gameIsEnded)
            {
                return false;
            }
            if (is_playing && turn)
            {
                --first_player_time;
            }
            else
            {
                --second_player_time;
            }
            if (first_player_time < 0 )
            {
                is_playing = false;
                EndGame(second_player_color);
            }
            if (second_player_time < 0)
            {
                is_playing = false;
                EndGame(first_player_color);
            }
            return is_playing;
        }

        public void AddMessage(String who, String message)
        {
            chat += who + ":  " + message + "\r\n";
        }

        public String GetMessages()
        {
            return chat;
        }

        public String FullRoomInfo()
        {
            if (!is_playing)
            {
                return ShortRoomInfo() + ";" + GetMessages();
            }

            List<String> first = Database.GetUserInfo(first_player);
            List<String> second = Database.GetUserInfo(second_player);

            String playersInformation = first[0] + ";" +
                                        first[1] + ";" +
                                        second[0] + ";" +
                                        second[1] + ";" +
                                        first_player_time + ";" +
                                        second_player_time + ";";

            return playersInformation +
                   time.ToString() + ";" +
                   IsRanked() + ";" +
                   State() + ";" +
                   Turn() + ";{" +
                   History() + "};" +
                   GetMessages();

        }

        public void SetMove(String move)
        {
            if (move == "ERROR")
            {
                return;
            }
            gameHistory += move + ";";
            turn = !turn;
        }

        private String History()
        {
            return gameHistory;
        }

        private String Turn()
        {
            if (turn)
            {
                return first_player + ";" + first_player_color;
            }
            else
            {
                return second_player + ";" + second_player_color;
            }
        }

        public String ShortRoomInfo()
        {
            List<String> first = Database.GetUserInfo(first_player);

            return first[0] + ";" + 
                   first[1] + ";" +
                   time.ToString() + ";" +
                   IsRanked() + ";" +
                   State() + ";";
        }

        public String IsRanked()
        {
            if (is_ranked)
            {
                return "Ranked";
            }
            else
            {
                return "Unranked";
            }
        }

        public String State()
        {
            if (gameIsEnded)
            {
                return "Ended";
            }
            if (is_playing)
            {
                return "Playing";
            }
            else
            {
                return "Created";
            }
        }

        public void EndGame(String winner)
        {
            if (gameIsEnded)
            {
                return;
            }

            gameIsEnded = true;

            if (winner == first_player_color)
            {
                winner = first_player;
            }
            else if (winner == second_player_color)
            {
                winner = second_player;
            }
            else
            {
                winner = "DRAW";
            }

            Database.InsertGame(first_player,
                                second_player,
                                gameHistory,
                                winner);

            if (is_ranked)
            {
                Database.UpdateRank(first_player,
                                    second_player,
                                    winner);
            }
        }

        public bool GameIsEnded()
        {
            return gameIsEnded;
        }

    }
}
