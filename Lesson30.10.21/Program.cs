using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson30._10._21
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            Worker[] staff = //Cоздание команды
            {
                new Worker("Кондрашин Андрей"), //1
                new Worker("Морозов Денис"), //2
                new Worker("Гусев Данил"), //3
                new Worker("Гимранов Родион"), //4
                new Worker("Галанжин Вадим"), //5
                new Worker("Эгамов Руслан"), //6
                new Worker("Гильман Данил"), //7
                new Worker("Чернов Роман"), //8
                new Worker("Кубатов Александр"), //9
                new Worker("Налетов Роман"), //10
            };

            Console.Write("Введите описание проекта: ");
            string descript = Console.ReadLine();

            Console.Write("Введите количество задач: ");
            int.TryParse(Console.ReadLine(), out int count);
            Project project = new Project(descript, new DateTime(), staff[0], staff[1], count); //Cоздание (первый участник команды становится заказчиком, второй тимлидом)

            Console.Write("Teamlead назначает задачи");
            for (int i = 0, j = 2; i < project.Tasks.Count; i++, j++)
            {
                project.Tasks[i].Initiator = project.Initiator; //Заказчик
                project.Tasks[i].Performer = staff[j]; //Прикрепление сотрудника к задаче
                if (j == staff.Length - 1)
                {
                    j = 2;
                }
            }


            Console.WriteLine(project.GetTasks());
            Console.WriteLine("Задачи распределены.");


            project.Standing++; //Переход проекта к статусу 'Исполнение'


            int Progress = 0;
            bool notDeleted = true;
            while (Progress < project.Tasks.Count)
            {
                for (int i = 0; i < project.Tasks.Count; i++)
                {
                    if (project.Tasks[i].Status == Task.State.assigned) //Статус задачи: назначена
                    {
                        if (LaunchChance(15)) //15% шанс запуска блока
                        {
                            if (LaunchChance(50))
                            {
                                project.Tasks[i].Status = Task.State.devolve; //50% задача будет делегированна
                            }
                            else
                            {
                                project.Tasks[i].Status = Task.State.dismiss; //50% задача будет отклонена
                            }
                        }
                        else
                        {
                            project.Tasks[i].Status = Task.State.inwork; //Статус задачи: в работе
                        }
                    }

                    else if (project.Tasks[i].Status == Task.State.devolve) //Если задача делегированна то она назначается новому исполнителю
                    {
                        project.Tasks[i].Performer = staff[rnd.Next(2, staff.Length - 1)];
                        project.Tasks[i].Status = Task.State.assigned;
                    }

                    else if (project.Tasks[i].Status == Task.State.inwork) //Если задача в работе, исполнитель пишет отчёт и задача переходит в статус проверки
                    {
                        if (LaunchChance(50))
                        {
                            project.Tasks[i].Reports.Push(new Reports(project.Tasks[i].Description, project.Tasks[i].Performer)); // Текст отчёта, автор (исполнитель)
                            project.Tasks[i].Status = Task.State.checking;
                        }
                    }

                    else if (project.Tasks[i].Status == Task.State.checking) //Если задача на проверке, то с шансом 50% она либо будет отмечена выполненной, либо останется в статусе проверки
                    {
                        if (LaunchChance(50))
                        {
                            Console.WriteLine($"{project.Tasks[i].Reports.Peek()} утверждён.");
                            project.Tasks[i].Status = Task.State.completed;
                            Progress++;
                        }
                    }

                    else if (project.Tasks[i].Status == Task.State.dismiss) //Если задача отклонена, то с шансом 50% она будет назначена другому сотруднику, либо удалена
                    {
                        if (LaunchChance(50))
                        {
                            project.Tasks[i].Performer = staff[rnd.Next(2, staff.Length - 1)];
                            project.Tasks[i].Status = Task.State.assigned;
                        }
                        else
                        {
                            project.Tasks.RemoveAt(i);
                            i--;
                            Console.WriteLine($"{project.Tasks[i].Description}. (задача удалена)");
                            notDeleted = false;
                        }
                    }

                    if (notDeleted)
                    {
                        Console.WriteLine(project.Tasks[i]);
                    }
                    notDeleted = true;
                }
            }

            project.Standing++; //Переход проекта к статусу 'Закрыт'

            Console.WriteLine("Проект и все его задачи выполнены.");

            Console.ReadKey();
        }
        static bool LaunchChance(int chance) //Метод шанса запуска
        {
            return (rnd.Next(1, (100 / chance)) == 1); //если получается 1, то = true, иначе = false
        }
    }

    }

