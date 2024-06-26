﻿using SSS_FullyStackedTeam.Model;
using SSSProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_FullyStackedTeam.Repository
{
    internal interface IClientRepository
    {
        List<Client> GetAll();
        Client GetById(int? id);
        int Add(Client client);
        void Update(int id, Client client);
        void Delete(int id);
        List<Goal> GetAllGoals();
        Goal GetGoalById(int id);
        List<Illness> GetAllIllnesses();
        Illness GetIllnessById(int id);
        List<Prop> GetAllProps();
        Prop GetPropById(int id);

    }
}
