namespace dotnet_order_app.Models;

public class Consumidor
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; }
}
