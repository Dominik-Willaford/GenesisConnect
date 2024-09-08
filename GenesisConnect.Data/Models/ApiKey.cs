namespace GenesisConnect.Data.Models
{
    public class ApiKey
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string KeyHash { get; set; }
    }
}
