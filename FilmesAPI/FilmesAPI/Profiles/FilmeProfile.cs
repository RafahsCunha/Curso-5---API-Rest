using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            // Conversão de tipos
            CreateMap<CreateFilmeDto, Filme>();// Converte de CreateFilmeDto para Filme
            CreateMap<Filme, ReadFilmeDto>();// Converte de Filme para ReadFilmeDto
            CreateMap<UpdateFilmeDto, Filme>();// Converte de UpdateFilmeDto para Filme
        }
        
    }
}
