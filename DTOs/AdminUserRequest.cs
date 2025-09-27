using CallFlow.Models;

namespace CallFlow.DTOs
{
    public class AdminUserRequest
    {
        public AdminAuth AdminAuth { get; set; } = new AdminAuth();
        public Usuario User { get; set; } = new Usuario();
    }
}
