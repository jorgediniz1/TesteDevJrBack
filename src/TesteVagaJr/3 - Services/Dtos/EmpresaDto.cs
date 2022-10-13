namespace TesteVagaJr.Services.Dtos;

public class EmpresaDto
{
    public Guid Id { get; set; }
    public string Uf { get; set; }
    public string NomeFantasia { get; set; }
    public string Cnpj { get; set; }
    public EmpresaDto() {}

    public EmpresaDto(Guid id, string uf, string nomeFantasia, string cnpj)
    {
        Id = id;
        Uf = uf;
        NomeFantasia = nomeFantasia;
        Cnpj = cnpj;
    }
}