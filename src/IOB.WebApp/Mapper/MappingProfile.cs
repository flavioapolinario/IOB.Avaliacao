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

        //CreateMap<Compromisso, AtualizaCompromissoRequest>();
        //CreateMap<Endereco, InsereEnderecoRequest>();
        //CreateMap<Endereco, AtualizaEnderecoRequest>();

        //CreateMap<InsereContatoRequest, Contato>();
        //CreateMap<AtualizaContatoRequest, Contato>();
        //CreateMap<InsereCompromissoRequest, Compromisso>();
        //CreateMap<AtualizaCompromissoRequest, Compromisso>();
        //CreateMap<InsereEnderecoRequest, Endereco>();
        //CreateMap<AtualizaEnderecoRequest, Endereco>();

        // Response
        CreateMap<Contato, ContatoResponse>();
        CreateMap<Compromisso, CompromissoResponse>();

        CreateMap<ContatoResponse, Contato>();
        CreateMap<CompromissoResponse, Compromisso>();
    }
}