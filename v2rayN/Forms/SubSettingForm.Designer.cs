namespace v2rayN.Forms;

partial class SubSettingForm
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
        panCon = new System.Windows.Forms.Panel();
        panel2 = new System.Windows.Forms.Panel();
        tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        btnAdd = new System.Windows.Forms.Button();
        btnOK = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        panel2.SuspendLayout();
        tableLayoutPanel1.SuspendLayout();
        SuspendLayout();
        // 
        // btnClose
        // 
        btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        btnClose.Dock = System.Windows.Forms.DockStyle.Right;
        btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        btnClose.Location = new System.Drawing.Point(186, 12);
        btnClose.Name = "btnClose";
        btnClose.Size = new System.Drawing.Size(75, 35);
        btnClose.TabIndex = 4;
        btnClose.Text = "&取消";
        btnClose.UseVisualStyleBackColor = true;
        btnClose.Click += btnClose_Click;
        // 
        // panCon
        // 
        panCon.AutoScroll = true;
        panCon.Dock = System.Windows.Forms.DockStyle.Fill;
        panCon.Location = new System.Drawing.Point(0, 0);
        panCon.Name = "panCon";
        panCon.Size = new System.Drawing.Size(600, 390);
        panCon.TabIndex = 10;
        // 
        // panel2
        // 
        panel2.Controls.Add(tableLayoutPanel1);
        panel2.Controls.Add(label1);
        panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
        panel2.Location = new System.Drawing.Point(0, 390);
        panel2.Name = "panel2";
        panel2.Size = new System.Drawing.Size(600, 60);
        panel2.TabIndex = 7;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 5;
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.59318F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.40682F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.40682F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.59318F));
        tableLayoutPanel1.Controls.Add(btnAdd, 0, 1);
        tableLayoutPanel1.Controls.Add(btnOK, 3, 1);
        tableLayoutPanel1.Controls.Add(btnClose, 1, 1);
        tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanel1.Location = new System.Drawing.Point(0, 1);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 3;
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanel1.Size = new System.Drawing.Size(600, 59);
        tableLayoutPanel1.TabIndex = 8;
        // 
        // btnAdd
        // 
        btnAdd.Dock = System.Windows.Forms.DockStyle.Left;
        btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        btnAdd.Location = new System.Drawing.Point(16, 12);
        btnAdd.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new System.Drawing.Size(75, 35);
        btnAdd.TabIndex = 6;
        btnAdd.Text = "&添加";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;
        // 
        // btnOK
        // 
        btnOK.Dock = System.Windows.Forms.DockStyle.Left;
        btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        btnOK.Location = new System.Drawing.Point(337, 12);
        btnOK.Name = "btnOK";
        btnOK.Size = new System.Drawing.Size(75, 35);
        btnOK.TabIndex = 5;
        btnOK.Text = "&确定";
        btnOK.UseVisualStyleBackColor = true;
        btnOK.Click += btnOK_Click;
        // 
        // label1
        // 
        label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        label1.Dock = System.Windows.Forms.DockStyle.Top;
        label1.Location = new System.Drawing.Point(0, 0);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(600, 1);
        label1.TabIndex = 7;
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // SubSettingForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        CancelButton = btnClose;
        ClientSize = new System.Drawing.Size(600, 450);
        Controls.Add(panCon);
        Controls.Add(panel2);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        Margin = new System.Windows.Forms.Padding(96, 48, 96, 48);
        Name = "SubSettingForm";
        Text = "订阅设置(SubscriptionSettings)";
        Load += SubSettingForm_Load;
        panel2.ResumeLayout(false);
        tableLayoutPanel1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Panel panCon;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
}