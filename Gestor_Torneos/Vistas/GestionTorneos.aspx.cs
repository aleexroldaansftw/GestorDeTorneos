using System;
using System.Data;
using System.Data.SqlClient;

namespace Gestor_Torneos.Vistas
{
    public partial class GestionTorneos : System.Web.UI.Page
    {
        // Cadena de conexión a la base de datos
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTorneos(); // Cargar los datos al cargar la página
            }
        }

        // Método para cargar los torneos desde la base de datos
        private void CargarTorneos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Torneos";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                gvTorneos.DataSource = dataTable;
                gvTorneos.DataBind();
            }
        }

        // Evento para agregar un nuevo torneo
        protected void btnAddTorneo_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarTorneo.aspx"); // Redirigir a la página para agregar un torneo
        }

        // Evento para editar un torneo
        protected void gvTorneos_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            int idTorneo = Convert.ToInt32(gvTorneos.DataKeys[e.NewEditIndex].Value); // Obtener ID del torneo seleccionado
            Response.Redirect($"EditarTorneo.aspx?id={idTorneo}"); // Redirigir a la página para editar el torneo
        }

        // Evento para eliminar un torneo
        protected void gvTorneos_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int idTorneo = Convert.ToInt32(gvTorneos.DataKeys[e.RowIndex].Value); // Obtener ID del torneo seleccionado

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Torneos WHERE ID_Torneo = @ID_Torneo";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID_Torneo", idTorneo);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    Response.Write($"<script>alert('Error al eliminar: {ex.Message}');</script>");
                }
            }

            CargarTorneos(); // Recargar los datos
        }
    }
}
