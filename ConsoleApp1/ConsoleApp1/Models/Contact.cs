public class Contact
{
    public string Name
    {
        get;
        set;
    }
    public string Number
    {
        get;
        set;
    }
    public Contact(string name, string number)
    {
        Name = name;
        Number = number;
    }
    public void Print()
    {
        Console.WriteLine("Contacts:" + Name + ", Phone: " + Number);
    }
}