using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnglishCoach;
using System.Collections.Generic;

namespace EnglishCouchTests
{
    
    [TestClass]
    public class Test
    {
        string FilePath = @"";
        [TestMethod]
        public void CreatNewUser()
        {
            var user = EnglishCouch.AddNewUser("Tom", FilePath);
            Assert.AreEqual(user.Name, "Tom");
            Assert.AreEqual(user.PathToTheFile, FilePath + "Tom.json");
        }
        [TestMethod]
        public void LogInUser()
        {
            var user = EnglishCouch.AddNewUser("Ban",FilePath);
            user = EnglishCouch.LogInUser("Ban", FilePath);

            Assert.AreEqual(user.Name, "Ban");
            Assert.AreEqual(user.PathToTheFile, FilePath+"Ban.json");
        }

        [TestMethod]
        public void CheckTrueTheAnswer_and_CheckFalseTheAnswer_ShouldNotBeEqual()
        {
            var user = EnglishCouch.AddNewUser("Ken", FilePath);
            user = EnglishCouch.LogInUser("Ken", FilePath);
            var word = EnglishCouch.GetAWordForTraining(user);
            var valueF = EnglishCouch.CheckFalseTheAnswer(word, user);
            var valueT = EnglishCouch.CheckTrueTheAnswer(word, user);
            Assert.AreNotEqual(valueF, valueT);
        }

        [TestMethod]
        public void EctualArray_and_ExpectedArray_ShouldBeEqual()
        {
            User user = EnglishCouch.AddNewUser("Lee", FilePath);
            List<TheWord> EctualArray = new List<TheWord>();
            EctualArray.Add(new TheWord("мама", "mom"));
            EctualArray.Add(new TheWord("папа", "dad"));
            IEnumerable<TheWord> Dictionary = EnglishCouch.ShowAllWords(user);
            var ExpectedArray = new List<TheWord>(Dictionary);
            Assert.AreEqual(EctualArray[0].English, ExpectedArray[0].English);
            Assert.AreEqual(EctualArray[0].Russian, ExpectedArray[0].Russian);
            Assert.AreEqual(EctualArray[0].NumberOfCorrectAnswers, ExpectedArray[0].NumberOfCorrectAnswers);
            Assert.AreEqual(EctualArray[1].English, ExpectedArray[1].English);
            Assert.AreEqual(EctualArray[1].Russian, ExpectedArray[1].Russian);
            Assert.AreEqual(EctualArray[1].NumberOfCorrectAnswers, ExpectedArray[1].NumberOfCorrectAnswers);
        }
        [TestMethod]
        public void WordCanNotBeGivenMoreThenThreeTimes()
        {
            User user = EnglishCouch.AddNewUser("Mark", FilePath);
            var word = new TheWord("мама", "mom");

            var valueT1 = EnglishCouch.CheckTrueTheAnswer(word, user);

            var valueT2 = EnglishCouch.CheckTrueTheAnswer(word, user);

            var valueT3 = EnglishCouch.CheckTrueTheAnswer(word, user);

            var valueT4 = EnglishCouch.CheckTrueTheAnswer(word, user);

            Assert.IsFalse(valueT4);

        }

        [TestMethod]
        public void ShowAllLearnedWords()
        {
            User user = EnglishCouch.AddNewUser("Stefun", FilePath);
            var word = new TheWord("мама", "mom");

            var valueT1 = EnglishCouch.CheckTrueTheAnswer(word, user);

            var valueT2 = EnglishCouch.CheckTrueTheAnswer(word, user);

            var valueT3 = EnglishCouch.CheckTrueTheAnswer(word, user);

            var List = new List<TheWord>(EnglishCouch.ShowShowLearnedWords(user));
            TheWord Word = new TheWord("мама", "mom");
            word.NumberOfCorrectAnswers = 3;
            Assert.AreEqual(List[0].English, word.English);
            Assert.AreEqual(List[0].Russian, word.Russian);
            Assert.AreEqual(List[0].NumberOfCorrectAnswers, word.NumberOfCorrectAnswers);
        }

        [TestMethod]
        public void Mathod_GetAWordForTraining_ShouldNotGivLearnedWord()
        {
            User user = EnglishCouch.AddNewUser("Stefun", FilePath);

            var word = new TheWord("мама", "mom");
            var valueT = EnglishCouch.CheckTrueTheAnswer(word, user);
            valueT = EnglishCouch.CheckTrueTheAnswer(word, user);
            valueT = EnglishCouch.CheckTrueTheAnswer(word, user);

            word = new TheWord("папа", "dad");
            valueT = EnglishCouch.CheckTrueTheAnswer(word, user);
            valueT = EnglishCouch.CheckTrueTheAnswer(word, user);
            valueT = EnglishCouch.CheckTrueTheAnswer(word, user);

            word = EnglishCouch.GetAWordForTraining(user);
            Assert.IsNull(word);
        }

    }
}
