using Lernkartei.Dto.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernkartei.Service.Abstract.Card
{
    public interface ICardService : IMainService<CardDto>
    {
        public CardDto Insert(CardDto model);
        bool SetCardAfterReview(CardDto card);
    }
}
