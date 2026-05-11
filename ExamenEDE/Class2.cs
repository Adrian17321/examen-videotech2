using System;

public GestorBD()
{
MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder(); builder.Server = "localhost";
builder.UserID = "root"; 
    builder.Password = ""; 
    builder.Database = "EDE";

conexion = new MySqlConnection(builder.ToString());
}

public void Insertar(Pelicula p)
{
string query = "INSERT INTO pelicula (titulo, director, anyo, disponible) VALUES (@titulo, @director, @anyo, @disponible)";

conexion.Open();
MySqlCommand cmd = new MySqlCommand(query, conexion);

    cmd.Parameters.AddWithValue("@titulo", p.getTitulo());
cmd.Parameters.AddWithValue("@director", p.getDirector());
cmd.Parameters.AddWithValue("@anyo", p.getAnyo());
cmd.Parameters.AddWithValue("@disponible", p.isDisponible());

    cmd.Prepare();
cmd.ExecuteNonQuery(); 

conexion.Close(); 
}

public List<Pelicula> ObtenerTodos()
{
    List<Pelicula> listaBD = new List<Pelicula>();
    string query = "SELECT titulo, director, anyo, disponible FROM pelicula";

    conexion.Open(); 
    MySqlCommand cmd = new MySqlCommand(query, conexion);
    MySqlDataReader res = cmd.ExecuteReader();

   while (res.Read())
    {
        string titulo = res.GetString(0);
        string director = res.GetString(1);
        int anyo = res.GetInt32(2);
        bool disponible = res.GetBoolean(3);

        Pelicula p = new Pelicula(titulo, director, anyo, disponible);
        listaBD.Add(p);
    }

    res.Close(); 
    conexion.Close();

    return listaBD;

    {
    }
}
