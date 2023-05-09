using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eaidyAPI.Entities;

public class User
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    [StringLength(30)]
    [Required(ErrorMessage = "Firstname is required.")]
    public string? Firstname { get; set; }

    [StringLength(30)]
    [Required(ErrorMessage = "Lastname is required.")]
    public string? Lastname { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Birthday is required.")]
    public string? Birthday { get; set; }

    [StringLength(30)]
    [Required(ErrorMessage = "Phone is required.")]
    public string? Phone { get; set; }

    [StringLength(30)]
    [Required(ErrorMessage = "Username is required.")]
    public string? Username { get; set; }

    [StringLength(30)]
    [Required(ErrorMessage = "Password is required.")]
    public string? Password { get; set; }
}

