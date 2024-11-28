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
    public partial class BuscarOrden : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string numeroOrden = txtNumeroOrden.Text.Trim();

            // Verifica que el número de orden sea válido
            if (string.IsNullOrEmpty(numeroOrden) || !int.TryParse(numeroOrden, out int ordenId))
            {
                lblMensaje.Text = "Ingrese un número de orden válido.";
                lblMensaje.ForeColor= Color.Red;
                panelDetalles.Visible = False;
                return;
            }

            // Buscar la orden en la lista de órdenes (basado en tu clase)
            var orden = Basededatos.misOrdenes.FirstOrDefault(o => o.NumeroOrden == ordenId);
            if (orden == null)
            {
                lblMensaje.Text = "Orden no encontrada.";
                panelDetalles.Visible = False;
                return;
            }

            // Mostrar los detalles de la orden
            lblEstado.Text = $"Estado: {orden.Estado}";
            lblCliente.Text = $"Cliente: {orden.Cliente.NombreCompleto}";
            lblTecnico.Text = $"Técnico: {orden.Tecnico.NombreCompleto}";
            lblComentarios.Text = $"Comentarios: {orden.Comentarios}";
            panelDetalles.Visible = True;
            lblMensaje.Text = string.Empty;
        }
    }
}