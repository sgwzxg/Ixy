using System.Threading.Tasks;

namespace Ixy.Application.Service.Interface
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
