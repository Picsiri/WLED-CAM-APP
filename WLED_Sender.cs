using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLED_CAM_APP
{
    using System;
    using System.Drawing;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Text;
    using Newtonsoft.Json;

    public class WLED_Sender
    {
        private static readonly HttpClient client = new HttpClient();

        public static async void SendImageToWLED(Bitmap image, string wledIp, int brightness, int segmentId, int chunkSize)
        {
            int numberOfPixels = image.Width * image.Height;

            // Create hexadeciman color array
            var hexColorArray = new string[numberOfPixels];
            int index = 0;
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    hexColorArray[index] = pixelColor.Name.Substring(2);
                    index++;
                }
            }

            // Save for debug

            string filePath = @"compare.txt";
            File.WriteAllLines(filePath, hexColorArray);

            index = 0;
            bool done = false;
            while(!done)
            {
                int chunkEndId = Math.Min(numberOfPixels, index + chunkSize);
                if (chunkEndId == numberOfPixels) done = true;
                int payloadSize = chunkEndId - index;

                // create the payload
                var payload = new List<object> { index };

                for (int i = index; i < chunkEndId; i++)
                {
                    payload.Add(hexColorArray[i]);
                }

                // Create WLED state JSON object
                var wledState = new
                {
                    bri = brightness,
                    on = true,
                    seg = new
                    {
                        i = payload,
                        id = segmentId,
                    }
                };

                // Serialize the object to JSON
                var jsonContent = JsonConvert.SerializeObject(wledState);

                // Send HTTP POST request to WLED device
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var targetAddress = $"http://{wledIp}/json/state";

                //System.Diagnostics.Debug.WriteLine(targetAddress);

                var response = await client.PostAsync(targetAddress, content);

                if (response.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine("Image sent to WLED successfully!");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Failed to send image to WLED.");
                }

                Thread.Sleep(100);

                index = chunkEndId;
            }
        }
    }

}
