using huypq.SmtMiddleware;
using huypq.SmtMiddleware.Entities;
using Server.Entities;

namespace Server.Controllers
{
    public class SmtFileController : SmtFileBaseController<SqlDbContext, SmtFile>
    {
        public override string GetControllerName()
        {
            return nameof(SmtFileController);
        }
    }
}
