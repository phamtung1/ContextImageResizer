using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ContextImageResizer.Config
{
    public class ImageSizeCollection : ConfigurationElementCollection
    {
        public void Add(ImageSizeElement element)
        {
            base.BaseAdd(element);
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new ImageSizeElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ImageSizeElement)element).Name;
        }
        public ImageSizeElement this[int Index]
        {
            get
            {
                return (ImageSizeElement)BaseGet(Index);
            }
            set
            {
                if (BaseGet(Index) != null)
                {
                    BaseRemoveAt(Index);
                }

                BaseAdd(Index, value);
            }
        }
    }
}
