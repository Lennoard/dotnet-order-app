namespace dotnet_order_app.Models;

public class Pagamento
{
    public int Id { get; set; }

    public decimal Valor { get; set; }

    public virtual Pedido Pedido { get; set; }

    public int PedidoId { get; set; }

    public virtual void confirma()
    {
        
    }
}
