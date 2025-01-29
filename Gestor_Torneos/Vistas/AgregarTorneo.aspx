<%@ Page Title="Agregar Torneo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarTorneo.aspx.cs" Inherits="Gestor_Torneos.Vistas.AgregarTorneo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Agregar Torneo</h1>
    <div style="width: 400px; margin: auto;">
        <asp:Label Text="Nombre del Torneo:" AssociatedControlID="txtNombre" runat="server" />
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" /><br />

        <asp:Label Text="Tipo de Torneo:" AssociatedControlID="ddlTipo" runat="server" />
        <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control">
            <asp:ListItem Text="Deporte" Value="Deporte" />
            <asp:ListItem Text="Videojuego" Value="Videojuego" />
        </asp:DropDownList><br />

        <asp:Label Text="Fecha de Inicio:" AssociatedControlID="txtFechaInicio" runat="server" />
        <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date" CssClass="form-control" /><br />

        <asp:Label Text="Fecha de Finalización:" AssociatedControlID="txtFechaFin" runat="server" />
        <asp:TextBox ID="txtFechaFin" runat="server" TextMode="Date" CssClass="form-control" /><br />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" />
    </div>
</asp:Content>
