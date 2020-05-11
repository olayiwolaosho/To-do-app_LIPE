using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Todolist_LIPE.Models;
using Todolist_LIPE.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Todolist_LIPE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditMyTasks : ContentPage
    {
        EditTasksViewModel ETVM => BindingContext as EditTasksViewModel;
        public EditMyTasks(Tasks task)
        {
            InitializeComponent();

            BindingContext = new EditTasksViewModel(task);
        }

        protected override bool OnBackButtonPressed()
        {
            ETVM.BackbuttonCommand.Execute(this);
            return base.OnBackButtonPressed();

        }
    }
}