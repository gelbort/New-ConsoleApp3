using ConsoleApp3.Services;

class Program
{
    static void Main()
    {
        var contactBook = new ContactBook();
        var menuService = new MenuService(contactBook);

        while (true)
        {
            menuService.ShowMenu();
            var choice = Console.ReadLine();
            menuService.ProcessChoice(choice);
        }
    }
}
