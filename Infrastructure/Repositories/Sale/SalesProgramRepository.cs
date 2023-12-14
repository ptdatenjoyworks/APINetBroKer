using Core.Entities.Sales;
using Core.Repositories.Sale;
using Infrastructure.Context;

namespace Infrastructure.Repositories.Sale
{
    public class SalesProgramRepository : RepositoryBase<SalesProgram>, ISalesProgramRepository
    {
        public SalesProgramRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
