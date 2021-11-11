using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace RPS
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.ArgsValidation(args);
            Game game = new Game(args);
            game.Run();        
        }

    }
}

