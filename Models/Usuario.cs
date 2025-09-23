using System.ComponentModel.DataAnnotations;

public class Usuario
{
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    public string Apellido { get; set; } = string.Empty;

    [Required]
    public string Avatar { get; set; } = string.Empty; // Ruta o nombre del archivo

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Clave { get; set; } = string.Empty; // Hasheada preferentemente

    [Required]
    public string Rol { get; set; }  // Ej: "Admin", "Usuario", etc.
}