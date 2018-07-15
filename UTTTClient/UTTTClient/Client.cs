using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UTTTClient
{
    class Client
    {
        const int port = 8888;
        const string address = "127.0.0.1";

        private static String token;

        private static String login;
        private static String rank;

        private static String selectedGame;

        public static void SetToken(String sessionToken)
        {
            token = sessionToken;
        }

        public static void SetLogin(String userLogin)
        {
            login = userLogin.ToUpper();
        }

        public static void SetRank(String userRank)
        {
            rank = userRank;
        }

        public static String GetLogin()
        {
            return login;
        }

        public static String GetToken()
        {
            return token;
        }

        public static String GetRank()
        {
            return rank;
        }

        public static void SelectGame(String game)
        {
            selectedGame = game.ToUpper();
        }

        public static String GetSelectedGame()
        {
            return selectedGame;
        }

        public static String SendMessage(String message)
        {
            TcpClient client = null;
            try
            {
                client = new TcpClient(address, port);
                NetworkStream stream = client.GetStream();
                byte[] data = Encoding.Unicode.GetBytes(message);

                stream.Write(data, 0, data.Length);

                data = new byte[64];
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = stream.Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable);

                message = builder.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Connection error";
            }
            finally
            {
                if (client != null)
                {
                    client.Close();
                }
            }
            return message;
        }
    }
}
