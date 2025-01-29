<%@ Page Title="Gestión de Partidos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionPartidos.aspx.cs" Inherits="Gestor_Torneos.Vistas.GestionPartidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Gestión de Partidos</h1>
    <asp:Button ID="btnAddPartido" runat="server" Text="Agregar Partido" OnClick="btnAddPartido_Click" CssClass="btn btn-primary" />

    <div style="margin-top: 20px;">
        <asp:GridView ID="gvPartidos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
            OnRowEditing="gvPartidos_RowEditing" OnRowDeleting="gvPartidos_RowDeleting" DataKeyNames="ID_Partido">
            <Columns>
                <asp:BoundField DataField="ID_Partido" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Torneo" HeaderText="Torneo" />
                <asp:BoundField DataField="Equipo1" HeaderText="Equipo 1" />
                <asp:BoundField DataField="Equipo2" HeaderText="Equipo 2" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
                <asp:BoundField DataField="Resultado" HeaderText="Resultado" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
