using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace VirusWPF.Models
{
    public class RectanglePointer
    {
        public int Id { get; set; }
        public Rectangle rectangle { get; set; }
        public Point pointer { get; set; }
        public TextBlock textBox = new TextBlock();
        public List<Line> lines = new List<Line>();
        public List<RectanglePointer> neighbours = new List<RectanglePointer>();
        private List<Person> Persons = new List<Person>();
        public HouseTypeEnum HouseTypeEnum { get; set; }

        public int PeoplesCount { get; set; }
        public int Healthy { get; set; }
        public int Infected { get; set; }
        public int Dead { get; set; }
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
        public void ReadAllasdsadsa()
        {
           PeoplesCount = Persons.Count;
           Healthy = GetHealthyPersonCount();
           Infected =  GetInfectedPersonCount();
           Dead =  GetDeadPersonCount();
        }
        private void generatePeaples(int min, int max)
        {
            maxPeapleAllowed = max;
            for (int i = min; i < max; i++)
            {
                Persons.Add(new Person(PeopleIdcounter));
                PeopleIdcounter++;
            }
        }
        public int GetPersonCount()
        {
            return Persons.Count;
        }
        public int GetHealthyPersonCount()
        {
            var counter = 0;
            foreach(Person person in Persons)
            {
                if (!person.Infected && !person.Dead)
                {
                    counter++;
                }
            }
            return counter;
        }
        public int GetInfectedPersonCount()
        {
            var counter = 0;
            foreach (Person person in Persons)
            {
                if (person.Infected && !person.Dead)
                {
                    counter++;
                }
            }
            return counter;
        }
        public int GetDeadPersonCount()
        {
            var counter = 0;
            foreach (Person person in Persons)
            {
                if (person.Dead)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
