using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ContextImageResizer.Config
{
    public class ImageSizeElement : ConfigurationElement
    {
        private const string NAME = "name";
        private const string WIDTH = "width";
        private const string HEIGHT = "height";

        [ConfigurationProperty(NAME, IsRequired = true)]
        public string Name
        {
            get { return (string)this[NAME]; }
            set { this[NAME] = value; }
        }

        [ConfigurationProperty(WIDTH, IsRequired = true)]
        public int Width
        {
            get { return (int)this[WIDTH]; }
            set { this[WIDTH] = value; }
        }

        [ConfigurationProperty(HEIGHT, IsRequired = true)]
        public int Height
        {
            get { return (int)this[HEIGHT]; }
            set { this[HEIGHT] = value; }
        }

        public override string ToString()
        {
            return string.Format("{0} ({1} x {2} pixels)", this.Name, this.Width, this.Height);
        }
    }
}
