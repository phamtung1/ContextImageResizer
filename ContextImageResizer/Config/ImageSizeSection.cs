using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ContextImageResizer.Config
{
    public class ImageSizeSection : ConfigurationSection
    {
        [ConfigurationProperty("elements", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(ImageSizeCollection), AddItemName = "add",
        ClearItemsName = "clear",
        RemoveItemName = "remove")]
        public ImageSizeCollection Elements
        {
            get
            {
                return (ImageSizeCollection)base["elements"];
            }
        }

    }
}
