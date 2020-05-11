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
            this.BindingContext = new MyTaskViewModel(this.Navigation);

            MessagingCenter.Subscribe<MyTaskViewModel, Tasks>(
        this, "AddList", async (sender, arg) =>
        {
            collectionViewListHorizontal.ItemsSource = await MTVM.Init();
        });
        }

        ~MyTasks()
        {
        }

        protected async override void OnAppearing()
        {
            collectionViewListHorizontal.ItemsSource = await MTVM.Init();
            base.OnAppearing();
        }

        private async void BuyButton_Clicked(object sender, EventArgs e)
        {
            var b = (Button)sender;
            var item = (Tasks)b.CommandParameter;
            await DisplayAlert("Clicked",item.TaskName + "button was clicked", "OK");
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