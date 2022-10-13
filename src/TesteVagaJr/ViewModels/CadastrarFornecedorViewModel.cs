using System.ComponentModel.DataAnnotations;
using TesteVagaJr.Domain.Entities;

namespace TesteVagaJr.ViewModels
{

    public class CadastrarFornecedorViewModel
    {
        [Required(ErrorMessage = "O nome não pode ser vazio.")]
        [MinLength(2, ErrorMessage = "O nome deve ter no mínimo 2 caracteres")]
        [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres")]
        public string Nome { get; set; }

        [Required]
        [MinLength(11, ErrorMessage = "O número do documento deve ter no mínimo 11 digitos")]
        [MaxLength(14, ErrorMessage = "O número do documento deve ter no máximo 14 digitos")]
        public string NumeroDocumento { get; set; }

        public Guid EmpresaId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "O tipo de documento deve ter no mínimo 1 digito")]
        [MaxLength(2, ErrorMessage = "O tipo de documento deve ter no máximo 1 digito")]
        public string TipoDocumento { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "O tipo de fornecedor deve ter no mínimo 1 digito")]
        [MaxLength(2, ErrorMessage = "O tipo de fornecedor deve ter no máximo 1 digito")]
        public string TipoFornecedor { get; set; }

        //public DateTime DataHoraCadastro { get; set; } Data aplicada automaticamente ao incluir fornecedor.
        public List<Telefone> Telefones { get; set; }

        public DateTime? DataNascimento { get; set; }

        [MaxLength(10, ErrorMessage = "O RG deve ter no máximo 10 digitos")]
        public string RG { get; set; } 

    }

}

