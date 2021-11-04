using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson30._10._21
{
    class Task
    {
        public enum State
        {
            assigned, //назначена
            inwork, //в работе
            checking, //на проверке
            completed, //выполнена
            devolve, //делегировать
            dismiss //отклонить
        }
        public string Description;
        public Worker Initiator;
        public Worker Performer;
        public Stack<Reports> Reports;
        public State Status;

        public Task(string description)
        {
            Description = description;
            Status = State.assigned;
            Reports = new Stack<Reports>();
        }
        public override string ToString()
        {
            return $"{Description}. {Performer.Name} : {Status}";
        }
    }
}
