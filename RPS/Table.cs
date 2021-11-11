using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace RPS
{
    class Table
    {
        public static ConsoleTable CreateTable(string[] args)
        {
            var raw = new string[args.Length + 1];
            raw[0] = @"PC \ User";
            for (int i = 0; i < args.Length; i++) raw[i + 1] = args[i];
            var table = new ConsoleTable(raw);
            for (int i = 1; i <= args.Length; i++)
            {
                var tempRaw = new string[args.Length + 1];
                tempRaw[0] = args[i - 1];
                for (int j = 1; j <= args.Length; j++) tempRaw[j] = Rules.DetermineWinner(args, j, i);
                table.AddRow(tempRaw);
            }
            return table;
        }
    }
}
