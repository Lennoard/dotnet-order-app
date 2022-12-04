namespace dotnet_order_app.Models;

public class Boleto : Pagamento
{
    public string Codigo { get; set; }

    override public void confirma()
    {
        
    }
}
