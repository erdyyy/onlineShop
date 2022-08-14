using System;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class OrdersVm
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TaxAmount { get; set; }
        public DateTime OrderDate { get; set; }


        //Product information
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductSummary { get; set; }
        public int Unit { get; set; }


        //Customer information
        public string CustomerFullName { get; set; }
        public string CustomerAdress { get; set; }
        public string CargoTrackingNumer { get; set; }
        public string Country { get; set; }
    }
}
