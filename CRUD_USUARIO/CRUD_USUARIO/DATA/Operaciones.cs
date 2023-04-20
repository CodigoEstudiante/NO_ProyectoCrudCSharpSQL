using CRUD_USUARIO.MODELO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_USUARIO.DATA
{
    public class Operaciones
    {
        public bool CrearPersona(Persona oPersona)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Configuracion.Conexion))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_CrearPersona", oConexion);
                    cmd.Parameters.AddWithValue("DocumentoIdentidad", oPersona.DocumentoIdentidad);
                    cmd.Parameters.AddWithValue("Nombres", oPersona.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", oPersona.Apellidos);
                    cmd.Parameters.AddWithValue("Telefono", oPersona.Telefono);
                    cmd.Parameters.AddWithValue("Foto", oPersona.Foto);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }catch(Exception ex)
                {
                    respuesta = false;
                }
                
            }

            return respuesta;

        }

        public bool ModificarPersona(Persona oPersona)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Configuracion.Conexion))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ModificarPersona", oConexion);
                    cmd.Parameters.AddWithValue("IdPersona", oPersona.IdPersona);
                    cmd.Parameters.AddWithValue("DocumentoIdentidad", oPersona.DocumentoIdentidad);
                    cmd.Parameters.AddWithValue("Nombres", oPersona.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", oPersona.Apellidos);
                    cmd.Parameters.AddWithValue("Telefono", oPersona.Telefono);
                    cmd.Parameters.AddWithValue("Foto", oPersona.Foto);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }

        public List<Persona> ObtenerPersonas()
        {
            List<Persona> oListaPersona = new List<Persona>();
            using (SqlConnection oConexion = new SqlConnection(Configuracion.Conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerPersonas", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                oConexion.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    oListaPersona.Add(new Persona
                    {
                        IdPersona = int.Parse(dr["IdPersona"].ToString()),
                        DocumentoIdentidad = dr["DocumentoIdentidad"].ToString(),
                        Nombres = dr["Nombres"].ToString(),
                        Apellidos = dr["Apellidos"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Foto = dr["Foto"] as byte[]
                    });

                }
                dr.Close();


            }

            return oListaPersona;

        }




    }
}
