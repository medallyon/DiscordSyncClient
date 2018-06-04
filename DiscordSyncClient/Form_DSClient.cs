using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using NLua;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace DiscordSyncClient
{
    public partial class Form_DSClient : Form
    {
        private static readonly WebClient WEB_CLIENT = new WebClient();

        public static readonly string DEFAULT_SAVEDVARIABLES_PATH = Environment.ExpandEnvironmentVariables("%USERPROFILE%\\Documents\\Elder Scrolls Online\\live\\SavedVariables\\DiscordSync.lua");
        public static readonly string API_DOMAIN = "api.grogsile.org";
        public static readonly string API_ENDPOINT = "esoi/characterUpload";

        public string SavedVariablesPath = DEFAULT_SAVEDVARIABLES_PATH;
        public Dictionary<string, ESOCharacter> Characters;

        public Form_DSClient()
        {
            InitializeComponent();
            
            WEB_CLIENT.BaseAddress = $"https://{API_DOMAIN}";
            WEB_CLIENT.Headers.Set("Authorization", "GM72HW6CGJr5khtS");

            WEB_CLIENT.UploadProgressChanged += Update_ProgressBar;
            WEB_CLIENT.UploadValuesCompleted += Upload_Finished;

            if (File.Exists(DEFAULT_SAVEDVARIABLES_PATH))
                this.Characters = Parse_Lua(DEFAULT_SAVEDVARIABLES_PATH);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileBrowser.InitialDirectory = DEFAULT_SAVEDVARIABLES_PATH;
        }

        private Dictionary<string, ESOCharacter> Parse_Lua(string fileName)
        {
            var LuaClient = new Lua();
            object[] result = null;

            try
            {
                result = LuaClient.DoFile(fileName);
            }

            catch (NLua.Exceptions.LuaException error)
            {
                MessageBox.Show($"Something went wrong while reading your characters: {error.Message}");
                return null;
            }

            LuaTable rootTable = LuaClient.GetTable("DiscordSync_SavedVars");
            LuaTable defaultTable = (LuaTable)rootTable["Default"];

            Dictionary<object, LuaTable> Accounts = new Dictionary<object, LuaTable>();
            foreach (object key in defaultTable.Keys)
            {
                LuaTable value = (LuaTable)defaultTable[key];
                Accounts.Add(key, value);
            }

            Dictionary<object, LuaTable> LuaCharacters = new Dictionary<object, LuaTable>();
            foreach (object account in Accounts.Keys)
            {
                LuaTable characters = Accounts[account];
                foreach (object characterID in characters.Keys)
                {
                    if (characterID.ToString() == "$AccountWide")
                        continue;

                    LuaTable character = (LuaTable)characters[characterID];
                    LuaCharacters.Add(characterID, character);
                }
            }

            Dictionary<string, ESOCharacter> Characters = new Dictionary<string, ESOCharacter>();
            foreach (LuaTable character in LuaCharacters.Values)
            {
                Characters.Add((string)character["name"], new ESOCharacter((string)character["name"])
                {
                    IsChampion = (bool)character["isChampion"],
                    Level = (int)(double)character["level"],
                    Gender = (int)(double)character["gender"],
                    Class = (string)character["class"],
                    Race = (string)character["race"],
                    Alliance = (int)(double)character["alliance"]
                });
            }

            return Characters;
        }

        private void Button_Upload_Click(object sender, EventArgs e)
        {
            this.Characters = Parse_Lua(this.SavedVariablesPath);

            var content = new NameValueCollection()
            {
                { "characters", JsonConvert.SerializeObject(this.Characters) }
            };

            Post_Data(content);
        }

        private void Button_SetPath_Click(object sender, EventArgs e)
        {
            if (FileBrowser.ShowDialog() == DialogResult.OK)
                this.SavedVariablesPath = FileBrowser.FileName;
        }

        private void Update_ProgressBar(object sender, UploadProgressChangedEventArgs e)
        {
            Console.WriteLine("Updated ProgressBar.");
            ProgressBar_Upload.Maximum = e.ProgressPercentage * 100;
        }

        private void Upload_Finished(object sender, UploadValuesCompletedEventArgs e)
        {
            Console.WriteLine("Upload Finished.");
            MessageBox.Show(e.ToString());
        }

        private void Post_Data(NameValueCollection data)
        {
            if (TextBox_Token.Text.Length == 0)
                MessageBox.Show("Please input your Account Token and try again.");

            else
            {
                WEB_CLIENT.Headers.Set("Token", TextBox_Token.Text);
                try
                {
                    WEB_CLIENT.UploadValues(new Uri($"{WEB_CLIENT.BaseAddress}/{API_ENDPOINT}"), data);
                }

                catch (WebException error)
                {
                    MessageBox.Show($"Something went wrong while uploading your characters: {error.Message}");
                }
            }
        }

        private void ProgressBar_Upload_Click(object sender, EventArgs e)
        {

        }

        private void TextBox_Token_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
