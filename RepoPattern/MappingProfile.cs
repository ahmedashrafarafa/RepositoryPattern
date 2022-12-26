using AutoMapper;
using RepoPattern.API.DTOs;
using RepoPattern.Core.Models;
using System;
using System.Linq;

namespace RepoPattern.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
        }
    }
}
