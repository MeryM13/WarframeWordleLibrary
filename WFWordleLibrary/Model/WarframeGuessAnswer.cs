using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFWordleLibrary.Model
{
    public class WarframeGuessAnswer
    {
       public AnswerTypes GenderGuessed { get; set; } = AnswerTypes.Wrong;
        public AnswerTypes ExaltedsGuessed { get; set; } = AnswerTypes.Lower;
        public AnswerTypes HasPrimeGuessed { get; set; } = AnswerTypes.Wrong;
        public AnswerTypes ReleaseUpdateGuessed { get; set; } = AnswerTypes.Higher;
        public AnswerTypes AuraGuessed { get; set; } = AnswerTypes.Wrong;
        public AnswerTypes ProgenitorGuessed { get; set; } = AnswerTypes.Wrong;
        public AnswerTypes SubsumedGuessed { get; set; } = AnswerTypes.Wrong;
        public AnswerTypes TacticalGuessed { get; set; } = AnswerTypes.Wrong;
        public AnswerTypes HealthGuessed { get; set; } = AnswerTypes.Higher;
        public AnswerTypes ShieldsGuessed { get; set; } = AnswerTypes.Higher;
        public AnswerTypes ArmorGuessed { get; set; } = AnswerTypes.Higher;
        public AnswerTypes EnergyGuessed { get; set; } = AnswerTypes.Higher;
        public AnswerTypes SprintGuessed { get; set; } = AnswerTypes.Higher;
        public AnswerTypes AcquisitionGuessed { get; set; } = AnswerTypes.Wrong;
    }
}
