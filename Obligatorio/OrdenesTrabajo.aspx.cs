using Obligatorio.Clases;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio
{
    public partial class OrdenesTrabajo : System.Web.UI.Page
    {
        public static int contadorOrdenes = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar datos de ejemplo para clientes y técnicos
                ddlCliente.DataSource = Basededatos.misClientes; // Suponiendo que ya tienes esta lista
                ddlCliente.DataTextField = "Nombre"; // Ajusta según tu modelo
                ddlCliente.DataBind();

                ddlTecnico.DataSource = Basededatos.misTecnicos; // Suponiendo que ya tienes esta lista
                ddlTecnico.DataTextField = "Nombre"; // Ajusta según tu modelo
                ddlTecnico.DataBind();

                // Enlazar la tabla
                gvOrdenes.DataSource = Basededatos.misOrdenes;
                gvOrdenes.DataBind();
            }

        }

        protected void btnCrearOrden_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                lblMensaje.Text = "La descripción del problema es obligatoria.";
                lblMensaje.ForeColor = Color.Red;
                return;
            }

            OrdenDeTrabajo nuevaOrden = new OrdenDeTrabajo
            {
                NumeroOrden = contadorOrdenes++,
                Cliente = ddlCliente.SelectedValue,
                Tecnico = ddlTecnico.SelectedValue,
                DescripcionProblema = txtDescripcion.Text,
                FechaCreacion = DateTime.Now,
                Estado = "Pendiente",
                ComentariosTecnico = new List<string>()
            };

            Basededatos.misOrdenes.Add(nuevaOrden);
            gvOrdenes.DataSource = Basededatos.misOrdenes;
            gvOrdenes.DataBind();

            lblMensaje.Text = "Orden creada con éxito.";

            txtDescripcion.Text = "";

        }
        protected void gvOrdenes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvOrdenes.EditIndex = e.NewEditIndex;
            gvOrdenes.DataSource = Basededatos.misOrdenes;
            gvOrdenes.DataBind();
        }

        protected void gvOrdenes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = e.RowIndex;
            DropDownList ddlEstado = (DropDownList)gvOrdenes.Rows[index].FindControl("ddlEstado");

            Basededatos.misOrdenes[index].Estado = ddlEstado.SelectedValue;

            gvOrdenes.EditIndex = -1;
            gvOrdenes.DataSource = Basededatos.misOrdenes;
            gvOrdenes.DataBind();

            lblMensaje.ForeColor = Color.Green;
            lblMensaje.Text = "Estado actualizado con éxito.";
        }

        protected void gvOrdenes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Basededatos.misOrdenes.RemoveAt(e.RowIndex);
            gvOrdenes.DataSource = Basededatos.misOrdenes;
            gvOrdenes.DataBind();

            lblMensaje.ForeColor = Color.Red;
            lblMensaje.Text = "Orden eliminada con éxito.";
        }

        protected void gvOrdenes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AgregarComentario")
            {
                int numeroOrden = Convert.ToInt32(e.CommandArgument);
                OrdenDeTrabajo orden = Basededatos.misOrdenes.Find(o => o.NumeroOrden == numeroOrden);

                if (orden != null)
                {
                    // Aquí podrías abrir un modal o redirigir para agregar comentarios
                    lblMensaje.Text = $"Comentarios para la orden {numeroOrden}.";
                }
            }
        }
    }
}