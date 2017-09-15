using huypq.SmtMiddleware;
using huypq.SmtMiddleware.Entities;
using Server.Entities;

namespace Server.Controllers
{
    public class SmtImageFileController : SmtImageFileBaseController<SqlDbContext, SmtFile>
    {
        public override string GetControllerName()
        {
            return nameof(SmtImageFileController);
        }
    }
}
