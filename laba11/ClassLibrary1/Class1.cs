public abstract class InformationHandler
{
    protected InformationHandler NextHandler; // Наступний обробник в ланцюжку

    public void SetNextHandler(InformationHandler handler)
    {
        NextHandler = handler;
    }

    public abstract void HandleRequest(string request); // Метод обробки запиту

}

// Конкретний обробник, що відповідає за перевірку наявності інформації на локальному сервері
public class LocalServerHandler : InformationHandler
{
    public override void HandleRequest(string request)
    {
        if (IsInformationAvailableLocally(request))
        {
            Console.WriteLine($"Інформація '{request}' знайдена на локальному сервері.");
        }
        else
        {
            Console.WriteLine($"Інформацію '{request}' не знайдено на локальному сервері.");
            NextHandler?.HandleRequest(request); // Передаємо запит на наступний обробник в ланцюжку
        }
    }

    private bool IsInformationAvailableLocally(string request)
    {
        // Логіка перевірки наявності інформації на локальному сервері
        // Повертає true, якщо інформація знайдена, інакше - false
        return false;
    }
}

// Конкретний обробник, що відповідає за пошук інформації на віддаленому сервері
public class RemoteServerHandler : InformationHandler
{
    public override void HandleRequest(string request)
    {
        if (IsInformationAvailableRemotely(request))
        {
            Console.WriteLine($"Інформація '{request}' знайдена на віддаленому сервері.");
        }
        else
        {
            Console.WriteLine($"Інформацію '{request}' не знайдено на віддаленому сервері.");
            // Це останній обробник в ланцюжку, тому не викликаємо NextHandler
        }
    }

    private bool IsInformationAvailableRemotely(string request)
    {
        // Логіка пошуку інформації на віддаленому сервері
        // Повертає true, якщо інформація знайдена, інакше - false
        return true;
    }
}