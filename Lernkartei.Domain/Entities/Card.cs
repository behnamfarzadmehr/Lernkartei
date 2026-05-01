using System.Collections.ObjectModel;
using Lernkartei.Common.Enum;

namespace Lernkartei.Domain.Entities;

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
    public WordTypes WordTypes { get; set; }
    public int Artikle { get; set; }
    public DateTime CreateDateTime { get; set; }
    public string? KomParativ { get; set; }
    public string? Superlativ { get; set; }

    //foreign key
    public virtual ICollection<CardHouse> CardHouse { get; set; }
}
