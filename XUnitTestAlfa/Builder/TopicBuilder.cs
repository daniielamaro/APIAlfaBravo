using System;
using Domain;

public class TopicBuilder
{
    public Guid Id;
    public string Name;

    public static TopicBuilder New()
    {
<<<<<<< HEAD
        return new TopicBuilder()
        {
            Id = Guid.NewGuid(),
            Name = "TestTopic",
=======
        var random = new Random();

        return new TopicBuilder()
        {
            Id = Guid.NewGuid(),
            Name = "TestTopic" + random.Next(1, 9999).ToString(),
>>>>>>> master
        };
    }

    public TopicBuilder WithId(Guid id)
    {
        Id = id;
        return this;
    }

    public TopicBuilder WithName(string name)
    {
        Name = name;
        return this;
    }

    public Topic Build()
    {
        return new Topic(Id, Name);
    }
}

