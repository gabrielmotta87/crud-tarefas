using AutoMapper;
using Domain.DTO;
using Domain.Models;

namespace Service.Mapper;

public class ListaTarefaMapper : Profile
{
    public ListaTarefaMapper()
    {
        CreateMap<ListaTarefaRequestDto, ListaTarefa>();
        CreateMap<ListaTarefa, ListaTarefaResponseDto>();

        CreateMap<TarefaRequestDto, Tarefa>();
        CreateMap<Tarefa, TarefaResponseDto>();
    }
}