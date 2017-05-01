﻿namespace NeverGoodEnough.Services
{
    using NeverGoodEnough.Models.EntityModels;

    public class AccountService : Service
    {
        public void CreateEngineer(ApplicationUser user)
        {
            var newEngineer = new Engineer();
            newEngineer.User = user;

            this.Context.Engineers.Add(newEngineer);
            this.Context.SaveChanges();
        }
    }
}