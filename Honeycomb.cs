using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCCCCC
{
    internal class Honeycomb
    {
        public string[] Input { get; set; }
        public Honeycomb(string[] input)
        {
            Input = input;
        }
        public int CellCount;

        public int CountOs(string[] input)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for (int n = 0; n < input[i].Length; n++)
                {
                    if (input[i][n] == 'O')
                    {
                        count++;
                    }
                }

            }

            return count;
        }
        public string CountOsAdvanded()
        {
            return ((Input.Length * Input[0].Length) / 2).ToString();
        }
        public bool GetNeigbourCells()
        {
            int[] wPos = GetPosOfW();

            return isBlocked(wPos[1], wPos[0]);


            /*var s = GetSurroundingStrings(Input, wPos[1], wPos[0]);
            int cnt = CountOs(s);*/
        }

        public int foo()
        {//(int)Math.Max(Math.Min(Math.Round(Math.Sin(i) * 2 + w[1], 0), Input[0].Length), 0)
            int[] w = GetPosOfW();
            int count = 0;
            double[] myy = { 0, 1, 1, 0, -1, -1 };
            for (double i = 0; i < 6; i++)
            {
                int x = (int)Math.Round(Math.Cos(Math.PI / 3 * i) * 2 + w[0]);
                int y = (int)Math.Round(myy[Convert.ToInt32(i)] + w[1], 0);

                if (Input[x][y] == 'O')
                {
                    count++;
                }
            }
            return count;
        }

        private bool check()
        {
            bool isFree = true;
            int[] w = GetPosOfW();
            for (int i = w[0]; i < Math.Min(Input[0].Length - w[0], Input.Length - w[1]); i++)
            {
                if (Input[i][i] == 'X')
                {
                    isFree = false;
                }
            }
            for (int i = w[0]; i < Math.Min(Input[0].Length - w[0], w[1] - Input.Length); i++)
            {
                if (Input[i * -1][i] == 'X')
                {
                    isFree = false;
                }
            }
            for (int i = w[0]; i < Math.Min(w[0] - Input[0].Length, Input.Length - w[1]); i++)
            {
                if (Input[i][i * -1] == 'X')
                {
                    isFree = false;
                }
            }
            for (int i = w[0]; i < Math.Min(w[0] - Input[0].Length, w[1] -  Input.Length); i++)
            {
                if (Input[i * -1][i * -1] == 'X')
                {
                    isFree = false;
                }
            }

            for(ket)

            return isFree;
        }

        public int[] GetPosOfW()
        {
            int[] ret = new int[2];
            for (int i = 0; i < Input.Length; i++)
            {
                for (int n = 0; n < Input[i].Length; n++)
                {
                    if (Input[i][n] == 'W')
                    {
                        ret[0] = i;
                        ret[1] = n;
                        return ret;
                    }
                }

            }
            return ret;
        }
        public string[] ShringArround(int x, int y)
        {//Math.Max(Math.Min(y + i, 0), Input[0].Length)
            var array = Input;
            var returnVal = new string[3];
            int newX;
            int newY;
            for (int i = -1; i <= 1; i++)
            {
                returnVal[i + 1] = $"{array[y + i][x - 1]}{array[y + i][x]}{array[y + i][x + 1]}";
            }
            returnVal[1] = $"{array[y][x - 2]}{array[y][x - 1]}{array[y][x]}{array[y][x - 1]}{array[y][x - 2]}";
            foreach (string s in returnVal)
            {
                Console.WriteLine(s);
            }
            return returnVal;
        }
        public string[] GetSurroundingStrings(string[] input, int x, int y)
        {
            string[] result = new string[3];

            // first line
            if (y > 0 && x > 0 && x < input[y - 1].Length - 1)
                result[0] = input[y - 1][x - 1].ToString() + input[y - 1][x].ToString() + input[y - 1][x + 1].ToString();
            else
                result[0] = null;

            // second line
            if (x > 1 && x < input[y].Length - 1)
                result[1] = input[y][x - 2].ToString() + input[y][x - 1].ToString() + input[y][x].ToString() + input[y][x + 1].ToString() + input[y][x + 2].ToString();
            else
                result[1] = null;

            // third line
            if (y < input.Length - 1 && x > 0 && x < input[y + 1].Length - 1)
                result[2] = input[y + 1][x - 1].ToString() + input[y + 1][x].ToString() + input[y + 1][x + 1].ToString();
            else
                result[2] = null;

            return result;
        }
        public bool isBlocked(int x, int y)
        {
            //check side
            bool result = true;
            for (int i = 0; i < Input[y].Length; i++)
            {
                if (Input[y][i] == 'X') result = false;
                if (Input[y][i] == 'W' && result == true) return true;
                else if (Input[y][i] == 'W') result = true;
            }
            if(result) return true;
            var stair = Stair(x - y, true);
            result = true;
            foreach (char  c in stair)
            {
                if (c == 'X') result = false;
                if (c == 'W' && result == true) return true;
                else if(c == 'W') result = true;
            }
            stair = Stair(x + y, false);
            foreach (char c in stair)
            {
                if (c == 'X') result = false;
                if (c == 'W' && result == true) return true;
                else if (c == 'W') result = true;
            }
            if (result) return true;
            return false;
        }

        public string Stair(int start, bool directionX)
        {
            string tmp = "";
            int y = 0;
            if (directionX)
            {
                for (int x = start; x < Input.GetLength(0); x++)
                {
                    tmp += Input[x][++y];
                }
            } else
            {
                for(int x = Input.GetLength(0); x >= start; x--)
                {
                    tmp += Input[x][++y];
                }
            }

            return tmp;
        }
    }
}
