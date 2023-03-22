//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZeroHunger.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^[+][8][8][0][1][3-9]{1}[0-9]*$",ErrorMessage ="Phone number should be like +8801*********")]
        [StringLength(14)]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8}$", ErrorMessage = "Password must contain one uppercase,lowercase,digit and Specialchar")]
        public string Password { get; set; }
        [Required]
        public string Type { get; set; }
        public string ResturantId { get; set; }
        public string RiderId { get; set; }
    }
}