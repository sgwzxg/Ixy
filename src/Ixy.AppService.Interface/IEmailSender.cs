using System.Threading.Tasks;

namespace Ixy.AppService.Interface
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
