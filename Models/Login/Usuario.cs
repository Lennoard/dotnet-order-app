namespace dotnet_order_app.Models.Login
{
    using System.ComponentModel.DataAnnotations;
    
    public class Usuario
    {
        public int Id { get; set; }
        [Display(Name = "Login")]
        [Required]
        public string Nome { get; set; }

        [Required]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Senha { get; set; }
    }
}
