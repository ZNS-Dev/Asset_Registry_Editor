using System;
using System.Windows.Forms;

namespace Asset_Registry_Editor;

public class AREditor : Form
{
    private readonly string DefaultFilePath;

    private string FileNameSave;
    private TextBox TBsearch;
    private Button BTNsearch;
    private Label LBLeditor;
    private Button BTNsavefiletobin;
    private Label LBLdumper;
    private Button BTNsavefiletojson;
    private Button BTNdirtoexctractallpath;
    private Button BTNselectarpath3;
    private Label LBLinjector;
    private TextBox TBdirtoexctractallpath;
    private Button BTNinject;
    private Button BTNextract;
    private RichTextBox RTBassetregistryparsedread;
    private Button BTNselectarpath2;
    private Button BTNselectdirtoinject;
    private TextBox TBarpath2;
    private TextBox TBarpath;
    private TextBox TBdirtoinjectpath;
    private Button BTNselectarpath;

    public AREditor()
    {
        InitializeComponent();
    }

    private void OpenARInRTB(string filePath)
    {
        Fonctions.ReadAssetRegistryFile(filePath, out var OutJson);
        RTBassetregistryparsedread.Text = OutJson;
    }

    private void AREditor_Load(object sender, EventArgs e)
    {
        Control.CheckForIllegalCrossThreadCalls = false;
        Fonctions.RegisterFileAssociation(".bin", "Asset Registry Editor", "Editor of the Unreal Engine Asset Registry");
        if (DefaultFilePath != null)
        {
        }
    }

    public AREditor(string filePath)
    {
        InitializeComponent();
        OpenARInRTB(filePath);
        DefaultFilePath = filePath;
    }

    private void BTNselectarpath_Click(object sender, EventArgs e)
    {
        Fonctions.SelectBinFile(out var BinFilePath);

        if (!string.IsNullOrWhiteSpace(BinFilePath))
        {
            TBarpath.Text = BinFilePath;
            RTBassetregistryparsedread.Enabled = true;

            FileNameSave = BinFilePath;
            OpenARInRTB(BinFilePath);
        }
    }

    private void BTNselectdirtoinject_Click(object sender, EventArgs e)
    {
        Fonctions.SelectDir(out var DirFilePath);
        TBdirtoinjectpath.Text = DirFilePath;
    }

    private void BTNinject_Click(object sender, EventArgs e)
    {
        Fonctions.InjectJsonCode(TBarpath.Text, TBdirtoinjectpath.Text);
    }

    private void BTNselectarpath2_Click(object sender, EventArgs e)
    {
        Fonctions.SelectBinFile(out var BinFilePath);
        TBarpath2.Text = BinFilePath;
    }

    private void BTNdirtoexctractallpath_Click(object sender, EventArgs e)
    {
        Fonctions.SelectDir(out var DirFilePath);
        TBdirtoexctractallpath.Text = DirFilePath;
    }

    private void BTNextract_Click(object sender, EventArgs e)
    {
        Fonctions.DumpAllAssetRegistry(TBarpath2.Text, TBdirtoexctractallpath.Text);
    }

    private void BTNselectarpath3_Click(object sender, EventArgs e)
    {
        Fonctions.SelectBinFile(out var BinFilePath);

        if (!string.IsNullOrWhiteSpace(BinFilePath))
        {
            FileNameSave = BinFilePath;
            OpenARInRTB(BinFilePath);
            BTNsavefiletojson.Enabled = true;
            BTNsavefiletobin.Enabled = true;
            BTNsearch.Enabled = true;
            TBsearch.Enabled = true;
        }
    }

    private void BTNsavefiletojson_Click(object sender, EventArgs e)
    {
        FileNameSave ??= "AssetRegistry.bin";
        Fonctions.SaveAssetRegistryJson(FileNameSave, RTBassetregistryparsedread.Text);
    }

    private void BTNsavefiletobin_Click(object sender, EventArgs e)
    {
        FileNameSave ??= "AssetRegistry.bin";
        Fonctions.SaveAssetRegistryBin(FileNameSave, RTBassetregistryparsedread.Text);
    }

