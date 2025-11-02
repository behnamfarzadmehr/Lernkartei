using Lernkartei.Dto.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernkartei.Service.Abstract.Card
{
    public interface ICardHouseService : IMainService<CardHouseDto>
    {
        int CardOfHouseCount(byte houseNumber);
        int ReadyToReviewHausesCount(int houseNumber);
        IList<CardDto>? ReadyToReviewHousesList(int houseNumber);
        CardDto? FirstReadyToReviewHouses(int houseNumber);
    }
}
