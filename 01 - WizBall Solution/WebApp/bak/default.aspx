<%@ Page Title="" Language="C#" MasterPageFile="~/pages/master.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApp.pages._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="MatchRepeater" runat="server">
        <ItemTemplate>
            <section id="Matches">
                <section id="m-a-n">
                    <div class="container">
                        <div class="col-6">
                            <div class="match"  style="
                                            background-color: red; /* for browsers that do not support gradients */
                                        background-image: linear-gradient(to right, red , yellow); /* standard syntax (must be last) */">
                                <div class="m-result">
                                    <div class="logo-club col-3">
                                        <img src="../resources/imgs/<%# DataBinder.Eval(Container.DataItem, "HomeTeamFlag") %>.png" alt="" />
                                    </div>
                                    <span class="result col-6"><%# DataBinder.Eval(Container.DataItem, "ScoreHomeTeam") %> <b>:</b> <%# DataBinder.Eval(Container.DataItem, "ScoreAwayTeam") %></span>
                                    <div class="logo-club col-3">
                                        <img src="../resources/imgs/<%# DataBinder.Eval(Container.DataItem, "AwayTeamFlag") %>.png" alt="" />
                                    </div>
                                    <div class="club-name col-12">
                                        <span class="col-3"><%# DataBinder.Eval(Container.DataItem, "HomeTeamName") %></span>
                                        <div class="match-name col-6">
                                            <%# DataBinder.Eval(Container.DataItem, "CompetitionName") %>
                                            <br>
                                            <%# DataBinder.Eval(Container.DataItem, "MatchStage") %>
                                            <br>
                                            <b><%# DataBinder.Eval(Container.DataItem, "MatchDate") %></b>
                                        </div>
                                        <span class="col-3"><%# DataBinder.Eval(Container.DataItem, "AwayTeamName") %></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </section>
        </ItemTemplate>
    </asp:Repeater>


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
