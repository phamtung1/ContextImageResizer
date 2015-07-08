// -----------------------------------------------------------------------
// <copyright file="ImageHelper.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace ContextImageResizer.Helpers
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.IO;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ImageHelper
    {
        public static void ResizeImages(string[] imagePaths, int maxWidth, int maxHeight)
        {
            foreach (var filePath in imagePaths)
            {
                var folderPath = Path.GetDirectoryName(filePath);
                var fileName = Path.GetFileNameWithoutExtension(filePath);
                var extension = Path.GetExtension(filePath);
                var newFilePath = fileName + DateTime.Now.ToString(" yyyyMMdd_hhmmss") + extension;
                var resizedImage = ImageHelper.ResizeImage(Image.FromFile(filePath), maxWidth, maxHeight);
                resizedImage.Save(Path.Combine(folderPath, newFilePath));
            }
        }
        private static Bitmap ResizeImage(Image image, int maxWidth, int maxHeight)
        {
            int sourceWidth = image.Width;
            int sourceHeight = image.Height;

            float ratio = 0;
            float widthRatio = 0;
            float heightRatio = 0;

            widthRatio = ((float)maxWidth / (float)sourceWidth);
            heightRatio = ((float)maxHeight / (float)sourceHeight);
            ratio = Math.Min(heightRatio, widthRatio);

            var destWidth = (int)Math.Ceiling(sourceWidth * ratio);
            var destHeight = (int)Math.Ceiling(sourceHeight * ratio);

            var destImage = new Bitmap(destWidth, destHeight);
            destImage.SetResolution(image.HorizontalResolution,
                             image.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                graphics.DrawImage(image,
                    new Rectangle(0, 0, destWidth, destHeight),
                    new Rectangle(0, 0, sourceWidth, sourceHeight),
                    GraphicsUnit.Pixel);
            }

            return destImage;
        }
    }
}
