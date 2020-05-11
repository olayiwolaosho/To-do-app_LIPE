using SimpleInjector;
using System;
using Todolist_LIPE.Data;
using Todolist_LIPE.Data.Base;
using Todolist_LIPE.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Todolist_LIPE
{
    public partial class App : Application
    {
        private static Container ioCContainer = new SimpleInjector.Container();
        public static Container IoCContainer
        {
            get => ioCContainer;
            set => ioCContainer = value;
        }

        static DatabaseRepo databaserepo;

        public static DatabaseRepo Databaserepo
        {
            get
            {
                if (databaserepo == null)
                {
                    databaserepo = new DatabaseRepo();
                }
                return databaserepo;
            }
        }
        public App()
        {
            InitializeComponent();
            //   App.IoCContainer.Register<IDatabaseRepo, DatabaseRepo>(Lifestyle.Transient);
            //  MainPage = new MainPage();
          //  database = DependencyService.Get<IDatabase>().DBConnection();
            MainPage = new NavigationPage(new MyTasks());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
