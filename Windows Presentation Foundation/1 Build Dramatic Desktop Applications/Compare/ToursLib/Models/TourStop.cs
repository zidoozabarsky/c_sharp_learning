﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TailorMadeTours.Models {
public	class TourStop {
		public int StopNumber { get; set; }
		public string Name { get; set; }
		public string Latitude { get; set; }
		public string Longitude { get; set; }
		public string Description { get; set; }
		public string Phone { get; set; }
		public string ImageUri { get; set; }
		public List<BusyTime> BusyTimes { get; set; }
		public bool Selected { get; set; }
		public int EstimatedMinutes { get; set; }

	}
	public class BusyTime {
		public int Hour { get; set; }
		public int Rank { get; set; }

	}
}
