using System.ComponentModel.DataAnnotations;

namespace personinfor.Models
{
    public class socialPlatformsModels
    {
        [Key]
        public int platformid {get; set;}
        public string? platfoms {get; set;}
    }
}