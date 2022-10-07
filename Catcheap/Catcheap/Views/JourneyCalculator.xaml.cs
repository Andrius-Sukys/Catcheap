namespace Catcheap.Views;

public partial class JourneyCalculator : ContentPage
{
    private const string ENTER_A_POS_NUMBER = "Enter a positive number!";

    ValidateInput validateInput = new ValidateInput();

    Calculator calc = new Calculator();

    FileIO fileIO = new FileIO();

    public JourneyCalculator()
	{
		InitializeComponent();
    }

    private void AddDistanceButtonClicked(object sender, EventArgs e)
    {
        string distanceText = DistanceEntry.Text;

        if (!validateInput.ValidateInputAsAPositiveNumber(distanceText))
        {
            DistanceEntry.Text = ENTER_A_POS_NUMBER;
            calc.distance = -1;
        }
        else
            calc.distance = Convert.ToDouble(DistanceEntry.Text);
    }

    private void AddConsumptionButtonClicked(object sender, EventArgs e)
    {
        string consumptionText = ConsumptionEntry.Text;

        if (!validateInput.ValidateInputAsAPositiveNumber(consumptionText))
        {
            ConsumptionEntry.Text = ENTER_A_POS_NUMBER;
            calc.consumption = -1;
        }
        else
            calc.consumption = Convert.ToDouble(ConsumptionEntry.Text);
    }

    private void AddElectricityButtonClicked(object sender, EventArgs e)
    {
        string electricityPriceText = ElectricityPriceEntry.Text;

        if (!validateInput.ValidateInputAsAPositiveNumber(electricityPriceText))
        {
            ElectricityPriceEntry.Text = ENTER_A_POS_NUMBER;
            calc.electricityPrice = -1;
        }
        else
            calc.electricityPrice = Convert.ToDouble(ElectricityPriceEntry.Text);
    }

    private void EntryDistanceTextChanged(object sender, TextChangedEventArgs e)
    {
        if (validateInput.ValidateInputAsNull(DistanceEntry.Text))
            AddDistanceButton.IsEnabled = false;
        else
            AddDistanceButton.IsEnabled = true;
    }

    private void EntryConsumptionTextChanged(object sender, TextChangedEventArgs e)
    {
        if (validateInput.ValidateInputAsNull(ConsumptionEntry.Text))
            AddConsumptionButton.IsEnabled = false;
        else
            AddConsumptionButton.IsEnabled = true;
    }

    private void EntryElectricityPriceTextChanged(object sender, TextChangedEventArgs e)
    {
        if (validateInput.ValidateInputAsNull(ElectricityPriceEntry.Text))
            AddElectricityPriceButton.IsEnabled = false;
        else
            AddElectricityPriceButton.IsEnabled = true;
    }

    private void CalculateTotalPriceButtonClicked(object sender, EventArgs e)
    {
        double totalPrice = calc.calculatePrice();
        if (totalPrice != -1 && !String.IsNullOrEmpty(DistanceEntry.Text)
                             && !String.IsNullOrEmpty(ConsumptionEntry.Text)
                             && !String.IsNullOrEmpty(ElectricityPriceEntry.Text))
        { 
            CalcedValue.Text = totalPrice.ToString() + "€";
        }
        else
            CalcedValue.Text = "Invalid input!";
    }
}

