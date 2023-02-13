using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<model1> list1 = new List<model1>()
            {
                new model1 {id=1,name="Parth",Bdate=28},
                new model1 {id=2,name="Ruchit",Bdate=2},
                new model1 {id=3,name="Deep",Bdate=22},
                new model1 {id=4,name="Parshav",Bdate=10},
            };

            List<model2> list2 = new List<model2>()
            {
                new model2 {id=1,name="Farman",Bdate=30},
                new model2 {id=2,name="Soumy",Bdate=20},
                new model2 {id=3,name="Mahaveer",Bdate=5},
                new model2 {id=4,name="Deep",Bdate=22},
            };

            Console.WriteLine("------------------UniqueData----------------");
            foreach (var a in list1.Select(a => a.name).Union(list2.Select(a => a.name)).Distinct()) 
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("------------------Show List1 data not have on List2----------------");
            foreach (var ans in (from item in list1.Select(x=>x.name)where !list2.Any(x=>x.name==item)select item).ToList())
            {
                Console.WriteLine(ans);
            }

            Console.WriteLine("------------------Show List2 data not have on List1----------------");
            foreach (var ans in (from item in list2 .Select(x => x.name) where !list1.Any(x => x.name == item) select item).ToList())
            {
                Console.WriteLine(ans);
            }

            Console.WriteLine("------------------Show List2 data also have on List1----------------");
            foreach (var ans in (from item in list2.Select(x => x.name) where list1.Any(x => x.name == item) select item).Concat(list2.Select(x=>x.name)))
            {
                Console.WriteLine(ans);
            }


            
            Console.ReadLine();
        }

        
    }
    public class model1
    {
        public int id { get; set; }
        public string name { get; set; }
        public int Bdate { get; set; }
    }
    public class model2
    {
        public int id { get; set; }
        public string name { get; set; }
        public int Bdate { get; set; }
    }
}
