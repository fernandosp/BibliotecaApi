namespace Library.Domain
{
    public sealed class Publisher : Entity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
    }
}