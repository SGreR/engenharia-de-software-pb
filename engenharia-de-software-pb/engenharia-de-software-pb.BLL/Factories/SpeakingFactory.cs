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
            int Id = 0,
            int NotasId = 0,
            Notas Notas = null,
            int productionAndFluencyGrade = 0,
            int spokenInteractionGrade = 0,
            int languageRangeGrade = 0,
            int accuracyGrade = 0,
            int l2Use = 0)
        {
            return new Speaking
            {
                Id = Id,
                NotasId = NotasId,
                Notas = Notas,
                ProductionAndFluencyGrade = productionAndFluencyGrade,
                SpokenInteractionGrade = spokenInteractionGrade,
                LanguageRangeGrade = languageRangeGrade,
                AccuracyGrade = accuracyGrade,
                L2Use = l2Use
            };
        }
    }
}
