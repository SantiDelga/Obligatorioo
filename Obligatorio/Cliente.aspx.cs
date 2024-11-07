﻿using Obligatorio.Clases;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Este método se ejecuta cuando la página se carga
            if (!IsPostBack)
            {
                // Cargar la lista de clientes en el GridView
                gvCliente.DataSource = Basededatos.misClientes;
                gvCliente.DataBind();
            }

        }

        // Este método se ejecuta cuando se hace clic en el botón "Agregar Cliente"
        protected void Button1_Click(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes() 
            {

                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                CI = int.Parse(txtCi.Text),
                Direccion = txtDireccion.Text,
                Telefono = int.Parse(txtTelefono.Text),
                Email = txtEmail.Text

            };

            Basededatos.misClientes.Add(cliente);

            gvCliente.DataSource = Basededatos.misClientes;
            gvCliente.DataBind();

            lblMensaje.Text = "El cliente se creo correctamente";
            lblMensaje.ForeColor=Color.Black;

            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCi.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";

        }

          // Maneja el evento de editar un cliente
        protected void gvCliente_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Obtén el índice de la fila en la que se hace clic en Editar
            int index = e.NewEditIndex;

            // Establece el modo de edición del GridView
            gvCliente.EditIndex = index;

            // Vuelve a enlazar los datos del GridView
            gvCliente.DataSource = Basededatos.misClientes;
            gvCliente.DataBind();
        }

        // Maneja el evento de cancelar la edición
        protected void gvCliente_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Cancela el modo de edición
            gvCliente.EditIndex = -1;

            // Vuelve a enlazar los datos del GridView
            gvCliente.DataSource = Basededatos.misClientes;
            gvCliente.DataBind();
        }

        // Maneja el evento de actualizar un cliente (cuando se hace clic en el botón "Actualizar")
        protected void gvCliente_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Obtén el índice de la fila que está siendo editada
            int index = e.RowIndex;

            // Accede a los controles TextBox en la fila editada
            TextBox txtNombre = (TextBox)gvCliente.Rows[index].FindControl("txtNombre");
            TextBox txtApellido = (TextBox)gvCliente.Rows[index].FindControl("txtApellido");
            TextBox txtCI = (TextBox)gvCliente.Rows[index].FindControl("txtCI");
            TextBox txtDireccion = (TextBox)gvCliente.Rows[index].FindControl("txtDireccion");
            TextBox txtTelefono = (TextBox)gvCliente.Rows[index].FindControl("txtTelefono");
            TextBox txtEmail = (TextBox)gvCliente.Rows[index].FindControl("txtEmail");

            // Obtén los nuevos valores ingresados
            string nuevoNombre = txtNombre.Text;
            string nuevoApellido = txtApellido.Text;
            int nuevoCI = int.Parse(txtCI.Text);
            string nuevaDireccion = txtDireccion.Text;
            int nuevoTelefono = int.Parse(txtTelefono.Text);
            string nuevoEmail = txtEmail.Text;

            // Actualiza el cliente en la lista
            Clientes cliente = Basededatos.misClientes[index];
            cliente.Nombre = nuevoNombre;
            cliente.Apellido = nuevoApellido;
            cliente.CI = nuevoCI;
            cliente.Direccion = nuevaDireccion;
            cliente.Telefono = nuevoTelefono;
            cliente.Email = nuevoEmail;

            // Salir del modo de edición
            gvCliente.EditIndex = -1;

            // Vuelve a enlazar los datos del GridView
            gvCliente.DataSource = Basededatos.misClientes;
            gvCliente.DataBind();
        }


        // Maneja el evento de eliminar un cliente
        protected void gvCliente_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Obtén el índice de la fila que está siendo eliminada
            int index = e.RowIndex;

            // Elimina el cliente de la lista
            Basededatos.misClientes.RemoveAt(index);

            // Vuelve a enlazar los datos del GridView
            gvCliente.DataSource = Basededatos.misClientes;
            gvCliente.DataBind();
        }


        protected void gvCliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Aquí iría la lógica para manejar el comando
            if (e.CommandName == "Eliminar")
            {
                // Obtener el índice de la fila y eliminar el cliente correspondiente
                int index = Convert.ToInt32(e.CommandArgument);
                Basededatos.misClientes.RemoveAt(index);

                // Re-bind del GridView
                gvCliente.DataSource = Basededatos.misClientes;
                gvCliente.DataBind();
            }
        }


    }
}