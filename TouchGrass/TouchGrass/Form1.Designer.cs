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
        private int score = 0;
        private Label scoreLabel;
        private int remainingGrassCount;
        private SoundPlayer soundPlayer;

        // Load an image
        private Image grassImage = Image.FromFile("C:\\Users\\tgfel\\Desktop\\TouchGrass\\Touch_Grass\\TouchGrass\\TouchGrass\\Green.jpg");



        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeSoundPlayer();
            // Set form properties
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;

            // Create and position the score label
            scoreLabel = new Label();
            scoreLabel.ForeColor = Color.White;
            scoreLabel.Font = new Font(scoreLabel.Font.FontFamily, 20);
            UpdateScoreLabel();
            scoreLabel.AutoSize = true;
            scoreLabel.Location = new Point((this.ClientSize.Width - scoreLabel.Width) / 2, 20);
            this.Controls.Add(scoreLabel);

            // Generate random number of boxes between 10 and 20
            int numBoxes = random.Next(10, 21);
            remainingGrassCount = numBoxes;
            for (int i = 0; i < numBoxes; i++)
            {
                GenerateRandomBox();
            }
        }

        private void UpdateScoreLabel()
        {
            scoreLabel.Text = $"Score: {score}";
        }

        private void GenerateRandomBox()
        {
            int x, y;
            int minDistance = 100; // Minimum distance between box and score label

            do
            {
                x = random.Next(minDistance, this.ClientSize.Width - minDistance);
                y = random.Next(minDistance, this.ClientSize.Height - minDistance);
            } while (IsOverlapWithScore(x, y));

            int size = 150; // Set the size of the grass square
            x -= size / 2; // Adjust x position to center the square
            y -= size / 2; // Adjust y position to center the square

            // Create a new PictureBox to represent the green box
            PictureBox box = new PictureBox();
            box.BackgroundImage = grassImage; // Set the background image
            box.BackgroundImageLayout = ImageLayout.Stretch; // Stretch the image to fit the box
            box.Size = new Size(size, size); // Set the size of the box
            box.Location = new Point(x, y);
            box.MouseClick += Box_MouseClick;

            // Add the PictureBox to the form
            this.Controls.Add(box);
        }

        private bool IsOverlapWithScore(int x, int y)
        {
            Rectangle scoreBounds = new Rectangle(scoreLabel.Location, scoreLabel.Size);
            return scoreBounds.Contains(new Point(x, y));
        }

        private async void Box_MouseClick(object sender, MouseEventArgs e)
        {
            // Play sound
            PlaySound();

            // Remove the clicked green box from the form
            PictureBox box = (PictureBox)sender;
            this.Controls.Remove(box);
            box.Dispose(); // Clean up resources
            score++; // Increment score
            UpdateScoreLabel(); // Update score label

            remainingGrassCount--;
            if (remainingGrassCount == 0)
            {
                await Task.Delay(1000); // Wait for a moment before showing the message
                MessageBox.Show("Congratulations! You have now been cured.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Close the application
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            // Play sound when a miss click occurs
            PlaySound();
        }

        private void InitializeSoundPlayer()
        {
            // Initialize the sound player
            soundPlayer = new SoundPlayer();
            // Load custom sound from file
            LoadCustomSound("C:\\Users\\tgfel\\Desktop\\TouchGrass\\Touch_Grass\\TouchGrass\\TouchGrass\\goatScream.wav");
        }

        private void PlaySound()
        {
            // Play sound
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
            // Load the custom sound from the specified file path
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
            this.BackColor = System.Drawing.Color.Magenta; // Set the background color to a color not used in your form
            this.TransparencyKey = System.Drawing.Color.Magenta; // Set the TransparencyKey to the same color
            this.ClientSize = new System.Drawing.Size(1059, 642);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; // Remove the border
            this.Name = "TouchGrass";
            this.Text = "Touch Grass";
            this.TopMost = true; // Keep the form on top of other windows
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click); // Add click event handler for the form
            this.ResumeLayout(false);
        }
    }
}
