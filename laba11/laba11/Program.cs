// Абстрактний клас, що представляє базовий об'єкт ланцюжка


// Клієнтський код
class Program
{
    static void Main(string[] args)
    {
        //Створюємо об'єкти обробників
        var localServerHandler = new LocalServerHandler();
        var remoteServerHandler = new RemoteServerHandler();
        localServerHandler.SetNextHandler(remoteServerHandler);
        localServerHandler.HandleRequest("Запит на інформацію");
    }
}
