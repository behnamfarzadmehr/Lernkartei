using Lernkartei.Dto.Card;
using Lernkartei.Service.Abstract.Card;
using Microsoft.AspNetCore.Mvc;


namespace Lernkartei.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class CardHouseController : ControllerBase
    {
        private readonly ICardHouseService _cardHouseService;
        public CardHouseController(ICardHouseService cardHouseService)
        {
            _cardHouseService = cardHouseService;
        }
        [HttpGet("CardOfHouseCount")]
        public ActionResult<int> CardOfHouseCount(byte houseNumber)
        {
            try
            {
                int count = _cardHouseService.CardOfHouseCount(houseNumber);
                return Ok(count);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("ReadyToReviewHausesCount")]
        public ActionResult<int> ReadyToReviewHausesCount(int houseNumber)
        {
            try
            {
                int count = _cardHouseService.ReadyToReviewHausesCount(houseNumber);
                return Ok(count);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("ReadyToReviewHousesList")]
        public ActionResult<IList<CardDto>?> ReadyToReviewHousesList(int houseNumber)
        {
            try
            {
                IList<CardDto>? list = _cardHouseService.ReadyToReviewHousesList(houseNumber);
                return Ok(list);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("FirstReadyToReviewCard")]
        public ActionResult<CardDto?> FirstReadyToReviewCard(int houseNumber)
        {
            try
            {
                CardDto? card = _cardHouseService.FirstReadyToReviewHouses(houseNumber);
                return Ok(card);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
