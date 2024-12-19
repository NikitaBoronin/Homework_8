

namespace Homework_8
{
    internal class TaskAssigner
    {
        #region Поле
        public string Name { get; private set; }
        #endregion
        #region Конструктор
        public TaskAssigner(string name)
        {
            Name = name;
        }
        #endregion

        #region Метод
        public void AssignTask(Task task, string executor)
        {
            if (task.Executor == null)
            {
                task.AssignExecutor(executor);
                Console.WriteLine($"{Name} назначил задачу \"{task.Description}\" исполнителю {executor}.");
            }
            else
            {
                Console.WriteLine("Невозможно назначить задачу. Она уже имеет исполнителя.");
            }
        }
        #endregion

    }
}
