using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todolist_LIPE.Behaviours;
using Todolist_LIPE.Data;
using Todolist_LIPE.Models;
using Todolist_LIPE.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Todolist_LIPE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyTasks : ContentPage
    {
        MyTaskViewModel MTVM => BindingContext as MyTaskViewModel;
        public MyTasks()
        {
            InitializeComponent();
           
        }

        protected async override void OnAppearing()
        {
            this.BindingContext = await MyTaskViewModel.CreateAsync(this.Navigation);
            base.OnAppearing();
        }

        private void collectionViewListHorizontal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count == 0)
            {
                return;
            }

            var item = (IEnumerable<object>)e.CurrentSelection;
            MTVM.NavigateComman.Execute(item);
           collectionViewListHorizontal.SelectedItem = null;
        }

    }
}