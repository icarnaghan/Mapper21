using System;
using Mapper21.DAL.Interfaces;
using Mapper21.DAL.Repositories;
using Mapper21.UI.Controllers;
using Microsoft.Practices.Unity;

namespace Mapper21.UI
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();

            container.RegisterType<ISectionRepository, SectionRepository>();
            container.RegisterType<ICaseStudyRepository, CaseStudyRepository>();

            // Needed for account controller - http://stackoverflow.com/questions/20023065/how-to-add-mvc-5-authentication-to-unity-ioc
            container.RegisterType<AccountController>(new InjectionConstructor());
        }
    }
}