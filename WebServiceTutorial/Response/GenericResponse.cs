namespace WebServiceTutorial.Response
{
    public class GenericResponse<T>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
    }
}
