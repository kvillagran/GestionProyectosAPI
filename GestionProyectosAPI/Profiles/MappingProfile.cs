using AutoMapper;
using GestionProyectosAPI.DTOs;
using GestionProyectosAPI.DTOs.GestionProyectosAPI.DTOs;
using GestionProyectosAPI.Models;
using EstadoTarea = GestionProyectosAPI.DTOs.EstadoTarea;

namespace GestionProyectosAPI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeo entre Equipo y EquipoReadDto
            CreateMap<Equipo, EquipoReadDto>();
            CreateMap<EquipoCreateDto, Equipo>();

            // Mapeo entre Proyecto y ProyectoReadDto
            CreateMap<Proyecto, ProyectoReadDto>();
            CreateMap<ProyectoCreateDto, Proyecto>();
            CreateMap<Proyecto, ProyectoSimplificadoDto>();

            // Mapeo entre Equipo y EquipoSimplificadoDto
            CreateMap<Equipo, EquipoSimplificadoDto>();

            // Mapeo entre Tarea y TareaReadDto
            CreateMap<Tarea, TareaReadDto>()
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado.ToString()));
            CreateMap<TareaCreateDto, Tarea>()
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => (EstadoTarea)src.Estado));

            // Mapeo para TareaSimplificadaDto
            CreateMap<Tarea, TareaSimplificadaDto>()
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado.ToString()));
        }
    }
}

