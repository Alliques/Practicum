using AutoMapper;
using BookLibrary.Entites.DTO;
using BookLibrary.Entites.Models;

namespace BookLibrary
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HumanDto, Human>();
            CreateMap<BookDto, Book>();
            CreateMap<LibraryCardDto, LibraryCard>();
        }
    }
}
