<%@ Page Title="" Language="C#" MasterPageFile="~/pages/master.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApp.pages._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
            <section id="Matches">

                <section id="m-a-n">
        <div class="container">
            <div class="col-6">
                <div class="match">
                    <div class="m-result">
                        <div class="logo-club col-3"><img src="../resources/imgs/man.png"  alt="" /></div>
                        <span class="result col-6">0 <b>:</b> 3</span>
                        <div class="logo-club col-3"><img src="../resources/imgs/fcp.png" alt="" /></div>
                        <div class="club-name col-12">
                            <span class="col-3">Bayern</span>
                            <div class="match-name col-6">Champions League <br> Semi-final <br> <b>25 May 23:00</b></div>
                            <span class="col-3">Arsenal</span>
                        </div>
                    </div>
                </div>
                
            </div>
            
        </div>
    </section>
            </section>

    <asp:Panel ID="compPanel" ClientIDMode="Static" runat="server">
        <asp:CheckBoxList ID="compCBList" CssClass="compCBList" ClientIDMode="Static" runat="server">
           
        </asp:CheckBoxList>

    </asp:Panel>

    <asp:Repeater id="compRep" runat="server">
<ItemTemplate>
   <asp:HiddenField ID="hiddenEmail" Value=''>
</ItemTemplate>
</asp:Repeater>
   

</asp:Content>
