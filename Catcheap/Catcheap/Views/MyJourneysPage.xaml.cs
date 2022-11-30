using Catcheap.Models.FileIO_Classes;

namespace Catcheap.Views;

public partial class MyJourneysPage : ContentPage
{
    FileIO fileIO;
    public MyJourneysPage(FileIO fileIO)
	{
        this.fileIO = fileIO;

		InitializeComponent();

        ReloadHistory();
    }

    public void ReloadHistory()
    {
        Placeholder.Text = FileIO.ReadTextFile("journeys.txt");
    }

    public void ClearHistory()
    {
        Placeholder.Text = "";
        FileIO.ClearTextFile("journeys.txt");
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
