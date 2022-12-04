namespace dotnet_order_app.Models;

public class CartaoDeCredito : Pagamento
{
    public string Numero { get; set; }

    override public void confirma()
    {
        
    }

    public void autoridaDebito()
    {

    }
}
