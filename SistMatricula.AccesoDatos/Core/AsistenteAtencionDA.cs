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
    public class AsistenteAtencionDA
    {
        public AsistenteAtencionPublico LlenarEntidad(IDataReader reader)
        {
            AsistenteAtencionPublico asistenteAP = new AsistenteAtencionPublico();


            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='id'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["id"]))
                    asistenteAP.Id = Convert.ToInt32(reader["id"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipoUsuario'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["tipoUsuario"]))
                    asistenteAP.TipoUsuario = Convert.ToInt32(reader["tipoUsuario"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nombre'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["nombre"]))
                    asistenteAP.Nombres = Convert.ToString(reader["nombre"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='apellidoPaterno'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["apellidoPaterno"]))
                    asistenteAP.ApellidoPat = Convert.ToString(reader["apellidoPaterno"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='apellidoMaterno'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["apellidoMaterno"]))
                    asistenteAP.ApellidoMat = Convert.ToString(reader["apellidoMaterno"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='dni'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["dni"]))
                    asistenteAP.Dni = Convert.ToString(reader["dni"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='edad'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["edad"]))
                    asistenteAP.Edad = Convert.ToInt32(reader["edad"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='email'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["email"]))
                    asistenteAP.Email = Convert.ToString(reader["email"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='contrasena'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["contrasena"]))
                    asistenteAP.Contrasena = (byte[])reader["contrasena"];
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='celular'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["celular"]))
                    asistenteAP.Celular = Convert.ToString(reader["celular"]);
            }

            return asistenteAP;
        }


        public AsistenteAtencionPublico BuscarAsistenteAtencionPublico(Usuario asistenteAtencionPublico)
        {
            AsistenteAtencionPublico entidad = null;
            using (SqlConnection conexion = new
            SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("buscarAAP", conexion))
                {
                    comando.Parameters.AddWithValue("@Dni", asistenteAtencionPublico.Dni);
                    comando.Parameters.AddWithValue("@Contrasena", asistenteAtencionPublico.Contrasena);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
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