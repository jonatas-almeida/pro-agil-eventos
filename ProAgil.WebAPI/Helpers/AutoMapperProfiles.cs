using System.Linq;
using AutoMapper;
using ProAgil.Domain;
using ProAgil.WebAPI.DTOs;

namespace ProAgil.WebAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Referenciando as classes que irão ser utilizadas pelo AutoMapper

            //O mapeamento serve para referenciarmos com mais "segurança" qual objeto está sendo consumido da API. É necessário esse referênciamento porque ele é de muitos pra muitos, então é necessário especificar o que queremos pegar de informações importantes
            CreateMap<Evento, EventoDto>().ForMember(dest => dest.Palestrantes, opt => {
                opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Palestrante).ToList());
            });
            CreateMap<Palestrante, PalestranteDto>().ForMember(dest => dest.Eventos, opt => {
                opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Evento).ToList());
            });
            CreateMap<Lote, LoteDto>();
            CreateMap<RedeSocial, RedeSocialDto>();
        }
    }
}