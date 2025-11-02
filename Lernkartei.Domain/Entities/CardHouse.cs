using Lernkartei.Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernkartei.Domain.Entities
{
    public partial class CardHouse
    {
        public CardHouse()
        {
            Card = new Card();
        }
        public int Id { get; set; }
        public long CardId { get; set; }
        public Houses House { get; set; }
        public DateTime ActionDate { get; set; }
        public bool Lerned { get; set; }

        //foreign keys
        public virtual Card Card { get; set; }
    }
}
