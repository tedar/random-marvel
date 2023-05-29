using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace random_bios_manager.Interfaces
{
    public interface IBioManager
    {
        public Task<string?> GetRandomBio();
    }
}
