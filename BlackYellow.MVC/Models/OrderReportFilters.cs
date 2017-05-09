using static BlackYellow.MVC.Domain.Entites.Order;

namespace BlackYellow.MVC.Models
{
    public class OrderReportFilters : ReportFilters
    {

        public EStatusOrder[] Status { get; set; }


    }
}
