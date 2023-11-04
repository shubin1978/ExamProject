namespace ProjectApp.DAL;

public abstract class FileContext
{
    protected readonly string PathToObjects;

    protected FileContext(string pathToObjects)
    {
        PathToObjects = pathToObjects;
    }
}