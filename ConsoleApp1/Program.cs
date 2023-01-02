using Simulation.Graph;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    internal class Program
    {
        private const int N = 50;
        static void Main(string[] args)
        {
            Graph asd = new Graph(N);

            asd.AddEdge(0, 2);
            asd.AddEdge(0, 3);
            asd.AddEdge(0, 4);
            asd.AddEdge(1, 3);
            asd.AddEdge(2, 4);
            asd.AddEdge(2, 5);
            asd.AddEdge(3, 7);
            asd.AddEdge(7, 20);
            asd.AddEdge(7, 21);
            asd.AddEdge(21, 22);
            asd.AddEdge(4, 8);

            asd.BFS();
        }
        
    }

}