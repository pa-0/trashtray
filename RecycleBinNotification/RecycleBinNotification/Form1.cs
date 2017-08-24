using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using Shell32;
using System.Resources;
using System.Security.Permissions;
using System.Diagnostics;
using System.IO;

namespace NBin
{
    
    public partial class Form1 : Form
    {
        public int wybrany_set = Convert.ToInt32((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\pionner\NBin", "set", null));
        public string jezyk_p = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\pionner\NBin", "lang", null);


        [System.Runtime.InteropServices.DllImport("Shell32.dll")]
        private static extern int SHChangeNotify(int eventId, int flags, IntPtr item1, IntPtr item2);


        private static int WM_QUERYENDSESSION = 0x11;
        private static bool systemShutdown = false;
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == WM_QUERYENDSESSION)
            {
                //MessageBox.Show("queryendsession: this is a logoff, shutdown, or reboot");
                systemShutdown = true;
            }
            base.WndProc(ref m);

        }

        public string lang(string nazwa)
        {
            if (jezyk_p == "pl")
            {
                if (nazwa == "settings")
                    return "Ustawienia";
                else if (nazwa == "bin")
                    return "Kosz";
                else if (nazwa == "empty")
                    return "(pusty)";
                else if (nazwa == "start_on_boot")
                    return "Uruchom przy starcie PC";
                else if (nazwa == "kill")
                    return "Wyłącz program";
                else if (nazwa == "empty_bin")
                    return "Opróżnij kosz";
                else if (nazwa == "close")
                    return "Zamknij ustawienia";
                else if (nazwa == "kill_sure")
                    return "Na pewno chcesz wyłączyć NBin?";
                else if (nazwa == "open")
                    return "Otwórz";
                else if (nazwa == "hide_on_desktop")
                    return "Ukryj kosz na pulpicie";

            }
            else
            {
                if (nazwa == "settings")
                    return "Settings";
                else if (nazwa == "bin")
                    return "Recycle Bin";
                else if (nazwa == "empty")
                    return "(empty)";
                else if (nazwa == "start_on_boot")
                    return "Start with PC";
                else if (nazwa == "kill")
                    return "Kill program";
                else if (nazwa == "empty_bin")
                    return "Empty Recycle Bin";
                else if (nazwa == "close")
                    return "Close settings";
                else if (nazwa == "kill_sure")
                    return "Are You sure You want to close NBin?";
                else if (nazwa == "open")
                    return "Open";
                else if (nazwa == "hide_on_desktop")
                    return "Hide bin on desktop";
            }

            return "error";
        }

        public void load_lang()
        {
            jezyk_p = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\pionner\NBin", "lang", null);
            start_on_boot.Text = lang("start_on_boot");
            close.Text = lang("close");
            kill.Text = lang("kill");
            hide_on_desktop.Text = lang("hide_on_desktop");
            wczytaj_liste();
        }



        public class IconExtractor
        {

            public static Icon Extract(string file, int number, bool largeIcon)
            {
                IntPtr large;
                IntPtr small;
                ExtractIconEx(file, number, out large, out small, 1);
                try
                {
                    return Icon.FromHandle(largeIcon ? large : small);
                }
                catch
                {
                    return null;
                }

            }
            [DllImport("Shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            private static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion, out IntPtr piSmallVersion, int amountIcons);

        }



        public Form1()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var Params = base.CreateParams;
                Params.ExStyle |= 0x80;
                return Params;
            }
        }

        enum RecycleFlags : uint
        {
            SHERB_NOCONFIRMATION = 0x00000001,
            SHERB_NOPROGRESSUI = 0x00000001,
            SHERB_NOSOUND = 0x00000004
        }

        [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
        static extern uint SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath,
        RecycleFlags dwFlags);

        [DllImport("shell32.dll")]
        static extern int SHQueryRecycleBin(string pszRootPath, ref SHQUERYRBINFO
           pSHQueryRBInfo);

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct SHQUERYRBINFO
        {
            public int cbSize;
            public long i64Size;
            public long i64NumItems;
        }

