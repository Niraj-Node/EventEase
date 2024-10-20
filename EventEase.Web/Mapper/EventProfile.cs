using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventEase.Application.Models;
using EventEase.Core.Entities;
using EventEase.Web.Models;

namespace EventEase.Web.Mapper
{
    public class EventProfiles : Profile
    {
        public EventProfiles()
        {
            // Mapping from EventModel to EventViewModel and vice versa
            CreateMap<EventModel, EventViewModel>()
                .ForMember(dest => dest.Comments, opt => opt.Ignore()) // Ignore Comments for now if not needed in ViewModel
                .ReverseMap();

            // Mapping for user sign-up
            CreateMap<SignUpModel, SignUpViewModel>().ReverseMap();

            // Mapping for login functionality
            CreateMap<LoginModel, LoginViewModel>().ReverseMap();

            // Mapping for comments
            CreateMap<CommentModel, CommentViewModel>().ReverseMap();
        }
    }
}
