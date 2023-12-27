
using ConsoleApp3.Enums;

namespace ConsoleApp3.Models.Responses
{
    public interface IServiceResult
    {
        ServiceStatus Status { get; set; } 
        object Result { get; set; }
    }

    public class ServiceResult : IServiceResult
    {
        public ServiceStatus Status { get; set; }
        public object Result { get; set; } = null!;
    }
}
