using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Todolist_LIPE.Models;
using Todolist_LIPE.ViewModels.Base;
using Xamarin.Forms;

namespace Todolist_LIPE.ViewModels
{
    class EditTasksViewModel : BaseViewModel
    {
        private Tasks _tasks;
      
        public Tasks Tasks => _tasks ?? (_tasks = new Tasks());

        public EditTasksViewModel(Tasks Tasks)
        {
            this._tasks = Tasks;
        }

        public ICommand BackbuttonCommand => new Command(() =>
        {
            MessagingCenter.Send(this, "UpdateList", Tasks);
        });
    }
}
