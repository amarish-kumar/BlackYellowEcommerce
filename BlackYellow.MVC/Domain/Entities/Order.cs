using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BlackYellow.MVC.Domain.Entites
{
    public class Order
    {

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }

        public EStatusOrder OrderStatus { get; set; }

        public Customer Customer { get; set; }

        public List<ItemCart> Itens { get; set; }

        public EPaymentMethod PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }


        public double TotalOrder { get { return this.Itens.Sum(i => i.SubTotal); } }

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