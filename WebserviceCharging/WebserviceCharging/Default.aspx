<%@ Page Title="Payment Hoàng Hiệp" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebserviceCharging._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><b>Kết nối Webservice Charging</b></h1>
            </hgroup>
            <p>
                Tài liệu kỹ thuật kiểm tra kết nối
                <br />
                test : merchan_id = "7"
                <br />
                test : key_secret = "ED8325026DE38C32AC46"
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>Chúng ta có 3 loại:</h2>
    <ol class="round">
        <li class="one">
            <h3>Kết nối thẻ cào</h3>
            <p>
                <asp:Label ID="Label5" runat="server" Text="type_card" Height="30px" Width="100"></asp:Label>
                <asp:DropDownList runat="server" Height="37px" Width="212" ID="dropTypeCardConnectCard">
                    <asp:ListItem Enabled="true" Text="" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="Viettel" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Mobifone" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Vinaphone" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Gate" Value="4"></asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label6" runat="server" Height="30px" Width="20"></asp:Label>
                <asp:Label ID="Label7" runat="server" Text="Loại thẻ cào." ></asp:Label>
                <br />

                <asp:Label ID="Label8" runat="server" Text="number_card" Height="30px" Width="100"></asp:Label>
                <asp:TextBox ID="txtNumberCardConnectCard" runat="server" Text="" Height="30px" Width="200"></asp:TextBox>
                <asp:Label ID="Label9" runat="server" Height="30px" Width="20"></asp:Label>
                <asp:Label ID="Label10" runat="server" Text="Mã số thẻ cào." ></asp:Label>
                <br />

                <asp:Label ID="Label11" runat="server" Text="seri_card" Height="30px" Width="100"></asp:Label>
                <asp:TextBox ID="txtSeriCardConnectCard" runat="server" Text="" Height="30px" Width="200"></asp:TextBox>
                <asp:Label ID="Label12" runat="server" Height="30px" Width="20"></asp:Label>
                <asp:Label ID="Label13" runat="server" Text="Số serial thẻ cào" ></asp:Label>
                <br />

                <asp:Label ID="Label14" runat="server" Text="merchan_id" Height="30px" Width="100"></asp:Label>
                <asp:TextBox ID="txtMerchantIdConnectCard" runat="server" Text="" Height="30px" Width="200"></asp:TextBox>
                <asp:Label ID="Label15" runat="server" Height="30px" Width="20"></asp:Label>
                <asp:Label ID="Label16" runat="server" Text="Mã website/app client cần kết nối dịch vụ." ></asp:Label>
                <br />

                <asp:Label ID="Label17" runat="server" Text="key_secret " Height="30px" Width="100"></asp:Label>
                <asp:TextBox ID="txtSecretConnectCard" runat="server" Text="" Height="30px" Width="200"></asp:TextBox>
                <asp:Label ID="Label18" runat="server" Height="30px" Width="20"></asp:Label>
                <asp:Label ID="Label19" runat="server" Text="Khóa Secret" ></asp:Label>
                <br />
                <asp:Button ID="connectCardConnectCard" runat="server" Text="Thực hiện" OnClick="connectCard_Click" />
            </p>
            <asp:Label ID="lblWarningConnectCard" runat="server" Text="Cảnh báo request: " ForeColor="#996600"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Kết quả" Font-Size="Larger" Font-Bold="True"></asp:Label>
            <section class="result">
                <div class="connect-card">
                    - status : 
                    <asp:Label ID="lblStatusConnectCard" runat="server"  Text="" ForeColor="#CC3300"></asp:Label>
                    <br />
                    - error_code : 
                    <asp:Label ID="lblErrorCodeConnectCard" runat="server"  Text="" ForeColor="#CC3300"></asp:Label>
                    <br />
                    - message : 
                    <asp:Label ID="lblMessageConnectCard" runat="server"  Text="" ForeColor="#CC3300"></asp:Label>
                    <br />
                    - trans_id
                    <asp:Label ID="lblTransIdConnectCard" runat="server"  Text="" ForeColor="#CC3300"></asp:Label>
                    <br />
                    - amount : 
                    <asp:Label ID="lblAmountConnectCard" runat="server"  Text="" ForeColor="#CC3300"></asp:Label>
                    <br />
                </div>
             </section>
            
        </li>
        <li class="two">
            <h3>Kết nối topup</h3>
            <p>
                <asp:Label ID="Label1" runat="server" Text="type_card" Height="30px" Width="100"></asp:Label>
                <asp:DropDownList runat="server" Height="37px" Width="212" ID="dropTypeCardTopup">
                    <asp:ListItem Enabled="true" Text="" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="Viettel" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Mobifone" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Vinaphone" Value="3"></asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label3" runat="server" Height="30px" Width="20"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text="Loại thuê bao." ></asp:Label>
                <br />

                <asp:Label ID="Label39" runat="server" Text="postpaid" Height="30px" Width="100"></asp:Label>
                <asp:DropDownList runat="server" Height="37px" Width="212" ID="dropPostpaidTopup">
                    <asp:ListItem Enabled="true" Text="" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="Trả trước" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Trả sau" Value="2"></asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label40" runat="server" Height="30px" Width="20"></asp:Label>
                <asp:Label ID="Label41" runat="server" Text="Kiểu thuê bao." ></asp:Label>
                <br />

                <asp:Label ID="Label20" runat="server" Text="amount" Height="30px" Width="100"></asp:Label>
                <asp:TextBox ID="txtAmountTopup" runat="server" Text="" Height="30px" Width="200"></asp:TextBox>
                <asp:Label ID="Label21" runat="server" Height="30px" Width="20"></asp:Label>
                <asp:Label ID="Label22" runat="server" Text="Mệnh giá thẻ nạp." ></asp:Label>
                <br />

                <asp:Label ID="Label23" runat="server" Text="phone" Height="30px" Width="100"></asp:Label>
                <asp:TextBox ID="txtPhoneTopup" runat="server" Text="" Height="30px" Width="200"></asp:TextBox>
                <asp:Label ID="Label24" runat="server" Height="30px" Width="20"></asp:Label>
                <asp:Label ID="Label25" runat="server" Text="Số điện thoại cần nạp" ></asp:Label>
                <br />

                <asp:Label ID="sf" runat="server" Text="merchan_id" Height="30px" Width="100"></asp:Label>
                <asp:TextBox ID="txtMerchanIdTopup" runat="server" Text="" Height="30px" Width="200"></asp:TextBox>
                <asp:Label ID="Label27" runat="server" Height="30px" Width="20"></asp:Label>
                <asp:Label ID="Label28" runat="server" Text="Mã website/app client cần kết nối dịch vụ." ></asp:Label>
                <br />

                <asp:Label ID="Label29" runat="server" Text="key_secret " Height="30px" Width="100"></asp:Label>
                <asp:TextBox ID="txtSecretTopup" runat="server" Text="" Height="30px" Width="200"></asp:TextBox>
                <asp:Label ID="Label30" runat="server" Height="30px" Width="20"></asp:Label>
                <asp:Label ID="Label31" runat="server" Text="Khóa Secret" ></asp:Label>
                
                <br />
                <asp:Button ID="Button1" runat="server" Text="Thực hiện" OnClick="Button1_Click"  />
            </p>
            <asp:Label ID="lblWarningTopup" runat="server" Text="Cảnh báo request: " ForeColor="#996600"></asp:Label>
            <br />
            <asp:Label ID="Label33" runat="server" Text="Kết quả" Font-Size="Larger" Font-Bold="True"></asp:Label>
            <section class="result">
                <div class="connect-card">
                    - status : 
                    <asp:Label ID="lblStatusTopup" runat="server"  Text="" ForeColor="#CC3300"></asp:Label>
                    <br />
                    - error_code : 
                    <asp:Label ID="lblErrorCodeTopup" runat="server"  Text="" ForeColor="#CC3300"></asp:Label>
                    <br />
                    - message : 
                    <asp:Label ID="lblMessageTopup" runat="server"  Text="" ForeColor="#CC3300"></asp:Label>
                    <br />
                    - trans_id : 
                    <asp:Label ID="lblTransIdTopup" runat="server"  Text="" ForeColor="#CC3300"></asp:Label>
                    <br />
                </div>
             </section>
        </li>
        <li class="three">
            <h3>Kết nối mua mã thẻ</h3>
            <p>
                <asp:Label ID="Label26" runat="server" Text="type_card" Height="30px" Width="100"></asp:Label>
                <asp:DropDownList runat="server" Height="37px" Width="212" ID="dropTypeCardBuyCard">
                    <asp:ListItem Enabled="true" Text="" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="Viettel" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Mobifone" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Vinaphone" Value="3"></asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label38" runat="server" Height="30px" Width="20"></asp:Label>
                <asp:Label ID="Label42" runat="server" Text="Loại thẻ cần mua." ></asp:Label>
                <br />

                <asp:Label ID="Label43" runat="server" Text="total" Height="30px" Width="100"></asp:Label>
                <asp:DropDownList runat="server" Height="37px" Width="212" ID="dropTotalBuyCard">
                    <asp:ListItem Enabled="true" Text="" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label44" runat="server" Height="30px" Width="20"></asp:Label>
                <asp:Label ID="Label45" runat="server" Text="Số lượng thẻ mua." ></asp:Label>
                <br />

                <asp:Label ID="Label46" runat="server" Text="amount" Height="30px" Width="100"></asp:Label>
                <asp:TextBox ID="txtAmountBuyCard" runat="server" Text="" Height="30px" Width="200"></asp:TextBox>
                <asp:Label ID="Label47" runat="server" Height="30px" Width="20"></asp:Label>
                <asp:Label ID="Label48" runat="server" Text="Mệnh giá cào cần mua." ></asp:Label>
                <br />

                <asp:Label ID="Label52" runat="server" Text="merchan_id" Height="30px" Width="100"></asp:Label>
                <asp:TextBox ID="txtMerchanIdBuyCard" runat="server" Text="" Height="30px" Width="200"></asp:TextBox>
                <asp:Label ID="Label53" runat="server" Height="30px" Width="20"></asp:Label>
                <asp:Label ID="Label54" runat="server" Text="Mã website/app client cần kết nối dịch vụ." ></asp:Label>
                <br />

                <asp:Label ID="Label55" runat="server" Text="key_secret " Height="30px" Width="100"></asp:Label>
                <asp:TextBox ID="txtSecretBuyCard" runat="server" Text="" Height="30px" Width="200"></asp:TextBox>
                <asp:Label ID="Label56" runat="server" Height="30px" Width="20"></asp:Label>
                <asp:Label ID="Label57" runat="server" Text="Khóa Secret" ></asp:Label>
                
                <br />
                <asp:Button ID="Button2" runat="server" Text="Thực hiện" OnClick="Button2_Click"  />
            </p>
            <asp:Label ID="lblWarningBuyCard" runat="server" Text="Cảnh báo request: " ForeColor="#996600"></asp:Label>
            <br />
            <asp:Label ID="Label59" runat="server" Text="Kết quả" Font-Size="Larger" Font-Bold="True"></asp:Label>
            <section class="result">
                <div class="connect-card">
                    - status : 
                    <asp:Label ID="lblStatusBuyCard" runat="server"  Text="" ForeColor="#CC3300"></asp:Label>
                    <br />
                    - error_code : 
                    <asp:Label ID="lblErrorCodeBuyCard" runat="server"  Text="" ForeColor="#CC3300"></asp:Label>
                    <br />
                    - message : 
                    <asp:Label ID="lblMessageBuyCard" runat="server"  Text="" ForeColor="#CC3300"></asp:Label>
                    <br />
                    - trans_id : 
                    <asp:Label ID="lblTransIdBuyCard" runat="server"  Text="" ForeColor="#CC3300"></asp:Label>
                    <br />
                    - list_cards: 
                    <asp:Label ID="lblListCardsBuyCard" runat="server"  Text="" ForeColor="#CC3300"></asp:Label>
                    <br />
                    - key_decrypt : 
                    <asp:Label ID="lblKeyDecryptBuyCard" runat="server"  Text="" ForeColor="#CC3300"></asp:Label>
                    <br />
                </div>
             </section>
        </li>
    </ol>
</asp:Content>
