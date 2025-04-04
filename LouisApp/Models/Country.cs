
namespace LouisApp.Models
{
    public class Country
    {
        public string capital { get; set; }
        public string currency { get; set; }
        public string name { get; set; }
        public int population { get; set; }
        public Media media { get; set; }
    }

    public class Media
    {
        public string flag { get; set; }
    
    }

}