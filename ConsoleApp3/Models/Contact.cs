﻿using ConsoleApp3.Services;

public class Contact : IContact
{
    
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; } = null!;
    public string Address { get; set; }
}
