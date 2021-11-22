using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment2.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models;

namespace Assignment2.Data
{
    public class SqliteAdultService:IAdultService
    {
        private AdultContext adultContext;

        public SqliteAdultService(AdultContext adultContext)
        {
            this.adultContext = adultContext;
        }


        public async Task<IList<Adult>> GetAdultsAsync()
        {
            return await adultContext.Adults.ToListAsync();
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            EntityEntry<Adult> adultAdd = await adultContext.Adults.AddAsync(adult);
            await adultContext.SaveChangesAsync();
            return adultAdd.Entity;
        }

        public async Task RemoveAdultAsync(int adultId)
        {
            Adult adultRemove = await adultContext.Adults.FirstAsync(a => a.Id == adultId);
            if (adultRemove != null)
            {
                adultContext.Adults.Remove(adultRemove);
                await adultContext.SaveChangesAsync();
            }
        }

        public async Task<Adult> UpdateAsync(Adult adult)
        {
            try
            {
                Adult toUpdate = await adultContext.Adults.FirstOrDefaultAsync(a => a.Id == adult.Id);
                toUpdate.FirstName = adult.FirstName;
                toUpdate.LastName = adult.LastName;
                toUpdate.HairColor = adult.HairColor;
                toUpdate.EyeColor = adult.EyeColor;
                toUpdate.Age = adult.Age;
                toUpdate.Weight = adult.Weight;
                toUpdate.Height = adult.Height;
                toUpdate.Sex = adult.Sex;
                toUpdate.JobTitle = adult.JobTitle;
                toUpdate.Salary = adult.Salary;
                adultContext.Adults.Update(toUpdate);
                adultContext.Update(toUpdate);
                await adultContext.SaveChangesAsync();
                return toUpdate;
            }
            catch (Exception e)
            {
                throw new Exception($"Did not find todo with id{adult.Id}");
            }
        }
    }
}