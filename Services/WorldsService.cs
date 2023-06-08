using WorldWorkshopApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace WorldWorkshopApi.Services;

public class WorldsService
{

    private readonly IHttpContextAccessor _httpContextAccessor;

    private readonly IMongoCollection<World> _worldsCollection;

    public WorldsService(IHttpContextAccessor httpContextAccessor,
         IOptions<WorldWorkshopDatabaseSettings> worldWorkshopDatabaseSettings)
    {

        var mongoClient = new MongoClient(worldWorkshopDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
        worldWorkshopDatabaseSettings.Value.DatabaseName);

        _worldsCollection = mongoDatabase.GetCollection<World>(
            worldWorkshopDatabaseSettings.Value.WorldsCollectionName);

        _httpContextAccessor = httpContextAccessor;

    }

    // get all worlds
    public async Task<List<World>> GetAsync() 
    {
       Console.WriteLine(_httpContextAccessor?.HttpContext?.User);
       var worlds = await _worldsCollection.Find(_ => true).ToListAsync();

       return worlds;

    }

    

    // get a specific world

    public async Task<World?> GetAsync(string id) =>
    await _worldsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    // create a new world

    public async Task CreateAsync(World newWorld) =>
    await _worldsCollection.InsertOneAsync(newWorld);

    // update a world
    public async Task UpdateAsync(string id, World updatedWorld) =>
    await _worldsCollection.ReplaceOneAsync(x => x.Id == id, updatedWorld);


    // delete a world

    public async Task RemoveAsync(string id) =>
    await _worldsCollection.DeleteOneAsync(x => x.Id == id);





}