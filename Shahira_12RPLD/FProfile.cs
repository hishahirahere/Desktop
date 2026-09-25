using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shahira_12RPLD
{
    public partial class FProfile : Form
    {
        private readonly Color WARNA_BIRU = Color.FromArgb(37, 99, 235);

        public FProfile()
        {
            InitializeComponent();
        }

        private void FProfile_Load(object sender, EventArgs e)
        {
            this.AutoScroll = true; // jaring pengaman kalau ada kontrol yang overflow ke luar layar
            TampilkanDataProfil();
        }

        // ============ AMBIL DATA AKUN USER YANG SEDANG LOGIN ============
        private void TampilkanDataProfil()
        {
            db.crud("SELECT * FROM t_users WHERE id_users = '" + db.idUserLogin + "'");

            if (db.ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Data akun tidak ditemukan.");
                return;
            }

            DataRow baris = db.ds.Tables[0].Rows[0];

            txtUsername.Text = baris["username"].ToString();
            txtUsername.Enabled = false; // username tidak boleh diubah user sendiri
            // (pakai Enabled=false, bukan ReadOnly, supaya teksnya tetap tampil dengan benar)

            txtNamaLengkap.Text = baris["nama_lengkap"].ToString();
            txtEmail.Text = baris["email"].ToString();
            txtNoHp.Text = baris["no_hp"].ToString();
            txtAlamat.Text = baris["alamat"].ToString();
        }

        // ============ SATU TOMBOL: SIMPAN PROFIL + GANTI PASSWORD (JIKA DIISI) ============
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // --- 1. Validasi & simpan data profil (selalu dijalankan) ---
            if (string.IsNullOrWhiteSpace(txtNamaLengkap.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtNoHp.Text))
            {
                MessageBox.Show("Nama lengkap, email, dan nomor HP wajib diisi.",
                                 "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            db.crud("UPDATE t_users SET " +
                     "nama_lengkap = '" + txtNamaLengkap.Text + "', " +
                     "email = '" + txtEmail.Text + "', " +
                     "no_hp = '" + txtNoHp.Text + "', " +
                     "alamat = '" + txtAlamat.Text + "' " +
                     "WHERE id_users = '" + db.idUserLogin + "'");

            // --- 2. Ganti password HANYA kalau kolom password diisi ---
            // Kalau ketiga kolom password kosong semua, berarti user cuma mau
            // update data profil saja, ganti password dilewati (tidak wajib).
            bool adaIsiPassword = !string.IsNullOrWhiteSpace(txtPasswordLama.Text) ||
                                   !string.IsNullOrWhiteSpace(txtPasswordBaru.Text) ||
                                   !string.IsNullOrWhiteSpace(txtKonfirmasiPassword.Text);

            if (adaIsiPassword)
            {
                if (string.IsNullOrWhiteSpace(txtPasswordLama.Text) ||
                    string.IsNullOrWhiteSpace(txtPasswordBaru.Text) ||
                    string.IsNullOrWhiteSpace(txtKonfirmasiPassword.Text))
                {
                    MessageBox.Show("Profil berhasil disimpan.\n\n" +
                                     "Tapi untuk ganti password, semua kolom password harus diisi lengkap.",
                                     "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cek password lama cocok (dibandingkan dalam bentuk hash MD5)
                string hashLama = Form1.MD5Hash(txtPasswordLama.Text);
                db.crud("SELECT * FROM t_users WHERE id_users = '" + db.idUserLogin + "' " +
                         "AND password = '" + hashLama + "'");

                if (db.ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Profil berhasil disimpan.\n\n" +
                                     "Tapi password LAMA yang kamu masukkan salah, password TIDAK diubah.",
                                     "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtPasswordBaru.Text != txtKonfirmasiPassword.Text)
                {
                    MessageBox.Show("Profil berhasil disimpan.\n\n" +
                                     "Tapi konfirmasi password baru tidak cocok, password TIDAK diubah.",
                                     "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtPasswordBaru.Text.Length < 6)
                {
                    MessageBox.Show("Profil berhasil disimpan.\n\n" +
                                     "Tapi password baru minimal 6 karakter, password TIDAK diubah.",
                                     "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string hashBaru = Form1.MD5Hash(txtPasswordBaru.Text);
                db.crud("UPDATE t_users SET password = '" + hashBaru + "' " +
                         "WHERE id_users = '" + db.idUserLogin + "'");

                txtPasswordLama.Clear();
                txtPasswordBaru.Clear();
                txtKonfirmasiPassword.Clear();

                MessageBox.Show("Profil dan password berhasil diperbarui.",
                                 "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Profil berhasil diperbarui.",
                                 "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}