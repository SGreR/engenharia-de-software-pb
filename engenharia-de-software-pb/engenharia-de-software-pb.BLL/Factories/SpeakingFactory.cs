using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using engenharia_de_software_pb.BLL.Models;

namespace engenharia_de_software_pb.BLL.Factories
{
    public static class SpeakingFactory
    {
        public static Speaking CreateSpeaking(
            int productionAndFluencyGrade,
            int spokenInteractionGrade,
            int languageRangeGrade,
            int accuracyGrade,
            int l2Use)
        {
            return new Speaking
            {
                ProductionAndFluencyGrade = productionAndFluencyGrade,
                SpokenInteractionGrade = spokenInteractionGrade,
                LanguageRangeGrade = languageRangeGrade,
                AccuracyGrade = accuracyGrade,
                L2Use = l2Use
            };
        }
    }
}
