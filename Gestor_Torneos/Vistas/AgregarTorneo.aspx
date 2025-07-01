<%@ Page Title="Agregar Torneo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarTorneo.aspx.cs" Inherits="Gestor_Torneos.Vistas.AgregarTorneo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="text-align: center; color: #fff;">Agregar Torneo</h1>

    <div style="width: 400px; margin: auto; background-color: #1e1e1e; padding: 30px; border-radius: 10px; box-shadow: 0 0 10px rgba(255,255,255,0.1); color: #fff;">
        <asp:Label Text="Nombre del Torneo:" AssociatedControlID="txtNombre" runat="server" />
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" style="background-color:#121212; color:white; border:1px solid #444;" /><br /><br />

        <asp:Label Text="Tipo de Torneo:" AssociatedControlID="ddlTipo" runat="server" />
        <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control" style="background-color:#121212; color:white; border:1px solid #444;">
            <asp:ListItem Text="Deporte" Value="Deporte" />
            <asp:ListItem Text="Videojuego" Value="Videojuego" />
        </asp:DropDownList><br /><br />

        <asp:Label Text="Fecha de Inicio:" AssociatedControlID="txtFechaInicio" runat="server" />
        <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date" CssClass="form-control" style="background-color:#121212; color:white; border:1px solid #444;" /><br /><br />

        <asp:Label Text="Fecha de Finalización:" AssociatedControlID="txtFechaFin" runat="server" />
        <asp:TextBox ID="txtFechaFin" runat="server" TextMode="Date" CssClass="form-control" style="background-color:#121212; color:white; border:1px solid #444;" /><br /><br />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"
            CssClass="btn" 
            style="background-color: white; color: black; border: none; margin-right: 10px;" />

        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"
            CssClass="btn" 
            style="background-color: white; color: black; border: none;" />
    </div>
</asp:Content>
