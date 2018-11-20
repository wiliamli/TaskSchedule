using Autofac;
using Jwell.Framework.Configure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Modules.Configure
{
    public class JwellConfigModule:Framework.Modules.JwellModule
    {
        public override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
        }
    }
}
