using System;
using System.Data.SqlClient;

namespace Gestor_Torneos.Vistas
{
    public partial class EditarEquipo : System.Web.UI.Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTorneos(); // Cargar la lista de torneos
                CargarDatosEquipo(); // Cargar los datos del equipo seleccionado
            }
        }

        private void CargarTorneos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ID_Torneo, Nombre FROM Torneos";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    ddlTorneo.DataSource = reader;
                    ddlTorneo.DataTextField = "Nombre";
                    ddlTorneo.DataValueField = "ID_Torneo";
                    ddlTorneo.DataBind();

                    ddlTorneo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Seleccione un Torneo --", "0"));
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error al cargar los torneos: {ex.Message}');</script>");
                }
            }
        }

        private void CargarDatosEquipo()
        {
            int idEquipo = Convert.ToInt32(Request.QueryString["id"]); // Obtener el ID del equipo desde la URL

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Nombre, ID_Torneo FROM Equipos WHERE ID_Equipo = @ID_Equipo";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID_Equipo", idEquipo);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        txtNombre.Text = reader["Nombre"].ToString();
                        ddlTorneo.SelectedValue = reader["ID_Torneo"].ToString();
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error al cargar los datos del equipo: {ex.Message}');</script>");
                }
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || ddlTorneo.SelectedValue == "0")
            {
                Response.Write("<script>alert('Por favor, complete todos los campos.');</script>");
                return;
            }

            int idEquipo = Convert.ToInt32(Request.QueryString["id"]); // Obtener el ID del equipo desde la URL

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Equipos SET Nombre = @Nombre, ID_Torneo = @ID_Torneo WHERE ID_Equipo = @ID_Equipo";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ID_Equipo", idEquipo);
                command.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                command.Parameters.AddWithValue("@ID_Torneo", ddlTorneo.SelectedValue);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    // Redirigir a la página de gestión de equipos después de actualizar
                    Response.Redirect("GestionEquipos.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error al actualizar el equipo: {ex.Message}');</script>");
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // Redirigir a la página de gestión de equipos
            Response.Redirect("GestionEquipos.aspx");
        }
    }
}
