using System.ComponentModel.DataAnnotations;
using TesteVagaJr.Domain.Entities;

namespace TesteVagaJr.ViewModels
{

    public class CadastrarFornecedorViewModel
    {
        public string Nome { get; private set; }
        public string NumeroDocumento { get; private set; }
        public ETipoDocumento TipoDocumento { get; private set; }
        public ETipoFornecedor TipoFornecedor { get; private set; }
        public DateTime DataHoraCadastro { get; set; }
        public List<Telefone> Telefones { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        public string RG { get; private set; }

    }

}

