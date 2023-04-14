using SSS_FullyStackedTeam.Model;
using SSSProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSSProject.Service
{
    class LanguageService : ILanguageService
    {
        private ILanguageRepository repository;

        public LanguageService()
        {
            repository = new LanguageRepository();
        }

        public void Add(Language language)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Language> GetActive()
        {
            throw new NotImplementedException();
        }

        public List<Language> GetAll()
        {
            return repository.GetAll();
        }

        public void Update(int id, Language language)
        {
            throw new NotImplementedException();
        }
    }
}
