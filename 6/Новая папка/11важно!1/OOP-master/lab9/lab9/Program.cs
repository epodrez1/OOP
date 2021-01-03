using System;

namespace lab9
{
    

    public class User : EventArgs
    {
        public delegate void Handler(string str);
        public event Handler Upgrade;

        public event Handler Work;

        public string name;
        public int age;
        public int level;
        public bool works;

        public User()
        {

        }

        public User(string name, int age, int level) : this()
        {
            this.name = name;
            this.age = age;
            this.level = level;
        }

        public void UserUpgrade(int num)
        {
            level += num;
            if (Upgrade != null)
            {
                Upgrade($"Текущий уровень пользователя {name}: {level}");
            }
            else
            {
                Console.WriteLine("Событие не привязано");
            }
        }

        public void UserWork(bool bl)
        {
            if (Work != null)
            {
                if (bl)
                {
                    Work($"Пользователь {name} сейчас работает");
                }
                else
                {
                    Work($"Пользователь {name} сейчас не работает");

                }
            }
            else
            {
                Console.WriteLine("Событие не привязано");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User("Екатерина", 27, 3);
            User user2 = new User("Геннадий", 28, 5);
            User user3 = new User("Пётр", 18, 1);
            User user4 = new User("Иван", 23, 2);

            user1.Upgrade += ShowMessage;
            user2.Upgrade += ShowMessage;
            user3.Upgrade += ShowMessage;
            user4.Upgrade += ShowMessage;

            user1.Work += ShowMessage;
            user2.Work += ShowMessage;
            user3.Work += ShowMessage;
            user4.Work += ShowMessage;

            user1.UserUpgrade(1);
            user2.UserUpgrade(-2);
            user3.UserUpgrade(0);
            user4.UserUpgrade(1);

            user1.UserWork(true);
            user2.UserWork(false);

            Action<string> action;
            string str = "КакОЙ-То теКст";
            action = ToUpperCase;
            action += ToLowerCase;
            action += AddSymbols;
            action += AddSpaceBefore;
            action += DeleteHalf;
            action(str);
        }
        static public void ShowMessage(string message) => Console.WriteLine(message);

        static public void ToUpperCase(string str) => Console.WriteLine(str.ToUpper());
        static public void ToLowerCase(string str) => Console.WriteLine(str.ToLower());
        static public void AddSymbols(string str1) => Console.WriteLine(str1 + "rrr");
        static public void AddSpaceBefore(string str) => Console.WriteLine(" " + str);
        static public void DeleteHalf(string str) => Console.WriteLine(str.Remove(str.Length / 2));
    }
}
