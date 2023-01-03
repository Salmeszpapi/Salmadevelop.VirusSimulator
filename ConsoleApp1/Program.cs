using Simulation.Graph;
using Simulation.Model;
namespace ConsoleApp1
{
    internal class Program
    {
        private const int N = 50;
        static void Main(string[] args)
        {
            Graph asd = new Graph(N);

            asd.BFS();
        }
        
    }

}