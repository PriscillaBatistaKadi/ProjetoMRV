using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMRV.Domain.Service.Interface
{
    public interface IBaseService
    {
        IReadOnlyCollection<Notification> Notifications();
    }
}
