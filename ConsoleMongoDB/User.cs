using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Login { get; set;}

    public string Password { get; set;}

    [BsonRepresentation(BsonType.DateTime)]
    public DateTime CreatedAt { get; set; }

    [BsonRepresentation(BsonType.DateTime)]
    public DateTime UpdatedAt { get; set; }

    public bool isActive { get; set; }

    public User(string login, string password)
    {
        this.Login = login;
        this.Password = password;
        this.CreatedAt = DateTime.Now;
        this.UpdatedAt = DateTime.Now;
        this.isActive = true;
    }

    public override string ToString()
    {
        return $"Id:{this.Id}\n" +
            $"Login:{this.Login}\n" +
            $"Senha:{this.Password}\n" +
            $"Criado em:{this.CreatedAt}\n" +
            $"Atualizado em: {this.UpdatedAt}\n" +
            $"Ativo:{(this.isActive ? "Sim" : "Não")}";
    }
}