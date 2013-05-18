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
        private IPluginHost m_host = null;
        private DiceWarePwGen m_gen = null;

        public override bool Initialize(IPluginHost host)
        {
            m_host = host;

            m_gen = new DiceWarePwGen();

            host.PwGeneratorPool.Add(m_gen);

            return true;
        }

        public override void Terminate()
        {
            if (m_host != null)
            {
                m_host.PwGeneratorPool.Remove(m_gen.Uuid);
            }
        }

    }
}
