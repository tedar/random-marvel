using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace random_bios_manager.Managers
{
    public class TranslatorManager : ITranslatorManager
    {
        string ITranslatorManager.Translate(string text)
        {
            return text;
        }
    }
}
