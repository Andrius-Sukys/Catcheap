public static class ExpectedRangeExtensionMethod
{
    public static double AdjustExpectedRange(this double Range, double TopSpeed, double Weight,
                                                                 double WeightCapacity, double WeightRider, double AverageSpeed)
    {
        double temp = Range;
        try
        {
            if (AverageSpeed / TopSpeed > 1)
                Range += Range - (Range * AverageSpeed / TopSpeed);
        }
        catch (DivideByZeroException ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.ToString());
        }

        if (WeightCapacity > 0)
        {
            if ((Weight + WeightRider) / WeightCapacity > 1)
                Range += Range - (Range * (Weight + WeightRider) / (WeightCapacity));
        }
        else return 0;

        if (Range >= 0)
            return Range;
        else return 0;
    }

}