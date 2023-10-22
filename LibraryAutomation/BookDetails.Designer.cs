namespace LibraryAutomation
{
    partial class BookDetails
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookDetails));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Name = new System.Windows.Forms.TextBox();
            this.Writer = new System.Windows.Forms.TextBox();
            this.PageNumber = new System.Windows.Forms.TextBox();
            this.Year = new System.Windows.Forms.TextBox();
            this.Genre = new System.Windows.Forms.TextBox();
            this.ShelfCode = new System.Windows.Forms.TextBox();
            this.BarkodNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.deleteBookButton = new System.Windows.Forms.Button();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Count = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kitap Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Yazar:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sayfa Sayısı:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Basım Yılı:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tür:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 26);
            this.label6.TabIndex = 5;
            this.label6.Text = "Raf:";
            // 
            // Name
            // 
            this.Name.Location = new System.Drawing.Point(9, 46);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(137, 33);
            this.Name.TabIndex = 6;
            // 
            // Writer
            // 
            this.Writer.Location = new System.Drawing.Point(9, 94);
            this.Writer.Name = "Writer";
            this.Writer.Size = new System.Drawing.Size(137, 33);
            this.Writer.TabIndex = 7;
            // 
            // PageNumber
            // 
            this.PageNumber.Location = new System.Drawing.Point(9, 142);
            this.PageNumber.Name = "PageNumber";
            this.PageNumber.Size = new System.Drawing.Size(137, 33);
            this.PageNumber.TabIndex = 8;
            // 
            // Year
            // 
            this.Year.Location = new System.Drawing.Point(9, 190);
            this.Year.Name = "Year";
            this.Year.Size = new System.Drawing.Size(137, 33);
            this.Year.TabIndex = 9;
            // 
            // Genre
            // 
            this.Genre.Location = new System.Drawing.Point(9, 238);
            this.Genre.Name = "Genre";
            this.Genre.Size = new System.Drawing.Size(137, 33);
            this.Genre.TabIndex = 10;
            // 
            // ShelfCode
            // 
            this.ShelfCode.Location = new System.Drawing.Point(9, 286);
            this.ShelfCode.Name = "ShelfCode";
            this.ShelfCode.Size = new System.Drawing.Size(137, 33);
            this.ShelfCode.TabIndex = 11;
            // 
            // BarkodNo
            // 
            this.BarkodNo.Location = new System.Drawing.Point(9, 386);
            this.BarkodNo.Name = "BarkodNo";
            this.BarkodNo.Size = new System.Drawing.Size(97, 33);
            this.BarkodNo.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 366);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 26);
            this.label7.TabIndex = 14;
            this.label7.Text = "Barkod No:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.deleteBookButton);
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(201, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 409);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sorgu";
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Location = new System.Drawing.Point(135, 49);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(132, 24);
            this.button3.TabIndex = 19;
            this.button3.Text = "Sorgula";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(181, 26);
            this.label8.TabIndex = 18;
            this.label8.Text = "Barkod Numarası:";
            // 
            // deleteBookButton
            // 
            this.deleteBookButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteBookButton.Enabled = false;
            this.deleteBookButton.Image = global::LibraryAutomation.Properties.Resources.book_delete_icon;
            this.deleteBookButton.Location = new System.Drawing.Point(273, 17);
            this.deleteBookButton.Name = "deleteBookButton";
            this.deleteBookButton.Size = new System.Drawing.Size(55, 56);
            this.deleteBookButton.TabIndex = 16;
            this.deleteBookButton.UseVisualStyleBackColor = true;
            this.deleteBookButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(135, 18);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(132, 33);
            this.textBox8.TabIndex = 17;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox18);
            this.groupBox2.Controls.Add(this.textBox17);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.textBox16);
            this.groupBox2.Controls.Add(this.textBox15);
            this.groupBox2.Controls.Add(this.textBox14);
            this.groupBox2.Controls.Add(this.textBox13);
            this.groupBox2.Controls.Add(this.textBox12);
            this.groupBox2.Controls.Add(this.textBox11);
            this.groupBox2.Controls.Add(this.textBox10);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(12, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(316, 316);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kitap Sil";
            // 
            // textBox18
            // 
            this.textBox18.Enabled = false;
            this.textBox18.Location = new System.Drawing.Point(101, 268);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(25, 33);
            this.textBox18.TabIndex = 36;
            // 
            // textBox17
            // 
            this.textBox17.Enabled = false;
            this.textBox17.Location = new System.Drawing.Point(101, 20);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(135, 33);
            this.textBox17.TabIndex = 35;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 28);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(86, 26);
            this.label19.TabIndex = 34;
            this.label19.Text = "Barkod:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(128, 274);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(0, 26);
            this.label18.TabIndex = 33;
            // 
            // textBox16
            // 
            this.textBox16.Enabled = false;
            this.textBox16.Location = new System.Drawing.Point(101, 237);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(135, 33);
            this.textBox16.TabIndex = 32;
            // 
            // textBox15
            // 
            this.textBox15.Enabled = false;
            this.textBox15.Location = new System.Drawing.Point(101, 206);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(135, 33);
            this.textBox15.TabIndex = 31;
            // 
            // textBox14
            // 
            this.textBox14.Enabled = false;
            this.textBox14.Location = new System.Drawing.Point(101, 175);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(135, 33);
            this.textBox14.TabIndex = 30;
            // 
            // textBox13
            // 
            this.textBox13.Enabled = false;
            this.textBox13.Location = new System.Drawing.Point(101, 144);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(135, 33);
            this.textBox13.TabIndex = 29;
            // 
            // textBox12
            // 
            this.textBox12.Enabled = false;
            this.textBox12.Location = new System.Drawing.Point(101, 113);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(135, 33);
            this.textBox12.TabIndex = 28;
            // 
            // textBox11
            // 
            this.textBox11.Enabled = false;
            this.textBox11.Location = new System.Drawing.Point(101, 82);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(135, 33);
            this.textBox11.TabIndex = 27;
            // 
            // textBox10
            // 
            this.textBox10.Enabled = false;
            this.textBox10.Location = new System.Drawing.Point(101, 51);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(135, 33);
            this.textBox10.TabIndex = 25;
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Enabled = false;
            this.button4.Image = global::LibraryAutomation.Properties.Resources.if_book_edit_35733;
            this.button4.Location = new System.Drawing.Point(255, 255);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(55, 55);
            this.button4.TabIndex = 18;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 214);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 26);
            this.label12.TabIndex = 18;
            this.label12.Text = "Raf:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 276);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(84, 26);
            this.label17.TabIndex = 26;
            this.label17.Text = "Durum:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 183);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 26);
            this.label13.TabIndex = 17;
            this.label13.Text = "Tür:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 121);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(131, 26);
            this.label11.TabIndex = 22;
            this.label11.Text = "Sayfa Sayısı:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 152);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(114, 26);
            this.label14.TabIndex = 16;
            this.label14.Text = "Basım Yılı:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 245);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 26);
            this.label16.TabIndex = 25;
            this.label16.Text = "Stok:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 26);
            this.label9.TabIndex = 20;
            this.label9.Text = "Kitap Adı:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 26);
            this.label10.TabIndex = 21;
            this.label10.Text = "Yazar:";
            // 
            // Count
            // 
            this.Count.Location = new System.Drawing.Point(9, 334);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(137, 33);
            this.Count.TabIndex = 17;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 314);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 26);
            this.label15.TabIndex = 16;
            this.label15.Text = "Stok:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Count);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.BarkodNo);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.ShelfCode);
            this.groupBox3.Controls.Add(this.Genre);
            this.groupBox3.Controls.Add(this.Year);
            this.groupBox3.Controls.Add(this.PageNumber);
            this.groupBox3.Controls.Add(this.Writer);
            this.groupBox3.Controls.Add(this.Name);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(173, 446);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Kitap Ekle";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Image = global::LibraryAutomation.Properties.Resources.if_book_add_35730;
            this.button1.Location = new System.Drawing.Point(112, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 54);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Location = new System.Drawing.Point(299, 427);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(150, 31);
            this.button5.TabIndex = 18;
            this.button5.Text = "Tüm Kitapları Göster";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // BookDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 449);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(573, 505);
            this.MinimumSize = new System.Drawing.Size(573, 505);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kitap İşlemleri";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private new System.Windows.Forms.TextBox Name;
        private System.Windows.Forms.TextBox Writer;
        private System.Windows.Forms.TextBox PageNumber;
        private System.Windows.Forms.TextBox Year;
        private System.Windows.Forms.TextBox Genre;
        private System.Windows.Forms.TextBox ShelfCode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox BarkodNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button deleteBookButton;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox Count;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBox18;
    }
}

