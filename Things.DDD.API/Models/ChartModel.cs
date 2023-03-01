using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Things.DDD.API.Models
{
    public class ChartModel
    {
        public List<int> Data { get; set; }
        public string? Label { get; set; }
        public string? BackgroundColor { get; set; }

        public ChartModel()
        {
            Data = new List<int>();
        }
    }
}