        public static int GetCount()
        {
            SHQUERYRBINFO sqrbi = new SHQUERYRBINFO();
            sqrbi.cbSize = Marshal.SizeOf(typeof(SHQUERYRBINFO));
            int hresult = SHQueryRecycleBin(string.Empty, ref sqrbi);
            return (int)sqrbi.i64NumItems;
        }

        private void ikona_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("shell:RecycleBinFolder");
        }

        public void wczytaj_liste()
        {
            menu.Items.Clear();


            var item = new ToolStripMenuItem(lang("open"));
            

            switch (wybrany_set)
            {
                case 1:
                case 2:
                case 7:
                case 8:
                    item.Image = IconExtractor.Extract("imageres.dll", 3, false).ToBitmap();
                    break;
                default:
                    item.Image = global::NBin.Properties.Resources.folder;
                    break;
            }

            menu.Items.Add(item);

            item = new ToolStripMenuItem(lang("empty_bin"));
            switch (wybrany_set)
            {
                case 1:
                    item.Image = global::NBin.Properties.Resources.empty1.ToBitmap();
                    break;
                case 2:
                    item.Image = global::NBin.Properties.Resources.empty2.ToBitmap();
                    break;
                case 3:
                    item.Image = global::NBin.Properties.Resources.empty3.ToBitmap();
                    break;
                case 4:
                    item.Image = global::NBin.Properties.Resources.empty4.ToBitmap();
                    break;
                case 5:
                    item.Image = global::NBin.Properties.Resources.empty5.ToBitmap();
                    break;
                case 6:
                    item.Image = global::NBin.Properties.Resources.empty6.ToBitmap();
                    break;
                case 7:
                    item.Image = IconExtractor.Extract("imageres.dll", 50, false).ToBitmap();
                    break;
                case 8:
                    item.Image = IconExtractor.Extract("shell32.dll", 101, false).ToBitmap();
                    break;

            }

            menu.Items.Add(item);


            try
            {
                String[] values;
                if (Environment.Is64BitOperatingSystem)
                {
                    RegistryKey localMachineX64View = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64);
                    values = localMachineX64View.OpenSubKey(@"CLSID\{645FF040-5081-101B-9F08-00AA002F954E}\shell").GetSubKeyNames();
                }
                else
                {
                    values = Registry.ClassesRoot.OpenSubKey(@"CLSID\{645FF040-5081-101B-9F08-00AA002F954E}\shell").GetSubKeyNames();
                }


                int ilosc = 0;
                foreach (String value in values)
                {
                    if (value != "empty")
                    {
                        ilosc++;
                    }
                }

                if (ilosc != 0)
                    menu.Items.Add(new ToolStripSeparator());

                foreach (String value in values)
                {
                    if (value != "empty")
                    {
                        menu.Items.Add(value);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
                menu.Items.Add(new ToolStripSeparator());

                item = new ToolStripMenuItem(lang("settings"));
                item.Image = global::NBin.Properties.Resources.settings;
                menu.Items.Add(item);

            
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {

            //string[] args = Environment.GetCommandLineArgs();

            /*foreach (string arg in args)
            {
                if (arg == "install")
                {
                    Registry.SetValue(@"HKEY_CURRENT_USER\Software\pionner\NBin", "firstrun", "1");
                    Registry.SetValue(@"HKEY_CURRENT_USER\Software\pionner\NBin", "lang", "en");
                    Registry.SetValue(@"HKEY_CURRENT_USER\Software\pionner\NBin", "set", "1");
                    try
                    {
                        Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\NBin");
                    }
                    catch (Exception) { }
                    try
                    {
                        File.Copy(System.AppDomain.CurrentDomain.FriendlyName, Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\NBin\\NBin.exe", true);
                    }
                    catch (Exception) { MessageBox.Show("Can't write to Program Files/NBin. Probably NBin is already running. Stop it first."); }
                    Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    key.SetValue("NBin", @Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\NBin\\NBin.exe");
                    MessageBox.Show("Installation successful.\nNBin was added to your autostart. You can disable this in settings.\nAlso You can remove installer. It was copied to Program Files and is no longer needed.\n\nHave fun!");
                    System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\NBin\\NBin.exe");
                   Environment.Exit(0);
                }
            }*/



            string firstrun = "0";

            try
            {
                firstrun = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\pionner\NBin", "firstrun", null);
            }
            catch { }
            

            /*if (firstrun == null)
            {
                MessageBox.Show("This is first run.\nYou will be asked by Windows whether allow this program to proceed.\nPlease click \"Allow\". It will install NBin in Your Program Files.", "First run");

                var psi = new ProcessStartInfo();
                psi.FileName = System.AppDomain.CurrentDomain.FriendlyName;
                psi.Arguments = "install";
                psi.Verb = "runas";
                try
                {
                    var process = new Process();
                    process.StartInfo = psi;
                    process.Start();
                    Environment.Exit(0);
                }
                catch (Exception)
                {
                    MessageBox.Show("You disagreed to install NBin.\nApp will now exit.", "Error");
                    Environment.Exit(0);
                }

            }
            else */
            
            if (firstrun=="1")
            {
                this.Opacity = 1;
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\pionner\NBin", "firstrun", "0");
            }



            if (jezyk_p == "en")
                jezyk.SelectedIndex = 0;
            else
                jezyk.SelectedIndex = 1;

            int set_p = Convert.ToInt32((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\pionner\NBin", "set", null));
            set.SelectedIndex = set_p - 1;



            if (Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", "NBin", null) != null)
            {
                start_on_boot.Checked = true;
            }



            try
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel", "{645FF040-5081-101B-9F08-00AA002F954E}", null).ToString() == "1")
                {
                    hide_on_desktop.Checked = true;
                }
            }
            catch { }



            wczytaj_liste();

            updater.RunWorkerAsync();

            ikona.Visible = true;


            if (set.SelectedIndex == 0)
            {
                podglad1.Image = global::NBin.Properties.Resources.empty1.ToBitmap();
                podglad2.Image = global::NBin.Properties.Resources.full1.ToBitmap();

            }
            else if (set.SelectedIndex == 1)
            {
                podglad1.Image = global::NBin.Properties.Resources.empty2.ToBitmap();
                podglad2.Image = global::NBin.Properties.Resources.full2.ToBitmap();
            }
            else if (set.SelectedIndex == 2)
            {
                podglad1.Image = global::NBin.Properties.Resources.empty3.ToBitmap();
                podglad2.Image = global::NBin.Properties.Resources.full3.ToBitmap();
            }
            else if (set.SelectedIndex == 3)
            {
                podglad1.Image = global::NBin.Properties.Resources.empty4.ToBitmap();
                podglad2.Image = global::NBin.Properties.Resources.full4.ToBitmap();
            }
            else if (set.SelectedIndex == 4)
            {
                podglad1.Image = global::NBin.Properties.Resources.empty5.ToBitmap();
                podglad2.Image = global::NBin.Properties.Resources.full5.ToBitmap();
            }
            else if (set.SelectedIndex == 5)
            {
                podglad1.Image = global::NBin.Properties.Resources.empty6.ToBitmap();
                podglad2.Image = global::NBin.Properties.Resources.full6.ToBitmap();
            }
            else if (set.SelectedIndex == 6)
            {
                podglad1.Image = IconExtractor.Extract("imageres.dll", 50, false).ToBitmap();
                podglad2.Image = IconExtractor.Extract("imageres.dll", 49, false).ToBitmap();
            }
            else if (set.SelectedIndex == 7)
            {
                podglad1.Image = IconExtractor.Extract("shell32.dll", 101, false).ToBitmap();
                podglad2.Image = IconExtractor.Extract("shell32.dll", 102, false).ToBitmap();
            }

        }

        private void updater_DoWork(object sender, DoWorkEventArgs e)
        {
            
            int pusty = -1;
            int lastdigit;
            string indicator;

            while (true)
            {
                //!!detect shd

                pusty = GetCount();
                System.Threading.Thread.Sleep(100);

                if (jezyk_p == "pl")
                {
                    lastdigit = (pusty % 10);
                    if (pusty == 1)
                        indicator = "element";
                    else if (pusty == 11 || pusty == 12 || pusty == 13 || pusty == 14)
                        indicator = "elementów";
                    else if (lastdigit == 2 || lastdigit == 3 || lastdigit == 4)
                        indicator = "elementy";
                    else
                        indicator = "elementów";
                }
                else
                {
                    if (pusty == 1)
                        indicator = "item";
                    else 
                        indicator = "items";
                }

                
                
                if (pusty != 0)
                {
                    switch (wybrany_set)
                    {
                        case 1:
                            ikona.Icon = global::NBin.Properties.Resources.full1;
                            break;
                        case 2:
                            ikona.Icon = global::NBin.Properties.Resources.full2;
                            break;
                        case 3: 
                            ikona.Icon = global::NBin.Properties.Resources.full3;
                            break;
                        case 4:
                            ikona.Icon = global::NBin.Properties.Resources.full4;
                            break;
                        case 5:
                            ikona.Icon = global::NBin.Properties.Resources.full5;
                            break;
                        case 6:
                            ikona.Icon = global::NBin.Properties.Resources.full6;
                            break;
                        case 7:
                            ikona.Icon = IconExtractor.Extract("imageres.dll", 49, false);
                            break;
                        case 8:
                            ikona.Icon = IconExtractor.Extract("shell32.dll", 102, false);
                            break;
                    }
                    ikona.Text = lang("bin") + " (" + pusty + " " + indicator + ")";
                }
                else
                {
                    switch (wybrany_set)
                    {
                        case 1:
                            ikona.Icon = global::NBin.Properties.Resources.empty1;
                            break;
                        case 2:
                            ikona.Icon = global::NBin.Properties.Resources.empty2;
                            break;
                        case 3:
                            ikona.Icon = global::NBin.Properties.Resources.empty3;
                            break;
                        case 4:
                            ikona.Icon = global::NBin.Properties.Resources.empty4;
                            break;
                        case 5:
                            ikona.Icon = global::NBin.Properties.Resources.empty5;
                            break;
                        case 6:
                            ikona.Icon = global::NBin.Properties.Resources.empty6;
                            break;
                        case 7:
                            ikona.Icon = IconExtractor.Extract("imageres.dll", 50, false);
                            break;
                        case 8:
                            ikona.Icon = IconExtractor.Extract("shell32.dll", 101, false);
                            break;
                    }
                    ikona.Text = lang("bin") + " " + lang("empty");
                }
            }
        }

        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            if (e.ClickedItem.Text == lang("settings"))
            {
                this.Opacity = 1;
                this.ShowInTaskbar = true;
            }
            else if (e.ClickedItem.Text == lang("empty_bin"))
            {
                try
                {
                    empty_now.RunWorkerAsync();
                }
                catch { }
            }
            else if (e.ClickedItem.Text == lang("open"))
                System.Diagnostics.Process.Start("shell:RecycleBinFolder");
            else
            {
                try
                {
                    RegistryKey localMachineX64View = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64);
                    string polecenie = localMachineX64View.OpenSubKey(@"CLSID\{645FF040-5081-101B-9F08-00AA002F954E}\shell\" + e.ClickedItem.Text + "\\command").GetValue(null).ToString();
                    System.Diagnostics.Process.Start(polecenie);
                }
                catch (Exception) { }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (systemShutdown)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
                this.Opacity = 0;
                this.ShowInTaskbar = false;
            }
        }

        private void kill_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show(lang("kill_sure"), lang("kill"), MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ikona.Visible = false;
                    systemShutdown = true;
                    System.Threading.Thread.Sleep(50);

                    Environment.Exit(0);

                }
            }
            catch (Exception) { }  
        }

        private void start_on_boot_CheckedChanged(object sender, EventArgs e)
        {
            if (start_on_boot.Checked)
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                key.SetValue("NBin", @System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
            else
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                key.DeleteValue("NBin", false);
            }
        }

        private void jezyk_SelectedIndexChanged(object sender, EventArgs e)
        {   
            if(jezyk.SelectedIndex==0)
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\pionner\NBin", "lang", "en");
            else
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\pionner\NBin", "lang", "pl");
            load_lang();
        }

        private void set_SelectedIndexChanged(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\pionner\NBin", "set", Convert.ToString(set.SelectedIndex+1));
            wybrany_set = set.SelectedIndex+1;
            if (set.SelectedIndex == 0)
            {
                podglad1.Image = global::NBin.Properties.Resources.empty1.ToBitmap();
                podglad2.Image = global::NBin.Properties.Resources.full1.ToBitmap();

            } else if (set.SelectedIndex == 1)
            {
                podglad1.Image = global::NBin.Properties.Resources.empty2.ToBitmap();
                podglad2.Image = global::NBin.Properties.Resources.full2.ToBitmap();
            } else if (set.SelectedIndex == 2)
            {
                podglad1.Image = global::NBin.Properties.Resources.empty3.ToBitmap();
                podglad2.Image = global::NBin.Properties.Resources.full3.ToBitmap();
            } else if (set.SelectedIndex == 3)
            {
                podglad1.Image = global::NBin.Properties.Resources.empty4.ToBitmap();
                podglad2.Image = global::NBin.Properties.Resources.full4.ToBitmap();
            } else if (set.SelectedIndex == 4)
            {
                podglad1.Image = global::NBin.Properties.Resources.empty5.ToBitmap();
                podglad2.Image = global::NBin.Properties.Resources.full5.ToBitmap();
            } else if (set.SelectedIndex == 5)
            {
                podglad1.Image = global::NBin.Properties.Resources.empty6.ToBitmap();
                podglad2.Image = global::NBin.Properties.Resources.full6.ToBitmap();

            }
            else if (set.SelectedIndex == 6)
            {
                podglad1.Image = IconExtractor.Extract("imageres.dll", 50, false).ToBitmap();
                podglad2.Image = IconExtractor.Extract("imageres.dll", 49, false).ToBitmap();

            }
            else if (set.SelectedIndex == 7)
            {
                podglad1.Image = IconExtractor.Extract("shell32.dll", 101, false).ToBitmap();
                podglad2.Image = IconExtractor.Extract("shell32.dll", 102, false).ToBitmap();

            }



            

            wczytaj_liste();
        }

        private void info_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.Opacity = 0;
        }

        private void donate_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=BYSM3WHMSBTEJ");
        }

        private void hide_on_desktop_CheckedChanged(object sender, EventArgs e)
        {
            if (hide_on_desktop.Checked)
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\NewStartPanel", true);
                key.SetValue("{645FF040-5081-101B-9F08-00AA002F954E}", 1);

                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\ClassicStartMenu", true);
                key.SetValue("{645FF040-5081-101B-9F08-00AA002F954E}", 1);
            }
            else
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\NewStartPanel", true);
                key.SetValue("{645FF040-5081-101B-9F08-00AA002F954E}", 0);

                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\ClassicStartMenu", true);
                key.SetValue("{645FF040-5081-101B-9F08-00AA002F954E}", 0);
            }

            SHChangeNotify(0x8000000, 0x1000, IntPtr.Zero, IntPtr.Zero);
        }

        private void empty_now_DoWork(object sender, DoWorkEventArgs e)
        {
            SHEmptyRecycleBin(IntPtr.Zero, null, 0);
        }


    }
}
