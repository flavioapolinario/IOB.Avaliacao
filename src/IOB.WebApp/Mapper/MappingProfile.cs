using AutoMapper;
using IOB.Application.DTO.Request.Compromisso;
using IOB.Application.DTO.Request.Contato;
using IOB.Application.DTO.Response;
using IOB.Domain.Entidades;
using IOB.WebApp.Models;

namespace IOB.WebApp.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Request
        CreateMap<Contato, ContatoModel>();
        CreateMap<Compromisso, CompromissoModel>();
        CreateMap<Endereco, EnderecoModel>();

        CreateMap<ContatoModel, Contato>();
        CreateMap<EnderecoModel, Endereco>();
        CreateMap<CompromissoModel, Compromisso>();
        
        // Response
        CreateMap<Contato, ContatoResponse>();
        CreateMap<Endereco, EnderecoResponse>();
        CreateMap<Compromisso, CompromissoResponse>();

        CreateMap<ContatoResponse, Contato>();
        CreateMap<EnderecoResponse, Endereco>();
        CreateMap<CompromissoResponse, Compromisso>();
    }
}