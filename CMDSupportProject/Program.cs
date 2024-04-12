using CMDGameEngine.Objects;
using CMDGameEngine.Objects.VisualMap;
using CMDGameEngine.Menu;
using CMDGameEngine.Screen;
using CMDGameEngine.Additional;
using System.Linq.Expressions;
using static System.Reflection.Metadata.BlobBuilder;
using System.IO;

namespace CMDSupportProject
{

    internal class Program
    {
        static GameScreen gameScreen = new GameScreen(40, 10);


        static string xml = "<objectVisualMap>\r\n  <element x=\"0\" y=\"2\" sign=\"(\" />\r\n  <element x=\"1\" y=\"1\" sign=\"(\" />\r\n  <element x=\"2\" y=\"0\" sign=\"_\" />\r\n  <element x=\"3\" y=\"0\" sign=\"_\" />\r\n  <element x=\"4\" y=\"0\" sign=\"_\" />\r\n  <element x=\"5\" y=\"1\" sign=\")\" />\r\n  <element x=\"4\" y=\"1\" sign=\"o\" />\r\n  <element x=\"2\" y=\"1\" sign=\"o\" />\r\n  <element x=\"3\" y=\"2\" sign=\"V\" />\r\n  <element x=\"6\" y=\"2\" sign=\")\" />\r\n  <element x=\"5\" y=\"3\" sign=\"-\" />\r\n  <element x=\"1\" y=\"3\" sign=\"-\" />\r\n  <element x=\"2\" y=\"3\" sign=\"m\" />\r\n  <element x=\"3\" y=\"3\" sign=\"-\" />\r\n  <element x=\"4\" y=\"3\" sign=\"m\" />\r\n</objectVisualMap>";


        static VisualMap visualMap = new VisualMap(xml);
        static GameObject gameObject = new GameObject(5, 5, visualMap);

        static void Main(string[] args)
        {


            gameScreen.Show();
        }

      
    }
}
