using System;
using System.Data;
using System.Data.SqlClient;

namespace Gestor_Torneos.Vistas
{
    public partial class GestionPartidos : System.Web.UI.Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPartidos(); // Cargar los partidos al cargar la página
            }
        }

        private void CargarPartidos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT p.ID_Partido, t.Nombre AS Torneo, e1.Nombre AS Equipo1, e2.Nombre AS Equipo2, 
                                p.Fecha, p.Resultado
                                FROM Partidos p
                                INNER JOIN Torneos t ON p.ID_Torneo = t.ID_Torneo
                                INNER JOIN Equipos e1 ON p.ID_Equipo1 = e1.ID_Equipo
                                INNER JOIN Equipos e2 ON p.ID_Equipo2 = e2.ID_Equipo";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                gvPartidos.DataSource = dataTable;
                gvPartidos.DataBind();
            }
        }

        protected void btnAddPartido_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarPartido.aspx"); // Redirigir a la vista para agregar un partido
        }

        protected void gvPartidos_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            int idPartido = Convert.ToInt32(gvPartidos.DataKeys[e.NewEditIndex].Value); // Obtener ID del partido seleccionado
            Response.Redirect($"EditarPartido.aspx?id={idPartido}"); // Redirigir a la página para editar el partido
        }

        protected void gvPartidos_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int idPartido = Convert.ToInt32(gvPartidos.DataKeys[e.RowIndex].Value); // Obtener ID del partido seleccionado

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Partidos WHERE ID_Partido = @ID_Partido";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID_Partido", idPartido);

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

            CargarPartidos(); // Recargar los datos
        }
    }
}
