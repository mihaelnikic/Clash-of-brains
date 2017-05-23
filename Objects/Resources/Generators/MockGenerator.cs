using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Java.Util;
using Objects.Answers;
using Random = System.Random;

namespace Objects.Generators
{
    public class MockGenerator : IQuestionGenerator
    {

        public List<Question> Questions;
        private Random random;

        public MockGenerator()
        {
            Questions = new List<Question>();
            random = new Random();
            Questions.Add(new Question(1, "#POVIJEST1", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#1"), Kategorija.Povijest, "#POVIJEST1"));
            Questions.Add(new Question(2, "#POVIJEST2", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#2"), Kategorija.Povijest, "#POVIJEST2"));
            Questions.Add(new Question(3, "#POVIJEST3", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#3"), Kategorija.Povijest, "#POVIJEST3"));
            Questions.Add(new Question(4, "#POVIJEST4", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#4"), Kategorija.Povijest, "#POVIJEST4"));
            Questions.Add(new Question(5, "#POVIJEST5", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#1"), Kategorija.Povijest, "#POVIJEST5"));
            Questions.Add(new Question(6, "#POVIJEST6", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#2"), Kategorija.Povijest, "#POVIJEST6"));
            Questions.Add(new Question(7, "#POVIJEST7", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#3"), Kategorija.Povijest, "#POVIJEST7"));
            Questions.Add(new Question(8, "#POVIJEST8", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#4"), Kategorija.Povijest, "#POVIJEST8"));
            Questions.Add(new Question(9, "#POVIJEST9", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#1"), Kategorija.Povijest, "#POVIJEST9"));
            Questions.Add(new Question(10, "#POVIJEST10", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#2"), Kategorija.Povijest, "#POVIJEST10"));
            Questions.Add(new Question(11, "#ZEMLJOPIS1", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#1"), Kategorija.Zemljopis, "#ZEMLJOPIS1"));
            Questions.Add(new Question(12, "#ZEMLJOPIS2", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#2"), Kategorija.Zemljopis, "#ZEMLJOPIS2"));
            Questions.Add(new Question(13, "#ZEMLJOPIS3", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#3"), Kategorija.Zemljopis, "#ZEMLJOPIS3"));
            Questions.Add(new Question(14, "#ZEMLJOPIS4", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#4"), Kategorija.Zemljopis, "#ZEMLJOPIS4"));
            Questions.Add(new Question(15, "#ZEMLJOPIS5", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#1"), Kategorija.Zemljopis, "#ZEMLJOPIS5"));
            Questions.Add(new Question(16, "#ZEMLJOPIS6", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#2"), Kategorija.Zemljopis, "#ZEMLJOPIS6"));
            Questions.Add(new Question(17, "#ZEMLJOPIS7", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#3"), Kategorija.Zemljopis, "#ZEMLJOPIS7"));
            Questions.Add(new Question(18, "#ZEMLJOPIS8", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#4"), Kategorija.Zemljopis, "#ZEMLJOPIS8"));
            Questions.Add(new Question(19, "#ZEMLJOPIS9", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#1"), Kategorija.Zemljopis, "#ZEMLJOPIS9"));
            Questions.Add(new Question(20, "#ZEMLJOPIS10", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#2"), Kategorija.Zemljopis, "#ZEMLJOPIS10"));
            Questions.Add(new Question(21, "#TEHNOLOGIJA1", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#1"), Kategorija.Tehnologija, "#TEHNOLOGIJA1"));
            Questions.Add(new Question(22, "#TEHNOLOGIJA2", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#2"), Kategorija.Tehnologija, "#TEHNOLOGIJA2"));
            Questions.Add(new Question(23, "#TEHNOLOGIJA3", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#3"), Kategorija.Tehnologija, "#TEHNOLOGIJA3"));
            Questions.Add(new Question(24, "#TEHNOLOGIJA4", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#4"), Kategorija.Tehnologija, "#TEHNOLOGIJA4"));
            Questions.Add(new Question(25, "#TEHNOLOGIJA5", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#1"), Kategorija.Tehnologija, "#TEHNOLOGIJA5"));
            Questions.Add(new Question(26, "#TEHNOLOGIJA6", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#2"), Kategorija.Tehnologija, "#TEHNOLOGIJA6"));
            Questions.Add(new Question(27, "#TEHNOLOGIJA7", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#3"), Kategorija.Tehnologija, "#TEHNOLOGIJA7"));
            Questions.Add(new Question(28, "#TEHNOLOGIJA8", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#4"), Kategorija.Tehnologija, "#TEHNOLOGIJA8"));
            Questions.Add(new Question(29, "#TEHNOLOGIJA9", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#1"), Kategorija.Tehnologija, "#TEHNOLOGIJA9"));
            Questions.Add(new Question(30, "#TEHNOLOGIJA10", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#2"), Kategorija.Tehnologija, "#TEHNOLOGIJA10"));
            Questions.Add(new Question(31, "#ZABAVA1", null,
               new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#1"), Kategorija.Zabava, "#ZABAVA1"));
            Questions.Add(new Question(32, "#ZABAVA2", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#2"), Kategorija.Zabava, "#ZABAVA2"));
            Questions.Add(new Question(33, "#ZABAVA3", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#3"), Kategorija.Zabava, "#ZABAVA3"));
            Questions.Add(new Question(34, "#ZABAVA4", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#4"), Kategorija.Zabava, "#ZABAVA4"));
            Questions.Add(new Question(35, "#ZABAVA5", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#1"), Kategorija.Zabava, "#ZABAVA5"));
            Questions.Add(new Question(36, "#ZABAVA6", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#2"), Kategorija.Zabava, "#ZABAVA6"));
            Questions.Add(new Question(37, "#ZABAVA7", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#3"), Kategorija.Zabava, "#ZABAVA7"));
            Questions.Add(new Question(38, "#ZABAVA8", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#4"), Kategorija.Zabava, "#ZABAVA8"));
            Questions.Add(new Question(39, "#ZABAVA9", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#1"), Kategorija.Zabava, "#ZABAVA9"));
            Questions.Add(new Question(40, "#ZABAVA10", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#2"), Kategorija.Zabava, "#ZABAVA10"));
            Questions.Add(new Question(41, "#ZNANOST1", null,
               new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#1"), Kategorija.Znanost, "#ZNANOST1"));
            Questions.Add(new Question(42, "#ZNANOST2", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#2"), Kategorija.Znanost, "#ZNANOST2"));
            Questions.Add(new Question(43, "#ZNANOST3", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#3"), Kategorija.Znanost, "#ZNANOST3"));
            Questions.Add(new Question(44, "#ZNANOST4", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#4"), Kategorija.Znanost, "#ZNANOST4"));
            Questions.Add(new Question(45, "#ZNANOST5", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#1"), Kategorija.Znanost, "#ZNANOST5"));
            Questions.Add(new Question(46, "#ZNANOST6", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#2"), Kategorija.Znanost, "#ZNANOST6"));
            Questions.Add(new Question(47, "#ZNANOST7", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#3"), Kategorija.Znanost, "#ZNANOST7"));
            Questions.Add(new Question(48, "#ZNANOST8", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#4"), Kategorija.Znanost, "#ZNANOST8"));
            Questions.Add(new Question(49, "#ZNANOST9", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#1"), Kategorija.Znanost, "#ZNANOST9"));
            Questions.Add(new Question(50, "#ZNANOST10", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#2"), Kategorija.Znanost, "#ZNANOST10"));
            Questions.Add(new Question(51, "#UMJETNOST1", null,
               new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#1"), Kategorija.Umjetnost, "#UMJETNOST1"));
            Questions.Add(new Question(52, "#UMJETNOST2", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#2"), Kategorija.Umjetnost, "#UMJETNOST2"));
            Questions.Add(new Question(53, "#UMJETNOST3", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#3"), Kategorija.Umjetnost, "#UMJETNOST3"));
            Questions.Add(new Question(54, "#UMJETNOST4", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#4"), Kategorija.Umjetnost, "#UMJETNOST4"));
            Questions.Add(new Question(55, "#UMJETNOST5", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#1"), Kategorija.Umjetnost, "#UMJETNOST5"));
            Questions.Add(new Question(56, "#UMJETNOST6", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#2"), Kategorija.Umjetnost, "#UMJETNOST6"));
            Questions.Add(new Question(57, "#UMJETNOST7", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#3"), Kategorija.Umjetnost, "#UMJETNOST7"));
            Questions.Add(new Question(58, "#UMJETNOST8", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#4"), Kategorija.Umjetnost, "#UMJETNOST8"));
            Questions.Add(new Question(59, "#UMJETNOST9", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#1"), Kategorija.Umjetnost, "#UMJETNOST9"));
            Questions.Add(new Question(60, "#UMJETNOST10", null,
                new ZaokruzivanjeAnswer("#1", "#2", "#3", "#4", "#2"), Kategorija.Umjetnost, "#UMJETNOST10"));
        }


        public Question[] GenerateNextQuestions()
        {
            int count = 0;
            Question[] questions = new Question[4];
            Dictionary<Kategorija, Question> dict = new Dictionary<Kategorija, Question>();
            while (count < 4)
            {
                int index = random.Next(0, Questions.Count);
                Question q = Questions[index];
                if (dict.ContainsKey(q.Kategorija)) continue;
                dict.Add(q.Kategorija, q);
                questions[count] = q;
                Questions.RemoveAt(index);
                count++;
            }
            return questions;
        }
    }
}