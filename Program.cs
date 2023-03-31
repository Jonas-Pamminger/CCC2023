// Hello World! program
namespace CCCCCC
{
    class MainClass {         
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Run(File.ReadAllLines($"input-{i}.txt"), i);
            }
        }

        static void Run(string[] input, int time)
        {
            string[] result = null;
            
            File.WriteAllLines($"output-{time}.txt", result);
        }
    }
}