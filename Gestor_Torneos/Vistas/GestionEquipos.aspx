<%@ Page Title="Gestión de Equipos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionEquipos.aspx.cs" Inherits="Gestor_Torneos.Vistas.GestionEquipos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Gestión de Equipos</h1>
    <asp:Button ID="btnAddEquipo" runat="server" Text="Agregar Equipo" OnClick="btnAddEquipo_Click" CssClass="btn btn-primary" />

    <div style="margin-top: 20px;">
        <asp:GridView ID="gvEquipos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
            OnRowEditing="gvEquipos_RowEditing" OnRowDeleting="gvEquipos_RowDeleting" DataKeyNames="ID_Equipo">
            <Columns>
                <asp:BoundField DataField="ID_Equipo" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Torneo" HeaderText="Torneo" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
