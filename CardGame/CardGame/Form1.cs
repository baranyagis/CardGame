using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame
{
    public partial class Form1 : Form
    {
        enum Tiklamalar
        {
            ilkTiklama,ikinciTiklama
        }

        Tiklamalar tiklama = Tiklamalar.ilkTiklama;
        PictureBox oncekiResim;

        public Form1()
        {
            InitializeComponent();
        }

        void ResimGizle()
        {
            foreach (PictureBox x in panel1.Controls) x.Image = imgList.Images[0];
        }

        void ResimGoster()
        {
            foreach (PictureBox x in panel1.Controls) x.Image = imgList.Images[(int)x.Tag];
        }

        void ResimlerDoldur()
        {
            ArrayList tagler = new ArrayList();
            for (int i = 0; i < (imgList.Images.Count - 1) *2; i++) tagler.Add((i % 32) + 1);
            foreach(PictureBox x in panel1.Controls)
            {
                int balli = new Random().Next(tagler.Count);
                x.Tag = tagler[balli];
                tagler.RemoveAt(balli);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResimlerDoldur();
            ResimGizle();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox simdikiResim = sender as PictureBox;
            simdikiResim.Image = imgList.Images[(int)simdikiResim.Tag];
            if (oncekiResim==simdikiResim)
            {
                MessageBox.Show("HATA!");
                return;
            }

            panel1.Refresh();
            switch (tiklama)
            {
                case Tiklamalar.ilkTiklama:
                    oncekiResim = simdikiResim;
                    tiklama = Tiklamalar.ikinciTiklama;
                    break;
                case Tiklamalar.ikinciTiklama:
                    Thread.Sleep(600);
                    if (oncekiResim.Tag.ToString()==simdikiResim.Tag.ToString())
                    {
                        oncekiResim.Hide();
                        simdikiResim.Hide();
                    }

                    ResimGizle();
                    {
                        tiklama = Tiklamalar.ilkTiklama;
                        break;
                    }
                  
            }
        }
    }
}
