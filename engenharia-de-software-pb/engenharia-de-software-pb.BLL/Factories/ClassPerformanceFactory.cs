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
            int presenceGrade = 0,
            int homeworkGrade = 0,
            int participationGrade = 0,
            int behaviorGrade = 0)
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
