using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
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

        private string old_isim = "";
        private string old_tur = "";
        private string old_kisim = "";
        private string old_ksoy = "";
        private string old_firma = "";

        private void urun_ara_func(string param_urun_ismi, string param_urun_turu)
        {
            try
            {
                SQLiteConnection baglan = new SQLiteConnection();
                baglan.ConnectionString = ("Data Source= db/aybar_ticaret_stok.db");
                baglan.Open();
                string sql_command = "";
                if (param_urun_ismi == "*" | param_urun_turu == "*")
                {
                    sql_command = "SELECT * FROM stok;";
                    SQLiteCommand command = new SQLiteCommand(sql_command, baglan);

                    DataTable dt = new DataTable();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                    da.Fill(dt);

                    urun_ara_listeleme.DataSource = dt;
                }
                else if (param_urun_ismi != "" & param_urun_turu == "")
                {
                    sql_command = "SELECT * FROM stok WHERE urun_adi = @param1;";
                    SQLiteParameter param1 = new SQLiteParameter("param1", param_urun_ismi);
                    SQLiteCommand command = new SQLiteCommand(sql_command, baglan);
                    command.Parameters.Add(param1);

                    DataTable dt = new DataTable();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                    da.Fill(dt);

                    urun_ara_listeleme.DataSource = dt;
                }
                else if (param_urun_ismi == "" & param_urun_turu != "")
                {
                    sql_command = "SELECT * FROM stok WHERE urun_turu = @param1;";
                    SQLiteParameter param1 = new SQLiteParameter("param1", param_urun_turu);
                    SQLiteCommand command = new SQLiteCommand(sql_command, baglan);
                    command.Parameters.Add(param1);

                    DataTable dt = new DataTable();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                    da.Fill(dt);

                    urun_ara_listeleme.DataSource = dt;
                }
                else if (param_urun_ismi != "" & param_urun_turu != "")
                {
                    sql_command = "SELECT * FROM stok WHERE urun_adi = @param1 AND urun_turu = @param2;";
                    SQLiteParameter param1 = new SQLiteParameter("param1", param_urun_ismi);
                    SQLiteParameter param2 = new SQLiteParameter("param2", param_urun_turu);
                    SQLiteCommand command = new SQLiteCommand(sql_command, baglan);
                    command.Parameters.Add(param1);
                    command.Parameters.Add(param2);

                    DataTable dt = new DataTable();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                    da.Fill(dt);

                    urun_ara_listeleme.DataSource = dt;
                }
                baglan.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void kisi_ara_func(string param_isim, string param_soyisim)
        {
            try
            {
                SQLiteConnection baglan = new SQLiteConnection();
                baglan.ConnectionString = ("Data Source= db/aybar_ticaret_stok.db");
                baglan.Open();
                string sql_command = "";
                if (param_isim == "*" | param_soyisim == "*")
                {
                    sql_command = "SELECT * FROM kisiler;";
                    SQLiteCommand command = new SQLiteCommand(sql_command, baglan);

                    DataTable dt = new DataTable();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                    da.Fill(dt);

                    kisi_ara_data.DataSource = dt;
                }
                else if (param_isim != "" & param_soyisim == "")
                {
                    sql_command = "SELECT * FROM kisiler WHERE isim = @param1;";
                    SQLiteParameter param1 = new SQLiteParameter("param1", param_isim);
                    SQLiteCommand command = new SQLiteCommand(sql_command, baglan);
                    command.Parameters.Add(param1);

                    DataTable dt = new DataTable();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                    da.Fill(dt);

                    kisi_ara_data.DataSource = dt;
                }
                else if (param_isim == "" & param_soyisim != "")
                {
                    sql_command = "SELECT * FROM kisiler WHERE soyisim = @param1;";
                    SQLiteParameter param1 = new SQLiteParameter("param1", param_soyisim);
                    SQLiteCommand command = new SQLiteCommand(sql_command, baglan);
                    command.Parameters.Add(param1);

                    DataTable dt = new DataTable();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                    da.Fill(dt);

                    kisi_ara_data.DataSource = dt;
                }
                else if (param_isim != "" & param_soyisim != "")
                {
                    sql_command = "SELECT * FROM kisiler WHERE isim = @param1 AND soyisim = @param2;";
                    SQLiteParameter param1 = new SQLiteParameter("param1", param_isim);
                    SQLiteParameter param2 = new SQLiteParameter("param2", param_soyisim);
                    SQLiteCommand command = new SQLiteCommand(sql_command, baglan);
                    command.Parameters.Add(param1);
                    command.Parameters.Add(param2);

                    DataTable dt = new DataTable();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                    da.Fill(dt);

                    kisi_ara_data.DataSource = dt;
                }
                baglan.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void firma_ara_func(string param_firma)
        {
            try
            {
                SQLiteConnection baglan = new SQLiteConnection();
                baglan.ConnectionString = ("Data Source= db/aybar_ticaret_stok.db");
                baglan.Open();
                string sql_command = "";
                if (param_firma == "*")
                {
                    sql_command = "SELECT * FROM firma;";
                    SQLiteCommand command = new SQLiteCommand(sql_command, baglan);

                    DataTable dt = new DataTable();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                    da.Fill(dt);

                    firma_data.DataSource = dt;
                }
                else
                {
                    sql_command = "SELECT * FROM firma WHERE firma_ismi = @param1;";
                    SQLiteParameter param1 = new SQLiteParameter("param1", param_firma);
                    SQLiteCommand command = new SQLiteCommand(sql_command, baglan);
                    command.Parameters.Add(param1);

                    DataTable dt = new DataTable();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                    da.Fill(dt);

                    firma_data.DataSource = dt;
                }
                
                baglan.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void urun_ara_box_temizle()
        {
            urun_ismi.Clear();
            urun_ara_tur_box.Clear();
            urun_id_guncelle_box.Clear();
            urun_ismi_guncelle_box.Clear();
            urun_turu_guncelle_box.Clear();
            urun_marka_guncelle_box.Clear();
            urun_alis_guncelle_box.Clear();
            urun_satis_guncelle_box.Clear();
            urun_miktar_guncelle_box.Clear();
            miktar_degisim.Clear();
            miktar_turu_guncelle.SelectedIndex = -1;
        }

        private void kisi_ara_box_temizle()
        {
            kisi_ara_isim_box.Clear();
            kisi_ara_soyisim_box.Clear();
            kisi_guncelle_isim.Clear();
            kisi_guncelle_soyisim.Clear();
            kisi_guncelle_telefon.Clear();
            kisi_guncelle_miktar.Clear();
            kisi_guncelle_tur.SelectedIndex = -1;
            kisi_miktar_degistir.Clear();
            kisi_id.Clear();
        }

        private void firma_ara_box_temizle()
        {
            firma_ara_isim.Clear();
            firma_adres_guncelle.Clear();
            firma_isim_guncelle.Clear();
            firma_telefon_guncelle.Clear();
            firma_yetkili_guncelle.Clear();
            firma_id.Clear();
        }

        private void veri_ekle_box_temizle()
        {
            urun_ekle_isim.Clear();
            urun_ekle_tur.Clear();
            urun_ekle_marka.Clear();
            urun_ekle_alis.Clear();
            urun_ekle_satis.Clear();
            urun_ekle_miktar.Clear();
            miktar_turu.SelectedIndex = -1;

            kisi_ekle_isim.Clear();
            kisi_ekle_soyisim.Clear();
            kisi_ekle_telefon.Clear();
            kisi_ekle_para.Clear();
            kisi_ekle_tur.SelectedIndex = -1;

            firma_ekle_isim.Clear();
            firma_ekle_adres.Clear();
            firma_ekle_yetkili.Clear();
            firma_ekle_telefon.Clear();
        }

        private void urun_ara_button_Click(object sender, EventArgs e)
        {
            if (urun_ismi.Text == "" & urun_ara_tur_box.Text == "")
            {
                urun_ara_box_temizle();
                MessageBox.Show("Ürün ismi ve türü boş bırakılamaz. Tüm ürünler için * olarak arama yapın.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    old_isim = urun_ismi.Text;
                    old_tur = urun_ara_tur_box.Text;
                    urun_ara_func(old_isim, old_tur);
                    urun_ara_box_temizle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void urun_ekle_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection baglan = new SQLiteConnection();
                baglan.ConnectionString = ("Data Source= db/aybar_ticaret_stok.db");
                baglan.Open();
                string sql_command = "INSERT INTO stok(urun_adi, urun_turu, urun_marka, urun_alis, urun_satis, stok, miktar_turu)" +
                    " VALUES(@param1, @param2, @param3, @param4, @param5, @param6, @param7);";
                
                SQLiteParameter param1 = new SQLiteParameter("param1", urun_ekle_isim.Text);
                SQLiteParameter param2 = new SQLiteParameter("param2", urun_ekle_tur.Text);
                SQLiteParameter param3 = new SQLiteParameter("param3", urun_ekle_marka.Text);
                SQLiteParameter param4 = new SQLiteParameter("param4", urun_ekle_alis.Text);
                SQLiteParameter param5 = new SQLiteParameter("param5", urun_ekle_satis.Text);
                SQLiteParameter param6 = new SQLiteParameter("param6", urun_ekle_miktar.Text);
                SQLiteParameter param7 = new SQLiteParameter("param7", miktar_turu.Text);
                SQLiteCommand command = new SQLiteCommand(sql_command, baglan);
                command.Parameters.Add(param1);
                command.Parameters.Add(param2);
                command.Parameters.Add(param3);
                command.Parameters.Add(param4);
                command.Parameters.Add(param5);
                command.Parameters.Add(param6);
                command.Parameters.Add(param7);

                command.ExecuteNonQuery();
                baglan.Close();
                veri_ekle_box_temizle();
                MessageBox.Show("Ürün başarıyla eklendi.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void veri_ekle_Click(object sender, EventArgs e)
        {
            veri_ekle_panel.Visible = !veri_ekle_panel.Visible;
            veri_ara_panel.Visible = false;
            kisi_ara_panel.Visible = false;
            firma_ara_panel.Visible = false;
            txt_panel.Visible = false;
            veri_ekle_box_temizle();
            urun_ara_box_temizle();
            kisi_ara_box_temizle();
            firma_ara_box_temizle();
            urun_ara_listeleme.DataSource=null;
            kisi_ara_data.DataSource = null;
            firma_data.DataSource = null;
        }

        private void veri_ara_Click(object sender, EventArgs e)
        {
            veri_ekle_panel.Visible = false;
            veri_ara_panel.Visible = !veri_ara_panel.Visible;
            kisi_ara_panel.Visible = false;
            firma_ara_panel.Visible = false;
            txt_panel.Visible = false;
            veri_ekle_box_temizle();
            urun_ara_box_temizle();
            kisi_ara_box_temizle();
            firma_ara_box_temizle();
            urun_ara_listeleme.DataSource = null;
            kisi_ara_data.DataSource = null;
            firma_data.DataSource = null;
        }

        private void kisi_ara_button_Click(object sender, EventArgs e)
        {
            veri_ekle_panel.Visible = false;
            veri_ara_panel.Visible = false;
            kisi_ara_panel.Visible = !kisi_ara_panel.Visible;
            firma_ara_panel.Visible = false;
            txt_panel.Visible = false;
            veri_ekle_box_temizle();
            urun_ara_box_temizle();
            kisi_ara_box_temizle();
            firma_ara_box_temizle();
            urun_ara_listeleme.DataSource = null;
            kisi_ara_data.DataSource = null;
            firma_data.DataSource = null;
        }

        private void firma_ara_button_Click(object sender, EventArgs e)
        {
            veri_ekle_panel.Visible = false;
            veri_ara_panel.Visible = false;
            kisi_ara_panel.Visible = false;
            firma_ara_panel.Visible = !firma_ara_panel.Visible;
            txt_panel.Visible = false;
            veri_ekle_box_temizle();
            urun_ara_box_temizle();
            kisi_ara_box_temizle();
            firma_ara_box_temizle();
            urun_ara_listeleme.DataSource = null;
            kisi_ara_data.DataSource = null;
            firma_data.DataSource = null;
        }

        private void urun_ara_listeleme_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = urun_ara_listeleme.Rows[index];
            urun_id_guncelle_box.Text = selectedRow.Cells[0].Value.ToString();
            urun_ismi_guncelle_box.Text = selectedRow.Cells[1].Value.ToString();
            urun_turu_guncelle_box.Text = selectedRow.Cells[2].Value.ToString();
            urun_marka_guncelle_box.Text = selectedRow.Cells[3].Value.ToString();
            urun_alis_guncelle_box.Text = selectedRow.Cells[4].Value.ToString();
            urun_satis_guncelle_box.Text = selectedRow.Cells[5].Value.ToString();
            urun_miktar_guncelle_box.Text = selectedRow.Cells[6].Value.ToString();
            miktar_turu_guncelle.SelectedItem = selectedRow.Cells[7].Value.ToString();
        }

        private void urun_ara_guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection baglan = new SQLiteConnection();
                baglan.ConnectionString = ("Data Source= db/aybar_ticaret_stok.db");
                baglan.Open();
                string sql_command = "UPDATE stok SET urun_adi = @param1, urun_turu = @param2, urun_marka = @param3, urun_alis = @param4, urun_satis = @param5, stok = @param6, miktar_turu = @param7" +
                    " WHERE id = @param0;";

                SQLiteParameter param0 = new SQLiteParameter("param0", urun_id_guncelle_box.Text);
                SQLiteParameter param1 = new SQLiteParameter("param1", urun_ismi_guncelle_box.Text);
                SQLiteParameter param2 = new SQLiteParameter("param2", urun_turu_guncelle_box.Text);
                SQLiteParameter param3 = new SQLiteParameter("param3", urun_marka_guncelle_box.Text);
                SQLiteParameter param4 = new SQLiteParameter("param4", urun_alis_guncelle_box.Text);
                SQLiteParameter param5 = new SQLiteParameter("param5", urun_satis_guncelle_box.Text);
                SQLiteParameter param6 = new SQLiteParameter("param6", urun_miktar_guncelle_box.Text);
                SQLiteParameter param7 = new SQLiteParameter("param7", miktar_turu_guncelle.Text);

                SQLiteCommand command = new SQLiteCommand(sql_command, baglan);
                command.Parameters.Add(param0);
                command.Parameters.Add(param1);
                command.Parameters.Add(param2);
                command.Parameters.Add(param3);
                command.Parameters.Add(param4);
                command.Parameters.Add(param5);
                command.Parameters.Add(param6);
                command.Parameters.Add(param7);

                command.ExecuteNonQuery();
                baglan.Close();
                urun_ara_box_temizle();
                urun_ara_func(old_isim, old_tur);
                MessageBox.Show("Ürün başarıyla guncellendi.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void alis_guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection baglan = new SQLiteConnection();
                baglan.ConnectionString = ("Data Source= db/aybar_ticaret_stok.db");
                baglan.Open();
                string sql_command = "UPDATE stok SET stok = stok + @param1 WHERE id = @param0;";

                SQLiteParameter param0 = new SQLiteParameter("param0", urun_id_guncelle_box.Text);
                SQLiteParameter param1 = new SQLiteParameter("param1", miktar_degisim.Text);

                SQLiteCommand command = new SQLiteCommand(sql_command, baglan);
                command.Parameters.Add(param0);
                command.Parameters.Add(param1);

                command.ExecuteNonQuery();
                baglan.Close();
                urun_ara_box_temizle();
                urun_ara_func(old_isim, old_tur);
                MessageBox.Show("Ürün başarıyla guncellendi.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void satis_guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection baglan = new SQLiteConnection();
                baglan.ConnectionString = ("Data Source= db/aybar_ticaret_stok.db");
                baglan.Open();
                string sql_command = "UPDATE stok SET stok = stok - @param1 WHERE id = @param0;";

                SQLiteParameter param0 = new SQLiteParameter("param0", urun_id_guncelle_box.Text);
                SQLiteParameter param1 = new SQLiteParameter("param1", miktar_degisim.Text);

                SQLiteCommand command = new SQLiteCommand(sql_command, baglan);
                command.Parameters.Add(param0);
                command.Parameters.Add(param1);

                command.ExecuteNonQuery();
                baglan.Close();
                urun_ara_box_temizle();
                urun_ara_func(old_isim, old_tur);
                MessageBox.Show("Ürün başarıyla guncellendi.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void yedekle_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "./db/aybar_ticaret_stok.db";
                System.IO.File.Copy(path, "./db/aybar_ticaret_stok_yedek.db", true);
                MessageBox.Show("Dosyanın yedeği alındı.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_cikti_Click(object sender, EventArgs e)
        {
            veri_ekle_panel.Visible = false;
            veri_ara_panel.Visible = false;
            kisi_ara_panel.Visible = false;
            firma_ara_panel.Visible = false;
            txt_panel.Visible = !txt_panel.Visible;
            veri_ekle_box_temizle();
            urun_ara_box_temizle();
            kisi_ara_box_temizle();
            firma_ara_box_temizle();
            urun_ara_listeleme.DataSource = null;
            kisi_ara_data.DataSource = null;
            firma_data.DataSource = null;
        }

        private void excel_ciktisi_Click(object sender, EventArgs e)
        {
            veri_ekle_panel.Visible = false;
            veri_ara_panel.Visible = false;
            veri_ekle_box_temizle();
            urun_ara_box_temizle();
            kisi_ara_box_temizle();
            urun_ara_listeleme.DataSource = null;
            MessageBox.Show("YAPIM ASAMASINDA", "BILGI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void kisi_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection baglan = new SQLiteConnection();
                baglan.ConnectionString = ("Data Source= db/aybar_ticaret_stok.db");
                baglan.Open();
                string sql_command = "INSERT INTO kisiler(isim, soyisim, telefon, tur, miktar)" +
                    " VALUES(@param1, @param2, @param3, @param4, @param5);";

                SQLiteParameter param1 = new SQLiteParameter("param1", kisi_ekle_isim.Text);
                SQLiteParameter param2 = new SQLiteParameter("param2", kisi_ekle_soyisim.Text);
                SQLiteParameter param3 = new SQLiteParameter("param3", kisi_ekle_telefon.Text);
                SQLiteParameter param4 = new SQLiteParameter("param4", kisi_ekle_tur.Text);
                SQLiteParameter param5 = new SQLiteParameter("param5", kisi_ekle_para.Text);
                SQLiteCommand command = new SQLiteCommand(sql_command, baglan);
                command.Parameters.Add(param1);
                command.Parameters.Add(param2);
                command.Parameters.Add(param3);
                command.Parameters.Add(param4);
                command.Parameters.Add(param5);

                command.ExecuteNonQuery();
                baglan.Close();
                veri_ekle_box_temizle();
                MessageBox.Show("Kişi başarıyla eklendi.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void firma_ekle_onay_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection baglan = new SQLiteConnection();
                baglan.ConnectionString = ("Data Source= db/aybar_ticaret_stok.db");
                baglan.Open();
                string sql_command = "INSERT INTO firma(firma_ismi, adres, yetkili, telefon)" +
                    " VALUES(@param1, @param2, @param3, @param4);";

                SQLiteParameter param1 = new SQLiteParameter("param1", firma_ekle_isim.Text);
                SQLiteParameter param2 = new SQLiteParameter("param2", firma_ekle_adres.Text);
                SQLiteParameter param3 = new SQLiteParameter("param3", firma_ekle_yetkili.Text);
                SQLiteParameter param4 = new SQLiteParameter("param4", firma_ekle_telefon.Text);
                SQLiteCommand command = new SQLiteCommand(sql_command, baglan);
                command.Parameters.Add(param1);
                command.Parameters.Add(param2);
                command.Parameters.Add(param3);
                command.Parameters.Add(param4);

                command.ExecuteNonQuery();
                baglan.Close();
                veri_ekle_box_temizle();
                MessageBox.Show("Firma başarıyla eklendi.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void kisi_ara_ara_button_Click(object sender, EventArgs e)
        {
            if (kisi_ara_isim_box.Text == "" & kisi_ara_soyisim_box.Text == "")
            {
                kisi_ara_box_temizle();
                MessageBox.Show("İsim ve soyisim boş bırakılamaz. Tüm kişiler için * olarak arama yapın.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    old_kisim = kisi_ara_isim_box.Text;
                    old_ksoy = kisi_ara_soyisim_box.Text;
                    kisi_ara_func(old_kisim, old_ksoy);
                    kisi_ara_box_temizle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void kisi_ara_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = kisi_ara_data.Rows[index];
            kisi_id.Text = selectedRow.Cells[0].Value.ToString();
            kisi_guncelle_isim.Text = selectedRow.Cells[1].Value.ToString();
            kisi_guncelle_soyisim.Text = selectedRow.Cells[2].Value.ToString();
            kisi_guncelle_telefon.Text = selectedRow.Cells[3].Value.ToString();
            kisi_guncelle_miktar.Text = selectedRow.Cells[5].Value.ToString();
            kisi_guncelle_tur.SelectedItem = selectedRow.Cells[4].Value.ToString();
        }

        private void kisi_guncelle_button_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection baglan = new SQLiteConnection();
                baglan.ConnectionString = ("Data Source= db/aybar_ticaret_stok.db");
                baglan.Open();
                string sql_command = "UPDATE kisiler SET isim = @param1, soyisim = @param2, telefon = @param3, tur = @param4, miktar = @param5" +
                    " WHERE id = @param0;";

                SQLiteParameter param0 = new SQLiteParameter("param0", kisi_id.Text);
                SQLiteParameter param1 = new SQLiteParameter("param1", kisi_guncelle_isim.Text);
                SQLiteParameter param2 = new SQLiteParameter("param2", kisi_guncelle_soyisim.Text);
                SQLiteParameter param3 = new SQLiteParameter("param3", kisi_guncelle_telefon.Text);
                SQLiteParameter param4 = new SQLiteParameter("param4", kisi_guncelle_tur.Text);
                SQLiteParameter param5 = new SQLiteParameter("param5", kisi_guncelle_miktar.Text);

                SQLiteCommand command = new SQLiteCommand(sql_command, baglan);
                command.Parameters.Add(param0);
                command.Parameters.Add(param1);
                command.Parameters.Add(param2);
                command.Parameters.Add(param3);
                command.Parameters.Add(param4);
                command.Parameters.Add(param5);

                command.ExecuteNonQuery();
                baglan.Close();
                kisi_ara_box_temizle();
                kisi_ara_func(old_kisim, old_ksoy);
                MessageBox.Show("Kişi başarıyla guncellendi.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void kisi_miktar_azalt_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection baglan = new SQLiteConnection();
                baglan.ConnectionString = ("Data Source= db/aybar_ticaret_stok.db");
                baglan.Open();
                string sql_command = "UPDATE kisiler SET miktar = miktar - @param1 WHERE id = @param0;";

                SQLiteParameter param0 = new SQLiteParameter("param0", kisi_id.Text);
                SQLiteParameter param1 = new SQLiteParameter("param1", kisi_miktar_degistir.Text);

                SQLiteCommand command = new SQLiteCommand(sql_command, baglan);
                command.Parameters.Add(param0);
                command.Parameters.Add(param1);

                command.ExecuteNonQuery();
                baglan.Close();
                kisi_ara_box_temizle();
                kisi_ara_func(old_kisim, old_ksoy);
                MessageBox.Show("Kişi başarıyla guncellendi.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void kisi_miktar_artir_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection baglan = new SQLiteConnection();
                baglan.ConnectionString = ("Data Source= db/aybar_ticaret_stok.db");
                baglan.Open();
                string sql_command = "UPDATE kisiler SET miktar = miktar + @param1 WHERE id = @param0;";

                SQLiteParameter param0 = new SQLiteParameter("param0", kisi_id.Text);
                SQLiteParameter param1 = new SQLiteParameter("param1", kisi_miktar_degistir.Text);

                SQLiteCommand command = new SQLiteCommand(sql_command, baglan);
                command.Parameters.Add(param0);
                command.Parameters.Add(param1);

                command.ExecuteNonQuery();
                baglan.Close();
                kisi_ara_box_temizle();
                kisi_ara_func(old_kisim, old_ksoy);
                MessageBox.Show("Kişi başarıyla guncellendi.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void firma_ara_Click(object sender, EventArgs e)
        {
            if (firma_ara_isim.Text == "")
            {
                kisi_ara_box_temizle();
                MessageBox.Show("Firma İsmi boş bırakılamaz. Tüm veriler için * kullanın.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    old_firma = firma_ara_isim.Text;
                    firma_ara_func(old_firma);
                    firma_ara_box_temizle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void firma_guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection baglan = new SQLiteConnection();
                baglan.ConnectionString = ("Data Source= db/aybar_ticaret_stok.db");
                baglan.Open();
                string sql_command = "UPDATE firma SET firma_ismi = @param1, adres = @param2, yetkili = @param3, telefon = @param4" +
                    " WHERE id = @param0;";

                SQLiteParameter param0 = new SQLiteParameter("param0", firma_id.Text);
                SQLiteParameter param1 = new SQLiteParameter("param1", firma_isim_guncelle.Text);
                SQLiteParameter param2 = new SQLiteParameter("param2", firma_adres_guncelle.Text);
                SQLiteParameter param3 = new SQLiteParameter("param3", firma_yetkili_guncelle.Text);
                SQLiteParameter param4 = new SQLiteParameter("param4", firma_telefon_guncelle.Text);

                SQLiteCommand command = new SQLiteCommand(sql_command, baglan);
                command.Parameters.Add(param0);
                command.Parameters.Add(param1);
                command.Parameters.Add(param2);
                command.Parameters.Add(param3);
                command.Parameters.Add(param4);

                command.ExecuteNonQuery();
                baglan.Close();
                firma_ara_box_temizle();
                firma_ara_func(old_firma);
                MessageBox.Show("Firma başarıyla guncellendi.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void firma_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = firma_data.Rows[index];
            firma_id.Text = selectedRow.Cells[0].Value.ToString();
            firma_isim_guncelle.Text = selectedRow.Cells[1].Value.ToString();
            firma_adres_guncelle.Text = selectedRow.Cells[2].Value.ToString();
            firma_yetkili_guncelle.Text = selectedRow.Cells[3].Value.ToString();
            firma_telefon_guncelle.Text = selectedRow.Cells[4].Value.ToString();
        }

        private void txt_yedek_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_check.Checked)
                {

                    if (urun_yedek.Checked)
                    {
                        SQLiteConnection baglan = new SQLiteConnection();
                        baglan.ConnectionString = ("Data Source= db/aybar_ticaret_stok.db");
                        baglan.Open();
                        string sql_command = "SELECT sql FROM sqlite_master WHERE name = 'stok';";

                        SQLiteCommand command = new SQLiteCommand(sql_command, baglan);

                        command = new SQLiteCommand(sql_command, baglan);
                        SQLiteDataReader datareader = command.ExecuteReader();

                        int ColumnCount = datareader.FieldCount;
                        string ListOfColumns = string.Empty;
                        while (datareader.Read())
                        {
                            for (int i = 0; i <= ColumnCount - 1; i++)
                            {
                                ListOfColumns = ListOfColumns + datareader[i].ToString();
                                if (i < ColumnCount - 1)
                                {
                                    ListOfColumns = ListOfColumns + "|";
                                }
                            }

                            ListOfColumns = ListOfColumns + System.Environment.NewLine;
                        }
                        datareader.Close();

                        sql_command = "select group_concat(name,'|') from pragma_table_info('stok');";
                        command.CommandText = sql_command;
                        datareader = command.ExecuteReader();
                        ColumnCount = datareader.FieldCount;
                        while (datareader.Read())
                        {
                            for (int i = 0; i <= ColumnCount - 1; i++)
                            {
                                ListOfColumns = ListOfColumns + datareader[i].ToString();
                                if (i < ColumnCount - 1)
                                {
                                    ListOfColumns = ListOfColumns + "|";
                                }
                            }

                            ListOfColumns = ListOfColumns + System.Environment.NewLine;
                        }
                        datareader.Close();

                        sql_command = "SELECT * FROM stok;";
                        command.CommandText = sql_command;
                        datareader = command.ExecuteReader();

                        ColumnCount = datareader.FieldCount;
                        while (datareader.Read())
                        {
                            for (int i = 0; i <= ColumnCount - 1; i++)
                            {
                                ListOfColumns = ListOfColumns + datareader[i].ToString();
                                if (i < ColumnCount - 1)
                                {
                                    ListOfColumns = ListOfColumns + "|";
                                }
                            }

                            ListOfColumns = ListOfColumns + System.Environment.NewLine;
                        }
                        baglan.Close();

                        string file_name = @"./db/aybar_ticaret_stok_urun.txt";

                        using (var tw = new StreamWriter(file_name, false))
                        {
                            tw.WriteLine(ListOfColumns);
                        }
                        MessageBox.Show("Txt dosyası oluşturuldu.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (kisi_yedek.Checked)
                    {
                        SQLiteConnection baglan = new SQLiteConnection();
                        baglan.ConnectionString = ("Data Source= db/aybar_ticaret_stok.db");
                        baglan.Open();
                        string sql_command = "SELECT sql FROM sqlite_master WHERE name = 'kisiler';";

                        SQLiteCommand command = new SQLiteCommand(sql_command, baglan);

                        command = new SQLiteCommand(sql_command, baglan);
                        SQLiteDataReader datareader = command.ExecuteReader();

                        int ColumnCount = datareader.FieldCount;
                        string ListOfColumns = string.Empty;
                        while (datareader.Read())
                        {
                            for (int i = 0; i <= ColumnCount - 1; i++)
                            {
                                ListOfColumns = ListOfColumns + datareader[i].ToString();
                                if (i < ColumnCount - 1)
                                {
                                    ListOfColumns = ListOfColumns + "|";
                                }
                            }

                            ListOfColumns = ListOfColumns + System.Environment.NewLine;
                        }
                        datareader.Close();

                        sql_command = "select group_concat(name,'|') from pragma_table_info('kisiler');";
                        command.CommandText = sql_command;
                        datareader = command.ExecuteReader();
                        ColumnCount = datareader.FieldCount;
                        while (datareader.Read())
                        {
                            for (int i = 0; i <= ColumnCount - 1; i++)
                            {
                                ListOfColumns = ListOfColumns + datareader[i].ToString();
                                if (i < ColumnCount - 1)
                                {
                                    ListOfColumns = ListOfColumns + "|";
                                }
                            }

                            ListOfColumns = ListOfColumns + System.Environment.NewLine;
                        }
                        datareader.Close();

                        sql_command = "SELECT * FROM kisiler;";
                        command.CommandText = sql_command;
                        datareader = command.ExecuteReader();

                        ColumnCount = datareader.FieldCount;
                        while (datareader.Read())
                        {
                            for (int i = 0; i <= ColumnCount - 1; i++)
                            {
                                ListOfColumns = ListOfColumns + datareader[i].ToString();
                                if (i < ColumnCount - 1)
                                {
                                    ListOfColumns = ListOfColumns + "|";
                                }
                            }

                            ListOfColumns = ListOfColumns + System.Environment.NewLine;
                        }
                        baglan.Close();

                        string file_name = @"./db/aybar_ticaret_stok_kisiler.txt";

                        using (var tw = new StreamWriter(file_name, false))
                        {
                            tw.WriteLine(ListOfColumns);
                        }
                        MessageBox.Show("Txt dosyası oluşturuldu.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (firma_yedek.Checked)
                    {
                        SQLiteConnection baglan = new SQLiteConnection();
                        baglan.ConnectionString = ("Data Source= db/aybar_ticaret_stok.db");
                        baglan.Open();
                        string sql_command = "SELECT sql FROM sqlite_master WHERE name = 'firma';";

                        SQLiteCommand command = new SQLiteCommand(sql_command, baglan);

                        command = new SQLiteCommand(sql_command, baglan);
                        SQLiteDataReader datareader = command.ExecuteReader();

                        int ColumnCount = datareader.FieldCount;
                        string ListOfColumns = string.Empty;
                        while (datareader.Read())
                        {
                            for (int i = 0; i <= ColumnCount - 1; i++)
                            {
                                ListOfColumns = ListOfColumns + datareader[i].ToString();
                                if (i < ColumnCount - 1)
                                {
                                    ListOfColumns = ListOfColumns + "|";
                                }
                            }

                            ListOfColumns = ListOfColumns + System.Environment.NewLine;
                        }
                        datareader.Close();

                        sql_command = "select group_concat(name,'|') from pragma_table_info('firma');";
                        command.CommandText = sql_command;
                        datareader = command.ExecuteReader();
                        ColumnCount = datareader.FieldCount;
                        while (datareader.Read())
                        {
                            for (int i = 0; i <= ColumnCount - 1; i++)
                            {
                                ListOfColumns = ListOfColumns + datareader[i].ToString();
                                if (i < ColumnCount - 1)
                                {
                                    ListOfColumns = ListOfColumns + "|";
                                }
                            }

                            ListOfColumns = ListOfColumns + System.Environment.NewLine;
                        }
                        datareader.Close();

                        sql_command = "SELECT * FROM firma;";
                        command.CommandText = sql_command;
                        datareader = command.ExecuteReader();

                        ColumnCount = datareader.FieldCount;
                        while (datareader.Read())
                        {
                            for (int i = 0; i <= ColumnCount - 1; i++)
                            {
                                ListOfColumns = ListOfColumns + datareader[i].ToString();
                                if (i < ColumnCount - 1)
                                {
                                    ListOfColumns = ListOfColumns + "|";
                                }
                            }

                            ListOfColumns = ListOfColumns + System.Environment.NewLine;
                        }
                        baglan.Close();

                        string file_name = @"./db/aybar_ticaret_stok_firmalar.txt";

                        using (var tw = new StreamWriter(file_name, false))
                        {
                            tw.WriteLine(ListOfColumns);
                        }
                        MessageBox.Show("Txt dosyası oluşturuldu.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (csv_check.Checked)
                {
                    if (urun_yedek.Checked)
                    {
                        SQLiteConnection baglan = new SQLiteConnection();
                        baglan.ConnectionString = ("Data Source= db/aybar_ticaret_stok.db");
                        baglan.Open();
                        string sql_command = "select group_concat(name,',') from pragma_table_info('stok');";

                        SQLiteCommand command = new SQLiteCommand(sql_command, baglan);

                        command = new SQLiteCommand(sql_command, baglan);
                        SQLiteDataReader datareader = command.ExecuteReader();

                        int ColumnCount = datareader.FieldCount;
                        string ListOfColumns = string.Empty;
                        while (datareader.Read())
                        {
                            for (int i = 0; i <= ColumnCount - 1; i++)
                            {
                                ListOfColumns = ListOfColumns + datareader[i].ToString();
                                if (i < ColumnCount - 1)
                                {
                                    ListOfColumns = ListOfColumns + ",";
                                }
                            }

                            ListOfColumns = ListOfColumns + System.Environment.NewLine;
                        }
                        datareader.Close();

                        sql_command = "SELECT * FROM stok;";
                        command.CommandText = sql_command;
                        datareader = command.ExecuteReader();

                        ColumnCount = datareader.FieldCount;
                        while (datareader.Read())
                        {
                            for (int i = 0; i <= ColumnCount - 1; i++)
                            {
                                ListOfColumns = ListOfColumns + datareader[i].ToString();
                                if (i < ColumnCount - 1)
                                {
                                    ListOfColumns = ListOfColumns + ",";
                                }
                            }

                            ListOfColumns = ListOfColumns + System.Environment.NewLine;
                        }
                        baglan.Close();

                        string file_name = @"./db/aybar_ticaret_stok_urun.csv";

                        using (var tw = new StreamWriter(file_name, false))
                        {
                            tw.WriteLine(ListOfColumns);
                        }
                        MessageBox.Show("CSV dosyası oluşturuldu.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (kisi_yedek.Checked)
                    {
                        SQLiteConnection baglan = new SQLiteConnection();
                        baglan.ConnectionString = ("Data Source= db/aybar_ticaret_stok.db");
                        baglan.Open();
                        string sql_command = "select group_concat(name,',') from pragma_table_info('kisiler');";

                        SQLiteCommand command = new SQLiteCommand(sql_command, baglan);

                        command = new SQLiteCommand(sql_command, baglan);
                        SQLiteDataReader datareader = command.ExecuteReader();

                        int ColumnCount = datareader.FieldCount;
                        string ListOfColumns = string.Empty;
                        while (datareader.Read())
                        {
                            for (int i = 0; i <= ColumnCount - 1; i++)
                            {
                                ListOfColumns = ListOfColumns + datareader[i].ToString();
                                if (i < ColumnCount - 1)
                                {
                                    ListOfColumns = ListOfColumns + ",";
                                }
                            }

                            ListOfColumns = ListOfColumns + System.Environment.NewLine;
                        }
                        datareader.Close();

                        sql_command = "SELECT * FROM kisiler;";
                        command.CommandText = sql_command;
                        datareader = command.ExecuteReader();

                        ColumnCount = datareader.FieldCount;
                        while (datareader.Read())
                        {
                            for (int i = 0; i <= ColumnCount - 1; i++)
                            {
                                ListOfColumns = ListOfColumns + datareader[i].ToString();
                                if (i < ColumnCount - 1)
                                {
                                    ListOfColumns = ListOfColumns + ",";
                                }
                            }

                            ListOfColumns = ListOfColumns + System.Environment.NewLine;
                        }
                        baglan.Close();

                        string file_name = @"./db/aybar_ticaret_stok_kisiler.csv";

                        using (var tw = new StreamWriter(file_name, false))
                        {
                            tw.WriteLine(ListOfColumns);
                        }
                        MessageBox.Show("CSV dosyası oluşturuldu.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (firma_yedek.Checked)
                    {
                        SQLiteConnection baglan = new SQLiteConnection();
                        baglan.ConnectionString = ("Data Source= db/aybar_ticaret_stok.db");
                        baglan.Open();
                        string sql_command = "select group_concat(name,',') from pragma_table_info('firma');";

                        SQLiteCommand command = new SQLiteCommand(sql_command, baglan);

                        command = new SQLiteCommand(sql_command, baglan);
                        SQLiteDataReader datareader = command.ExecuteReader();

                        int ColumnCount = datareader.FieldCount;
                        string ListOfColumns = string.Empty;
                        while (datareader.Read())
                        {
                            for (int i = 0; i <= ColumnCount - 1; i++)
                            {
                                ListOfColumns = ListOfColumns + datareader[i].ToString();
                                if (i < ColumnCount - 1)
                                {
                                    ListOfColumns = ListOfColumns + ",";
                                }
                            }

                            ListOfColumns = ListOfColumns + System.Environment.NewLine;
                        }
                        datareader.Close();

                        sql_command = "SELECT * FROM firma;";
                        command.CommandText = sql_command;
                        datareader = command.ExecuteReader();

                        ColumnCount = datareader.FieldCount;
                        while (datareader.Read())
                        {
                            for (int i = 0; i <= ColumnCount - 1; i++)
                            {
                                ListOfColumns = ListOfColumns + datareader[i].ToString();
                                if (i < ColumnCount - 1)
                                {
                                    ListOfColumns = ListOfColumns + ",";
                                }
                            }

                            ListOfColumns = ListOfColumns + System.Environment.NewLine;
                        }
                        baglan.Close();

                        string file_name = @"./db/aybar_ticaret_stok_firmalar.csv";

                        using (var tw = new StreamWriter(file_name, false))
                        {
                            tw.WriteLine(ListOfColumns);
                        }
                        MessageBox.Show("CSV dosyası oluşturuldu.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
