using System;
using System.Data;
using System.Data.SqlClient;

namespace Gestor_Torneos.Vistas
{
    public partial class GestionEquipos : System.Web.UI.Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEquipos(); // Cargar los datos al cargar la página
            }
        }

        private void CargarEquipos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT e.ID_Equipo, e.Nombre, t.Nombre AS Torneo
                                 FROM Equipos e
                                 INNER JOIN Torneos t ON e.ID_Torneo = t.ID_Torneo";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                gvEquipos.DataSource = dataTable;
                gvEquipos.DataBind();
            }
        }

        protected void btnAddEquipo_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarEquipo.aspx"); // Redirigir a la página para agregar un equipo
        }

        protected void gvEquipos_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            int idEquipo = Convert.ToInt32(gvEquipos.DataKeys[e.NewEditIndex].Value); // Obtener ID del equipo seleccionado
            Response.Redirect($"EditarEquipo.aspx?id={idEquipo}"); // Redirigir a la página para editar el equipo
        }

        protected void gvEquipos_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int idEquipo = Convert.ToInt32(gvEquipos.DataKeys[e.RowIndex].Value); // Obtener ID del equipo seleccionado

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Equipos WHERE ID_Equipo = @ID_Equipo";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID_Equipo", idEquipo);

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

            CargarEquipos(); // Recargar los datos
        }
    }
}
