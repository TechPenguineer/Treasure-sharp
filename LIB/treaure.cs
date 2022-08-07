
namespace treasure.privacy
{
    public class appKey
    {
       public void createPopup(string codeFormat)
        {
            string message = "Please use your activation key to continue.";
            string title = "Activation";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            MessageBox.Show(message, title, buttons);
        }


        public static void main(string[] args)
        {
            appKey appKey = new appKey();
            appKey.createPopup("xxxx-xxxx-xxxx");
        }
    }
}