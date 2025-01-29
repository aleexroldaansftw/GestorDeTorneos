using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Gestor_Torneos.Vistas
{
    public partial class Reportes : System.Web.UI.Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Opcional: Inicialización o mensajes
            }
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            int tipoReporte = Convert.ToInt32(ddlReporte.SelectedValue);

            switch (tipoReporte)
            {
                case 1:
                    GenerarReporteTorneosYEquipos();
                    break;
                case 2:
                    GenerarReportePartidosYResultados();
                    break;
                case 3:
                    GenerarReporteEstadisticasEquipos();
                    break;
                default:
                    gvReporte.DataSource = null;
                    gvReporte.DataBind();
                    Response.Write("<script>alert('Por favor, seleccione un tipo de reporte válido.');</script>");
                    break;
            }
        }

        private void GenerarReporteTorneosYEquipos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT t.Nombre AS Torneo, e.Nombre AS Equipo
                                 FROM Torneos t
                                 INNER JOIN Equipos e ON t.ID_Torneo = e.ID_Torneo";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    adapter.Fill(dataTable);
                    gvReporte.DataSource = dataTable;
                    gvReporte.DataBind();
                    ViewState["ReporteData"] = dataTable; // Guardar datos para exportación
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error al generar el reporte: {ex.Message}');</script>");
                }
            }
        }

        private void GenerarReportePartidosYResultados()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT t.Nombre AS Torneo, p.Fecha, e1.Nombre AS Equipo1, e2.Nombre AS Equipo2, p.Resultado
                                 FROM Partidos p
                                 INNER JOIN Torneos t ON p.ID_Torneo = t.ID_Torneo
                                 INNER JOIN Equipos e1 ON p.ID_Equipo1 = e1.ID_Equipo
                                 INNER JOIN Equipos e2 ON p.ID_Equipo2 = e2.ID_Equipo";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    adapter.Fill(dataTable);
                    gvReporte.DataSource = dataTable;
                    gvReporte.DataBind();
                    ViewState["ReporteData"] = dataTable; // Guardar datos para exportación
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error al generar el reporte: {ex.Message}');</script>");
                }
            }
        }

        private void GenerarReporteEstadisticasEquipos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT t.Nombre AS Torneo, e.Nombre AS Equipo, es.Puntos, es.Victorias, es.Derrotas
                                 FROM Estadisticas es
                                 INNER JOIN Equipos e ON es.ID_Equipo = e.ID_Equipo
                                 INNER JOIN Torneos t ON e.ID_Torneo = t.ID_Torneo";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    adapter.Fill(dataTable);
                    gvReporte.DataSource = dataTable;
                    gvReporte.DataBind();
                    ViewState["ReporteData"] = dataTable; // Guardar datos para exportación
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error al generar el reporte: {ex.Message}');</script>");
                }
            }
        }

        protected void btnExportarPDF_Click(object sender, EventArgs e)
        {
            DataTable dataTable = ViewState["ReporteData"] as DataTable;

            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                Response.Write("<script>alert('No hay datos para exportar.');</script>");
                return;
            }

            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 20f, 20f);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();

                // Título del reporte
                pdfDoc.Add(new Paragraph("Reporte Generado"));
                pdfDoc.Add(new Paragraph(" "));

                // Tabla del reporte
                PdfPTable pdfTable = new PdfPTable(dataTable.Columns.Count);
                pdfTable.WidthPercentage = 100;

                // Agregar encabezados
                foreach (DataColumn column in dataTable.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName));
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    pdfTable.AddCell(cell);
                }

                // Agregar datos
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (var cellValue in row.ItemArray)
                    {
                        pdfTable.AddCell(cellValue.ToString());
                    }
                }

                pdfDoc.Add(pdfTable);
                pdfDoc.Close();

                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Reporte.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
            }
        }
    }
}
