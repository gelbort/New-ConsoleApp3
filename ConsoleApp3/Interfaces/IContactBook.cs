using ConsoleApp3.Models.Responses;

namespace ConsoleApp3.Interfaces
{
    public interface IContactBook
    {
        ServiceResult AddContact(IContact contact); 
        void RemoveContactByEmail(string email);
        List<IContact> GetAllContacts();
        IContact GetContactByEmail(string email);
        void DisplayAllContacts();
        void DisplayContactDetails(string email);
    }
}
