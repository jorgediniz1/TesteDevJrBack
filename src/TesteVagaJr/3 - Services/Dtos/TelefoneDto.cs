namespace TesteVagaJr.Services.Dtos
{
    public class TelefoneDto
    {
        public string DDD { get; set; }
        public string Numero { get; set; }

        public TelefoneDto(string ddd, string numero)
        {
            DDD = ddd;
            Numero = numero;
        }
    }

}
