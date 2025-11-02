using Lernkartei.Domain.Abstraction;
using Lernkartei.Dto.Card;
using Lernkartei.Service.Abstract.Card;
using Lernkartei.Common.AutoMapper;
using System.Globalization;

namespace Lernkartei.Service.Concrete.Card
{
    public class CardHouseService : MainService<Domain.Entities.CardHouse, CardHouseDto>, ICardHouseService
    {
        private readonly ICardHouseRepository _cardRepository;
        public CardHouseService(ICardHouseRepository cardRepository) : base(cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public CardHouseDto Insert(CardHouseDto model)
        {
            try
            {
                Domain.Entities.CardHouse? result = _cardRepository.Add(entity: model.MapTo<Domain.Entities.CardHouse>());
                return result.MapTo<CardHouseDto>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int CardOfHouseCount(byte houseNumber)
        {
            switch (houseNumber)
            {
                case 1: return _cardRepository.Find(s => s.House == Common.Enum.Houses.House1).Count();
                case 2: return _cardRepository.Find(s => s.House == Common.Enum.Houses.House2).Count();
                case 3: return _cardRepository.Find(s => s.House == Common.Enum.Houses.House3).Count();
                case 4: return _cardRepository.Find(s => s.House == Common.Enum.Houses.House4).Count();
                case 5: return _cardRepository.Find(s => s.House == Common.Enum.Houses.House5).Count();
                default: return -1;
            }
        }

        public int ReadyToReviewHausesCount(int houseNumber)
        {
            switch (houseNumber)
            {
                case 1:
                    DateTime now1 = DateTime.Now.Date;
                    return _cardRepository.Find(s => s.House == Common.Enum.Houses.House1
                 && s.ActionDate.Date.CompareTo(now1) < 0).Count();
                case 2:
                    DateTime now2 = DateTime.Now.AddDays(-1).Date;
                    return _cardRepository.Find(s => s.House == Common.Enum.Houses.House2
                && s.ActionDate.Date.CompareTo(now2) < 0).Count();
                case 3:
                    DateTime now3 = DateTime.Now.AddDays(-3).Date;
                    return _cardRepository.Find(s => s.House == Common.Enum.Houses.House3
                && s.ActionDate.Date.CompareTo(now3) < 0).Count();
                case 4:
                    DateTime now4 = DateTime.Now.AddDays(-7).Date;
                    return _cardRepository.Find(s => s.House == Common.Enum.Houses.House4
                && s.ActionDate.Date.CompareTo(now4) < 0).Count();
                case 5:
                    DateTime now5 = DateTime.Now.AddDays(-14).Date;
                    return _cardRepository.Find(s => s.House == Common.Enum.Houses.House5
                && s.ActionDate.Date.CompareTo(now5) < 0).Count();
                default: return -1;
            }
        }

        public IList<CardDto>? ReadyToReviewHousesList(int houseNumber)
        {
            switch (houseNumber)
            {
                case 1: return _cardRepository.GetReadyToReviewHousesList(Common.Enum.Houses.House1, DateTime.Now.Date).MapToList<CardDto>();
                case 2: return _cardRepository.GetReadyToReviewHousesList(Common.Enum.Houses.House2, DateTime.Now.AddDays(-1).Date).MapToList<CardDto>();
                case 3: return _cardRepository.GetReadyToReviewHousesList(Common.Enum.Houses.House3,DateTime.Now.AddDays(-3).Date).MapToList<CardDto>();
                case 4: return _cardRepository.GetReadyToReviewHousesList(Common.Enum.Houses.House4, DateTime.Now.AddDays(-7).Date).MapToList<CardDto>();
                case 5: return _cardRepository.GetReadyToReviewHousesList(Common.Enum.Houses.House5,DateTime.Now.AddDays(-14).Date).MapToList<CardDto>();
                default: return null;
            }
        }

        public CardDto? FirstReadyToReviewHouses(int houseNumber)
        {
            switch (houseNumber)
            {
                case 1: return _cardRepository.GetFirstReadyToReviewHousesList(Common.Enum.Houses.House1, DateTime.Now.Date)?.MapTo<CardDto>();
                case 2: return _cardRepository.GetFirstReadyToReviewHousesList(Common.Enum.Houses.House2, DateTime.Now.AddDays(-1).Date)?.MapTo<CardDto>();
                case 3: return _cardRepository.GetFirstReadyToReviewHousesList(Common.Enum.Houses.House3, DateTime.Now.AddDays(-3).Date)?.MapTo<CardDto>();
                case 4: return _cardRepository.GetFirstReadyToReviewHousesList(Common.Enum.Houses.House4, DateTime.Now.AddDays(-7).Date)?.MapTo<CardDto>();
                case 5: return _cardRepository.GetFirstReadyToReviewHousesList(Common.Enum.Houses.House5, DateTime.Now.AddDays(-14).Date)?.MapTo<CardDto>();
                default: return null;
            }
        }
    }
}
