using System;
using System.Collections.Generic;
using System.Text;

namespace SousChef.Security.Interfaces
{
    public interface ICurrentUserProvider
    {
        ICurrentUser CurrentUser { get; }
    }
}
