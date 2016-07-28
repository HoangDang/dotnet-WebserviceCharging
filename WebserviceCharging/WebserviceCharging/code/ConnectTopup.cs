using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;
using WebserviceCharging.code.lib;

namespace WebserviceCharging.code
{
    public class ConnectTopup
    {
        public void init(DropDownList dropTypeCard, DropDownList dropPostpaid,
            TextBox txtAmount, TextBox txtPhone, TextBox txtMerchanId,
            TextBox txtSecret, Label lblWarning, Label lblStatus,
            Label lblErrorCode, Label lblMessage, Label lblTransId)
        {
            string merchanId = txtMerchanId.Text;

            string typeCard = "";
            switch (dropTypeCard.SelectedIndex)
            {
                case 1:
                    typeCard = "VT_TOPUP";
                    break;
                case 2:
                    typeCard = "MBF_TOPUP";
                    break;
                case 3:
                    typeCard = "VNP_TOPUP";
                    break;
            }

            string postpaid = "";
            switch (dropPostpaid.SelectedIndex)
            {
                case 1:
                    postpaid = "0";
                    break;
                case 2:
                    postpaid = "1";
                    break;
            }

            string amount = txtAmount.Text;
            string phone = txtPhone.Text;
            string secret = txtSecret.Text;

            if (merchanId.Length < 1)
            {
                lblWarning.Text = "Thiếu merchan_id";
                return;
            }
            if (typeCard.Length < 1)
            {
                lblWarning.Text = "Thiếu type_card";
                return;
            }
            if (postpaid.Length < 1)
            {
                lblWarning.Text = "Thiếu postpaid";
                return;
            }
            if (amount.Length < 1)
            {
                lblWarning.Text = "Thiếu amount";
                return;
            }
            if (phone.Length < 1)
            {
                lblWarning.Text = "Thiếu phone";
                return;
            }
            if (secret.Length < 1)
            {
                lblWarning.Text = "Thiếu key_secret";
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(phone);
            sb.Append(amount);
            sb.Append(typeCard);
            sb.Append(postpaid);
            sb.Append(merchanId);


            string sign = Helper.createSign(sb.ToString(), secret);

            HttpResponse<String> response = Unirest.post("http://api.hoanghiep.vn:6868/api_connect/services/execTopup")
                .header("accept", "application/json")
                .connectTopup("json", typeCard, postpaid, amount, phone, merchanId, sign)
                .asString();

            if (response.Body != null)
            {
                lblWarning.Text = Regex.Unescape(response.Body);

                var objects = JObject.Parse(response.Body);
                if (objects != null)
                {
                    if (objects["status"] != null)
                    {
                        lblStatus.Text = ((int)objects["status"]).ToString();
                    }
                    if (objects["message"] != null)
                    {
                        lblMessage.Text = (String)objects["message"];
                    }
                    if (objects["error_code"] != null)
                    {
                        lblErrorCode.Text = ((int)objects["error_code"]).ToString();
                    }
                    if (objects["trans_id"] != null)
                    {
                        lblTransId.Text = ((int)objects["trans_id"]).ToString();
                    }
                }
            }
        }
    }
}