//// create personal contact list
//// simulate contacts on a phone.
//// Features
//// add a contact
//// and search 
////print on console after finding the contact.


//using System.ComponentModel.DataAnnotations;

//List<Contact> contacts = new List<Contact>(); // make a list of contacts
//contacts.Add(new Contact("Kamil", "123555"));
//contacts.Add(new Contact("Forka", "444455"));
//contacts.Add(new Contact("Test", "4411155"));

//bool isRunning = true;

//while (isRunning) //it will run forever
//{

//    Queue<string> commandQueue = GetCommandQueue();

//    string command = GetNextCommand(commandQueue);

//    switch (command)
//    {
//        case "add":
//            OnAdd(commandQueue);
//            break;

//        case "print":
//            PrintList();
//            break;

//        case "search":
//            OnSearch(commandQueue);
//            break;

//        case "delete":
//            OnDelete(commandQueue);
//            break;

//        case "edit":
//            OnEdit(commandQueue);
//            break;

//        case "exit":
//            isRunning = false;
//            break;

//        default:
//            Console.WriteLine($"'{command}' is not recognised command");
//            break;

//    }

//    //if (command == "add")
//    //{
//    //    OnAdd();
//    //}
//    //else if (command == "print")
//    //{
//    //    PrintList();
//    //    //if you type print insted of add it should print every
//    //    //contact saved in the list
//    //}
//    //else if (command == "search")
//    //{
//    //    OnSearch();
//    //}
//    //else if (command == "delete")
//    //{
//    //    OnDelete();
//    //}

//    //else if (command == "edit")
//    //{
//    //    OnEdit();
//    //}

//}

////homework111
////1 - make everything with the command - type 1 line only
////2 when you adding a contact ensure that the number is an actual number 0-9
////3 - new function? other than search edit delete.



//void OnEdit(Queue<string> command)
//{
//    string editTerm = GetNextCommand(command);
//    bool notfound = false;

//    for (int i = contacts.Count - 1; i >= 0; i--) //reversed for
//    {
//        if (string.Equals(editTerm, contacts[i].Name, StringComparison.InvariantCultureIgnoreCase))
//        //if (contacts[i].Name.Contains(editTerm))
//        {
//            Console.WriteLine("enter new name:");
//            string newName = GetNextLine();

//            contacts[i].Name = newName; // great discovery im proud

//            Console.WriteLine("enter new phone number:");
//            string newNumber = GetNextLine();

//            contacts[i].Number = newNumber;

//            Console.WriteLine("contact updated");
//            notfound = true;

//            break;
//        }
//    }
//    if (!notfound)
//    {
//        Console.WriteLine("No contact found");
//    }
//}

//void OnDelete(Queue<string> command)
//{
//    string deleteTerm = GetNextCommand(command);
//    bool notFound = false; // new add for hmework

//    for (int i = (contacts.Count) - (1); i >= 0; i--) //reversed for
//    {
//        if (string.Equals(deleteTerm, contacts[i].Name, StringComparison.InvariantCultureIgnoreCase))
//        //if (contacts[i].Name.Contains(deleteTerm)) -- old version
//        {
//            notFound = true; // new addition
//            Console.WriteLine(contacts[i].Name + " contact deleted");
//            contacts.RemoveAt(i);
//            break;
//        }
//    }
//    if (!notFound) //tell the mistake so we have a laugh
//                   //(if was in the for loop so it was printing 5 times ffs
//    {
//        Console.WriteLine("no contact found/deleted");   //this is new add for homework
//    }
//}
//void OnSearch(Queue<string> command)
//{
//    string searchTerm = GetNextCommand(command); // define searchTerm - get the text written on the console
//    bool isFound = false;

//    foreach (Contact contact in contacts) // loops through contacts 
//    {
//        if (contact.Name.Contains(searchTerm)) // check if contact name contains the text entered
//        {
//            isFound = true;
//            contact.Print();
//        }
//    }
//    if (!isFound)
//    {
//        Console.WriteLine("no contact found");
//    }
//}

//void OnAdd(Queue<string> command)
//{
//    bool isFound = false;
//    string name = GetNextCommand(command);
//    string number = GetNextCommand(command);

//    //foreach (Contact contact in contacts) // it dies when testing :(
//    for (int i = (contacts.Count) - (1); i >= 0; i--)
//    {
//        if (string.Equals(name, contacts[i].Name, StringComparison.InvariantCultureIgnoreCase))
//        {
//            isFound = true;
//            Console.WriteLine("contact exists");
//            break;
//        }
//    }
//    if (isFound == false)
//    {
//        contacts.Add(new Contact(name, number));
//        Console.WriteLine("added something");
//    }
//}

//string GetNextLine()
//{
//    string nextLine = Console.ReadLine();
//    return nextLine.Trim();
//}

//string GetNextCommand(Queue<string> command)
//{
//    return command.Dequeue();
//}

//Queue<string> GetCommandQueue()
//{
//    string nextLine = GetNextLine();
//    var words = nextLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
//    Queue<string> command = new Queue<string>(words);
//    return command;

//}

//void PrintList()
//{
//    foreach (Contact contact in contacts)  // loop through the contacts!
//    {
//        // Console.WriteLine("Contacts:" + contact.Name + ", Phone: " + contact.Number); //the same
//        contact.Print(); // as this
//    }
//}

//class Contact
//{
//    public string Name
//    {
//        get;
//        set;
//    }
//    public string Number
//    {
//        get;
//        set;
//    }
//    public Contact(string name, string number)
//    {
//        Name = name;
//        Number = number;
//    }
//    public void Print()
//    {
//        Console.WriteLine("Contacts:" + Name + ", Phone: " + Number);
//    }
//}
