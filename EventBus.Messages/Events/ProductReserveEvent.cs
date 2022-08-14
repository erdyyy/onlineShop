namespace EventBus.Messages.Events
{
    public class ProductReserveEvent : IntegrationBaseEvent
    {
        public int ProductId { get; set; }
    }
}
