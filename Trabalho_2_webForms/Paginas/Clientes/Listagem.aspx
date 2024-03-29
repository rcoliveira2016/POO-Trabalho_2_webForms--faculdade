﻿<%@ Page Title="Listagem Cliente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listagem.aspx.cs" Inherits="Trabalho_2_webForms.Paginas.Clientes.Listagem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset class="titulo-pagina">
        <legend><%: Title %></legend>
        <div class="row">
            <div class="col-12">
                <a runat="server" class="btn btn-btn-default" href="~/Paginas/Clientes/Cadastro.aspx">Novo Cliente</a>
            </div>
        </div>
        <asp:GridView ID="grdDados" 
            runat="server" 
            AutoGenerateColumns="false" 
            AutoGenerateDeleteButton="true"
            AutoGenerateEditButton="true"
            OnRowDeleting="grdDados_RowDeleting" 
            OnRowEditing="grdDados_RowEditing"
            CssClass="table table-striped table-bordered">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Codigo" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="DataNascimento" HeaderText="Data Nascimento" />
                <asp:BoundField DataField="Endereco" HeaderText="Endereço" />
                <asp:BoundField DataField="Telefone" HeaderText="Telefone" />
            </Columns>
        </asp:GridView>
    </fieldset>
</asp:Content>
