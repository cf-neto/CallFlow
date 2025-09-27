using CallFlow.Models;

namespace CallFlow.DTOs
{
    public class CreateUserRequest
    {
        public Usuario User { get; set; } = new Usuario();
        public AdminAuth adminAuth { get; set; } = new AdminAuth();
    }
}
