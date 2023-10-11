using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_Library
{
    public partial class MainWindow : Window
    {
        private List<User> users = new List<User>();
        private List<Book> books = new List<Book>();

        public MainWindow()
        {
            InitializeComponent();
            InitializeData();
        }

        private void ShowUsers()
        {
            UsersListView.ItemsSource = users;
        }
        private void ShowBooks()
        {
            BooksListView.ItemsSource = books;
        }

        private void ShowUserBooks(User user)
        {
            UserBooksListView.Items.Clear();

            foreach (var book in user.Books)
            {
                UserBooksListView.Items.Add($"{book.Title} by {book.Author} ({book.Genre})");
            }
        }

        private void SearchUserButton_Click(object sender, RoutedEventArgs e)
        {
            string searchName = UserNameTextBox.Text;
            string searchFamily = UserFamilyTextBox.Text;

            User foundUser = users.Find(user => user.Name == searchName && user.Family == searchFamily);

            if (foundUser != null)
            {
                MessageBox.Show($"Найден пользователь: {foundUser.Name} {foundUser.Family}");
            }
            else
            {
                MessageBox.Show("Пользователь не найден.");
            }
        }

        private void SearchBookButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTitle = BookTitleTextBox.Text;
            string searchAuthor = BookAuthorTextBox.Text;
            string searchGenre = GenreForLend.Text;

            Book foundBook = books.Find(book =>
                book.Title == searchTitle &&
                book.Author == searchAuthor &&
                book.Genre == searchGenre);

            if (foundBook != null)
            {
                MessageBox.Show($"Найдена книга: {foundBook.Title} by {foundBook.Author} ({foundBook.Genre})");
            }
            else
            {
                MessageBox.Show("Книга не найдена.");
            }
        }
        private void LendBookButton_Click(object sender, RoutedEventArgs e)
        {
            string userName = UserNameForLend.Text;
            string bookTitle = BookTitleForLend.Text;
            string genre = GenreForLend.Text;

            User selectedUser = users.Find(user => user.Name.ToLower() == userName.ToLower());

            if (selectedUser == null)
            {
                MessageBox.Show($"Пользователь с именем '{userName}' не найден.");
                return;
            }

            Book selectedBook = books.Find(book => book.Title.ToLower() == bookTitle.ToLower() && book.Genre.ToLower() == genre.ToLower());

            if (selectedBook == null)
            {
                MessageBox.Show($"Книга с названием '{bookTitle}' и жанром '{genre}' не найдена.");
                return;
            }

            if (selectedBook.Count > 0)
            {
                selectedUser.Books.Add(selectedBook);
                selectedBook.Count--;
                ShowUserBooks(selectedUser);
                ShowBooks();
                MessageBox.Show($"Книга '{selectedBook.Title}' ({selectedBook.Genre}) успешно выдана пользователю '{selectedUser.Name}'.");
            }
            else
            {
                MessageBox.Show($"Книги '{selectedBook.Title}' ({selectedBook.Genre}) нет в наличии.");
            }
        }
        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsersListView.SelectedItem != null)
            {
                User selectedUser = (User)UsersListView.SelectedItem;
                users.Remove(selectedUser);
            }
        }
        private void UserBooksListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User selectedUser = GetSelectedUserForLend();

            if (selectedUser != null)
            {
                ShowUserBooks(selectedUser);
            }
        }
        private User GetSelectedUserForLend()
        {
            if (UserBooksListView.SelectedItem != null)
            {
                string selectedUserName = UserBooksListView.SelectedItem.ToString();
                return users.Find(user => $"{user.Name} {user.Family}" == selectedUserName);
            }
            return null;
        }
        private Book GetSelectedBook()
        {
            if (BooksListView.SelectedItem != null)
            {
                Book selectedBook = (Book)BooksListView.SelectedItem;

                return selectedBook;
            }
            return null;
        }

        private void InitializeData()
        {
            // Пользователи
            users.Add(new User(1, "Амелия", "Смирнова"));
            users.Add(new User(2, "Максим", "Петров"));
            users.Add(new User(3, "Мирослава", "Смирнова"));
            users.Add(new User(4, "Али", "Антонов"));
            users.Add(new User(5, "Никита", "Шестаков"));
            users.Add(new User(6, "Айша", "Мельникова"));
            users.Add(new User(7, "Яна", "Малышева"));
            users.Add(new User(8, "Оливия", "Горбунова"));
            users.Add(new User(9, "Алиса", "Чумакова"));
            users.Add(new User(10, "Ульяна", "Борисова"));
            users.Add(new User(11, "Таисия", "Князева"));
            users.Add(new User(12, "Евгений", "Ильин"));
            users.Add(new User(13, "Мирослава", "Голубева"));
            users.Add(new User(14, "Альберт", "Трофимов"));
            users.Add(new User(15, "Мария", "Карасева"));
            users.Add(new User(16, "Даниил", "Алексеев"));
            users.Add(new User(17, "Кирилл", "Титов"));
            users.Add(new User(18, "Варвара", "Смирнова"));
            users.Add(new User(19, "Мария", "Костина"));
            users.Add(new User(20, "Егор", "Пименов"));
            users.Add(new User(21, "Максим", "Соколов"));
            users.Add(new User(22, "Егор", "Чумаков"));
            users.Add(new User(23, "Артём", "Маслов"));
            users.Add(new User(24, "Николай", "Гаврилов"));
            users.Add(new User(25, "Анастасия", "Климова"));
            users.Add(new User(26, "Никита", "Гаврилов"));
            users.Add(new User(27, "Андрей", "Филатов"));
            users.Add(new User(28, "Степан", "Князев"));
            users.Add(new User(29, "Мария", "Федотова"));
            users.Add(new User(30, "Даниил", "Борисов"));
            users.Add(new User(31, "Айлин", "Баженова"));
            users.Add(new User(32, "Глеб", "Дементьев"));
            users.Add(new User(33, "Амина", "Островская"));
            users.Add(new User(34, "Мария", "Морозова"));
            users.Add(new User(35, "Георгий", "Федоров"));
            users.Add(new User(36, "София", "Дементьева"));
            users.Add(new User(37, "Савелий", "Мартынов"));
            users.Add(new User(38, "Арсений", "Макаров"));
            users.Add(new User(39, "Арина", "Лебедева"));
            users.Add(new User(40, "Филипп", "Вишневский"));
            users.Add(new User(41, "Александра", "Сорокина"));
            users.Add(new User(42, "Степан", "Трофимов"));
            users.Add(new User(43, "Полина", "Аникина"));
            users.Add(new User(44, "Артём", "Овчинников"));
            users.Add(new User(45, "Варвара", "Баранова"));
            users.Add(new User(46, "Варвара", "Бессонова"));
            users.Add(new User(47, "Анна", "Никитина"));
            users.Add(new User(48, "Артём", "Степанов"));
            users.Add(new User(49, "Фёдор", "Смирнов"));
            users.Add(new User(50, "Иван", "Родионов"));
            // Книги
            books.Add(new Book("Лев Толстой", "Роман", "Война и мир", new DateTime(1869, 1, 1), 10));
            books.Add(new Book("Фёдор Достоевский", "Роман", "Преступление и наказание", new DateTime(1866, 1, 1), 10));
            books.Add(new Book("Джордж Оруэлл", "Научная фантастика", "1984", new DateTime(1949, 1, 1), 10));
            books.Add(new Book("Джейн Остин", "Роман", "Гордость и предубеждение", new DateTime(1813, 1, 1), 10));
            books.Add(new Book("Марк Твен", "Приключения", "Приключения Тома Сойера", new DateTime(1876, 1, 1), 10));
            books.Add(new Book("Фрэнсис Скотт Фицджеральд", "Роман", "Великий Гэтсби", new DateTime(1925, 1, 1), 10));
            books.Add(new Book("Джоан Роулинг", "Фэнтези", "Гарри Поттер и философский камень", new DateTime(1997, 1, 1), 10));
            books.Add(new Book("Джордж Р.Р. Мартин", "Фэнтези", "Игра престолов", new DateTime(1996, 1, 1), 10));
            books.Add(new Book("Агата Кристи", "Детектив", "Убийство в Восточном экспрессе", new DateTime(1934, 1, 1), 10));
            books.Add(new Book("Дан Браун", "Триллер", "Да Винчи код", new DateTime(2003, 1, 1), 10));
            books.Add(new Book("Жюль Верн", "Приключения", "Двадцать тысяч лье под водой", new DateTime(1870, 1, 1), 10));
            books.Add(new Book("Эрих Мария Ремарк", "Военная проза", "На Западном фронте без перемен", new DateTime(1929, 1, 1), 10));
            books.Add(new Book("Жан-Поль Сартр", "Философская проза", "Тошнота", new DateTime(1938, 1, 1), 10));
            books.Add(new Book("Рэй Брэдбери", "Фантастика", "451 градус по Фаренгейту", new DateTime(1953, 1, 1), 10));
            books.Add(new Book("Уильям Шекспир", "Трагедия", "Гамлет", new DateTime(1603, 1, 1), 10));
            books.Add(new Book("Анна Сьюэлл", "Детская литература", "Черный красавец", new DateTime(1877, 1, 1), 10));
            books.Add(new Book("Фрэнсис Ходжсон Бёрнетт", "Детская литература", "Тайный сад", new DateTime(1911, 1, 1), 10));
            books.Add(new Book("Оскар Уайльд", "Роман", "Портрет Дориана Грея", new DateTime(1890, 1, 1), 10));
            books.Add(new Book("Джордж Оруэлл", "Антиутопия", "Скотный двор", new DateTime(1945, 1, 1), 10));
            books.Add(new Book("Льюис Кэрролл", "Детская литература", "Алиса в Стране чудес", new DateTime(1865, 1, 1), 10));
            books.Add(new Book("Герман Мелвилл", "Роман", "Моби Дик", new DateTime(1851, 1, 1), 10));
            books.Add(new Book("Джейн Эйр", "Роман", "Джейн Эйр", new DateTime(1847, 1, 1), 10));
            books.Add(new Book("Джон Стейнбек", "Роман", "Гроздья гнева", new DateTime(1939, 1, 1), 10));
            books.Add(new Book("Артур Конан Дойль", "Детектив", "Приключения Шерлока Холмса", new DateTime(1892, 1, 1), 10));
            books.Add(new Book("Жюль Верн", "Приключения", "Вокруг света в восемьдесят дней", new DateTime(1873, 1, 1), 10));
            books.Add(new Book("Джон Толкин", "Фэнтези", "Властелин колец: Братство кольца", new DateTime(1954, 1, 1), 10));
            books.Add(new Book("Аркадий и Борис Стругацкие", "Научная фантастика", "Пикник на обочине", new DateTime(1972, 1, 1), 10));
            books.Add(new Book("Джон Грин", "Роман", "Виноваты звезды", new DateTime(2012, 1, 1), 10));
            books.Add(new Book("Маргарет Атвуд", "Антиутопия", "Рассказ служанки", new DateTime(1985, 1, 1), 10));
            books.Add(new Book("Габриэль Гарсиа Маркес", "Магический реализм", "Сто лет одиночества", new DateTime(1967, 1, 1), 10));
            books.Add(new Book("Роберт Льюис Стивенсон", "Приключения", "Остров сокровищ", new DateTime(1883, 1, 1), 10));
            books.Add(new Book("Артур Конан Дойль", "Детектив", "Собака Баскервилей", new DateTime(1902, 1, 1), 10));
            books.Add(new Book("Эмили Бронте", "Роман", "Грозовой перевал", new DateTime(1847, 1, 1), 10));
            books.Add(new Book("Юлия Верн", "Фантастика", "Заводной апельсин", new DateTime(1962, 1, 1), 10));
            books.Add(new Book("Марк Твен", "Приключения", "Приключения Гекльберри Финна", new DateTime(1884, 1, 1), 10));
            books.Add(new Book("Гастон Леру", "Приключения", "Призрак оперы", new DateTime(1910, 1, 1), 10));
            books.Add(new Book("Джордж Оруэлл", "Антиутопия", "Скотный двор", new DateTime(1945, 1, 1), 10));
            books.Add(new Book("Агата Кристи", "Детектив", "Десять негритят", new DateTime(1939, 1, 1), 10));
            books.Add(new Book("Джейн Остин", "Роман", "Эмма", new DateTime(1815, 1, 1), 10));
            books.Add(new Book("Джон Голсуорси", "Роман", "История семьи Форсайтов", new DateTime(1922, 1, 1), 10));
            books.Add(new Book("Марк Твен", "Приключения", "Приключения Гекльберри Финна", new DateTime(1884, 1, 1), 10));
            books.Add(new Book("Франц Кафка", "Метафизический роман", "Процесс", new DateTime(1925, 1, 1), 10));
            books.Add(new Book("Артур Конан Дойль", "Детектив", "Знак четырех", new DateTime(1890, 1, 1), 10));
            books.Add(new Book("Габриэль Гарсиа Маркес", "Магический реализм", "Осенний палас", new DateTime(1975, 1, 1), 10));
            books.Add(new Book("Эдгар Аллан По", "Ужасы", "Маска Красной Смерти", new DateTime(1842, 1, 1), 10));
            books.Add(new Book("Оскар Уайльд", "Роман", "Завтрак у Тиффани", new DateTime(1958, 1, 1), 10));
            books.Add(new Book("Джордж Р.Р. Мартин", "Фэнтези", "Битва королей", new DateTime(1998, 1, 1), 10));
            books.Add(new Book("Рэй Брэдбери", "Фантастика", "Марсианские хроники", new DateTime(1950, 1, 1), 10));
            books.Add(new Book("Герман Мелвилл", "Роман", "Бартлби, или Запись в офисе", new DateTime(1853, 1, 1), 10));
            books.Add(new Book("Джон Стейнбек", "Роман", "На восток от Эдема", new DateTime(1952, 1, 1), 10));

            UsersListView.ItemsSource = users;
            BooksListView.ItemsSource = books;

            ShowUsers();
            ShowBooks();
        }
    }
}
