namespace ConfitecEscola.Application.Domain.VO
{
    public class ResponseVo
    {
        public object? Result { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool HasError { get; set; } = false;

        public ResponseVo() { }

        public ResponseVo(object? result, string message, bool hasError = false)
        {
            Result = result;
            Message = message;
            HasError = hasError;
        }
    }
}
