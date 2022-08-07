using System;
using System.Windows.Forms;
using System.Drawing;
namespace treasure.privacy
{
    public class appKey
    {
       public static DialogResult createPopup(ref string input, string codeFormat)
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
            textBox.PlaceholderText = codeFormat;
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


        public static void Main(string[] args)
        {
            appKey appKey = new appKey();
            string input = "...";
            appKey.createPopup(ref input, "xxxx-xxxx-xxxx");
        }
    }
}