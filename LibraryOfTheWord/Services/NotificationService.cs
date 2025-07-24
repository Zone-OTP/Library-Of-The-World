using LibraryOfClasses.Classes;
using System.Text;
using System.Text.Json;

namespace LibraryOfTheWorld.Services
{
    public class NotificationService
    {
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:5160") };

        public static void ShowMessage(string message, string title = "Information")
        {
            using (var dialog = new Form())
            {
                dialog.Text = title;
                dialog.Size = new Size(400, 200);
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.MaximizeBox = false;
                dialog.MinimizeBox = false;

                var label = new Label()
                {
                    Text = message,
                    AutoSize = false,
                    Size = new Size(360, 100),
                    Location = new Point(20, 20),
                    TextAlign = ContentAlignment.MiddleLeft,
                    BackColor = Control.DefaultBackColor,

                };

                var okButton = new System.Windows.Forms.Button()
                {
                    Text = "OK",
                    Size = new Size(75, 30),
                    Location = new Point(200, 120),
                    DialogResult = DialogResult.OK
                };

                dialog.Controls.Add(label);
                dialog.Controls.Add(okButton);
                dialog.AcceptButton = okButton;
                dialog.ShowDialog();
            }


        }
        public static DialogResult ShowMessageYesNo(string message, string title = "Information")
        {
            using (var dialog = new Form())
            {
                dialog.Text = title;
                dialog.Size = new Size(400, 200);
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.MaximizeBox = false;
                dialog.MinimizeBox = false;

                var label = new Label()
                {
                    Text = message,
                    AutoSize = false,
                    Size = new Size(360, 100),
                    Location = new Point(20, 20),
                    TextAlign = ContentAlignment.MiddleLeft,
                    BackColor = Control.DefaultBackColor,

                };

                var yesButton = new System.Windows.Forms.Button()
                {
                    Text = "Yes",
                    Size = new Size(75, 30),
                    Location = new Point(100, 120),
                    DialogResult = DialogResult.Yes
                };

                var noButton = new System.Windows.Forms.Button()
                {
                    Text = "No",
                    Size = new Size(75, 30),
                    Location = new Point(200, 120),
                    DialogResult = DialogResult.No,
                };
                dialog.Controls.Add(label);
                dialog.Controls.Add(yesButton);
                dialog.AcceptButton = yesButton;
                dialog.Controls.Add(noButton);

                return dialog.ShowDialog();
            }

        }

        public static async Task MailNotifySignIn(Customer customer)
        {
            var endpoint = $"/api/mailing/send-login-email";
            try
            {
                string jsonCustomer = JsonSerializer.Serialize(customer);
                var content = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(endpoint, content);
                if (response.IsSuccessStatusCode)
                {
                    string responseJson = await response.Content.ReadAsStringAsync();
                    Customer createdEntity = JsonSerializer.Deserialize<Customer>(responseJson,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true, WriteIndented = true });
                    Console.WriteLine("Mail sent to cutomer");
                }
                else { Console.WriteLine("Mail coudn't be sent"); }

            }
            catch (Exception ex) { Console.WriteLine($"Exception thrown at Mailing Front side notification service\n:{ex}"); }
        }
    }
 }
 


