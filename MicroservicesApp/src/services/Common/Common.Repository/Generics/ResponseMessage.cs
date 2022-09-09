using Newtonsoft.Json;

namespace Common.Repository.Generics
{
    public static class Respuesta
    {
        public static Task<DtoRespuesta> DevolverRespuesta(string entidad, string accion)
        => Task.FromResult(new DtoRespuesta { Dt1 = $"{entidad}, {accion} correctamente" });
        public static Task<DtoRespuesta> DevolverRespuesta(string entidad, string accion, Guid id)
        => Task.FromResult(new DtoRespuesta { Dt1 = $"{entidad}, {accion} correctamente", Id = id });
    }
}

public class DtoRespuesta
{
    [JsonProperty("id")]
    public Guid Id { get; set; }
    [JsonProperty("dt1")]
    public string Dt1 { get; set; }
    [JsonProperty("dt2")]
    public string Dt2 { get; set; }
    [JsonProperty("dt3")]
    public string Dt3 { get; set; }
    [JsonProperty("bdt1")]
    public bool Bdt1 { get; set; } = true;
    [JsonProperty("bdt2")]
    public bool Bdt2 { get; set; } = true;
    [JsonProperty("bdt3")]
    public bool Bdt3 { get; set; } = true;
    [JsonProperty("bdt4")]
    public bool Bdt4 { get; set; } = true;
    [JsonProperty("bdt5")]
    public bool Bdt5 { get; set; } = true;
}

