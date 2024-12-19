
namespace Homework_8
{

    enum ReportStatus
    {
        OnCheck,
        Approved,
        Revision

    }


    internal class Report
    {
        #region Поля
        public string ReportText { get; private set; }
        public DateTime DateCompletion { get; private set; }
        public string Executor { get; private set; }
        public ReportStatus Status { get; private set; }

        #endregion

        #region Конструктор
        public Report(string reportText, string executor)
        {
            ReportText = reportText;
            Executor = executor;
            DateCompletion = DateTime.Now;
            Status = ReportStatus.OnCheck;
        }
        #endregion

        #region Методы
        public void Approve()
        {
            Status = ReportStatus.Approved;
            Console.WriteLine("Отчет утвержден.");
        }

        public void ReturnRevision(string newReportText)
        {
            Status = ReportStatus.Revision;
            ReportText = newReportText;
            DateCompletion = DateTime.Now;
            Console.WriteLine("Отчет отправлен на доработку.");
        }
        #endregion
    }
}
