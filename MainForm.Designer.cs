﻿namespace BookRentalShopApp20
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MnuMng = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuItemCodeMng = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuItemBooksMng = new System.Windows.Forms.ToolStripMenuItem();
            this.MemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRentalRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.LblUserID = new MetroFramework.Controls.MetroLabel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuMng});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(760, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MnuMng
            // 
            this.MnuMng.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuItemCodeMng,
            this.MnuItemBooksMng,
            this.MemToolStripMenuItem,
            this.MenuRentalRToolStripMenuItem,
            this.toolStripMenuItem1,
            this.MnuItemExit});
            this.MnuMng.Name = "MnuMng";
            this.MnuMng.Size = new System.Drawing.Size(62, 20);
            this.MnuMng.Text = "관리(&M)";
            // 
            // MnuItemCodeMng
            // 
            this.MnuItemCodeMng.Name = "MnuItemCodeMng";
            this.MnuItemCodeMng.Size = new System.Drawing.Size(180, 22);
            this.MnuItemCodeMng.Text = "코드관리(&C)";
            this.MnuItemCodeMng.Click += new System.EventHandler(this.MnuItemCodeMng_Click);
            // 
            // MnuItemBooksMng
            // 
            this.MnuItemBooksMng.Name = "MnuItemBooksMng";
            this.MnuItemBooksMng.Size = new System.Drawing.Size(180, 22);
            this.MnuItemBooksMng.Text = "도서관리(&B)";
            this.MnuItemBooksMng.Click += new System.EventHandler(this.MnuItemBooksMng_Click);
            // 
            // MemToolStripMenuItem
            // 
            this.MemToolStripMenuItem.Name = "MemToolStripMenuItem";
            this.MemToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.MemToolStripMenuItem.Text = "회원관리(&M)";
            this.MemToolStripMenuItem.Click += new System.EventHandler(this.MemToolStripMenuItem_Click);
            // 
            // MenuRentalRToolStripMenuItem
            // 
            this.MenuRentalRToolStripMenuItem.Name = "MenuRentalRToolStripMenuItem";
            this.MenuRentalRToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.MenuRentalRToolStripMenuItem.Text = "대여관리(&R)";
            this.MenuRentalRToolStripMenuItem.Click += new System.EventHandler(this.MenuRentalRToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // MnuItemExit
            // 
            this.MnuItemExit.Name = "MnuItemExit";
            this.MnuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.MnuItemExit.Size = new System.Drawing.Size(180, 22);
            this.MnuItemExit.Text = "끝내기(&X)";
            this.MnuItemExit.Click += new System.EventHandler(this.MnuItemExit_Click);
            // 
            // LblUserID
            // 
            this.LblUserID.Location = new System.Drawing.Point(462, 22);
            this.LblUserID.Name = "LblUserID";
            this.LblUserID.Size = new System.Drawing.Size(304, 27);
            this.LblUserID.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LblUserID);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Book Rental Shop v0.6";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MnuMng;
        private System.Windows.Forms.ToolStripMenuItem MnuItemCodeMng;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MnuItemExit;
        private System.Windows.Forms.ToolStripMenuItem MnuItemBooksMng;
        private System.Windows.Forms.ToolStripMenuItem MemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuRentalRToolStripMenuItem;
        private MetroFramework.Controls.MetroLabel LblUserID;
    }
}

