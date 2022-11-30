namespace Catcheap.Views;

using Catcheap.Models.Calculator_Classes;
using Catcheap.Models.FileIO_Classes;
using Catcheap.Models.Validation_Classes;
using Catcheap.Models.Vehicles_Classes.Cars_Classes;
using Catcheap.Models.Price_Classes;
using System.Net.Http.Headers;
//using Android.Gms.Common.Apis;
using Catcheap.Client;
using Catcheap.Models.Exception_Classes;

public partial class JourneyCalculator : ContentPage
{
    private const string ENTER_A_POS_NUMBER = "Enter a positive number!";
    readonly ValidateInput<string> validateInput;
    readonly Calculator calc;

    public JourneyCalculator(Calculator calculator, ValidateInput<string> validateInput)
	{
        calc = calculator;
        this.validateInput = validateInput;
		InitializeComponent();
    }

    private void AddDistanceButtonClicked(object sender, EventArgs e)
    {
        string distanceText = DistanceEntry.Text;

        if (validateInput.ValidateInputNumber(distanceText) is not null)
        {
            DistanceEntry.Text = ENTER_A_POS_NUMBER;
            calc.Distance = -1;
        }
        else
        {
            try
            {
                calc.Distance = Convert.ToDouble(DistanceEntry.Text);
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                Navigation.PushAsync(new ExceptionPage());
            }
        }
            
    }

    private void AddConsumptionButtonClicked(object sender, EventArgs e)
    {
        string consumptionText = ConsumptionEntry.Text;

        if (!validateInput.ValidateInputPositiveNumber(consumptionText))
        {
            ConsumptionEntry.Text = ENTER_A_POS_NUMBER;
            calc.Consumption = -1;
        }
        else
        {
            try
            {
                calc.Consumption = Convert.ToDouble(ConsumptionEntry.Text);
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                Navigation.PushAsync(new ExceptionPage());
            }
        }
            
    }

    private void AddElectricityButtonClicked(object sender, EventArgs e)
    {
        string electricityPriceText = ElectricityPriceEntry.Text;

        if (!validateInput.ValidateInputPositiveNumber(electricityPriceText))
        {
            ElectricityPriceEntry.Text = ENTER_A_POS_NUMBER;
            calc.ElectricityPrice = -1;
        }
        else
        {
            try
            {
                calc.ElectricityPrice = Convert.ToDouble(ElectricityPriceEntry.Text);
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                Navigation.PushAsync(new ExceptionPage());
            }
        }
            
    }

    private void EntryDistanceTextChanged(object sender, TextChangedEventArgs e)
    {
        if (validateInput.ValidateInputNull(DistanceEntry.Text))
            AddDistanceButton.IsEnabled = false;
        else
            AddDistanceButton.IsEnabled = true;
    }

    private void EntryConsumptionTextChanged(object sender, TextChangedEventArgs e)
    {
        if (validateInput.ValidateInputNull(ConsumptionEntry.Text))
            AddConsumptionButton.IsEnabled = false;
        else
            AddConsumptionButton.IsEnabled = true;
    }

    private void EntryElectricityPriceTextChanged(object sender, TextChangedEventArgs e)
    {
        if (validateInput.ValidateInputNull(ElectricityPriceEntry.Text))
            AddElectricityPriceButton.IsEnabled = false;
        else
            AddElectricityPriceButton.IsEnabled = true;
    }

    private void CalculateTotalPriceButtonClicked(object sender, EventArgs e)
    {
        double totalPrice = calc.CalculatePrice();
        if (totalPrice != -1 && !string.IsNullOrEmpty(DistanceEntry.Text)
                             && !string.IsNullOrEmpty(ConsumptionEntry.Text)
                             && !string.IsNullOrEmpty(ElectricityPriceEntry.Text))
        { 
            CalcedValue.Text = totalPrice.ToString() + "€";
        }
        else
            CalcedValue.Text = "Invalid input!";
    }

    private async void CalculateFullChargePriceButtonClicked(object sender, EventArgs e)
    {
        Car car = Handler.MauiContext.Services.GetService<Car>();
        CarLoaderSaver carLoaderSaver = Handler.MauiContext.Services.GetService<CarLoaderSaver>();
        Price price = Handler.MauiContext.Services.GetService<Price>();

        await CarLoaderSaver.Load(car);

        //FullChargePrice.Text = calc.calculateFullChargePrice(car.BatteryCapacity, car.BatteryLevel, price.getCurrentPrice()).ToString() + "€";

        

            HttpResponseMessage response = await ApiClient.client.PutAsJsonAsync("api/Calculator", car);
            if (response.IsSuccessStatusCode)
            {
                FullChargePrice.Text = (await response.Content.ReadAsAsync<Double>()).ToString();
            }
            else
            {
                FullChargePrice.Text = response.ToString();
            }

    }
}

