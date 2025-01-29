<%@ Page Title="Agregar Partido" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarPartido.aspx.cs" Inherits="Gestor_Torneos.Vistas.AgregarPartido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Agregar Partido</h1>
    <div style="width: 400px; margin: auto;">
        <asp:Label Text="Seleccionar Torneo:" AssociatedControlID="ddlTorneo" runat="server" />
        <asp:DropDownList ID="ddlTorneo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTorneo_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList><br />

        <asp:Label Text="Seleccionar Equipo 1:" AssociatedControlID="ddlEquipo1" runat="server" />
        <asp:DropDownList ID="ddlEquipo1" runat="server" CssClass="form-control"></asp:DropDownList><br />

        <asp:Label Text="Seleccionar Equipo 2:" AssociatedControlID="ddlEquipo2" runat="server" />
        <asp:DropDownList ID="ddlEquipo2" runat="server" CssClass="form-control"></asp:DropDownList><br />

        <asp:Label Text="Fecha del Partido:" AssociatedControlID="txtFecha" runat="server" />
        <asp:TextBox ID="txtFecha" runat="server" TextMode="DateTimeLocal" CssClass="form-control" /><br />

        <asp:Label Text="Resultado (Opcional):" AssociatedControlID="txtResultado" runat="server" />
        <asp:TextBox ID="txtResultado" runat="server" CssClass="form-control" /><br />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" />
    </div>
</asp:Content>
