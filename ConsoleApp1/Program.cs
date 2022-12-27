using Simulation.Graph;

namespace ConsoleApp1
{
    internal class Program
    {
        private const int N = 10;
        static void Main(string[] args)
        {
            Graph asd = new Graph(N);
            //for(int i=0; i < N; i++)
            //{
            //    asd.AddEdge(i, N-i-1);
            //}
            asd.AddEdge(0, 2);
            asd.AddEdge(2, 3);
            asd.AddEdge(2, 4);
            asd.AddEdge(2, 5);

            asd.DepthSearching(0);
        }
        
    }

}