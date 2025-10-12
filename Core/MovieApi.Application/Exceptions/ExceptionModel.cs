using Newtonsoft.Json;

namespace MovieApi.Application.Exceptions;

public class ExceptionModel : ErrorStatusCode
{
    public string Message { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}

public class ErrorStatusCode
{
    public int StatusCode { get; set; }
}