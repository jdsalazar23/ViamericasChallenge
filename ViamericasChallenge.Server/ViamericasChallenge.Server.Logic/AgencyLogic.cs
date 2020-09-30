using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViamericasChallenge.Server.Common.ViewModels;
using ViamericasChallenge.Server.Data.Models;
using ViamericasChallenge.Server.Data.Repository;
using ViamericasChallenge.Server.Logic.Services;

namespace ViamericasChallenge.Server.Logic
{
    public class AgencyLogic
    {
        public async Task<List<AgencyResponse>> GetAgenciesAsync(string city)
        {
            List<AgencyResponse> agencyResponses = await AgencyService.GetAgencyAsync();

            ProcessResponseToDataBase(agencyResponses);

            return agencyResponses.Where(a => a.City.Equals(city)).ToList();
        }

        private void ProcessResponseToDataBase(List<AgencyResponse> agencyResponses)
        {
            foreach (var item in agencyResponses)
            {
                ProcessAgengyData(item);
            }
        }

        private void ProcessAgengyData(AgencyResponse item)
        {
            City city = ValidateCity(item.City);
            State state = ValidateState(item.State);
            Status status = ValidateStatus(item.Status);

            Agency agency = GetAgencyData(item, city, state, status);

            ProcessAgengy(agency);

        }

        private void ProcessAgengy(Agency agency)
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            var result = unitOfWork.AgencyRepository.Get(c => c.AgencyId.Equals(agency.AgencyId));
            if (result == null || result.Count() == 0)
                unitOfWork.AgencyRepository.Insert(agency);
        }

        private Agency GetAgencyData(AgencyResponse item, City city, State state, Status status)
        {
            Agency agency = new Agency();
            agency.Name = item.Name;
            agency.AgencyId = item.Id;
            agency.CityId = city.CityId;
            agency.StateId = state.StateId;
            agency.StatusId = status.StatusId;
            return agency;
        }

        private City ValidateCity(string cityParam)
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            var result = unitOfWork.CityRepository.Get(c => c.Name.Equals(cityParam));
            if (result != null && result.Count() > 0)
            {
                return result.First();
            }
            else
            {
                City city = new City() { Name = cityParam };

                unitOfWork.CityRepository.Insert(city);
                return city;
            }
        }

        private State ValidateState(string stateParam)
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            var result = unitOfWork.StateRepository.Get(c => c.Name.Equals(stateParam));
            if (result != null && result.Count() > 0)
            {
                return result.First();
            }
            else
            {
                State state = new State() { Name = stateParam };

                unitOfWork.StateRepository.Insert(state);
                return state;
            }
        }

        private Status ValidateStatus(string statusParam)
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            var result = unitOfWork.StatusRepository.Get(c => c.Name.Equals(statusParam));
            if (result != null && result.Count() > 0)
            {
                return result.First();
            }
            else
            {
                Status status = new Status() { Name = statusParam };

                unitOfWork.StatusRepository.Insert(status);
                return status;
            }
        }
    }
}
