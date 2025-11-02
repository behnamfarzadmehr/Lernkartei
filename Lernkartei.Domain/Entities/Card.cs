using System.Collections.ObjectModel;

namespace Lernkartei.Domain.Entities
{
    public partial class Card
    {
        public Card()
        {
            Front = "";
            Back = "";
            CardHouse = new Collection<CardHouse>();
        }
        public long Id { get; set; }
        public string Front { get; set; }
        public string Back { get; set; }
        public string? Plural { get; set; }
        public string? Perfekt { get; set; }
        public int WordTypes { get; set; }
        public int Artikle { get; set; }
        public DateTime CreateDateTime { get; set; }

        //foreign key
        public virtual ICollection<CardHouse> CardHouse { get; set; }
    }
}
