using System;
using System.Collections.Generic;
#if !CONSOLE_APP
using System.ComponentModel.DataAnnotations.Schema;
#endif
using System.Linq;
using System.Web;

namespace APIMedia.Models
{
#if !CONSOLE_APP
    [ComplexType]
#endif
    public class Size
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
    public class Media
    {
        public int Id { get; set; }
        public Size Size { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}