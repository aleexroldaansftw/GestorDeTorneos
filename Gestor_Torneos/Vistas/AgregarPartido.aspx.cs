using System;
using System.Data;
using System.Data.SqlClient;

namespace Gestor_Torneos.Vistas
{
    public partial class AgregarPartido : System.Web.UI.Page
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
            CargarEquipos(idTorneo);
        }

        private void CargarEquipos(int idTorneo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ID_Equipo, Nombre FROM Equipos WHERE ID_Torneo = @ID_Torneo";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID_Torneo", idTorneo);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    ddlEquipo1.DataSource = reader;
                    ddlEquipo1.DataTextField = "Nombre";
                    ddlEquipo1.DataValueField = "ID_Equipo";
                    ddlEquipo1.DataBind();
                    ddlEquipo1.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Seleccione un Equipo --", "0"));

                    reader.Close(); // Cerrar antes de hacer otra consulta

                    SqlDataReader reader2 = command.ExecuteReader();
                    ddlEquipo2.DataSource = reader2;
                    ddlEquipo2.DataTextField = "Nombre";
                    ddlEquipo2.DataValueField = "ID_Equipo";
                    ddlEquipo2.DataBind();
                    ddlEquipo2.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Seleccione un Equipo --", "0"));
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error al cargar los equipos: {ex.Message}');</script>");
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ddlTorneo.SelectedValue == "0" || ddlEquipo1.SelectedValue == "0" || ddlEquipo2.SelectedValue == "0" || string.IsNullOrWhiteSpace(txtFecha.Text))
            {
                Response.Write("<script>alert('Por favor, complete todos los campos obligatorios.');</script>");
                return;
            }

            if (ddlEquipo1.SelectedValue == ddlEquipo2.SelectedValue)
            {
                Response.Write("<script>alert('No puedes seleccionar el mismo equipo para ambos lados.');</script>");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Partidos (ID_Torneo, ID_Equipo1, ID_Equipo2, Fecha, Resultado) VALUES (@ID_Torneo, @ID_Equipo1, @ID_Equipo2, @Fecha, @Resultado)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ID_Torneo", ddlTorneo.SelectedValue);
                command.Parameters.AddWithValue("@ID_Equipo1", ddlEquipo1.SelectedValue);
                command.Parameters.AddWithValue("@ID_Equipo2", ddlEquipo2.SelectedValue);
                command.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(txtFecha.Text));
                command.Parameters.AddWithValue("@Resultado", string.IsNullOrWhiteSpace(txtResultado.Text) ? DBNull.Value.ToString() : txtResultado.Text);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    Response.Redirect("GestionPartidos.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error al guardar el partido: {ex.Message}');</script>");
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionPartidos.aspx");
        }
    }
}
