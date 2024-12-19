

namespace Homework_Tumakov_8
{
    internal class Song
    {
        #region Поля
        private string _name;
        private string _author;
        private Song _prev;
        #endregion

        #region Конструкторы

        public Song(string nameSong, string autorSong, Song prevousSong)
        {
            _name = nameSong;
            _author = autorSong;
            _prev = prevousSong;
        }

        public Song()
        {
            _name = string.Empty;
            _author = string.Empty;
            _prev = null;
        }

        public Song(string name, string author)
        {
            _name = name;
            _author = author;
            _prev = null;
        }
        #endregion

        #region Методы
        public void EnterName()
        {
            string input;
            int attempts = 3;
            bool isValidInput = false;

            for (int i = 0; i < attempts; i++)
            {
                Console.WriteLine("Введите название песни:");
                input = Console.ReadLine();


                if (!string.IsNullOrWhiteSpace(input))
                {
                    _name = input;
                    isValidInput = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Название не может быть пустым. Попробуйте снова.");
                }
            }


            if (!isValidInput)
            {
                Console.WriteLine("Вы исчерпали все попытки.");
            }
        }

        public void EnterAuthor()
        {
            string input;
            int attempts = 3;
            bool isValidInput = false;

            while (attempts > 0)
            {
                Console.WriteLine("Введите имя автора:");
                input = Console.ReadLine();


                if (!string.IsNullOrWhiteSpace(input) && !int.TryParse(input, out _))
                {
                    _author = input;
                    isValidInput = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Имя автора должно быть строкой. Попробуйте снова.");
                }

                attempts--;
            }

            if (!isValidInput)
            {
                Console.WriteLine("Вы исчерпали все попытки.");
            }
        }

        public void EnterPrev(Song previousSong)
        {
            _prev = previousSong;
        }

        public string Title()
        {
            return $"{_name} - {_author}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Song song)
            {
                return _name == song._name && _author == song._author;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_name, _author);
        }
        #endregion
    }
}
