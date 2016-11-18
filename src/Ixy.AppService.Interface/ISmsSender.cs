using System.Threading.Tasks;

namespace Ixy.AppService.Interface
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
