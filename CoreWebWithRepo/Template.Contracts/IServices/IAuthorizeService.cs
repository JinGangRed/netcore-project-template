using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Contracts.IServices
{
    public interface IAuthorizeService
    {
        /// <summary>
        /// Generate an access Token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        string GenerateToken(object model);
    }
}
