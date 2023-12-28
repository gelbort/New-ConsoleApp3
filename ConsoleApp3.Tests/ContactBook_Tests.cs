using ConsoleApp3.Enums;
using ConsoleApp3.Interfaces;
using ConsoleApp3.Services;
using Xunit;

namespace ConsoleApp3.Tests
{
    public class ContactBook_Tests
    {
        [Fact]
        public void AddContact_ShouldSucceedAndContactShouldBeInList()
        {
            // Arrange
            IContact contact = new Contact
            {
                FirstName = "Eric",
                LastName = "Gelbort",
                PhoneNumber = "",
                Email = "",
                Address = ""
            };

            IContactBook contactBook = new ContactBook();

            // Act
            var result = contactBook.AddContact(contact);

            // Assert
            // Kontrollera att tillägget av kontakt har lyckats
            Assert.Equal(ServiceStatus.SUCCEDED, result.Status);

            // Kontrollera att kontakten finns i listan efter tillägg
            Assert.Contains(contact, contactBook.GetAllContacts());
        }
    }
}
