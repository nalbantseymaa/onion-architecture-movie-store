using Newtonsoft.Json;

namespace MovieApi.Application.Loggings;

public class LoggingModel
{
    public string RequestMethod { get; set; }
    public string RequestPath { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}

public class ResponseLoggingModel : LoggingModel
{
    public int ResponseStatusCode { get; set; }
    public long ResponseTime { get; set; }
}