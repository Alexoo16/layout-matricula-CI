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
    public class CoordinadorDA
    {
        public Coordinador LlenarEntidad(IDataReader reader)
        {
            Coordinador coordinador = new Coordinador();
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='id'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["id"]))
                    coordinador.Id = Convert.ToInt32(reader["id"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipoUsuario'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["tipoUsuario"]))
                    coordinador.TipoUsuario = Convert.ToInt32(reader["tipoUsuario"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nombre'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["nombre"]))
                    coordinador.Nombres = Convert.ToString(reader["nombre"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='apellidoPaterno'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["apellidoPaterno"]))
                    coordinador.ApellidoPat = Convert.ToString(reader["apellidoPaterno"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='apellidoMaterno'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["apellidoMaterno"]))
                    coordinador.ApellidoMat = Convert.ToString(reader["apellidoMaterno"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='dni'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["dni"]))
                    coordinador.Dni = Convert.ToString(reader["dni"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='edad'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["edad"]))
                    coordinador.Edad = Convert.ToInt32(reader["edad"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='email'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["email"]))
                    coordinador.Email = Convert.ToString(reader["email"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='contrasena'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["contrasena"]))
                    coordinador.Contrasena = (byte[])reader["contrasena"];
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='celular'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["celular"]))
                    coordinador.Celular = Convert.ToString(reader["celular"]);
            }

            return coordinador;
        }


        public Coordinador BuscarCoordinador(Usuario coordinador)
        {
            Coordinador entidad = null;

            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("buscarC", conexion))
                {
                    comando.Parameters.AddWithValue("@Dni", coordinador.Dni);
                    comando.Parameters.AddWithValue("@Contrasena", coordinador.Contrasena);
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            entidad = LlenarEntidad(reader);
                        }
                    }
                }
            }

            return entidad;
        }


    }
}