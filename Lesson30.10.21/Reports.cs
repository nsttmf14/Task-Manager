using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson30._10._21
{
    class Reports
    {
        public string Report;
        public Worker Executor;
        public Reports(string report, Worker executor)
        {
            Report = report;
            Executor = executor; //автор отчёта
        }
        public override string ToString() //Абстракция
        {
            return $"{Report}\nAвтор отчёта: {Executor.Name}";
        }
    }
}
