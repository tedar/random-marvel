﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace random_bios_manager.Managers
{
    public class TranslatedRandomBio : ITranslatedRandomBio
    {
        private readonly IBioManager _bioManager;
        private readonly ITranslatorManager _translatorManager;

        public TranslatedRandomBio(IBioManager bioManager, ITranslatorManager translatorManager)
        {
            _bioManager = bioManager;
            _translatorManager = translatorManager;
        }

        string ITranslatedRandomBio.GetTranslatedRandomBio()
        {
            return _translatorManager.Translate(_bioManager.GetRandomBio());
        }
    }
}