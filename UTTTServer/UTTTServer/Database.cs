using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTTTServer
{
    class Database
    {
        private static string connectionString = "server=localhost;user id=root;password=1234567;database=uttt;SslMode=none";

        private static MySqlConnection connection;

        public static void Open()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        public static void Close()
        {
            connection.Close();
        }

        public static List<String> GetUserInfo(String login)
        {
            return Select("select login, rank from user where login = \"" + login + "\"", 2).First();
        }

        public static bool LogIn(String login, String password)
        {
            login = login.ToUpper();
            password = password.ToUpper();
            return Select("select * from user where login = \"" + login + "\" and password = \"" + password + "\"", 4).Count != 0;
        }

        public static bool SignIn(String login, String password)
        {
            login = login.ToUpper();
            password = password.ToUpper();
            if (Select("select * from user where login = \"" + login + "\"", 4).Count != 0)
            {
                return false;
            }
            Insert("insert into user (`login`, `password`)  values(\"" + login + "\", \"" + password + "\")");
            return true;
        }

        public static void InsertGame(String first_player,
                                      String second_player,
                                      String moves,
                                      String winner)
        {
            Insert("insert into game(`moves`, `date`, `winner`) values (\"" + moves + "\", now(),\"" + winner + "\")");

            String gameID = LastGameID();
            String first_player_id = GetIDByLogin(first_player);
            String second_player_id = GetIDByLogin(second_player);

            Insert("insert into user_played_the_game values(" + first_player_id + "," + gameID + ")");
            Insert("insert into user_played_the_game values(" + second_player_id + "," + gameID + ")");
        }

        public static void UpdateRank(String first_player,
                                      String second_player,
                                      String winner)
        {

            Console.WriteLine(winner);
            int first_player_rank = int.Parse(GetUserInfo(first_player)[1]);
            int second_player_rank = int.Parse(GetUserInfo(second_player)[1]);
            int delta = (int)(Math.Abs(first_player_rank - second_player_rank) / 25);
            if (first_player == winner)
            {
                if (first_player_rank > second_player_rank)
                {
                    first_player_rank = first_player_rank + 25 - delta;
                    second_player_rank = second_player_rank - 25 + delta;
                }
                else
                {
                    first_player_rank = first_player_rank + 25 + delta;
                    second_player_rank = second_player_rank - 25 - delta;
                }
            }
            else
            {
                if (first_player_rank > second_player_rank)
                {
                    first_player_rank = first_player_rank - 25 + delta;
                    second_player_rank = second_player_rank + 25 - delta;
                }
                else
                {
                    first_player_rank = first_player_rank - 25 - delta;
                    second_player_rank = second_player_rank + 25 + delta;
                }
            }
            if (first_player_rank <= 500)
            {
                Database.UnlockAchievement(first_player, "2");
            }
            if (second_player_rank <= 500)
            {
                Database.UnlockAchievement(second_player, "2");
            }

            if (first_player_rank >= 1500)
            {
                Database.UnlockAchievement(first_player, "3");
            }
            if (second_player_rank >= 1500)
            {
                Database.UnlockAchievement(second_player, "3");
            }

            if (first_player_rank >= 2000)
            {
                Database.UnlockAchievement(first_player, "4");
            }
            if (second_player_rank >= 2000)
            {
                Database.UnlockAchievement(second_player, "4");
            }


            Insert("update user set rank = " + first_player_rank + " where login = \"" + first_player + "\"");
            Insert("update user set rank = " + second_player_rank + " where login = \"" + second_player + "\"");
        }

        public static List<List<String>> GetUserAchievements(String login)
        {
            List<List<String>> user_achievements = Select("select title from user, user_has_an_achievement,achievement where user_has_an_achievement.User_id = user.id and achievement.id = user_has_an_achievement.Achievement_id and login = \"" + login + "\"", 1);

            List<String> user_achievements_list = new List<string>();

            foreach (List<String> achievement in user_achievements)
            {
                user_achievements_list.Add(achievement[0]);
            }

            List<List<String>> all_achievements = GetAllAchievements();

            foreach(List<String> achievement in all_achievements)
            {
                if (user_achievements_list.Contains(achievement[1]))
                {
                    achievement[0] = "Yes";
                }
                else
                {
                    achievement[0] = "No";
                }
            }

            return all_achievements;
        }

        private static List<List<String>> GetAllAchievements()
        {
            return Select("select * from achievement", 3);
        }

        public static void UnlockAchievement(String login, String achievement_id)
        {
            String user_id = GetIDByLogin(login);

            Insert("insert into user_has_an_achievement values(" + achievement_id + ", " + user_id + ")");

            if (GetUserAchievements(login).Count == 7)
            {
                UnlockAchievement(login, "8");
            }
        }

        private static String LastGameID()
        {
            return Select("select max(id) from game", 1).First().First();
        }

        private static String GetIDByLogin(String login)
        {
            return Select("select id from user where login = \"" + login + "\"", 1).First().First();
        }

        public static List<List<String>> GetLeaderboard()
        {
            return Select("select login, rank, count(user_played_the_game.User_id), count(game.id), ifnull( count(game.id) / count(user_played_the_game.User_id), 0) * 100 from user left join user_played_the_game on user.id = user_played_the_game.User_id left join game on user_played_the_game.Game_id = game.id and user.login = game.winner group by login order by rank desc", 5);
        }

        public static List<List<String>> GetMatches(String login)
        {
            return Select("select game_id, login, player, date, winner, moves from user, user_played_the_game, game, (select login as player , game_id rival_game_id from user, user_played_the_game, game where user.id = user_played_the_game.User_id and game.id = user_played_the_game.Game_id) as rival where user.id = user_played_the_game.User_id and game.id = user_played_the_game.Game_id and game_id = rival_game_id and player <> login and login = \"" + login + "\" order by date desc", 6);
        }

        private static List<List<String>> Select(String query, int rowsCount)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            DbDataReader reader = null;
            List<List<String>> list = new List<List<string>>();
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new List<string>());
                    for(int row = 0; row < rowsCount; ++row)
                    {
                        list.Last().Add(reader.GetValue(row).ToString());
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return list;
        }

        private static void Insert(String query)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
     
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }
    }
}
