namespace CasaDosFarelos.Application.DTOs
{
    public class ClienteResponseDto
    {
        public Guid Id { get; init; }
        public string Nome { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Documento { get; init; } = string.Empty;

        /// <summary>
        /// Indica se é PF ou PJ
        /// </summary>
        public string Tipo { get; init; } = string.Empty;

        /// <summary>
        /// Apenas preenchido se Tipo == PF
        /// </summary>
        public string? CPF { get; init; }

        /// <summary>
        /// Apenas preenchido se Tipo == PJ
        /// </summary>
        public string? CNPJ { get; init; }
    }
}