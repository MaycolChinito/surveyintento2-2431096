using System.Collections.ObjectModel;
using surveyintento2.Data;
using surveyintento2.Models;

namespace surveyintento2.View;

public partial class PartesqlDetailsPage : ContentPage
{
    Database basededatos;
    public ObservableCollection<Survey> Items { get; set; } = new();
	public PartesqlDetailsPage(Database database)
	{
		InitializeComponent();
        basededatos = database;
        BindingContext = this;
	}

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        var surveys = await basededatos.GetSurveysAsync();
        MainThread.BeginInvokeOnMainThread(() => 
        {
            Items.Clear();
            foreach (var item in surveys)
                Items.Add(item);
        });
    }
    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Survey survey)
            return;

        await Shell.Current.GoToAsync(nameof(partesqlPage), true, new Dictionary<string, object>
        {
            ["Survey"] = survey
        });
    }

    private async void OnItemAdded(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(partesqlPage), true, new Dictionary<string, object>
        {
            ["Survey"] = new Survey()
        }); 
    }
}