using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SousChef.Shell.Interfaces
{
    public interface IViewResolver
    {
        Type ResolveViewTypeFromViewModel<TViewModel>();
    }
}
