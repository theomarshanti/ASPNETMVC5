using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile: Profile
    {
        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<MappingProfile>();
            });
        }

        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());

            CreateMap<MembershipType, MembershipTypeDto>();

            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
            //<Source, Destination>

            CreateMap<Rental, RentalDto>();
            CreateMap<RentalDto, Rental>().ForMember(r => r.Id, opt => opt.Ignore());
        }
    }
}