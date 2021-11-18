using AutoMapper;
using Contracts;
using Domain.Entites;

namespace BookLibrary
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonForCreationDto, PersonDto>();
            CreateMap<PersonDto, Person>();
            CreateMap<BookDto, Book>();
            CreateMap<LibraryCardDto, LibraryCard>();
        }
    }
}
