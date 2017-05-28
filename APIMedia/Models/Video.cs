using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIMedia.Models
{
    public enum FormatVideo
    {
        MP4,
        AVI,
        FLW
    }
    public class Video : Media
    {
        public FormatVideo Format { get; set; }
        public TimeSpan Duration { get; set; }
    }
}