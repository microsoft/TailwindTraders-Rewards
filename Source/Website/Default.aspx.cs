using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Text;
using System.Web.UI;
using Tailwind.Traders.Rewards.Web.Data;
using Tailwind.Traders.Rewards.Web.Models;

namespace Tailwind.Traders.Rewards.Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Don't forget to create the 'rewards' database and execute the sql ..\SQLScripts\CreateTablesAndPopulate.sql script
            // to make the initial migration and seeding



            string yolo = Request.QueryString["yolo"];
            if (yolo == "hi")
            {
                throw new Exception();
            }

            var cid = -1;
            if (Page.IsPostBack)
            {
                cid = int.Parse(CustomerId.Value);
            }

            var orders = OrdersData.GetOrders(5);
            orderList.DataSource = orders;
            orderList.DataBind();

            if (cid == -1)
            {
                var defaultCustomer = CustomerData.GetDefaultCustomer();
                MapCustomer(defaultCustomer);
            }
            else
            {
                var customer = CustomerData.GetCustomerById(cid);
                MapCustomer(customer);
            }
            

            lblCheckbox.Attributes.Add("for", EnrollCheckbox.ClientID);
        }

        protected void EnrollChckedChanged(object sender, EventArgs e)
        {
            var cid = int.Parse(CustomerId.Value);

            var customer = CustomerData.GetCustomerById(cid);

            if (customer.Enrrolled == EnrollmentStatusEnum.Uninitialized)
            {
                customer.Enrrolled = EnrollmentStatusEnum.Started;
                CustomerData.ChangeEnrollmentStatus(customer);
                BypassLogicAppIfNeeded(customer);
                MapCustomer(customer);
            }
        }

    private void BypassLogicAppIfNeeded(Customer customer)
        {
            var bypassSettings = ConfigurationManager.AppSettings["ByPassLogicApp"];
            if (string.IsNullOrEmpty(bypassSettings) || !bool.Parse(bypassSettings))
            {
                return;
            }

            var channel = ConfigurationManager.AppSettings["ChannelType"] ?? "Email";

            var uri = ConfigurationManager.AppSettings["AfHttpHandlerUri"];

            var client = new WebClient();
            var obj = new
            {
                enrolled = customer.Enrrolled,
                firstName = customer.FirstName,
                id = customer.CustomerId,
                lastName = customer.LastName,
                mobileNumber = customer.MobileNumber,
                Email = customer.Email,
                Channel = channel
            };
            var jsonString = JsonConvert.SerializeObject(obj);
            var ut8Bytes = Encoding.UTF8.GetBytes(jsonString);
            jsonString = Encoding.UTF8.GetString(ut8Bytes);

            client.Headers.Add("content-type", "application/json");
            client.UploadStringAsync(new Uri(uri), jsonString);
        }

        protected void SearchCustomer(object sender, EventArgs e)
        {
            var customer = CustomerData.GetCustomerByEmailOrName(SearchTextBox.Text);

            if (customer != null)
            {
                MapCustomer(customer);
                spanCustomer.Visible = true;
                spanCustomer2.Visible = true;
                spanNotFound.Visible = false;
            }
            else
            {
                spanCustomer.Visible = false;
                spanCustomer2.Visible = false;
                spanNotFound.Visible = true;
            }

            RandomizeOrderHistory();
            SearchTextBox.Text = string.Empty;            
        }

        private void MapCustomer(Customer customer)
        {
            CustomerId.Value = customer.CustomerId.ToString();
            AccNo.InnerText = customer.AccountCode;
            Address1.InnerText = customer.FirstAddress;
            City.InnerText = customer.City;
            Country.InnerText = customer.Country;
            ZipCode.InnerText = customer.ZipCode;
            Website.InnerText = customer.Website;
            Active.InnerText = customer.Active ? "yes" : "no";
            Name.InnerText = customer.FirstName;
            LastName.InnerText = customer.LastName;
            Email.InnerText = customer.Email;
            PhoneNumber.InnerText = customer.PhoneNumber;
            FaxNumber.InnerText = customer.FaxNumber;
            MobileNumber.InnerText = customer.MobileNumber;
            switch (customer.Enrrolled)
            {
                case EnrollmentStatusEnum.Accepted:
                    EnrollCheckbox.Visible = false;
                    lblCheckbox.InnerText = "Already enrolled";
                    break;
                case EnrollmentStatusEnum.Rejected:
                    EnrollCheckbox.Visible = false;
                    lblCheckbox.InnerText = "Enrollment rejected";
                    break;
                case EnrollmentStatusEnum.Started:
                    EnrollCheckbox.Visible = true;
                    EnrollCheckbox.Enabled = false;
                    EnrollCheckbox.Checked = true;
                    lblCheckbox.InnerText = "Enrollment in process";
                    break;
                case EnrollmentStatusEnum.Uninitialized:
                case EnrollmentStatusEnum.Uncompleted:
                    EnrollCheckbox.Visible = true;
                    EnrollCheckbox.Enabled = true;
                    EnrollCheckbox.Checked = false;
                    lblCheckbox.InnerText = "Enroll in loyalty program";
                    break;
            }

        }

        private void RandomizeOrderHistory()
        {
            var shuffledOrders = OrdersData.GetOrdersRandomized();

            orderList.DataSource = shuffledOrders;
            orderList.DataBind();
        }
    }
}