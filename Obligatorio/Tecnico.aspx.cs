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
    public partial class Tecnico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Este método se ejecuta cuando la página se carga
            if (!IsPostBack)
            {
                // Cargar la lista de tecnicos en el GridView
                gvTecnico.DataSource = Basededatos.misTecnicos;
                gvTecnico.DataBind();
            }

        }

        // Este método se ejecuta cuando se hace clic en el botón "Agregar Cliente"
        protected void Button1_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = ""; // Limpiar el mensaje

            int nuevoCI;

            // Validación de la cédula
            if (!Validacion.ValidarCedula(txtCITecnico.Text))
            {
                lblMensaje.Text = "La cédula no es válida.";
                lblMensaje.ForeColor = Color.Red;
                return;  // Detiene la ejecución si la cédula no es válida
            }

            nuevoCI = int.Parse(txtCITecnico.Text);

            // Verificar si el CI ya está registrado
            foreach (Tecnicos tecnicoo in Basededatos.misTecnicos)
            {
                if (tecnicoo.CI == nuevoCI)
                {
                    lblMensaje.Text = "El número de cédula ya está registrado.";
                    lblMensaje.ForeColor = Color.Red;
                    return;  // Detiene la ejecución si el CI ya está registrado
                }
            }

            Tecnicos tecnico = new Tecnicos()
            {

                Nombre = txtNombreTecnico.Text,
                Apellido = txtApellidoTecnico.Text,
                CI = nuevoCI,
                Especialidad = txtEspecialidadTecnico.Text,

            };

            Basededatos.misTecnicos.Add(tecnico);

            gvTecnico.DataSource = Basededatos.misTecnicos;
            gvTecnico.DataBind();

            lblMensaje.Text = "El Técnico se creó correctamente";
            lblMensaje.ForeColor = Color.Black;

            txtNombreTecnico.Text = "";
            txtApellidoTecnico.Text = "";
            txtCITecnico.Text = "";
            txtEspecialidadTecnico.Text = "";

        }

        // Maneja el evento de editar un Tecnico
        protected void gvTecnico_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Obtén el índice de la fila en la que se hace clic en Editar
            int index = e.NewEditIndex;

            // Establece el modo de edición del GridView
            gvTecnico.EditIndex = index;

            // Vuelve a enlazar los datos del GridView
            gvTecnico.DataSource = Basededatos.misTecnicos;
            gvTecnico.DataBind();
        }

        // Maneja el evento de cancelar la edición
        protected void gvTecnico_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Cancela el modo de edición
            gvTecnico.EditIndex = -1;

            // Vuelve a enlazar los datos del GridView
            gvTecnico.DataSource = Basededatos.misTecnicos;
            gvTecnico.DataBind();
        }

        // Maneja el evento de actualizar un tecnico (cuando se hace clic en el botón "Actualizar")
        protected void gvTecnico_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            lblMensaje.Text = ""; // Limpiar el mensaje

            // Obtén el índice de la fila que está siendo editada
            int index = e.RowIndex;

            // Accede a los controles TextBox en la fila editada
            TextBox txtNombreTecnico = (TextBox)gvTecnico.Rows[index].FindControl("txtNombreTecnico");
            TextBox txtApellidoTecnico = (TextBox)gvTecnico.Rows[index].FindControl("txtApellidoTecnico");
            TextBox txtCITecnico = (TextBox)gvTecnico.Rows[index].FindControl("txtCITecnico");
            TextBox txtEspecialidadTecnico = (TextBox)gvTecnico.Rows[index].FindControl("txtEspecialidadTecnico");

            // Validación de la cédula
            int nuevoCI;
            if (!Validacion.ValidarCedula(txtCITecnico.Text))
            {
                lblMensaje.Text = "La cédula no es válida.";
                lblMensaje.ForeColor = Color.Red;
                return;  // Detiene la ejecución si la cédula no es válida
            }

            nuevoCI = int.Parse(txtCITecnico.Text);

            // Validar que el nuevo CI no esté duplicado, omitiendo el técnico actual
            for (int i = 0; i < Basededatos.misTecnicos.Count; i++)
            {
                if (i != index && Basededatos.misTecnicos[i].CI == nuevoCI)
                {
                    lblMensaje.Text = "El número de cédula ya está registrado.";
                    lblMensaje.ForeColor = Color.Red;
                    return; // Detiene la ejecución si el CI ya está registrado en otro técnico
                }
            }


            // Obtén los nuevos valores ingresados
            string nuevoNombreTecnico = txtNombreTecnico.Text;
            string nuevoApellidoTecnico = txtApellidoTecnico.Text;
            string nuevaEspecialidadTecnico = txtEspecialidadTecnico.Text;


            // Actualiza el tecnico en la lista
            Tecnicos tecnico = Basededatos.misTecnicos[index];
            tecnico.Nombre = nuevoNombreTecnico;
            tecnico.Apellido = nuevoApellidoTecnico;
            tecnico.CI = nuevoCI;
            tecnico.Especialidad = nuevaEspecialidadTecnico;

            // Salir del modo de edición
            gvTecnico.EditIndex = -1;

            // Vuelve a enlazar los datos del GridView
            gvTecnico.DataSource = Basededatos.misTecnicos;
            gvTecnico.DataBind();

            // Muestra mensaje de actualización correcta

            lblMensaje.Text = "El Técnico se actualizó correctamente";
            lblMensaje.ForeColor = Color.DarkGreen;

        }

        // Maneja el evento de eliminar un Tecnico
        protected void gvTecnico_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Obtén el índice de la fila que está siendo eliminada
            int index = e.RowIndex;

            // Elimina el tecnico de la lista
            Basededatos.misTecnicos.RemoveAt(index);

            // Vuelve a enlazar los datos del GridView
            gvTecnico.DataSource = Basededatos.misTecnicos;
            gvTecnico.DataBind();
        }


        protected void gvTecnico_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Aquí iría la lógica para manejar el comando
            if (e.CommandName == "Eliminar")
            {
                // Obtener el índice de la fila y eliminar el cliente correspondiente
                int index = Convert.ToInt32(e.CommandArgument);
                Basededatos.misTecnicos.RemoveAt(index);

                // Re-bind del GridView
                gvTecnico.DataSource = Basededatos.misTecnicos;
                gvTecnico.DataBind();
            }
        }
    }
}