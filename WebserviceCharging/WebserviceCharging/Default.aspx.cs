using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebserviceCharging.code;

namespace WebserviceCharging
{
    public partial class _Default : Page
    {
        // test
        public void test()
        {
            txtMerchanIdBuyCard.Text = "7";
            txtMerchanIdTopup.Text = "7";
            txtMerchantIdConnectCard.Text = "7";

            txtSecretBuyCard.Text = "ED8325026DE38C32AC46";
            txtSecretConnectCard.Text = "ED8325026DE38C32AC46";
            txtSecretTopup.Text = "ED8325026DE38C32AC46";

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            test();
        }

        // Kết nối thẻ cào
        protected void connectCard_Click(object sender, EventArgs e)
        {
            lblWarningConnectCard.Text = "Cảnh báo request kết nối nạp thẻ: ";
            new ConnectCard().init(
                dropTypeCardConnectCard, txtNumberCardConnectCard, txtSeriCardConnectCard,
                txtMerchantIdConnectCard, txtSecretConnectCard,
                lblWarningConnectCard, lblStatusConnectCard, lblErrorCodeConnectCard,
                lblMessageConnectCard, lblTransIdConnectCard, lblAmountConnectCard);
            
        }

        // Kết nối topup
        protected void Button1_Click(object sender, EventArgs e)
        {
            lblWarningTopup.Text = "Cảnh báo request kết nối topup: ";
            new ConnectTopup().init(dropTypeCardTopup, dropPostpaidTopup, txtAmountTopup, txtPhoneTopup,
                txtMerchanIdTopup, txtSecretTopup, lblWarningTopup,
                lblStatusTopup, lblErrorCodeTopup, lblMessageTopup, lblTransIdTopup);
        }

        // kết nối mua mã thẻ
        protected void Button2_Click(object sender, EventArgs e)
        {
            lblWarningBuyCard.Text = "Cảnh báo request kết nối mua mã thẻ: ";
            new ConnectBuyCard().init(dropTypeCardBuyCard, dropTotalBuyCard, txtAmountBuyCard,
                txtMerchanIdBuyCard, txtSecretBuyCard, lblWarningBuyCard, lblStatusBuyCard,
                lblErrorCodeBuyCard, lblMessageBuyCard, lblTransIdBuyCard, lblListCardsBuyCard, lblKeyDecryptBuyCard);
        }
    }
}