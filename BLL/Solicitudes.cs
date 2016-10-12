using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
 public class Solicitudes: ClaseMaestra
    {

        public int IdSolicitud { get; set; }
        public DateTime Fecha{ get; set; }
        public string  Razon  { get; set; }
        public float Total { get; set; }

        private string tabla;
        public Solicitudes()
        {
            IdSolicitud = 0;
            Fecha = DateTime.Now;
            Razon = "";
            Total = 0f;
            tabla = "Solicitudes";

        }
        public override bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            string sql = string.Format("insert into {0}(Fecha,Razon,Total) values({1},'{2}',{3}) select @@identity",tabla,Fecha.ToString("yyy-MM-dd"),Razon,Total);
           IdSolicitud=Convert.ToInt32 (conexion.ObtenerValorDb(sql).ToString());
            return IdSolicitud > 0;
        }

        public override bool Editar()
        {
            ConexionDb conexion = new ConexionDb();

            bool Retorno = false;
            Retorno = conexion.EjecutarDB(String.Format("Update {0} set Fecha = {1}, Razon = '{2}', Total = {3} where IdSolicitud = {4}", this.tabla, this.Fecha, this.Razon, this.Total, this.IdSolicitud));
            return Retorno;
        }

        public override bool Eliminar()
        {
            ConexionDb conexion = new ConexionDb();

            bool retorno = false;
            retorno = conexion.EjecutarDB(String.Format("Delete from {0} where IdSolicitud = {1}", this.tabla, this.IdSolicitud));
            return retorno;
        }

        public override bool Buscar(int IdBuscado)
        {
            ConexionDb conexion = new ConexionDb();

            DataTable dt = new DataTable();

            dt = conexion.BuscarDb(string.Format("Select * from {0} where IdMateriales = {1}", tabla, IdBuscado));
            if (dt.Rows.Count > 0)
            {
                this.IdSolicitud = (int)dt.Rows[0]["IdSolicitud"];
                this.Fecha = Convert.ToDateTime(dt.Rows[0]["Fecha"].ToString());
                this.Razon = dt.Rows[0]["Razon"].ToString();
                this.Total = (float)dt.Rows[0]["Total"];
            }
            return dt.Rows.Count > 0;
        }


        public override DataTable Listado(string Campos = "*", string Condicion = "1=1", string Orden = "desc")
        {
            ConexionDb conexion = new ConexionDb();
            return conexion.BuscarDb("Select" + Campos + "from Solicitudes where " + Condicion + " order by IdSolicitud " + Orden);
        }
    }
}
