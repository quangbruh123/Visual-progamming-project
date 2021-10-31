
namespace Sorting_Algorithms_Simulator
{
    partial class SortProject
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rdIncrease = new System.Windows.Forms.RadioButton();
            this.rdDecrease = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdInterchange = new System.Windows.Forms.RadioButton();
            this.rdHeap = new System.Windows.Forms.RadioButton();
            this.rdMerge = new System.Windows.Forms.RadioButton();
            this.rdQuick = new System.Windows.Forms.RadioButton();
            this.rdInsertion = new System.Windows.Forms.RadioButton();
            this.rdSelection = new System.Windows.Forms.RadioButton();
            this.rdBubble = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbInput = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lbAmount = new System.Windows.Forms.Label();
            this.rdManual = new System.Windows.Forms.RadioButton();
            this.rdAuto = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdIncrease
            // 
            this.rdIncrease.AutoSize = true;
            this.rdIncrease.Location = new System.Drawing.Point(6, 27);
            this.rdIncrease.Name = "rdIncrease";
            this.rdIncrease.Size = new System.Drawing.Size(134, 34);
            this.rdIncrease.TabIndex = 1;
            this.rdIncrease.TabStop = true;
            this.rdIncrease.Text = "Ascending";
            this.rdIncrease.UseVisualStyleBackColor = true;
            this.rdIncrease.CheckedChanged += new System.EventHandler(this.rdIncrease_CheckedChanged);
            // 
            // rdDecrease
            // 
            this.rdDecrease.AutoSize = true;
            this.rdDecrease.Location = new System.Drawing.Point(6, 56);
            this.rdDecrease.Name = "rdDecrease";
            this.rdDecrease.Size = new System.Drawing.Size(147, 34);
            this.rdDecrease.TabIndex = 2;
            this.rdDecrease.TabStop = true;
            this.rdDecrease.Text = "Descending";
            this.rdDecrease.UseVisualStyleBackColor = true;
            this.rdDecrease.CheckedChanged += new System.EventHandler(this.rdDecrease_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdInterchange);
            this.groupBox2.Controls.Add(this.rdHeap);
            this.groupBox2.Controls.Add(this.rdMerge);
            this.groupBox2.Controls.Add(this.rdQuick);
            this.groupBox2.Controls.Add(this.rdInsertion);
            this.groupBox2.Controls.Add(this.rdSelection);
            this.groupBox2.Controls.Add(this.rdBubble);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(11, 275);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(377, 195);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Algorithm";
            // 
            // rdInterchange
            // 
            this.rdInterchange.AutoSize = true;
            this.rdInterchange.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdInterchange.Location = new System.Drawing.Point(175, 35);
            this.rdInterchange.Name = "rdInterchange";
            this.rdInterchange.Size = new System.Drawing.Size(195, 34);
            this.rdInterchange.TabIndex = 8;
            this.rdInterchange.TabStop = true;
            this.rdInterchange.Text = "Interchange Sort";
            this.rdInterchange.UseVisualStyleBackColor = true;
            // 
            // rdHeap
            // 
            this.rdHeap.AutoSize = true;
            this.rdHeap.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdHeap.Location = new System.Drawing.Point(175, 115);
            this.rdHeap.Name = "rdHeap";
            this.rdHeap.Size = new System.Drawing.Size(132, 34);
            this.rdHeap.TabIndex = 7;
            this.rdHeap.TabStop = true;
            this.rdHeap.Text = "Heap Sort";
            this.rdHeap.UseVisualStyleBackColor = true;
            // 
            // rdMerge
            // 
            this.rdMerge.AutoSize = true;
            this.rdMerge.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdMerge.Location = new System.Drawing.Point(175, 75);
            this.rdMerge.Name = "rdMerge";
            this.rdMerge.Size = new System.Drawing.Size(145, 34);
            this.rdMerge.TabIndex = 6;
            this.rdMerge.TabStop = true;
            this.rdMerge.Text = "Merge Sort";
            this.rdMerge.UseVisualStyleBackColor = true;
            // 
            // rdQuick
            // 
            this.rdQuick.AutoSize = true;
            this.rdQuick.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdQuick.Location = new System.Drawing.Point(6, 155);
            this.rdQuick.Name = "rdQuick";
            this.rdQuick.Size = new System.Drawing.Size(135, 34);
            this.rdQuick.TabIndex = 5;
            this.rdQuick.TabStop = true;
            this.rdQuick.Text = "Quick Sort";
            this.rdQuick.UseVisualStyleBackColor = true;
            // 
            // rdInsertion
            // 
            this.rdInsertion.AutoSize = true;
            this.rdInsertion.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdInsertion.Location = new System.Drawing.Point(6, 115);
            this.rdInsertion.Name = "rdInsertion";
            this.rdInsertion.Size = new System.Drawing.Size(164, 34);
            this.rdInsertion.TabIndex = 4;
            this.rdInsertion.TabStop = true;
            this.rdInsertion.Text = "Insertion Sort";
            this.rdInsertion.UseVisualStyleBackColor = true;
            // 
            // rdSelection
            // 
            this.rdSelection.AutoSize = true;
            this.rdSelection.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdSelection.Location = new System.Drawing.Point(6, 75);
            this.rdSelection.Name = "rdSelection";
            this.rdSelection.Size = new System.Drawing.Size(168, 34);
            this.rdSelection.TabIndex = 3;
            this.rdSelection.TabStop = true;
            this.rdSelection.Text = "Selection Sort";
            this.rdSelection.UseVisualStyleBackColor = true;
            // 
            // rdBubble
            // 
            this.rdBubble.AutoSize = true;
            this.rdBubble.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdBubble.Location = new System.Drawing.Point(6, 35);
            this.rdBubble.Name = "rdBubble";
            this.rdBubble.Size = new System.Drawing.Size(145, 34);
            this.rdBubble.TabIndex = 2;
            this.rdBubble.TabStop = true;
            this.rdBubble.Text = "Bubble sort";
            this.rdBubble.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdIncrease);
            this.groupBox3.Controls.Add(this.rdDecrease);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(975, 281);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(154, 103);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Order";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.trackBar1);
            this.groupBox4.Controls.Add(this.btnAdd);
            this.groupBox4.Controls.Add(this.txtInput);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.lbInput);
            this.groupBox4.Controls.Add(this.txtAmount);
            this.groupBox4.Controls.Add(this.lbAmount);
            this.groupBox4.Controls.Add(this.rdManual);
            this.groupBox4.Controls.Add(this.rdAuto);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox4.Location = new System.Drawing.Point(395, 280);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(574, 189);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Input";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(87, 134);
            this.trackBar1.Maximum = 5;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(475, 56);
            this.trackBar1.TabIndex = 22;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(464, 40);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(98, 55);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(398, 69);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(44, 36);
            this.txtInput.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 30);
            this.label3.TabIndex = 6;
            this.label3.Text = "Speed";
            // 
            // lbInput
            // 
            this.lbInput.AutoSize = true;
            this.lbInput.Location = new System.Drawing.Point(177, 71);
            this.lbInput.Name = "lbInput";
            this.lbInput.Size = new System.Drawing.Size(148, 30);
            this.lbInput.TabIndex = 4;
            this.lbInput.Text = "Next element:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(398, 28);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(44, 36);
            this.txtAmount.TabIndex = 3;
            // 
            // lbAmount
            // 
            this.lbAmount.AutoSize = true;
            this.lbAmount.Location = new System.Drawing.Point(177, 31);
            this.lbAmount.Name = "lbAmount";
            this.lbAmount.Size = new System.Drawing.Size(215, 30);
            this.lbAmount.TabIndex = 2;
            this.lbAmount.Text = "Amount of elements:";
            // 
            // rdManual
            // 
            this.rdManual.AutoSize = true;
            this.rdManual.Location = new System.Drawing.Point(7, 69);
            this.rdManual.Name = "rdManual";
            this.rdManual.Size = new System.Drawing.Size(121, 34);
            this.rdManual.TabIndex = 1;
            this.rdManual.TabStop = true;
            this.rdManual.Text = "Manually";
            this.rdManual.UseVisualStyleBackColor = true;
            this.rdManual.CheckedChanged += new System.EventHandler(this.rdManual_CheckedChanged);
            // 
            // rdAuto
            // 
            this.rdAuto.AutoSize = true;
            this.rdAuto.Location = new System.Drawing.Point(7, 29);
            this.rdAuto.Name = "rdAuto";
            this.rdAuto.Size = new System.Drawing.Size(164, 34);
            this.rdAuto.TabIndex = 0;
            this.rdAuto.TabStop = true;
            this.rdAuto.Text = "Automatically";
            this.rdAuto.UseVisualStyleBackColor = true;
            this.rdAuto.CheckedChanged += new System.EventHandler(this.rdAuto_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStart.Location = new System.Drawing.Point(11, 491);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(370, 56);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPause.Location = new System.Drawing.Point(11, 553);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(370, 56);
            this.btnPause.TabIndex = 10;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnReset.Location = new System.Drawing.Point(11, 615);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(370, 56);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(235, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 30);
            this.label4.TabIndex = 9;
            this.label4.Text = "Quick Sort";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(11, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 30);
            this.label5.TabIndex = 12;
            this.label5.Text = "Selection Sort";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(235, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 30);
            this.label6.TabIndex = 13;
            this.label6.Text = "Merge Sort";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(235, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 30);
            this.label7.TabIndex = 14;
            this.label7.Text = "Interchange Sort";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(11, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 30);
            this.label8.TabIndex = 15;
            this.label8.Text = "Insertion Sort";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(485, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 30);
            this.label9.TabIndex = 16;
            this.label9.Text = "Heap Sort";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(11, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 30);
            this.label10.TabIndex = 17;
            this.label10.Text = "Bubble sort";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Controls.Add(this.textBox9);
            this.groupBox5.Controls.Add(this.textBox8);
            this.groupBox5.Controls.Add(this.textBox7);
            this.groupBox5.Controls.Add(this.textBox6);
            this.groupBox5.Controls.Add(this.textBox5);
            this.groupBox5.Controls.Add(this.textBox4);
            this.groupBox5.Controls.Add(this.textBox3);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox5.Location = new System.Drawing.Point(395, 475);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(781, 200);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Sorting time (second)";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button4.Location = new System.Drawing.Point(562, 123);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(115, 56);
            this.button4.TabIndex = 25;
            this.button4.Text = "Display";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(663, 45);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(44, 36);
            this.textBox9.TabIndex = 24;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(165, 155);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(44, 36);
            this.textBox8.TabIndex = 23;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(414, 157);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(44, 36);
            this.textBox7.TabIndex = 22;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(414, 45);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(44, 36);
            this.textBox6.TabIndex = 21;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(414, 103);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(44, 36);
            this.textBox5.TabIndex = 20;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(165, 103);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(44, 36);
            this.textBox4.TabIndex = 19;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(165, 45);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(44, 36);
            this.textBox3.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(11, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1166, 263);
            this.panel1.TabIndex = 19;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // SortProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 687);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "SortProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sorting Algorithms Simulator";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton rdIncrease;
        private System.Windows.Forms.RadioButton rdDecrease;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdInterchange;
        private System.Windows.Forms.RadioButton rdHeap;
        private System.Windows.Forms.RadioButton rdMerge;
        private System.Windows.Forms.RadioButton rdQuick;
        private System.Windows.Forms.RadioButton rdInsertion;
        private System.Windows.Forms.RadioButton rdSelection;
        private System.Windows.Forms.RadioButton rdBubble;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbInput;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lbAmount;
        private System.Windows.Forms.RadioButton rdManual;
        private System.Windows.Forms.RadioButton rdAuto;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Panel panel1;
    }
}

