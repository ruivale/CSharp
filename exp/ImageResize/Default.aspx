<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
        <asp:Button ID="btnSubmit" runat="server" Text="Upload" OnClick="btnSubmit_Click" />
        <br />
        <br />
        Before<br />
        <asp:Image ID="imgBefore" runat="server"  />
        <br />
        <br />
        <br />
        <br />
        <br />
        After<br />
        <canvas id="canasp" width="100" height="100" runat="server"> 
        </canvas><br /> 
        <asp:Image ID="imgAfter" runat="server" />
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
