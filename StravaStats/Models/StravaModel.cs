namespace StravaStats.Models
{
    public class AllRideTotals
    {
        public int count { get; set; }
        public int distance { get; set; }
        public int moving_time { get; set; }
        public int elapsed_time { get; set; }
        public int elevation_gain { get; set; }
    }

    public class AllRunTotals
    {
        public int count { get; set; }
        public int distance { get; set; }
        public int moving_time { get; set; }
        public int elapsed_time { get; set; }
        public int elevation_gain { get; set; }
    }

    public class AllSwimTotals
    {
        public int count { get; set; }
        public int distance { get; set; }
        public int moving_time { get; set; }
        public int elapsed_time { get; set; }
        public int elevation_gain { get; set; }
    }

    public class RecentRideTotals
    {
        public int count { get; set; }
        public double distance { get; set; }
        public int moving_time { get; set; }
        public int elapsed_time { get; set; }
        public double elevation_gain { get; set; }
        public int achievement_count { get; set; }
    }

    public class RecentRunTotals
    {
        public int count { get; set; }
        public double distance { get; set; }
        public int moving_time { get; set; }
        public int elapsed_time { get; set; }
        public double elevation_gain { get; set; }
        public int achievement_count { get; set; }
    }

    public class RecentSwimTotals
    {
        public int count { get; set; }
        public double distance { get; set; }
        public int moving_time { get; set; }
        public int elapsed_time { get; set; }
        public double elevation_gain { get; set; }
        public int achievement_count { get; set; }
    }

    public class StravaModel
    {
        public double biggest_ride_distance { get; set; }
        public object biggest_climb_elevation_gain { get; set; }
        public RecentRideTotals recent_ride_totals { get; set; }
        public AllRideTotals all_ride_totals { get; set; }
        public RecentRunTotals recent_run_totals { get; set; }
        public AllRunTotals all_run_totals { get; set; }
        public RecentSwimTotals recent_swim_totals { get; set; }
        public AllSwimTotals all_swim_totals { get; set; }
        public YtdRideTotals ytd_ride_totals { get; set; }
        public YtdRunTotals ytd_run_totals { get; set; }
        public YtdSwimTotals ytd_swim_totals { get; set; }
    }

    public class YtdRideTotals
    {
        public int count { get; set; }
        public int distance { get; set; }
        public int moving_time { get; set; }
        public int elapsed_time { get; set; }
        public int elevation_gain { get; set; }
    }

    public class YtdRunTotals
    {
        public int count { get; set; }
        public int distance { get; set; }
        public int moving_time { get; set; }
        public int elapsed_time { get; set; }
        public int elevation_gain { get; set; }
    }

    public class YtdSwimTotals
    {
        public int count { get; set; }
        public int distance { get; set; }
        public int moving_time { get; set; }
        public int elapsed_time { get; set; }
        public int elevation_gain { get; set; }
    }


}
