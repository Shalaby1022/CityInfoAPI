﻿using AutoMapper;

namespace CityInfoAPI.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile() 
        {
            CreateMap<Entities.City , Models.CityWithoutPointofinteresrsDTO>();
            CreateMap<Entities.City, Models.CityDto>();

        }
    }
}
