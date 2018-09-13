﻿<%@ Page Title="" Language="C#" MasterPageFile="~/pages/master.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApp.pages._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="form-group">
            <div class="searchable-container">
                <asp:Panel ID="compPanel" ClientIDMode="Static" runat="server">
                    <div class="items col-xs-5 col-sm-5 col-md-3 col-lg-3">
                        <div class="info-block block-info clearfix">
                            <div data-toggle="buttons" class="btn-group bizmoduleselect">
                                <label class="btn btn-default">
                                    <div class="bizcontent">
                                        <asp:CheckBox Text="All" Checked="true" AutoPostBack="true" ID="AllCompsCB" ClientIDMode="Static" runat="server" />
                                    </div>
                                </label>
                            </div>
                        </div>
                    </div>
                    <asp:Repeater ID="compRep" runat="server" ClientIDMode="Static">
                        <ItemTemplate>
                            <div class="items col-xs-5 col-sm-5 col-md-3 col-lg-3">
                                <div class="info-block block-info clearfix">
                                    <div data-toggle="buttons" class="btn-group bizmoduleselect">
                                        <label class="btn btn-default">
                                            <div class="bizcontent">
                                                <asp:HiddenField Value='<%# DataBinder.Eval(Container.DataItem, "ID") %>' ID='HidFieldComp' runat="server" />
                                                <asp:CheckBox value='<%# DataBinder.Eval(Container.DataItem, "ID")%>' name="var_id[]" ID='CompCB' runat="server" />
                                                <span class="glyphicon glyphicon-ok glyphicon-lg"></span>
                                                <h5><%# DataBinder.Eval(Container.DataItem, "Name") %></h5>
                                            </div>
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </asp:Panel>
            </div>
        </div>
    </div>
    <asp:Button Text="Apply Competition Filters" ID="CompFilterBtn" ClientIDMode="Static" OnClick="CompFilterBtn_Click" runat="server" />
    <div class="container ">
        <asp:Panel ID="frmMain" runat="server"></asp:Panel>
    </div>
    <script type="text/javascript">

        $(function () {
            $('#search').on('keyup', function () {
                var pattern = $(this).val();
                $('.searchable-container .items').hide();
                $('.searchable-container .items').filter(function () {
                    return $(this).text().match(new RegExp(pattern, 'i'));
                }).show();
            });
        });
    </script>

</asp:Content>
