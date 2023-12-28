using ConsoleApp3.Enums;
using ConsoleApp3.Interfaces;
using ConsoleApp3.Models.Responses;
using System;

namespace ConsoleApp3.Services
{
    
    public class MenuService
    {
        private readonly IContactBook contactBook;

        public MenuService(IContactBook contactBook)
        {
            this.contactBook = contactBook;
        }

        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Välkommen till Telefonboken!");
            Console.WriteLine();
            Console.WriteLine("Vänligen gör ett val:");
            Console.WriteLine($"{"1.",-3} Lägg till kontakt");
            Console.WriteLine($"{"2.",-3} Ta bort kontakt");
            Console.WriteLine($"{"3.",-3} Visa alla kontakter");
            Console.WriteLine($"{"4.",-3} Visa detaljer för kontakt");
            Console.WriteLine($"{"0.",-3} Avsluta");
            Console.WriteLine();
            Console.Write("Ditt menyval:");
        }

        public void ProcessChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    AddContactFromUserInput();
                    break;

                case "2":
                    RemoveContact();
                    break;

                case "3":
                    DisplayAllContacts();
                    break;

                case "4":
                    DisplayContactDetails();
                    break;

                case "0":
                    ShowExitApplication();
                    break;

                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    Console.WriteLine("Tryck på en tangent för att fortsätta...");
                    Console.ReadKey();
                    break;
            }
        }

        private void ShowExitApplication()
        {
            Console.Clear();
            Console.Write("Är du säker på att du vill avsluta programmet? (y/n): ");
            var option = Console.ReadLine() ?? "";

            if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
                Environment.Exit(0);
        }

        private void AddContactFromUserInput()
        {
            IContact newContact = new Contact();

            Console.Write("Förnamn: ");
            newContact.FirstName = Console.ReadLine()?.Trim() ?? string.Empty;
            Console.Write("Efternamn: ");
            newContact.LastName = Console.ReadLine().Trim() ?? string.Empty;
            Console.Write("Telefonnummer: ");
            newContact.PhoneNumber = Console.ReadLine().Trim() ?? string.Empty;
            Console.Write("E-post: ");
            newContact.Email = Console.ReadLine().Trim() ?? string.Empty;
            Console.Write("Adress: ");
            newContact.Address = Console.ReadLine().Trim() ?? string.Empty;

            var result = contactBook.AddContact(newContact);
            ProcessServiceResult(result);
        }

        private void RemoveContact()
        {
            Console.Write("Ange e-postadress för att ta bort kontakt: ");
            var emailToRemove = Console.ReadLine().Trim();
            contactBook.RemoveContactByEmail(emailToRemove);
        }

        private void DisplayAllContacts()
        {
            Console.Clear();
            contactBook.DisplayAllContacts();
            Console.WriteLine("Tryck på en tangent för att fortsätta...");
            Console.ReadKey();
        }

        private void DisplayContactDetails()
        {
            Console.Write("Ange e-postadress för att visa detaljer: ");
            var emailToDisplay = Console.ReadLine().Trim();

            var contact = (Contact)contactBook.GetContactByEmail(emailToDisplay);

            if (contact != null)
            {
                Console.Clear();
                Console.WriteLine($"ID: {contact.Id}");
                Console.WriteLine($"Namn: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"Telefon: {contact.PhoneNumber}");
                Console.WriteLine($"E-post: {contact.Email}");
                Console.WriteLine($"Adress: {contact.Address}");
            }
            else
            {
                Console.WriteLine("Kontakt hittades inte.");
            }

            Console.WriteLine("Tryck på en tangent för att fortsätta...");
            Console.ReadKey();
        }

        private void ProcessServiceResult(ServiceResult result)
        {
            if (result.Status == ServiceStatus.SUCCEDED)
            {
                Console.WriteLine("Kontakt tillagd.");
            }
            else if (result.Status == ServiceStatus.ALREADY_EXISTS)
            {
                Console.WriteLine("Kontakt finns redan.");
            }
            else
            {
                Console.WriteLine($"Error: {result.Result}");
            }
            Console.WriteLine("Tryck på en tangent för att fortsätta...");
            Console.ReadKey();
        }
    }
}
