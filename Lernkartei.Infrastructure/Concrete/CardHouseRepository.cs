using Lernkartei.Common.Enum;
using Lernkartei.Domain.Abstraction;
using Lernkartei.Domain.Entities;
using Lernkartei.InfraStructure.Concrete.Repository;
using Swish.InfraStructure.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernkartei.Infrastructure.Concrete
{
    public class CardHouseRepository : Repository<CardHouse>, ICardHouseRepository
    {
        private readonly LernkarteiContext _context;
        public CardHouseRepository(LernkarteiContext context) : base(context)
        {
            _context = context;
        }

        public Card? GetFirstReadyToReviewHousesList(Houses house1, DateTime date)
        {
            var result = (from a in _context.Card
                          join b in _context.CardHouse on a.Id equals b.CardId
                          where b.ActionDate.Date < date
                          && b.House == house1
                          select new Card
                          {
                              Id = a.Id,
                              Artikle = a.Artikle,
                              Back = a.Back,
                              Front = a.Front,
                              Perfekt = a.Perfekt,
                              Plural = a.Plural,
                              WordTypes = a.WordTypes,
                              CreateDateTime = a.CreateDateTime,
                          }).ToList();
            return result.FirstOrDefault();
        }

        public IList<Card> GetReadyToReviewHousesList(Common.Enum.Houses houseNumber, DateTime date)
        {
            var result = (from a in _context.Card
                          join b in _context.CardHouse on a.Id equals b.CardId
                          where b.ActionDate.Date < date
                          && b.House == houseNumber
                          select new Card
                          {
                              Id = a.Id,
                              Artikle = a.Artikle,
                              Back = a.Back,
                              Front = a.Front,
                              Perfekt = a.Perfekt,
                              Plural = a.Plural,
                              WordTypes = a.WordTypes,
                              CreateDateTime = a.CreateDateTime,
                          }).ToList();
                         return result;
        }
    }
}
