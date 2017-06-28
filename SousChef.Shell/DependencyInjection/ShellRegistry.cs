using SousChef.Shell.Interfaces;
using SousChef.Shell.Services;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SousChef.Shell.DependencyInjection
{
    public class ShellRegistry : Registry
    {
        public ShellRegistry()
        {
            For<INavigator>().UseIfNone<Navigator>();
            For<IViewResolver>().UseIfNone<ViewResolver>();
            For<IRelayCommandFactory>().UseIfNone<RelayCommandFactory>();
        }
    }
}
