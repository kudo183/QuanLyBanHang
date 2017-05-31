using huypq.SmtMiddleware;
using huypq.SmtMiddleware.Entities;
using Server.Entities;
using Shared;

namespace Server.Controllers
{
    public class SmtUserClaimController : SmtUserClaimBaseController<SqlDbContext, SmtUserClaim, SmtUserClaimDto, SmtTenant, SmtUser>
    {
        public override string GetControllerName()
        {
            return nameof(SmtUserClaimController);
        }
    }
}
