using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
  public  class Materiales : ClaseMaestra

    {

        public int IdMaterial{ get; set; }
        public string Descripcion{ get; set; }
        public float Precio { get; set; }

        private string tabla;

        public Materiales()
        {
            IdMaterial = 0;
            Descripcion = "";
            Precio = 0f;
            tabla="Materiales";

        }

        public override bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();

            string sql = string.Format("insert into {0}(Descripcion, Precio) values('{1}',{2})SELECT @@IDENTITY",tabla,Descripcion,Precio);
            IdMaterial =Convert.ToInt32 (conexion.ObtenerValorDb(sql).ToString());
            return IdMaterial > 0;
        }


        public override bool Editar()
        {
            ConexionDb con = new ConexionDb();

            bool Retorno = false;
            Retorno = con.EjecutarDB(String.Format("Update {0} set Descripcion = '{1}', Precio = {2} where IdMaterial = {3}", this.tabla, this.Descripcion, this.Precio, this.IdMaterial));
            return Retorno;
        }


        public override bool Eliminar()
        {
            ConexionDb con = new ConexionDb();

            bool retorno = false;
            retorno = con.EjecutarDB(String.Format("Delete from {0} where IdMaterial = {1}",this.tabla, this.IdMaterial));
            return retorno;
        }

        public override bool Buscar(int IdBuscado)
        {
            ConexionDb conexion = new ConexionDb();

            DataTable dt = new DataTable();

            dt = conexion.BuscarDb(string.Format("Select * from {0} where IdMateriales = {1}",tabla, IdBuscado));
            if (dt.Rows.Count > 0)
            {
                this.IdMaterial = (int)dt.Rows[0]["IdMaterial"];
                this.Descripcion = dt.Rows[0]["Descripcion"].ToString();
                this.Precio = (float)dt.Rows[0]["Precio"];
            }
            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos = "*", string Condicion = "1=1", string Orden = "desc")
        {
            ConexionDb conexion = new ConexionDb();
            return conexion.BuscarDb("Select" + Campos + "from Materiales where " + Condicion + " order by IdMaterial " + Orden);
        }
    }
}
