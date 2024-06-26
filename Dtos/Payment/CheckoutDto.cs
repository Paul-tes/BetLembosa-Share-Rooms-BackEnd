namespace BetLembosa_Share_Rooms_BackEnd;

public class CheckoutDto
{
  public required string HostName { get; set; }
  public required string HostPhoto { get; set; }
  public required string StartDate { get; set; }
  public required string EndDate { get; set; }
  public required string SuccessUrl { get; set; }
  public required string CancelUrl { get; set; }
  public required string HostId { get; set; }
  public decimal Price { get; set; }
}
