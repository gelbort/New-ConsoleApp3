using ConsoleApp3.Models.Responses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using ConsoleApp3.Enums;
using ConsoleApp3.Interfaces;
using Newtonsoft.Json;

namespace ConsoleApp3.Services
{
    public class ContactBook : IContactBook
    {
        private List<IContact> contacts;
        private const string FileName = "contacts.json";

        public ContactBook()
        {
            LoadContactsFromFile();
        }

        public ServiceResult AddContact(IContact contact)
        {
            var response = new ServiceResult();
            try
            {
                if (!contacts.Any(x => x.Email == contact.Email))
                {
                    contact.Id = Guid.NewGuid();
                    contacts.Add(contact);
                    SaveContactsToFile();
                    response.Status = Enums.ServiceStatus.SUCCEDED;
                }
                else
                {
                    response.Status = Enums.ServiceStatus.ALREADY_EXISTS;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                response.Status = ServiceStatus.FAILED;
                response.Result = $"Error: {ex.Message}";
            }

            return response;
        }

        public void RemoveContactByEmail(string email)
        {
            var contactToRemove = contacts.FirstOrDefault(c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (contactToRemove != null)
            {
                contacts.Remove(contactToRemove);
                Console.WriteLine("Kontakt borttagen.");
                SaveContactsToFile();
            }
            else
            {
                Console.WriteLine("Kontakt hittades inte.");
            }
        }

        public List<IContact> GetAllContacts()
        {
            return contacts;
        }

        public IContact GetContactByEmail(string email)
        {
            return contacts.FirstOrDefault(c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public void DisplayAllContacts()
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Namn: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"Telefonnummer: {contact.PhoneNumber}");
                Console.WriteLine($"E-post: {contact.Email}");
                Console.WriteLine($"Adress: {contact.Address}");
                Console.WriteLine();
            }
        }

        public void DisplayContactDetails(string email)
        {
            var contact = GetContactByEmail(email);
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

        private void LoadContactsFromFile()
        {
            if (File.Exists(FileName))
            {
                var json = File.ReadAllText(FileName);
                var concreteContacts = JsonConvert.DeserializeObject<List<Contact>>(json);
                contacts = concreteContacts.Cast<IContact>().ToList();
            }
            else
            {
                contacts = new List<IContact>();
            }
        }

        private void SaveContactsToFile()
        {
            var json = JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(FileName, json);
            Console.WriteLine("Kontakter sparade.");
        }
    }
}
