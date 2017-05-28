using APIMedia.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MediaAPCLI
{
    class Program
    {
        const string URL_IMG = @"http://localhost:3034/api/images";
        const string URL_VID = @"http://localhost:3034/api/videos";
        const string CONTENT_TYPE = "application/json";

        static void Main(string[] args)
        {
            PRESS_ENTER("Crear Imagenes");
            CargarImagenesAsync();
            PRESS_ENTER("Crear Videos");
            CargarVideosAsync();
            PRESS_ENTER("Consultar");
            ConsultaYDisplay();
            PRESS_ENTER();
        }

        private static async void ConsultaYDisplay()
        {
            await ConsultaYDisplayImages();
            await ConsultaYDisplayVideos();
        }

        private static async Task ConsultaYDisplayVideos()
        {
            var http = new HttpClient();
            var jsonList = await http.GetStringAsync(URL_VID);

            List<Video> lista = JsonConvert.DeserializeObject<List<Video>>(jsonList);

            var listaFiltrada = from video in lista
                                where video.Size.Width == 1920 && video.Size.Height == 1080
                                && video.Path.Length >= 255
                                select video;

            Console.WriteLine("VIDEOS");
            foreach (var video in listaFiltrada)
            {
                Console.WriteLine($"VidName = {video.Name}");
            }
        }
        private static async Task ConsultaYDisplayImages()
        {
            var http = new HttpClient();
            var jsonList = await http.GetStringAsync(URL_IMG);

            List<Image> lista = JsonConvert.DeserializeObject<List<Image>>(jsonList);

            var listaFiltrada = from img in lista
                                where img.Size.Width == 1920 && img.Size.Height == 1080
                                && img.Path.Length >= 255
                                select img;

            Console.WriteLine("IMAGENES");
            foreach (var img in listaFiltrada)
            {
                Console.WriteLine($"ImgName = {img.Name}");
            }
        }

        private static async void CargarImagenesAsync()
        {
            List<Image> lista = new List<Image>();

            lista = CrearImagenesDetallado(FormatImage.BMP, new Size { Width = 1920, Height = 1030 }, @"C:\Temp\", 15);
            await EnviarImagenesServicio(lista);

            lista = CrearImagenesDetallado(FormatImage.PNG, new Size { Width = 1280, Height = 720 }, @"C:\Temp\HD", 20);
            await EnviarImagenesServicio(lista);

            lista = CrearImagenesDetallado(FormatImage.JPG, new Size { Width = 1920, Height = 1080 }, @"C:\Temp\SD\JIAIDMIASDIOFASDNFKASLDFKJASLKDJLFKASNDFLAKSDJLFKJFÑASL8989H8W9EH89FWHF98EH9S8HE98FH9W8EH9W8EH98FH89EWH8F9HEW9EFHSADHFAJSDKFHASDJKFJASHDKFJASHKDJFHKASJDHFKJAHSDKJFHAKSDJFHAKSDJFHASKDJFHW9EHFUHWIUEFH9W87EFWUEH8WUFH8EWH8E7HF87WH8E7HFWEFU8WUEHFWE8FW8EF7WEUFWEFWEF", 15);
            await EnviarImagenesServicio(lista);
        }
        private static async Task EnviarImagenesServicio(List<Image> lista)
        {
            var http = new HttpClient();

            foreach (var item in lista)
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, CONTENT_TYPE);
                var rta = await http.PostAsync(URL_IMG, content);
            }
        }
        private static List<Image> CrearImagenesDetallado(FormatImage formato, Size tamaño, string ruta, int cantidad)
        {
            var lista = new List<Image>();
            for (int i = 0; i < cantidad; i++)
            {
                var img = new Image
                {
                    Format = formato,
                    Name = Guid.NewGuid().ToString(),
                    Path = ruta,
                    Size = tamaño
                };
                lista.Add(img);
            }

            return lista;
        }

        private static async void CargarVideosAsync()
        {
            List<Video> lista = new List<Video>();

            lista = CrearVideosDetallado(FormatVideo.AVI, new Size { Width = 1920, Height = 1080 }, @"C:\Temp\FHD\JIAIDMIASDIOFASDNFKASLDFKJASLKDJLFKASNDFLAKSDJLFKJFÑASL8989H8W9EH89FWHF98EH9S8HE98FH9W8EH9W8EH98FH89EWH8F9HEW9EFHSADHFAJSDKFHASDJKFJASHDKFJASHKDJFHKASJDHFKJAHSDKJFHAKSDJFHAKSDJFHASKDJFHW9EHFUHWIUEFH9W87EFWUEH8WUFH8EWH8E7HF87WH8E7HFWEFU8WUEHFWE8FW8EF7WEUFWEFWEF", 15);
            await EnviarVideosServicio(lista);

            lista = CrearVideosDetallado(FormatVideo.FLW, new Size { Width = 320, Height = 240 }, @"C:\Temp\SD", 15);
            await EnviarVideosServicio(lista);

            lista = CrearVideosDetallado(FormatVideo.MP4, new Size { Width = 1280, Height = 720 }, @"C:\Temp\HD", 15);
            await EnviarVideosServicio(lista);
        }
        private static async Task EnviarVideosServicio(List<Video> lista)
        {
            var http = new HttpClient();

            foreach (var item in lista)
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, CONTENT_TYPE);
                var rta = await http.PostAsync(URL_VID, content);
            }
        }
        private static List<Video> CrearVideosDetallado(FormatVideo formato, Size tamaño, string ruta, int cantidad)
        {
            var lista = new List<Video>();
            for (int i = 0; i < cantidad; i++)
            {
                var video = new Video
                {
                    Format = formato,
                    Name = Guid.NewGuid().ToString(),
                    Path = ruta,
                    Size = tamaño
                };
                lista.Add(video);
            }

            return lista;
        }

        private static void PRESS_ENTER(string msg = "")
        {
            Console.WriteLine("PRESS ENTER TO CONTINUE " + msg);
            Console.ReadLine();
        }
    }
}
