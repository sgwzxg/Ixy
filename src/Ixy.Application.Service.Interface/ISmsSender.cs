using System.Threading.Tasks;

namespace Ixy.Application.Service.Interface
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
