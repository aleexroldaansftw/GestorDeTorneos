<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Gestor_Torneos.Vistas.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Generar Reportes</h1>

    <div style="width: 400px; margin: auto;">
        <asp:Label Text="Seleccionar Tipo de Reporte:" AssociatedControlID="ddlReporte" runat="server" />
        <asp:DropDownList ID="ddlReporte" runat="server" CssClass="form-control">
            <asp:ListItem Text="Torneos y Equipos" Value="1" />
            <asp:ListItem Text="Partidos y Resultados" Value="2" />
            <asp:ListItem Text="Estadísticas de Equipos" Value="3" />
        </asp:DropDownList><br />

        <asp:Button ID="btnGenerar" runat="server" Text="Generar Reporte" OnClick="btnGenerar_Click" CssClass="btn btn-primary" />
        <asp:Button ID="btnExportarPDF" runat="server" Text="Exportar a PDF" OnClick="btnExportarPDF_Click" CssClass="btn btn-secondary" />
    </div>

    <div id="reporteResultado" style="margin-top: 20px;">
        <asp:GridView ID="gvReporte" runat="server" AutoGenerateColumns="True" CssClass="table table-striped" />
    </div>
</asp:Content>
