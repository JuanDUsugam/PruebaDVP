namespace PruebaDVP.Api.Errors
{
    public class CodeErrorResponse
    {
        public int StatusCode { get; set; }
        public string? Mensaje { get; set; }

        public CodeErrorResponse(int statusCode, string? mensaje = null)
        {
           StatusCode = statusCode;
            Mensaje = mensaje;
        }
        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "El request enviado tiene errores",
                401 => "No tienes autorización para este recurso",
                404 => "No se encontro el recurso solicitado",
                500 => "Se producieron errores en el sevidor",
                _ => string.Empty
            };
        }
    }
}
