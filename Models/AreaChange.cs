﻿namespace Karverket.Models
{
    public class AreaChange 
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Fylke { get; set; }
        public string GeoJson { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; } = "Pending";
    }


}