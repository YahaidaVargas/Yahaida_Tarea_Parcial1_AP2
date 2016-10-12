using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
  public  class SolicitudesDetalle: ClaseMaestra
    {

        public int Id { get; set; }
        public int IdSolicitud { get; set; }
        public int IdMaterial{ get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }

        private string tabla;

    public SolicitudesDetalle()
        {
            Id = 0;
            IdSolicitud = 0;
            IdMaterial = 0;
            Cantidad = 0;
            Precio = 0f;
            tabla = "SolicitudDetalle";

        }

        public override bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            string sql = string.Format("insert into {0}(IdSolicitud,IdMaterial,Cantidad,Precio) values({1},{2},{3},{4}) select @@identity", tabla, IdSolicitud, IdMaterial, Cantidad,Precio);
            IdSolicitud = Convert.ToInt32(conexion.ObtenerValorDb(sql).ToString());
            return Id> 0;
        }

        public override bool Editar()
        {
            ConexionDb conexion = new ConexionDb();

            bool Retorno = false;
            Retorno = conexion.EjecutarDB(String.Format("Update {0} set IdSolicitud = {1}, IdMaterial = {2},Cantidad = {3},Precio= {4} where Id = {3}", this.tabla, this.IdSolicitud, this.IdMaterial, this.Cantidad,this.Precio, this.Id));
            return Retorno;
        }

        public override bool Eliminar()
        {
            ConexionDb conexion = new ConexionDb();

            bool retorno = false;
            retorno = conexion.EjecutarDB(String.Format("Delete from {0} where Id = {1}", this.tabla, this.Id));
            return retorno;
        }

        public override bool Buscar(int IdBuscado)
        {
            ConexionDb conexion = new ConexionDb();

            DataTable dt = new DataTable();

            dt = conexion.BuscarDb(string.Format("Select * from {0} where Id = {1}", tabla, IdBuscado));
            if (dt.Rows.Count > 0)
            {
                this.Id = (int)dt.Rows[0]["Id"];
                this.IdSolicitud = (int)dt.Rows[0]["IdSolicitud"];
                this.IdMaterial = (int)dt.Rows[0]["IdMaterial"];
                this.Cantidad = (int)dt.Rows[0]["Cantidad"];
                this.Precio = (float)dt.Rows[0]["Precio"];
            }
            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos = "*", string Condicion = "1=1", string Orden = "desc")
        {
            ConexionDb conexion = new ConexionDb();
            return conexion.BuscarDb("Select" + Campos + "from SolicitudDetalle where " + Condicion + " order by Id " + Orden);
        }
    }
}
