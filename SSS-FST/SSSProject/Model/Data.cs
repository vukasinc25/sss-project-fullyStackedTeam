﻿using SSS_FullyStackedTeam.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSSProject.Model
{
    public class Data
    {
        private static Data instance;
        public User LoggedInUser { get; set; }
        public Client LoggedInClient { get; set; }
        public Coach LoggedInCoach { get; set; }

        static Data() { }

        private Data()
        {
            LoggedInUser = new User();
            LoggedInClient = new Client();
            LoggedInCoach = new Coach();
        }

        public static Data Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Data();
                }

                return instance;
            }

            private set => instance = value;
        }

    }
}
