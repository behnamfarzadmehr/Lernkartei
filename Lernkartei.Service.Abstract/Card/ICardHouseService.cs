using Lernkartei.Dto.Card;

namespace Lernkartei.Service.Abstract.Card;

public interface ICardHouseService 
{
    int CardOfHouseCount(byte houseNumber);

    int ReadyToReviewHausesCount(int houseNumber);

    IList<CardDto>? ReadyToReviewHousesList(int houseNumber);

    CardDto? FirstReadyToReviewHouses(int houseNumber);
}
