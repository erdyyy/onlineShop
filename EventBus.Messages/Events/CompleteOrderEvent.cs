namespace EventBus.Messages.Events
{
    public class CompleteOrderEvent : IntegrationBaseEvent
    {
        //Order information
        public string OrderNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TaxAmount { get; set; }


        //Product information
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Unit { get; set; }


        //Customer information
        public string CustomerFullName { get; set; }
        public string CustomerAdress { get; set; }
        public string CargoTrackingNumer { get; set; }
    }
}
