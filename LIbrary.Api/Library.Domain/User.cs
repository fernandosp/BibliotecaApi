namespace Library.Domain
{
    public sealed class User : Entity
    {
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Observation { get; set; }
        public bool IsBlocked { get; set; }
    }
}