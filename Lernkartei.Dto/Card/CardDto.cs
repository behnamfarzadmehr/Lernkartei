using Lernkartei.Common.Enum;

namespace Lernkartei.Dto.Card;

public record CardDto
{
    public CardDto()
    {
        Front = "";
        Back = "";
    }
    /// <summary>
    /// کلید جدول
    /// </summary>
    public long Id { get; set; }
    /// <summary>
    /// نوشته روی کارت
    /// </summary>
    public string Front { get; set; }
    /// <summary>
    /// نوشته پشت کارت
    /// </summary>
    public string Back { get; set; }
    /// <summary>
    /// نوع کلمه مانند فعل یا اسم
    /// </summary>
    public WordTypes WordTypes { get; set; }
    /// <summary>
    /// آرتیکل اگر اسم بود
    /// </summary>
    public Artikle Artikle { get; set; }
    /// <summary>
    /// جمع اگر اسم بود
    /// </summary>
    public string? Plural { get; set; }
    /// <summary>
    /// پرفکت اگر فعل بود
    /// </summary>
    public string? Perfekt { get; set; }
    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime? CreateDateTime { get; set; }
    /// <summary>
    /// تفضیلی اگر صفت بود
    /// </summary>
    public string? KomParativ { get; set; }
    /// <summary>
    /// تفضیلی برتر اگر صفت بود
    /// </summary>
    public string? Superlativ { get; set; }
}
