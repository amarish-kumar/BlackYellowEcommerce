using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BlackYellow.MVC.Domain.Entites
{
    public class Order
    {
        [Key]
        public long OrderId { get; set; }
        public long CustomerId { get; set; }
        public DateTime OrderDate { get; set; }

        public EStatusOrder OrderStatus { get; set; }

        [Write(false)]
        public Customer Customer { get; set; }
        [Write(false)]
        public List<ItemCart> Itens { get; set; }

        public EPaymentMethod PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public long TicketNumber { get; set; }



        public double TotalOrder {
            get
            { if(Itens != null)
                {
                    return this.Itens.Sum(i => i.SubTotal);
                }
                return 0; 
            }

        }

        public enum EStatusOrder : int
        {
            [Description("Aguardando Pagto")]
            AguardandoPagamento = 1,

            [Description("Emitindo NF")]
            AguardandoEmissaoNF,

            [Description("Preparando Envio")]
            AguardandoEnvio,

            [Description("Em Devolução")]
            AguardandoDevolucao,

            [Description("Entregue")]
            Concluido,

            [Description("Cancelado")]
            Cancelado
        }
        public enum EPaymentMethod : int
        {
            Boleto = 1,
        }


    }
}