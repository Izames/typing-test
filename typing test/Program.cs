using typing_test;
namespace typing_test
{
    internal class menu
    {
        public static void Main()
        {
            Console.WriteLine("Введите имя для таблицы рекордов:");
            string user_name = Console.ReadLine();
            Console.Clear();
            txt_write.test_start(user_name);
        }
    }
}
