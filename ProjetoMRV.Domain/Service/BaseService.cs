using FluentValidator;
using ProjetoMRV.Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMRV.Domain.Service
{
    public class BaseService: Notifiable, IService
    {
        IReadOnlyCollection<Notification> IService.Notifications() => this.Notifications;
}
}
