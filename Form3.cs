using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kappa
{
    public partial class Form3 : Form
    {
        private Form1 Form1;

        private float radarRadius = 200; // Radius of the radar
        private float radarRange = 1000; // Maximum range in game units
        private float radarCenterX, radarCenterY; // Center of radar
        private Bitmap radarBitmap; // Reusable bitmap for radar drawing
        private Graphics radarGraphics; // Graphics object for drawing
        private bool needsRedraw = true; // Flag to determine if redrawing is needed

        public Form3(Form1 form)
        {
            InitializeComponent();
            this.Form1 = form;

            radarCenterX = pictureBoxRadar.Width / 2;
            radarCenterY = pictureBoxRadar.Height / 2;

            // Initialize the bitmap and graphics object
            radarBitmap = new Bitmap(pictureBoxRadar.Width, pictureBoxRadar.Height);
            radarGraphics = Graphics.FromImage(radarBitmap);

            pictureBoxRadar.Image = radarBitmap;
            pictureBoxRadar.SizeMode = PictureBoxSizeMode.StretchImage;

            Task.Run(UpdateRadarAsync);
        }

        private void DrawRadar((float X, float Y, float Z, int ID, int HP, string Guild, string Name)[] players)
        {
            if (radarBitmap == null) InitializeRadar(); // Ensure bitmap is initialized

            // Set flag to prevent redundant redraws unless the content changes
            if (!needsRedraw) return;

            // Get your position (call only once at the start)
            var myPosition = Form1.GetMyPosition();

            using (Graphics g = Graphics.FromImage(radarBitmap))
            {
                // Clear previous frame
                g.Clear(Color.Black);

                // Draw radar circle
                Pen radarPen = new Pen(Color.Green, 2);
                g.DrawEllipse(radarPen, radarCenterX - radarRadius, radarCenterY - radarRadius, radarRadius * 2, radarRadius * 2);

                // Draw your position at the center
                g.FillEllipse(Brushes.Yellow, radarCenterX - 3, radarCenterY - 3, 6, 6);

                // Process players once
                foreach (var player in players)
                {
                    // Skip drawing yourself
                    if (player.ID == -1)
                        continue;

                    // Calculate relative position considering X, Y, and Z
                    float relativeX = player.X - myPosition.X;
                    float relativeY = player.Y - myPosition.Y;
                    float relativeZ = player.Z - myPosition.Z;  // Z-axis difference

                    // Calculate distance considering the Z-axis (height)
                    float distance = (float)Math.Sqrt(relativeX * relativeX + relativeY * relativeY + relativeZ * relativeZ);

                    // Only show players within the radar's range
                    if (distance > radarRange) continue;

                    // Scale the player position to radar coordinates
                    float radarX = radarCenterX + (relativeX / radarRange) * radarRadius;
                    float radarY = radarCenterY - (relativeY / radarRange) * radarRadius;

                    // Adjust the Z-axis to show depth (height)
                    float radarZOffset = (relativeZ / radarRange) * radarRadius;

                    // For a more realistic effect, use the Z-axis to adjust the player position's Y value on the radar
                    radarY -= radarZOffset;

                    // Determine player dot color (Red if name contains specific keywords)
                    Brush playerBrush = Brushes.Blue; // Default blue dot
                    if (player.Name.Contains("admin", StringComparison.OrdinalIgnoreCase) ||
                        player.Name.Contains("GM", StringComparison.OrdinalIgnoreCase) ||
                        player.Name.Contains("cafe", StringComparison.OrdinalIgnoreCase))
                    {
                        playerBrush = Brushes.Red; // Red dot for specific players
                    }

                    // Draw player dot (larger dot size - 10x10)
                    g.FillEllipse(playerBrush, radarX - 5, radarY - 5, 10, 10);

                    // Draw Guild Name
                    if (!string.IsNullOrEmpty(player.Guild))
                    {
                        Font guildFont = new Font("Arial", 8, FontStyle.Bold); // Font size set to 8
                        Brush guildBrush = Brushes.White;
                        g.DrawString(player.Guild, guildFont, guildBrush, radarX + 5, radarY - 15);
                    }

                    // Display Name only if conditions met
                    if (player.Name.Contains("admin", StringComparison.OrdinalIgnoreCase) ||
                        player.Name.Contains("GM", StringComparison.OrdinalIgnoreCase) ||
                        player.Name.Contains("cafe", StringComparison.OrdinalIgnoreCase))
                    {
                        Font nameFont = new Font("Arial", 8, FontStyle.Bold);
                        Brush nameBrush = Brushes.White;
                        g.DrawString(player.Name, nameFont, nameBrush, radarX + 5, radarY + 5);
                    }
                }
            }

            // Update PictureBox only if something has changed
            if (needsRedraw)
            {
                pictureBoxRadar.Image = radarBitmap;
                needsRedraw = false; // Disable further redraws until a change happens
            }
        }

        private async Task UpdateRadarAsync()
        {
            while (true)
            {
                try
                {
                    // Check if PictureBox is disposed
                    if (pictureBoxRadar.IsDisposed)
                    {
                        return; // Exit the loop if PictureBox is disposed
                    }

                    if (Form1 == null)
                    {
                        Console.WriteLine("Form1 reference is null.");
                        await Task.Delay(500);
                        continue;
                    }

                    var players = await Form1.GetPlayerAsyncRadar();
                    needsRedraw = true; // Mark as needing redraw
                    DrawRadar(players);

                    // Delay for the next update (reducing the update frequency for better performance)
                    await Task.Delay(200); // Reducing the update rate from 100ms to 200ms
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in UpdateRadarAsync: {ex.Message}");
                }
            }
        }
        private void InitializeRadar()
        {
            // Initialize the bitmap once and reuse it
            radarBitmap = new Bitmap(pictureBoxRadar.Width, pictureBoxRadar.Height);
        }
        private async void Form3_Load(object sender, EventArgs e)
        {
            await UpdateRadarAsync();
        }
    }
}
