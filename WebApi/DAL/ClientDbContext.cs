using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class ClientDbContext
{
	public ClientDbContext() : base("ClientDbContext")
    {
		
	}
    public DbSet<Client> employee { get; set; }
    public DbSet<ClientAddress> department { get; set; }
}
