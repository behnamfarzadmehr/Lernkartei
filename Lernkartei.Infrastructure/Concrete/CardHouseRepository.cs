using Lernkartei.Common.Enum;
using Lernkartei.Domain.Abstraction;
using Lernkartei.Domain.Entities;
using Lernkartei.InfraStructure.Concrete.Repository;
using Swish.InfraStructure.context;

namespace Lernkartei.Infrastructure.Concrete;

public class CardHouseRepository : Repository<CardHouse>, ICardHouseRepository
{
    private readonly LernkarteiContext _context;
    public CardHouseRepository(LernkarteiContext context) : base(context)
    {
        _context = context;
    }

    public Card? GetFirstReadyToReviewHousesList(Houses houseNumber, DateTime date)
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
                          KomParativ = a.KomParativ,
                          Superlativ = a.Superlativ
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
                          KomParativ = a.KomParativ,
                          Superlativ = a.Superlativ
                      }).ToList();
                     return result;
    }

    IList<Card> ICardHouseRepository.GetReadyToReviewHousesList(Houses houseNumber, DateTime date)
    {
        return (from a in _context.Card
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
                    KomParativ = a.KomParativ,
                    Superlativ = a.Superlativ
                }).ToList();
    }
}
