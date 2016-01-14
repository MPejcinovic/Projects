using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomskiProjekt.Algorithms
{
    public class SHA3
    {
        private int _bitrate;
        private int _capacity;
        private string _text;
        private int _residient;
        private double _word;
        private int _numRounds;
        private string _hash;

        public int Bitrate
        {
            get
            {
                return _bitrate;
            }
            set
            {
                _bitrate = value;
            }
        }

        public int Capacity
        {
            get
            {
                return _capacity;
            }
            set
            {
                _capacity = value;
            }
        }

        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        public int Residient
        {
            get
            {
                return _residient;
            }
            set
            {
                _residient = value;
            }
        }

        public double Word
        {
            get
            {
                return _word;
            }
            set
            {
                _word = value;
            }
        }

        public int NumRounds
        {
            get
            {
                return _numRounds;
            }
            set
            {
                _numRounds = value;
            }
        }

        public string Hash
        {
            get
            {
                return _hash;
            }
            set
            {
                _hash = value;
            }
        }

        private static ulong[] ROUND_CONST = { 0x0000000000000001, 0x0000000000008082, 0x800000000000808aL, 
								              0x8000000080008000L, 0x000000000000808bL, 0x0000000080000001L,
								              0x8000000080008081L, 0x8000000000008009L, 0x000000000000008aL,
								              0x0000000000000088L, 0x0000000080008009L, 0x000000008000000aL, 
								              0x000000008000808bL, 0x800000000000008bL, 0x8000000000008089L,
								              0x8000000000008003L, 0x8000000000008002L, 0x8000000000000080L, 
								              0x000000000000800aL, 0x800000008000000aL, 0x8000000080008081L,
								              0x8000000000008080L, 0x0000000080000001L, 0x8000000080008008L };

        private static int[,] ROTATION_OFFSET = {{0, 36, 3, 41, 18},
				                                {1, 44, 10, 45, 2},
								                {62, 6, 43, 15, 61},
								                {28, 55, 25, 21, 56},
								                {27, 20, 39, 8, 14}};

        public SHA3(int bitrate, int capacity, string text)
        {
            Bitrate = bitrate;
            Capacity = capacity;
            Text = text;
            Residient = Bitrate + Capacity;
            Word = Residient / 25;
            NumRounds = 12 + 2 * Convert.ToInt32(Math.Log(Word) / Math.Log(2));
        }

        public void ComputeHash(string text) 
        {
            Text = text;
            ComputeHash();
        }

        public void ComputeHash()
        {
            long[,] matrix = new long[5, 5];

            var hexString = BitConverter.ToString(Encoding.UTF8.GetBytes(Text)).Replace("-", "");
            var expandedText = GetPadding(hexString);

            Hash = SqueezingPhase(KeccakFunction(ApsorbingPhase(matrix, expandedText)));
        }

        public long[,] KeccakFunction(long[,] matrix)
        {
            for (int i = 0; i < NumRounds; i++)
            {
                matrix = startRound(matrix, i);
            }
            return matrix;
        }

        public string GetPadding(string text)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append(text);
            
            if (sb.Length % (Bitrate / 4) != Bitrate / 4 - 2)
            {
                sb.Append("01");
                while (sb.Length % (Bitrate / 4) != (Bitrate / 4 - 2))
                {
                    sb.Append("00");
                }
                sb.Append("80");
            }
            else
            {
                sb.Append("81");
            }

            for (int i = 0; i < 64; i++)
            {
                sb.Append("00");
            }

            return Convert.ToString(sb);
        }

        public long[,] ApsorbingPhase(long[,] matrix, string text)
        {
            int len = 0;

            string[,] tmp = new string[5, 5];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    StringBuilder sb = new StringBuilder();

                    len += 16;

                    string t = text.Substring(len - 16, 16);

                    for (int l = 16; l > 0; l = l - 2)
                    {
                        sb.Append(t.Substring(l - 2, 2));
                    }

                    tmp[j, i] = Convert.ToString(sb);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    long bi = Convert.ToInt64(tmp[i, j], 16);
                    matrix[i, j] = matrix[i, j] ^ bi;
                }
            }
            return matrix;
        }

        public long[,] startRound(long[,] matrix, int k)
        {
            long[,] B = new long[5, 5];
            long[] C = new long[5];
            long[] D = new long[5];


            for (int i = 0; i < 5; i++)
            {
                C[i] = matrix[i, 0] ^ matrix[i, 1] ^ matrix[i, 2] ^ matrix[i, 3] ^ matrix[i, 4];
            }
            for (int i = 0; i < 5; i++)
            {
                D[i] = C[(i + 4) % 5] ^ (long)ROL((ulong)C[(i + 1) % 5], 1);
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = matrix[i, j] ^ D[i];
                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    B[j, (2 * i + 3 * j) % 5] = (long)ROL((ulong)matrix[i, j], ROTATION_OFFSET[i, j]);
                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = B[i, j] ^ ((~B[(i + 1) % 5, j]) & B[(i + 2) % 5, j]);
                }
            }

            matrix[0, 0] = matrix[0, 0] ^ (long)ROUND_CONST[k];
            return matrix;
        }

        public string SqueezingPhase(long[,] matrix)
        {

            StringBuilder Z = new StringBuilder();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    StringBuilder sb = new StringBuilder();
                    StringBuilder sb1 = new StringBuilder();

                    String tmp = matrix[j, i].ToString("X");

                    if (tmp.Length != 16)
                    {
                        for (int k = 0; k < 16 - tmp.Length; k++)
                        {
                            sb1.Append("0");
                        }
                        tmp = sb1.ToString() + tmp;
                    }
                    for (int l = 16; l > 0; l = l - 2)
                    {
                        sb.Append(tmp.Substring(l - 2, 2));
                    }
                    Z.Append(sb.ToString());
                }
            }
            string result = Convert.ToString(Z);
            return result.Substring(0, 64);
        }

        protected ulong ROL(ulong a, int offset)
        {
            if (offset == 0)
                return a;
            return (((a) << ((offset) % 64)) ^ ((a) >> (64 - ((offset) % 64))));
        }
    }
}