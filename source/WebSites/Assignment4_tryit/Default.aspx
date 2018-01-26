<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Xml_operations" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            XML Operations<br />
            <br />
            5.1 Verification<br />
            <br />
            Enter the path for XML file<br />
            <asp:TextBox ID="xmlFile" runat="server" Width="420px"></asp:TextBox>
            <br />
            Enter the path of XSD file<br />
            <asp:TextBox ID="xsdFile" runat="server" Width="420px"></asp:TextBox>
            <br />
            <asp:Button ID="xmlVerifyBtn" runat="server" OnClick="xmlVerifyBtn_Click" Text="Verify" />
            <br />
            <br />
            (Default is set to : <a href="http://www.public.asu.edu/~srpate19/Movies.xml">http://www.public.asu.edu/~srpate19/Movies.xml</a> and <a href="http://www.public.asu.edu/~srpate19/Movies.xsd">http://www.public.asu.edu/~srpate19/Movies.xsd</a> )<br />
            <br />
            <strong> <asp:Label ID="result1" runat="server" Text="(Output)"></asp:Label> </strong>
            <br />
            <br />
            <br />
            5.2 Searching 
            <br />
            Enter the path for XML file<br />
            <asp:TextBox ID="xmlFileSearch" runat="server" Width="420px"></asp:TextBox>
            <br />
            Enter the keyword to search:<br />
            <asp:TextBox ID="keyword" runat="server" Height="29px" Width="200px"></asp:TextBox>
            <br />
            <asp:Button ID="xmlSearchBtn" runat="server" OnClick="xmlSearchBtn_Click" Text="Search" />
            <br />
            <br />
            (Default is set to : <a href="http://www.public.asu.edu/~srpate19/Movies.xml">http://www.public.asu.edu/~srpate19/Movies.xml</a> and &quot;Inside Out&quot;)<br />
            <br /><br />

            <strong><asp:Label ID="result2" runat="server" Text="(Output)"></asp:Label></strong>
        </div>
    </form>
</body>
</html>
