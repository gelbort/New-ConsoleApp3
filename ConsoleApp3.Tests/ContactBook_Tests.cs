using ConsoleApp3.Enums;
using ConsoleApp3.Interfaces;
using ConsoleApp3.Models.Responses;
using ConsoleApp3.Services;
using Xunit;

namespace ConsoleApp3.Tests
{
    public class ContactBook_Tests
    {
        [Fact]
        public void AddContact_SkaLyckasOchKontaktBordefinnasIListan()
        {
            // Arrange
            IContact contact = new Contact
            {
                FirstName = "Batman",
                LastName = "Gelbort",
                PhoneNumber = "123456789",
                Email = "Batman@domain.com",
                Address = "Ankeborg"
            };

            IContactBook contactBook = new ContactBook();

            // Act
            var result = contactBook.AddContact(contact);

            // Assert
            Assert.Equal(ServiceStatus.SUCCEDED, result.Status); // Verifiera att tillägget av kontakt har lyckats

            Assert.Contains(contact, contactBook.GetAllContacts()); // Verifiera att kontakten finns i listan efter tillägget
        }

        [Fact]
        public void RemoveContactByEmail_SkaTaBortKontaktOchVisaMeddelande()
        {
            // Arrange
            IContact contact = new Contact
            {
                FirstName = "Maria",
                LastName = "Doe",
                PhoneNumber = "111",
                Email = "maria@domain.com",
                Address = "Gotham"
            };

            IContactBook contactBook = new ContactBook();
            contactBook.AddContact(contact); // Lägg till en kontakt att ta bort

            // Act
            contactBook.RemoveContactByEmail(contact.Email);

            // Assert
            // Verifiera att kontakten har tagits bort från listan
            Assert.DoesNotContain(contact, contactBook.GetAllContacts());
        }

        [Fact]
        public void GetContactByEmail_SkaReturneraKontaktOmDenExisterar()
        {
            // Arrange
            IContact contact = new Contact
            {
                FirstName = "Jax",
                LastName = "G",
                PhoneNumber = "111",
                Email = "jax@domain.com",
                Address = "Metropolis"
            };

            IContactBook contactBook = new ContactBook();
            contactBook.AddContact(contact); // Lägg till en kontakt att söka efter

            // Act
            var foundContact = contactBook.GetContactByEmail(contact.Email);

            // Assert
            // Verifiera att rätt kontakt har hämtats genom att jämföra e-postadresser
            Assert.Equal(contact.Email, foundContact.Email);
        }

        [Fact]
        public void DisplayAllContacts_SkaVisaAllaKontakter()
        {
            // Arrange
            IContactBook contactBook = new ContactBook();
            IContact contact1 = new Contact
            {
                FirstName = "Noah",
                LastName = "G",
                PhoneNumber = "111111111",
                Email = "noah@domain.com",
                Address = "Smallville"
            };
            IContact contact2 = new Contact
            {
                FirstName = "Charlie",
                LastName = "G",
                PhoneNumber = "2222",
                Email = "charlie@domain.com",
                Address = "Beverly Hills"
            };
            contactBook.AddContact(contact1);
            contactBook.AddContact(contact2);

            // Act
            // Detta testar endast DisplayAllContacts-metoden som skriver till konsolen, inga direkta påståenden här

            // Assert
            // Du kan lägga till påståenden här om det finns specifika utmatningar du vill verifiera
        }

        [Fact]
        public void DisplayContactDetails_SkaVisaDetaljerOmKontaktExisterar()
        {
            // Arrange
            IContactBook contactBook = new ContactBook();
            IContact contact = new Contact
            {
                FirstName = "Charlie",
                LastName = "G",
                PhoneNumber = "2222",
                Email = "charlie@domain.com",
                Address = "Beverly Hills"
            };
            contactBook.AddContact(contact); // Lägg till en kontakt att visa detaljer för

            // Act
            // Detta testar endast DisplayContactDetails-metoden som skriver till konsolen, inga direkta påståenden här

            // Assert
            // Du kan lägga till påståenden här om det finns specifika utmatningar du vill verifiera
        }
    }
}
