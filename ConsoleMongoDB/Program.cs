using MongoDB.Driver;

var client = new MongoClient("mongodb+srv://krysthiang_db_user:2SrPPyQ9hDbfbBFJ@interacaomongo.c0dlrc6.mongodb.net/");

var database = client.GetDatabase("InterAcaoMongoDB");

var collection = database.GetCollection<User>("Usuarios");
/*
var usuario = new User("Krysthian", "123@mudar");
collection.InsertOne(usuario);

var usuariosNovos = new List<User>();

usuariosNovos.Add(new User("Marcio", "123senhamarcio"));
usuariosNovos.Add(new User("Gabriel", "123senhagabriel"));
usuariosNovos.Add(new User("Wayne", "123senhawayne"));

collection.InsertMany(usuariosNovos);



var usuarios = collection.Find(_ => true).ToList();

foreach(User u in usuarios)
{
    Console.WriteLine(u);
    Console.WriteLine("- - -");
}

var usuario = collection.Find(_ => _.Id == "691739971a2ead4a14bb4fe3").FirstOrDefault();
var usuario2 = collection.Find(_ => _.Id == "691739971a2ead4a14bb4fe2").ToList();

Console.WriteLine(usuario);
Console.WriteLine(usuario2.Count);

usuario.Password = "546@mudar";

collection.ReplaceOne(_ => _.Id == usuario.Id, usuario);

Console.WriteLine(usuario);

Console.WriteLine(collection.Find(_ => _.Id == "691739971a2ead4a14bb4fe3").FirstOrDefault());

*/



void ImprimirUsuarios(List<User> lista)
{
    foreach (User u in lista)
    {
        Console.WriteLine(u);
        Console.WriteLine("- - -");
    }
}

collection.UpdateOne(
    _ => _.Id == "691739971a2ead4a14bb4fe3",

    Builders<User>.Update
        .Set(_ => _.Password, "senhaAlterada")
        .Set(_ => _.UpdatedAt, DateTime.Now)
   );

var usuarios = collection.Find(_ => true).ToList();

ImprimirUsuarios(usuarios);

Console.ReadKey();
Console.Clear();

collection.UpdateMany(
    _ => _.isActive == true,

    Builders<User>.Update
        .Set(_ => _.isActive, false)
        .Set(_ => _.UpdatedAt, DateTime.Now)
   );

usuarios = collection.Find(_ => true).ToList();

ImprimirUsuarios(usuarios);
