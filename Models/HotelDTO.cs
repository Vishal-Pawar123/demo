using HotelListing.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.Models
{
    public class UpdateHotelDTO
    {
        [Required]
        [StringLength(maximumLength: 150, ErrorMessage = "Name of Hotel is Too Long")]
        public string Name { get; set; }
        
        //[Required]
        //[StringLength(maximumLength:250, ErrorMessage = "Address is Too Long")]
        public string Address { get; set; }
        [Range(1,5)]
        public double Rating { get; set; }
        [Required]
        public int CountryId { get; set; }
    }

    public class UpdateDTO : UpdateHotelDTO
    { 
        
    }
    public class HotelDTO : UpdateHotelDTO
    {
        public int Id { get; set; }
        public CountryDTO Country { get; set; }
    }
}
