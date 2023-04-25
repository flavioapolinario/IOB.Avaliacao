using AutoMapper;
using IOB.Application.DTO.Request.Compromisso;
using IOB.Application.DTO.Request.Contato;
using IOB.Application.DTO.Response;
using IOB.Domain.Entidades;

namespace IOB.Api.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Request
        CreateMap<Contato, InsereContatoRequest>();
        CreateMap<Contato, AtualizaContatoRequest>();
        CreateMap<Compromisso, InsereCompromissoRequest>();
        CreateMap<Compromisso, AtualizaCompromissoRequest>();
        CreateMap<Endereco, InsereEnderecoRequest>();
        CreateMap<Endereco, AtualizaEnderecoRequest>();

        CreateMap<InsereContatoRequest, Contato>();
        CreateMap<AtualizaContatoRequest, Contato>();
        CreateMap<InsereCompromissoRequest, Compromisso>();
        CreateMap<AtualizaCompromissoRequest, Compromisso>();
        CreateMap<InsereEnderecoRequest, Endereco>();
        CreateMap<AtualizaEnderecoRequest, Endereco>();

        // Response
        CreateMap<Contato, ContatoResponse>();
        CreateMap<Compromisso, CompromissoResponse>();

        CreateMap<ContatoResponse, Contato>();
        CreateMap<CompromissoResponse, Compromisso>();
    }
}