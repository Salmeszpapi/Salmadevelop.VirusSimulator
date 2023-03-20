using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VirusSimulator_UI.Models
{
    public class RectanglePointer
    {
        public int Id { get; set; }
        public Rectangle rectangle { get; set; }
        public Point pointer { get; set; }
        public TextBlock textBox = new TextBlock();
        public List<Line> lines = new List<Line>();
        public List<RectanglePointer> neighbours = new List<RectanglePointer>();
        public List<Person> persons = new List<Person>();
        public HouseTypeEnum HouseTypeEnum { get; set; }
        public int PeoplesCount { get; set; }
        public int HealthyCount { get; set; }
        public int InfectedCount { get; set; }
        public int DeadCount { get; set; }
        public int PeopleIdcounter { get; set; }

        private int maxPeapleAllowed;
        public RectanglePointer(int Id, Rectangle rectangle, Point pointer, int peopleIdcounter) 
        {
            this.Id = Id;
            this.pointer = pointer;
            this.rectangle = rectangle;
            this.PeopleIdcounter = peopleIdcounter;
            SetHouseType();
            FillRectngleWithPeaople();
        }

        private void SetHouseType()
        {
            switch (new Random().Next(4))
            {
                case 0:
                    HouseTypeEnum = HouseTypeEnum.Hospital;
                    break;
                case 1:
                    HouseTypeEnum = HouseTypeEnum.House;
                    break;
                case 2:
                    HouseTypeEnum = HouseTypeEnum.WorkPlace;
                    break;
                case 3:
                    HouseTypeEnum= HouseTypeEnum.Store;
                    break;
                default:
                    break;
            }
        }

        private void FillRectngleWithPeaople()
        {
            switch (HouseTypeEnum) 
            {
                case HouseTypeEnum.Hospital:
                    generatePeaples(50,300);
                    break;
                case HouseTypeEnum.House:
                    generatePeaples(1,12);
                    break;
                case HouseTypeEnum.WorkPlace:
                    generatePeaples(10,400);
                    break;
                case HouseTypeEnum.Store:
                    generatePeaples(4,50);
                    break;
                default:
                    break;
            }
        }
        public void ReadPeopleStatus()
        {
            PeoplesCount = persons.Count;
            var myList = GetInfectedAndHealthyPersonsCount();
            HealthyCount = myList[0];
            InfectedCount = myList[1];
        }
        private void generatePeaples(int min, int max)
        {
            maxPeapleAllowed = max;
            for (int i = min; i < max; i++)
            {
                persons.Add(new Person(PeopleIdcounter));
                PeopleIdcounter++;
            }
        }


        public List<int> GetInfectedAndHealthyPersonsCount()
        {
            var infected = 0;
            var healthy = 0;
            for (int i = 0; i < persons.Count; i++)
            {
                if (persons[i] is not null && !persons[i].Infected && !persons[i].Dead)
                {
                    healthy++;
                }
                else if (persons[i] is not null && persons[i].Infected && !persons[i].Dead)
                {
                    infected++;
                }
            }
            return new List<int>() { healthy, infected };
        }
        public bool HasInfectedPerson()
        {
            for (int i = 0; i < persons.Count; i++)
            {
                if (persons[i].Infected)
                {
                    return true;
                }
            }
            return false;            
        }
    }
}
