using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjects.Models
{
    public class MapperOriModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; } = 1;
        public string MemoSelf { get; set; }
        public string Jobs { get; set; }
        public string LineId { get; set; }
    }

    public class MapperSimpleDestiModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string MemoSelf { get; set; }
        [Description("Arg Contents Memo.")]
        public string ArgContents { get; set; }
        public string line_id { get; set; }
    }

    public class MapperMoreSimpDestiModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string MemoSelf { get; set; }
        public string Jobs { get; set; }
    }

    public class MapperConfigProfile : AutoMapper.Profile
    {
        public MapperConfigProfile()
        {
            CreateMap<MapperOriModel, MapperSimpleDestiModel>().ReverseMap();
            CreateMap<MapperOriModel, MapperMoreSimpDestiModel>().ForMember(des => des.Name
            , opt =>
            {
                opt.MapFrom(s => $"{s.FirstName} {s.LastName}");
            }
            )
            .ForMember(dest => dest.Jobs, src => src.NullSubstitute("Ace"))
            ;
            CreateMap<MapperSimpleDestiModel, MapperMoreSimpDestiModel>().ForMember(des => des.Name
            , opt => {
                opt.MapFrom(s => $"{s.FirstName} {s.LastName}");
            }
            );
        }
    }
}
