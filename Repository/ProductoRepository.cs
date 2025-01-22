using Microsoft.Data.Sqlite;

class ProductoRepository
{
    public void CrearProducto(Producto producto)
    {
        string connectionString = "Data Source=DB/Tienda.db;Cache=Shared";

        string querystring = "INSERT INTO Productos (Descripcion, Precio) VALUES (@Descripcion, @Precio)";

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(querystring, connection);
            command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
            command.Parameters.AddWithValue("@Precio", producto.Precio);
            command.ExecuteNonQuery();
            connection.Close();

        }
    }

    public void ModificarProducto(int id, Producto producto)
    {
        string connectionString = "Data Source=DB/Tienda.db;Cache=Shared";

        string querystring = "UPDATE Productos SET Descripcion=@Descripcion, Precio=@Precio WHERE idProducto=@Id";

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(querystring, connection);
            command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
            command.Parameters.AddWithValue("@Precio", producto.Precio);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
            connection.Close();

        }

    }

    public List<Producto> ListarProductos()
    {
        List<Producto> productos = new List<Producto>();
        string connectionString = "Data Source=DB/Tienda.db;Cache=Shared";
        string querystring = "SELECT * FROM Productos";

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(querystring, connection);

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Producto productoNuevo = new Producto();
                    productoNuevo.IdProducto = Convert.ToInt32(reader["idProducto"]);
                    productoNuevo.Descripcion = reader["Descripcion"].ToString();
                    productoNuevo.Precio = Convert.ToInt32(reader["Precio"]);
                    productos.Add(productoNuevo);
                }
            }
            connection.Close();
        }
        return productos;
    }

    public Producto ObtenerProducto(int id)
    {
        Producto producto = null;
        string connectionString = "Data Source=DB/Tienda.db;Cache=Shared";
        string querystring = "SELECT * FROM Productos WHERE idProducto = @id ";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(querystring, connection);
            command.Parameters.AddWithValue("@id", id);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if(reader.Read())
                {
                    producto= new Producto();
                    producto.Descripcion= reader["Descripcion"].ToString();
                    producto.Precio= Convert.ToInt32(reader["Precio"]);
                    producto.IdProducto= Convert.ToInt32(reader["idProducto"]);
                }
            }
            connection.Close();
        }
        return producto;
    }

    public void EliminarProducto(int id)
    {
        string connectionString = "Data Source=DB/Tienda.db;Cache=Shared";

        string querystring = "DELETE FROM Productos WHERE idProducto= @Id ";

         using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(querystring, connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}