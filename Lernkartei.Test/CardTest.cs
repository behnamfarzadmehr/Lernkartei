using FluentAssertions;
using Lernkartei.Common.Enum;
using Lernkartei.Domain.Abstraction;
using Lernkartei.Domain.Entities;
using Lernkartei.Dto.Card;
using Lernkartei.Infrastructure.Concrete;
using Lernkartei.Service.Abstract.Card;
using Lernkartei.Service.Concrete.Card;
using Lernkartei.Test.Persist;
using Microsoft.EntityFrameworkCore;
using Swish.InfraStructure.context;

namespace Lernkartei.Test
{
    public class CardTest : PersistTest
    {
        DbContextOptionsBuilder<LernkarteiContext> optionsBuilder = new();
        private readonly ICardService _cardService;
        private readonly ICardRepository _cardREpository;
        private readonly ICardHouseRepository _cardHouseRepository;
        private readonly LernkarteiContext _contex;
        public CardTest()
        {
            optionsBuilder.UseSqlServer(GlobalVariables.connectionstring);
            _contex = new LernkarteiContext(optionsBuilder.Options);
            _cardREpository = new CardRepository(_contex);
            _cardHouseRepository = new CardHouseRepository(_contex);
            _cardService = new CardService(_cardREpository, _cardHouseRepository);
        }
        [Fact]
        public void Add_Card_SuccessfullyAddRowToCard()
        {
            CardDto model = new CardDto
            {
                Id = 0,
                Front = "انجام دادن",
                Back = "Machen",
                WordTypes = WordTypes.Verb,
                Artikle = Artikle.Null,
                Plural = null,
                Perfekt = "gemacht",
                CreateDateTime = DateTime.Now,
            };
            CardDto result = _cardService.Add(model);
            CardHouse cardHouse = new CardHouse
            {
                ActionDate = DateTime.Now,
                CardId = result.Id,
                House = Common.Enum.Houses.House1,
                Id = 0
            };
            _cardHouseRepository.Add(cardHouse);
            result.Id.Should().BeGreaterThan(0);
        }
    }
}