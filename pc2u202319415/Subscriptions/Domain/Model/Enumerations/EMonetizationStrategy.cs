namespace pc2u202319415.Subscriptions.Domain.Model.Enumerations;

/// <summary>
/// Enumeración para estrategias de monetización.
/// </summary>
/// <remarks>Raul Tasayco</remarks>
public enum EMonetizationStrategy
{
    MonthlySubscription = 1,
    YearlySubscription = 2,
    PerTransactionFee = 3,
    OneTimePurchase = 4
}