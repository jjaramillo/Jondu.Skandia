<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AllowanceSavingsSimulatorWebpartUserControl.ascx.cs" Inherits="Jondu.Skandia.Simulators.UI.AllowanceSavingsSimulatorWebpart.AllowanceSavingsSimulatorWebpartUserControl" %>
<div id="allowanceSavingsUserControlContainer" runat="server">
    Meta: <input type="text" name="AimDesired" id="AimDesired" data-bind="value: AimDesired" />
    <br />
    Numero de Meses : <input type="text" name="NumberMonth" id="NumberMonth" data-bind="value: NumberMonth" />
    <br />
    Rentabilidad : <input type="text" name="Rentability" id="Rentability" data-bind="value: Rentability" />
    <br />
    <input type="button" name="Send" id="Send" data-bind="click: Submit" value="Enviar"/>
</div>