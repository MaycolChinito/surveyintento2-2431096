
using surveyintento2.Data;
using surveyintento2.Models;


namespace surveyintento2.View;

[QueryProperty("Survey", "Survey")]
public partial class partesqlPage : ContentPage
{
    Survey surveyy;
    public Survey survey
    {
        get => BindingContext as Survey;
        set => BindingContext = value;
    }
    Database basededatos;

	public partesqlPage(Database database)
	{
		InitializeComponent();
        basededatos = database;
	}

     async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(survey?.Name))
        {
            await DisplayAlert("Name required", "Please enter a name for the todo survey", "ok");
            return;
        }

        await basededatos.SaveSurveysAsync(survey);
        await Shell.Current.GoToAsync("...");
    }

     async void OnDelete_Clicked(object sender, EventArgs e)
    { 
        if (survey?.ID == 0)
        
            return;
            await basededatos.DeleteSurveyAsync(survey);
            await Shell.Current.GoToAsync("..");
        }
    

     async void OnCancel_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
