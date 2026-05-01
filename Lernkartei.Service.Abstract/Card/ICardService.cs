using Lernkartei.Dto.Card;

namespace Lernkartei.Service.Abstract.Card;

public interface ICardService
{
    bool Delete(long id);

    IList<CardDto> GetAll();

    CardDto GetById(long id);

    public CardDto Insert(CardDto model);

    bool SetCardAfterReview(CardDto card);

    CardDto Update(CardDto model);
}
