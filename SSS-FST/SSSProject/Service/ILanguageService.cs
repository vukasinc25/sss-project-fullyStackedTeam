using SSS_FullyStackedTeam.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSSProject.Service
{
    interface ILanguageService
    {
        List<Language> GetAll();
        List<Language> GetActive();
        void Add(Language language);
        void Update(int id, Language language);
        void Delete(int id);
    }
}
