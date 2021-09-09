using AutoMapper;
using CatalogoJogos.Application.Dtos;
using CatalogoJogos.Domain.Models;

namespace CatalogoJogos.Application.Helpers
{
    public class CatalogoJogosProfile : Profile
    {
        public CatalogoJogosProfile()
        {
            CreateMap<Jogo, JogoDto>().ReverseMap();
            CreateMap<Jogo, CreateJogoDto>().ReverseMap();
        }
    }
}