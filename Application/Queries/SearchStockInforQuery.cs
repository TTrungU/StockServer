using Domain.Model;
using MediatR;


namespace Application.Queries
{
    public class SearchStockInforQuery : IRequest<IEnumerable<HyperLink>>
    {
        public string Symbol { get; set; }

        public SearchStockInforQuery(string symbol)
        {
            Symbol = symbol;
        }
    }
}
