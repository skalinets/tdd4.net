using FubuMVC.Core;
using FubuMVC.Core.Diagnostics;
using FubuMVC.Core.Registration.Conventions;
using FubuMVC.Core.Registration.Nodes;
using FubuMVC.Core.Registration.Routes;
using FubuMVC.Razor;
using Tdd4.net.Features;
using Tdd4.net.Features.Home;

namespace Tdd4.net
{
    public class ConfigureFubuMVC : FubuRegistry
    {
        public ConfigureFubuMVC()
        {
            // This line turns on the basic diagnostics and request tracing
            // todo: fix this
//            IncludeDiagnostics(true);

            // All public methods from concrete classes ending in "Controller"
            // in this assembly are assumed to be action methods
            Actions.IncludeClassesSuffixedWithController();

            // Policies
            Routes
                .IgnoreControllerNamesEntirely()
                .IgnoreMethodSuffix("Html")
//                .HomeIs<FooController>(x => x.hello())
                .HomeIs<HomeController>(x => x.Items(new PostFilter()))
                .RootAtAssemblyNamespace();
            
//            Import<RazorEngineRegistry>();
//            Assets.Alias("bootstrap").Is("bootstrap-min.js");
    
//            Asset.YSOD_on_missing_assets(true);

            // Match views to action methods by matching
            // on model type, view name, and namespace
        }
    }

    public class FooController
    {
        public string hello()
        {
            return "hello mother fucker";
        }
    }
}