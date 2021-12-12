using AutoMapper;
using BookhubApi.Modelss;
using BookhubApi.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookhubApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<userVM, User>();
            //CreateMap<User, userVM>();

            CreateMap<bookVM, Book>();
            //CreateMap<Book, bookVM>();

            /*CreateMap<ComentVm, Coment>();
            CreateMap<Coment, ComentVm>();*/

            CreateMap<publicationVM, Publication>();
            /*CreateMap<Publication, PublicationVM>();

            CreateMap<RoleVm, Role>();
            CreateMap<Role, RoleVm>();*/
        }
    }
}
