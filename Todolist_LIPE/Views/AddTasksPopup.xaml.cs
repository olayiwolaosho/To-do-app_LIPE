using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todolist_LIPE.Data;
using Todolist_LIPE.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Todolist_LIPE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTasksPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public AddTasksPopup()
        {
            InitializeComponent();
            BindingContext = new MyTaskViewModel(this.Navigation);
        }


    }
}