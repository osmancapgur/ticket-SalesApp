using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace ticketSales
{

    public partial class Form1 : Form
    {

        Random rastgele = new Random();

        string[] firma;
        DateTime gidisTarihi;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;

        }

        private void button3_Click(object sender, EventArgs e)//Koltuk Seçimine Gitme
        {
            farkliSeyehat();
            degerKontrol();
            kontrolEt(1);
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)//Ödemeye Geçme
        {
            degerKontrol();
            koltukKontrol();

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ali Osman ÇAPĞUR\nÖğrenci no: 20219003\nGitHub: osmancapgur\nMail: osmancapgur@gmail.com", "Hakkında");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)//Ödemeyi Tamamlama
        {
            
            kontrolEt(2);
            satilmisKoltuk();
            DialogResult secenek = MessageBox.Show("Satın Almayı Onaylıyor Musunuz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (tabControl1.SelectedIndex == 2)
            {
                if (secenek == DialogResult.Yes& label27.Text != "")
                {
                    MessageBox.Show(firmacomboBox2.Text + " Biletiniz Satın Alınmıştır", "Bizi Tercih Ettiğiniz İçin Teşekkürler");
                    button8.Visible = true;
                    dataGridView1.Rows.Add(textBox3.Text, textBox1.Text, textBox2.Text, cinsiyetcomboBox1.Text,textBox5.Text, firma[0] + " " + firma[1], kalkiscomboBox.Text, variscomboBox.Text, dateTimePicker1.Text + " " + sefercomboBox3.Text, label27.Text,label29.Text);
                    button9.Visible = true;
                    dataGridView1.Visible = true;
                    label27.Text ="";

                }
                else if (label27.Text == "") MessageBox.Show("Koltuk Seçiniz");


                else if (secenek == DialogResult.No)
                {
                    button9.Visible = true;
                    biletKontrol();
                }

            }
            else { MessageBox.Show("Boşlukları Doldurunuz", "HATA"); koltukKontrol(); biletKontrol(); }
            

        }
        
           
        
        void degerKontrol()
        {
            gidisTarihi = dateTimePicker1.Value;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Adınızı Giriniz");

            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Soy Adınızı Giriniz");

            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("T.C. Kimlik No Giriniz");

            }            
            if (textBox4.Text == "")
            {
                MessageBox.Show("Hes Kodunuzu Giriniz");

            }
            if (textBox5.Text == "")
            {
                MessageBox.Show("Cep Telefonu Giriniz");

            }
            if (cinsiyetcomboBox1.Text == "")
            {
                MessageBox.Show("Lütfen Cinsiyetinizi Seçiniz");
                tabControl1.SelectedIndex = 0;

            }
            if (kalkiscomboBox.Text == "")
            {
                MessageBox.Show("Lütfen Kalkış Yeri Seçiniz");
                tabControl1.SelectedIndex = 0;
            }
            else label22.Text = kalkiscomboBox.Text;
            if (variscomboBox.Text == "")
            {
                MessageBox.Show("Lütfen Varış Yeri Seçiniz");
                tabControl1.SelectedIndex = 0;
            }
            else label23.Text = variscomboBox.Text;
            if (sefercomboBox3.Text == "" && dateTimePicker1.Text == "")
            {
                MessageBox.Show("Lütfen Sefer Saatini ve Tarihi Seçiniz");
                tabControl1.SelectedIndex = 0;
            }
            if (gidisTarihi < DateTime.Today) { MessageBox.Show("Bilet Tarihi Bugünden Önce Olamaz"); tabControl1.SelectedIndex = 0; }
            else label25.Text = dateTimePicker1.Text + " " + sefercomboBox3.Text;
            if (firmacomboBox2.Text == "")
            {
                MessageBox.Show("Lütfen Firma Seçiniz");
                tabControl1.SelectedIndex = 0;
            }
            else
            {
                firma = firmacomboBox2.Text.Split(" ");
                label19.Text = firma[0] + " " + firma[1];
                label29.Text = firma[2];

            }
        }
        void kontrolEt(int sayfa)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && cinsiyetcomboBox1.Text != "" && kalkiscomboBox.Text != "" && variscomboBox.Text != "" && sefercomboBox3.Text != "" && dateTimePicker1.Text != "" && firmacomboBox2.Text != "" && gidisTarihi >= DateTime.Today) tabControl1.SelectedIndex = sayfa;
            else tabControl1.SelectedIndex = 0;

        }

        void koltukKontrol()
        {
            bool isAnyRadioButtonChecked = false;

            foreach (RadioButton rdo in groupBox3.Controls.OfType<RadioButton>())
            {
                if (rdo.Checked)
                {
                    isAnyRadioButtonChecked = true;
                    rdo.BackColor = Color.Green;
                    label27.Text = rdo.Text;
                    
                }
                if (rdo.Checked == false && rdo.BackColor == Color.Green)
                {
                    rdo.BackColor = Color.White;
                }

            }
            if (isAnyRadioButtonChecked)
            {
                tabControl1.SelectedIndex = 2;
            }
            else
            {
                MessageBox.Show("Lütfen Koltuk Seçiniz");
            }

        }
        void satilmisKoltuk()
        {

            foreach (RadioButton rdo in groupBox3.Controls.OfType<RadioButton>())
            {
                if (rdo.Checked)
                {
                    rdo.BackColor = Color.Red;
                    rdo.Enabled = false;

                    
                }
            }

        }
        void eskiSeyehatSil()
        {
            foreach (RadioButton rdo in groupBox3.Controls.OfType<RadioButton>())
            {
                if (rdo.BackColor == Color.Red || rdo.BackColor == Color.Green)
                {
                    rdo.BackColor = Color.White;
                    rdo.Enabled = true;
                }
            }
        }
        void biletKontrol()
        {
            if (tabControl1.SelectedIndex == 3)
            {
                MessageBox.Show("BİLETİNİZ BULUNMAMAKTADIR");
                tabControl1.SelectedIndex = 2;
            }
        }
        void farkliSeyehat()
        {
            if (kalkiscomboBox.Text != label22.Text || variscomboBox.Text != label23.Text || firma[0] + " " + firma[1] != label19.Text)
            {
                eskiSeyehatSil();
                rastgeleKoltuk();
            }
        }
        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)//Biletleri Gösterme
        {
            tabControl1.SelectedIndex = 3;
        }

        private void button4_Click(object sender, EventArgs e)//Bilet İptal
        {

            if (dataGridView1.RowCount == 1)
            {
                MessageBox.Show("Biletiniz Bulunmamaktadır", "Hata");
            }
            else
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows.Count);
                MessageBox.Show(" Biletiniz İptal Edilmiştir",label19.Text);
            }
        }

        private void button9_Click(object sender, EventArgs e)//Temizleme
        {
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; cinsiyetcomboBox1.Text = ""; sefercomboBox3.Text = ""; kalkiscomboBox.Text = ""; variscomboBox.Text = ""; firmacomboBox2.Text = ""; label27.Text = ""; label22.Text = ""; label23.Text = ""; label19.Text = "Tekrar Firma Seçiniz";label29.Text = "";textBox5.Text = "";
            eskiSeyehatSil();

            button9.Visible = false;
        }
        private static Random random = new Random();
        void rastgeleKoltuk()
        {
            List<RadioButton> Checkboxlist = new List<RadioButton>();
            foreach (RadioButton control in groupBox3.Controls.OfType<RadioButton>())
            {
                Checkboxlist.Add(control);
                control.BackColor = Color.White;
                control.Enabled = true;
            }

            for (int i = 0; i <= 29; i++)
            {
                var r = random.Next(0, Checkboxlist.Count);
                var checkbox = Checkboxlist[r];
                checkbox.BackColor = Color.Red;
                checkbox.Enabled = false;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);//sadece rakam girdirme
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)&& !char.IsSeparator(e.KeyChar);//sadece harf girme
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);//sadece harf girme

        }
    }
}
