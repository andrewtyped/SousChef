using Metrology.Interfaces;
using Metrology.Models;
using StructureMap;
using StructureMap.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrology.DependencyInjection
{
    public class MetrologyStructureMapRegistry : Registry
    {
        public MetrologyStructureMapRegistry()
        {
            For<IUnit>().Use<Pound>().LifecycleIs<SingletonLifecycle>();
        }
    }
}
