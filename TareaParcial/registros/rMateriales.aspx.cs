using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Web.SessionState;


namespace TareaParcial
{
    public partial class rMateriales : System.Web.UI.Page
    {

        Materiales mate = new Materiales();
        Solicitudes sol = new Solicitudes();
        SolicitudesDetalle sDt = new SolicitudesDetalle();
         
        DataTable dt;
         DataColumn dc;
            DataRow dr;




        public rMateriales()
        {
           
                

        
    

        }
      
        protected void Page_Load(object sender, EventArgs e)
        {
            //GVDetalle.DataSource = dt;
            //Session.Clear();
        }

        protected void BtnADD_Click(object sender, EventArgs e)
        {

            datatablesesion();
            dr["Material"] = TxtDescripcionM.Text;
            dr["Cantidad"] = TxtCantidad.Text;
            dr["Precio"] = TxtPrecio.Text;

            float precio;
            int cant;
            float total = 0f;

            cant = Int32.Parse(TxtCantidad.Text);
            precio = float.Parse(TxtPrecio.Text);

            float importe=  cant * precio;

            dr["Importe"] = importe;

            total += importe;

            Session["total"] = total;
           

            dt.Rows.Add(dr);            

            GVDetalle.DataBind();


           
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            sol.Fecha = Convert.ToDateTime(TxtFecha.Text);
            sol.Razon = txtRazon.Text;
            sol.Total = float.Parse(Session["total"].ToString());
            sol.Insertar();

            datatablesesion();
            foreach (DataRow fila in dt.Rows)
            {
                mate.Descripcion = fila["Material"].ToString();
                mate.Precio = float.Parse(fila["Precio"].ToString());
                mate.Insertar();

                sDt.IdSolicitud = sol.IdSolicitud;
                sDt.IdMaterial = mate.IdMaterial;
                sDt.Cantidad = Convert.ToInt32(fila["Cantidad"].ToString());
                sDt.Precio = float.Parse(fila["Precio"].ToString());
                sDt.Insertar();
            }
        }

        void datatablesesion()
        {
            if (Session["dtable"] == null)
            {
                dt = new DataTable("Materiales");
                dc = new DataColumn();
                dc.DataType = Type.GetType("System.String");
                dc.ColumnName = "Material";
                dc.Caption = "Materiales";
                dt.Columns.Add(dc);


                dc = new DataColumn();
                dc.DataType = Type.GetType("System.String");
                dc.ColumnName = "Cantidad";
                dc.Caption = "Cantidad";
                dt.Columns.Add(dc);


                dc = new DataColumn();
                dc.DataType = Type.GetType("System.String");
                dc.ColumnName = "Precio";
                dc.Caption = "Precio";
                dt.Columns.Add(dc);
                //dr = dt.NewRow();

                dc = new DataColumn();
                dc.DataType = Type.GetType("System.String");
                dc.ColumnName = "Importe";
                dc.Caption = "Importe";
                dt.Columns.Add(dc);
                dr = dt.NewRow();

                Session["dtable"] = dt;

            }
            else
            {
                dt = (DataTable)Session["dtable"];
                dr = dt.NewRow();
            }

            GVDetalle.DataSource = dt;
        }
    }

    
}