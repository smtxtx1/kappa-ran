using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kappa
{
    public class WebhookPayload
    {
        public string content { get; set; }
        public List<WebhookEmbed> embeds { get; set; }
        public string username { get; set; }
        public string avatar_url { get; set; }
        public List<object> attachments { get; set; }
    }

    public class WebhookEmbed
    {
        public string title { get; set; }
        public string description { get; set; }
        public int? color { get; set; } // Nullable int for the color
        public List<WebhookEmbedField> fields { get; set; }
        public WebhookEmbedAuthor author { get; set; }
    }

    public class WebhookEmbedField
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class WebhookEmbedAuthor
    {
        public string name { get; set; }
    }

    class WebhookSender
        {
            // Function to send a webhook
            public static async Task<bool> SendWebhookAsync(string webhookUrl, object payload)
            {
                // Convert the payload to JSON format
                string jsonPayload = JsonConvert.SerializeObject(payload);

                // Create an HttpClient instance
                using (HttpClient client = new HttpClient())
                {
                    // Create the content to send in the POST request
                    HttpContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    try
                    {
                        // Send the POST request
                        HttpResponseMessage response = await client.PostAsync(webhookUrl, content);

                        // Check if the request was successful
                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine("Webhook sent successfully!");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine($"Failed to send webhook. Status code: {response.StatusCode}");
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error sending webhook: {ex.Message}");
                        return false;
                    }
                }
            }
        }
    }

