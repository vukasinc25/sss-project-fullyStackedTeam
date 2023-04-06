using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_FullyStackedTeam.Model
{

    public class User
    {
        public int Id { get; set; }    

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }    
        public string ContactNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CardNumber { get; set; }

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

        List<Language> SecondaryLanguages { get; set; }

        public string TimeZone { get; set;  }



    }
}
