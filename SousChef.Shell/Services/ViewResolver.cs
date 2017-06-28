using SousChef.Shell.Interfaces;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SousChef.Shell.Services
{
    public class ViewResolver : IViewResolver
    {         

        public ViewResolver()
        {
        }

        public Type ResolveViewTypeFromViewModel<TViewModel>()
        {

            var typeInfo = typeof(TViewModel).GetTypeInfo();

            var assemblyQualifiedName = typeInfo.AssemblyQualifiedName;

            var viewNamespace = typeInfo.Namespace.Replace("ViewModels", "Views");
            var viewName = typeInfo.Name;

            if(typeInfo.IsInterface)
            {
                //Strip leading "I"
                var implementationName = viewName.Substring(1);
                assemblyQualifiedName = assemblyQualifiedName.Replace(viewName, implementationName)
                                                             .Replace("Interfaces", "Views");
                                        
            }

            assemblyQualifiedName = assemblyQualifiedName.Replace("ViewModels", "Views");
            assemblyQualifiedName = assemblyQualifiedName.Replace("ViewModel", "View");
            
            var viewType = Type.GetType(assemblyQualifiedName,true);
            return viewType;
        }
    }
}
