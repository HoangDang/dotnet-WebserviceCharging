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
    public class ConnectBuyCard
    {
        public void init(DropDownList dropTypeCard, DropDownList dropTotal,
            TextBox txtAmount, TextBox txtMerchanId, TextBox txtSecret,
            Label lblWarning, Label lblStatus, Label lblErrorCode, Label lblMessage,
            Label lblTransId, Label lblListCards, Label lblKeyDecrypt)
        {
            string merchanId = txtMerchanId.Text;

            string typeCard = "";
            switch (dropTypeCard.SelectedIndex)
            {
                case 1:
                    typeCard = "VT_BUYCODE";
                    break;
                case 2:
                    typeCard = "MBF_BUYCODE";
                    break;
                case 3:
                    typeCard = "VNP_BUYCODE";
                    break;
            }

            string total = "";
            if (dropTotal.SelectedIndex > 0)
            {
                total = dropTotal.SelectedIndex.ToString();
            }

            string amount = txtAmount.Text;
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
            if (total.Length < 1)
            {
                lblWarning.Text = "Thiếu total";
                return;
            }
            if (amount.Length < 1)
            {
                lblWarning.Text = "Thiếu amount";
                return;
            }
            if (secret.Length < 1)
            {
                lblWarning.Text = "Thiếu key_secret";
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(typeCard);
            sb.Append(total);
            sb.Append(amount);
            sb.Append(merchanId);


            string sign = Helper.createSign(sb.ToString(), secret);

            HttpResponse<String> response = Unirest.post("http://api.hoanghiep.vn:6868/api_connect/services/execBuyCode")
                .header("accept", "application/json")
                .connectByCard("json", typeCard, total, amount, merchanId, sign)
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
                    if (objects["list_cards"] != null)
                    {
                        lblTransId.Text = (objects["list_cards"]).ToString();
                    }
                    if (objects["key_decrypt"] != null)
                    {
                        lblTransId.Text = (objects["key_decrypt"]).ToString();
                    }
                }
            }
        }
    }
}