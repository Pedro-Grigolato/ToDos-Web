using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.SignalR;

namespace ToDoPlatform.ViewModels;

public class LoginVM
{
    [Display(Name = "E-mail", Prompt = "seu@email.com")]
    [Required(ErrorMessage = "O e-mail de acesso é obrigatório!")]
    [EmailAddress(ErrorMessage = "Informe um e-mail válido!")]
    public string Emai { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public string RememberName { get; set; }
    public string ReturnUrl { get; set; }
}
