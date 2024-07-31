namespace v2rayN.Forms;

partial class ConfigSocksForm
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
        btnClose = new System.Windows.Forms.Button();
        groupBox1 = new System.Windows.Forms.GroupBox();
        label7 = new System.Windows.Forms.Label();
        label5 = new System.Windows.Forms.Label();
        txtSecurity = new System.Windows.Forms.TextBox();
        label4 = new System.Windows.Forms.Label();
        txtId = new System.Windows.Forms.TextBox();
        label3 = new System.Windows.Forms.Label();
        label13 = new System.Windows.Forms.Label();
        txtRemarks = new System.Windows.Forms.TextBox();
        label6 = new System.Windows.Forms.Label();
        txtPort = new System.Windows.Forms.TextBox();
        label2 = new System.Windows.Forms.Label();
        txtAddress = new System.Windows.Forms.TextBox();
        label1 = new System.Windows.Forms.Label();
        panel2 = new System.Windows.Forms.Panel();
        tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        btnOK = new System.Windows.Forms.Button();
        panel1 = new System.Windows.Forms.Panel();
        groupBox1.SuspendLayout();
        panel2.SuspendLayout();
        tableLayoutPanel1.SuspendLayout();
        SuspendLayout();
        // 
        // btnClose
        // 
        btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        btnClose.Dock = System.Windows.Forms.DockStyle.Right;
        btnClose.Location = new System.Drawing.Point(112, 12);
        btnClose.Name = "btnClose";
        btnClose.Size = new System.Drawing.Size(75, 35);
        btnClose.TabIndex = 4;
        btnClose.Text = "&Cancel";
        btnClose.UseVisualStyleBackColor = true;
        btnClose.Click += btnClose_Click;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(label7);
        groupBox1.Controls.Add(label5);
        groupBox1.Controls.Add(txtSecurity);
        groupBox1.Controls.Add(label4);
        groupBox1.Controls.Add(txtId);
        groupBox1.Controls.Add(label3);
        groupBox1.Controls.Add(label13);
        groupBox1.Controls.Add(txtRemarks);
        groupBox1.Controls.Add(label6);
        groupBox1.Controls.Add(txtPort);
        groupBox1.Controls.Add(label2);
        groupBox1.Controls.Add(txtAddress);
        groupBox1.Controls.Add(label1);
        groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
        groupBox1.Location = new System.Drawing.Point(0, 10);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new System.Drawing.Size(450, 280);
        groupBox1.TabIndex = 3;
        groupBox1.TabStop = false;
        groupBox1.Text = "Server";
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Location = new System.Drawing.Point(334, 83);
        label7.Name = "label7";
        label7.Size = new System.Drawing.Size(93, 17);
        label7.TabIndex = 28;
        label7.Text = "*可选(optional)";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new System.Drawing.Point(334, 110);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(93, 17);
        label5.TabIndex = 27;
        label5.Text = "*可选(optional)";
        // 
        // txtSecurity
        // 
        txtSecurity.Location = new System.Drawing.Point(114, 80);
        txtSecurity.Name = "txtSecurity";
        txtSecurity.Size = new System.Drawing.Size(214, 23);
        txtSecurity.TabIndex = 26;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        label4.Location = new System.Drawing.Point(12, 110);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(67, 17);
        label4.TabIndex = 25;
        label4.Text = "用户(User)";
        // 
        // txtId
        // 
        txtId.Location = new System.Drawing.Point(114, 109);
        txtId.Name = "txtId";
        txtId.PasswordChar = '*';
        txtId.Size = new System.Drawing.Size(214, 23);
        txtId.TabIndex = 24;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        label3.Location = new System.Drawing.Point(12, 83);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(96, 17);
        label3.TabIndex = 23;
        label3.Text = "密码(Password)";
        // 
        // label13
        // 
        label13.AutoSize = true;
        label13.Location = new System.Drawing.Point(334, 141);
        label13.Name = "label13";
        label13.Size = new System.Drawing.Size(93, 17);
        label13.TabIndex = 22;
        label13.Text = "*可选(optional)";
        // 
        // txtRemarks
        // 
        txtRemarks.Location = new System.Drawing.Point(114, 138);
        txtRemarks.Name = "txtRemarks";
        txtRemarks.Size = new System.Drawing.Size(214, 23);
        txtRemarks.TabIndex = 11;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new System.Drawing.Point(12, 141);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(67, 17);
        label6.TabIndex = 10;
        label6.Text = "别名(Alias)";
        // 
        // txtPort
        // 
        txtPort.Location = new System.Drawing.Point(114, 51);
        txtPort.Name = "txtPort";
        txtPort.Size = new System.Drawing.Size(324, 23);
        txtPort.TabIndex = 3;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new System.Drawing.Point(12, 54);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(64, 17);
        label2.TabIndex = 2;
        label2.Text = "端口(Port)";
        // 
        // txtAddress
        // 
        txtAddress.Location = new System.Drawing.Point(114, 22);
        txtAddress.Name = "txtAddress";
        txtAddress.Size = new System.Drawing.Size(324, 23);
        txtAddress.TabIndex = 1;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new System.Drawing.Point(12, 25);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(87, 17);
        label1.TabIndex = 0;
        label1.Text = "地址(address)";
        // 
        // panel2
        // 
        panel2.Controls.Add(tableLayoutPanel1);
        panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
        panel2.Location = new System.Drawing.Point(0, 290);
        panel2.Name = "panel2";
        panel2.Size = new System.Drawing.Size(450, 60);
        panel2.TabIndex = 7;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 3;
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanel1.Controls.Add(btnOK, 2, 1);
        tableLayoutPanel1.Controls.Add(btnClose, 0, 1);
        tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 3;
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanel1.Size = new System.Drawing.Size(450, 60);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // btnOK
        // 
        btnOK.Dock = System.Windows.Forms.DockStyle.Left;
        btnOK.Location = new System.Drawing.Point(263, 12);
        btnOK.Name = "btnOK";
        btnOK.Size = new System.Drawing.Size(75, 35);
        btnOK.TabIndex = 5;
        btnOK.Text = "&确定";
        btnOK.UseVisualStyleBackColor = true;
        btnOK.Click += btnOK_Click;
        // 
        // panel1
        // 
        panel1.Dock = System.Windows.Forms.DockStyle.Top;
        panel1.Location = new System.Drawing.Point(0, 0);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(450, 10);
        panel1.TabIndex = 6;
        // 
        // ConfigSocksForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        CancelButton = btnClose;
        ClientSize = new System.Drawing.Size(450, 350);
        Controls.Add(groupBox1);
        Controls.Add(panel2);
        Controls.Add(panel1);
        Margin = new System.Windows.Forms.Padding(175, 96, 175, 96);
        MinimizeBox = true;
        Name = "ConfigSocksForm";
        Text = "Socks";
        Load += AddServer4Form_Load;
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        panel2.ResumeLayout(false);
        tableLayoutPanel1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.TextBox txtRemarks;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtPort;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtAddress;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.TextBox txtId;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtSecurity;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label5;
}