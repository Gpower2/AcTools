using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Threading;

using AcTools.Core;

using AcToolsLibrary.Common;
using AcToolsLibrary.Core.Hash;

namespace AcTools.Forms
{
	public enum HashType
	{
		MD5,
		MD4,
		ED2K,
		CRC32,
		SHA1,
		SHA256,
		SHA384,
		SHA512,
		TTH
	}

	public partial class frmHashCalculator : AcForm
	{
		private Boolean lowerCase = true;

		public frmHashCalculator()
		{
			InitializeComponent();
			InitColors();
			InitControls();
			InitIcon();
			this.Text = "Hash Calculator";
		}

		private void InitForm()
		{
			txtHashCrc32.Text = String.Empty;
			txtHashMD5.Text = String.Empty;
			txtHashSHA1.Text = String.Empty;
			txtHashSHA256.Text = String.Empty;
			txtHashSHA384.Text = String.Empty;
			txtHashSHA512.Text = String.Empty;
			txtHashTTH.Text = String.Empty;
			lblStatus.Text = string.Empty;
			lowerCase = true;
			btnChangeCase.Text = "To Upper";
		}

		private String CalculateFromFile(HashType ht, String filename)
		{
			byte[] hashBytes = null;
            using (FileStream file = new FileStream(filename, FileMode.Open))
            {
                switch (ht)
                {
                    case HashType.MD5:
                        hashBytes = new MD5CryptoServiceProvider().ComputeHash(file);
                        break;
                    case HashType.MD4:
                        hashBytes = new Md4().ComputeHash(file);
                        break;
                    case HashType.ED2K:
                        hashBytes = new Ed2k().ComputeHash(file);
                        break;
                    case HashType.CRC32:
                        hashBytes = new Crc32().ComputeHash(file);
                        break;
                    case HashType.SHA1:
                        hashBytes = new SHA1CryptoServiceProvider().ComputeHash(file);
                        break;
                    case HashType.SHA256:
                        hashBytes = SHA256.Create().ComputeHash(file);
                        break;
                    case HashType.SHA384:
                        hashBytes = SHA384.Create().ComputeHash(file);
                        break;
                    case HashType.SHA512:
                        hashBytes = SHA512.Create().ComputeHash(file);
                        break;
                    case HashType.TTH:
                        TTH tth = new TTH();
                        tth.Initialize();
                        hashBytes = tth.ComputeHash(file);
                        break;
                }
            }
            StringBuilder hashBuilder = new StringBuilder();
            foreach (byte hashByte in hashBytes)
            {
                hashBuilder.Append(hashByte.ToString("x2").ToLower());
            }
            return hashBuilder.ToString();
		}

		private String CalculateFromText(HashType ht, String str)
		{
			byte[] hashBytes = null;
            StringBuilder hashBuilder = new StringBuilder();
			switch (ht)
			{
				case HashType.MD5:
					//Compute hash based on source data.
					hashBytes = new MD5CryptoServiceProvider().ComputeHash(UTF8Encoding.UTF8.GetBytes(str)); 
					break;
				case HashType.MD4:
					//Compute hash based on source data.
					hashBytes = new Md4().ComputeHash(UTF8Encoding.UTF8.GetBytes(str));
					break;
				case HashType.ED2K:
					//Compute hash based on source data.
					hashBytes = new Ed2k().ComputeHash(UTF8Encoding.UTF8.GetBytes(str));
					break;
				case HashType.CRC32:
                    hashBytes = new Crc32().ComputeHash(UTF8Encoding.UTF8.GetBytes(str));
					break;
				case HashType.SHA1:
					//Compute hash based on source data.
					hashBytes = new SHA1CryptoServiceProvider().ComputeHash(UTF8Encoding.UTF8.GetBytes(str));
					break;
				case HashType.SHA256:
					//Compute hash based on source data.
					hashBytes = SHA256.Create().ComputeHash(UTF8Encoding.UTF8.GetBytes(str));
					break;
				case HashType.SHA384:
					//Compute hash based on source data.
					hashBytes = SHA384.Create().ComputeHash(UTF8Encoding.UTF8.GetBytes(str));
					break;
				case HashType.SHA512:
					//Compute hash based on source data.
					hashBytes = SHA512.Create().ComputeHash(UTF8Encoding.UTF8.GetBytes(str));
					break;
				case HashType.TTH:
					TTH tth = new TTH();
					tth.Initialize();
					hashBytes = tth.ComputeHash(UTF8Encoding.UTF8.GetBytes(str));
					break;
			}

            foreach (Byte hashByte in hashBytes)
            {
                hashBuilder.Append(hashByte.ToString("X2").ToLower());
            }
            return hashBuilder.ToString();
		}

