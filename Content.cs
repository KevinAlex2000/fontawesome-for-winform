using Svg;
using System.Drawing;
using System.IO;
using System;
using System.Reflection;
using System.Windows.Forms;
using System.Data;

namespace fontawesome
{
    public enum Packages
    {
        Regular,
        Solid,
        Light,
        Duotone,
        Brand
    }

    public class Content
    {
        Icons index = new Icons();
        string path = System.IO.Path.GetTempPath() + "icon.svg";

        private void crearArchivo(string data)
        {
            // Crea archivo temporal del icono
            try
            {
                using (var tw = new StreamWriter(path, false))
                {
                    tw.WriteLine(data);
                }
            }
            catch
            {
                crearArchivo(data);// Vuelve a intentarlo
            }
        }

        private bool buscarArchivo(string paquete, string icono)
        {
            string data = "";

            switch (paquete)
            {
                case "Regular":
                    data = index.Regular(icono);
                    break;
                case "Solid":
                    data = index.Solid(icono);
                    break;
                case "Light":
                    data = index.Light(icono);
                    break;
                case "Duotone":
                    data = index.Duotone(icono);
                    break;
                case "Brand":
                    data = index.Brand(icono);
                    break;
            }
            
            if(data == "")
            {
                return false;
            }
            else
            {
                crearArchivo(data);
                return true;
            }
        }

        public Image returnIcon(string paquete, string nombre, Color color , Size size, bool auto = false)
        {
            bool resultTemp = buscarArchivo(paquete,nombre);
            Image result;
            
            int width = size.Width;
            int height = size.Height;

            if(resultTemp == false)
            {
                result = null;
            }
            else
            {
                SvgDocument svg = SvgDocument.Open(path);
                svg.Fill = new SvgColourServer(color);

                if (auto == true)
                {
                    result = svg.Draw();

                    int widthReal = result.Width;
                    int heightReal = result.Height;

                    height = heightReal * width / widthReal;
                }
                
                result = svg.Draw(width, height);
            }

            return result;
        }
        
    }
}
