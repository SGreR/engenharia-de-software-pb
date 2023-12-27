using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using engenharia_de_software_pb.BLL.Models;

namespace engenharia_de_software_pb.BLL.Factories
{
    public static class ClassPerformanceFactory
    {
        public static ClassPerformance CreateClassPerformance(
            int presenceGrade,
            int homeworkGrade,
            int participationGrade,
            int behaviorGrade)
        {
            return new ClassPerformance
            {
                PresenceGrade = presenceGrade,
                HomeworkGrade = homeworkGrade,
                ParticipationGrade = participationGrade,
                BehaviorGrade = behaviorGrade
            };
        }
    }
}
