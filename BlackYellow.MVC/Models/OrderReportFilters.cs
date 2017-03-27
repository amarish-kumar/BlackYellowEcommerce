using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BlackYellow.MVC.Models
{
    public class OrderReportFilters : ReportFilters
    {

        public enum eStatusOrder
        {
            [Description("Aguardando pagamento")]
            AguardandoPagamento,

            [Description("Aguardando Emissão NF")]
            AguardandoEmissaoNF,

            [Description("Aguardando Envio")]
            AguardandoEnvio,

            [Description("Aguardando Devolução")]
            AguardandoDevolucao,

            [Description("Pedido entregue")]
            Concluido,

            [Description("Pedido cancelado")]
            Cancelado
        }


        public eStatusOrder[] Status { get; set; }
        

    }
}
