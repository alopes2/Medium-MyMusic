using AutoMapper;
using MyMusic.Api.Resources;
using MyMusic.Core.Models;

namespace MyMusic.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Music, MusicResource>();
            CreateMap<Artist, ArtistResource>();
            
            // Resource to Domain
            CreateMap<MusicResource, Music>();
            CreateMap<SaveMusicResource, Music>();
            CreateMap<ArtistResource, Artist>();
            CreateMap<SaveArtistResource, Artist>();
        }
    }
}