using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rafa27silva
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        dbArabalarEntities1 db = new dbArabalarEntities1();
        private void Form1_Load(object sender, EventArgs e)
        {
            Doldur();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtRenk_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TblArabalar arabalar = new TblArabalar();
            arabalar.marka = int.Parse(cmbMarka.SelectedValue.ToString());
            arabalar.model = int.Parse(cmbModel.SelectedValue.ToString());
            arabalar.renk = txtRenk.Text;
            arabalar.fiyat = float.Parse(txtFiyat.Text);
            arabalar.durum = checkBox1.Checked;
            arabalar.modelYili = int.Parse(txtmodelyili.Text);
            db.TblArabalar.Add(arabalar);
            db.SaveChanges();
            Doldur();
        }
        private void Doldur() {

            var arabalar = db.TblArabalar.Select(x=> new
            {
                x.id,
                x.TblMarka.markaAdi,
                x.TblModeller.modelAdi,
                x.renk,
                x.durum,
                x.fiyat,
                x.modelYili


            }).ToList();
            dataGridView1.DataSource = arabalar;

            var markalar = db.TblMarka.Select(x => new
            {
                id = x.id,
                marka = x.markaAdi
            }).ToList();
            cmbMarka.DataSource = markalar;
            cmbMarka.DisplayMember = "marka";
            cmbMarka.ValueMember = "id";
            dataGridView2.DataSource = markalar;

            var modeller = db.TblModeller.Select(x => new
            {
                id = x.id,
                model = x.modelAdi
            }).ToList();
            cmbModel.DataSource = modeller;
            cmbModel.DisplayMember = "model";
            cmbModel.ValueMember = "id";
            dataGridView3.DataSource = modeller;






        }
        private void button2_Click(object sender, EventArgs e)
        {
            var guncelle = (from x in db.TblArabalar where x.id == arabaid select x).FirstOrDefault();
            guncelle.marka = int.Parse(cmbMarka.SelectedValue.ToString());
            guncelle.model = int.Parse(cmbModel.SelectedValue.ToString());
            guncelle.renk = txtRenk.Text;
            guncelle.fiyat = float.Parse(txtFiyat.Text);
            guncelle.durum = checkBox1.Checked;
            guncelle.modelYili = int.Parse(txtmodelyili.Text);
            db.SaveChanges();
            Doldur();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var sil = (from x in db.TblArabalar where x.id == arabaid select x).FirstOrDefault();
            db.TblArabalar.Remove(sil);
            db.SaveChanges();
            Doldur();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtara1_TextChanged(object sender, EventArgs e)
        {
            var arama = from x in db.TblArabalar
                        where x.TblMarka.markaAdi.Contains(txtara1.Text)
                        select new
                        {
                            x.id,
                            x.TblMarka.markaAdi,
                            x.TblModeller.modelAdi,
                            x.renk,
                            x.durum,
                            x.fiyat,
                            x.modelYili

                        };
            dataGridView1.DataSource = arama.ToList();
           
        }
        int arabaid, markaid, modelid;

        private void button5_Click(object sender, EventArgs e)
        {
            var guncelle = (from x in db.TblMarka where x.id == markaid select x).FirstOrDefault();
            guncelle.markaAdi = txtmarka.Text;
            
            db.SaveChanges();
            Doldur();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var sil = (from x in db.TblMarka where x.id == markaid select x).FirstOrDefault();
            db.TblMarka.Remove(sil);
            db.SaveChanges();
            Doldur();
        }

        private void txtara2_TextChanged(object sender, EventArgs e)
        {
            var arama = from x in db.TblMarka
                        where x.markaAdi.Contains(txtara2.Text)
                        select x;
            dataGridView2.DataSource = arama.ToList();
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            markaid = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            var marka = db.TblMarka.Where(x => x.id == markaid).FirstOrDefault();
            txtmarka.Text = marka.markaAdi;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            TblModeller model = new TblModeller();
            model.modelAdi = txtmodel.Text;
            db.TblModeller.Add(model);
            db.SaveChanges();
            Doldur();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var guncelle = (from x in db.TblModeller where x.id == modelid select x).FirstOrDefault();
            guncelle.modelAdi = txtmodel.Text;

            db.SaveChanges();
            Doldur();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var sil = (from x in db.TblModeller where x.id == modelid select x).FirstOrDefault();
            db.TblModeller.Remove(sil);
            db.SaveChanges();
            Doldur();
        }

        private void txtara3_TextChanged(object sender, EventArgs e)
        {
            var arama = from x in db.TblModeller
                        where x.modelAdi.Contains(txtara3.Text)
                        select x;
            dataGridView3.DataSource = arama.ToList();
        }

        private void dataGridView3_DoubleClick(object sender, EventArgs e)
        {
            modelid = int.Parse(dataGridView3.CurrentRow.Cells[0].Value.ToString());
            var model = db.TblModeller.Where(x => x.id == modelid).FirstOrDefault();
            txtmodel.Text = model.modelAdi;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            TblMarka marka = new TblMarka();
            marka.markaAdi = txtmarka.Text;
            db.TblMarka.Add(marka);
            db.SaveChanges();
            Doldur();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            arabaid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var araba = db.TblArabalar.Where(x => x.id == arabaid).FirstOrDefault();
            cmbMarka.Text = araba.TblMarka.markaAdi;
            cmbModel.Text = araba.TblModeller.modelAdi;
            txtFiyat.Text = araba.fiyat.ToString();
            txtRenk.Text = araba.renk;
            txtmodelyili.Text = araba.modelYili.ToString();
            checkBox1.Checked = (bool)araba.durum;
           
        }
    }
}
