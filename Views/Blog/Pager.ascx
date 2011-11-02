<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Site.Models.PagerModel>" %>
<ul class="pager">
    <%foreach (var item in Model.Items)
      {
          if (item.Item2 == Model.ShowFrom)
          {%>
    <li class="current">
        <%:Html.ActionLink(item.Item1, "Index", new {startFrom = item.Item2})%></li>
    <%
       }
       else
       {%>
        <li>
        <%:Html.ActionLink(item.Item1, "Index", new {startFrom = item.Item2})%></li>
    <%
       }
   }%>
</ul>
