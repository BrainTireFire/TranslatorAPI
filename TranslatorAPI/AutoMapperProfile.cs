using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranslatorDataAccessLibrary.Dtos.Notes;
using TranslatorDataAccessLibrary.Models;

namespace TranslatorAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Notes, GetNotesDto>();
            CreateMap<AddNotesDto, Notes>();
        }
    }
}
