using System;
using System.Windows.Forms;
using System.Drawing;
using MongoDB.Driver;

namespace treasure.privacy
{
    public class appKey
    {
       public void validateKey(string key)
        {

        }
        public enum DATABASES
        {
            mongoAtlas
        }
        public class CREDENTIALS
        {
            public string mongo_atlas_connection_string;
        }
        public string generateKey()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
        public class APP_KEY_MODEL
        {
            public string key { get; set; }
            public string exp_date { get; set; }
        }

        public APP_KEY_MODEL createKey(string expireDate)
        {
            APP_KEY_MODEL app_key_model = new APP_KEY_MODEL();
            app_key_model.key = generateKey();
            app_key_model.exp_date = expireDate;
        }
        public void CreateApiKeyRefference(DATABASES database, CREDENTIALS credentials)
        {
            if (credentials.mongo_atlas_connection_string != null)
            {
                string atlas_connection_string = credentials.mongo_atlas_connection_string;
                if(database == DATABASES.mongoAtlas)
                {
                    try
                    {
                        MongoClient dbClient = new MongoClient(atlas_connection_string);
                        Console.WriteLine("Successfuly connected to MONGO ATLAS, for authentication keys");
                    }
                    catch ( Exception e ) 
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
            }
        }
       public static DialogResult createPopup(ref string input, int codeLength)
        {
           
            int width = 300;
            int height = 100;
            string title = "Activation";
            string prompt = "To continue please use your activation key.";
            Size size = new Size(width, height);
            Form inputBox = new Form();

            inputBox.MaximizeBox = false;
            inputBox.MinimizeBox = false;
           
            inputBox.FormBorderStyle = FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = title;

            Label label = new Label();
            label.Text = prompt;
            label.Location = new Point(5, 5);
            label.Width = size.Width - 10;
            inputBox.Controls.Add(label);

            TextBox textBox = new TextBox();
            textBox.Size = new Size(size.Width - 10, 23);
            textBox.Location = new Point(5, label.Location.Y + 20);
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new Point(size.Width - 80 - 80, size.Height - 30);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new Point(size.Width - 80, size.Height - 30);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;

            return result;
        }



        // TESTING
        public static void Main(string[] args)
        {
            appKey appKey = new appKey();
            string input = "...";
            appKey.CREDENTIALS creds = new CREDENTIALS();
            creds.mongo_atlas_connection_string = "bob";
            appKey.CreateApiKeyRefference(DATABASES.mongoAtlas, creds);
            appKey.createPopup(ref input, 11);
        }
    }
}