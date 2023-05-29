using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace random_bios_manager.Managers
{
    public class BioManager : IBioManager
    {
        string IBioManager.GetRandomBio()
        {
            return "Capitain America spent decades frozen";
        }
    }
}
