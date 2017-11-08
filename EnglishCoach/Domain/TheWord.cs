using System;
using System.Collections.Generic;

namespace EnglishCoach
{
    public class TheWord
    {
      public string Russian { get; set; }
       public string English { get; set; }
        public int NumberOfCorrectAnswers { get; set; }

        public TheWord(string _russian, string _english)
        {
            Russian = _russian;
            English = _english;
            NumberOfCorrectAnswers = 0;
        }
    }
}
