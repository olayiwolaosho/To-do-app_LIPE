using Rg.Plugins.Popup.Extensions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Todolist_LIPE.Data;
using Todolist_LIPE.Models;
using Todolist_LIPE.ViewModels.Base;
using Todolist_LIPE.Views;
using Xamarin.Forms;

namespace Todolist_LIPE.ViewModels
{
    public class MyTaskViewModel : BaseViewModel
    {
        private INavigation navigation;

       // private IDatabaseRepo database;
        public MyTaskViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            IsNotBusy = true;
           
            MessagingCenter.Subscribe<EditTasksViewModel, Tasks>(
            this, "UpdateList", async(sender, arg) =>
            {
                await App.Databaserepo.SaveObject(arg);
                //var index = _tasks.IndexOf(_tasks.First(a => a.ID == arg.ID));
                //_tasks.RemoveAt(index);
                //_tasks.Insert(index, arg);
            }); 
            

        }

        private Tasks _newtask;
        public Tasks Newtask => _newtask ?? (_newtask = new Tasks());

        private string _todoitem;
        public string Todoitem
        {
            get => _todoitem;
            set => SetProperty(ref _todoitem, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private ObservableCollection<Tasks> _tasks;
        public ObservableCollection<Tasks> MyTasks
        {
            get => _tasks;
            set => SetProperty(ref _tasks, value);
        }

        public async Task<ObservableCollection<Tasks>> Init()
        {
            var users = await App.Databaserepo.GetAllObjects<Tasks>();
            MyTasks =  new ObservableCollection<Tasks>(users);
            return MyTasks;
        }

        public ICommand addtaskCommand => new Command(async() =>
        {
            IsNotBusy = false;
            Tasks tasks = new Tasks
            {
                TaskName = Todoitem,
                TaskDetail = Description ?? default,
                Delete = false
            };
            int success = await App.Databaserepo.SaveObject(tasks);
            if(success != default)
            {
               
                await navigation.PopPopupAsync();
                MessagingCenter.Send(this, "AddList", tasks);
            }
           // MyTasks.Add(tasks);
            IsNotBusy = true;
            
        }); 
        
        public ICommand NavigateComman => new Command(async(task) =>
        {

            var item = (IEnumerable<object>)task;
            var obj = item.Cast<Tasks>().ToList();
            
            await navigation.PushAsync(new EditMyTasks(obj.First())); 
        }); 
        
        public ICommand openPopupCommand => new Command(async() =>
        {

            await navigation.PushPopupAsync(new AddTasksPopup());
        });

        

        public async Task NavigateCommand(object task)
        {
            var item = (IEnumerable<object>)task;
            var obj = item.Cast<Tasks>().ToList();

           await navigation.PushAsync(new EditMyTasks(obj.First()));
        } 
        
        public ICommand DeleteCommand => new Command(async(task) =>
        {
            var obj = (Tasks)task;
            MyTasks.Remove(obj);
            await App.Databaserepo.DeleteObject(obj);
        }); 
        
        public ICommand CompleteCommand => new Command((task) =>
        {
            MyTasks.Remove((Tasks)task);
        });


        public ICommand RefreshCommand
        {
            get => new Command(async() =>
            {
                IsRefreshing = true;

                MyTasks = new ObservableCollection<Tasks>(await App.Databaserepo.GetAllObjects<Tasks>());

                IsRefreshing = false;
            });

        }


    }
}
