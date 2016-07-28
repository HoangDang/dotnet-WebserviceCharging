using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebserviceCharging.code.lib;

namespace WebserviceCharging.code
{
    public class ConnectCard
    {
        public void init(DropDownList dropTypeCard,
            TextBox txtNumberCard, TextBox txtSeriCard, TextBox txtMerchanId, TextBox txtSecret, Label lblWarning, Label lblStatus,
            Label lblErrorCode, Label lblMessage, Label lblTransId, Label lblAmount)
        {
            string merchanId = txtMerchanId.Text;
            string typeCard = "";
            switch (dropTypeCard.SelectedIndex)
            {
                case 1:
                    typeCard = "VT";
                    break;
                case 2:
                    typeCard = "MBF";
                    break;
                case 3:
                    typeCard = "VNP";
                    break;
                case 4:
                    typeCard = "GATE";
                    break;
            }
            string numberCard = txtNumberCard.Text;
            string seriCard = txtSeriCard.Text;
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
            if (numberCard.Length < 1)
            {
                lblWarning.Text = "Thiếu number_card";
                return;
            }
            if (seriCard.Length < 1)
            {
                lblWarning.Text = "Thiếu seri_card";
                return;
            }
            if (secret.Length < 1)
            {
                lblWarning.Text = "Thiếu key_secret";
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(numberCard);
            sb.Append(seriCard);
            sb.Append(merchanId);
            sb.Append(typeCard);


            string sign = Helper.createSign(sb.ToString(), secret);

            HttpResponse<String> response = Unirest.post("http://api.hoanghiep.vn:6868/api_connect/services/execChargeMobile")
                .header("accept", "application/json")
                .connectCard("json", typeCard, numberCard, seriCard, merchanId, sign)
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
                    if (objects["amount"] != null)
                    {
                        lblAmount.Text = ((int)objects["amount"]).ToString();
                    }
                }
            }
        }
    }
}