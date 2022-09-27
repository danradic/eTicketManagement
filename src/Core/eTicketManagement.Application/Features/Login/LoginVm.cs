using System.ComponentModel.DataAnnotations;

namespace eTicketManagement.Application.Features.Login
{
    public class LoginVm
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
