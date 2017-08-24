namespace NBin
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ikona = new System.Windows.Forms.NotifyIcon(this.components);
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.emptyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updater = new System.ComponentModel.BackgroundWorker();
            this.set = new System.Windows.Forms.ComboBox();
            this.podglad1 = new System.Windows.Forms.PictureBox();
            this.podglad2 = new System.Windows.Forms.PictureBox();
            this.jezyk = new System.Windows.Forms.ComboBox();
            this.kill = new System.Windows.Forms.Button();
            this.start_on_boot = new System.Windows.Forms.CheckBox();
            this.info = new System.Windows.Forms.RichTextBox();
            this.ikona_opcje = new System.Windows.Forms.PictureBox();
            this.close = new System.Windows.Forms.Button();
            this.dondon = new System.Windows.Forms.Button();
            this.hide_on_desktop = new System.Windows.Forms.CheckBox();
            this.empty_now = new System.ComponentModel.BackgroundWorker();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.podglad1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.podglad2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ikona_opcje)).BeginInit();
            this.SuspendLayout();
            // 
            // ikona
            // 
            this.ikona.ContextMenuStrip = this.menu;
            this.ikona.Icon = ((System.Drawing.Icon)(resources.GetObject("ikona.Icon")));
            this.ikona.Text = "Kosz";
            this.ikona.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ikona_MouseDoubleClick);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emptyToolStripMenuItem});
            this.menu.Name = "menu";
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menu.Size = new System.Drawing.Size(146, 26);
            this.menu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menu_ItemClicked);
            // 
            // emptyToolStripMenuItem
            // 
            this.emptyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("emptyToolStripMenuItem.Image")));
            this.emptyToolStripMenuItem.Name = "emptyToolStripMenuItem";
            this.emptyToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.emptyToolStripMenuItem.Text = "Opróżnij kosz";
            // 
            // updater
            // 
            this.updater.DoWork += new System.ComponentModel.DoWorkEventHandler(this.updater_DoWork);
            // 
            // set
            // 
            this.set.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.set.FormattingEnabled = true;
            this.set.Items.AddRange(new object[] {
            "Set 1",
            "Set 2",
            "Set 3",
            "Set 4",
            "Set 5",
            "Set 6",
            "Windows",
            "Windows Old"});
            this.set.Location = new System.Drawing.Point(56, 12);
            this.set.Name = "set";
            this.set.Size = new System.Drawing.Size(140, 21);
            this.set.TabIndex = 1;
            this.set.SelectedIndexChanged += new System.EventHandler(this.set_SelectedIndexChanged);
            // 
            // podglad1
            // 
            this.podglad1.Location = new System.Drawing.Point(12, 12);
            this.podglad1.Name = "podglad1";
            this.podglad1.Size = new System.Drawing.Size(16, 16);
            this.podglad1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.podglad1.TabIndex = 2;
            this.podglad1.TabStop = false;
            // 
            // podglad2
            // 
            this.podglad2.Location = new System.Drawing.Point(34, 12);
            this.podglad2.Name = "podglad2";
            this.podglad2.Size = new System.Drawing.Size(16, 16);
            this.podglad2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.podglad2.TabIndex = 3;
            this.podglad2.TabStop = false;
            // 
            // jezyk
            // 
            this.jezyk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jezyk.FormattingEnabled = true;
            this.jezyk.Items.AddRange(new object[] {
            "English",
            "Polski"});
            this.jezyk.Location = new System.Drawing.Point(12, 39);
            this.jezyk.Name = "jezyk";
            this.jezyk.Size = new System.Drawing.Size(184, 21);
            this.jezyk.TabIndex = 4;
            this.jezyk.SelectedIndexChanged += new System.EventHandler(this.jezyk_SelectedIndexChanged);
            // 
            // kill
            // 
            this.kill.Location = new System.Drawing.Point(168, 66);
            this.kill.Name = "kill";
            this.kill.Size = new System.Drawing.Size(94, 23);
            this.kill.TabIndex = 5;
            this.kill.Text = "kill";
            this.kill.UseVisualStyleBackColor = true;
            this.kill.Click += new System.EventHandler(this.kill_Click);
            // 
            // start_on_boot
            // 
            this.start_on_boot.AutoSize = true;
            this.start_on_boot.Location = new System.Drawing.Point(12, 72);
            this.start_on_boot.Name = "start_on_boot";
            this.start_on_boot.Size = new System.Drawing.Size(91, 17);
            this.start_on_boot.TabIndex = 6;
            this.start_on_boot.Text = "start_on_boot";
            this.start_on_boot.UseVisualStyleBackColor = true;
            this.start_on_boot.CheckedChanged += new System.EventHandler(this.start_on_boot_CheckedChanged);
            // 
            // info
            // 
            this.info.Location = new System.Drawing.Point(12, 118);
            this.info.Name = "info";
            this.info.ReadOnly = true;
            this.info.Size = new System.Drawing.Size(250, 164);
            this.info.TabIndex = 7;
            this.info.Text = resources.GetString("info.Text");
            this.info.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.info_LinkClicked);
            // 
            // ikona_opcje
            // 
            this.ikona_opcje.Image = ((System.Drawing.Image)(resources.GetObject("ikona_opcje.Image")));
            this.ikona_opcje.Location = new System.Drawing.Point(209, 12);
            this.ikona_opcje.Name = "ikona_opcje";
            this.ikona_opcje.Size = new System.Drawing.Size(48, 48);
            this.ikona_opcje.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ikona_opcje.TabIndex = 8;
            this.ikona_opcje.TabStop = false;
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(12, 288);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(122, 23);
            this.close.TabIndex = 9;
            this.close.Text = "close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // dondon
            // 
            this.dondon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dondon.BackgroundImage")));
            this.dondon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.dondon.FlatAppearance.BorderSize = 0;
            this.dondon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dondon.Location = new System.Drawing.Point(180, 288);
            this.dondon.Name = "dondon";
            this.dondon.Size = new System.Drawing.Size(82, 23);
            this.dondon.TabIndex = 10;
            this.dondon.UseVisualStyleBackColor = true;
            this.dondon.Click += new System.EventHandler(this.donate_Click);
            // 
            // hide_on_desktop
            // 
            this.hide_on_desktop.AutoSize = true;
            this.hide_on_desktop.Location = new System.Drawing.Point(12, 95);
            this.hide_on_desktop.Name = "hide_on_desktop";
            this.hide_on_desktop.Size = new System.Drawing.Size(108, 17);
            this.hide_on_desktop.TabIndex = 11;
            this.hide_on_desktop.Text = "hide_on_desktop";
            this.hide_on_desktop.UseVisualStyleBackColor = true;
            this.hide_on_desktop.CheckedChanged += new System.EventHandler(this.hide_on_desktop_CheckedChanged);
            // 
            // empty_now
            // 
            this.empty_now.DoWork += new System.ComponentModel.DoWorkEventHandler(this.empty_now_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 320);
            this.Controls.Add(this.hide_on_desktop);
            this.Controls.Add(this.dondon);
            this.Controls.Add(this.close);
            this.Controls.Add(this.ikona_opcje);
            this.Controls.Add(this.info);
            this.Controls.Add(this.start_on_boot);
            this.Controls.Add(this.kill);
            this.Controls.Add(this.jezyk);
            this.Controls.Add(this.podglad2);
            this.Controls.Add(this.podglad1);
            this.Controls.Add(this.set);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NBin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.podglad1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.podglad2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ikona_opcje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon ikona;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem emptyToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker updater;
        private System.Windows.Forms.ComboBox set;
        private System.Windows.Forms.PictureBox podglad1;
        private System.Windows.Forms.PictureBox podglad2;
        private System.Windows.Forms.ComboBox jezyk;
        private System.Windows.Forms.Button kill;
        private System.Windows.Forms.CheckBox start_on_boot;
        private System.Windows.Forms.RichTextBox info;
        private System.Windows.Forms.PictureBox ikona_opcje;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button dondon;
        private System.Windows.Forms.CheckBox hide_on_desktop;
        private System.ComponentModel.BackgroundWorker empty_now;
    }
}

