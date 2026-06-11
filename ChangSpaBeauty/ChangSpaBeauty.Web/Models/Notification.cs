namespace ChangSpaBeauty.Web.Models
{
    public class Notification
    {
        public string Message { get; set; } = string.Empty;
        public string OrderStatus { get; set; } = string.Empty;
        public int OrderId {  get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
