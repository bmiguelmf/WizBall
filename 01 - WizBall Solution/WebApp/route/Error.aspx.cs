using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.pages.Misc
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            switch (status)
            {
                // https://kb.iu.edu/d/bfrc
                // http://www.eeemo.net/
                // https://www.tutorialrepublic.com/html-reference/http-status-codes.php

                case 200:
                    // Ok
                    ErrTitle.InnerText = "Erro";
                    ErrBody.InnerHtml = "Operação concluída com sucesso";
                    break;
                case 400:
                    // Bad Request
                    break;
                case 401:
                    // Unauthorized               
                    break;
                case 403:
                    // Forbidden
                    break;
                case 404:
                    // Not Found
                    ErrTitle.InnerText = "Hum...";
                    ErrBody.InnerText = "Como assim não existe?!";
                    break;
                case 500:
                    // Internal Server Error
                    ErrBody.InnerText = "Servidores...";
                    break;
                case 501:
                    // Not Implemented
                    ErrTitle.InnerText = "Pois...";
                    ErrBody.InnerText = "Ainda não temos isso";
                    break;
                case 502:
                    // Bad Gateway
                    break;
                case 503:
                    // Out of Resources
                    ErrTitle.InnerText = "Pois...";
                    ErrBody.InnerText = "Precisamos de mais espaço";
                    break;
                case 505:
                    // HTTP Version Not Supported
                    ErrTitle.InnerText = "Pois...";
                    ErrBody.InnerHtml = "Temos de atualizar isto";
                    break;
                default:
                    if (status == -1)
                    {
                        Error_Status.InnerText = "Erro";
                        ErrTitle.InnerText = "?!...";
                        ErrBody.InnerText = "A culpa não é nossa...";
                    }
                    else
                    {
                        Response.Redirect("~/Erro");
                    }
                    break;
            }



        }
    }
}