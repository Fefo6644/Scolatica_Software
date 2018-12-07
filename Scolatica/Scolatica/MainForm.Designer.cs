//
//
//	El IDE se encarga de esto. Es preferible dejarlo así.
//
//

namespace Scolatica
{
    partial class MainForm
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.cbPorts = new System.Windows.Forms.ComboBox();
            this.SerialPort = new System.IO.Ports.SerialPort(this.components);
            this.tbDebugger = new System.Windows.Forms.TextBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lab1 = new System.Windows.Forms.Label();
            this.lab1b = new System.Windows.Forms.Label();
            this.lab2 = new System.Windows.Forms.Label();
            this.lab3 = new System.Windows.Forms.Label();
            this.lab4 = new System.Windows.Forms.Label();
            this.lab5 = new System.Windows.Forms.Label();
            this.lab6 = new System.Windows.Forms.Label();
            this.lab7 = new System.Windows.Forms.Label();
            this.lab8 = new System.Windows.Forms.Label();
            this.lab9 = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 11);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(151, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Conectar";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // cbPorts
            // 
            this.cbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPorts.FormattingEnabled = true;
            this.cbPorts.Location = new System.Drawing.Point(240, 12);
            this.cbPorts.Name = "cbPorts";
            this.cbPorts.Size = new System.Drawing.Size(151, 21);
            this.cbPorts.TabIndex = 1;
            this.cbPorts.DropDown += new System.EventHandler(this.CbPorts_DropDown);
            // 
            // SerialPort
            // 
            this.SerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort_DataReceived);
            // 
            // tbDebugger
            // 
            this.tbDebugger.BackColor = System.Drawing.Color.White;
            this.tbDebugger.Location = new System.Drawing.Point(12, 41);
            this.tbDebugger.Multiline = true;
            this.tbDebugger.Name = "tbDebugger";
            this.tbDebugger.ReadOnly = true;
            this.tbDebugger.Size = new System.Drawing.Size(379, 242);
            this.tbDebugger.TabIndex = 999;
            this.tbDebugger.WordWrap = false;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.SystemColors.Control;
            this.mainPanel.BackgroundImage = global::Scolatica.Properties.Resources.Fondo;
            this.mainPanel.Controls.Add(this.lab1);
            this.mainPanel.Controls.Add(this.lab1b);
            this.mainPanel.Controls.Add(this.lab2);
            this.mainPanel.Controls.Add(this.lab3);
            this.mainPanel.Controls.Add(this.lab4);
            this.mainPanel.Controls.Add(this.lab5);
            this.mainPanel.Controls.Add(this.lab6);
            this.mainPanel.Controls.Add(this.lab7);
            this.mainPanel.Controls.Add(this.lab8);
            this.mainPanel.Controls.Add(this.lab9);
            this.mainPanel.Location = new System.Drawing.Point(12, 41);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(379, 242);
            this.mainPanel.TabIndex = 2;
            // 
            // lab1
            // 
            this.lab1.AutoSize = true;
            this.lab1.BackColor = System.Drawing.Color.Transparent;
            this.lab1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lab1.Location = new System.Drawing.Point(3, 4);
            this.lab1.Name = "lab1";
            this.lab1.Size = new System.Drawing.Size(44, 16);
            this.lab1.TabIndex = 12;
            this.lab1.Text = "Lab. 1";
            // 
            // lab1b
            // 
            this.lab1b.AutoSize = true;
            this.lab1b.BackColor = System.Drawing.Color.Transparent;
            this.lab1b.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lab1b.Location = new System.Drawing.Point(3, 28);
            this.lab1b.Name = "lab1b";
            this.lab1b.Size = new System.Drawing.Size(52, 16);
            this.lab1b.TabIndex = 11;
            this.lab1b.Text = "Lab. 1b";
            // 
            // lab2
            // 
            this.lab2.AutoSize = true;
            this.lab2.BackColor = System.Drawing.Color.Transparent;
            this.lab2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lab2.Location = new System.Drawing.Point(3, 52);
            this.lab2.Name = "lab2";
            this.lab2.Size = new System.Drawing.Size(44, 16);
            this.lab2.TabIndex = 10;
            this.lab2.Text = "Lab. 2";
            // 
            // lab3
            // 
            this.lab3.AutoSize = true;
            this.lab3.BackColor = System.Drawing.Color.Transparent;
            this.lab3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lab3.Location = new System.Drawing.Point(3, 76);
            this.lab3.Name = "lab3";
            this.lab3.Size = new System.Drawing.Size(44, 16);
            this.lab3.TabIndex = 9;
            this.lab3.Text = "Lab. 3";
            // 
            // lab4
            // 
            this.lab4.AutoSize = true;
            this.lab4.BackColor = System.Drawing.Color.Transparent;
            this.lab4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lab4.Location = new System.Drawing.Point(3, 100);
            this.lab4.Name = "lab4";
            this.lab4.Size = new System.Drawing.Size(44, 16);
            this.lab4.TabIndex = 8;
            this.lab4.Text = "Lab. 4";
            // 
            // lab5
            // 
            this.lab5.AutoSize = true;
            this.lab5.BackColor = System.Drawing.Color.Transparent;
            this.lab5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lab5.Location = new System.Drawing.Point(3, 124);
            this.lab5.Name = "lab5";
            this.lab5.Size = new System.Drawing.Size(44, 16);
            this.lab5.TabIndex = 7;
            this.lab5.Text = "Lab. 5";
            // 
            // lab6
            // 
            this.lab6.AutoSize = true;
            this.lab6.BackColor = System.Drawing.Color.Transparent;
            this.lab6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lab6.Location = new System.Drawing.Point(3, 148);
            this.lab6.Name = "lab6";
            this.lab6.Size = new System.Drawing.Size(44, 16);
            this.lab6.TabIndex = 6;
            this.lab6.Text = "Lab. 6";
            // 
            // lab7
            // 
            this.lab7.AutoSize = true;
            this.lab7.BackColor = System.Drawing.Color.Transparent;
            this.lab7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lab7.Location = new System.Drawing.Point(3, 172);
            this.lab7.Name = "lab7";
            this.lab7.Size = new System.Drawing.Size(44, 16);
            this.lab7.TabIndex = 5;
            this.lab7.Text = "Lab. 7";
            // 
            // lab8
            // 
            this.lab8.AutoSize = true;
            this.lab8.BackColor = System.Drawing.Color.Transparent;
            this.lab8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lab8.Location = new System.Drawing.Point(3, 196);
            this.lab8.Name = "lab8";
            this.lab8.Size = new System.Drawing.Size(44, 16);
            this.lab8.TabIndex = 5;
            this.lab8.Text = "Lab. 8";
            // 
            // lab9
            // 
            this.lab9.AutoSize = true;
            this.lab9.BackColor = System.Drawing.Color.Transparent;
            this.lab9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lab9.Location = new System.Drawing.Point(3, 220);
            this.lab9.Name = "lab9";
            this.lab9.Size = new System.Drawing.Size(44, 16);
            this.lab9.TabIndex = 3;
            this.lab9.Text = "Lab. 9";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 295);
            this.Controls.Add(this.cbPorts);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.tbDebugger);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "¡Bienvenido a Electrónica! - Visor Scolática";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cbPorts;
        private System.IO.Ports.SerialPort SerialPort;
        private System.Windows.Forms.TextBox tbDebugger;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label lab1;
        private System.Windows.Forms.Label lab1b;
        private System.Windows.Forms.Label lab2;
        private System.Windows.Forms.Label lab3;
        private System.Windows.Forms.Label lab4;
        private System.Windows.Forms.Label lab5;
        private System.Windows.Forms.Label lab6;
        private System.Windows.Forms.Label lab7;
        private System.Windows.Forms.Label lab8;
        private System.Windows.Forms.Label lab9;
    }
}

