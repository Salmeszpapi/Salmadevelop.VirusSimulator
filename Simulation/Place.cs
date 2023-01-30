using Simulation.Model;

namespace Simulation
{
    public class Place
    {
        public int ID { get; set; }
        public List<int> AdjencyNodes { get; set; }
        public int MaxPeople { get; set; }
        public List<People> peoples { get; set; }
        public PlaceTypeEnum placeName;
        private WorkTypeEnum workType;

        public Place()
        {
            peoples = new List<People>();
            var randomCreatePlaces = new Random().Next(16);
            switch (randomCreatePlaces)
            {
                case int n when n <= 6:
                    placeName = PlaceTypeEnum.Home;
                    MaxPeople = new Random().Next(6);
                    break;

                case int n when n <= 9:
                    placeName = PlaceTypeEnum.Workplace;
                    int newWorkplacetype = new Random().Next(3);
                    switch (newWorkplacetype)
                    {
                        case 0:
                            workType = WorkTypeEnum.Small;
                            MaxPeople = 5;
                            break;
                        case 1:
                            workType = WorkTypeEnum.Medium;
                            MaxPeople = 20;
                            break;
                        case 2:
                            workType = WorkTypeEnum.Big;
                            MaxPeople = 50;
                            break;
                    }
                    break;
                case int n when n <= 12:
                    placeName = PlaceTypeEnum.Store;
                    MaxPeople = new Random().Next(15);
                    break;
                case int n when n <= 14:
                    placeName = PlaceTypeEnum.Restaurant;
                    MaxPeople = new Random().Next(6);
                    break;
                case int n when n <= 15:
                    placeName = PlaceTypeEnum.Club;
                    MaxPeople = new Random().Next(40);
                    break;

                default:
                    Console.WriteLine("Grade is D");
                    break;
            }
        }

    }
}
