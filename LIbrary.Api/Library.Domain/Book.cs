namespace Library.Domain
{
    public sealed class Book : Entity
    {
        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
        public int IdPublisher { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Observation { get; set; }
        public bool IsAvailable { get; set; }//EstaDisponivel
        public decimal AmountPaid { get; set; } //Valor pago pelo livro
        public decimal ReturnInvestment{ get; set; } //valor do lucro com o livro

    }
}
