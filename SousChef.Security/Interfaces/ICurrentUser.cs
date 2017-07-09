using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SousChef.Security.Interfaces
{
    public interface ICurrentUser
    {
        string AccessToken { get; }
        string DisplayableId { get; }
        string Name { get; }
        string Identifier { get; }
    }
}
