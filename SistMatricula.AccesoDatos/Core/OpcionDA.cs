using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistMatricula.Entidades.Core;

namespace SistMatricula.AccesoDatos.Core
{
    public class OpcionDA
    {
        public Opcion LlenarEntidad(IDataReader reader)
        {
            Opcion opcion = new Opcion();
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdOpcion'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["IdOpcion"]))
                    opcion.IdOpcion = Convert.ToInt32(reader["IdOpcion"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreOpcion'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["NombreOpcion"]))
                    opcion.NombreOpcion = Convert.ToString(reader["NombreOpcion"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UrlOpcion'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["UrlOpcion"]))
                    opcion.UrlOpcion = Convert.ToString(reader["UrlOpcion"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RutaImagen'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["RutaImagen"]))
                    opcion.RutaImagen = Convert.ToString(reader["RutaImagen"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NroOrden'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["NroOrden"]))
                    opcion.NroOrden = Convert.ToInt32(reader["NroOrden"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdOpcionRef'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["IdOpcionRef"]))
                    opcion.IdOpcionRef = Convert.ToInt32(reader["IdOpcionRef"]);
            }
            return opcion;
        }
        public List<Opcion> ListaOpcionesAlumno()
        {
            List<Opcion> listaEntidad = new List<Opcion>();
            Opcion entidad = null;
            using (SqlConnection conexion = new
            SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("obtenerListaOpcionesAP", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = LlenarEntidad(reader);
                        listaEntidad.Add(entidad);
                    }
                }
                conexion.Close();
            }
            return listaEntidad;
        }
        public List<Opcion> ListaOpcionesAC()
        {
            List<Opcion> listaEntidad = new List<Opcion>();
            Opcion entidad = null;
            using (SqlConnection conexion = new
            SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("obtenerListaOpcionesAC", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = LlenarEntidad(reader);
                        listaEntidad.Add(entidad);
                    }
                }
                conexion.Close();
            }
            return listaEntidad;
        }
        public List<Opcion> ListaOpcionesAAP()
        {
            List<Opcion> listaEntidad = new List<Opcion>();
            Opcion entidad = null;
            using (SqlConnection conexion = new
            SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("obtenerListaOpcionesAP", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = LlenarEntidad(reader);
                        listaEntidad.Add(entidad);
                    }
                }
                conexion.Close();
            }
            return listaEntidad;
        }
        public List<Opcion> ListaOpcionCoord()
        {
            List<Opcion> listaEntidad = new List<Opcion>();
            Opcion entidad = null;
            using (SqlConnection conexion = new
            SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("obtenerListaOpcionesC", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = LlenarEntidad(reader);
                        listaEntidad.Add(entidad);
                    }
                }
                conexion.Close();
            }
            return listaEntidad;
        }
    }
}