namespace AguadeCactus.Api.Dto;
using System.Text.Json.Serialization;

public abstract class DtoBase
{
    
    [JsonIgnore]
    public int id { get; set; }
}