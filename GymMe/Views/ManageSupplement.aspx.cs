﻿using GymMe.Handler;
using GymMe.Models;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
    public partial class ManageSupplement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user_cookie"] == null && Session["user"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                string id = "";
                if (Request.Cookies["user_cookie"] != null)
                {
                    id = Request.Cookies["user_cookie"].Value;
                }
                if (Session["user"] != null)
                {
                    id = Session["user"].ToString();
                }
                string role = UserRepository.GetUserRole(id);
                if (role == "Customer")
                {
                    Response.Redirect("Navigation.aspx");
                }
                else
                {
                    GridViewSup.DataSource = ProductRepository.GetSupplements();
                    GridViewSup.DataBind();
                }
            }
        }

        protected void LinkButtonNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("Navigation.aspx");
        }

        protected void LinkButtonInsertSup_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertSupplement.aspx");
        }

        protected void GridViewSup_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridViewSup.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            ProductHandler.DeleteSupplement(id);
            Response.Redirect("ManageSupplement.aspx");
        }

        protected void GridViewSup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridViewSup_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = GridViewSup.Rows[e.NewEditIndex];
            string id = row.Cells[0].Text;
            Response.Redirect("UpdateSupplement.aspx?ID=" + id);
        }

        protected void LinkButtonInsertSupType_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertSupplementType.aspx");
        }
    }
}