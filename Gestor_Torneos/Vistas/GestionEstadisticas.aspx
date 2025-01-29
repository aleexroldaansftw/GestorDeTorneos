<%@ Page Title="Gestión de Estadísticas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionEstadisticas.aspx.cs" Inherits="Gestor_Torneos.Vistas.GestionEstadisticas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Gestión de Estadísticas</h1>

    <asp:Label Text="Seleccionar Torneo:" AssociatedControlID="ddlTorneo" runat="server" />
    <asp:DropDownList ID="ddlTorneo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTorneo_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList><br />

    <div style="margin-top: 20px;">
        <asp:GridView ID="gvEstadisticas" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
            <Columns>
                <asp:BoundField DataField="Equipo" HeaderText="Equipo" />
                <asp:BoundField DataField="Puntos" HeaderText="Puntos" />
                <asp:BoundField DataField="Victorias" HeaderText="Victorias" />
                <asp:BoundField DataField="Derrotas" HeaderText="Derrotas" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
