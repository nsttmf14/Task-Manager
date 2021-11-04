using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson30._10._21
{
    class Project
    {
        public string Description;
        public DateTime Deadline;
        public Worker Initiator;
        public Worker TeamLead;
        public List<Task> Tasks;
        public Status Standing;
        public enum Status
        {
            draft = 1, //проект
            execution, //исполнение
            closed //закрыт
        }
        public Project(string description, DateTime deadline, Worker initiator, Worker teamLead, int count)
        {
            Description = description; //Описание
            Deadline = deadline;
            Initiator = initiator;
            initiator.Type = Worker.WorkType.customer; //Заказчик
            TeamLead = teamLead;
            teamLead.Type = Worker.WorkType.teamlead;
            Tasks = new List<Task>();
            while (Tasks.Count != count) //Пока количество задач в листе не равняется введённому количеству задач, добавляем в него задачу
            {
                Tasks.Add(new Task(((Tasks.Count + 1)).ToString));
            }
            Standing = (Status)1; //Ставим статус 'Проект'
        }
        public string GetTasks() //Вывод текущих задач
        {
            string output = "";
            foreach (Task task in Tasks)
            {
                output += task + "\n";
            }
            return output;
        }
    }
}
