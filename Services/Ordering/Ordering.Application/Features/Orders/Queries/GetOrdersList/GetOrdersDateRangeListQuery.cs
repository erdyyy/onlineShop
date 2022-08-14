using MediatR;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;
using System;
using System.Collections.Generic;

namespace Ordering.Application.Features.Orders.Queries
{
    public class GetOrdersDateRangeListQuery : IRequest<List<OrdersVm>>
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public GetOrdersDateRangeListQuery(DateTime? StartDate, DateTime? EndDate)
        {
            startDate = StartDate ?? throw new ArgumentNullException(nameof(startDate));
            endDate = EndDate ?? throw new ArgumentNullException(nameof(endDate));
        }
    }
}
