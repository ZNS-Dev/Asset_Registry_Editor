using Microsoft.Win32;
using Newtonsoft.Json;
using QueenIO;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Asset_Registry_Editor;

internal class Fonctions
{
    public static void SelectBinFile(out string BinFilePath)
    {
        BinFilePath = null;
        OpenFileDialog openFileDialog = new()
        {
            InitialDirectory = "C:\\",
            Filter = "Binary Files (*.bin)|*.bin"
        };
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            BinFilePath = openFileDialog.FileName;
        }
    }

    public static void SelectDir(out string DirFilePath)
    {
        DirFilePath = null;
        FolderBrowserDialog folderBrowserDialog = new();
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            DirFilePath = folderBrowserDialog.SelectedPath;
        }
    }

    public static void InjectJsonCode(string AssetRegistryPath, string FolderJsonToInject)
    {
        try
        {
            AssetRegistry assetRegistry = new();
            assetRegistry.Read(File.ReadAllBytes(AssetRegistryPath));
            string[] files = Directory.GetFiles(FolderJsonToInject, "*.json");
            string[] array = files;
            for (int i = 0; i < array.Length; i++)
            {
                AssetRegistry.FAssetData item = JsonConvert.DeserializeObject<AssetRegistry.FAssetData>(File.ReadAllText(array[i]));
                assetRegistry.fAssetDatas.Add(item);
            }
            File.WriteAllBytes(AssetRegistryPath + "_NewFile", assetRegistry.Make());
        }
        catch
        {
            MessageBox.Show(
            "Failed to inject!\nMake sure the Asset Registry is not corrupted or the version is 4.26.2.",
            "Inject Update",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
        }
    }

    public static void DumpAllAssetRegistry(string AssetRegistryPath, string OutPutFilePath)
    {
        try
        {
            AssetRegistry assetRegistry = new();
            assetRegistry.Read(File.ReadAllBytes(AssetRegistryPath));
            foreach (AssetRegistry.FAssetData fAssetData in assetRegistry.fAssetDatas)
            {
                string contents = JsonConvert.SerializeObject(fAssetData, Formatting.Indented);
                File.WriteAllText(OutPutFilePath + "\\" + fAssetData.ToString() + ".json", contents);
            }
        }
        catch
        {
            MessageBox.Show(
            "Failed to extract Asset Registry!\nMake sure the Asset Registry is not corrupted.",
            "Extract Update",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
        }
    }

    public static void ReadAssetRegistryFile(string FileToRead, out string OutJson)
    {
        OutJson = null;
        try
        {
            AssetRegistry assetRegistry = new();
            assetRegistry.Read(File.ReadAllBytes(FileToRead));
            OutJson = JsonConvert.SerializeObject(assetRegistry, Formatting.Indented);
        }
        catch
        {
            MessageBox.Show(
            "Failed to read Asset Regsitry!\nMake sure the Asset Registry is in version 4.26.2.",
            "Read Update",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
        }
    }

    public static void SaveAssetRegistryJson(string FileToSave, string JsonToSave)
    {
        try
        {
            File.WriteAllText(Path.ChangeExtension(FileToSave, ".json_NewFile"), JsonToSave);
        }
        catch
        {
            MessageBox.Show(
            "Failed to save in .json\nMake sure the Asset Registry is not corrupted.",
            "Save .json Update",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
        }
    }

    public static void SaveAssetRegistryBin(string FileNameOut, string JsonToBin)
    {
        try
        {
            new AssetRegistry();
            byte[] bytes = JsonConvert.DeserializeObject<AssetRegistry>(JsonToBin).Make();
            File.WriteAllBytes(Path.ChangeExtension(FileNameOut, ".bin_NewFile"), bytes);
        }
        catch
        {
            MessageBox.Show(
            "Failed to save in .bin\nMake sure the Asset Registry is not corrupted.",
            "Save .bin Update",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
        }
    }

    public static void RegisterFileAssociation(string extension, string progId, string description)
    {
        using (RegistryKey registryKey = Registry.ClassesRoot.CreateSubKey(extension))
        {
            registryKey.SetValue("", progId);
        }
        using RegistryKey registryKey2 = Registry.ClassesRoot.CreateSubKey(progId);
        registryKey2.SetValue("", description);
        using RegistryKey registryKey3 = registryKey2.CreateSubKey("shell").CreateSubKey("open").CreateSubKey("command");
        registryKey3.SetValue("", "\"" + Assembly.GetExecutingAssembly().Location + "\" \"%1\"");
    }
}
