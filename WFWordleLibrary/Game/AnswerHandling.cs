using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFWordleLibrary.Model;
using WFWordleLibrary.Model.Database;

namespace WFWordleLibrary.Game
{
    public class AnswerHandling
    {
        public static WarframeGuessAnswer GetWarframeAnswer(Warframe selected, Warframe guess)
        {
            WarframeGuessAnswer answer = new()
            {
                GenderGuessed = Compare<int>(selected.Gender, guess.Gender),
                ExaltedsGuessed = HighLowCompare<int>(selected.HasExalteds, guess.HasExalteds),
                HasPrimeGuessed = Compare<bool>(selected.HasPrime, guess.HasPrime),
                ReleaseUpdateGuessed = HighLowCompare<int>(selected.ReleasedInUpdate, guess.ReleasedInUpdate),
                AuraGuessed = Compare<int>(selected.AuraPolarity, guess.AuraPolarity),
                ProgenitorGuessed = Compare<int>(selected.ProgenitorElement, guess.ProgenitorElement),
                SubsumedGuessed = Compare<int>(selected.SubsumedAbility, guess.SubsumedAbility),
                TacticalGuessed = Compare<int>(selected.TacticalAbility, guess.TacticalAbility),
                HealthGuessed = HighLowCompare<int>(selected.Health, guess.Health),
                ShieldsGuessed = HighLowCompare<int>(selected.Shields, guess.Shields),
                ArmorGuessed = HighLowCompare<int>(selected.Armor, guess.Armor),
                EnergyGuessed = HighLowCompare<int>(selected.Energy, guess.Energy),
               SprintGuessed = HighLowCompare<decimal>(selected.SprintSpeed, guess.SprintSpeed)
            };
            return answer;
        }

        static AnswerTypes Compare<T>(T selected, T guess)
        {
            Comparer<T> comp = Comparer<T>.Default;
            if (comp.Compare(selected, guess) == 0)
            {
                return AnswerTypes.Correct;
            }
            return AnswerTypes.Wrong;
        }

        static AnswerTypes SoftCompare<T>(List<T> selected, List<T> guess)
        {
            if (selected.Intersect(guess).Count() == selected.Count)
            {
                return AnswerTypes.Correct;
            }
            if (selected.Intersect(guess).Any())
            {
                return AnswerTypes.Semicorrect;
            }
            return AnswerTypes.Wrong;
        }

        static AnswerTypes HighLowCompare<T>(T selected, T guess)
        {
            Comparer<T> comp = Comparer<T>.Default;
            if (comp.Compare(selected, guess) == 0)
            {
                return AnswerTypes.Correct;
            }
            if (comp.Compare(selected, guess) > 0)
            {
                return AnswerTypes.Higher;
            }
            if (comp.Compare(selected, guess) < 0)
            {
                return AnswerTypes.Lower;
            }
            return AnswerTypes.Wrong;
        }
    }
}
