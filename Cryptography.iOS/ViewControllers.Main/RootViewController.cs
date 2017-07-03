using System;
using System.IO;
using Foundation;
using UIKit;
using System.Text;

namespace Cryptography.iOS.ViewControllers.Main
{
    public partial class RootViewController : UIViewController
    {
        private string aesFileName;

        public RootViewController()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitializeView();
        }

		private void EncryptFile(object sender, EventArgs e)
		{
            try
            {
                var content = File.ReadAllText(GetFilePath(uiFileNameField.Text));
				var encrypted = Crypto.EncryptAes(content);
                aesFileName = string.Format("{0}.aes", uiFileNameField.Text);
                File.WriteAllBytes(GetFilePath(aesFileName), encrypted);
                Console.WriteLine(GetFilePath(aesFileName));

                uiFileNameField.Text = BitConverter.ToString(File.ReadAllBytes(GetFilePath(aesFileName)));
            }
            catch (Exception exc)
            {
                var alert = UIAlertController.Create("Error", exc.Message, UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, null));
                PresentViewController(alert, true, null);
            }
		}

        private void DecryptFile(object sender, EventArgs e)
        {
			try
			{
                //var content = File.ReadAllText(GetFilePath(uiFileNameField.Text));
                var content = File.ReadAllBytes(GetFilePath(aesFileName));
                var decrypted = Crypto.DecryptAes(content);
                File.WriteAllText(GetFilePath("decrypted.xml"), decrypted);
                Console.WriteLine(GetFilePath("decrypted.xml"));

                uiFileNameField.Text = GetFilePath("decrypted.xml");
			}
			catch (Exception exc)
			{
				var alert = UIAlertController.Create("Error", exc.Message, UIAlertControllerStyle.Alert);
				alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, null));
				PresentViewController(alert, true, null);
			}
        }

        private string GetFilePath(string fileName)
        {
            return Path.Combine(NSBundle.MainBundle.BundlePath, fileName);
        }
    }
}
