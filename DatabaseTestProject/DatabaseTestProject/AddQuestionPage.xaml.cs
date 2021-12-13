using DatabaseTestProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseTestProject.Data;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DatabaseTestProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddQuestionPage : ContentPage
    {
        public AddQuestionPage()
        {
            InitializeComponent();
        }

        private async void addQuestionButton_Clicked(object sender, EventArgs e)
        {
            string questionBody = questionBodyEntry.Text;
            await QuestionDatabase.AddQuestionAsync(questionBody);
        }
    }
}