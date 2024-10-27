using ProjetoMRV.Domain.Command;
using ProjetoMRV.Domain.CommandResult;
using ProjetoMRV.Domain.Repository.Interfaces;

namespace ProjetoMRV.Domain.Service
{
    public class SpaService : BaseService
    {
        private readonly ISpaRepository _repository;

        public SpaService(ISpaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SpaResult>> GetSpaService()
        {
            try
            {
                var result = await _repository.GetSpaRepository();

                var list = new List<SpaResult>();

                foreach (var item in result)
                {
                    var data = new SpaResult();

                    data.Id = item.Id;
                    data.ContactFirstName = item.ContactFirstName;
                    data.DateCreated = item.DateCreated;
                    data.Suburb = item.Suburb;
                    data.Category = item.Category;
                    data.Description = item.Description;
                    data.Price = item.Price;
                    data.ContactFullName = item.ContactFullName;
                    data.ContactPhoneNumber = item.ContactPhoneNumber;
                    data.ContactEmail = item.ContactEmail;
                    data.Status = item.Status;

                    list.Add(data);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<SpaResult>> GetAcceptedsService()
        {
            try
            {
                var result = await _repository.GetAcceptedsRepository();

                var list = new List<SpaResult>();

                foreach (var item in result)
                {
                    var data = new SpaResult();

                    data.Id = item.Id;
                    data.ContactFirstName = item.ContactFirstName;
                    data.DateCreated = item.DateCreated;
                    data.Suburb = item.Suburb;
                    data.Category = item.Category;
                    data.Description = item.Description;
                    data.Price = item.Price;
                    data.ContactFullName = item.ContactFullName;
                    data.ContactPhoneNumber = item.ContactPhoneNumber;
                    data.ContactEmail = item.ContactEmail;
                    data.Status = item.Status;

                    list.Add(data);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> AcceptSpaService(SpaCommand command)
        {
            try
            {
                if (!command.IsValid())
                {
                    AddNotifications(command.Notifications);
                }

                if (!await _repository.AcceptSpaRepository(command))
                {
                    return false;
                }
                
                string filePath = @"C:\Teste\Accepted.txt"; 

                string[] linhas = { 
                    $"Accept {command.ContactFullName}." 
                }; 

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (string linha in linhas)
                    {
                        writer.WriteLine(linha);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeclineSpaService(SpaCommand command)
        {
            try
            {
                if (!command.IsValid())
                {
                    AddNotifications(command.Notifications);
                }

                if (!await _repository.DeclineSpaRepository(command))
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
