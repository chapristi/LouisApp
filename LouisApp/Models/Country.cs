
namespace LouisApp.Models
{
    public class Country
    {
        public string abbreviation { get; set; }
        public string capital { get; set; }
        public string currency { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public int population { get; set; }
        public Media media { get; set; }
        public int id { get; set; }
    }

    public class Media
    {
        public string flag { get; set; }
        public string emblem { get; set; }
        public string orthographic { get; set; }
    }

}