using SousChef.Security.Interfaces;
using SousChef.Security.Services;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace SousChef.Security.DependencyInjection
{
    public class SecurityRegistry : Registry
    {
        public SecurityRegistry()
        {
            For<IAccountManager>().Use<AccountManager>().Singleton();
            Forward<IAccountManager, ICurrentUserProvider>();

            //ForConcreteType<AccountManager>().Configure.Singleton();

            //Forward<AccountManager, IAccountManager>();
            //Forward<AccountManager, ICurrentUserProvider>();
        }
    }
}
