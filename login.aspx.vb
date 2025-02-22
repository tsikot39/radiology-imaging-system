﻿Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Data
Imports System.Data.Sql
Imports System.Drawing
Imports System.Web.Security
Imports System.Collections

Public Class login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        modalpopup.Show()
    End Sub

    Protected Sub ValidateUser(sender As Object, e As EventArgs)
        Dim userId As Integer = 0
        Dim constr As String = ConfigurationManager.ConnectionStrings("rid").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("Validate_User")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Username", Login1.UserName)
                cmd.Parameters.AddWithValue("@Password", Login1.Password)
                cmd.Connection = con
                con.Open()
                userId = Convert.ToInt32(cmd.ExecuteScalar())
                con.Close()
            End Using
            Select Case userId
                Case -1
                    Login1.FailureText = "Username and/or password is incorrect."
                    Exit Select
                Case -2
                    Login1.FailureText = "Account has not been activated."
                    Exit Select
                Case Else
                    FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet)
                    Exit Select
            End Select
        End Using
    End Sub

End Class