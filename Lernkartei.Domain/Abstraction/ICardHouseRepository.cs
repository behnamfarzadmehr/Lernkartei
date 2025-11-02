using Lernkartei.Common.Enum;
using Lernkartei.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernkartei.Domain.Abstraction
{
    public interface ICardHouseRepository : IRepository<CardHouse>
    {
        IList<Card> GetReadyToReviewHousesList(Houses houseNumber, DateTime date);
        Card? GetFirstReadyToReviewHousesList(Houses house1, DateTime date);
    }
}
