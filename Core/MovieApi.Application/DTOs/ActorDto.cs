using System.Text.Json.Serialization;

namespace MovieApi.Application.DTOs;

public class ActorDto
{
    public long? Id { get; set; }
    public string FullName { get; set; }
}