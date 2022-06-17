using System;
using System.Threading.Tasks;
using Trades.Application.Enums;
using Trades.Domain.Core.Interfaces.Repositorys;
using Trades.Domain.Entitys;

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

        public async Task<TradeCategory> GetTradeCategories(Trade trade)
        {
            try
            {
                return await Get((x => x.ClientSector == trade.ClientSector && x.Symbol == (int)MathSymbolsEnum.Equality && x.Value == trade.Value ||
                                       x.ClientSector == trade.ClientSector && x.Symbol == (int)MathSymbolsEnum.LessThan && trade.Value < x.Value ||
                                       x.ClientSector == trade.ClientSector && x.Symbol == (int)MathSymbolsEnum.GreaterThan && trade.Value >= x.Value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}