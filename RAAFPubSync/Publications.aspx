<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Publications.aspx.cs" Inherits="RAAFPubSync.Publications" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RAAF Publications Sync</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>        
            Select publication from the list below:
        </h2>
        
        <p>        
            <asp:Button ID="getAIPAB" Text="Get AIPAB" OnClick="GetAIPAB_Click" runat="server" />
        </p>
        <p>        
            <asp:Button ID="getFIHA" Text="Get FIHA" OnClick="GetFIHA_Click" runat="server" />
        </p>      
        <p>        
            <asp:Button ID="getGPA" Text="Get GPA" OnClick="GetGPA_Click" runat="server" />
        </p>        
        <p>
            <h3>Download Status Logging</h3>
            <asp:Label runat="server" ID="statusMessage" name="statusMessage"></asp:Label>
        </p>              
    </div>
    </form>
</body>
</html>
