namespace PruebaDVP.Api.Errors
{
    public class CodeErrorException : CodeErrorResponse
    {
        public string? Details { get; set; }

        public CodeErrorException(int statusCode, string? mensaje = null, string? details = null) : base(statusCode, mensaje)
        {
            Details = details;
        }
    }
}
