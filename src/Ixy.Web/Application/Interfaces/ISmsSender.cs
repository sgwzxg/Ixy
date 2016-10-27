using System.Threading.Tasks;

namespace Ixy.Application.Interfaces
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
