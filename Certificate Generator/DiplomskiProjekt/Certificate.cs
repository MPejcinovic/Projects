using DiplomskiProjekt.Algorithms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiplomskiProjekt
{
    public partial class Certificate : Form
    {
        private Dictionary<string, int> _month = new Dictionary<string, int>();
        public Dictionary<string, int> Month
        {
            get
            {
                return _month;
            }
            set
            {
                _month = value;
            }
        }

        public Certificate()
        {
            InitializeComponent();
            FillMonth();
            cmbBoxSignatureAlgorithm.SelectedIndex = 4;
            var todaysDate = DateTime.UtcNow.Date;
            var todaysDateInYearTime = DateTime.UtcNow.Date.AddYears(1);

            cmbBoxValidFromDay.Text = todaysDate.Day.ToString();
            cmbBoxValidFromMonth.Text = Month.FirstOrDefault(x => x.Value == todaysDate.Month).Key;
            cmbBoxValidFromYear.Text = todaysDate.Year.ToString();

            cmbBoxValidTillDay.Text = todaysDateInYearTime.Day.ToString();
            cmbBoxValidTillMonth.Text = Month.FirstOrDefault(x => x.Value == todaysDateInYearTime.Month).Key;
            cmbBoxValidTillYear.Text = todaysDateInYearTime.Year.ToString();

            txtBoxSiteUrl.Text = @"";
        }

        private void FillComboBoxWithCertificates()
        {
            var certificateCollection = CertificateGenerator.ImportCertificate();
            foreach (var certificate in certificateCollection)
            {
                cmbBoxCertificates.Items.Add(certificate);
            }
        }

        private void FillMonth()
        {
            Month = new Dictionary<string, int>();
            Month.Add("January", 1);
            Month.Add("February", 2);
            Month.Add("March", 3);
            Month.Add("April", 4);
            Month.Add("May", 5);
            Month.Add("June", 6);
            Month.Add("July", 7);
            Month.Add("August", 8);
            Month.Add("September", 9);
            Month.Add("October", 10);
            Month.Add("November", 11);
            Month.Add("December", 12);
        }

        private void btnGenerateCertificate_Click(object sender, EventArgs e)
        {
            var yearFrom = cmbBoxValidFromYear.SelectedItem;
            var yearTill = cmbBoxValidTillYear.SelectedItem;

            string monthFrom = "";
            string monthTill = "";

            var dayFrom = cmbBoxValidFromDay.SelectedItem;
            var dayTill = cmbBoxValidTillDay.SelectedItem;

            try
            {
                DateTime validFrom;
                DateTime validTill;

                if (cmbBoxValidFromMonth.SelectedItem != null)
                {
                    monthFrom = cmbBoxValidFromMonth.SelectedItem.ToString();
                    validFrom = new DateTime(Convert.ToInt32(yearFrom), Month[monthFrom], Convert.ToInt32(dayFrom));
                }
                else
                {
                    monthFrom = cmbBoxValidFromMonth.Text;
                    validFrom = new DateTime(Convert.ToInt32(yearFrom), Convert.ToInt32(monthFrom), Convert.ToInt32(dayFrom));
                }


                if (cmbBoxValidTillMonth.SelectedItem != null)
                {
                    monthTill = cmbBoxValidTillMonth.SelectedItem.ToString();
                    validTill = new DateTime(Convert.ToInt32(yearTill), Month[monthTill], Convert.ToInt32(dayTill));
                }
                else
                {
                    monthTill = cmbBoxValidTillMonth.Text;
                    validTill = new DateTime(Convert.ToInt32(yearTill), Convert.ToInt32(monthTill), Convert.ToInt32(dayTill));
                }

                if ((validTill < DateTime.UtcNow.Date) || (validTill < DateTime.UtcNow.Date)) 
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Date is in the past!";
                    return;
                }

                if (validTill < validFrom)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = String.Format("{0} is before {1}! The certificate could not be created!", validTill, validFrom);
                }
                else
                {
                    CertificateGenerator certificateGenerator = new CertificateGenerator(txtBoxSubjectName.Text,
                                                                                     cmbBoxSignatureAlgorithm.SelectedItem.ToString(),
                                                                                     validFrom,
                                                                                     validTill);
                    var cert = certificateGenerator.CreateCertificate();
                    certificateGenerator.StoreCertificate(cert, StoreName.My, StoreLocation.CurrentUser);
                    lblMessage.Visible = true;
                    lblMessage.Text = "The certificate was successfully created!";
                    btnView.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = ex.Message;
            }

        }

        private void CheckConditions()
        {
            if ((txtBoxSubjectName.Text.Length != 0)
                && (cmbBoxSignatureAlgorithm.Text.Length != 0)
                && (cmbBoxValidFromDay.Text.Length != 0)
                && (cmbBoxValidFromMonth.Text.Length != 0)
                && (cmbBoxValidFromYear.Text.Length != 0)
                && (cmbBoxValidTillDay.Text.Length != 0)
                && (cmbBoxValidTillMonth.Text.Length != 0)
                && (cmbBoxValidTillYear.Text.Length != 0))
            {
                btnGenerateCertificate.Enabled = true;
            }
        }

        private void txtBoxSubjectName_TextChanged(object sender, EventArgs e)
        {
            CheckConditions();
        }

        private void cmbBoxSignatureAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckConditions();
        }

        private void cmbBoxValidFromDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckConditions();
        }

        private void cmbBoxValidFromMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckConditions();
        }

        private void cmbBoxValidFromYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckConditions();
        }

        private void cmbBoxValidTillDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckConditions();
        }

        private void cmbBoxValidTillMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckConditions();
        }

        private void cmbBoxValidTillYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckConditions();
        }

        private void btnGetLists_Click(object sender, EventArgs e)
        {
            if (!(cmbBoxCertificates.SelectedItem.ToString().Contains("38ACD0303460F03A")))
            {
                rtxtBoxListCollection.Text = "The certificate you selected is not valid!";
            }
            else
            {
                var siteUrl = txtBoxSiteUrl.Text;
                AES aes = new AES();
                DiplomskiProjekt.Algorithms.RSA rsa = new DiplomskiProjekt.Algorithms.RSA();

                DigitalEnvelope digitalEnvelope = new DigitalEnvelope(aes, rsa);

                var userName = digitalEnvelope.OpenDigitalEnvelope("UserName");
                var password = digitalEnvelope.OpenDigitalEnvelope("Password");
                if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(password))
                {
                    rtxtBoxListCollection.Text = "Username or password has not been provided!";
                }
                else
                {
                    var sharePointObject = new SPClass(userName, password, siteUrl);
                    try
                    {
                        var listCollection = sharePointObject.GetListFromSharePointOnline();
                        string text = "";

                        foreach (var list in listCollection)
                        {
                            text += String.Format("{0}, Item count: {1}\n", list.Title, list.ItemCount);
                        }
                        rtxtBoxListCollection.Text = text;
                    }
                    catch (Exception ex)
                    {
                        rtxtBoxListCollection.Text = ex.Message;
                    }
                }
            }
        }

        private void txtBoxSiteUrl_TextChanged(object sender, EventArgs e)
        {
            CheckConditionsForEnablingButton();
        }

        private void cmbBoxCertificates_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckConditionsForEnablingButton();
        }

        private void CheckConditionsForEnablingButton()
        {
            if ((cmbBoxCertificates.SelectedIndex != -1) && txtBoxSiteUrl.Text.Length != 0)
            {
                btnGetLists.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl1_SelectedIndexchanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0:
                    cmbBoxCertificates.Items.Clear();
                    break;
                case 1:
                    FillComboBoxWithCertificates();
                    break;
                default:
                    break;
            }
        }

        private void DisplayCert()
        {
            X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

            X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
            X509Certificate2Collection fcollection = (X509Certificate2Collection)collection.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
            X509Certificate2Collection scollection = X509Certificate2UI.SelectFromCollection(fcollection, "Test Certificate Select", "Select a certificate from the following list to get information on that certificate", X509SelectionFlag.MultiSelection);
            Console.WriteLine("Number of certificates: {0}{1}", scollection.Count, Environment.NewLine);

            foreach (X509Certificate2 x509 in scollection)
            {
                try
                {
                    byte[] rawdata = x509.RawData;
                    Console.WriteLine("Content Type: {0}{1}", X509Certificate2.GetCertContentType(rawdata), Environment.NewLine);
                    Console.WriteLine("Certificate Verified?: {0}{1}", x509.Verify(), Environment.NewLine);
                    Console.WriteLine("Simple Name: {0}{1}", x509.GetNameInfo(X509NameType.SimpleName, true), Environment.NewLine);
                    Console.WriteLine("Signature Algorithm: {0}{1}", x509.SignatureAlgorithm.FriendlyName, Environment.NewLine);
                    Console.WriteLine("Private Key: {0}{1}", x509.PrivateKey.ToXmlString(false), Environment.NewLine);
                    Console.WriteLine("Public Key: {0}{1}", x509.PublicKey.Key.ToXmlString(false), Environment.NewLine);
                    Console.WriteLine("Certificate Archived?: {0}{1}", x509.Archived, Environment.NewLine);
                    Console.WriteLine("Length of Raw Data: {0}{1}", x509.RawData.Length, Environment.NewLine);
                    Console.WriteLine("Valid from: {0}{1}", x509.NotBefore, Environment.NewLine);
                    Console.WriteLine("Valid until: {0}{1}", x509.NotAfter, Environment.NewLine);
                    X509Certificate2UI.DisplayCertificate(x509);
                    x509.Reset();
                }
                catch (Exception)
                {
                    Console.WriteLine("Information could not be written out for this certificate.");
                }
            }
            store.Close();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DisplayCert();
        }

    }
}
