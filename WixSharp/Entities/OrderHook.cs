namespace WixSharp.Entities
{
    public class OrderHook
    {
        public Order Order { get; set; }
        public string HookType { get; set; }
        public string OrderId { get; set; }
        public int SaleChannelId { get; set; }
    }
}