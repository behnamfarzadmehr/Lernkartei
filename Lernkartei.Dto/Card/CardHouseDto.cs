using Lernkartei.Common.Enum;

namespace Lernkartei.Dto.Card
{
    public class CardHouseDto
    {
        /// <summary>
        /// کلید اصلی
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// کلید خارجی با جدول card
        /// </summary>
        public long CardId { get; set; }
        /// <summary>
        /// شماره خانه
        /// </summary>
        public Houses House { get; set; }
        /// <summary>
        /// تاریخ ورود به خانه
        /// </summary>
        public DateTime ActionDate { get; set; }
    }
}
