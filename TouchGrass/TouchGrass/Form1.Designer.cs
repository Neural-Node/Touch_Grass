using System;
using System.Drawing;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TouchGrass
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private int remainingGrassCount;
        private SoundPlayer soundPlayer;
        private Image grassImage;

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeSoundPlayer();
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;

            // Change the path below to your desired image file path
            string imagePath = "C:\\Users\\Temp\\Desktop\\TouchGrass\\Touch_Grass\\TouchGrass\\TouchGrass\\Green.jpg";
            grassImage = Image.FromFile(imagePath);

            int numBoxes = random.Next(10, 21);
            remainingGrassCount = numBoxes;
            for (int i = 0; i < numBoxes; i++)
            {
                GenerateRandomBox();
            }
        }

        private void GenerateRandomBox()
        {
            int x, y;
            int minDistance = 100;

            do
            {
                x = random.Next(minDistance, this.ClientSize.Width - minDistance);
                y = random.Next(minDistance, this.ClientSize.Height - minDistance);
            } while (false); // No overlap check needed

            int size = 150;
            x -= size / 2;
            y -= size / 2;

            PictureBox box = new PictureBox();
            box.BackgroundImage = grassImage;
            box.BackgroundImageLayout = ImageLayout.Stretch;
            box.Size = new Size(size, size);
            box.Location = new Point(x, y);
            box.MouseClick += Box_MouseClick;

            this.Controls.Add(box);
        }

        private async void Box_MouseClick(object sender, MouseEventArgs e)
        {
            PlaySound();

            PictureBox box = (PictureBox)sender;
            this.Controls.Remove(box);
            box.Dispose();

            remainingGrassCount--;
            if (remainingGrassCount == 0)
            {
                await Task.Delay(1000);
                ShowCuredMessage();
                this.Close();
            }
        }

        private void ShowCuredMessage()
        {
            // Change the path below to your desired image file path
            string imagePath = "C:\\Users\\Temp\\Desktop\\TouchGrass\\Touch_Grass\\TouchGrass\\TouchGrass\\screaming-goat.jpg";

            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile(imagePath);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Dock = DockStyle.Fill;

            Form form = new Form();
            form.WindowState = FormWindowState.Maximized;
            form.BackColor = Color.White;
            form.TransparencyKey = Color.White;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Controls.Add(pictureBox);
            form.TopMost = true;

            // Register the event handler for the click event on the picture box
            pictureBox.Click += (sender, e) =>
            {
                // Close the form when clicked
                form.Close();

                // Show a congratulatory message box
                MessageBox.Show("Congratulations, you have been cured!", "Cured", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            form.ShowDialog();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            PlaySound();
        }

        private void InitializeSoundPlayer()
        {
            soundPlayer = new SoundPlayer();
            // Load custom sound from file
            LoadCustomSound("C:\\Users\\Temp\\Desktop\\TouchGrass\\Touch_Grass\\TouchGrass\\TouchGrass\\goatScream.wav");
        }

        private void PlaySound()
        {
            try
            {
                soundPlayer.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing sound: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCustomSound(string filePath)
        {
            try
            {
                soundPlayer.SoundLocation = filePath;
                soundPlayer.Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load sound file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Magenta;
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.ClientSize = new System.Drawing.Size(1059, 642);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TouchGrass";
            this.Text = "Touch Grass";
            this.Icon = new Icon("C:\\Users\\Temp\\Desktop\\TouchGrass\\Touch_Grass\\TouchGrass\\TouchGrass\\screaming-goat.ico");
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.ResumeLayout(false);
        }
    }
}
