using System;
using System.IO;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using TestApp.Models;

namespace TestApp.Utils {
    public static class IconUtils {
        private const string ImagesDirectoryPath = "Images";

        public static async Task<Bitmap> GetIcon(string url) {
            var fileName = Path.GetFileName(url);
            var filePath = Path.Combine(ImagesDirectoryPath, fileName);

            if (!Directory.Exists(ImagesDirectoryPath)) Directory.CreateDirectory(ImagesDirectoryPath);

            var bytes = File.Exists(filePath)
                ? await File.ReadAllBytesAsync(filePath)
                : await DownloadIcon(url, filePath);

            if (bytes.Length == 0) bytes = await DownloadIcon(url, filePath);

            await using var iconStream = new MemoryStream(bytes);
            return new Bitmap(iconStream);
        }

        private static async Task<byte[]> DownloadIcon(string url, string filePath) {
            var bytes = await App.MarketStaticClient.GetByteArrayAsync($"/static/assets/{url}");

            await File.Create(filePath).DisposeAsync();
            await File.WriteAllBytesAsync(filePath, bytes);

            Console.WriteLine($"Downloaded: {url}");

            return bytes;
        }

        public static string GetIconUrl(ItemsInSet item) {
            return item.UrlName.Contains("set") || string.IsNullOrEmpty(item.SubIcon)
                ? item.Icon
                : item.SubIcon;
        }
    }
}