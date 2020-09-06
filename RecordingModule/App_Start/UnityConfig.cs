using RecordingModule.Services.Interface;
using RecordingModule.Services.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace RecordingModule
{
	public static class UnityConfig
	{
		public static void RegisterComponents()
		{
			var container = new UnityContainer();
			
			// register all your components with the container here
			// it is NOT necessary to register your controllers
			
			container.RegisterType<IUser, UserServices >();
			container.RegisterType<ITask, TaskServices >();
			
			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
		}
	}
}