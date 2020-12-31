using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System;

namespace fontawesome
{
    public class FontawesomeDobleIcon : PictureBox
    {

        // Propiedades del icono

        private Packages _package = Packages.Solid;
        [Description("Carpeta de iconos")]
        [DefaultValue(Packages.Solid)]
        [Category("Icono")]
        public Packages PackageIcon
        {
            get { return _package; }
            set
            {
                _package = value;
                searchIcon();
                Invalidate();
            }
        }

        private string _iconName = "award";
        [Description("Nombre clave de icono")]
        [DefaultValue("award")]
        [Category("Icono")]
        public string NameIcon
        {
            get { return _iconName; }
            set
            {
                _iconName = value;
                searchIcon();
                Invalidate();
            }
        }

        private Color _color = Color.Black;
        [Description("Color del icono")]
        [DefaultValue(typeof(Color), "Black")]
        [Category("Icono")]
        public Color ColorIcon
        {
            get { return _color; }
            set
            {
                _color = value;
                searchIcon();
                Invalidate();
            }
        }

        private int _WidthIcon = 30;
        [Description("Ancho del icono")]
        [DefaultValue(20)]
        [Category("Icono")]
        public int WidthIcon
        {
            get { return _WidthIcon; }
            set
            {
                _WidthIcon = value;
                searchIcon();
                Invalidate();
            }
        }


        // Propiedades del icono de fondo

        private Packages _packageBackground = Packages.Solid;
        [Description("Carpeta del icono de fondo")]
        [DefaultValue(Packages.Regular)]
        [Category("Icono de fondo")]
        public Packages PackageBackgroundIcon
        {
            get { return _packageBackground; }
            set
            {
                _packageBackground = value;
                searchBackgroundIcon();
                Invalidate();
            }
        }

        private string _iconNameBack = "circle-notch";
        [Description("Nombre clave de icono de fondo")]
        [DefaultValue("circle-notch")]
        [Category("Icono de fondo")]
        public string NameBackgroundIcon
        {
            get { return _iconNameBack; }
            set
            {
                _iconNameBack = value;
                searchBackgroundIcon();
                Invalidate();
            }
        }

        private Color _colorBackground = Color.Gray;
        [Description("Color del icono de fondo")]
        [DefaultValue(typeof(Color), "Black")]
        [Category("Icono de fondo")]
        public Color ColorBackgroundIcon
        {
            get { return _colorBackground; }
            set
            {
                _colorBackground = value;
                searchBackgroundIcon();
                Invalidate();
            }
        }


        public new int Width
        {
            get { return base.Width; }
            set
            {
                base.Width = value;
                searchBackgroundIcon();
                Invalidate();
            }
        }

        Content paquetes = new Content();

        // Buscamos icono en las carpetas
        private void searchIcon()
        {
            Size size = new Size(WidthIcon, 0);
            Image = paquetes.returnIcon(PackageIcon.ToString(),NameIcon,ColorIcon, size, true);
        }

        private void searchBackgroundIcon()
        {
            Size size = new Size(Width, Height);
            base.BackgroundImage = paquetes.returnIcon(PackageIcon.ToString(),NameBackgroundIcon, ColorBackgroundIcon, size);
        }

        protected override void OnResize(EventArgs e)
        {
            Width = base.Width;
            base.OnResize(e);
        }
    }
}
