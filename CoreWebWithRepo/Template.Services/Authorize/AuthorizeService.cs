using System;
using Template.Contracts.IServices;

namespace Template.Services.Authorize
{
    public partial class AuthorizeService : IAuthorizeService
    {
        public virtual string GenerateToken(object model)
        {
            throw new NotImplementedException();
        }
    }
}
