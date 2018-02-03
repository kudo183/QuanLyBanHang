using huypq.SmtWpfClientSQL;

namespace SQLClient.DataController
{
    public class SmtController : SmtBaseController<Entity.SqlDbContext, SmtTenant, SmtUser, SmtUserClaim>
    {
    }
}
