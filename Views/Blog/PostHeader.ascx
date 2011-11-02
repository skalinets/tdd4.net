<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Site.DAL.Post>" %>
<%@ Import Namespace="Site.Models" %>
<h3>
    <span class="postDate">
        <%:Model.Posted %></span> 
    <br />
    <%if (Model.IsDraft)
      {
    %>
    <span>ЧЕРНОВИК</span>
    <%
          }%>
    <span class="postTitle">
        <%= Html.ActionLink(Model.Title, "Post", new { postID = Model.ID })%></span>
</h3>
<%
      if (AuthorizationHelper.IsAdmin)
    {
%>
<ul class='control-buttons'>
    <li>
        <%:Html.ActionLink("Изменить >>", "Edit", new {postID = Model.ID})%>
    </li>
    <li>
        <%:Html.ActionLink("Удалить >>", "Delete", new {postID = Model.ID})%>
    </li>
</ul>
<% } %>
