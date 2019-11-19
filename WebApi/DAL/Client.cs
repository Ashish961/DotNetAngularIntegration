using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Client
{
    int Id { set; get; }
    string FirstName { get; set; }
    string LastName { get; set; }
    int Dob { get; set; }
    public ICollection<ClientAddress> employee { get; set; }
    public Client()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
