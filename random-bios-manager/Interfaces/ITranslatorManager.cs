using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace random_bios_manager.Interfaces
{
    public interface ITranslatorManager
    {
        public Task<string> Translate(string text);
    }
}
