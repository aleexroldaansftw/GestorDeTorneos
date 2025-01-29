using System;
using System.Data;
using System.Data.SqlClient;

namespace Gestor_Torneos.Vistas
{
    public partial class AgregarEquipo : System.Web.UI.Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTorneos(); // Cargar la lista de torneos al cargar la página
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || ddlTorneo.SelectedValue == "0")
            {
                Response.Write("<script>alert('Por favor, complete todos los campos.');</script>");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Equipos (Nombre, ID_Torneo) VALUES (@Nombre, @ID_Torneo)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                command.Parameters.AddWithValue("@ID_Torneo", ddlTorneo.SelectedValue);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    Response.Redirect("GestionEquipos.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error al guardar el equipo: {ex.Message}');</script>");
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
