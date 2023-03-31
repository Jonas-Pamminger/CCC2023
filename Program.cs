// Hello World! program
namespace CCCCCC
{
    class MainClass
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 6; i++)
            {
                Run(File.ReadAllLines($"level3_{i}.in"), i);
            }
        }

        static void Run(string[] input, int time)
        {
            int length = Convert.ToInt32(input[0]);
            string[] result = new string[length];
            string[] currentComp = new string[1000];
            int count = 0;
            var resultCount = -1;
            for(int i = 2; i < input.Length; i++)
            {
               if (input[i].Length != 0)
                {
                    currentComp[count] = input[i];
                    count++;
                }
                else
                {
                    currentComp = currentComp.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    Honeycomb h = new Honeycomb(currentComp);
          
                    result[++resultCount] = h.GetNeigbourCells().ToString();
                    count = 0;
                    currentComp = new string[1000];
                }
            }
            Honeycomb h1 = new Honeycomb(currentComp);
            result[++resultCount] = h1.GetNeigbourCells().ToString();
            File.WriteAllLines($"level3_{time}", result);
        }
    }
}