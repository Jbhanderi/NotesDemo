using NotesManagement.Services.Contracts;
using NotesManagement.Services.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace NotesManagement
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<INoteService, NoteService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}