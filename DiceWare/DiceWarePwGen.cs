using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using KeePass;
using KeePassLib.Cryptography.PasswordGenerator;
using KeePassLib.Cryptography;
using KeePassLib;
using KeePassLib.Security;
using KeePassLib.Utility;
using System.IO;

namespace DiceWare
{
    class DiceWarePwGen : CustomPwGenerator
    {
        private Dictionary<int, string> words = new Dictionary<int, string>(7776);

        private static readonly PwUuid m_uuid = new PwUuid(
            new byte[] {
                        0x9E, 0x61, 0x1F, 0x76, 
                        0xB0, 0xE2, 0xAF, 0x4F, 
                        0x81, 0x2, 0xF6, 0xA9, 
                        0x2F, 0x4B, 0x51, 0x30 });

        public override PwUuid Uuid { get { return m_uuid; } }
        public override string Name { get { return "Diceware"; } }
        public override bool SupportsOptions { get { return true; } }

        public DiceWarePwGen()
        {
            using (var stream = new StringReader(DiceWare.Properties.Resources.diceware))
            {
                string line = "";
                while ((line = stream.ReadLine()) != null)
                {
                    var word = line.Split('\t');
                    words.Add(int.Parse(word[0]), word[1].Trim());
                }
            }
        }

        public override string GetOptions(string strCurrentOptions)
        {
            var opt = new DiceWareOptionsForm(strCurrentOptions);

            if (KeePass.UI.UIUtil.ShowDialogAndDestroy(opt) == System.Windows.Forms.DialogResult.OK)
            {
                return opt.GetOptions();
            }

            return strCurrentOptions;
        }

        public override ProtectedString Generate(PwProfile prf, CryptoRandomStream crsRandomSource)
        {

            Random r = new Random((int)crsRandomSource.GetRandomUInt64());
            var opt = new DiceWareOptions(prf.CustomAlgorithmOptions);

            string result = "";
            int word = 0;

            for (int i = 0; i < 5 * opt.WordCount; i++)
            {
                word *= 10;
                word += (1 + r.Next(6));

                if ((i + 1) % 5 == 0 && i > 0)
                {
                    result += words[word];
                    result += " ";

                    word = 0;
                }
            }

            return new ProtectedString(true, result.Trim());
        }

        internal void Terminate()
        {
            words = null;
        }
    }
}
