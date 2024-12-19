namespace Homework_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Project project = new Project(
                description: "Разработка нового мобильного приложения",
                deadLine: DateTime.Now.AddDays(30),
                initiator: "Заказчик Иванов",
                teamLead: "Тимлид Петров"
            );
            Console.WriteLine("Проект создан.");

            
            string[] team = { "Алексей", "Мария", "Сергей", "Наталья", "Дмитрий", "Ольга", "Иван", "Екатерина", "Анна", "Владимир" };

            
            Task[] tasks = new Task[10];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = new Task(
                    description: $"Задача {i + 1}: Разработка модуля {i + 1}",
                    deadLine: DateTime.Now.AddDays(15 + i),
                    initiator: "Тимлид Петров"
                );

               
                project.AddTask(tasks[i]);
            }

          
            project.StartExecution();

            
            for (int i = 0; i < tasks.Length; i++)
            {
                
                if (i == 3) 
                {
                    tasks[i].RejectTask();

                    
                    string newExecutor = team[(i + 1) % team.Length]; 
                    tasks[i].AssignExecutor(newExecutor);
                    tasks[i].StartAtWork();
                    Console.WriteLine($"Задача {i + 1} была отклонена и переназначена исполнителю {newExecutor}.");
                }
                else
                {
                    tasks[i].AssignExecutor(team[i]);
                    tasks[i].StartAtWork();
                }
            }

            
            for (int i = 0; i < tasks.Length; i++)
            {
                if (tasks[i].StatusTask == StatusTask.Assigned) continue; 

                Report report = new Report(
                    reportText: $"Отчет по задаче {tasks[i].Description}: выполнено успешно.",
                    executor: tasks[i].Executor
                );

                tasks[i].AddReport(report);

                
                report.Approve();
                tasks[i].MarkAsCompleted();
            }

            
            project.CloseProject();
            

        }
    }
}
