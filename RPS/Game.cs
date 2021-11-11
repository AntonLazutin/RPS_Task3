using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS
{
    class Game
    {
        public Game(string[] _args)
        {
            this.args = _args;
        }

        private string[] args;
        private int user_input;
        private string string_input;
        private Crypto crypto;
        public void Run()
        {
            while (true)
            {
                crypto = new Crypto(args.Length);
                Menu();
                ProcessUserInput();
                Console.WriteLine("CPU choice is {0}", this.args[crypto.CPUChoice]);
                Console.WriteLine(Rules.DetermineWinner(this.args, this.user_input, this.crypto.CPUChoice));
                Console.WriteLine("Secret key is {0}", crypto.Key);
            }
        }

        public void Menu()
        {
            Console.WriteLine("Hello!\nHMAC: {0}", crypto.HMAC);
            AvailableMoves();
            Console.WriteLine("0. Exit\n? Help");
        }
        public void AvailableMoves()
        {
            Console.WriteLine("Available moves:");
            for (int i = 0; i < this.args.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, this.args[i]);
            }
        }

        public void ProcessUserInput()
        {
            this.StringInputValidation();
            this.InputProcessing();
        }

        public void StringInputValidation()
        {
            Console.WriteLine("Enter your choice:");
            string _string_input = Console.ReadLine();
            while (_string_input == null)
                throw new ArgumentException("Invalid input");
            this.string_input = _string_input;
        }

        public void IntInputValidation()
        {
            while (!int.TryParse(this.string_input, out this.user_input))
            {
                ProcessWrongInput();
            }   
            OutOfRangeValidation();
            Console.WriteLine("Your choice is {0}", this.args[this.user_input]);
        }
        public void InputProcessing()
        {
            switch (this.string_input)
            {
                case "0": Environment.Exit(0); break;
                case "?": Console.WriteLine(Table.CreateTable(this.args)); break;
                default : this.IntInputValidation(); break;
            }
        }
        public void OutOfRangeValidation()
        {
            int temp = Int32.Parse(this.string_input);
            while (temp > args.Length || temp < 1)
            {
                ProcessWrongInput();
            }
            this.user_input = temp - 1;
        }
        public void ProcessWrongInput()
        {
            Console.WriteLine("Wrong input!\nExample: '{0}', '0', or '?'", crypto.CPUChoice + 1);
            Run();
        }
        public static void ArgsValidation(string[] args)
        {
            while (args.Length < 3 || (args.Length % 2) == 0 || args.Length == 0 || args == null ||
                (args.Distinct().Count() != args.Count()))
            {
                Console.WriteLine("Invalid args" + Environment.NewLine + @"Example: ""rock"" ""paper"" ""scissors""");
                Environment.Exit(1);
            }
        }
    }
}
