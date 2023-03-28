<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImageResize.aspx.cs" Inherits="ImageResize" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
        <br />
        <br />
        <asp:FileUpload ID="fuImage" runat="server" />
        <br />
        <br />
        Width :<asp:TextBox ID="txtWidth" runat="server"></asp:TextBox>
        <br />
        <br />
        Height :<asp:TextBox ID="txtHeight" runat="server"></asp:TextBox>
        <br />
        <br />
        Output File Name :<asp:TextBox ID="txtOutputFileName" runat="server"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" Text="Upload" OnClick="btnSubmit_Click" />
    
    </div>
    </form>
</body>
</html>
