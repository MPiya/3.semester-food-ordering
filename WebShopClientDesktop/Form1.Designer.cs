namespace WebShopClientDesktop
{
	partial class Form1
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
		this.buttonGetOrders = new System.Windows.Forms.Button();
		this.listBoxOrders = new System.Windows.Forms.ListBox();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.label1 = new System.Windows.Forms.Label();
		this.groupBox1.SuspendLayout();
		this.SuspendLayout();
		// 
		// buttonGetOrders
		// 
		this.buttonGetOrders.Location = new System.Drawing.Point(177, 39);
		this.buttonGetOrders.Name = "buttonGetOrders";
		this.buttonGetOrders.Size = new System.Drawing.Size(123, 41);
		this.buttonGetOrders.TabIndex = 0;
		this.buttonGetOrders.Text = "Get all orders";
		this.buttonGetOrders.UseVisualStyleBackColor = true;
		this.buttonGetOrders.Click += new System.EventHandler(this.ButtonGetOrders_Click);
		// 
		// listBoxOrders
		// 
		this.listBoxOrders.FormattingEnabled = true;
		this.listBoxOrders.ItemHeight = 19;
		this.listBoxOrders.Location = new System.Drawing.Point(26, 98);
		this.listBoxOrders.Name = "listBoxOrders";
		this.listBoxOrders.Size = new System.Drawing.Size(272, 289);
		this.listBoxOrders.TabIndex = 1;
		// 
		// groupBox1
		// 
		this.groupBox1.Controls.Add(this.label1);
		this.groupBox1.Controls.Add(this.listBoxOrders);
		this.groupBox1.Controls.Add(this.buttonGetOrders);
		this.groupBox1.Location = new System.Drawing.Point(67, 28);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(312, 419);
		this.groupBox1.TabIndex = 2;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Get orders";
		// 
		// label1
		// 
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(34, 396);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(15, 19);
		this.label1.TabIndex = 2;
		this.label1.Text = "..";
		// 
		// Form1
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ClientSize = new System.Drawing.Size(800, 450);
		this.Controls.Add(this.groupBox1);
		this.Name = "Form1";
		this.Text = "Form1";
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.ResumeLayout(false);

	}

	#endregion

	private Button buttonGetOrders;
	private ListBox listBoxOrders;
	private GroupBox groupBox1;
	private Label label1;
}
}