		private void btnBrowseInputFile_Click(object sender, EventArgs e)
		{
			String[] filenames = ShowOpenFileDialog("Select File to hash...", "", "", false);
			if (filenames != null)
			{
				if (filenames[0].Length > 0)
				{
					txtInputFile.Text = filenames[0];
				}
			}
		}

		private void UpdateMD5(String str)
		{
			txtHashMD5.Text = str;
		}

		private void UpdateMD4(String str)
		{
			txtHashMd4.Text = str;
		}

		private void UpdateEd2k(String str)
		{
			txtHashEd2k.Text = str;
		}

		private void UpdateCRC32(String str)
		{
			txtHashCrc32.Text = str;
		}

		private void UpdateSHA1(String str)
		{
			txtHashSHA1.Text = str;
		}

		private void UpdateSHA256(String str)
		{
			txtHashSHA256.Text = str;
		}

		private void UpdateSHA384(String str)
		{
			txtHashSHA384.Text = str;
		}

		private void UpdateSHA512(String str)
		{
			txtHashSHA512.Text = str;
		}

		private void UpdateTTH(String str)
		{
			txtHashTTH.Text = str;
		}

		private void UpdateStatus(String str)
		{
			lblStatus.Text = str;
		}

		private delegate void UpdateHashStringdelegate(String str);

		private void CalculateAllResultsFromFile()
		{
            lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating MD5...");
			txtHashMD5.BeginInvoke(new UpdateHashStringdelegate(this.UpdateMD5), CalculateFromFile(HashType.MD5, txtInputFile.Text));
            lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating MD4...");
            txtHashMd4.BeginInvoke(new UpdateHashStringdelegate(this.UpdateMD4), CalculateFromFile(HashType.MD4, txtInputFile.Text));
            lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating ED2K...");
            txtHashEd2k.BeginInvoke(new UpdateHashStringdelegate(this.UpdateEd2k), CalculateFromFile(HashType.ED2K, txtInputFile.Text));
            lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating CRC32...");
			txtHashCrc32.BeginInvoke(new UpdateHashStringdelegate(this.UpdateCRC32), CalculateFromFile(HashType.CRC32, txtInputFile.Text));
            lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating SHA-1...");
			txtHashSHA1.BeginInvoke(new UpdateHashStringdelegate(this.UpdateSHA1), CalculateFromFile(HashType.SHA1, txtInputFile.Text));
            lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating SHA-256...");
			txtHashSHA256.BeginInvoke(new UpdateHashStringdelegate(this.UpdateSHA256), CalculateFromFile(HashType.SHA256, txtInputFile.Text));
            lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating SHA-384...");
			txtHashSHA384.BeginInvoke(new UpdateHashStringdelegate(this.UpdateSHA384), CalculateFromFile(HashType.SHA384, txtInputFile.Text));
            lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating SHA-512...");
			txtHashSHA512.BeginInvoke(new UpdateHashStringdelegate(this.UpdateSHA512), CalculateFromFile(HashType.SHA512, txtInputFile.Text));
            lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating TTH...");
			txtHashTTH.BeginInvoke(new UpdateHashStringdelegate(this.UpdateTTH), CalculateFromFile(HashType.TTH, txtInputFile.Text));
            lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "");
		}

