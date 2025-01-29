using System;
using System.Data.SqlClient;

namespace Gestor_Torneos.Vistas
{
    public partial class AgregarTorneo : System.Web.UI.Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar datos ingresados
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtFechaInicio.Text) || string.IsNullOrWhiteSpace(txtFechaFin.Text))
            {
                Response.Write("<script>alert('Por favor, complete todos los campos.');</script>");
                return;
            }

            // Insertar el nuevo torneo en la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Torneos (Nombre, Tipo, FechaInicio, FechaFin) VALUES (@Nombre, @Tipo, @FechaInicio, @FechaFin)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                command.Parameters.AddWithValue("@Tipo", ddlTipo.SelectedValue);
                command.Parameters.AddWithValue("@FechaInicio", txtFechaInicio.Text);
                command.Parameters.AddWithValue("@FechaFin", txtFechaFin.Text);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    // Redirigir a la página de gestión de torneos después de guardar
                    Response.Redirect("GestionTorneos.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error al guardar el torneo: {ex.Message}');</script>");
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // Redirigir a la página de gestión de torneos
            Response.Redirect("GestionTorneos.aspx");
        }
    }
}
