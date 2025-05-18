namespace EmployeeManagerAPI.Helpher
{
    public class Response
    {
        public object? Data { get; set; }
        public string? Message { get; set; }
        public bool Status { get; set; }
        public int StatusCode { get; set; }
    }
}
