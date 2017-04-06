$(document).ready(function () {
    getItensCart();
});

function getItensCart()
{
    $.ajax({
        contentType: "application/json",
        method: "POST",
        url: "/Order/Itens",
        success: function(data)
        {
            fillCart(data.sucesso.itens);
        }
    });
}


function fillCart(itens)
{
    var html = '<table cellspacing="0" class="shop_table cart">' +
                                 '<thead>' +
                                     '<tr>' +
                                        ' <th class="product-remove">&nbsp;</th>' +
                                        ' <th class="product-thumbnail">&nbsp;</th>' +
                                        ' <th class="product-name">Produto</th>' +
                                        ' <th class="product-price">Preço</th>' +
                                        ' <th class="product-quantity">Quantidade</th>' +
                                        ' <th class="product-subtotal">Total</th>' +
                                    ' </tr>' +
                                 '</thead>' +
                     '<tbody>';
     $.each(itens, function (item, value) {
       
         html += ' <tr class="cart_item">' +
                 ' <td class="product-remove">' +
                 '   <a title="Remover produto" class="remove" href="#">×</a>' +
                 ' </td>' +
                 ' <td class="product-thumbnail">' +
                 '     <a href="single-product.html"><img width="145" height="145" alt="poster_1_up" class="shop_thumbnail" src=""></a>' +
                 ' </td>' +
                 ' <td class="product-name">' +
                 '    <a href="single-product.html">' + value.product.name + '</a>' +
                 ' </td>' +
                 '  <td class="product-price">' +
                 '     <span class="amount">' + value.product.price + '</span>' +
                 ' </td>' +
                 ' <td class="product-quantity">' +
                 '     <div class="quantity buttons_added">' +
                 '         <input type="button" class="minus" value="-">' +
                 '        <input type="number" size="4" class="input-text qty text" title="Qty" value="' + value.quantity + '" min="0" step="1">' +
                 '        <input type="button" class="plus" value="+">' +
                 '    </div>' +
                 ' </td>' +
                 ' <td class="product-subtotal">' +
                 '    <span class="amount">' + value.subtotal + '</span>' +
                 ' </td>' +
                 ' </tr>' +
                 ' <tr>' +
                 '  <td class="actions" colspan="6">' +
                 '  <input type="submit" value="Atualizar Carrinho" name="update_cart" class="button">' +
                 '   <input type="submit" value="Finalizar Compra" name="proceed" class="checkout-button button alt wc-forward">' +
                 ' </td>' +
                 '</tr>';
     });

     html += '  </tbody>'+
            ' </table>';
     console.log(html);
     $("#cart").append(html);
}