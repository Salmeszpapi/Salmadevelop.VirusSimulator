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
            InitialCountInfected();
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
            generatePeople(10,1100);
            //switch (HouseTypeEnum)
            //{
            //    case HouseTypeEnum.Hospital:
            //        generatePeople(50, 300);
            //        break;
            //    case HouseTypeEnum.House:
            //        generatePeople(1, 12);
            //        break;
            //    case HouseTypeEnum.WorkPlace:
            //        generatePeople(10, 400);
            //        break;
            //    case HouseTypeEnum.Store:
            //        generatePeople(4, 50);
            //        break;
            //    default:
            //        break;
            //}
        }
        public void ReadPeopleStatus()
        {
            PeoplesCount = persons.Count;
            GetInfectedAndHealthyPersonsCount();
        }
        private void generatePeople(int min, int max=50)
        {
            maxPeapleAllowed = max;

            for (int i = 0; i < new Random().Next(min,max); i++)
            {
                persons.Add(new Person(PeopleIdcounter));
                PeopleIdcounter++;
            }
        }

        public void GetInfectedAndHealthyPersonsCount()
        {
            HealthyCount = 0;
            InfectedCount = 0;
            for (int i = 0; i < persons.Count; i++)
            {
                if (persons[i] is not null && !persons[i].Infected && !persons[i].Dead)
                {
                    HealthyCount++;
                }
                else if (persons[i] is not null && persons[i].Infected && !persons[i].Dead)
                {
                    InfectedCount++;
                }
            }
            
        }
        public bool HasInfectedPerson()
        {
            for (int i = 0; i < persons.Count; i++)
            {
                if (persons[i].Infected && !persons[i].Dead)
                {
                    return true;
                }
            }
            return false;            
        }
        public void InitialCountInfected()
        {
            foreach(Person person in persons)
            {
                if(person.Infected)
                {
                    InfectedCount++;
                }
            }
        }
    }
}
