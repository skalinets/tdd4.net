<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Web.Mvc.HandleErrorInfo>" %>

<asp:Content ID="errorTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Ошибка
</asp:Content>

<asp:Content ID="errorContent" ContentPlaceHolderID="MainContent" runat="server">
<h1>ОЙ!</h1>
<div style="padding-bottom:300px">
    <p>
        По этой ссылке ничего нет. Вполне возможно, что вы ожидали увидеть здесь что-то другое, но тут все-таки ничего нет. Может ссылка неправильная или что-то где-то сломалось. 
        Если вы считаете, что здесь вместо этого сообщения должно быть что-то другое, свяжитесь пожалуйста с нами. Мы обязательно разберемся и сообщим вам.
    </p>
    </div>
</asp:Content>
