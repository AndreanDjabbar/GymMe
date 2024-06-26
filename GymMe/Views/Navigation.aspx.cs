﻿using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
    public partial class Navigation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user_cookie"] == null && Session["user"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                string id = "";
                if (Session["user"] != null)
                {
                    id = Session["user"].ToString();
                }
                if (Request.Cookies["user_cookie"] != null)
                {
                    id = Request.Cookies["user_cookie"].Value;

                }
                string role = UserRepository.GetUserRole(id);
                if (role == "Admin")
                {
                    AdminChoice.Visible = true;
                }
                else if (role == "Customer")
                {
                    CustomerChoice.Visible = true;
                }
            }
        }

        protected void LinkButtonHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }

        protected void LinkButtonLogout_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["user_cookie"] != null)
            {
                HttpCookie userCookie = new HttpCookie("user_cookie");
                userCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(userCookie);
            }
            else
            {
                Session.Clear();
                Session.Abandon();
            }
            Response.Redirect("login.aspx");
        }

        protected void LinkButtonProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("profile.aspx");
        }

        protected void LinkButtonManageSup_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageSupplement.aspx");
        }

        protected void LinkButtonOrderSup_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderSupplement.aspx");
        }

        protected void LinkButtonHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("History.aspx");
        }

        protected void LinkButtonTransactionQueue_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransactionQueue.aspx");
        }

        protected void LinkButtonTransactionReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransactionReport.aspx");
        }

        protected void LinkButtonTransactionReport_Click1(object sender, EventArgs e)
        {
            Response.Redirect("TransactionReport.aspx");
        }
    }
}