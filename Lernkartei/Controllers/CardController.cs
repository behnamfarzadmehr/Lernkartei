using Microsoft.AspNetCore.Mvc;
using Lernkartei.Service.Abstract.Card;
using Lernkartei.Dto.Card;

namespace Lernkartei.RestApi.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class CardController: ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet("GetAll")]
        public ActionResult<IList<CardDto>> Get()
        {
            try
            {
                IList<CardDto> discountType = _cardService.GetAll();
                return Ok(discountType);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("{id}")]
        public ActionResult<IQueryable<CardDto>> Get(long id)
        {
            try
            {
                CardDto discountType = _cardService.GetById(id);
                return Ok(discountType);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult<CardDto> Post([FromBody] CardDto model)
        {
            try
            {
                model.CreateDateTime = DateTime.Now;
                CardDto discountType = _cardService.Insert(model);
                return StatusCode(StatusCodes.Status201Created, discountType);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut]
        public ActionResult<CardDto> Put([FromBody]CardDto model)
        {
            try
            {
                CardDto discountType = _cardService.Update(model);
                return StatusCode(StatusCodes.Status202Accepted, discountType);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<CardDto> Delete (long id)
        {
            try
            {
                bool discountType = _cardService.Delete(id);
                return StatusCode(StatusCodes.Status204NoContent, discountType);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut("SetCardAfterReview")]
        public ActionResult SetCardAfterReview(CardDto card)
        {
            try
            {
                bool result = _cardService.SetCardAfterReview(card);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}