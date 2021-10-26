using Datos.Server;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public static class AdmAuto
    {
        public static List<Auto> Listar()
        {
            string consulta = "SELECT Id,Marca,Modelo,Matricula,Precio FROM dbo.Auto";

            SqlCommand comando = new SqlCommand(consulta, AdminDB.ConectarBase());
            SqlDataReader reader;

            reader = comando.ExecuteReader();


            List<Auto> lista = new List<Auto>();

            while (reader.Read())
            {
                lista.Add(
                    new Auto(
                        reader["Marca"].ToString(),
                        reader["Modelo"].ToString(),
                        reader["Matricula"].ToString(),
                        Convert.ToDecimal(reader["Precio"]),
                        Convert.ToInt32(reader["Id"])
                        ));
            }
            AdminDB.ConectarBase().Close();
            return lista;
        }

        public static DataTable ListarSoloMarcas()
        {
            string consultaSQL = "SELECT DISTINCT Marca FROM dbo.Auto";

            SqlConnection conexion = AdminDB.ConectarBase();

            SqlDataAdapter adapter = new SqlDataAdapter(consultaSQL, conexion);

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Marca");

            AdminDB.ConectarBase().Close();
            return ds.Tables["Marca"];
        }

        public static DataTable Listar(string marca)
        {
            string consultaSQL = "SELECT Id,Marca,Modelo,Matricula,Precio FROM dbo.Auto WHERE Marca = @Marca";

            SqlConnection conexion = AdminDB.ConectarBase();

            SqlDataAdapter adapter = new SqlDataAdapter(consultaSQL, conexion);


            adapter.SelectCommand.Parameters.Add("@Marca", SqlDbType.VarChar,50).Value = marca;

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Marca");

            AdminDB.ConectarBase().Close();
            return ds.Tables["Marca"];
        }

        public static int Insertar(Auto auto)
        {
            string consulta = "INSERT INTO dbo.Auto (Marca,Modelo,Matricula,Precio) VALUES(@Marca,@Modelo,@Matricula,@Precio)";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, AdminDB.ConectarBase());


            adapter.SelectCommand.Parameters.Add("@Marca", SqlDbType.VarChar, 50).Value = auto.Marca;
            adapter.SelectCommand.Parameters.Add("@Modelo", SqlDbType.VarChar, 50).Value = auto.Modelo;
            adapter.SelectCommand.Parameters.Add("@Matricula", SqlDbType.Char,6).Value = auto.Matricula;
            adapter.SelectCommand.Parameters.Add("@Precio", SqlDbType.Decimal).Value = auto.Precio;

            int filasAfectadas = adapter.SelectCommand.ExecuteNonQuery();

            AdminDB.ConectarBase().Close();
            return filasAfectadas;
        }

        public static int Modificar(Auto auto)
        {
            string consulta = "UPDATE dbo.Auto SET Marca = @Marca,Modelo = @Modelo,Matricula = @Matricula, Precio = @Precio WHERE Id = @Id";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, AdminDB.ConectarBase());


            adapter.SelectCommand.Parameters.Add("@Marca", SqlDbType.VarChar, 50).Value = auto.Marca;
            adapter.SelectCommand.Parameters.Add("@Modelo", SqlDbType.VarChar, 50).Value = auto.Modelo;
            adapter.SelectCommand.Parameters.Add("@Matricula", SqlDbType.Char, 6).Value = auto.Matricula;
            adapter.SelectCommand.Parameters.Add("@Precio", SqlDbType.Decimal).Value = auto.Precio;
            adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = auto.Id;
            int filasAfectadas = adapter.SelectCommand.ExecuteNonQuery();

            AdminDB.ConectarBase().Close();
            return filasAfectadas;
        }

        public static int Eliminar(int id)
        {
            string consulta = "DELETE FROM dbo.Auto WHERE Id = @Id";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, AdminDB.ConectarBase());

            adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            int filasAfectadas = adapter.SelectCommand.ExecuteNonQuery();

            AdminDB.ConectarBase().Close();
            return filasAfectadas;
        }
    }
}
