using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;

namespace UTTTClient
{
    class Bot
    {
        [DllImport("UTTT_AI.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void FromDLL(string input, StringBuilder result);

        private BotLevel botLevel;
        private Player botColor;

        private int difficulty;

        public Bot (BotLevel level,  Player player)
        {
            botLevel = level;
            botColor = player;
            File.Delete("Game.ai");
        }

        public static String DLLInfo(String input)
        {
            StringBuilder builder = new StringBuilder(1000);
            FromDLL(input, builder);

            return builder.ToString();
        }

        public String NextMove(String state)
        {
            String move = Color();

            switch (botLevel)
            {
                case BotLevel.EASY:
                    move += EasyBot(state);
                    break;

                case BotLevel.NORMAL:
                    move += NormalBot(state);
                    break;

                case BotLevel.HARD:
                    move += HardBot(state);
                    break;
            }

            return move;
        }

        public void ChangeDifficulty(int diff)
        {
            difficulty = diff;
        }

        public String Analysis(String state, bool update = false)
        {
            return Bot.DLLInfo(difficulty.ToString() + "#" + state);
        }

        private String EasyBot(String state)
        {
            return Bot.DLLInfo("0-" + state);
        }

        private String NormalBot(String state)
        {
            return Bot.DLLInfo("1-" + state);
        }

        private String HardBot(String state)
        {
            return Bot.DLLInfo("2-" + state);
        }




        private String Color()
        {
            if (botColor == Player.X)
            {
                return "X";
            }
            else
            {
                return "O";
            }
        }

    }

    public enum BotLevel
    {
        EASY, NORMAL, HARD
    }
}
