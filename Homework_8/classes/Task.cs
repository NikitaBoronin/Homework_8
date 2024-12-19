

namespace Homework_8
{
    enum StatusTask
    {
        Assigned,
        AtWork,
        OnCheck,
        Completed

    }


    internal class Task
    {
        #region Поля
        public string Description { get; private set; }
        public DateTime DeadLine { get; private set; }
        public string Initiator { get; private set; }
        public string Executor { get; private set; }
        public StatusTask StatusTask { get; private set; }
        public Report TaskReport { get; private set; }


        #endregion

        #region Конструктор
        public Task(string description, DateTime deadLine, string initiator)
        {
            Description = description;
            DeadLine = deadLine;
            Initiator = initiator;
            StatusTask = StatusTask.Assigned;
        }
        #endregion

        #region Методы
        public void AssignExecutor(string executor)
        {
            if (Executor == null)
            {
                Executor = executor;
                Console.WriteLine($"Задача \"{Description}\" назначена исполнителю {executor}.");
            }
            else
            {
                Console.WriteLine("У задачи уже есть исполнитель.");
            }
        }

        public void StartAtWork()
        {
            if (StatusTask == StatusTask.Assigned && Executor != null)
            {
                StatusTask = StatusTask.AtWork;
                Console.WriteLine($"Задача \"{Description}\" переведена в статус 'В работе'.");
            }
            else
            {
                Console.WriteLine("Задачу нельзя взять в работу.");
            }
        }

        public void DelegateTask(string newExecutor)
        {
            if (StatusTask == StatusTask.Assigned)
            {
                Executor = newExecutor;
                Console.WriteLine($"Задача \"{Description}\" делегирована новому исполнителю: {newExecutor}.");
            }
            else
            {
                Console.WriteLine("Делегировать можно только задачу со статусом 'Назначена'.");
            }
        }

        public void RejectTask()
        {
            if (StatusTask == StatusTask.Assigned)
            {
                Executor = null;
                Console.WriteLine($"Задача \"{Description}\" отклонена и доступна для повторного назначения.");
            }
            else
            {
                Console.WriteLine("Отклонить можно только задачу со статусом 'Назначена'.");
            }
        }

        public void AddReport(Report report)
        {
            if (StatusTask == StatusTask.AtWork)
            {
                TaskReport = report;
                StatusTask = StatusTask.OnCheck;
                Console.WriteLine($"Отчет добавлен к задаче \"{Description}\", статус задачи: 'На проверке'.");
            }
            else
            {
                Console.WriteLine("Отчет можно добавить только к задаче в статусе 'В работе'.");
            }
        }

        public void MarkAsCompleted()
        {
            if (StatusTask == StatusTask.OnCheck && TaskReport != null && TaskReport.Status == ReportStatus.Approved)
            {
                StatusTask = StatusTask.Completed;
                Console.WriteLine($"Задача \"{Description}\" выполнена.");
            }
            else
            {
                Console.WriteLine("Задачу можно завершить только после утверждения отчета.");
            }
        }
        #endregion

    }
}
