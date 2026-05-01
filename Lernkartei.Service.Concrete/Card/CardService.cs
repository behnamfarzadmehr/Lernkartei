using Lernkartei.Common.Enum;
using Lernkartei.Domain.Abstraction;
using Lernkartei.Domain.Entities;
using Lernkartei.Dto.Card;
using Lernkartei.Service.Abstract.Card;
using Lernkartei.Service.Concrete.Mapper;

namespace Lernkartei.Service.Concrete.Card;

public class CardService : ICardService
{
    private readonly ICardRepository _cardRepository;
    private readonly ICardHouseRepository _cardHouseRepository;
    public CardService(ICardRepository cardRepository, ICardHouseRepository cardHouseRepository)
    {
        _cardRepository = cardRepository;
        _cardHouseRepository = cardHouseRepository;
    }

    public bool Delete(long id)
    {
        return _cardRepository.Delete(new Domain.Entities.Card { Id = id});
    }

    public IList<CardDto> GetAll()
    {
        return _cardRepository.GetAll().ToList().MapTo();
    }

    public CardDto GetById(long id)
    {
        return _cardRepository.GetById(id).MapTo();
    }

    public CardDto Insert(CardDto model) 
    {
        try
        {
            var card = model.MapTo();
            card.CardHouse.Add(new CardHouse{
                ActionDate = DateTime.Now,
                CardId = card.Id,
                House = Common.Enum.Houses.House1
            });
            Domain.Entities.Card? result = _cardRepository.Add(card);
            return result.MapTo();
        }
        catch (Exception)
        {

            throw;
        }
    }

    public bool SetCardAfterReview(CardDto card)
    {
        var dbCard = _cardRepository.GetById(card.Id);

        if(dbCard.WordTypes != card.WordTypes)
        {
            UpdateCardHouseToFailed(card);
            return false;
        }

        if(card.WordTypes == WordTypes.Adjective)
        {
            if (dbCard.Back.ToString().Trim().CompareTo(card.Back.ToString().Trim()) == 0
            && dbCard.KomParativ?.ToString().Trim().CompareTo(card.KomParativ?.ToString().Trim()) == 0
            && dbCard.Superlativ?.ToString().Trim().CompareTo(card.Superlativ?.ToString().Trim()) == 0 )
            {
                UpdateCardHouse(card);
                return true;
            }                                             
            else
            {
                UpdateCardHouseToFailed(card);
                return false;
            }
        }
        else if(card.WordTypes == WordTypes.Verb)
        {
            if (dbCard.Back.ToString().Trim().CompareTo(card.Back.ToString().Trim()) == 0
            && dbCard.Perfekt?.ToString().Trim().CompareTo(card.Perfekt?.ToString().Trim()) == 0)
            {
                UpdateCardHouse(card);
                return true;
            }
            else
            {
                UpdateCardHouseToFailed(card);
                return false;
            }
        }
        else if(card.WordTypes == WordTypes.Noun)
        {
            if( dbCard.Back.ToString().Trim().CompareTo(card.Back.ToString().Trim()) == 0
            && dbCard.Artikle == (int)card.Artikle
            && dbCard.Plural?.ToString().Trim().CompareTo(card.Plural?.ToString().Trim()) == 0)
            {
                UpdateCardHouse(card);
                return true;
            }
            else
            {
                UpdateCardHouseToFailed(card);
                return false;
            }
        }
        else if (card.WordTypes == WordTypes.Sentence || card.WordTypes == WordTypes.Adverb )
        {
            if (dbCard.Back.ToString().Trim().CompareTo(card.Back.ToString().Trim()) == 0)
            {
                UpdateCardHouse(card);
                return true;
            }
            else
            {
                UpdateCardHouseToFailed(card);
                return false;
            }
        }
        return false;
    }

    public CardDto Update(CardDto model)
    {
        return _cardRepository.Update(model.MapTo()).MapTo();
    }

    private void UpdateCardHouse(CardDto card)
    {
        var cardHouse = _cardHouseRepository.Find(s => s.CardId == card.Id).First();
        cardHouse.ActionDate = DateTime.Now;
        cardHouse.House = cardHouse.House + 1;
        cardHouse.Lerned = cardHouse.House == Houses.House5 ? true : false;
        _cardHouseRepository.Update(cardHouse);
    }

    private void UpdateCardHouseToFailed(CardDto card)
    {
        var cardHouse = _cardHouseRepository.Find(s => s.CardId == card.Id).First();
        cardHouse.ActionDate = DateTime.Now;
        cardHouse.House = Houses.House1;
        cardHouse.Lerned = false;
        _cardHouseRepository.Update(cardHouse);
    }
}
