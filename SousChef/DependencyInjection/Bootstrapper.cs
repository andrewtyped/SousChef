using StructureMap;
using StructureMap.Graph.Scanning;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SousChef.DependencyInjection
{
    public class Bootstrapper : IDisposable
    {
        public IContainer Container
        {
            get;
            private set;
        }

        public void Dispose()
        {
            this.Container.Dispose();
        }

        public void Initialize()
        {
            Container = new Container();

            Container.Configure(cfg =>
                {
                    cfg.Scan(scan =>
                    {
                        scan.TheCallingAssembly();
                        scan.AssembliesFromApplicationBaseDirectory(assembly =>
                        {
                            var isSystemAssembly = assembly.FullName.StartsWith("System.");
                            var isSousChefAssembly = assembly.FullName.StartsWith("SousChef");
                            var isMetrologyAssembly = assembly.FullName.StartsWith("Metrology");

                            return !isSystemAssembly && (isSousChefAssembly || isMetrologyAssembly);
                        });
                        scan.LookForRegistries();
                        scan.WithDefaultConventions();

                    });
                });

#if DEBUG
            TypeRepository.AssertNoTypeScanningFailures();

            var scanReport = Container.WhatDidIScan();
            var registryReport = Container.WhatDoIHave();

            Debug.WriteLine(scanReport);
            Debug.WriteLine(registryReport);
#endif
        }
    }
}
