using Microsoft.EntityFrameworkCore;
using ProjetoMRV.Domain.Command;
using ProjetoMRV.Domain.CommandResult;
using ProjetoMRV.Domain.Entities;
using ProjetoMRV.Domain.Enums;
using ProjetoMRV.Domain.Repository.Interfaces;
using ProjetoMRV.Infra.Data;
using System;
using System.Data;

namespace ProjetoMRV.Infra.Repository
{
    public class SpaRepository : ISpaRepository
    {
        private readonly RepositoryContext _context;

        public SpaRepository(RepositoryContext context)
        {
            _context = context;
        }

        public async Task<List<SpaEntity>> GetSpaRepository()
        {
            try
            {
                var result = await _context.Spa.Where(x => x.Status == (int)EnumStatus.Invited).ToListAsync();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SpaEntity>> GetAcceptedsRepository()
        {
            try
            {
                var result = await _context.Spa.Where(x => x.Status == (int)EnumStatus.Accepted).ToListAsync();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AcceptSpaRepository(SpaCommand command)
        {
            try
            {
                var spaToUpdate = await _context.Spa.FindAsync(command.Id);

                if (spaToUpdate != null)
                {
                    spaToUpdate.Status = (int)EnumStatus.Accepted;

                    if (spaToUpdate.Price > 500)
                    {
                        spaToUpdate.Price *= 0.9;
                    }

                    await _context.SaveChangesAsync();
                }
                else
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeclineSpaRepository(SpaCommand command)
        {
            try
            {
                var spaToUpdate = await _context.Spa.FindAsync(command.Id);

                if (spaToUpdate != null)
                {
                    spaToUpdate.Status = (int)EnumStatus.Decline;

                    await _context.SaveChangesAsync();
                }
                else
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
