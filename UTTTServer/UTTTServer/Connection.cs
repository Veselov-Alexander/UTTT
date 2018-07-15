using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UTTTServer
{
    class Connection
    {
        public TcpClient client;


        public Connection(TcpClient tcpClient)
        {
            client = tcpClient;
        }

        public void Process()
        {
            NetworkStream stream = null;
            try
            {
                stream = client.GetStream();
                byte[] data = new byte[64];
                StringBuilder builder = new StringBuilder();
                int bytes = 0;

                do
                {
                    bytes = stream.Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable);

                string message = builder.ToString();

                message = HandleMessage(message);

                data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
                if (client != null)
                {
                    client.Close();
                }
            }
        }

        private String HandleMessage(String message)
        {
            Server.AppendLog(DateTime.Now.ToString().Split(' ')[1] + ":  " + message);

            String[] tokens = message.Split(';');

            switch (tokens[0])
            {
                case "LogIn":
                    if (Database.LogIn(tokens[1], tokens[2]))
                    {
                        String token = SignGenerator.GetSign(tokens[1] + tokens[2] + new Random().Next());
                        Server.AddSession(token, tokens[1]);
                        return token;
                    }
                    else
                    {
                        return "ERROR";
                    }


                case "SignIn":
                    if (Database.SignIn(tokens[1], tokens[2]))
                    {
                        String token = SignGenerator.GetSign(tokens[1] + tokens[2] + new Random().Next());
                        Server.AddSession(token, tokens[1]);
                        return token;
                    }
                    else
                    {
                        return "ERROR";
                    }


                case "getUserInfo":
                    String login = Server.GetUserByToken(tokens[1]);
                    List<String> info = Database.GetUserInfo(login);
                    return info[0] + ";" + info[1];


                case "createRoom":
                    login = Server.GetUserByToken(tokens[1]);
                    Server.AddRoom(login, tokens[2], tokens[3]);
                    break;


                case "getRooms":
                    String roomsInfo = Server.GetRooms();
                    return (roomsInfo.Length > 3 ? roomsInfo : "null");


                case "getRoomInfo":
                    return Server.GetRoomInfo(tokens[1]);


                case "sendMessage":
                    Server.AddMessageToChat(tokens[1], tokens[2], tokens[3]);
                    break;


                case "acceptGame":
                    Server.BeginGame(tokens[1], Server.GetUserByToken(tokens[2]));
                    break;

                case "cancelGame":
                    Server.DeleteRoom(tokens[1]);
                    break;

                case "setMove":
                    Server.SetMove(tokens[1], tokens[2]);
                    break;

                case "endGame":
                    Server.EndGame(tokens[1], tokens[2]);
                    break;

                case "getLeaderboard":
                    return Server.getLeaderboard();

                case "getMatches":
                    return Server.getMatches(tokens[1]);

                case "getAchievements":
                    return Server.getAchievements(tokens[1]);

            }
            
            return "DONE";
        }
    }
}
