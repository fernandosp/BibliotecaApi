using LinqToDB.Mapping;

namespace Library.Domain
{
    public class Entity
    {
        [Column(Name = "ID"), Identity]

        public int ID { get; set; }
    }
}
