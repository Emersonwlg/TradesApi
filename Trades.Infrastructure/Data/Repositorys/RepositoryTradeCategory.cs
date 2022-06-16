using Trades.Domain.Core.Interfaces.Repositorys;
using Trades.Domain.Entitys;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Trades.Infrastructure.Data.Repositorys
{
    public class RepositoryTradeCategory : RepositoryBase<TradeCategory>, IRepositoryTradeCategory
    {
        private readonly SqlContext _sqlContext;

        public RepositoryTradeCategory(SqlContext sqlContext)
            : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public TradeCategory GetTradeCategories(Portfolio portfolio)
        {
            try
            {
                return  _sqlContext.Set<TradeCategory>().Where(x => x.Value < portfolio.Value || x.Value > portfolio.Value
                                                             && x.ClientSector == portfolio.ClientSector).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}