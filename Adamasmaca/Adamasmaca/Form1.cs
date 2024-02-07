using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adamasmaca
{
    public partial class Form1 : Form
    {
        Kelimeler klm;
        int klm_uzunlugu;
        int hak_sayisi = 0;
        string kelime;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "resimler\\0.png";
        }
        void txtboxlar_true()
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is Button)
                {
                    item.Enabled = true;
                    item.BackColor = Color.White;
                }

            }
        }

        void kazandiniz()
        {
            int sayac = 0;
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox && !string.IsNullOrWhiteSpace(item.Text))
                {
                    sayac++;
                }
                if (sayac == klm_uzunlugu)
                {
                  
                    MessageBox.Show("Oyun bitti. Kazandınız. Tebrikler.");
                    txtboxlar_true();
                    groupBox2.Controls.Clear();
                    groupBox1.Enabled = false;
                    hak_sayisi = 0;

                }

            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "resimler\\0.png";
            groupBox1.Enabled = true;
            txtboxlar_true();
            groupBox2.Controls.Clear();        
            klm_uzunlugu = (int)numericUpDown1.Value;
            klm = new Kelimeler(klm_uzunlugu);
            kelime = klm.random_kelime_Cek();
            txtbox_Olustur(klm_uzunlugu);
        }

        void txtbox_Olustur(int klmuzunlugu)
        {
            for (int i = 0; i < klmuzunlugu; i++)
            {
                TextBox txt = new TextBox();
                txt.Name = "txt_" + (i + 1);
                txt.Font = new Font(new FontFamily("Microsoft Sans Serif"),30);
                txt.Location = new Point(50 + i * 55, 0);             txt.Visible = true;
                txt.Multiline = true;
                txt.TextAlign = HorizontalAlignment.Center;
                txt.BackColor = System.Drawing.Color.Aqua;
                txt.Size = new Size(50, 50);
                txt.Enabled = false;
                groupBox2.Controls.Add(txt);

            }
        }

        void kelime_dongusu(char c)
        {
            bool harfvar = false;
            List<TextBox> textboxes = new List<TextBox> ();
            foreach (var item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                   textboxes.Add((TextBox)item);
                }

            }
            for (int i = 0; i < klm_uzunlugu; i++)
            {
                if (kelime[i].Equals(c))
                {
                    textboxes[i].Text = c.ToString();
                    harfvar =true;
                }
            }
            if (!harfvar)
            {
                hak_sayisi++;
                resim_degis(hak_sayisi);
            }
         
        }

        void hak_kontrol()
        {
            if (hak_sayisi ==7)
            {
                MessageBox.Show("Oyun bitti. Kaybettiniz.");
                txtboxlar_true();
                groupBox2.Controls.Clear();
                groupBox1.Enabled = false;
                hak_sayisi = 0;

            }
        }

        void resim_degis(int i)
        {
            pictureBox1.ImageLocation = "resimler\\"+i+".png";
            hak_kontrol();
        }

        private void button_Click(object sender, EventArgs e)
        {
            char c;
            Button btn = (Button)sender;
            btn.Enabled = false;
            btn.BackColor = Color.DarkGray;
            kelime_dongusu(btn.Text.ToLower()[0]);
            kazandiniz();
        }
    }
}
