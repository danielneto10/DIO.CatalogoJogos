using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CatalogoJogos.Application.Dtos;
using CatalogoJogos.Application.Interfaces;
using CatalogoJogos.Domain.Models;
using CatalogoJogos.Infrastructure.Interfaces;

namespace CatalogoJogos.Application.Services
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository jogoRepository;
        private readonly IGeralRepository geralRepository;
        private readonly IMapper mapper;
        public JogoService(IGeralRepository geralRepository, IJogoRepository jogoRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.geralRepository = geralRepository;
            this.jogoRepository = jogoRepository;

        }

        public async Task AddJogo(CreateJogoDto model)
        {
            try
            {
                var entidadeJogo = await jogoRepository.ObterAsync(model.Nome, model.Produtora);
                if(entidadeJogo is not null ) throw new Exception("Jogo já cadastrado!");

                var jogo = mapper.Map<Jogo>(model);
                geralRepository.Add<Jogo>(jogo);

                await geralRepository.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public async Task UpdateJogo(Guid id, UpdateJogoDto model)
        {
            try
            {
                var entidadeJogo = await jogoRepository.ObterAsync(id);
                if(entidadeJogo is null) throw new Exception("Jogo não encontrado");

                mapper.Map(model, entidadeJogo);
                geralRepository.Update<Jogo>(entidadeJogo);
                await geralRepository.SaveChangesAsync();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public async Task RemoveJogo(Guid id)
        {
            try
            {
                var jogo = await jogoRepository.ObterAsync(id);
                if (jogo is null) throw new Exception("Jogo não encontrado");

                geralRepository.Remove<Jogo>(jogo);
                await geralRepository.SaveChangesAsync();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public async Task<List<JogoDto>> ObterAsync(int pagina, int quantidade)
        {
            try
            {
                var jogos = await jogoRepository.ObterAsync(pagina, quantidade);
                if (jogos.Count() < 1) return null;

                var jogoDto = mapper.Map<JogoDto[]>(jogos);

                return jogoDto.ToList();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public async Task<JogoDto> ObterAsync(Guid id)
        {
            try
            {

                var jogo = await jogoRepository.ObterAsync(id);
                if (jogo is null) return null;

                var jogoDto = mapper.Map<JogoDto>(jogo);

                return jogoDto;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public async Task<JogoDto> ObterAsync(string nome, string produtora)
        {
            try
            {
                var jogo = await jogoRepository.ObterAsync(nome, produtora);
                if (jogo is null) return null;

                var jogoDto = mapper.Map<JogoDto>(jogo);

                return jogoDto;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}