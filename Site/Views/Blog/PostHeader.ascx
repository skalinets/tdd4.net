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
        <%:Html.ActionLink(Model.Title, "Post", new { postID = Model.ID })%><br/>
        
    </span>
</h3>
<a href="<%=Url.Action("Post", new { postID = Model.ID })%>#disqus_thread" data-disqus-identifier="<%= Model.ID%>"></a>
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
