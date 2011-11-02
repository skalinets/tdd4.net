<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Site.DAL.Post>" %>

    <script type="text/javascript" src="../../Scripts/tinyMce/tiny_mce_gzip.js" ></script>
    <script type="text/javascript">
        tinyMCE_GZ.init(
        {
        plugins : 'style,layer,table,save,advhr,advimage,advlink,emotions,iespell,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras',
        themes : 'simple,advanced',
        languages : 'en',
        disk_cache : true,
        debug: false
    });
        </script>
<script type="text/javascript" >
    tinyMCE.init({
        mode: "textareas",
        theme: "advanced"   //(n.b. no trailing comma, this will be critical as you experiment later)
    });
</script>


    <%
        var d = new Dictionary<string, object> {{"class", "editor-control"}};
        var textAreaParams = new Dictionary<string, object>(d) {{"rows", "30"}};
        using (Html.BeginForm(null, null, FormMethod.Post, new {id = "editPost" })) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            
           <%: Html.HiddenFor(post => post.ID) %>
           <%: Html.HiddenFor(post => post.Index) %>
           <%: Html.HiddenFor(post => post.Posted) %>
           <div>Черновик: <%:Html.EditorFor(post1 => post1.IsDraft) %></div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Title) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Title, d) %>
                <%: Html.ValidationMessageFor(model => model.Title) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Text) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.Text, textAreaParams)%>
                <%: Html.ValidationMessageFor(model => model.Text) %>
            </div>
           
        </fieldset>

    <% } %>

    <ul class="control-buttons">
        <li>
            <%: Html.ActionLink("Назад", "Index") %>
        </li>
        <li><a href="#" onclick="javascript:$('#editPost').submit();"><%=ViewData["Verb"] %></a></li>
    </ul>


