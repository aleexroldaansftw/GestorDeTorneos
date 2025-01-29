<%@ Page Title="Editar Equipo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarEquipo.aspx.cs" Inherits="Gestor_Torneos.Vistas.EditarEquipo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Editar Equipo</h1>
    <div style="width: 400px; margin: auto;">
        <asp:Label Text="Nombre del Equipo:" AssociatedControlID="txtNombre" runat="server" />
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" /><br />

        <asp:Label Text="Seleccionar Torneo:" AssociatedControlID="ddlTorneo" runat="server" />
        <asp:DropDownList ID="ddlTorneo" runat="server" CssClass="form-control"></asp:DropDownList><br />

        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" CssClass="btn btn-success" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" />
    </div>
</asp:Content>
