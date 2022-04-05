using KursBusinssLogic.BusinessLogics;
using KursContracts.BusinessLogicInterfases;
using KursContracts.StorageContracts;
using KursModels.Implements;
using Unity;
using Unity.Lifetime;

namespace KursovaaRab
{
    class Programm
    {
        private static IUnityContainer container = null;

        public static IUnityContainer Container { get { if (container == null) { container = BuildUnityContainer(); } return container; } }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IClassStorage, ClassStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMaterialStorage, MaterialStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ITaskStorage, TaskStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ITeacherStorage, TeacherStorage>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<IClassLogic, ClassLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMaterialLogic, MaterialLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ITaskLogic, TaskLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ITeacherLogic, TeacherLogic>(new HierarchicalLifetimeManager());


            return currentContainer;
        }

        //static void Main()
        //{
        //    App app = new App();
        //    app.InitializeComponent();
        //    app.Run(Container.Resolve<Avtorizazia>());
        //}
    }
}
