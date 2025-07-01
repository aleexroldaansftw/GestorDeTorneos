<%@ Page Title="Agregar Equipo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarEquipo.aspx.cs" Inherits="Gestor_Torneos.Vistas.AgregarEquipo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <style>
    body {
      background-color: #121212 !important;
      color: white;
      font-family: Arial, sans-serif;
    }

    .card {
      background-color: #1e1e1e;
      padding: 30px;
      border-radius: 12px;
      width: 400px;
      margin: 80px auto;
      box-shadow: 0 0 12px rgba(255, 255, 255, 0.05);
      text-align: center;
    }

    .form-label {
      text-align: left;
      display: block;
      margin-bottom: 5px;
      font-weight: bold;
      margin-top: 20px;
    }

    .form-control {
      width: 100%;
      padding: 10px;
      background-color: #2e2e2e;
      color: white;
      border: none;
      border-radius: 6px;
      box-sizing: border-box;
    }

    .btn {
      margin-top: 25px;
      padding: 10px 20px;
      font-weight: bold;
      border-radius: 6px;
      border: none;
      cursor: pointer;
    }

    .btn-success {
      background-color: #ffffff;
      color: black;
      margin-right: 10px;
    }

    .btn-secondary {
      background-color: #444;
      color: white;
    }

    h2 {
      margin-bottom: 20px;
    }
  </style>

  <div class="card">
    <h2>Agregar Equipo</h2>

    <asp:Label Text="Nombre del Equipo: " AssociatedControlID="txtNombre" CssClass="form-label" runat="server" />
    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" /><br />

    <asp:Label Text="Seleccionar Torneo:" AssociatedControlID="ddlTorneo" CssClass="form-label" runat="server" />
    <asp:DropDownList ID="ddlTorneo" runat="server" CssClass="form-control">
        <asp:ListItem Text="Seleccione un torneo" Value="" />
    </asp:DropDownList>

    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" />
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" />
  </div>
</asp:Content>
