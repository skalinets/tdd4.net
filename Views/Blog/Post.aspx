<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Site.DAL.Post>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%=Model.Title %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<br />
    <%:Html.ActionLink("<< Назад", "Index")%>
    <%Html.RenderPartial("PostHeader"); %>
    <%=Model.Text%>
    <%:Html.ActionLink("<< Назад", "Index")%>
</asp:Content>
