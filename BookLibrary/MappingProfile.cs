using AutoMapper;
using BookLibrary.Entites;
using BookLibrary.Entites.DTO;

namespace BookLibrary
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonDto, Person>();
            CreateMap<BookDto, Book>();
            CreateMap<LibraryCardDto, LibraryCard>();
        }
    }
}
