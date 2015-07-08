using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using ContextImageResizer.Config;
using ContextImageResizer.Helpers;

namespace ContextImageResizer
{
    public partial class ResizeForm : Form
    {
        public ResizeForm()
        {
            InitializeComponent();
            this.Text = Application.ProductName + " - " + Application.ProductVersion;
            var selectedSize = ConfigurationManager.AppSettings["SelectedSize"];
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None); 
            var section = config.Sections.Get("ImageSizeSection") as ImageSizeSection;

            foreach (ImageSizeElement item in section.Elements)
            {
                var button = new RadioButton();
                button.AutoSize = true;
                button.Checked = item.Name == selectedSize;
                button.Text = item.ToString();
                button.Tag = item;
                imageSizePanel.Controls.Add(button);
            }
        }

        public string[] ImageFiles
        {
            get;
            set;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            var button = imageSizePanel.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            var imageSize = button.Tag as ImageSizeElement;
            SaveSelectedSize(imageSize.Name);
            ImageHelper.ResizeImages(this.ImageFiles, imageSize.Width, imageSize.Height);
            this.Close();
        }

        private void SaveSelectedSize(string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["SelectedSize"].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
