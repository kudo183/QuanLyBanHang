using huypq.SmtMiddleware;
using huypq.SmtMiddleware.Entities;
using Server.Entities;

namespace Server.Controllers
{
    public class SmtController : SmtBaseController<SqlDbContext, SmtTenant, SmtUser, SmtUserClaim>
    {
        public override string GetControllerName()
        {
            return nameof(SmtController);
        }
    }
}
