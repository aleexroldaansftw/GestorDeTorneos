<%@ Page Title="Gestión de Torneos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionTorneos.aspx.cs" Inherits="Gestor_Torneos.Vistas.GestionTorneos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Gestión de Torneos</h1>
    <asp:Button ID="btnAddTorneo" runat="server" Text="Agregar Torneo" OnClick="btnAddTorneo_Click" CssClass="btn btn-primary" />

    <div style="margin-top: 20px;">
        <asp:GridView ID="gvTorneos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
            OnRowEditing="gvTorneos_RowEditing" OnRowDeleting="gvTorneos_RowDeleting" DataKeyNames="ID_Torneo">
            <Columns>
                <asp:BoundField DataField="ID_Torneo" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                <asp:BoundField DataField="FechaInicio" HeaderText="Fecha Inicio" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="FechaFin" HeaderText="Fecha Fin" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
