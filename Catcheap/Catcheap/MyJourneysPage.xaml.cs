namespace Catcheap;

public partial class MyJourneysPage : ContentPage
{
    FileIO fileIO = new FileIO();
    public MyJourneysPage()
	{
		InitializeComponent();

        ReloadHistory();
    }

    public void ReloadHistory()
    {
        Placeholder.Text = fileIO.ReadTextFile("journeys.txt");
    }

    public void ClearHistory()
    {
        Placeholder.Text = "";
        fileIO.ClearTextFile("journeys.txt");
    }

    private void ClickedReloadHistory(object sender, EventArgs e)
    {
        ReloadHistory();
    }

    private void ClickedClearHistory(object sender, EventArgs e)
    {
        ClearHistory();
        ReloadHistory();
    }
}
