using FluentValidator;
using ProjetoMRV.Domain.Command.Base.Interface;

namespace ProjetoMRV.Domain.Command.Base
{
    public abstract class BaseCommand : Notifiable, ICommand
    {
        public virtual bool IsValid()
        {
            return base.Valid;
        }
    }
}
