using Lernkartei.Test.Persist;
using Microsoft.EntityFrameworkCore;
using Swish.InfraStructure.context;
using Lernkartei.Service.Abstract.Card;
using Lernkartei.Domain.Abstraction;
using Lernkartei.Infrastructure.Concrete;
using Lernkartei.Service.Concrete.Card;
using FluentAssertions;
using Lernkartei.Dto.Card;

namespace Lernkartei.Test
{
    public class LernKarteiActionsTest : PersistTest
    {
        DbContextOptionsBuilder<LernkarteiContext> optionsBuilder = new();
        private readonly LernkarteiContext _contex;
        private readonly ICardHouseRepository _cardHouseRepository;
        private readonly ICardHouseService _cardHouseService;
        public LernKarteiActionsTest()
        {
            optionsBuilder.UseSqlServer(GlobalVariables.connectionstring);
            _contex = new LernkarteiContext(optionsBuilder.Options);
            _cardHouseRepository = new CardHouseRepository(_contex);
            _cardHouseService = new CardHouseService(_cardHouseRepository); 
        }
        [Fact]
        public void HousesCount_GreatherThanOrEqualZero()
        {
            int count = _cardHouseService.CardOfHouseCount(1);
            count.Should().BeGreaterThan(-1);
        }
        [Fact]
        public void ReadyToReviewHousesCount_GreatherThanOrEqualZero()
        {
            int count = _cardHouseService.ReadyToReviewHausesCount(2);
            count.Should().BeGreaterThan(-1);
        }
        [Fact]
        public void ReadyToReviewHousesList_NotThrowException()
        {
            IList<CardDto>? list = _cardHouseService.ReadyToReviewHousesList(1);
            list.Should().NotBeNull();
        }
    }
}
