using System.Collections.Generic;

namespace EnglishCoach
{
  internal class ListOfWords
    {
        public List<TheWord> WordsList { get; set; } = new List<TheWord>();
        public ListOfWords()
        {
            WordsList.Add(new TheWord("мама", "mom" ));
            WordsList.Add(new TheWord("папа", "dad"));
        }
    }
}
