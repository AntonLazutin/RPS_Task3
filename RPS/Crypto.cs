using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace RPS
{
    class Crypto
    {
        public Crypto(int _args_len)
        {
            this.args_len = _args_len;
            this.rng = RandomNumberGenerator.Create();
            this.cpuchoice = GenerateInt(args_len);
            this.key = GenerateKey();
            this.hmac = HMACHASH();     
        }

        private RandomNumberGenerator rng;
        private string key;
        private const int bit_len = 128;
        private int args_len;
        private int cpuchoice;
        private string hmac;

        public RandomNumberGenerator RNG{ get { return rng; } } 

        public int Bit_Len { get { return bit_len; } }  

        public int Args_len { get { return args_len; } } 

        public int CPUChoice { get { return cpuchoice; } }

        public string Key { get { return key; } }    

        public string HMAC { get { return hmac; } }

        public string GenerateKey()
        {
            byte[] secretkey = new byte[Bit_Len / 8];
            RNG.GetBytes(secretkey);
            return BitConverter.ToString(secretkey).Replace("-", string.Empty).ToUpper();
        }

        public int GenerateInt(int max)
        {
            byte[] rand = new byte[4];
            RNG.GetBytes(rand);
            return BitConverter.ToUInt16(rand, 0) % max;
        }

        public string HMACHASH()
        {
            byte[] bkey = Encoding.Default.GetBytes(this.key);
            using (var hmac = new HMACSHA256(bkey))
            {
                var bhash = hmac.ComputeHash(Encoding.Default.GetBytes(this.CPUChoice.ToString()));
                return BitConverter.ToString(bhash).Replace("-", string.Empty);
            }
        }
    }
}

