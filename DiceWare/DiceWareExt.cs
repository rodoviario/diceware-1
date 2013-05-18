using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KeePass.Plugins;

namespace DiceWare
{
    public sealed class DiceWareExt : Plugin
    {
        private IPluginHost m_host;

        public override bool Initialize(IPluginHost host)
        {
            m_host = host;

            return true;
        }

    }
}
