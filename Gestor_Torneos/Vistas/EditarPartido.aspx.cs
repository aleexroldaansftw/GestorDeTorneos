using System;
using System.Data.SqlClient;

namespace Gestor_Torneos.Vistas
{
    public partial class EditarPartido : System.Web.UI.Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTorneos();
                CargarDatosPartido();
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

        private void CargarDatosPartido()
        {
            int idPartido = Convert.ToInt32(Request.QueryString["id"]);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ID_Torneo, ID_Equipo1, ID_Equipo2, Fecha, Resultado FROM Partidos WHERE ID_Partido = @ID_Partido";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID_Partido", idPartido);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        ddlTorneo.SelectedValue = reader["ID_Torneo"].ToString();
                        txtFecha.Text = Convert.ToDateTime(reader["Fecha"]).ToString("yyyy-MM-ddTHH:mm");
                        txtResultado.Text = reader["Resultado"].ToString();
                        CargarEquipos(Convert.ToInt32(reader["ID_Torneo"]), Convert.ToInt32(reader["ID_Equipo1"]), Convert.ToInt32(reader["ID_Equipo2"]));
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error al cargar los datos del partido: {ex.Message}');</script>");
                }
            }
        }

        private void CargarEquipos(int idTorneo, int idEquipo1, int idEquipo2)
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
                    ddlEquipo1.SelectedValue = idEquipo1.ToString();

                    reader.Close();

                    SqlDataReader reader2 = command.ExecuteReader();
                    ddlEquipo2.DataSource = reader2;
                    ddlEquipo2.DataTextField = "Nombre";
                    ddlEquipo2.DataValueField = "ID_Equipo";
                    ddlEquipo2.DataBind();
                    ddlEquipo2.SelectedValue = idEquipo2.ToString();
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error al cargar los equipos: {ex.Message}');</script>");
                }
            }
        }

        protected void ddlTorneo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idTorneo = Convert.ToInt32(ddlTorneo.SelectedValue);

            if (idTorneo > 0)
            {
                CargarEquipos(idTorneo, 0, 0);
            }
            else
            {
                ddlEquipo1.Items.Clear();
                ddlEquipo1.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Seleccione un Equipo --", "0"));

                ddlEquipo2.Items.Clear();
                ddlEquipo2.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Seleccione un Equipo --", "0"));
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
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

            int idPartido = Convert.ToInt32(Request.QueryString["id"]);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Partidos SET ID_Torneo = @ID_Torneo, ID_Equipo1 = @ID_Equipo1, ID_Equipo2 = @ID_Equipo2, Fecha = @Fecha, Resultado = @Resultado WHERE ID_Partido = @ID_Partido";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ID_Partido", idPartido);
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
                    Response.Write($"<script>alert('Error al actualizar el partido: {ex.Message}');</script>");
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionPartidos.aspx");
        }
    }
}
