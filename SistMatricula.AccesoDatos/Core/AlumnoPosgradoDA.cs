using SistMatricula.Entidades.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistMatricula.AccesoDatos.Core
{
    public class AlumnoPosgradoDA
    {


        public AlumnoPosgrado LlenarEntidad(IDataReader reader)
        {
            AlumnoPosgrado alumnoPosgrado = new AlumnoPosgrado();

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='id'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["id"]))
                    alumnoPosgrado.Id = Convert.ToInt32(reader["id"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipoUsuario'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["tipoUsuario"]))
                    alumnoPosgrado.TipoUsuario = Convert.ToInt32(reader["tipoUsuario"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nombre'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["nombre"]))
                    alumnoPosgrado.Nombres = Convert.ToString(reader["nombre"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='apellidoPaterno'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["apellidoPaterno"]))
                    alumnoPosgrado.ApellidoPat = Convert.ToString(reader["apellidoPaterno"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='apellidoMaterno'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["apellidoMaterno"]))
                    alumnoPosgrado.ApellidoMat = Convert.ToString(reader["apellidoMaterno"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='dni'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["dni"]))
                    alumnoPosgrado.Dni = Convert.ToString(reader["dni"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='edad'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["edad"]))
                    alumnoPosgrado.Edad = Convert.ToInt32(reader["edad"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='email'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["email"]))
                    alumnoPosgrado.Email = Convert.ToString(reader["email"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='contrasena'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["contrasena"]))
                    alumnoPosgrado.Contrasena = (byte[])reader["contrasena"];
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='celular'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["celular"]))
                    alumnoPosgrado.Celular = Convert.ToString(reader["celular"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='facultad'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["facultad"]))
                    alumnoPosgrado.facultad = Convert.ToString(reader["facultad"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='profesion'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["profesion"]))
                    alumnoPosgrado.profesion = Convert.ToString(reader["profesion"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='grado'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["grado"]))
                    alumnoPosgrado.grado = Convert.ToString(reader["grado"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='egresadoLocal'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["egresadoLocal"]))
                    alumnoPosgrado.egresadoLocal = Convert.ToBoolean(reader["egresadoLocal"]);
            }
            return alumnoPosgrado;
        }


        public AlumnoPosgrado BuscarAlumnoPosgrado(Usuario alumnoPosgrado)
        {
            AlumnoPosgrado entidad = null;
            using (SqlConnection conexion = new
            SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("buscarAlumnoPosgrado", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@dni", alumnoPosgrado.Dni);
                    comando.Parameters.AddWithValue("@contrasena", alumnoPosgrado.Contrasena);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = LlenarEntidad(reader);
                    }
                }
                conexion.Close();
            }
            return entidad;
        }


    }
}