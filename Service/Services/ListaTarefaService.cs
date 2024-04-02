using AutoMapper;
using Domain.DTO;
using Domain.Exceptions;
using Domain.Interfaces.Datas;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Service.Services
{
    public class ListaTarefaService : IListaTarefaService
    {
        private readonly IListaTarefaRepository _listaTarefaRepository;
        private readonly IListaTarefaAggregateRepository _listaTarefaAggregateRepository;
        private readonly IMapper _mapper;

        public ListaTarefaService(IListaTarefaRepository listaTarefaRepository,
                                  IListaTarefaAggregateRepository listaTarefaAggregateRepository,
                                  IMapper mapper)
        {
            _listaTarefaRepository = listaTarefaRepository;
            _listaTarefaAggregateRepository = listaTarefaAggregateRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ListaTarefaResponseDto>> BuscarTodasListasDeTarefaAsync()
        {
            try
            {
                var listaDeTarefasDto = await _listaTarefaRepository.BuscarTodasListasDeTarefaAsync();

                return listaDeTarefasDto;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ListaTarefaResponseDto> BuscarListaDeTarefaPorResponsavelAsync(string responsavel)
        {
            try
            {
                var listaDeTarefas = await _listaTarefaAggregateRepository.BuscarListaDeTarefasPorResponsavelAsync(responsavel);

                if (listaDeTarefas is null)
                    throw new ListaDeTarefaNotFoundException($"Lista de tarefas não encontrada para o Responsável: {responsavel}");

                var listaTarefasResponseDto = _mapper.Map<ListaTarefaResponseDto>(listaDeTarefas);

                return listaTarefasResponseDto;
            }
            catch
            {
                throw;
            }
        }

        public async Task AdicionarListaDeTarefasAsync(ListaTarefaRequestDto tarefasRequestDto)
        {
            try
            {
                var listaDeTarefas = await _listaTarefaAggregateRepository.BuscarListaDeTarefasPorResponsavelAsync(tarefasRequestDto.Responsavel!);

                if (listaDeTarefas is not null)
                    throw new ListaDeTarefaBadRequestException($"Lista de tarefas já existe para o Responsável: {tarefasRequestDto.Responsavel!}");

                var listaTarefa = _mapper.Map<ListaTarefa>(tarefasRequestDto);

                await _listaTarefaRepository.AdicionarListaDeTarefasAsync(listaTarefa);
            }
            catch
            {
                throw;
            }
        }

        public async Task AtualizarListaDeTarefasAsync(string responsavel, ICollection<TarefaRequestDto> tarefasAtualizadasDto)
        {
            try
            {
                var listaDeTarefas = await _listaTarefaAggregateRepository.BuscarListaDeTarefasPorResponsavelAsync(responsavel);

                if (listaDeTarefas is null)
                    throw new ListaDeTarefaNotFoundException($"Lista de tarefas a ser atualizada não encontrada para o Responsável: {responsavel}");

                ICollection<Tarefa> tarefasAtualizadas = new List<Tarefa>();
                foreach (var tarefaAtualizadaDto in tarefasAtualizadasDto)
                    tarefasAtualizadas.Add(_mapper.Map<Tarefa>(tarefaAtualizadaDto));

                var tarefasRemovidas = listaDeTarefas.RemoverTarefas(tarefasAtualizadas);
                if (tarefasRemovidas is not null && tarefasRemovidas.Any())
                    _listaTarefaAggregateRepository.RemoverTarefaDaListaAsync(tarefasRemovidas.ToList());

                listaDeTarefas.AtualizarListaDeTarefas(tarefasAtualizadas);

                await _listaTarefaAggregateRepository.AtualizarListaDeTarefasAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task RemoverListaDeTarefasAsync(string responsavel)
        {
            try
            {
                var listaDeTarefas = await _listaTarefaAggregateRepository.BuscarListaDeTarefasPorResponsavelAsync(responsavel);

                if (listaDeTarefas is null)
                    throw new ListaDeTarefaNotFoundException($"Lista de tarefas a ser removida não encontrada para o Responsável: {responsavel}");

                if (listaDeTarefas.Tarefas is not null && listaDeTarefas.Tarefas.Any())
                    _listaTarefaAggregateRepository.RemoverTarefaDaListaAsync(listaDeTarefas.Tarefas.ToList());

                await _listaTarefaAggregateRepository.RemoverListaDeTarefasAsync(listaDeTarefas);
            }
            catch
            {
                throw;
            }
        }
    }
}