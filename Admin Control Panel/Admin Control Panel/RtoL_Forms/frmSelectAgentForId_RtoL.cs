using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO; 
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Layouts;
using Telerik.WinControls.UI;
using Admin_Control_Panel.Classes;
using System.Threading;


namespace Admin_Control_Panel.RtoL_Forms
{
    public partial class frmSelectAgentForId_RtoL : Telerik.WinControls.UI.RadForm
    {
        private string _langCode;
        private string _agentId;
        private string _agentName;
        private int _selectedSystemIndex;
      

        public frmSelectAgentForId_RtoL()
        {
         
            _langCode = Convert.ToString(Program.LangCode);
            InitializeComponent();
        }

        private void frmSelectAgentForId_RtoL_Load(object sender, EventArgs e)
        {

            FillForm();
            FillSystemName();
        }

        private void FillForm()
        {
            LogicLayer ll = new LogicLayer();

            this.Text = ll.GetMessageFromDll(_langCode, "SystemSelection");
            
            lblAgentName.Text = ll.GetMessageFromDll(_langCode, "SelectSystem");

            btnCancel.Text = ll.GetMessageFromDll(_langCode, "btnCancel");
            btnOk.Text = ll.GetMessageFromDll(_langCode, "btnOk");

        }

        private void FillSystemName()
        {
            LogicLayer lg = new LogicLayer();
            int count = Program.AgentList.Count;

            ddlAgentName.BeginUpdate();
            this.ddlAgentName.ListElement.AutoSizeItems = true;


            for (int i = 0; i < count; i++)
            {
                if (Program.dataSource[i].UserFullName != "")
                    ddlAgentName.Items.Add(Program.dataSource[i].UserFullName);
                else
                    ddlAgentName.Items.Add(Program.AgentList[i].ComputerName);

                ddlAgentName.Items[i].TextImageRelation = TextImageRelation.ImageBeforeText;
                ddlAgentName.Items[i].Image = GetImageFromData(lg.imageToByteArray((Program.dataSource[i].UserImage)));
                ddlAgentName.Items[i].Font = new Font("Tahoma", 9, FontStyle.Regular);

            }
            ddlAgentName.EndUpdate();
            ddlAgentName.SelectedIndex = 0;

            /***************/
        }

        private Image GetImageFromData(byte[] imageData)
        {
            const int OleHeaderLength = 78;
            MemoryStream memoryStream = new MemoryStream();
            if (HasOleContainerHeader(imageData))
            {
                memoryStream.Write(imageData, OleHeaderLength, imageData.Length - OleHeaderLength);
            }
            else
            {
                memoryStream.Write(imageData, 0, imageData.Length);
            }
            Bitmap bitmap = new Bitmap(memoryStream);
            return bitmap.GetThumbnailImage(55, 65, null, new IntPtr());
        }

        private bool HasOleContainerHeader(byte[] imageByteArray)
        {
            const byte OleByte0 = 21;
            const byte OleByte1 = 28;
            return (imageByteArray[0] == OleByte0) && (imageByteArray[1] == OleByte1);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ddlAgentName_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            _selectedSystemIndex = ddlAgentName.SelectedIndex;
        }
    }   
}


