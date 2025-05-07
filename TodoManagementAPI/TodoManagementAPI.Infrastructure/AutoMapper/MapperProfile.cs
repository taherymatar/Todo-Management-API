using AutoMapper;
using TodoManagementAPI.Core.Dtos;
using TodoManagementAPI.Core.ViewModels;
using TodoManagementAPI.Data.Models;

namespace TodoManagementAPI.Infrastructure.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateTodoDto, Todo>();
            CreateMap<UpdateTodoDto, Todo>();
            CreateMap<Todo, UpdateTodoDto>();
            CreateMap<Todo, TodoViewModel>().ForMember(x => x.Status, x => x.MapFrom(x => x.Status.ToString()))
                                            .ForMember(x => x.Priority, x => x.MapFrom(x => x.Priority.ToString()))
                                            .ForMember(x => x.CreatedDate, x => x.MapFrom(x => x.CreatedDate.ToString("yyyy-MM-dd")))
                                            .ForMember(x => x.Priority, x => x.MapFrom(x => x.Priority.ToString()))
                                            .ForMember(x => x.LastModifiedDate, x => x.MapFrom(x => x.LastModifiedDate.ToString("yyyy-MM-dd")))
                                            .ForMember(x => x.DueDate, x => x.MapFrom(x => x.DueDate.HasValue ? x.DueDate.Value.ToString("yyyy-MM-dd") : null));
        }
    }
}
