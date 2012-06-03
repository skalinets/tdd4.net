<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Site.DAL.Post>" %>

<%
    var text = Model.Text;
    bool shouldBeTruncated = text.Contains("<!--more-->");
    text.%>

