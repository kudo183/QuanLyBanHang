using huypq.SmtMiddleware;
using huypq.SmtMiddleware.Entities;
using huypq.QueryBuilder;
using Server.Entities;
using Shared;

namespace Server.Controllers
{
    public class SmtUserController : SmtUserBaseController<SqlDbContext, SmtUser, SmtUserDto>
    {
        protected override OrderByExpression.OrderOption GetDefaultOrderOption()
        {
            return new OrderByExpression.OrderOption()
            {
                PropertyPath = "ID",
                IsAscending = true
            };
        }

        public override string GetControllerName()
        {
            return nameof(SmtUserController);
        }
    }
}
