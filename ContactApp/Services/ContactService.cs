using ContactApp.Models;
using System.ComponentModel.DataAnnotations;

namespace ContactApp.Services
{
    public class ContactService
    {
        private List<Contact> contacts = new List<Contact>();

        public List<Contact> GetContacts()
        {
           return contacts;
        }

        public Contact GetContact(int id)
        {
            return contacts.FirstOrDefault(c => c.Id == id);
        }

        public bool ValidateContact(Contact contact) 
        {
            var validationContext = new ValidationContext(contact, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            bool validate = Validator.TryValidateObject(contact, validationContext, validationResults, validateAllProperties: true);
            return validate;
            
        }

        public void AddContact(Contact contact)
        {
            contact.Id = contacts.Count > 0 ? contacts.Max(c => c.Id) + 1 : 1;
            contacts.Add(contact);
        }

        public void UpdateContact(Contact contact)
        {
            var existingContact = GetContact(contact.Id);
            if (existingContact != null)
            {
                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;
                existingContact.Email = contact.Email;
                existingContact.PhoneNumber = contact.PhoneNumber;
            }
        }

        public void DeleteContact(int id)
        {
            var contact = GetContact(id);
            if (contact != null)
            {
                contacts.Remove(contact);
            }
        }
    }
}
