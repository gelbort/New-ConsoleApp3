using ConsoleApp3.Enums;

namespace ConsoleApp3.Models.Responses
{
    public interface IServiceResult<T>
    {
        ServiceStatus Status { get; set; }
        T Result { get; set; }
    }

    public class ServiceResult<T> : IServiceResult<T>
    {
        public ServiceStatus Status { get; set; }
        public T Result { get; set; } = default!;
    }
}
