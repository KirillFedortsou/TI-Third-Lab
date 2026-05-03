using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace TIThird
{
    public partial class Form1 : Form
    {
        private string currentFilePath = null;
        private List<BigInteger> encryptedData = null;
        private string lastEncryptedPath = null;
        private RabinCipher cipher;

        public Form1()
        {
            InitializeComponent();
            cipher = new RabinCipher();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnEncrypt.Enabled = false;
            btnDecrypt.Enabled = false;

            UpdateParamHints();
            Log("Готов к работе");
        }

        private void Log(string message)
        {
            txtLog.AppendText($"{message}{Environment.NewLine}");
        }

        private void UpdateParamHints()
        {
            if (BigInteger.TryParse(txtP.Text, out BigInteger p) &&
                BigInteger.TryParse(txtQ.Text, out BigInteger q) &&
                BigInteger.TryParse(txtB.Text, out BigInteger b))
            {
                string hints = $"p = {p}, q = {q}, n = {p * q}";
                if (RabinCipher.IsPrime(p) && RabinCipher.IsPrime(q) && RabinCipher.CheckPQCondition(p, q) && p != q)
                {
                    BigInteger n = p * q;
                    if (b > 0 && b < n)
                        hints += $"\n✓ Параметры корректны";
                    else
                        hints += $"\n✗ b должно быть в (0, {n})";
                }
                else
                {
                    hints += $"\n✗ p и q должны быть простыми и p ≡ q ≡ 3 (mod 4)";
                }
                lblParamHints.Text = hints;
            }
            else
            {
                lblParamHints.Text = "✗ Введите корректные числа";
            }
        }

        private void txtP_TextChanged(object sender, EventArgs e) => UpdateParamHints();
        private void txtQ_TextChanged(object sender, EventArgs e) => UpdateParamHints();
        private void txtB_TextChanged(object sender, EventArgs e) => UpdateParamHints();

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Выберите файл для шифрования";
                ofd.Filter = "Все файлы (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = ofd.FileName;
                    FileInfo fi = new FileInfo(currentFilePath);
                    Log($"Выбран файл: {fi.Name} ({fi.Length} байт)");
                    btnEncrypt.Enabled = true;
                }
            }
        }

        private bool ValidateParams(out BigInteger p, out BigInteger q, out BigInteger b)
        {
            p = 0; q = 0; b = 0;

            if (!BigInteger.TryParse(txtP.Text, out p) || p <= 0)
            {
                MessageBox.Show("p должно быть положительным целым числом", "Ошибка");
                return false;
            }
            if (!BigInteger.TryParse(txtQ.Text, out q) || q <= 0)
            {
                MessageBox.Show("q должно быть положительным целым числом", "Ошибка");
                return false;
            }
            if (!BigInteger.TryParse(txtB.Text, out b) || b <= 0)
            {
                MessageBox.Show("b должно быть положительным целым числом", "Ошибка");
                return false;
            }

            if (!RabinCipher.IsPrime(p))
            {
                MessageBox.Show($"p = {p} не является простым числом", "Ошибка");
                return false;
            }
            if (!RabinCipher.IsPrime(q))
            {
                MessageBox.Show($"q = {q} не является простым числом", "Ошибка");
                return false;
            }
            if (!RabinCipher.CheckPQCondition(p, q))
            {
                MessageBox.Show("p и q должны удовлетворять условию p ≡ q ≡ 3 (mod 4)", "Ошибка");
                return false;
            }
            if (p == q)
            {
                MessageBox.Show("p и q должны быть разными", "Ошибка");
                return false;
            }

            BigInteger n = p * q;
            if (b <= 0 || b >= n)
            {
                MessageBox.Show($"b должно быть в интервале (0, {n})", "Ошибка");
                return false;
            }

            if (n <= 256)
            {
                DialogResult res = MessageBox.Show(
                    $"n = p*q = {n} <= 256. Для однозначной расшифровки байтов рекомендуется n > 255.\nПродолжить?",
                    "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res != DialogResult.Yes)
                    return false;
            }

            return true;
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                MessageBox.Show("Выберите файл для шифрования!", "Ошибка");
                return;
            }

            if (!ValidateParams(out BigInteger p, out BigInteger q, out BigInteger b))
                return;

            try
            {
                cipher.SetParameters(p, q, b);

                byte[] fileData = File.ReadAllBytes(currentFilePath);
                encryptedData = cipher.Encrypt(fileData);

                string encPath = Path.Combine(Path.GetDirectoryName(currentFilePath),
                    Path.GetFileNameWithoutExtension(currentFilePath) + "_encrypted.txt");
                lastEncryptedPath = encPath;

                using (StreamWriter sw = new StreamWriter(encPath))
                {
                    for (int i = 0; i < encryptedData.Count; i++)
                    {
                        sw.Write(encryptedData[i].ToString());
                        if (i < encryptedData.Count - 1)
                            sw.Write(" ");
                    }
                }

                string display = "=== Зашифрованные данные ===\r\n\r\n";

                if (encryptedData.Count <= 20000)
                {
                    for (int i = 0; i < encryptedData.Count; i++)
                    {
                        display += encryptedData[i].ToString() + " ";
                    }
                }
                else
                {
                    for (int i = 0; i < 10000; i++)
                    {
                        display += encryptedData[i].ToString() + " ";
                    }

                    display += $"\r\n\r\n... ещё {encryptedData.Count - 20000} чисел ...\r\n\r\n";

                    for (int i = encryptedData.Count - 10000; i < encryptedData.Count; i++)
                    {
                        display += encryptedData[i].ToString() + " ";
                    }
                }

                txtResult.Text = display;

                FileInfo fi = new FileInfo(currentFilePath);
                Log($"Шифрование завершено: {fi.Name} ({fi.Length} байт) → {encryptedData.Count} чисел.");
                Log($"Сохранено в: {encPath}");

                btnDecrypt.Enabled = true;

                MessageBox.Show($"Шифрование завершено!\n" +
                    $"Исходный файл: {fi.Name} ({fi.Length} байт)\n" +
                    $"Зашифровано чисел: {encryptedData.Count}\n" +
                    $"Сохранено в: {encPath}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log($"Ошибка шифрования: {ex.Message}");
                MessageBox.Show($"Ошибка шифрования: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (encryptedData == null || encryptedData.Count == 0)
            {
                MessageBox.Show("Нет зашифрованных данных. Сначала загрузите зашифрованные данные через кнопку 'Загрузить шифротекст'.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateParams(out BigInteger p, out BigInteger q, out BigInteger b))
                return;

            try
            {
                cipher.SetParameters(p, q, b);

                byte[] decryptedBytes = cipher.Decrypt(encryptedData.ToArray());

                string decPath;

                if (!string.IsNullOrEmpty(lastEncryptedPath))
                {
                    string directory = Path.GetDirectoryName(lastEncryptedPath);
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(lastEncryptedPath);
                    string extension = ".bin";

                    if (!string.IsNullOrEmpty(currentFilePath))
                    {
                        extension = Path.GetExtension(currentFilePath);
                    }

                    decPath = Path.Combine(directory, fileNameWithoutExt + "_decrypted" + extension);
                }
                else if (!string.IsNullOrEmpty(currentFilePath))
                {
                    string originalExt = Path.GetExtension(currentFilePath);
                    decPath = Path.Combine(Path.GetDirectoryName(currentFilePath),
                        Path.GetFileNameWithoutExtension(currentFilePath) + "_decrypted" + originalExt);
                }
                else
                {
                    decPath = Path.Combine(Application.StartupPath, "decrypted_output.bin");
                }

                File.WriteAllBytes(decPath, decryptedBytes);

                Log($"Дешифрование завершено. Получено {decryptedBytes.Length} байт.");
                Log($"Сохранено в: {decPath}");

                string display = "=== Расшифрованные данные ===\r\n\r\n";

                if (decryptedBytes.Length <= 20000)
                {
                    for (int i = 0; i < decryptedBytes.Length; i++)
                    {
                        display += decryptedBytes[i].ToString() + " ";
                    }
                }
                else
                {
                    for (int i = 0; i < 10000; i++)
                    {
                        display += decryptedBytes[i].ToString() + " ";
                    }

                    display += $"\r\n\r\n... ещё {decryptedBytes.Length - 20000} байт ...\r\n\r\n";

                    for (int i = decryptedBytes.Length - 10000; i < decryptedBytes.Length; i++)
                    {
                        display += decryptedBytes[i].ToString() + " ";
                    }
                }

                txtResult.Text = display;

                MessageBox.Show($"Дешифрование завершено!\n" +
                    $"Сохранено в: {decPath}\n" +
                    $"Размер: {decryptedBytes.Length} байт", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log($"Ошибка дешифрования: {ex.Message}");
                MessageBox.Show($"Ошибка дешифрования: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadEncrypted_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Выберите файл с зашифрованными данными (числа через пробел)";
                ofd.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    LoadEncryptedFile(ofd.FileName);
                }
            }
        }

        private void LoadEncryptedFile(string filePath)
        {
            try
            {
                string content = File.ReadAllText(filePath);
                string[] parts = content.Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                encryptedData = new List<BigInteger>();
                foreach (string part in parts)
                {
                    if (BigInteger.TryParse(part, out BigInteger val))
                        encryptedData.Add(val);
                }
                lastEncryptedPath = filePath;

                Log($"Загружено {encryptedData.Count} зашифрованных чисел из {Path.GetFileName(filePath)}");
                btnDecrypt.Enabled = true;

                string display = "=== Загруженные зашифрованные данные ===\r\n\r\n";

                if (encryptedData.Count <= 20000)
                {
                    for (int i = 0; i < encryptedData.Count; i++)
                    {
                        display += encryptedData[i].ToString() + " ";
                    }
                }
                else
                {
                    for (int i = 0; i < 10000; i++)
                    {
                        display += encryptedData[i].ToString() + " ";
                    }

                    display += $"\r\n\r\n... ещё {encryptedData.Count - 20000} чисел ...\r\n\r\n";

                    for (int i = encryptedData.Count - 10000; i < encryptedData.Count; i++)
                    {
                        display += encryptedData[i].ToString() + " ";
                    }
                }

                txtResult.Text = display;

                MessageBox.Show($"Загружено {encryptedData.Count} зашифрованных чисел", "Загрузка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log($"Ошибка загрузки: {ex.Message}");
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
            Log("Готов");
        }
    }
}