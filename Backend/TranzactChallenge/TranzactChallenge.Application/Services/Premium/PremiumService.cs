using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TranzactChallenge.Application.ViewModels;
using TranzactChallenge.Core.Entities;
using TranzactChallenge.Core.Interfaces;

namespace TranzactChallenge.Application.Services
{
    public class PremiumService : IPremiumService
    {
        private readonly IPremiumRepository _premiumRepository;
        public PremiumService(IPremiumRepository premiumRepository)
        {
            _premiumRepository = premiumRepository;
        }

        public async Task<List<PremiumViewModel>> GetPremiums(PostFilter filter)
        {
            #region Get Month
            DateTime dateValue;
            DateTime today = DateTime.Today;
            int age = 0;

            if (DateTime.TryParseExact(filter.DateOfBirth, "yyyy-MM-dd", null, DateTimeStyles.None, out dateValue))
            {                
                age = DateTime.Now.Year - dateValue.Year;

                if ((dateValue.Month > DateTime.Now.Month) || (dateValue.Month == DateTime.Now.Month && dateValue.Day > DateTime.Now.Day))
                    age--;

                filter.MonthOfBirth = dateValue.ToString("MMMM", CultureInfo.CreateSpecificCulture("en"));
                filter.Age = age;
            }
            #endregion

            var premiums = await _premiumRepository.GetPremiums(filter);

            #region Validate Age 

            List<int> ids = new List<int>();
            foreach (var p in premiums)
            {
                if (!String.IsNullOrEmpty(p.Age))
                {
                    if (p.Age.Contains("+") && p.Age.Length > 2)
                    {
                        var range = int.Parse(p.Age.Substring(0,2).ToString());

                        if (range > age)
                            ids.Add(p.id);
                    }
                    else if (p.Age.Contains("-"))
                    {
                        var range = p.Age.Split("-").Select(Int32.Parse).ToList();

                        if (range.Count > 0)
                        {
                            if (!(range[0] <= age && age <= range[1]))
                                ids.Add(p.id);
                        }
                    }
                }
            }

            premiums.RemoveAll(x => ids.Contains(x.id));
            #endregion

            var premiumsM = premiums
                .Select(u => new PremiumViewModel(u))
                .ToList();

            return premiumsM;
        }

    }
}
