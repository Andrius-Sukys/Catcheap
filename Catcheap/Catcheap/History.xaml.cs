namespace Catcheap;

public partial class History : ContentPage
{
    FileIO fileIO = new FileIO();
    public History()
	{
		InitializeComponent();

        ReloadHistory();
    }

    public void ReloadHistory()
    {
        Placeholder.Text = fileIO.ReadTextFile("history.txt");
    }

    public void ClearHistory()
    {
        Placeholder.Text = "";
        fileIO.ClearTextFile("history.txt");
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
