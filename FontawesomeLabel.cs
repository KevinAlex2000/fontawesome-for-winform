using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System;

namespace fontawesome
{
    public class FontawesomeLabel : Label
    {
        private Packages _package = Packages.Regular;
        [Description("Carpeta de iconos")]
        [DefaultValue(Packages.Regular)]
        [Category("fontawesome")]
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

        private string _iconName = "smile-beam";
        [Description("Nombre clave de icono")]
        [DefaultValue("angry")]
        [Category("fontawesome")]
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
        [Category("fontawesome")]
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

        private int _WidthIcon = 20;
        [Description("Ancho del icono")]
        [DefaultValue(20)]
        [Category("fontawesome")]
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

        Content paquetes = new Content();

        // Buscamos icono en las carpetas
        private void searchIcon()
        {
            Size size = new Size(WidthIcon, 0);
            Image = paquetes.returnIcon(PackageIcon.ToString(), NameIcon, ColorIcon, size, true);
        }

        protected override void OnResize(EventArgs e)
        {
            searchIcon();
            base.OnResize(e);
        }
    }
}
