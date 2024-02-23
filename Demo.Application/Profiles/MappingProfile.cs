using AutoMapper;
using Demo.Application.DTOs.Book;
using Demo.Domain;

namespace Demo.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
                CreateMap<Book , BookDto>().ReverseMap();
                CreateMap<Book, AddBookDto>().ReverseMap();

        }
    }
}
