using Lernkartei.Domain.Abstraction;
using Lernkartei.Domain.Entities;
using Lernkartei.InfraStructure.Concrete.Repository;
using Swish.InfraStructure.context;

namespace Lernkartei.Infrastructure.Concrete
{
    public class CardRepository : Repository<Card> , ICardRepository
    {
        private readonly LernkarteiContext _context;
        public CardRepository(LernkarteiContext context) : base(context)
        {
            _context = context;
        }
    }
}
