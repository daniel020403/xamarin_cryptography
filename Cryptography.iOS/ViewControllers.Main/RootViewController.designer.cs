using System;
using UIKit;

namespace Cryptography.iOS.ViewControllers.Main
{
    public partial class RootViewController
    {
        private const float VERTICALPADDING = 10.0f;
        private const float HORIZONTALPADDING = 5.0f;
        private const float UIELEMENTHEIGHT = 30.0f;
        private const string FILENAME = "data.xml";

        private UILabel uiFilePathLabel;
        private UITextField uiFileNameField;
        private UIButton uiEncryptFileButton;
        private UIButton uiDecryptFileButton;
        
        private void InitializeView()
        {
            View.BackgroundColor = UIColor.White;

            AddFilePathLabel();
            AddFilePathField();
            AddEncryptButton();
            AddDecryptButton();

            SetLayoutConstraints();
        }

        private void AddFilePathLabel()
        {
            uiFilePathLabel = new UILabel();
            uiFilePathLabel.Text = "File to encrypt:";
            uiFilePathLabel.Font = UIFont.FromName("ArialMT", 12.0f);

            View.AddSubview(uiFilePathLabel);
        }

        private void AddFilePathField()
        {
            uiFileNameField = new UITextField();
            uiFileNameField.Placeholder = "Filename of the file to encrypt.";
            uiFileNameField.BorderStyle = UITextBorderStyle.Line;
            uiFileNameField.Font = UIFont.FromName("ArialMT", 12.0f);
            uiFileNameField.Text = FILENAME;

            View.AddSubview(uiFileNameField);
        }

        private void AddEncryptButton()
        {
            uiEncryptFileButton = new UIButton();
            uiEncryptFileButton.SetTitle("Encrypt File", UIControlState.Normal);
            uiEncryptFileButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            uiEncryptFileButton.Font = UIFont.FromName("ArialMT", 12.0f);
            uiEncryptFileButton.TouchUpInside += EncryptFile;

            View.AddSubview(uiEncryptFileButton);
        }

        private void AddDecryptButton()
        {
            uiDecryptFileButton = new UIButton();
            uiDecryptFileButton.SetTitle("Decrypt File", UIControlState.Normal);
            uiDecryptFileButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            uiDecryptFileButton.Font = UIFont.FromName("ArialMT", 12.0f);
            uiDecryptFileButton.TouchUpInside += DecryptFile;

            View.AddSubview(uiDecryptFileButton);
        }

        private void ClearTranslatesAutoresizingMaskIntoConstraints()
        {
            uiFilePathLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            uiFileNameField.TranslatesAutoresizingMaskIntoConstraints = false;
            uiEncryptFileButton.TranslatesAutoresizingMaskIntoConstraints = false;
            uiDecryptFileButton.TranslatesAutoresizingMaskIntoConstraints = false;
        }

        private void SetLayoutConstraints()
        {
            ClearTranslatesAutoresizingMaskIntoConstraints();
            
            NSLayoutConstraint.ActivateConstraints(FilePathLabelLayoutConstraints());
            NSLayoutConstraint.ActivateConstraints(FileNameFieldLayoutConstraints());
            NSLayoutConstraint.ActivateConstraints(EncryptFileButtonLayoutConstraints());
            NSLayoutConstraint.ActivateConstraints(DecryptFileButtonLayoutConstraints());
        }

        private NSLayoutConstraint[] FilePathLabelLayoutConstraints()
        {
            return new[] {
                uiFilePathLabel.TopAnchor.ConstraintEqualTo(TopLayoutGuide.GetBottomAnchor()),
                uiFilePathLabel.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor),
                uiFilePathLabel.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor),
                uiFilePathLabel.HeightAnchor.ConstraintEqualTo(UIELEMENTHEIGHT)
            };
        }

        private NSLayoutConstraint[] FileNameFieldLayoutConstraints()
        {
            return new[] {
                uiFileNameField.TopAnchor.ConstraintEqualTo(uiFilePathLabel.BottomAnchor, VERTICALPADDING),
                uiFileNameField.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, HORIZONTALPADDING),
                uiFileNameField.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor, -HORIZONTALPADDING),
                uiFileNameField.HeightAnchor.ConstraintEqualTo(UIELEMENTHEIGHT)
            };
        }

        private NSLayoutConstraint[] EncryptFileButtonLayoutConstraints()
        {
            return new[] {
                uiEncryptFileButton.TopAnchor.ConstraintEqualTo(uiFileNameField.BottomAnchor, VERTICALPADDING),
                uiEncryptFileButton.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, HORIZONTALPADDING),
                uiEncryptFileButton.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor, -HORIZONTALPADDING),
                uiEncryptFileButton.HeightAnchor.ConstraintEqualTo(UIELEMENTHEIGHT)
            };
        }

        private NSLayoutConstraint[] DecryptFileButtonLayoutConstraints()
        {
            return new[] {
                uiDecryptFileButton.TopAnchor.ConstraintEqualTo(uiEncryptFileButton.BottomAnchor, VERTICALPADDING),
                uiDecryptFileButton.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, HORIZONTALPADDING),
                uiDecryptFileButton.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor, -HORIZONTALPADDING),
                uiDecryptFileButton.HeightAnchor.ConstraintEqualTo(UIELEMENTHEIGHT)
            };
        }
    }
}
