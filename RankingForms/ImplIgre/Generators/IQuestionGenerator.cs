using System.Collections.Generic;

namespace RankingForms.ImplIgre.Generators
{
    public interface IQuestionGenerator
    {
        List<Question> GenerateNextQuestions();
        void Clear();
    }
}