using huypq.SmtMiddleware;
using huypq.SmtMiddleware.Entities;
using Server.Entities;
using Shared;

namespace Server.Controllers
{
    public class SmtUserController : SmtUserBaseController<SqlDbContext, SmtUser, SmtUserDto>
    {
        public override string GetControllerName()
        {
            return nameof(SmtUserController);
        }
    }
}
