namespace WorldWorkshopApi.Models;

public class WorldWorkshopDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string WorldsCollectionName { get; set; } = null!;

    public string CharactersCollectionName { get; set; } = null!;
}
