Keep Web API controllers in a separate DLL for better testing and sharing among other projects.

To do so:

- create a custom resolver like so:

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
	
	
- register the resolver in httpconfig services like so:

config.Services.Replace(typeof(IAssembliesResolver), new CustomAssembliesResolver());