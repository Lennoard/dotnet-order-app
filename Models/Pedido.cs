namespace dotnet_order_app.Models;
using System.Collections.Generic;

public class Pedido
{
    public int Id { get; set; }
    
    public virtual ICollection<Produto> Items { get; set; }

    public virtual Consumidor Consumidor { get; set; }

    public int ConsumidorId { get; set; }

    public int PagamentoId { get; set; }

    public virtual Pagamento Pagamento { get; set; }


    public void incluirProduto(Produto produto)
    {
        Items.Add(produto);
    }

    public void excluirProduto(Produto produto)
    {
        Items.Remove(produto);
    }
}
