using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using static BlackYellow.MVC.Domain.Entites.Order;

namespace BlackYellow.MVC.Models
{
    public class OrderReportFilters : ReportFilters
    {

        public EStatusOrder[] Status { get; set; }


    }
}
