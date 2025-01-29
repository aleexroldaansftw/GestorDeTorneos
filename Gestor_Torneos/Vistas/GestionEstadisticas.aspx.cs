using System;
using System.Data;
using System.Data.SqlClient;

namespace Gestor_Torneos.Vistas
{
    public partial class GestionEstadisticas : System.Web.UI.Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTorneos();
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

        protected void ddlTorneo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idTorneo = Convert.ToInt32(ddlTorneo.SelectedValue);

            if (idTorneo > 0)
            {
                CargarEstadisticas(idTorneo);
            }
            else
            {
                gvEstadisticas.DataSource = null;
                gvEstadisticas.DataBind();
            }
        }

        private void CargarEstadisticas(int idTorneo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT e.Nombre AS Equipo, es.Puntos, es.Victorias, es.Derrotas
                                 FROM Estadisticas es
                                 INNER JOIN Equipos e ON es.ID_Equipo = e.ID_Equipo
                                 WHERE e.ID_Torneo = @ID_Torneo";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID_Torneo", idTorneo);

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    gvEstadisticas.DataSource = dataTable;
                    gvEstadisticas.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error al cargar las estadísticas: {ex.Message}');</script>");
                }
            }
        }
    }
}