		private void CalculateAllResultsFromText()
		{
            lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating MD5...");
			txtHashMD5.BeginInvoke(new UpdateHashStringdelegate(this.UpdateMD5), CalculateFromText(HashType.MD5, txtText.Text));
            lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating MD4...");
            txtHashMd4.BeginInvoke(new UpdateHashStringdelegate(this.UpdateMD4), CalculateFromText(HashType.MD4, txtText.Text));
            lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating ED2K...");
            txtHashEd2k.BeginInvoke(new UpdateHashStringdelegate(this.UpdateEd2k), CalculateFromText(HashType.ED2K, txtText.Text));
            lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating CRC32...");
			txtHashCrc32.BeginInvoke(new UpdateHashStringdelegate(this.UpdateCRC32), CalculateFromText(HashType.CRC32, txtText.Text));
            lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating SHA-1...");
			txtHashSHA1.BeginInvoke(new UpdateHashStringdelegate(this.UpdateSHA1), CalculateFromText(HashType.SHA1, txtText.Text));
            lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating SHA-256...");
			txtHashSHA256.BeginInvoke(new UpdateHashStringdelegate(this.UpdateSHA256), CalculateFromText(HashType.SHA256, txtText.Text));
            lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating SHA-384...");
			txtHashSHA384.BeginInvoke(new UpdateHashStringdelegate(this.UpdateSHA384), CalculateFromText(HashType.SHA384, txtText.Text));
            lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating SHA-512...");
			txtHashSHA512.BeginInvoke(new UpdateHashStringdelegate(this.UpdateSHA512), CalculateFromText(HashType.SHA512, txtText.Text));
            lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating TTH...");
			txtHashTTH.BeginInvoke(new UpdateHashStringdelegate(this.UpdateTTH), CalculateFromText(HashType.TTH, txtText.Text));
            lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "");
		}

		private void CalculateFromFile(Object htObj)
		{
			HashType ht = (HashType)htObj;
			try
			{
				switch (ht)
				{
					case HashType.MD5:
                        lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating MD5...");
						txtHashMD5.BeginInvoke(new UpdateHashStringdelegate(this.UpdateMD5), CalculateFromFile(HashType.MD5, txtInputFile.Text));
						break;
					case HashType.MD4:
                        lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating MD4...");
						txtHashMd4.BeginInvoke(new UpdateHashStringdelegate(this.UpdateMD4), CalculateFromFile(HashType.MD4, txtInputFile.Text));
						break;
					case HashType.ED2K:
                        lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating ED2K...");
						txtHashEd2k.BeginInvoke(new UpdateHashStringdelegate(this.UpdateEd2k), CalculateFromFile(HashType.ED2K, txtInputFile.Text));
						break;
					case HashType.CRC32:
                        lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating CRC32...");
						txtHashCrc32.BeginInvoke(new UpdateHashStringdelegate(this.UpdateCRC32), CalculateFromFile(HashType.CRC32, txtInputFile.Text));
						break;
					case HashType.SHA1:
                        lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating SHA-1...");
						txtHashSHA1.BeginInvoke(new UpdateHashStringdelegate(this.UpdateSHA1), CalculateFromFile(HashType.SHA1, txtInputFile.Text));
						break;
					case HashType.SHA256:
                        lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating SHA-256...");
						txtHashSHA256.BeginInvoke(new UpdateHashStringdelegate(this.UpdateSHA256), CalculateFromFile(HashType.SHA256, txtInputFile.Text));
						break;
					case HashType.SHA384:
                        lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating SHA-384...");
						txtHashSHA384.BeginInvoke(new UpdateHashStringdelegate(this.UpdateSHA384), CalculateFromFile(HashType.SHA384, txtInputFile.Text));
						break;
					case HashType.SHA512:
                        lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating SHA-512...");
						txtHashSHA512.BeginInvoke(new UpdateHashStringdelegate(this.UpdateSHA512), CalculateFromFile(HashType.SHA512, txtInputFile.Text));
						break;
					case HashType.TTH:
                        lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating TTH...");
						txtHashTTH.BeginInvoke(new UpdateHashStringdelegate(this.UpdateTTH), CalculateFromFile(HashType.TTH, txtInputFile.Text));
						break;
				}
                lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "");
            }
			catch (Exception ex)
			{
                ShowExceptionMessage(ex, "Error calculating hash!");
			}
		}

		private void CalculateFromText(Object htObj)
		{
			HashType ht = (HashType)htObj;
			try
			{
				switch (ht)
				{
					case HashType.MD5:
                        lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating MD5...");
						txtHashMD5.BeginInvoke(new UpdateHashStringdelegate(this.UpdateMD5), CalculateFromText(HashType.MD5, txtText.Text));
						break;
					case HashType.MD4:
                        lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating MD4...");
						txtHashMd4.BeginInvoke(new UpdateHashStringdelegate(this.UpdateMD4), CalculateFromText(HashType.MD4, txtText.Text));
						break;
					case HashType.ED2K:
                        lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating ED2K...");
						txtHashEd2k.BeginInvoke(new UpdateHashStringdelegate(this.UpdateEd2k), CalculateFromText(HashType.ED2K, txtText.Text));
						break;
					case HashType.CRC32:
                        lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating CRC32...");
						txtHashCrc32.BeginInvoke(new UpdateHashStringdelegate(this.UpdateCRC32), CalculateFromText(HashType.CRC32, txtText.Text));
						break;
					case HashType.SHA1:
                        lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating SHA-1...");
						txtHashSHA1.BeginInvoke(new UpdateHashStringdelegate(this.UpdateSHA1), CalculateFromText(HashType.SHA1, txtText.Text));
						break;
					case HashType.SHA256:
                        lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating SHA-256...");
						txtHashSHA256.BeginInvoke(new UpdateHashStringdelegate(this.UpdateSHA256), CalculateFromText(HashType.SHA256, txtText.Text));
						break;
					case HashType.SHA384:
                        lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating SHA-384...");
						txtHashSHA384.BeginInvoke(new UpdateHashStringdelegate(this.UpdateSHA384), CalculateFromText(HashType.SHA384, txtText.Text));
						break;
					case HashType.SHA512:
                        lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating SHA-512...");
						txtHashSHA512.BeginInvoke(new UpdateHashStringdelegate(this.UpdateSHA512), CalculateFromText(HashType.SHA512, txtText.Text));
						break;
					case HashType.TTH:
                        lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "Calculating TTH...");
						txtHashTTH.BeginInvoke(new UpdateHashStringdelegate(this.UpdateTTH),  CalculateFromText(HashType.TTH, txtText.Text));
						break;
				}
                lblStatus.BeginInvoke(new UpdateHashStringdelegate(this.UpdateStatus), "");
            }
			catch (Exception ex)
			{
                ShowExceptionMessage(ex, "Error calculating hash!");
			}
		}

		private Boolean CheckInputFile()
		{
			if (String.IsNullOrWhiteSpace( txtInputFile.Text))
			{
				return false;
			}
			if (!File.Exists(txtInputFile.Text))
			{
				return false;
			}
			return true;
		}

        private delegate void CalAllHashDelegate();
		private void btnCalculateAll_Click(object sender, EventArgs e)
		{
            CalAllHashDelegate functionToExecute = null;
			if (tabCtrlInput.SelectedTab == tabPageFile)
			{
				if (!CheckInputFile())
				{
					return;
				}
                functionToExecute = new CalAllHashDelegate(CalculateAllResultsFromFile);
			}
			else
			{
                functionToExecute = new CalAllHashDelegate(CalculateAllResultsFromText);
			}

            swapCalculateButtons();
            Thread t = new Thread(new ThreadStart(functionToExecute));
            t.Start();

            while (t.ThreadState != ThreadState.Stopped)
            {
                Application.DoEvents();
            }
            swapCalculateButtons();
		}

		private void swapCalculateButtons()
		{
			btnBrowseInputFile.Enabled = !btnBrowseInputFile.Enabled;
			btnCalculateAll.Enabled = !btnCalculateAll.Enabled;
			btnCalculateCRC32.Enabled = !btnCalculateCRC32.Enabled;
			btnCalculateMD5.Enabled = !btnCalculateMD5.Enabled;
			btnCalculateMD4.Enabled = !btnCalculateMD4.Enabled;
			btnCalculateEd2k.Enabled = !btnCalculateEd2k.Enabled;
			btnCalculateSHA1.Enabled = !btnCalculateSHA1.Enabled;
			btnCalculateSHA256.Enabled = !btnCalculateSHA256.Enabled;
			btnCalculateSHA384.Enabled = !btnCalculateSHA384.Enabled;
			btnCalculateSHA512.Enabled = !btnCalculateSHA512.Enabled;
			btnCalculateTTH.Enabled = !btnCalculateTTH.Enabled;
		}

		private void txtInputFile_DragDrop(object sender, DragEventArgs e)
		{
			String[] s = (String[])e.Data.GetData(DataFormats.FileDrop, false);
			txtInputFile.Text = s[0];
		}

		private void txtInputFile_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.All;
			else
				e.Effect = DragDropEffects.None;
		}

        private delegate void CalHashDelegate(Object x); 
		private void btnCalculateHash_Click(object sender, EventArgs e)
		{
            CalHashDelegate functionToExecute = null;
            HashType hType = HashType.MD5;

			if (tabCtrlInput.SelectedTab == tabPageFile)
			{
				if (!CheckInputFile())
				{
					return;
				}
                functionToExecute = new CalHashDelegate(CalculateFromFile);
			}
			else
			{
                functionToExecute = new CalHashDelegate(CalculateFromText);
			}

            if (sender == btnCalculateMD5)
            {
                hType = HashType.MD5;
            }
            else if (sender == btnCalculateMD4)
            {
                hType = HashType.MD4;
            }
            else if (sender == btnCalculateCRC32)
            {
                hType = HashType.CRC32;
            }
            else if (sender == btnCalculateEd2k)
            {
                hType = HashType.ED2K;
            }
            else if (sender == btnCalculateSHA1)
            {
                hType = HashType.SHA1;
            }
            else if (sender == btnCalculateSHA256)
            {
                hType = HashType.SHA256;
            }
            else if (sender == btnCalculateSHA384)
            {
                hType = HashType.SHA384;
            }
            else if (sender == btnCalculateSHA512)
            {
                hType = HashType.SHA512;
            }
            else if (sender == btnCalculateTTH)
            {
                hType = HashType.TTH;
            }

            swapCalculateButtons();
            Thread t = new Thread(new ParameterizedThreadStart(functionToExecute));
            t.Start(hType);

            while (t.ThreadState != ThreadState.Stopped)
            {
                Application.DoEvents();
            }
            swapCalculateButtons();
		}

		private void btnHook_Click(object sender, EventArgs e)
		{
			HookUnHook(btnHook);
		}

		private void btnChangeCase_Click(object sender, EventArgs e)
		{
			if (lowerCase)
			{
                txtHashCrc32.Text = txtHashCrc32.Text.ToUpper();
				txtHashMD5.Text = txtHashMD5.Text.ToUpper();
                txtHashMd4.Text = txtHashMd4.Text.ToUpper();
                txtHashEd2k.Text = txtHashEd2k.Text.ToUpper();
                txtHashSHA1.Text = txtHashSHA1.Text.ToUpper();
                txtHashSHA256.Text = txtHashSHA256.Text.ToUpper();
                txtHashSHA384.Text = txtHashSHA384.Text.ToUpper();
                txtHashSHA512.Text = txtHashSHA512.Text.ToUpper();
                txtHashTTH.Text = txtHashTTH.Text.ToUpper();
				btnChangeCase.Text = "To Lower";
				lowerCase = false;
			}
			else
			{
                txtHashCrc32.Text = txtHashCrc32.Text.ToLower();
				txtHashMD5.Text = txtHashMD5.Text.ToLower();
                txtHashMd4.Text = txtHashMd4.Text.ToLower();
                txtHashEd2k.Text = txtHashEd2k.Text.ToLower();
                txtHashSHA1.Text = txtHashSHA1.Text.ToLower();
                txtHashSHA256.Text = txtHashSHA256.Text.ToLower();
                txtHashSHA384.Text = txtHashSHA384.Text.ToLower();
                txtHashSHA512.Text = txtHashSHA512.Text.ToLower();
                txtHashTTH.Text = txtHashTTH.Text.ToLower();
				btnChangeCase.Text = "To Upper";
				lowerCase = true;
			}
		}

		private void txtInputFile_TextChanged(object sender, EventArgs e)
		{
			InitForm();
		}
	}
}
