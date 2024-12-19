

namespace Homework_8
{
    enum StatusProject
    {
        Project,
        Execution,
        Closed

    }
    internal class Project
    {
        #region Поля
        public string Description { get; private set; }
        public DateTime DeadLine { get; private set; }
        public string Initiator { get; private set; }
        public string TeamLead { get; private set; }
        public StatusProject Status { get; private set; }
        private List<Task> Tasks;
        #endregion

        #region Конструктор
        public Project(string description, DateTime deadLine, string initiator, string teamLead)
        {
            Description = description;
            DeadLine = deadLine;
            Initiator = initiator;
            TeamLead = teamLead;
            Tasks = new List<Task>();
            Status = StatusProject.Project;
        }
        #endregion

        #region Методы
        public void AddTask(Task task)
        {
            if (Status == StatusProject.Project)
            {
                Tasks.Add(task);
                Console.WriteLine($"Задача \"{task.Description}\" добавлена в проект.");
            }
            else
            {
                Console.WriteLine("Невозможно добавить задачи. Проект уже в статусе 'Исполнение' или 'Закрыт'.");
            }
        }

        public void RemoveTask(Task task)
        {
            if (Status == StatusProject.Project && Tasks.Contains(task))
            {
                Tasks.Remove(task);
                Console.WriteLine($"Задача \"{task.Description}\" удалена из проекта.");
            }
            else
            {
                Console.WriteLine("Задачу можно удалить только в статусе 'Проект' и если она существует в проекте.");
            }
        }

        public void StartExecution()
        {
            if (Tasks.Count > 0)
            {
                Status = StatusProject.Execution;
                Console.WriteLine("Проект переведен в статус 'Исполнение'.");
            }
            else
            {
                Console.WriteLine("Невозможно перевести в статус 'Исполнение'. Добавьте хотя бы одну задачу.");
            }
        }

        public void CloseProject()
        {
            bool allTasksCompleted = true;

            foreach (var task in Tasks)
            {
                if (task.StatusTask != StatusTask.Completed)
                {
                    allTasksCompleted = false;
                    break;
                }
            }

            if (allTasksCompleted)
            {
                Status = StatusProject.Closed;
                Console.WriteLine("Проект успешно закрыт.");
            }
            else
            {
                Console.WriteLine("Не все задачи выполнены. Проект нельзя закрыть.");
            }
        }
        #endregion

    }
}
