<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AllowanceSavingsSimulatorWebpartUserControl.ascx.cs" Inherits="Jondu.Skandia.Simulators.UI.AllowanceSavingsSimulatorWebpart.AllowanceSavingsSimulatorWebpartUserControl" %>
<SharePoint:CssLink runat="server" ID="cssstyle" />
<SharePoint:CssRegistration Name="/_layouts/15/INC/Jondu.Skandia.Simulators/css/allowance-savings.css" runat="server" />
<div id="allowanceSavingsUserControlContainer" runat="server">
    <div class="simulador" data-bind="visible: Step1Visibility">
        <div class="content">
            <img class="titulo1" src="/_layouts/15/INC/Jondu.Skandia.Simulators/img/titulo1.png" />
            <img src="/_layouts/15/INC/Jondu.Skandia.Simulators/img/first.png" width="275" height="76" />
            <a href="javascript:void(0);" data-bind="click: ShowSimulator">
                <div class="btn-simular">
                </div>
            </a>
        </div>
        <!--content-->
    </div>
    <div class="simulador2" data-bind="visible: Step2Visibility">
        <div class="content2">
            <asp:DropDownList runat="server" ID="ddlSavings" DataTextField="Title" DataValueField="SavingsRate"
                data-bind="value: Rentability" class="text-form" AppendDataBoundItems="true">
                <asp:ListItem Text="[Seleccione una meta de ahorro]" Value="" />
            </asp:DropDownList>            
            <input class="text-form corto" placeholder="¿Valor de su meta? ($)" name="otro" type="text" data-bind="value: AimDesired">
            <input class="text-form corto" placeholder="Meses para lograrlo" name="otro" type="text" data-bind="value: NumberMonth">
        </div>
        <a href="javascript:void(0);" data-bind="click: Submit">
            <div class="btn-simular">
            </div>
        </a>



    </div>
    <div class="simulador3" data-bind="visible: Step3Visibility">
        <div class="content">

            <h1>Para lograr su meta, debe ahorrar <strong data-bind="text: Savings">$99.000.000</strong> durante <strong><span data-bind="    text: NumberMonth">18</span> meses</strong></h1>
            <h3>Permítanos ser parte de su proyecto</h3>

        </div>
        <div class="menu-inf">
            <div class="box-menu"><a href="javascript:void(0)" data-bind="click: Chat">Chat</a></div>
            <div class="box-menu"><a href="javascript:void(0)" data-bind="click: Schedule">Programar llamada</a></div>
            <div class="box-menu"><a href="javascript:void(0)" data-bind="click: Call">Llamar</a></div>
            <div class="box-menu selected"><a href="javascript:void(0)" data-bind="click: ShowSimulator">Simular nuevamente</a></div>
        </div>
    </div>
</div>
