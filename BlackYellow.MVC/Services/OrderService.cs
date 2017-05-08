using BlackYellow.MVC.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackYellow.MVC.Domain.Entites;
using BlackYellow.MVC.Domain.Interfaces.Repositories;

namespace BlackYellow.MVC.Services
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> GetAll(Models.OrderReportFilters filters)
        {
            return _orderRepository.GetAll(filters);
        }

        public string MontaBoleto()
        {
            string html = @"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>
                    <html xmlns='http://www.w3.org/1999/xhtml'>
                    <meta http-equiv='Content-Type' content='text/html; charset=utf-8'>
                    <meta charset='utf-8'/>
                    <head>    <title>Boleto.Net</title>
                    <style>
                    body {
	                    color: #000000;
	                    background-color: #ffffff;
	                    margin-top: 0;
	                    margin-right: 0;
                    }

                    * {
	                    margin: 0px;
	                    padding: 0px;
                    }

                    table {
	                    border: 0;
	                    border-collapse: collapse;
	                    padding: 0;
                    }

                    img {
	                    border: 0;
                    }

                    .cp {
	                    font: bold 10px arial;
	                    color: black;
                    }

                    .ti {
	                    font: 9px arial, helvetica, sans-serif;
                    }

                    .ld {
	                    font: bold 15px arial;
	                    color: #000000;
                    }

                    .ct {
	                    font: 9px 'arial narrow';
	                    color: #000033;
                    }

                    .cn {
	                    font: 9px arial;
	                    color: black;
                    }

                    .bc {
	                    font: bold 20px arial;
	                    color: #000000;
                    }

                    .cut {
	                    width: 665px;
	                    height: 1px;
	                    border-top: dashed 1px #000;
                    }

                    .Ac {
	                    text-align: center;
                    }

                    .Ar {
	                    text-align: right;
                    }

                    .Al {
	                    text-align: left;
                    }

                    .At {
	                    vertical-align: top;
                    }

                    .Ab {
	                    vertical-align: bottom;
                    }

                    .ct td, .cp td {
	                    padding-left: 6px;
	                    border-left: solid 1px #000;
                    }

                    .cpN {
	                    font: bold 10px arial;
	                    color: black;
                    }

                    .ctN {
	                    font: 9px 'arial narrow';
	                    color: #000033;
                    }

                    .pL0 {
	                    padding-left: 0px;
                    }

                    .pL6 {
	                    padding-left: 6px;
                    }

                    .pL10 {
	                    padding-left: 10px;
                    }

                    .imgLogo {
	                    width: 150px;
                    }

	                    .imgLogo img {
		                    width: 150px;
		                    height: 40px;
	                    }

                    .barra {
	                    width: 3px;
	                    height: 22px;
	                    vertical-align: bottom;
                    }

	                    .barra img {
		                    width: 2px;
		                    height: 22px;
	                    }

                    .rBb td {
	                    border-bottom: solid 1px #000;
                    }

                    .BB {
	                    border-bottom: solid 1px #000;
                    }

                    .BL {
	                    border-left: solid 1px #000;
                    }

                    .BR {
	                    border-right: solid 1px #000;
                    }

                    .BT1 {
	                    border-top: dashed 1px #000;
                    }

                    .BT2 {
	                    border-top: solid 2px #000;
                    }

                    .h1 {
	                    height: 1px;
                    }

                    .h13 {
	                    height: 13px;
                    }

                    .h12 {
	                    height: 12px;
                    }

                    .h13 td {
	                    vertical-align: top;
                    }

                    .h12 td {
	                    vertical-align: top;
                    }

                    .w6 {
	                    width: 6px;
                    }

                    .w7 {
	                    width: 7px;
                    }

                    .w34 {
	                    width: 34px;
                    }

                    .w45 {
	                    width: 45px;
                    }

                    .w53 {
	                    width: 53px;
                    }

                    .w62 {
	                    width: 62px;
                    }

                    .w65 {
	                    width: 65px;
                    }

                    .w72 {
	                    width: 72px;
                    }

                    .w83 {
	                    width: 83px;
                    }

                    .w88 {
	                    width: 88px;
                    }

                    .w104 {
	                    width: 104px;
                    }

                    .w105 {
	                    width: 105px;
                    }

                    .w106 {
	                    width: 106px;
                    }

                    .w113 {
	                    width: 113px;
                    }

                    .w112 {
	                    width: 112px;
                    }

                    .w123 {
	                    width: 123px;
                    }

                    .w126 {
	                    width: 126px;
                    }

                    .w128 {
	                    width: 128px;
                    }

                    .w132 {
	                    width: 132px;
                    }

                    .w134 {
	                    width: 134px;
                    }

                    .w150 {
	                    width: 150px;
                    }

                    .w163 {
	                    width: 163px;
                    }

                    .w164 {
	                    width: 164px;
                    }

                    .w180 {
	                    width: 180px;
                    }

                    .w182 {
	                    width: 182px;
                    }

                    .w186 {
	                    width: 186px;
                    }

                    .w192 {
	                    width: 192px;
                    }

                    .w250 {
	                    width: 250px;
                    }

                    .w298 {
	                    width: 298px;
                    }

                    .w409 {
	                    width: 409px;
                    }

                    .w472 {
	                    width: 472px;
                    }

                    .w478 {
	                    width: 478px;
                    }

                    .w500 {
	                    width: 500px;
                    }

                    .w544 {
	                    width: 544px;
                    }

                    .w564 {
	                    width: 564px;
                    }

                    .w659 {
	                    width: 659px;
                    }

                    .w666 {
	                    width: 666px;
                    }

                    .w667 {
	                    width: 667px;
                    }

                    .BHead td {
	                    border-bottom: solid 2px #000;
                    }

                    .EcdBar {
	                    height: 50px;
	                    vertical-align: bottom;
                    }

                    .rc6 td {
	                    vertical-align: top;
	                    border-bottom: solid 1px #000;
	                    border-left: solid 1px #000;
                    }

                    .rc6 div {
	                    padding-left: 6px;
                    }

                    .rc6 .t {
	                    font: 9px 'arial narrow';
	                    color: #000033;
	                    height: 13px;
                    }

                    .rc6 .c {
	                    font: bold 10px arial;
	                    color: black;
	                    height: 12px;
                    }

                    .mt23 {
	                    margin-top: 23px;
                    }

                    .pb4 {
	                    padding-bottom: 14px;
                    }

                    .ebc {
	                    width: 4px;
	                    height: 440px;
	                    border-right: dotted 1px #000000;
	                    margin-right: 4px;
                    }
                    </style>
                         </head>
                    <body>
                    <style>
                    .cp{ font-size: 12px !important; }.ctN{ font-size: 10px !important; }.cpN{ font-size: 12px !important; }.ti{ font-size: 14px !important; }.ct{ font-size: 10px !important; }.t{ font-size: 10px !important; }.it{ font-size: 14px !important; }</style>
                    <table class='w666'>
				                    <tr class='cpN'>
						                    <td class='At Ac'>Instru��es de Impress�o</td>
				                    </tr>
				                    <tr class='ti'>
						                    <td class='At Ac'>Imprimir em impressora jato de tinta (ink jet) ou laser em qualidade normal. (N�o use modo econ�mico).<br>Utilize folha A4 (210 x 297 mm) ou Carta (216 x 279 mm) - Corte na linha indicada<br></td>
				                    </tr>
		                    </table><br /><table class='w666'>
				                    <tr>
						                    <td class='ctN cut' />
				                    </tr>
				                    <tr>
						                    <td class='cpN Ar'>Recibo do Pagador</td>
				                    </tr>
		                    </table><br /><table class='w666'>
				                    <tr class='BHead'>
						                    <td class='imgLogo Al'><img src='data:image/gif;base64,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' /></td>
						                    <td class='barra'><img src='data:image/gif;base64,R0lGODlhAgATAIAAAAAAAP///yH5BAAAAAAALAAAAAACABMAAAIFhI+py1YAOw==' /></td>
						                    <td class='w65 Ab bc Ac'>001-9</td>
						                    <td class='barra'><img src='data:image/gif;base64,R0lGODlhAgATAIAAAAAAAP///yH5BAAAAAAALAAAAAACABMAAAIFhI+py1YAOw==' /></td>
						                    <td class='w500 Ar Ab ld'>00190.98763 54321.012343 00123.456162 1 71620000000001</td>
				                    </tr>
		                    </table><table class='w666'>
				                    <tr class='ct h13 At'>
						                    <td class='w298'>Benefici�rio</td>
						                    <td class='w126'>Ag�ncia / C�digo do Benefici�rio</td>
						                    <td class='w34'>Esp�cie</td>
						                    <td class='w45'>Quantidade</td>
						                    <td class='w128'>Carteira / Nosso n�mero</td>
				                    </tr>
				                    <tr class='cp h12 At rBb'>
						                    <td>BlackYellow</td>
						                    <td>1234-1/00123456-1</td>
						                    <td>R$</td>
						                    <td></td>
						                    <td class='Ar'>09876543210</td>
				                    </tr>
		                    </table><table class='w666'>
				                    <tr class='ct h13'>
						                    <td class='w192'>N�mero do documento</td>
						                    <td class='w132'>CPF/CNPJ</td>
						                    <td class='w134'>Vencimento</td>
						                    <td class='w180'>Valor documento</td>
				                    </tr>
				                    <tr class='cp h12 rBb'>
						                    <td>12415487</td>
						                    <td>00000000000000</td>
						                    <td>17/05/2017</td>
						                    <td class='Ar'>0,01</td>
				                    </tr>
		                    </table><table class='w666'>
				                    <tr class='ct h13'>
						                    <td class='w113'>(-) Desconto / Abatimentos</td>
						                    <td class='w112'>(-) Outras dedu��es</td>
						                    <td class='w113'>(+) Mora / Multa</td>
						                    <td class='w113'>(+) Outros acr�scimos</td>
						                    <td class='w180'>(=) Valor cobrado</td>
				                    </tr>
				                    <tr class='cp h12 rBb Ab'>
						                    <td></td>
						                    <td></td>
						                    <td></td>
						                    <td></td>
						                    <td class='Ar'>&nbsp;</td>
				                    </tr>
		                    </table><table class='w666'>
				                    <tr class='ct h13'>
						                    <td class='w659'>Pagador</td>
				                    </tr>
				                    <tr class='cp h12'>
						                    <td></td>
				                    </tr>
				                    <tr class='cp h12 rBb'>
						                    <td></td>
				                    </tr>
		                    </table><table class='w666'>
				                    <tr class='ctN h13'>
						                    <td class='pL6'>Instru��es</td>
						                    <td class='w180 Ar'>Autentica��o mec�nica</td>
				                    </tr>
				                    <tr class='cpN h12'>
						                    <td class='pL6 it'>Protestar ap�s 5 dias �teis.<br />Import�ncia por dia de desconto.<br />Protestar no 15� dia corrido ap�s vencimento</td>
						                    <td class='pL6 Ar'></td>
				                    </tr>
		                    </table><table class='ctN w666'>
				                    <tr class='h13'><td /></tr>
				                    <tr class='h13'><td /></tr>
				                    <tr><td class='Ar'>Corte na linha pontilhada</td></tr>
				                    <tr><td class='cut' /></tr>
				                    <tr class='h13'><td /></tr>
				                    <tr class='h13'><td /></tr>
		                    </table><table class='w666'>
				                    <tr class='BHead'>
						                    <td class='imgLogo Al'><img src='data:image/gif;base64,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' /></td>
						                    <td class='barra'><img src='data:image/gif;base64,R0lGODlhAgATAIAAAAAAAP///yH5BAAAAAAALAAAAAACABMAAAIFhI+py1YAOw==' /></td>
						                    <td class='w65 Ab bc Ac'>001-9</td>
						                    <td class='barra'><img src='data:image/gif;base64,R0lGODlhAgATAIAAAAAAAP///yH5BAAAAAAALAAAAAACABMAAAIFhI+py1YAOw==' /></td>
						                    <td class='w500 Ar ld' valign='bottom'>00190.98763 54321.012343 00123.456162 1 71620000000001</td>
				                    </tr>
		                    </table><table class='w666'>
				                    <tr class='ct h13'>
						                    <td class='w472'>Local de pagamento</td>
						                    <td class='w180'>Vencimento</td>
				                    </tr>
				                    <tr class='cp h12 rBb'>
						                    <td>At� o vencimento, preferencialmente no </td>
						                    <td class='Ar'>17/05/2017</td>
				                    </tr>
		                    </table><table class='w666'>
				                    <tr class='ct h13'>
						                    <td class='w472'>Benefici�rio</td>
						                    <td class='w180'>Ag�ncia / C�digo Benefici�rio</td>
				                    </tr>
				                    <tr class='cp h12 rBb'>
						                    <td>BlackYellow</td>
						                    <td class='Ar'>1234-1/00123456-1</td>
				                    </tr>
		                    </table><table class='w666'>
				                    <tr class='ct h13'>
						                    <td class='w113'>Data do documento</td>
						                    <td class='w163'>N<u>o</u> documento</td>
						                    <td class='w62'>Esp�cie doc.</td>
						                    <td class='w34'>Aceite</td>
						                    <td class='w72'>Data processamento</td>
						                    <td class='w180'>Carteira / Nosso n�mero</td>
				                    </tr>
				                    <tr class='cp h12 rBb'>
						                    <td>07/05/2017</td>
						                    <td>12415487</td>
						                    <td>DM</td>
						                    <td>N</td>
						                    <td>07/05/2017</td>
						                    <td class='Ar'>09876543210</td>
				                    </tr>
		                    </table><table class='w666'>
				                    <tr class='ct h13'>
						                    <td class='w113'>Uso do banco</td>
						                    <td class='w83'>Carteira</td>
						                    <td class='w53'>Esp�cie</td>
						                    <td class='w123'>Quantidade</td>
						                    <td class='w72'>(x) Valor</td>
						                    <td class='w180'>(=) Valor documento</td>
				                    </tr>
				                    <tr class='cp h12 rBb'>
						                    <td></td>
						                    <td class='Al'>16</td>
						                    <td class='Al'>R$</td>
						                    <td></td>
						                    <td></td>
						                    <td class='Ar'>0,01</td>
				                    </tr>
		                    </table><table class='w666'>
				                    <tr class='rc6'>
						                    <td class='w478'>
								                    <div class='ctN pL10'>Instru��es (Texto de responsabilidade do benefici�rio)</div>
                                    <div class='cpN pL10 it' style='height:105px; overflow:hidden'>Protestar ap�s 5 dias �teis.<br />Import�ncia por dia de desconto.<br />Protestar no 15� dia corrido ap�s vencimento</div>                
						                    </td>
						                    <td class='w186'>
								                    <div class='t'>(-) Desconto / Abatimentos</div>
								                    <div class='c BB'></div>
								                    <div class='t'>(-) Outras dedu��es</div>
								                    <div class='c BB'></div>
								                    <div class='t'>(+) Mora / Multa</div>
								                    <div class='c BB'></div>
								                    <div class='t'>(+) Outros acr�scimos</div>
								                    <div class='c BB'></div>
								                    <div class='t'>(=) Valor cobrado</div>
								                    <div class='c'></div>
						                    </td>
				                    </tr>
		                    </table><table class='w666'>
				                    <tr class='ct h13'>
						                    <td class='w659'>Pagador</td>
				                    </tr>
				                    <tr class='cp h12'>
						                    <td class='At'></td>
				                    </tr>
		                    </table><table class='w666'>
				                    <tr class='rBb'>
						                    <td class='w478 BL'>
								                    <div class='cpN pL6'></div>
						                    </td>
						                    <td class='Ab BL'>
								                    <div class='ctN pL6'>C�d. baixa</div>
						                    </td>
				                    </tr>
		                    </table><table class='w666 ctN'>
				                    <tr>
						                    <td class='pL6  w409'>Sacador / Avalista:  - </td>
						                    <td class='w250 Ar'>Autentica��o mec�nica - <b class='cpN'>Ficha de Compensa��o</b></td>
				                    </tr>
				                    <tr class='h13'><td colspan='3' /></tr>
		                    </table><table class='w666'>
				                    <tr>
						                    <td class='EcdBar Al pL10'><img src='data:image/gif;base64,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' alt='C�digo de Barras' /></td>
				                    </tr>
		                    </table><table class='ctN w666'>
				                    <tr class='h13'><td /></tr>
				                    <tr><td class='Ar'>Corte na linha pontilhada</td></tr>
				                    <tr><td class='cut' /></tr>
		                    </table>
		                    <table class='ctN w666'>
				                    <tr class='h13'><td /></tr>
				                    <tr class='h13'><td /></tr>
				                    <tr class='h13'><td /></tr>
				                    <tr class='h13'><td /></tr>
				                    <tr class='h13'><td /></tr>
				                    <tr class='h13'><td /></tr>
		                    </table></body>
                    </html>";

            return html;
        }


    }
}