    private void BTNsearch_Click(object sender, EventArgs e)
    {
        string text = TBsearch.Text;
        int start = RTBassetregistryparsedread.SelectionStart + RTBassetregistryparsedread.SelectionLength;
        int num = RTBassetregistryparsedread.Find(text, start, RichTextBoxFinds.None);
        if (num != -1)
        {
            RTBassetregistryparsedread.SelectionStart = num;
            RTBassetregistryparsedread.SelectionLength = text.Length;
            RTBassetregistryparsedread.Focus();
        }
        else
        {
            MessageBox.Show("Aucun texte trouvé.");
        }
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AREditor));
            this.TBsearch = new System.Windows.Forms.TextBox();
            this.BTNsearch = new System.Windows.Forms.Button();
            this.LBLeditor = new System.Windows.Forms.Label();
            this.BTNsavefiletobin = new System.Windows.Forms.Button();
            this.LBLdumper = new System.Windows.Forms.Label();
            this.BTNsavefiletojson = new System.Windows.Forms.Button();
            this.BTNdirtoexctractallpath = new System.Windows.Forms.Button();
            this.BTNselectarpath3 = new System.Windows.Forms.Button();
            this.LBLinjector = new System.Windows.Forms.Label();
            this.TBdirtoexctractallpath = new System.Windows.Forms.TextBox();
            this.BTNinject = new System.Windows.Forms.Button();
            this.BTNextract = new System.Windows.Forms.Button();
            this.RTBassetregistryparsedread = new System.Windows.Forms.RichTextBox();
            this.BTNselectarpath2 = new System.Windows.Forms.Button();
            this.BTNselectdirtoinject = new System.Windows.Forms.Button();
            this.TBarpath2 = new System.Windows.Forms.TextBox();
            this.TBarpath = new System.Windows.Forms.TextBox();
            this.TBdirtoinjectpath = new System.Windows.Forms.TextBox();
            this.BTNselectarpath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TBsearch
            // 
            this.TBsearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.TBsearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBsearch.Enabled = false;
            this.TBsearch.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBsearch.ForeColor = System.Drawing.Color.White;
            this.TBsearch.Location = new System.Drawing.Point(470, 119);
            this.TBsearch.Name = "TBsearch";
            this.TBsearch.Size = new System.Drawing.Size(284, 24);
            this.TBsearch.TabIndex = 9;
            // 
            // BTNsearch
            // 
            this.BTNsearch.AutoSize = true;
            this.BTNsearch.Enabled = false;
            this.BTNsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNsearch.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNsearch.Location = new System.Drawing.Point(379, 117);
            this.BTNsearch.Name = "BTNsearch";
            this.BTNsearch.Size = new System.Drawing.Size(85, 28);
            this.BTNsearch.TabIndex = 10;
            this.BTNsearch.Text = "Search";
            this.BTNsearch.UseVisualStyleBackColor = true;
            this.BTNsearch.Click += new System.EventHandler(this.BTNsearch_Click);
            // 
            // LBLeditor
            // 
            this.LBLeditor.AutoSize = true;
            this.LBLeditor.Font = new System.Drawing.Font("Unispace", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLeditor.Location = new System.Drawing.Point(493, 11);
            this.LBLeditor.Name = "LBLeditor";
            this.LBLeditor.Size = new System.Drawing.Size(144, 42);
            this.LBLeditor.TabIndex = 27;
            this.LBLeditor.Text = "Editor";
            // 
            // BTNsavefiletobin
            // 
            this.BTNsavefiletobin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BTNsavefiletobin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNsavefiletobin.Enabled = false;
            this.BTNsavefiletobin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNsavefiletobin.Location = new System.Drawing.Point(572, 86);
            this.BTNsavefiletobin.Name = "BTNsavefiletobin";
            this.BTNsavefiletobin.Size = new System.Drawing.Size(182, 25);
            this.BTNsavefiletobin.TabIndex = 23;
            this.BTNsavefiletobin.Text = "Save in .bin";
            this.BTNsavefiletobin.UseVisualStyleBackColor = false;
            this.BTNsavefiletobin.Click += new System.EventHandler(this.BTNsavefiletobin_Click);
            // 
            // LBLdumper
            // 
            this.LBLdumper.AutoSize = true;
            this.LBLdumper.Font = new System.Drawing.Font("Unispace", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLdumper.Location = new System.Drawing.Point(12, 333);
            this.LBLdumper.Name = "LBLdumper";
            this.LBLdumper.Size = new System.Drawing.Size(207, 42);
            this.LBLdumper.TabIndex = 24;
            this.LBLdumper.Text = "Extractor";
            // 
            // BTNsavefiletojson
            // 
            this.BTNsavefiletojson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BTNsavefiletojson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNsavefiletojson.Enabled = false;
            this.BTNsavefiletojson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNsavefiletojson.Location = new System.Drawing.Point(379, 86);
            this.BTNsavefiletojson.Name = "BTNsavefiletojson";
            this.BTNsavefiletojson.Size = new System.Drawing.Size(187, 25);
            this.BTNsavefiletojson.TabIndex = 20;
            this.BTNsavefiletojson.Text = "Save in .json";
            this.BTNsavefiletojson.UseVisualStyleBackColor = false;
            this.BTNsavefiletojson.Click += new System.EventHandler(this.BTNsavefiletojson_Click);
            // 
            // BTNdirtoexctractallpath
            // 
            this.BTNdirtoexctractallpath.AutoSize = true;
            this.BTNdirtoexctractallpath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BTNdirtoexctractallpath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNdirtoexctractallpath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNdirtoexctractallpath.Location = new System.Drawing.Point(193, 408);
            this.BTNdirtoexctractallpath.Name = "BTNdirtoexctractallpath";
            this.BTNdirtoexctractallpath.Size = new System.Drawing.Size(175, 25);
            this.BTNdirtoexctractallpath.TabIndex = 26;
            this.BTNdirtoexctractallpath.Text = "Select a output folder";
            this.BTNdirtoexctractallpath.UseVisualStyleBackColor = false;
            this.BTNdirtoexctractallpath.Click += new System.EventHandler(this.BTNdirtoexctractallpath_Click);
            // 
            // BTNselectarpath3
            // 
            this.BTNselectarpath3.AutoSize = true;
            this.BTNselectarpath3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BTNselectarpath3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNselectarpath3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNselectarpath3.Location = new System.Drawing.Point(379, 57);
            this.BTNselectarpath3.Name = "BTNselectarpath3";
            this.BTNselectarpath3.Size = new System.Drawing.Size(375, 25);
            this.BTNselectarpath3.TabIndex = 18;
            this.BTNselectarpath3.Text = "Select AssetRegistry.bin";
            this.BTNselectarpath3.UseVisualStyleBackColor = false;
            this.BTNselectarpath3.Click += new System.EventHandler(this.BTNselectarpath3_Click);
            // 
            // LBLinjector
            // 
            this.LBLinjector.AutoSize = true;
            this.LBLinjector.Font = new System.Drawing.Font("Unispace", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLinjector.Location = new System.Drawing.Point(12, 101);
            this.LBLinjector.Name = "LBLinjector";
            this.LBLinjector.Size = new System.Drawing.Size(186, 42);
            this.LBLinjector.TabIndex = 21;
            this.LBLinjector.Text = "Injector";
            // 
            // TBdirtoexctractallpath
            // 
            this.TBdirtoexctractallpath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.TBdirtoexctractallpath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBdirtoexctractallpath.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBdirtoexctractallpath.ForeColor = System.Drawing.Color.White;
            this.TBdirtoexctractallpath.Location = new System.Drawing.Point(12, 439);
            this.TBdirtoexctractallpath.Name = "TBdirtoexctractallpath";
            this.TBdirtoexctractallpath.Size = new System.Drawing.Size(356, 21);
            this.TBdirtoexctractallpath.TabIndex = 25;
            // 
            // BTNinject
            // 
            this.BTNinject.AutoSize = true;
            this.BTNinject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BTNinject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNinject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNinject.Location = new System.Drawing.Point(12, 234);
            this.BTNinject.Name = "BTNinject";
            this.BTNinject.Size = new System.Drawing.Size(356, 25);
            this.BTNinject.TabIndex = 19;
            this.BTNinject.Text = "Inject";
            this.BTNinject.UseVisualStyleBackColor = false;
            this.BTNinject.Click += new System.EventHandler(this.BTNinject_Click);
            // 
            // BTNextract
            // 
            this.BTNextract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BTNextract.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNextract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNextract.Location = new System.Drawing.Point(12, 466);
            this.BTNextract.Name = "BTNextract";
            this.BTNextract.Size = new System.Drawing.Size(356, 23);
            this.BTNextract.TabIndex = 22;
            this.BTNextract.Text = "Extract";
            this.BTNextract.UseVisualStyleBackColor = false;
            this.BTNextract.Click += new System.EventHandler(this.BTNextract_Click);
            // 
            // RTBassetregistryparsedread
            // 
            this.RTBassetregistryparsedread.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.RTBassetregistryparsedread.DetectUrls = false;
            this.RTBassetregistryparsedread.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTBassetregistryparsedread.ForeColor = System.Drawing.Color.White;
            this.RTBassetregistryparsedread.Location = new System.Drawing.Point(379, 151);
            this.RTBassetregistryparsedread.Name = "RTBassetregistryparsedread";
            this.RTBassetregistryparsedread.ReadOnly = true;
            this.RTBassetregistryparsedread.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.RTBassetregistryparsedread.Size = new System.Drawing.Size(375, 450);
            this.RTBassetregistryparsedread.TabIndex = 12;
            this.RTBassetregistryparsedread.Text = "";
            // 
            // BTNselectarpath2
            // 
            this.BTNselectarpath2.AutoSize = true;
            this.BTNselectarpath2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BTNselectarpath2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNselectarpath2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNselectarpath2.Location = new System.Drawing.Point(12, 408);
            this.BTNselectarpath2.Name = "BTNselectarpath2";
            this.BTNselectarpath2.Size = new System.Drawing.Size(175, 25);
            this.BTNselectarpath2.TabIndex = 16;
            this.BTNselectarpath2.Text = "Select AssetRegistry.bin";
            this.BTNselectarpath2.UseVisualStyleBackColor = false;
            this.BTNselectarpath2.Click += new System.EventHandler(this.BTNselectarpath2_Click);
            // 
            // BTNselectdirtoinject
            // 
            this.BTNselectdirtoinject.AutoSize = true;
            this.BTNselectdirtoinject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BTNselectdirtoinject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNselectdirtoinject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNselectdirtoinject.Location = new System.Drawing.Point(193, 176);
            this.BTNselectdirtoinject.Name = "BTNselectdirtoinject";
            this.BTNselectdirtoinject.Size = new System.Drawing.Size(175, 25);
            this.BTNselectdirtoinject.TabIndex = 17;
            this.BTNselectdirtoinject.Text = "Select folder to inject";
            this.BTNselectdirtoinject.UseVisualStyleBackColor = false;
            this.BTNselectdirtoinject.Click += new System.EventHandler(this.BTNselectdirtoinject_Click);
            // 
            // TBarpath2
            // 
            this.TBarpath2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.TBarpath2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBarpath2.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBarpath2.ForeColor = System.Drawing.Color.White;
            this.TBarpath2.Location = new System.Drawing.Point(12, 381);
            this.TBarpath2.Name = "TBarpath2";
            this.TBarpath2.Size = new System.Drawing.Size(356, 21);
            this.TBarpath2.TabIndex = 15;
            // 
            // TBarpath
            // 
            this.TBarpath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.TBarpath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBarpath.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBarpath.ForeColor = System.Drawing.Color.White;
            this.TBarpath.Location = new System.Drawing.Point(12, 149);
            this.TBarpath.Name = "TBarpath";
            this.TBarpath.Size = new System.Drawing.Size(356, 21);
            this.TBarpath.TabIndex = 11;
            // 
            // TBdirtoinjectpath
            // 
            this.TBdirtoinjectpath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.TBdirtoinjectpath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBdirtoinjectpath.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBdirtoinjectpath.ForeColor = System.Drawing.Color.White;
            this.TBdirtoinjectpath.Location = new System.Drawing.Point(12, 207);
            this.TBdirtoinjectpath.Name = "TBdirtoinjectpath";
            this.TBdirtoinjectpath.Size = new System.Drawing.Size(356, 21);
            this.TBdirtoinjectpath.TabIndex = 14;
            // 
            // BTNselectarpath
            // 
            this.BTNselectarpath.AutoSize = true;
            this.BTNselectarpath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BTNselectarpath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNselectarpath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNselectarpath.Location = new System.Drawing.Point(12, 176);
            this.BTNselectarpath.Name = "BTNselectarpath";
            this.BTNselectarpath.Size = new System.Drawing.Size(175, 25);
            this.BTNselectarpath.TabIndex = 13;
            this.BTNselectarpath.Text = "Select AssetRegistry.bin";
            this.BTNselectarpath.UseVisualStyleBackColor = false;
            this.BTNselectarpath.Click += new System.EventHandler(this.BTNselectarpath_Click);
            // 
            // AREditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(766, 611);
            this.Controls.Add(this.TBsearch);
            this.Controls.Add(this.BTNsearch);
            this.Controls.Add(this.LBLeditor);
            this.Controls.Add(this.BTNsavefiletobin);
            this.Controls.Add(this.LBLdumper);
            this.Controls.Add(this.BTNsavefiletojson);
            this.Controls.Add(this.BTNdirtoexctractallpath);
            this.Controls.Add(this.BTNselectarpath3);
            this.Controls.Add(this.LBLinjector);
            this.Controls.Add(this.TBdirtoexctractallpath);
            this.Controls.Add(this.BTNinject);
            this.Controls.Add(this.BTNextract);
            this.Controls.Add(this.RTBassetregistryparsedread);
            this.Controls.Add(this.BTNselectarpath2);
            this.Controls.Add(this.BTNselectdirtoinject);
            this.Controls.Add(this.TBarpath2);
            this.Controls.Add(this.TBarpath);
            this.Controls.Add(this.TBdirtoinjectpath);
            this.Controls.Add(this.BTNselectarpath);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(782, 562);
            this.Name = "AREditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asset Registry Editor";
            this.Load += new System.EventHandler(this.AREditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void TBdirtoinjectpath_TextChanged(object sender, EventArgs e)
    {

    }

    private void PNLforrtc_Paint(object sender, PaintEventArgs e)
    {

    }
}
