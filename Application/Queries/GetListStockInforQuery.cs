using Application.Models.StockInforModel;
using MediatR;


namespace Application.Queries
{
    public class GetListStockInforQuery :IRequest<IEnumerable<StockInforResponse>>
    {
    }
}
