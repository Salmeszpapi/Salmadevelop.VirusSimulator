using Simulation.Graph;
namespace ConsoleApp1
{
    internal class Program
    {
        private const int N = 30;
        static void Main(string[] args)
        {
            Graph asd = new Graph(N);

            asd.BFS2();
            Console.WriteLine("-----------------------");
            asd.BFS3();
            var result = asd.PlacePeapleIntoPlaces();
            Console.WriteLine("asd");
        }

    }

}