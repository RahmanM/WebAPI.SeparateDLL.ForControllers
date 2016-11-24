using System.Collections.Generic;
using System.Reflection;
using System.Web.Http.Dispatcher;

namespace WebAPI.Separate.Controller.Project
{

    /// <summary>
    ///  Custom assembly resolver to load the controllers from a separate DLL
    /// </summary>
    public class CustomAssembliesResolver : DefaultAssembliesResolver
    {
        public new virtual  ICollection<Assembly> GetAssemblies()
        {

            ICollection<Assembly> baseAssemblies = base.GetAssemblies();
            //List<Assembly> assemblies = new List<Assembly>(baseAssemblies);
            var controllersAssembly = Assembly.LoadFrom(@"Controllers.Library");
            baseAssemblies.Add(controllersAssembly);
            return baseAssemblies;

        }
    }
}