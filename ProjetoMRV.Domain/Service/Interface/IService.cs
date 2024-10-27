using FluentValidator;

namespace ProjetoMRV.Domain.Service.Interface
{
    public interface IService
    {
        IReadOnlyCollection<Notification> Notifications();
    }
}
