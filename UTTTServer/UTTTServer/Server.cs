using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UTTTServer
{
    class Server
    {
        const int port = 8888;
        static TcpListener listener;
        static bool isRunning = true;

        static String logMessages;

        private static Dictionary<String, String> sessions;
        private static Dictionary<String, Room> rooms;


        public static void Run()
        {
            sessions = new Dictionary<string, string>();
            rooms = new Dictionary<string, Room>();

            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
                listener.Start();

                while (isRunning)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    Connection clientObject = new Connection(client);

                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (listener != null)
                {
                    listener.Stop();
                }
            }
        }

        public static void Close()
        {
            isRunning = false;
            if (listener != null)
            {
                listener.Stop();
            }
        }

        public static void AddRoom(String creator, String game_time, String ranked)
        {
            DeleteRoom(creator);
            rooms.Add(creator, new Room(creator, game_time, ranked));
            
        }

        public static void DeleteRoom(String creator)
        {
            if (rooms.Keys.Contains(creator))
            {
                rooms.Remove(creator);
            }
        }

        public static void EndGame(String creator, String winner)
        {
            if (rooms.Keys.Contains(creator))
            {
                rooms[creator].EndGame(winner);
            }
        }

        public static void BeginGame(String creator, String rival)
        {
            rooms[creator].BeginGame(rival);
        }

        public static void UpdateTime()
        {
            foreach (Room room in rooms.Values)
            {
                room.UpdateGame();
            }
        }

        public static void SetMove(String creator, String move)
        {
            rooms[creator].SetMove(move);
        }

        public static String getLeaderboard()
        {
            String response = String.Empty;
            foreach (List<String> list in Database.GetLeaderboard())
            {
                foreach (String attribute in list)
                {
                    response += attribute + ";";
                }
                response = response.Substring(0, response.Length - 1);
                response += "|";
            }
            return response.Substring(0, response.Length - 1);
        }

        public static String getAchievements(String login)
        {
            String response = String.Empty;
            foreach (List<String> list in Database.GetUserAchievements(login))
            {
                foreach (String attribute in list)
                {
                    response += attribute + ";";
                }
                response = response.Substring(0, response.Length - 1);
                response += "|";
            }
            return response.Substring(0, response.Length - 1);
        }

        public static String getMatches(String login)
        {
            String response = String.Empty;
            foreach (List<String> list in Database.GetMatches(login))
            {
                foreach (String attribute in list)
                {
                    response += attribute + ";";
                }
                response = response.Substring(0, response.Length - 1);
                response += "|";
            }
            return response.Substring(0, response.Length - 1);
        }

        public static String GetRooms()
        {
            String roomsList = String.Empty;
            foreach (Room room in rooms.Values)
            {
                roomsList += room.ShortRoomInfo() + "?";
            }
            return roomsList;
        }

        public static String GetRoomInfo(String creator)
        {
            if (rooms.Keys.Contains(creator))
            {
                return rooms[creator].FullRoomInfo();
            }
            return "gameIsCanceled";
        }

        public static void AddMessageToChat(String room, String who, String message)
        {
            rooms[room].AddMessage(who, message);
        }

        public static void AddSession(String token, String login)
        {
            sessions.Add(token, login);
        }

        public static String GetUserByToken(String token)
        {
            return sessions[token];
        }

        public static void AppendLog(String text)
        {
            logMessages += text + "\r\n";
        }

        public static String PushLog()
        {
            String logCopy = logMessages;
            logMessages = String.Empty;

            return logCopy;
        }
    }
}
