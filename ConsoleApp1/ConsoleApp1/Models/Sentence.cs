public class Sentence
{
    public Guid Id { get; set; }

    public string Text
    {
        get;
        set;
    }
    public Sentence(string text, Guid id)
    {
        Text = text;
        Id = id;
    }
}