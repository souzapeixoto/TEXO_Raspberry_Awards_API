using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs
{
    public class DTOAwardsResponseGet
    {
        public List<IntervalAwards> Min { get; set; }
        public List<IntervalAwards> Max { get; set; }
    }

    public class IntervalAwards
    {
        public string producer { get; set; }
        public int Interval { get; set; }
        public int PreviousWin { get; set; }
        public int FollowingWin { get; set; }
    }

    
}
