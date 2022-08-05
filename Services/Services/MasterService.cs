using AutoMapper;
using Models.DBModels;
using Models.ViewModels;
using Repository.Abstraction;
using Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class MasterService: IMasterService
    {
        private readonly IMasterRepository _masterRepo;
        private readonly IMapper _mapper;
        public MasterService(IMasterRepository masterRepo,IMapper mapper)
        {
            _masterRepo = masterRepo;
            _mapper = mapper;   
        }

        public async Task<MasterVM> GetMasterData()
        {
            try
            {
                var places= await _masterRepo.GetPlaces();
                var mealTypes = await _masterRepo.GetMealType();
                var result = new MasterVM();
                result.MealTypes = _mapper.Map<List<MealType>,List<MealVm>>(mealTypes);
                result.Places = _mapper.Map<List<Place>, List<PlaceVm>>(places);
                return result;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<List<AirlineVM>> GetAirline()
        {
            try
            {
                var result= await _masterRepo.GetAirlines();
                return _mapper.Map<List<AirlineVM>>(result);

            }catch(Exception ex)
            {
                throw;
            }
        }
    }
}
