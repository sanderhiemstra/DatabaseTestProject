using DatabaseTestProject.Data;
using DatabaseTestProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DatabaseTestProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionIndexPage : ContentPage
    {
        public QuestionIndexPage()
        {
            InitializeComponent();
            BindingContext = new Question();
            var questionCollection = await QuestionDatabase.GetQuestionsAsync();
            QuestionListView.ItemsSource = questionCollection;
        }

        
    }
}