namespace Client.Mapper.Dto
{
    public class ClientDto : PersonaDto
    {
        public int ClientId { get; set; }
        public string Pasword { get; set; }
        public bool State { get; set; }
    }
}