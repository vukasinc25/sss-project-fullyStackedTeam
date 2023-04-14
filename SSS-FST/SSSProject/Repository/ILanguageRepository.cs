﻿using SSS_FullyStackedTeam.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSSProject.Repository
{
    interface ILanguageRepository
    {
        List<Language> GetAll();
        Language GetById(int id);
        int Add(Language language);
        void Update(int id, Language language);
        void Delete(int id);
    }
}
