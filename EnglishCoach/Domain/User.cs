using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace EnglishCoach
{
    public class User
    {
        public string Name { get; }
        public string PathToTheFile { get; }
        List<TheWord> Dictionary = new List<TheWord>();

        public User(string _name, string _pathToTheFile, Button button)
        {
            Name = _name;
            PathToTheFile = _pathToTheFile + _name + ".json";
            switch (button)
            {
                case Button.Register:
                    ListOfWords Words = new ListOfWords();
                    foreach (TheWord word in Words.WordsList)
                    {
                        Dictionary.Add(word);
                    }
                    using (File.Create(PathToTheFile))
                    { }
                    File.WriteAllText(PathToTheFile, JsonConvert.SerializeObject(Dictionary));
                    break;
                case Button.LogIn:
                    try
                    {
                        var FileString = File.ReadAllText(PathToTheFile);
                        Dictionary = JsonConvert.DeserializeObject<List<TheWord>>(FileString);

                    }
                    catch
                    {
                        throw new Exception("Поользователя с таким именем нет");
                    }
                    break;
            }
        }

        public TheWord ShowTheWord()
        {
            try
            {
                var CurrentWords = Dictionary.Where(p => p.NumberOfCorrectAnswers != 3).Take(5).ToArray();

                var EnglishWord = CurrentWords[new Random().Next(0, CurrentWords.Length)];

                var RussianWord = CurrentWords[new Random().Next(0, CurrentWords.Length)];

                var Word = new TheWord(RussianWord.Russian, EnglishWord.English);
                return Word;
            }
            catch
            {
                return null;
            }
        }

        public bool CheckTheAnswer(TheWord _word, bool suppose)
        {
            var CurrentWords = Dictionary.Where(p => p.NumberOfCorrectAnswers != 3).Take(5).ToList();

            var contains = CurrentWords?.Find(p => p.English == _word.English && p.Russian == _word.Russian);
            if((contains == null && suppose == false) || (contains != null && suppose == true) )
            {
                if (suppose == true)
                {
                    Dictionary.Find(p => p.English == _word.English).NumberOfCorrectAnswers += 1;
                    File.WriteAllText(PathToTheFile, JsonConvert.SerializeObject(Dictionary));
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<TheWord> ShowAllWords()
        {
            IEnumerable<TheWord> Words = Dictionary;
            return Words;
        }
        public IEnumerable<TheWord> ShowLearnedWords()
        {

            IEnumerable<TheWord> Words = Dictionary.Where(p=> p.NumberOfCorrectAnswers==3);
            return Words;
        }

    }
}
