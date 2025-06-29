namespace Bookify.Domain.Bookings;
public sealed record DateRange
{
    public DateOnly Start { get; init; }
    public DateOnly End { get; init; }

    public int LengthInDays => End.DayNumber - Start.DayNumber;

    public static DateRange Create(DateOnly start, DateOnly end)
    {
        if(start > end)
        {
            throw new ApplicationException("Start date cannot be after end date.");
        }
    
        return new DateRange
        {
            Start = start,
            End = end
        };

    }

}
