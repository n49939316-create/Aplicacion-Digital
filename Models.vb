public class Colegio
{
    public int ID { get; set; }
    public string NombreColegio { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
}

public class Estudiante
{
    public int ID { get; set; }
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public int ColegioID { get; set; }
    public string ProfesorConsejero { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class Trimestre
{
    public int ID { get; set; }
    public int EstudianteID { get; set; }
    public int Año { get; set; }
    public int Trimestre { get; set; }
    public string Materia { get; set; }
    public decimal Nota { get; set; }
    public int Creditos { get; set; }
}

public class Documento
{
    public int ID { get; set; }
    public int EstudianteID { get; set; }
    public string TipoDocumento { get; set; }
    public string RutaArchivo { get; set; }
    public string TextoOCR { get; set; }
    public DateTime FechaEscaneo { get; set; }
}