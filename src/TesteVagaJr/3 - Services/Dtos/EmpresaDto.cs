namespace TesteVagaJr.Services.Dtos;

public class EmpresaDto
{
    public string Uf { get; private set; }
    public string NomeFantasia { get; private set; }
    public string Cnpj { get; private set; }
    public EmpresaDto() {}

    public EmpresaDto(string uf, string nomeFantasia, string cnpj)
    {
        Uf = uf;
        NomeFantasia = nomeFantasia;
        Cnpj = cnpj;
    }
}