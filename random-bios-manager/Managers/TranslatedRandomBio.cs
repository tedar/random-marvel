using System;
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

        async Task<CharacterBioModel> ITranslatedRandomBio.GetTranslatedRandomBio()
        {
            var characterBio = await _bioManager.GetRandomBio();
            var translatedBio = "";

            if (!String.IsNullOrEmpty(characterBio?.Bio))
                translatedBio = await _translatorManager.Translate(characterBio?.Bio ?? "");

            var translatedCharacterBio = new CharacterBioModel { Name = characterBio?.Name, Bio = translatedBio };

            return translatedCharacterBio;
        }
    }
}
