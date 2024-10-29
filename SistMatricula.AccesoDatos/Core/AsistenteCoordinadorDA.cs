using SistMatricula.Entidades.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistMatricula.AccesoDatos.Core
{
    public class AsistenteCoordinadorDA
    {
        public AsistenteCoordinacion LlenarEntidad(IDataReader reader)
        {
            AsistenteCoordinacion asistenteC = new AsistenteCoordinacion();


            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='id'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["id"]))
                    asistenteC.Id = Convert.ToInt32(reader["id"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipoUsuario'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["tipoUsuario"]))
                    asistenteC.TipoUsuario = Convert.ToInt32(reader["tipoUsuario"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nombre'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["nombre"]))
                    asistenteC.Nombres = Convert.ToString(reader["nombre"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='apellidoPaterno'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["apellidoPaterno"]))
                    asistenteC.ApellidoPat = Convert.ToString(reader["apellidoPaterno"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='apellidoMaterno'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["apellidoMaterno"]))
                    asistenteC.ApellidoMat = Convert.ToString(reader["apellidoMaterno"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='dni'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["dni"]))
                    asistenteC.Dni = Convert.ToString(reader["dni"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='edad'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["edad"]))
                    asistenteC.Edad = Convert.ToInt32(reader["edad"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='email'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["email"]))
                    asistenteC.Email = Convert.ToString(reader["email"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='contrasena'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["contrasena"]))
                    asistenteC.Contrasena = (byte[])reader["contrasena"];
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='celular'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["celular"]))
                    asistenteC.Celular = Convert.ToString(reader["celular"]);
            }

            return asistenteC;
        }


        public AsistenteCoordinacion BuscarAsistenteCoordinador(Usuario asistenteCoordinacion)
        {
            AsistenteCoordinacion entidad = null;

            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("buscarAC", conexion))
                {
                    comando.Parameters.AddWithValue("@dni", asistenteCoordinacion.Dni);
                    comando.Parameters.AddWithValue("@contrasena", asistenteCoordinacion.Contrasena);
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