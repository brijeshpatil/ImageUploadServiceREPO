<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="StoreImageServiceApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Inserting images into databse and displaying images with gridview</title>
    <style type="text/css">
        .Gridview
        {
            font-family: Verdana;
            font-size: 10pt;
            font-weight: normal;
            color: black;
            width: 500px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Image Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtImageName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Upload Image:
                    </td>
                    <td>
                        <asp:FileUpload ID="fileuploadImage" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:GridView ID="gvImages" CssClass="Gridview" runat="server" AutoGenerateColumns="False"
                HeaderStyle-BackColor="#7779AF" HeaderStyle-ForeColor="white">
                <Columns>
                    <asp:BoundField HeaderText="Image Name" DataField="imagename" />
                    <asp:TemplateField HeaderText="uimage">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# "ImageHandler.ashx?ImID="+ Eval("ImageID") %>' Height="150px" Width="150px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
