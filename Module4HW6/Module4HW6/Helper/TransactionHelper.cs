using System;
using System.Threading.Tasks;
using Module4HW6.Data;

namespace Module4HW6.Helper
{
    public class TransactionHelper
    {
        private readonly ApplicationDbContext _context;

        public TransactionHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task ExecuteTransaction(Func<Task> func)
        {
            await using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await func.Invoke();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                }
            }
        }
    }
}