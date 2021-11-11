using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS
{
    class Rules
    {
        public static string DetermineWinner(string[] args, int user, int pc)
        {
            if (user == pc)
                return "Draw";
            else if ((Math.Abs(user - pc) % 2) == 0)
                return user > pc ? "Lose" : "Win";
            return user > pc ? "Win" : "Loose";
        }
    }
}


   