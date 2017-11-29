using AutoMapper;
using Viajante.Transporte.Cadastros;

namespace Viajante.Interface.AutoMapperConfig
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TVeiculo, Veiculo>();
                cfg.CreateMap<Veiculo, TVeiculo>();
            });
        }
    }
}
