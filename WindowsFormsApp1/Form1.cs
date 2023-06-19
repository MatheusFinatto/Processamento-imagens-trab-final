using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap img1;
        byte[,] vImg1Gray;
        byte[,] vImg1R;
        byte[,] vImg1G;
        byte[,] vImg1B;
        byte[,] vImg1A;

        Bitmap img2;
        byte[,] vImg2Gray;
        byte[,] vImg2R;
        byte[,] vImg2G;
        byte[,] vImg2B;
        byte[,] vImg2A;

        Bitmap img1Origin;
        byte[,] vImg1GrayOrigin;
        byte[,] vImg1ROrigin;
        byte[,] vImg1GOrigin;
        byte[,] vImg1BOrigin;
        byte[,] vImg1AOrigin;

        Bitmap img2Origin;
        byte[,] vImg2GrayOrigin;
        byte[,] vImg2ROrigin;
        byte[,] vImg2GOrigin;
        byte[,] vImg2BOrigin;
        byte[,] vImg2AOrigin;

        int resultIndex = 0;


        private void LoadImgA_Click_1(object sender, EventArgs e)
        {
            // Configurações iniciais da OpenFileDialogBox
            var openFileDialog1 = new OpenFileDialog();
            var filePath = string.Empty;
            openFileDialog1.InitialDirectory = "C:\\Users\\Computação\\Downloads\\MaterialMatlab\\Matlab";
            openFileDialog1.Filter = "TIFF image (*.tif)|*.tif|JPG image (*.jpg)|*.jpg|BMP image (*.bmp)|*.bmp|PNG image (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            // Se um arquivo foi localizado com sucesso...
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Armazena o path do arquivo de imagem
                filePath = openFileDialog1.FileName;

                bool bLoadImgOK = false;
                try
                {
                    img1 = new Bitmap(filePath);
                    img1Origin = new Bitmap(filePath);
                    bLoadImgOK = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro ao abrir imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bLoadImgOK = false;
                }

                // Se a imagem carregou perfeitamente...
                if (bLoadImgOK == true)
                {
                    // Adiciona imagem na PictureBox
                    pictureBox1.Image = img1;
                    vImg1Gray = new byte[img1.Width, img1.Height];
                    vImg1R = new byte[img1.Width, img1.Height];
                    vImg1G = new byte[img1.Width, img1.Height];
                    vImg1B = new byte[img1.Width, img1.Height];
                    vImg1A = new byte[img1.Width, img1.Height];

                    vImg1GrayOrigin = new byte[img1Origin.Width, img1Origin.Height];
                    vImg1ROrigin = new byte[img1Origin.Width, img1Origin.Height];
                    vImg1GOrigin = new byte[img1Origin.Width, img1Origin.Height];
                    vImg1BOrigin = new byte[img1Origin.Width, img1Origin.Height];
                    vImg1AOrigin = new byte[img1Origin.Width, img1Origin.Height];

                    // Percorre todos os pixels da imagem...
                    for (int i = 0; i < img1.Width; i++)
                    {
                        for (int j = 0; j < img1.Height; j++)
                        {
                            Color pixel = img1.GetPixel(i, j);

                            // Para imagens em escala de cinza, extrair o valor do pixel com...
                            byte pixelIntensity = Convert.ToByte((pixel.R + pixel.G + pixel.B) / 3);
                            vImg1Gray[i, j] = pixelIntensity;
                            vImg1GrayOrigin[i, j] = pixelIntensity;

                            // Para imagens RGB, extrair o valor do pixel com...
                            byte R = pixel.R;
                            byte G = pixel.G;
                            byte B = pixel.B;
                            byte A = pixel.A;

                            vImg1R[i, j] = R;
                            vImg1G[i, j] = G;
                            vImg1B[i, j] = B;
                            vImg1A[i, j] = A;

                            vImg1ROrigin[i, j] = R;
                            vImg1GOrigin[i, j] = G;
                            vImg1BOrigin[i, j] = B;
                            vImg1AOrigin[i, j] = A;

                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap finalImage = (Bitmap)pictureBox3.Image;

            using (SaveFileDialog salvarDialog = new SaveFileDialog())
            {
                salvarDialog.Filter = "Arquivos de imagem|*.jpg;*.jpeg;*.png";
                salvarDialog.Title = "Salvar Imagem";
                salvarDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (salvarDialog.ShowDialog() == DialogResult.OK)
                {
                    string caminho = salvarDialog.FileName;
                    finalImage.Save(caminho);

                    MessageBox.Show("Imagem salva!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Abertura_Click(object sender, EventArgs e)
        {
            // Aplica a operação de abertura na imagem img1Gray
            byte[,] vImg1GrayProcessada = Erosao(Dilatacao(vImg1Gray));

            // Atualiza a imagem exibida na pictureBox
            AtualizarImagemPictureBox(vImg1GrayProcessada);
        }

        private void Fechamento_Click(object sender, EventArgs e)
        {
            // Aplica a operação de fechamento na imagem img1Gray
            byte[,] vImg1GrayProcessada = Dilatacao(Erosao(vImg1Gray));

            // Atualiza a imagem exibida na pictureBox
            AtualizarImagemPictureBox(vImg1GrayProcessada);
        }

        private void AtualizarImagemPictureBox(byte[,] imagem)
        {
            Bitmap imagemProcessada = new Bitmap(imagem.GetLength(0), imagem.GetLength(1));

            for (int i = 0; i < imagem.GetLength(0); i++)
            {
                for (int j = 0; j < imagem.GetLength(1); j++)
                {
                    byte pixelIntensity = imagem[i, j];
                    Color pixel = Color.FromArgb(pixelIntensity, pixelIntensity, pixelIntensity);
                    imagemProcessada.SetPixel(i, j, pixel);
                }
            }

            pictureBox3.Image = imagemProcessada;
        }

        private byte[,] Erosao(byte[,] imagem)
        {
            int width = imagem.GetLength(0);
            int height = imagem.GetLength(1);

            byte[,] resultado = new byte[width, height];

            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < height - 1; j++)
                {
                    byte minIntensity = 255;

                    for (int k = -1; k <= 1; k++)
                    {
                        for (int l = -1; l <= 1; l++)
                        {
                            byte intensity = imagem[i + k, j + l];

                            if (intensity < minIntensity)
                            {
                                minIntensity = intensity;
                            }
                        }
                    }

                    resultado[i, j] = minIntensity;
                }
            }

            return resultado;
        }

        private byte[,] Dilatacao(byte[,] imagem)
        {
            int width = imagem.GetLength(0);
            int height = imagem.GetLength(1);

            byte[,] resultado = new byte[width, height];

            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < height - 1; j++)
                {
                    byte maxIntensity = 0;

                    for (int k = -1; k <= 1; k++)
                    {
                        for (int l = -1; l <= 1; l++)
                        {
                            byte intensity = imagem[i + k, j + l];

                            if (intensity > maxIntensity)
                            {
                                maxIntensity = intensity;
                            }
                        }
                    }

                    resultado[i, j] = maxIntensity;
                }
            }

            return resultado;
        }
    }
}
