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
                .ForMember(dest => dest.SquareImage,
                    opt => opt.MapFrom(
                        src => GetSquareImage(src.Version, src.Image.Full)));

            CreateMap<AllChampionsDto, ChampionListModel>()
                .ForMember(dest => dest.Champions, opt => opt.MapFrom(src => src.Data.Values));
        }

        private static string GetSquareImage(string version, string image)
        {
            return $"http://ddragon.leagueoflegends.com/cdn/{version}/img/champion/{image}";
        }
    }
}