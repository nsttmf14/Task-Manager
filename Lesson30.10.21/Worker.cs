using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson30._10._21
{
    class Worker
    {
        public string Name;
        public Worker(string name) //конструктор для присваивания имени
        {
            Name = name;
        }
        public WorkType Type;
        public enum WorkType //род деятельности
        {
            customer = 1,
            teamlead, 
            executor 
        }
    }
}
