<%@ Page Title="Diagrama de Torneo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DiagramaTorneo.aspx.cs" Inherits="Gestor_Torneos.Vistas.DiagramaTorneo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="text-align: center; color: white;">Diagrama del Torneo</h1>

    <div style="display: flex; justify-content: center; margin-top: 40px;">
        <div style="background-color: #1e1e1e; padding: 20px; border-radius: 12px; box-shadow: 0 0 10px rgba(255,255,255,0.1);">

            <table style="border-collapse: separate; border-spacing: 40px 20px;">
                <tr>
                    <td><asp:Button runat="server" Text="+" CssClass="btn btn-celda" /></td>
                    <td rowspan="2"><asp:Button runat="server" Text="+" CssClass="btn btn-celda" /></td>
                    <td rowspan="4"><asp:Button runat="server" Text="+" CssClass="btn btn-celda" /></td>
                    <td rowspan="8"><asp:Button runat="server" Text="🏆" CssClass="btn btn-celda" /></td>
                    <td rowspan="4"><asp:Button runat="server" Text="+" CssClass="btn btn-celda" /></td>
                    <td rowspan="2"><asp:Button runat="server" Text="+" CssClass="btn btn-celda" /></td>
                    <td><asp:Button runat="server" Text="+" CssClass="btn btn-celda" /></td>
                </tr>
                <tr>
                    <td><asp:Button runat="server" Text="+" CssClass="btn btn-celda" /></td>
                    <td><asp:Button runat="server" Text="+" CssClass="btn btn-celda" /></td>
                </tr>
                <tr>
                    <td><asp:Button runat="server" Text="+" CssClass="btn btn-celda" /></td>
                    <td rowspan="2"><asp:Button runat="server" Text="+" CssClass="btn btn-celda" /></td>
                    <td rowspan="2"><asp:Button runat="server" Text="+" CssClass="btn btn-celda" /></td>
                    <td><asp:Button runat="server" Text="+" CssClass="btn btn-celda" /></td>
                </tr>
                <tr>
                    <td><asp:Button runat="server" Text="+" CssClass="btn btn-celda" /></td>
                    <td><asp:Button runat="server" Text="+" CssClass="btn btn-celda" /></td>
                </tr>
            </table>

            <br />
            <div style="text-align: center; margin-top: 30px;">
                <asp:Button runat="server" Text="Guardar Cambios" CssClass="btn btn-white" />
                <asp:Button runat="server" Text="Cancelar" CssClass="btn btn-white" />
            </div>

        </div>
    </div>

    <style>
        .btn-celda {
            width: 80px;
            height: 40px;
            background-color: white;
            color: black;
            font-size: 1.2rem;
            border: none;
            border-radius: 8px;
        }

        .btn-celda:hover {
            background-color: #e0e0e0;
        }

        .btn-white {
            background-color: white;
            color: black;
            border: none;
            padding: 10px 20px;
            margin: 10px;
            border-radius: 8px;
        }

        .btn-white:hover {
            background-color: #e0e0e0;
        }
    </style>
</asp:Content>
