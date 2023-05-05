using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_FullyStackedTeam.Model
{
    public class User : ICloneable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }    
        public string Tel { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CreditCard { get; set; }
        public string isAdmin { get; set; }

        private Language primaryLanguage;
        public int? PrimaryLanguageId { get; set; }
        public Language PrimaryLanguage
        {
            get => primaryLanguage;
            set
            {
                primaryLanguage = value;
                PrimaryLanguageId = primaryLanguage?.Id;
            }
        }

        public List<Language> SecondaryLanguages { get; set; }

        public string TimeZone { get; set;  }

        public User()
        {
            SecondaryLanguages = new List<Language>();
        }

        public object Clone()
        {
            List<Language> languages = new List<Language>(SecondaryLanguages);
            List<Language> newList = new List<Language>();

            foreach (Language language in languages)
            {
                newList.Add((Language)language.Clone());
            }

            return new User
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Password = Password,
                Tel = Tel,
                Street = Street,
                City = City,
                Country = Country,
                CreditCard = CreditCard,
                TimeZone = TimeZone,
                PrimaryLanguage = PrimaryLanguage,
                SecondaryLanguages = newList,
                isAdmin = isAdmin
            };
        }
    }
}
