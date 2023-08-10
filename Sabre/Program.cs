/*
     Implement date consolidation. Application should take as input a list of unsorted date ranges and 
    produce consolidated list of ranges as an output. 
The condition for date consolidation take place when two consecutive ranges overlap or one date range is right after second date range. Presented solution should be testable.
     * INPUT :
01.01.2024 - 10.01.2024
05.01.2024 - 15.01.2024
19.01.2024 - 20.01.2024
02.01.2024 - 05.01.2024
22.01.2024 - 22.01.2024
17.01.2024 - 18.01.2024

    OUTPUT:
01.01.2024 - 15.01.2024
17.01.2024 - 20.01.2024
22.01.2024 - 22.01.2024
     */
using System;
using System.Collections.Generic;

public class DateRange
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public DateRange(DateTime start, DateTime end)
    {
        StartDate = start;
        EndDate = end;
    }

    public bool Overlaps(DateRange other)
    {
        return StartDate <= other.EndDate && other.StartDate <= EndDate;
    }

    public DateRange Merge(DateRange other)
    {
        return new DateRange(
            DateTime.Compare(StartDate, other.StartDate) < 0 ? StartDate : other.StartDate,
            DateTime.Compare(EndDate, other.EndDate) > 0 ? EndDate : other.EndDate
        );
    }

    public override string ToString()
    {
        return $"{StartDate:dd.MM.yyyy} - {EndDate:dd.MM.yyyy}";
    }
}

public class Utility
{
    public static List<DateRange> ConsolidateDateRanges(List<DateRange> ranges)
    {
        if (ranges.Count <= 1)
            return ranges;

        ranges.Sort((a, b) => a.StartDate.CompareTo(b.StartDate));

        List<DateRange> consolidated = new List<DateRange> { ranges[0] };

        for (int i = 1; i < ranges.Count; i++)
        {
            DateRange current = ranges[i];
            DateRange lastConsolidated = consolidated[consolidated.Count - 1];

            if (lastConsolidated.Overlaps(current) || lastConsolidated.EndDate.AddDays(1) == current.StartDate)
            {
                consolidated.RemoveAt(consolidated.Count - 1);
                consolidated.Add(lastConsolidated.Merge(current));
            }
            else
            {
                consolidated.Add(current);
            }
        }

        return consolidated;
    }
}

public class Program
{
    static void Main()
    {
        List<DateRange> inputRanges = new List<DateRange>
        {
            new(new DateTime(2024, 1, 1), new DateTime(2024, 1, 10)),
            new(new DateTime(2024, 1, 5), new DateTime(2024, 1, 15)),
            new(new DateTime(2024, 1, 19), new DateTime(2024, 1, 20)),
            new(new DateTime(2024, 1, 2), new DateTime(2024, 1, 5)),
            new(new DateTime(2024, 1, 22), new DateTime(2024, 1, 22)),
            new(new DateTime(2024, 1, 17), new DateTime(2024, 1, 18))
        };

        List<DateRange> consolidatedRanges = Utility.ConsolidateDateRanges(inputRanges);

        foreach (DateRange range in consolidatedRanges)
        {
            Console.WriteLine(range);
        }
    }
}
