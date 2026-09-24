using System.ComponentModel.DataAnnotations;

namespace MachineFleet.Client.Models;

public class AddMachineItem
{
    [Required(ErrorMessage = "Please enter a machine name.")]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters.")]
    [MaxLength(30, ErrorMessage = "Name can't be longer than 30 characters.")]
    public string Name { get; set; } = string.Empty;
}