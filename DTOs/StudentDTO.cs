public class StudentDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }  // Cambiato da int a string
    public string Email { get; set; }    // Cambiato da int a string
}

public class CreateStudentDTO
{
    public string Nome { get; set; }
    public string Cognome { get; set; }  // Cambiato da int a string
    public string Email { get; set; }    // Cambiato da int a string
}

public class UpdateStudentDTO
{
    public string Nome { get; set; }
    public string Cognome { get; set; }  // Cambiato da int a string
    public string Email { get; set; }    // Cambiato da int a string
}
