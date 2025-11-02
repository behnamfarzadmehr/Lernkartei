using Lernkartei.Domain.Abstraction;
using Lernkartei.Dto.Card;
using Lernkartei.Service.Abstract.Card;
using Lernkartei.Common.AutoMapper;
using Lernkartei.Domain.Entities;
using Lernkartei.Common.Enum;

namespace Lernkartei.Service.Concrete.Card
{
    public class CardService : MainService<Domain.Entities.Card, CardDto>,ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly ICardHouseRepository _cardHouseRepository;
        public CardService(ICardRepository cardRepository, ICardHouseRepository cardHouseRepository) : base(cardRepository)
        {
            _cardRepository = cardRepository;
            _cardHouseRepository = cardHouseRepository;
        }

        public CardDto Insert(CardDto model) 
        {
            try
            {
                var card = model.MapTo<Domain.Entities.Card>();
                card.CardHouse.Add(new CardHouse{
                    ActionDate = DateTime.Now,
                    CardId = card.Id,
                    House = Common.Enum.Houses.House1
                });
                Domain.Entities.Card? result = _cardRepository.Add(card);
                return result.MapTo<CardDto>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool SetCardAfterReview(CardDto card)
        {
            if(card.WordTypes == WordTypes.Adjective)
            {
                if (_cardRepository.Any(s => s.Id == card.Id 
                && s.Back.Trim() == card.Back.Trim()))
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
                if (_cardRepository.Any(s => s.Id == card.Id 
                && s.Back.Trim() == card.Back.Trim()
                && s.Perfekt.Trim() == card.Perfekt.Trim()))
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
                if( _cardRepository.Any(s => s.Id == card.Id
                && s.Back.Trim() == card.Back.Trim()
                && s.Artikle == (int)card.Artikle
                && s.Plural.Trim() == card.Plural.Trim()))
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
            else if (card.WordTypes == WordTypes.sentence )
            {
                if (_cardRepository.Any(s => s.Id == card.Id
                && s.Back.Trim() == card.Back.Trim()))
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
}
