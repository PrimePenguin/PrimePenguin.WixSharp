namespace WixSharp.Entities
{
    public class ProductHook
    {
        public Product Product { get; set; }
        public string HookType { get; set; }
        public string ProductId { get; set; }
        public int SaleChannelId { get; set; }
    }
}