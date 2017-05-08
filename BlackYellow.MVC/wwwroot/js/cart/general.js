//$(document).ready(function () {
//    getItens();
//});

function getItens()
{
    console.log("sadasds");
   
    $.ajax({
        contentType: "application/json",
        method: "POST",
        url: "/Order/Itens",
        success: function (data) {
            console.log("sadasds");
            fillCart(data.carrinho.itens,data.carrinho);
        },
        error: function (data) {  }
    })
}


function fillCart(itens,carrinho) {
    console.log(carrinho);
    var html = "";
    $.each(itens, function (item, value) {
       
        html += '<tr class="cart_item">' +
                                       ' <td class="product-remove">' +
                                           '<a title="Remover produto" class="remove" href="/Order/Remove/'+value.product.productId+'">×</a>' +
                                       '</td>' +
                                        '<td class="product-thumbnail">' +
                                            '<a href="single-product.html"><img width="145" height="145" alt="poster_1_up" class="shop_thumbnail" src="../' + value.product.galeryProduct[0].pathImage + '"></a>' +
                                       '</td>' +
                                        '<td class="product-name">' +
                                            '<a href="single-product.html">' + value.product.name + '</a>' +
                                        '</td>' +
                                        '<td class="product-price">' +
                                            '<span class="amount">' + value.product.price + '</span>' +
                                       ' </td>' +
                                        '<td class="product-quantity">' +
                                            '<div class="quantity buttons_added">' +
                                              
                                               ' <input type="number" size="4" disabled class="input-text qty text" title="Qty" value="' + value.quantity + '" >' +
                                              
                                            '</div>' +
                                       ' </td>' +
                                        '<td class="product-subtotal">' +
                                            '<span class="amount">' + value.subTotal + '</span>' +
                                        '</td>' +
                                   ' </tr>';
    });


    html += ' <tr>  ' +
                                       ' <td class="actions" colspan="6">' +

                                           //' <input type="submit" value="Atualizar Carrinho" name="update_cart" class="button">' +
                                           ' <input type="submit" value="Finalizar Compra" name="proceed" class="checkout-button button alt wc-forward">' +
                                       ' </td>' +
                                   ' </tr>';
    $("#cart").append(html);


    html = '<h2>Compra Total</h2>' +
                               ' <table cellspacing="0">' +
                                   ' <tbody>' +
                                        '<tr class="cart-subtotal">' +
                                            '<th>Subtotal</th>' +
                                            '<td><span class="amount">R$'+carrinho.totalOrder+'</span></td>' +
                                        '</tr>' +
                                       ' <tr class="shipping">' +
                                            '<th>Frete</th>' +
                                            '<td>Grátis</td>' +
                                       ' </tr>' +
                                       ' <tr class="order-total">' +
                                            '<th>Total da compra</th>' +
                                            '<td><strong><span class="amount"</span> R$' + carrinho.totalOrder + '</strong> </td>' +
                                       ' </tr>' +
                                   ' </tbody>' +
                               ' </table>';

    $('.cart_totals').append(html);
    
}