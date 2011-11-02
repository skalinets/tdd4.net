<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Site.Models.BlogModel>" %>
<%@ Import Namespace="Site.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Последние записи
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Последние записи</h2>
        

    <%foreach (var item in Model.Posts)
    {%>
    <% Html.RenderPartial("PostHeader", item);%>
        <p>
               <%=item.BriefText%>
            <%if (item.HasMoreTag)
            {%>
                <%=Html.ActionLink("Читать дальше >>", "Post", new {postID = item.ID})%>
            <%}%>
            </p>
            <hr class="post-divider"/>
    <%}%>
    <%Html.RenderPartial("Pager", Model.PagerModel); %>
    
    <%if (AuthorizationHelper.IsAdmin)
      {%>
    <p>
        <%:Html.ActionLink("Добавить новый пост", "Create")%>
    </p>
    <%
      }
    %>
</asp:Content>
