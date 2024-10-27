using ProjetoMRV.Domain.Command;
using ProjetoMRV.Domain.CommandResult;
using ProjetoMRV.Domain.Entities;

namespace ProjetoMRV.Domain.Repository.Interfaces
{
    public interface ISpaRepository
    {
        Task<List<SpaEntity>> GetSpaRepository();
        Task<List<SpaEntity>> GetAcceptedsRepository();
        Task<bool> AcceptSpaRepository(SpaCommand command);
        Task<bool> DeclineSpaRepository(SpaCommand command);
    }
}
