using FluentValidator.Validation;
using ProjetoMRV.Domain.Command.Base;

namespace ProjetoMRV.Domain.Command
{
    public class SpaCommand : BaseCommand
    {
        public int Id { get; set; }
        public string ContactFullName { get; set; }
        public double Price {  get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public int Status { get; set; }

        public override bool IsValid()
        {
            AddNotifications(new ValidationContract()
                .IsGreaterThan(Id, 0, "Id", "O campo id deve ser maior que zero.")
                .IsNotNullOrEmpty(ContactPhoneNumber, "Phone", "Número de contato não encontrado para este cadastro.")
                .IsNotNullOrEmpty(ContactEmail, "Email", "E-mail não encontrado para este cadastro.")
                );

            return Valid;
        }
    }
}
