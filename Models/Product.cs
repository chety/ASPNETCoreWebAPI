using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public record Product(
        int Id,
        [Required]
        string Name,
        
        [Range(0.01,99999.99)]
        decimal Price
        );

}