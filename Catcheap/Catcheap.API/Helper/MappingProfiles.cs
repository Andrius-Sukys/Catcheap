using AutoMapper;
using Catcheap.API.DTO;
using Catcheap.API.Models.CarModels;
using Catcheap.API.Models.ScooterModels;

namespace Catcheap.API.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Car, CarDTO>();
        CreateMap<CarJourney, JourneyDTO>();
        CreateMap<CarCharge, ChargeDTO>();

        CreateMap<Scooter, ScooterDTO>();
        CreateMap<ScooterJourney, JourneyDTO>();
        CreateMap<ScooterCharge, ChargeDTO>();

        CreateMap<CarDTO, Car>();
        CreateMap<JourneyDTO, CarJourney>();
        CreateMap<ChargeDTO, CarCharge>();

        CreateMap<ScooterDTO, Scooter>();
        CreateMap<JourneyDTO, ScooterJourney>();
        CreateMap<ChargeDTO, ScooterCharge>();
    }

}

