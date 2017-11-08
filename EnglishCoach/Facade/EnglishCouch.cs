using System.Collections.Generic;

namespace EnglishCoach
{
    static public class EnglishCouch
    {
        static public User AddNewUser(string name, string path)
        {
            User user = new User(name, path, Button.Register);
            return user;
        }

        static public User LogInUser(string name, string path)
        {
            User user = new User(name, path, Button.LogIn);
            return user;
        }

        static public TheWord GetAWordForTraining(User user)
        {
            return user.ShowTheWord();
        }

        static public bool CheckTrueTheAnswer(TheWord _word, User user)
        {
          return  user.CheckTheAnswer(_word, true);
        }

        static public bool CheckFalseTheAnswer(TheWord _word, User user)
        {
            return user.CheckTheAnswer(_word, false);
        }

        static public IEnumerable<TheWord> ShowAllWords(User user)
        {
            return user.ShowAllWords();
        }

        static public IEnumerable<TheWord> ShowShowLearnedWords(User user)
        {
            return user.ShowLearnedWords();
        }

    }
}
