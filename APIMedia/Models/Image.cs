using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIMedia.Models
{
    public enum FormatImage
    {
        BMP,
        JPG,
        PNG
    }
    public class Image : Media
    {
        public FormatImage Format { get; set; }
    }
}