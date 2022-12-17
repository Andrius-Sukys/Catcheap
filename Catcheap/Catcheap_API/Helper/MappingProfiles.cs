using AutoMapper;
using Catcheap_API.DTO;
using Catcheap_API.Models.CarModels;
using Catcheap_API.Models.ScooterModels;

namespace Catcheap_API.Helper;

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

