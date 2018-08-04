using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LeagueTool.Models.DataDragonDtos;
using LeagueTool.Models.ViewModels;

namespace LeagueTool.Profiles
{
    public class DataDragonProfile : Profile
    {
        public DataDragonProfile()
        {
            CreateMap<ChampionDto, ChampionListItemModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Key))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Tags.First()))
                .ForMember(dest => dest.SquareImage,
                    opt => opt.MapFrom(
                        src => GetSquareImage(src.Version, src.Image.Full)));

            CreateMap<AllChampionsDto, IEnumerable<ChampionListItemModel>>()
                .ConvertUsing((src, dest, ctx) => 
                    src.Data.Values.Select(v => ctx.Mapper.Map<ChampionListItemModel>(v)));
        }

        private static string GetSquareImage(string version, string image)
        {
            return $"http://ddragon.leagueoflegends.com/cdn/{version}/img/champion/{image}";
        }
    }
}