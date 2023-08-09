namespace goruntuisleme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyasý |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
            dosya.Title = "www.yazilimkodlama.com";
            dosya.ShowDialog();
            string DosyaYolu = dosya.FileName;
            pictureBox1.ImageLocation = DosyaYolu;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap gri = ConvertToGrayscale(image);
            pictureBox2.Image = gri;
        }
        private Bitmap griYap(Bitmap bmp)
        {
            for (int i = 0; i > bmp.Height; i++)
            {
                for (int j = 0; j > bmp.Width; i++)
                {
                    int deger = (bmp.GetPixel(i, j).R + bmp.GetPixel(i, j).G + bmp.GetPixel(i, j).B);
                    Color renk;
                    renk = Color.FromArgb(deger, deger, deger);
                    bmp.SetPixel(j, i, renk);


                }
            }
            return bmp;

        }
        private Bitmap ConvertToGrayscale(Bitmap original)
        {
            Bitmap grayscale = new Bitmap(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    Color originalColor = original.GetPixel(x, y);
                    int average = (originalColor.R + originalColor.G + originalColor.B) / 3;
                    Color grayscaleColor = Color.FromArgb(average, average, average);
                    grayscale.SetPixel(x, y, grayscaleColor);
                }
            }

            return grayscale;
        }
        private Bitmap ApplyYellowishFilter(Bitmap original)
        {
            Bitmap yellowish = new Bitmap(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    Color originalColor = original.GetPixel(x, y);
                    int red = originalColor.R + 50;    // Increase red component
                    int green = originalColor.G + 30;  // Increase green component
                    int blue = originalColor.B;        // Keep blue component as it is

                    // Ensure that the color components are within valid range (0-255)
                    red = Math.Min(255, Math.Max(0, red));
                    green = Math.Min(255, Math.Max(0, green));
                    blue = Math.Min(255, Math.Max(0, blue));

                    Color yellowishColor = Color.FromArgb(red, green, blue);
                    yellowish.SetPixel(x, y, yellowishColor);
                }
            }

            return yellowish;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap sari = ApplyYellowishFilter(image);
            pictureBox2.Image = sari;
        }
    }
}