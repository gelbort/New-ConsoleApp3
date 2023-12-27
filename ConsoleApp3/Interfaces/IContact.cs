using System;

// Publikt gränssnitt för Contact
public interface IContact
{
    // Definition av egenskaper och/eller metoder för Contact
    Guid Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string PhoneNumber { get; set; }
    string Email { get; set; }
    string Address { get; set; }
}
