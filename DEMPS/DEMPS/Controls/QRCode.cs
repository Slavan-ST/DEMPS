using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using QRCoder;

namespace DEMPS.Controls
{
    public class QRCode : Control
    {
        public static readonly StyledProperty<int> PixelsPerModuleProperty = AvaloniaProperty.Register<QRCode, int>(nameof(PixelsPerModule), 20);

        public static readonly StyledProperty<IBrush> ColorProperty = AvaloniaProperty.Register<QRCode, IBrush>(nameof(Color), Brushes.Black);

        public static readonly StyledProperty<IBrush> SpaceBrushProperty = AvaloniaProperty.Register<QRCode, IBrush>(nameof(SpaceBrush), Brushes.White);

        public static readonly StyledProperty<bool> DrawQuietZonesProperty = AvaloniaProperty.Register<QRCode, bool>(nameof(DrawQuietZones), true);

        public static readonly StyledProperty<string> DataProperty = AvaloniaProperty.Register<QRCode, string>(nameof(Data), string.Empty);

        public static readonly StyledProperty<int> IconBorderWidthProperty = AvaloniaProperty.Register<QRCode, int>(nameof(IconBorderWidth), 6);


        /// <summary>
        /// Ширина рамки, которая обводится вокруг значка. Минимум: 1
        /// </summary>
        public int IconBorderWidth
        {
            get { return GetValue(IconBorderWidthProperty); }
            set
            {
                if (value < 1)
                    value = 1;

                SetValue(IconBorderWidthProperty, value);
            }
        }

        /// <summary>
        /// То что зашифрованно в коде
        /// </summary>
        public string Data
        {
            get { return GetValue(DataProperty); }
            set
            {
                SetValue(DataProperty, value);
            }
        }

        /// <summary>
        /// Если значение true, то вокруг всего QR-кода будет нарисована белая рамка
        /// </summary>
        public bool DrawQuietZones
        {
            get { return GetValue(DrawQuietZonesProperty); }
            set
            {
                SetValue(DrawQuietZonesProperty, value);
            }
        }

        /// <summary>
        /// Цвет светлых/белых модулей
        /// </summary>
        public IBrush SpaceBrush
        {
            get { return GetValue(SpaceBrushProperty); }
            set
            {
                SetValue(SpaceBrushProperty, value);
            }
        }

        /// <summary>
        /// Цвет темных/черных модулей
        /// </summary>
        public IBrush Color
        {
            get { return GetValue(ColorProperty); }
            set
            {
                SetValue(ColorProperty, value);
            }
        }

        /// <summary>
        /// Размер пикселя, который рисуется каждым черно-белым модулем
        /// </summary>
        public int PixelsPerModule
        {
            get { return GetValue(PixelsPerModuleProperty); }
            set
            {
                SetValue(PixelsPerModuleProperty, value);
            }
        }

        public QRCode()
        {
            AffectsRender<QRCode>(DataProperty, PixelsPerModuleProperty, DrawQuietZonesProperty, ColorProperty, SpaceBrushProperty, IconBorderWidthProperty);

        }
        //отрисовываем код при рендере контрола
        public override void Render(DrawingContext context)
        {
            //объявляем генератор
            using var qrGenerator = new QRCodeGenerator();
            //генерируем код
            using var qrCodeData = qrGenerator.CreateQrCode(Data, QRCodeGenerator.ECCLevel.L);
            //получаем из кода битмап изображение в виде байт
            using var qrCode = new QRCoder.BitmapByteQRCode(qrCodeData);
            var systemBitmap = qrCode.GetGraphic(PixelsPerModule);

            //конвертируем байты в нормальное битмап изображение :)
            using Stream stream = new MemoryStream(systemBitmap);
            Bitmap bitmap = new Bitmap(stream);
            
            //далее идёт сама отрисовка
            var source = bitmap;
            if (source != null && Bounds.Width > 0 && Bounds.Height > 0)
            {
                Rect viewPort = new Rect(Bounds.Size);
                Size sourceSize = source.Size;
                Vector scale = Stretch.Uniform.CalculateScaling(Bounds.Size, sourceSize, StretchDirection.Both);
                Size scaledSize = sourceSize * scale;
                Rect destRect = viewPort
                    .CenterRect(new Rect(scaledSize))
                    .Intersect(viewPort);
                Rect sourceRect = new Rect(sourceSize)
                    .CenterRect(new Rect(destRect.Size / scale));
                context.DrawImage(source, sourceRect, destRect);
            }
        }

    }
}
