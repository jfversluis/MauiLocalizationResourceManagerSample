using LocalizationResourceManager.Maui;

namespace MauiLocalizationResourceManagerSample;

public partial class MainPage : ContentPage
{
	int count = 0;
	ILocalizationResourceManager _localizationResourceManager;
	LocalizedString _counterClicked;

	public MainPage(ILocalizationResourceManager localizationResourceManager)
	{
		InitializeComponent();
        _localizationResourceManager = localizationResourceManager;
		_counterClicked = new(() => _localizationResourceManager["CounterClicked"]);
    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
		if (_localizationResourceManager.CurrentCulture.TwoLetterISOLanguageName == "nl")
			_localizationResourceManager.CurrentCulture = new System.Globalization.CultureInfo("en");
		else
			_localizationResourceManager.CurrentCulture = new System.Globalization.CultureInfo("nl");

        count++;

		CounterBtn.Text = string.Format(_counterClicked.Localized, count);

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

