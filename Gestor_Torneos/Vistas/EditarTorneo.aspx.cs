using System;
using System.Data.SqlClient;

namespace Gestor_Torneos.Vistas
{
    public partial class EditarTorneo : System.Web.UI.Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosTorneo();
            }
        }

        private void CargarDatosTorneo()
        {
            int idTorneo = Convert.ToInt32(Request.QueryString["id"]); // Obtener el ID del torneo desde la URL

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Torneos WHERE ID_Torneo = @ID_Torneo";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID_Torneo", idTorneo);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        txtNombre.Text = reader["Nombre"].ToString();
                        ddlTipo.SelectedValue = reader["Tipo"].ToString();
                        txtFechaInicio.Text = Convert.ToDateTime(reader["FechaInicio"]).ToString("yyyy-MM-dd");
                        txtFechaFin.Text = Convert.ToDateTime(reader["FechaFin"]).ToString("yyyy-MM-dd");
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error al cargar los datos: {ex.Message}');</script>");
                }
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            int idTorneo = Convert.ToInt32(Request.QueryString["id"]); // Obtener el ID del torneo desde la URL

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Torneos SET Nombre = @Nombre, Tipo = @Tipo, FechaInicio = @FechaInicio, FechaFin = @FechaFin WHERE ID_Torneo = @ID_Torneo";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ID_Torneo", idTorneo);
                command.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                command.Parameters.AddWithValue("@Tipo", ddlTipo.SelectedValue);
                command.Parameters.AddWithValue("@FechaInicio", txtFechaInicio.Text);
                command.Parameters.AddWithValue("@FechaFin", txtFechaFin.Text);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    // Redirigir a la página de gestión de torneos después de actualizar
                    Response.Redirect("GestionTorneos.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error al actualizar el torneo: {ex.Message}');</script>");
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
