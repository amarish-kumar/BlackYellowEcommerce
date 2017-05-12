using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackYellow.MVC.Domain.Entites;

namespace BlackYellow.MVC.ViewModels
{
    public class BoletoViewModel
    {

        internal static int Mod10(string seq)
        {
            /* Variáveis
             * -------------
             * d - Dígito
             * s - Soma
             * p - Peso
             * b - Base
             * r - Resto
             */

            int d, s = 0, p = 2, r;

            for (int i = seq.Length; i > 0; i--)
            {
                r = (Convert.ToInt32(seq.Substring(i - 1, 1)) * p);

                if (r > 9)
                    r = (r / 10) + (r % 10);

                s += r;

                if (p == 2)
                    p = 1;
                else
                    p = p + 1;
            }
            d = ((10 - (s % 10)) % 10);
            return d;
        }


        public string LinhaDigitavel
        {
            get
            {

                string valorBoleto = Order.TotalOrder.ToString("f").Replace(",", "").Replace(".", "");
                valorBoleto = (valorBoleto.PadLeft(10, '0'));

                string numeroDocumento = Order.TicketNumber.ToString().PadLeft(7, '0');
                string codigoCedente = Order.CustomerId.ToString().PadLeft(5, '0');

                return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}0", "341", "9",
                        0, valorBoleto, "176",
                        "000000014", numeroDocumento, codigoCedente,
                        Mod10("176" + "000000014" + numeroDocumento + codigoCedente));

            }
        }

        public Order Order { get; set; }

    }
}
