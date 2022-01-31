using System.Threading.Tasks;
using Module4HW6.Helper;

namespace Module4HW6
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await using (var context = new ContextFactory().CreateDbContext(args))
            {
                var init = new DbInitializer(context, new TransactionHelper(context));
                await init.InitializeArtistTable();
                await init.InitializeGenreTable();
                await init.InitializeSongTable();

                await new QueriesTask(context).Run();
            }
        }
    }
}
