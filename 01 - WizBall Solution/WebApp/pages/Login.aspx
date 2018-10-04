<%@ Page Title="" Language="C#" MasterPageFile="~/pages/CredMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp.pages.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <img class="mb-4" src="../resources/imgs/favicon.jpg" alt="" width="72" height="72" />
    <h1 class="h3 mb-3 font-weight-normal">Please sign in</h1>
    <label for="inputEmail" class="sr-only">Email address</label>
    <asp:TextBox TextMode="SingleLine" CssClass="form-control" ClientIDMode="Static" ID="inputUsername" runat="server" placeholder="Username" required="" autofocus="" AutoCompleteType="DisplayName"></asp:TextBox>
    <label for="inputPassword" class="sr-only">Password</label>
    <asp:TextBox TextMode="Password" CssClass="form-control" ClientIDMode="Static" ID="inputPassword" runat="server" placeholder="Password" required=""></asp:TextBox>
    <div class="checkbox mb-3">
        <label>
            <asp:CheckBox ID="RemSession" runat="server" />
            Remember me
            <br />
            <style class="cp-pen-styles">
                html, body {
                    height: 100%;
                }

                body {
                    display: grid;
                    font-family: "Open Sans", sans-serif;
                    font-size: 16px;
                    color: #223254;
                }

                .cbx {
                    margin: auto;
                    -webkit-user-select: none;
                    user-select: none;
                    cursor: pointer;
                }

                    .cbx span {
                        display: inline-block;
                        vertical-align: middle;
                        transform: translate3d(0, 0, 0);
                    }

                        .cbx span:first-child {
                            position: relative;
                            width: 18px;
                            height: 18px;
                            border-radius: 3px;
                            transform: scale(1);
                            vertical-align: middle;
                            border: 1px solid #9098A9;
                            transition: all 0.2s ease;
                        }

                            .cbx span:first-child svg {
                                position: absolute;
                                top: 3px;
                                left: 2px;
                                fill: none;
                                stroke: #FFFFFF;
                                stroke-width: 2;
                                stroke-linecap: round;
                                stroke-linejoin: round;
                                stroke-dasharray: 16px;
                                stroke-dashoffset: 16px;
                                transition: all 0.3s ease;
                                transition-delay: 0.1s;
                                transform: translate3d(0, 0, 0);
                            }

                            .cbx span:first-child:before {
                                content: "";
                                width: 100%;
                                height: 100%;
                                background: #506EEC;
                                display: block;
                                transform: scale(0);
                                opacity: 1;
                                border-radius: 50%;
                            }

                        .cbx span:last-child {
                            padding-left: 8px;
                        }

                    .cbx:hover span:first-child {
                        border-color: #506EEC;
                    }

                .inp-cbx:checked + .cbx span:first-child {
                    background: #506EEC;
                    border-color: #506EEC;
                    animation: wave 0.4s ease;
                }

                    .inp-cbx:checked + .cbx span:first-child svg {
                        stroke-dashoffset: 0;
                    }

                    .inp-cbx:checked + .cbx span:first-child:before {
                        transform: scale(3.5);
                        opacity: 0;
                        transition: all 0.6s ease;
                    }

                @keyframes wave {
                    50% {
                        transform: scale(0.9);
                    }
                }
            </style>

            <input class="inp-cbx" id="cbx" type="checkbox" style="display: none;" />
            <label class="cbx" for="cbx">
                <span>
                    <svg width="12px" height="10px" viewbox="0 0 12 10">
                        <polyline points="1.5 6 4.5 9 10.5 1"></polyline>
                    </svg></span><span>CodePenChallenge</span></label>
            <!--<asp:PasswordRecovery runat="server"></asp:PasswordRecovery>-->
    </div>
    <br />

    <asp:Label Text="Don't have an Account? " runat="server" />
    <asp:HyperLink ID="RegHL" Text="Sign Up!" runat="server" />

    <br />

    <asp:Label Text="Forgot your credentials? " runat="server" />
    <asp:HyperLink ID="RecPWHL" Text="Recover them here!" runat="server" />

    <br />
    <asp:HyperLink NavigateUrl="navigateurl" runat="server" />
    <p class="mt-5 mb-3 text-muted">© 2017-2018</p>
</asp:Content>
