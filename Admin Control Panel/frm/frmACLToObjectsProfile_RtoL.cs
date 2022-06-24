using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Admin_Control_Panel.Classes;
using Admin_Control_Panel.RtoL_Forms;
using Telerik.WinControls.UI;
using System.Reflection;

namespace Admin_Control_Panel.RtoL_Forms
{
    

    public partial class frmACLToObjectsProfile_RtoL : Telerik.WinControls.UI.RadForm
    {
        private LogicLayer lg;
        private string _langCode;
        private string _SelectedProfileId;
        private bool _SqlError;
        private string SubjectTitle;
        private DataTable dtAgentsAcl;
        private DataTable dtObjectsAcl;
       


        /* Header Text */
        private string headerSubject;
        private string headerAcl;

        /*ACL Text */

        private string l1;
        private string l2;
        private string l3;
        private string l4;
        private string l5;       


        public frmACLToObjectsProfile_RtoL()
        {
            dtAgentsAcl = new DataTable();
            _langCode = Program.LangCode.ToString();
            lg = new LogicLayer();
            _SqlError = false;
            InitializeComponent();
        }

        private void frmACLToObjectsProfile_RtoL_Load(object sender, EventArgs e)
        {
            SetFormMessages();
            FillTreeViews();       
            FillProfileList();
        }     

        private void SetFormMessages()
        {
            this.Text = lg.GetMessageFromDll(_langCode, "AclDefine");

            grbProfileSelect.Text = lg.GetMessageFromDll(_langCode, "Profile");
            rbtNewProfile.Text = lg.GetMessageFromDll(_langCode, "NewProfile");
            rbtSelectProfile.Text = lg.GetMessageFromDll(_langCode, "SelectProfile");
            rbtCopyProfile.Text = lg.GetMessageFromDll(_langCode, "CopyProfile");
            lblTo.Text = lg.GetMessageFromDll(_langCode, "To");

            pwpAgents.Text = lg.GetMessageFromDll(_langCode, "System");
            pwpReports.Text = lg.GetMessageFromDll(_langCode, "Objects");
         
            l1 = lg.GetMessageFromDll(_langCode, "Unclassified");
            l2 = lg.GetMessageFromDll(_langCode, "Restricted");
            l3 = lg.GetMessageFromDll(_langCode, "Confidential");
            l4 = lg.GetMessageFromDll(_langCode, "Secret");
            l5 = lg.GetMessageFromDll(_langCode, "TopSecret");

        }

        private void FillTreeViews()
        {
            trvAgents.Nodes["Node1"].Text = lg.GetMessageFromDll(_langCode, "acl4");
            trvAgents.Nodes["Node2"].Text = lg.GetMessageFromDll(_langCode, "acl18");
            trvAgents.Nodes["Node3"].Text = lg.GetMessageFromDll(_langCode, "acl20");
            trvAgents.Nodes["Node4"].Text = lg.GetMessageFromDll(_langCode, "acl37");
            trvAgents.Nodes["Node5"].Text = lg.GetMessageFromDll(_langCode, "acl38");
            trvAgents.Nodes["Node6"].Text = lg.GetMessageFromDll(_langCode, "acl39");
            trvAgents.Nodes["Node7"].Text = lg.GetMessageFromDll(_langCode, "acl29");
            trvAgents.Nodes["Node8"].Text = lg.GetMessageFromDll(_langCode, "acl41");

            trvAgents.Nodes["Node1"].Nodes["5"].Text = lg.GetMessageFromDll(_langCode, "acl5");
            trvAgents.Nodes["Node1"].Nodes["6"].Text = lg.GetMessageFromDll(_langCode, "acl6");
            trvAgents.Nodes["Node1"].Nodes["7"].Text = lg.GetMessageFromDll(_langCode, "acl7");
            trvAgents.Nodes["Node1"].Nodes["8"].Text = lg.GetMessageFromDll(_langCode, "acl8");


            trvAgents.Nodes["Node2"].Nodes["19"].Text = lg.GetMessageFromDll(_langCode, "acl19");

            trvAgents.Nodes["Node3"].Nodes["21"].Text = lg.GetMessageFromDll(_langCode, "acl21");
            trvAgents.Nodes["Node3"].Nodes["22"].Text = lg.GetMessageFromDll(_langCode, "acl22");
            trvAgents.Nodes["Node3"].Nodes["23"].Text = lg.GetMessageFromDll(_langCode, "acl23");

            trvAgents.Nodes["Node4"].Nodes["11"].Text = lg.GetMessageFromDll(_langCode, "acl11");
            trvAgents.Nodes["Node4"].Nodes["13"].Text = lg.GetMessageFromDll(_langCode, "acl13");

            trvAgents.Nodes["Node5"].Nodes["3"].Text = lg.GetMessageFromDll(_langCode, "acl3");
            trvAgents.Nodes["Node5"].Nodes["9"].Text = lg.GetMessageFromDll(_langCode, "acl9");
            trvAgents.Nodes["Node5"].Nodes["10"].Text = lg.GetMessageFromDll(_langCode, "acl10");
            trvAgents.Nodes["Node5"].Nodes["12"].Text = lg.GetMessageFromDll(_langCode, "acl12");
            trvAgents.Nodes["Node5"].Nodes["14"].Text = lg.GetMessageFromDll(_langCode, "acl14");

            trvAgents.Nodes["Node6"].Nodes["15"].Text = lg.GetMessageFromDll(_langCode, "acl15");
            trvAgents.Nodes["Node6"].Nodes["16"].Text = lg.GetMessageFromDll(_langCode, "acl16");
            trvAgents.Nodes["Node6"].Nodes["17"].Text = lg.GetMessageFromDll(_langCode, "acl17");
            trvAgents.Nodes["Node6"].Nodes["24"].Text = lg.GetMessageFromDll(_langCode, "acl24");
            trvAgents.Nodes["Node6"].Nodes["1"].Text = lg.GetMessageFromDll(_langCode, "acl1");
            trvAgents.Nodes["Node6"].Nodes["2"].Text = lg.GetMessageFromDll(_langCode, "acl2");

            trvAgents.Nodes["Node7"].Nodes["42"].Text = lg.GetMessageFromDll(_langCode, "acl42");
            trvAgents.Nodes["Node8"].Nodes["43"].Text = lg.GetMessageFromDll(_langCode, "acl43");


            trvAgents.Nodes["Node1"].Nodes["5"].Nodes["lev1"].Text = l1;
            trvAgents.Nodes["Node1"].Nodes["5"].Nodes["lev2"].Text = l2;
            trvAgents.Nodes["Node1"].Nodes["5"].Nodes["lev3"].Text = l3;
            trvAgents.Nodes["Node1"].Nodes["5"].Nodes["lev4"].Text = l4;
            trvAgents.Nodes["Node1"].Nodes["5"].Nodes["lev5"].Text = l5;

            trvAgents.Nodes["Node1"].Nodes["6"].Nodes["lev1"].Text = l1;
            trvAgents.Nodes["Node1"].Nodes["6"].Nodes["lev2"].Text = l2;
            trvAgents.Nodes["Node1"].Nodes["6"].Nodes["lev3"].Text = l3;
            trvAgents.Nodes["Node1"].Nodes["6"].Nodes["lev4"].Text = l4;
            trvAgents.Nodes["Node1"].Nodes["6"].Nodes["lev5"].Text = l5;

            trvAgents.Nodes["Node1"].Nodes["7"].Nodes["lev1"].Text = l1;
            trvAgents.Nodes["Node1"].Nodes["7"].Nodes["lev2"].Text = l2;
            trvAgents.Nodes["Node1"].Nodes["7"].Nodes["lev3"].Text = l3;
            trvAgents.Nodes["Node1"].Nodes["7"].Nodes["lev4"].Text = l4;
            trvAgents.Nodes["Node1"].Nodes["7"].Nodes["lev5"].Text = l5;

            trvAgents.Nodes["Node1"].Nodes["8"].Nodes["lev1"].Text = l1;
            trvAgents.Nodes["Node1"].Nodes["8"].Nodes["lev2"].Text = l2;
            trvAgents.Nodes["Node1"].Nodes["8"].Nodes["lev3"].Text = l3;
            trvAgents.Nodes["Node1"].Nodes["8"].Nodes["lev4"].Text = l4;
            trvAgents.Nodes["Node1"].Nodes["8"].Nodes["lev5"].Text = l5;



            trvAgents.Nodes["Node2"].Nodes["19"].Nodes["lev1"].Text = l1;
            trvAgents.Nodes["Node2"].Nodes["19"].Nodes["lev2"].Text = l2;
            trvAgents.Nodes["Node2"].Nodes["19"].Nodes["lev3"].Text = l3;
            trvAgents.Nodes["Node2"].Nodes["19"].Nodes["lev4"].Text = l4;
            trvAgents.Nodes["Node2"].Nodes["19"].Nodes["lev5"].Text = l5;

            trvAgents.Nodes["Node3"].Nodes["21"].Nodes["lev1"].Text = l1;
            trvAgents.Nodes["Node3"].Nodes["21"].Nodes["lev2"].Text = l2;
            trvAgents.Nodes["Node3"].Nodes["21"].Nodes["lev3"].Text = l3;
            trvAgents.Nodes["Node3"].Nodes["21"].Nodes["lev4"].Text = l4;
            trvAgents.Nodes["Node3"].Nodes["21"].Nodes["lev5"].Text = l5;

            trvAgents.Nodes["Node3"].Nodes["22"].Nodes["lev1"].Text = l1;
            trvAgents.Nodes["Node3"].Nodes["22"].Nodes["lev2"].Text = l2;
            trvAgents.Nodes["Node3"].Nodes["22"].Nodes["lev3"].Text = l3;
            trvAgents.Nodes["Node3"].Nodes["22"].Nodes["lev4"].Text = l4;
            trvAgents.Nodes["Node3"].Nodes["22"].Nodes["lev5"].Text = l5;

            trvAgents.Nodes["Node3"].Nodes["23"].Nodes["lev1"].Text = l1;
            trvAgents.Nodes["Node3"].Nodes["23"].Nodes["lev2"].Text = l2;
            trvAgents.Nodes["Node3"].Nodes["23"].Nodes["lev3"].Text = l3;
            trvAgents.Nodes["Node3"].Nodes["23"].Nodes["lev4"].Text = l4;
            trvAgents.Nodes["Node3"].Nodes["23"].Nodes["lev5"].Text = l5;

            trvAgents.Nodes["Node4"].Nodes["11"].Nodes["lev1"].Text = l1;
            trvAgents.Nodes["Node4"].Nodes["11"].Nodes["lev2"].Text = l2;
            trvAgents.Nodes["Node4"].Nodes["11"].Nodes["lev3"].Text = l3;
            trvAgents.Nodes["Node4"].Nodes["11"].Nodes["lev4"].Text = l4;
            trvAgents.Nodes["Node4"].Nodes["11"].Nodes["lev5"].Text = l5;

            trvAgents.Nodes["Node4"].Nodes["13"].Nodes["lev1"].Text = l1;
            trvAgents.Nodes["Node4"].Nodes["13"].Nodes["lev2"].Text = l2;
            trvAgents.Nodes["Node4"].Nodes["13"].Nodes["lev3"].Text = l3;
            trvAgents.Nodes["Node4"].Nodes["13"].Nodes["lev4"].Text = l4;
            trvAgents.Nodes["Node4"].Nodes["13"].Nodes["lev5"].Text = l5;

            trvAgents.Nodes["Node5"].Nodes["3"].Nodes["lev1"].Text = l1;
            trvAgents.Nodes["Node5"].Nodes["3"].Nodes["lev2"].Text = l2;
            trvAgents.Nodes["Node5"].Nodes["3"].Nodes["lev3"].Text = l3;
            trvAgents.Nodes["Node5"].Nodes["3"].Nodes["lev4"].Text = l4;
            trvAgents.Nodes["Node5"].Nodes["3"].Nodes["lev5"].Text = l5;

            trvAgents.Nodes["Node5"].Nodes["9"].Nodes["lev1"].Text = l1;
            trvAgents.Nodes["Node5"].Nodes["9"].Nodes["lev2"].Text = l2;
            trvAgents.Nodes["Node5"].Nodes["9"].Nodes["lev3"].Text = l3;
            trvAgents.Nodes["Node5"].Nodes["9"].Nodes["lev4"].Text = l4;
            trvAgents.Nodes["Node5"].Nodes["9"].Nodes["lev5"].Text = l5;

            trvAgents.Nodes["Node5"].Nodes["10"].Nodes["lev1"].Text = l1;
            trvAgents.Nodes["Node5"].Nodes["10"].Nodes["lev2"].Text = l2;
            trvAgents.Nodes["Node5"].Nodes["10"].Nodes["lev3"].Text = l3;
            trvAgents.Nodes["Node5"].Nodes["10"].Nodes["lev4"].Text = l4;
            trvAgents.Nodes["Node5"].Nodes["10"].Nodes["lev5"].Text = l5;

            trvAgents.Nodes["Node5"].Nodes["12"].Nodes["lev1"].Text = l1;
            trvAgents.Nodes["Node5"].Nodes["12"].Nodes["lev2"].Text = l2;
            trvAgents.Nodes["Node5"].Nodes["12"].Nodes["lev3"].Text = l3;
            trvAgents.Nodes["Node5"].Nodes["12"].Nodes["lev4"].Text = l4;
            trvAgents.Nodes["Node5"].Nodes["12"].Nodes["lev5"].Text = l5;

            trvAgents.Nodes["Node5"].Nodes["14"].Nodes["lev1"].Text = l1;
            trvAgents.Nodes["Node5"].Nodes["14"].Nodes["lev2"].Text = l2;
            trvAgents.Nodes["Node5"].Nodes["14"].Nodes["lev3"].Text = l3;
            trvAgents.Nodes["Node5"].Nodes["14"].Nodes["lev4"].Text = l4;
            trvAgents.Nodes["Node5"].Nodes["14"].Nodes["lev5"].Text = l5;

            trvAgents.Nodes["Node6"].Nodes["15"].Nodes["lev1"].Text = l1;
            trvAgents.Nodes["Node6"].Nodes["15"].Nodes["lev2"].Text = l2;
            trvAgents.Nodes["Node6"].Nodes["15"].Nodes["lev3"].Text = l3;
            trvAgents.Nodes["Node6"].Nodes["15"].Nodes["lev4"].Text = l4;
            trvAgents.Nodes["Node6"].Nodes["15"].Nodes["lev5"].Text = l5;

            trvAgents.Nodes["Node6"].Nodes["16"].Nodes["lev1"].Text = l1;
            trvAgents.Nodes["Node6"].Nodes["16"].Nodes["lev2"].Text = l2;
            trvAgents.Nodes["Node6"].Nodes["16"].Nodes["lev3"].Text = l3;
            trvAgents.Nodes["Node6"].Nodes["16"].Nodes["lev4"].Text = l4;
            trvAgents.Nodes["Node6"].Nodes["16"].Nodes["lev5"].Text = l5;

            trvAgents.Nodes["Node6"].Nodes["17"].Nodes["lev1"].Text = l1;
            trvAgents.Nodes["Node6"].Nodes["17"].Nodes["lev2"].Text = l2;
            trvAgents.Nodes["Node6"].Nodes["17"].Nodes["lev3"].Text = l3;
            trvAgents.Nodes["Node6"].Nodes["17"].Nodes["lev4"].Text = l4;
            trvAgents.Nodes["Node6"].Nodes["17"].Nodes["lev5"].Text = l5;

            trvAgents.Nodes["Node6"].Nodes["24"].Nodes["lev1"].Text = l1;
            trvAgents.Nodes["Node6"].Nodes["24"].Nodes["lev2"].Text = l2;
            trvAgents.Nodes["Node6"].Nodes["24"].Nodes["lev3"].Text = l3;
            trvAgents.Nodes["Node6"].Nodes["24"].Nodes["lev4"].Text = l4;
            trvAgents.Nodes["Node6"].Nodes["24"].Nodes["lev5"].Text = l5;

            trvAgents.Nodes["Node6"].Nodes["1"].Nodes["lev1"].Text = l1;
            trvAgents.Nodes["Node6"].Nodes["1"].Nodes["lev2"].Text = l2;
            trvAgents.Nodes["Node6"].Nodes["1"].Nodes["lev3"].Text = l3;
            trvAgents.Nodes["Node6"].Nodes["1"].Nodes["lev4"].Text = l4;
            trvAgents.Nodes["Node6"].Nodes["1"].Nodes["lev5"].Text = l5;

            trvAgents.Nodes["Node6"].Nodes["2"].Nodes["lev1"].Text = l1;
            trvAgents.Nodes["Node6"].Nodes["2"].Nodes["lev2"].Text = l2;
            trvAgents.Nodes["Node6"].Nodes["2"].Nodes["lev3"].Text = l3;
            trvAgents.Nodes["Node6"].Nodes["2"].Nodes["lev4"].Text = l4;
            trvAgents.Nodes["Node6"].Nodes["2"].Nodes["lev5"].Text = l5;

            trvAgents.Nodes["Node7"].Nodes["42"].Nodes["lev1"].Text = l1;
            trvAgents.Nodes["Node7"].Nodes["42"].Nodes["lev2"].Text = l2;
            trvAgents.Nodes["Node7"].Nodes["42"].Nodes["lev3"].Text = l3;
            trvAgents.Nodes["Node7"].Nodes["42"].Nodes["lev4"].Text = l4;
            trvAgents.Nodes["Node7"].Nodes["42"].Nodes["lev5"].Text = l5;

            trvAgents.Nodes["Node8"].Nodes["43"].Nodes["lev1"].Text = l1;
            trvAgents.Nodes["Node8"].Nodes["43"].Nodes["lev2"].Text = l2;
            trvAgents.Nodes["Node8"].Nodes["43"].Nodes["lev3"].Text = l3;
            trvAgents.Nodes["Node8"].Nodes["43"].Nodes["lev4"].Text = l4;
            trvAgents.Nodes["Node8"].Nodes["43"].Nodes["lev5"].Text = l5;



            this.trvAgents.SortOrder = SortOrder.Ascending;
            trvAgents.CollapseAll();

            trvObjects.Nodes["Node1"].Text = lg.GetMessageFromDll(_langCode, "acl25");
            trvObjects.Nodes["Node2"].Text = lg.GetMessageFromDll(_langCode, "acl26");
            trvObjects.Nodes["Node3"].Text = lg.GetMessageFromDll(_langCode, "acl27");
            trvObjects.Nodes["Node4"].Text = lg.GetMessageFromDll(_langCode, "acl28");
            trvObjects.Nodes["Node5"].Text = lg.GetMessageFromDll(_langCode, "acl30");
            trvObjects.Nodes["Node6"].Text = lg.GetMessageFromDll(_langCode, "acl39");
            trvObjects.Nodes["Node7"].Text = lg.GetMessageFromDll(_langCode, "acl44");
            trvObjects.Nodes["Node8"].Text = lg.GetMessageFromDll(_langCode, "acl45");

            trvObjects.Nodes["Node1"].Nodes["46"].Text = lg.GetMessageFromDll(_langCode, "acl46");
            trvObjects.Nodes["Node1"].Nodes["47"].Text = lg.GetMessageFromDll(_langCode, "acl47");

            trvObjects.Nodes["Node2"].Nodes["48"].Text = lg.GetMessageFromDll(_langCode, "acl48");
            trvObjects.Nodes["Node2"].Nodes["49"].Text = lg.GetMessageFromDll(_langCode, "acl49");

            trvObjects.Nodes["Node3"].Nodes["50"].Text = lg.GetMessageFromDll(_langCode, "acl50");
            trvObjects.Nodes["Node3"].Nodes["51"].Text = lg.GetMessageFromDll(_langCode, "acl51");
            trvObjects.Nodes["Node3"].Nodes["52"].Text = lg.GetMessageFromDll(_langCode, "acl52");
            trvObjects.Nodes["Node3"].Nodes["53"].Text = lg.GetMessageFromDll(_langCode, "acl53");
            trvObjects.Nodes["Node3"].Nodes["54"].Text = lg.GetMessageFromDll(_langCode, "acl54");

            trvObjects.Nodes["Node4"].Nodes["55"].Text = lg.GetMessageFromDll(_langCode, "acl55");
            trvObjects.Nodes["Node4"].Nodes["56"].Text = lg.GetMessageFromDll(_langCode, "acl56");

            trvObjects.Nodes["Node5"].Nodes["57"].Text = lg.GetMessageFromDll(_langCode, "acl57");
            trvObjects.Nodes["Node5"].Nodes["58"].Text = lg.GetMessageFromDll(_langCode, "acl58");
            trvObjects.Nodes["Node5"].Nodes["59"].Text = lg.GetMessageFromDll(_langCode, "acl59");

            trvObjects.Nodes["Node6"].Nodes["60"].Text = lg.GetMessageFromDll(_langCode, "acl60");
            trvObjects.Nodes["Node6"].Nodes["61"].Text = lg.GetMessageFromDll(_langCode, "acl61");
            trvObjects.Nodes["Node6"].Nodes["62"].Text = lg.GetMessageFromDll(_langCode, "acl62");
            trvObjects.Nodes["Node6"].Nodes["63"].Text = lg.GetMessageFromDll(_langCode, "acl63");
            trvObjects.Nodes["Node6"].Nodes["64"].Text = lg.GetMessageFromDll(_langCode, "acl64");
            trvObjects.Nodes["Node6"].Nodes["65"].Text = lg.GetMessageFromDll(_langCode, "acl65");

            trvObjects.Nodes["Node7"].Nodes["66"].Text = lg.GetMessageFromDll(_langCode, "acl66");
            trvObjects.Nodes["Node7"].Nodes["67"].Text = lg.GetMessageFromDll(_langCode, "acl67");
            trvObjects.Nodes["Node7"].Nodes["68"].Text = lg.GetMessageFromDll(_langCode, "acl68");
            trvObjects.Nodes["Node7"].Nodes["69"].Text = lg.GetMessageFromDll(_langCode, "acl69");

            trvObjects.Nodes["Node8"].Nodes["70"].Text = lg.GetMessageFromDll(_langCode, "acl70");
            trvObjects.Nodes["Node8"].Nodes["71"].Text = lg.GetMessageFromDll(_langCode, "acl71");
            trvObjects.Nodes["Node8"].Nodes["72"].Text = lg.GetMessageFromDll(_langCode, "acl72");
            trvObjects.Nodes["Node8"].Nodes["73"].Text = lg.GetMessageFromDll(_langCode, "acl73");

            trvObjects.Nodes["Node1"].Nodes["46"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node1"].Nodes["46"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node1"].Nodes["46"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node1"].Nodes["46"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node1"].Nodes["46"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node1"].Nodes["47"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node1"].Nodes["47"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node1"].Nodes["47"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node1"].Nodes["47"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node1"].Nodes["47"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node2"].Nodes["48"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node2"].Nodes["48"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node2"].Nodes["48"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node2"].Nodes["48"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node2"].Nodes["48"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node2"].Nodes["49"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node2"].Nodes["49"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node2"].Nodes["49"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node2"].Nodes["49"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node2"].Nodes["49"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node3"].Nodes["50"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node3"].Nodes["50"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node3"].Nodes["50"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node3"].Nodes["50"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node3"].Nodes["50"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node3"].Nodes["51"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node3"].Nodes["51"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node3"].Nodes["51"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node3"].Nodes["51"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node3"].Nodes["51"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node3"].Nodes["52"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node3"].Nodes["52"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node3"].Nodes["52"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node3"].Nodes["52"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node3"].Nodes["52"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node3"].Nodes["53"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node3"].Nodes["53"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node3"].Nodes["53"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node3"].Nodes["53"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node3"].Nodes["53"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node3"].Nodes["54"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node3"].Nodes["54"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node3"].Nodes["54"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node3"].Nodes["54"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node3"].Nodes["54"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node4"].Nodes["55"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node4"].Nodes["55"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node4"].Nodes["55"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node4"].Nodes["55"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node4"].Nodes["55"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node4"].Nodes["56"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node4"].Nodes["56"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node4"].Nodes["56"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node4"].Nodes["56"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node4"].Nodes["56"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node5"].Nodes["57"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node5"].Nodes["57"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node5"].Nodes["57"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node5"].Nodes["57"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node5"].Nodes["57"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node5"].Nodes["58"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node5"].Nodes["58"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node5"].Nodes["58"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node5"].Nodes["58"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node5"].Nodes["58"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node5"].Nodes["59"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node5"].Nodes["59"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node5"].Nodes["59"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node5"].Nodes["59"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node5"].Nodes["59"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node6"].Nodes["60"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node6"].Nodes["60"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node6"].Nodes["60"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node6"].Nodes["60"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node6"].Nodes["60"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node6"].Nodes["61"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node6"].Nodes["61"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node6"].Nodes["61"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node6"].Nodes["61"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node6"].Nodes["61"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node6"].Nodes["62"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node6"].Nodes["62"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node6"].Nodes["62"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node6"].Nodes["62"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node6"].Nodes["62"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node6"].Nodes["63"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node6"].Nodes["63"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node6"].Nodes["63"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node6"].Nodes["63"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node6"].Nodes["63"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node6"].Nodes["64"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node6"].Nodes["64"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node6"].Nodes["64"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node6"].Nodes["64"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node6"].Nodes["64"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node6"].Nodes["65"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node6"].Nodes["65"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node6"].Nodes["65"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node6"].Nodes["65"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node6"].Nodes["65"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node7"].Nodes["66"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node7"].Nodes["66"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node7"].Nodes["66"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node7"].Nodes["66"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node7"].Nodes["66"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node7"].Nodes["67"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node7"].Nodes["67"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node7"].Nodes["67"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node7"].Nodes["67"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node7"].Nodes["67"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node7"].Nodes["68"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node7"].Nodes["68"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node7"].Nodes["68"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node7"].Nodes["68"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node7"].Nodes["68"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node7"].Nodes["69"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node7"].Nodes["69"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node7"].Nodes["69"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node7"].Nodes["69"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node7"].Nodes["69"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node8"].Nodes["70"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node8"].Nodes["70"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node8"].Nodes["70"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node8"].Nodes["70"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node8"].Nodes["70"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node8"].Nodes["71"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node8"].Nodes["71"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node8"].Nodes["71"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node8"].Nodes["71"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node8"].Nodes["71"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node8"].Nodes["72"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node8"].Nodes["72"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node8"].Nodes["72"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node8"].Nodes["72"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node8"].Nodes["72"].Nodes["lev5"].Text = l5;

            trvObjects.Nodes["Node8"].Nodes["73"].Nodes["lev1"].Text = l1;
            trvObjects.Nodes["Node8"].Nodes["73"].Nodes["lev2"].Text = l2;
            trvObjects.Nodes["Node8"].Nodes["73"].Nodes["lev3"].Text = l3;
            trvObjects.Nodes["Node8"].Nodes["73"].Nodes["lev4"].Text = l4;
            trvObjects.Nodes["Node8"].Nodes["73"].Nodes["lev5"].Text = l5;


            this.trvObjects.SortOrder = SortOrder.Ascending;
            trvObjects.CollapseAll();
            
        }    

        private void FillProfileList()
        {

            string _default = lg.GetMessageFromDll(_langCode, "DefaultProfile");
            lg.GetAclHeaderProfile();
            int _rowCount = Program.AclProfileList.Count;

            cmbProfileList.Items.Add(_default);
            cmbProfileTo.Items.Add(_default);
            cmbProfileFrom.Items.Add(_default);

            for (int i = 1; i < _rowCount; i++)
            {
                cmbProfileList.Items.Add(Program.AclProfileList[i].ProfileName);
                cmbProfileFrom.Items.Add(Program.AclProfileList[i].ProfileName);
                cmbProfileTo.Items.Add(Program.AclProfileList[i].ProfileName);
            }
          
            cmbProfileList.SelectedIndex = 0;
            cmbProfileFrom.SelectedIndex = 0;
            cmbProfileTo.SelectedIndex = 0;
        }

        private void cmbProfileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _profileId = Program.AclProfileList[cmbProfileList.SelectedIndex].ProfileId;
            _SelectedProfileId = _profileId;
            SetAgentsAclTables(_SelectedProfileId);
            SetObjectsAclTables(_SelectedProfileId);
            FillAgentsTreeViewData();
            FillObjectsTreeViewData();         
        }

        private void SetAgentsAclTables(string _SelectedProfileId)
        {
            dtAgentsAcl = null;
            dtAgentsAcl = lg.GetAclDetails(_SelectedProfileId, "1");            
        }

        private void SetObjectsAclTables(string _SelectedProfileId)
        {
            dtObjectsAcl = null;
            dtObjectsAcl = lg.GetAclDetails(_SelectedProfileId, "2");
        }

        private void FillAgentsTreeViewData()
        {
            int _rows = dtAgentsAcl.Rows.Count;
            string _subId, _aclLevel;
            for (int i = 0; i < _rows; i++)
            {
                _subId = dtAgentsAcl.Rows[i]["SubjectId"].ToString();
                _aclLevel = dtAgentsAcl.Rows[i]["AclLevel"].ToString();
                SetAclNode(_subId, Convert.ToInt32(_aclLevel));
            }
        }

        private void FillObjectsTreeViewData()
        {
            int _rows = dtObjectsAcl.Rows.Count;
            string _subId, _aclLevel;
            for (int i = 0; i < _rows; i++)
            {
                _subId = dtObjectsAcl.Rows[i]["SubjectId"].ToString();
                _aclLevel = dtObjectsAcl.Rows[i]["AclLevel"].ToString();
                SetAclNode(_subId, Convert.ToInt32(_aclLevel));
            }
        }

        private void SetAclNode(string SubId, int Acl)
        {
            switch (SubId)
            {
                case "1":
                    {
                        trvAgents.Nodes["Node6"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }
                case "2":
                    {
                        trvAgents.Nodes["Node6"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }
                case "3":
                    {
                        trvAgents.Nodes["Node5"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }
                case "5":
                    {
                        trvAgents.Nodes["Node1"].Nodes[SubId].Nodes[Acl-1].Checked = true;
                        break;
                    }
                case "6":
                    {
                        trvAgents.Nodes["Node1"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }
                case "7":
                    {
                        trvAgents.Nodes["Node1"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }
                case "8":
                    {
                        trvAgents.Nodes["Node1"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }
                case "9":
                    {
                        trvAgents.Nodes["Node5"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }
                case "10":
                    {
                        trvAgents.Nodes["Node5"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }
                case "11":
                    {
                        trvAgents.Nodes["Node4"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }
                case "12":
                    {
                        trvAgents.Nodes["Node5"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }
                case "13":
                    {
                        trvAgents.Nodes["Node4"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }
                case "14":
                    {
                        trvAgents.Nodes["Node5"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }
                case "15":
                    {
                        trvAgents.Nodes["Node6"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }
                case "16":
                    {
                        trvAgents.Nodes["Node6"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }
                case "17":
                    {
                        trvAgents.Nodes["Node6"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }
                case "19":
                    {
                        trvAgents.Nodes["Node2"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }
                case "21":
                    {
                        trvAgents.Nodes["Node3"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }
                case "22":
                    {
                        trvAgents.Nodes["Node3"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }
                case "23":
                    {
                        trvAgents.Nodes["Node3"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }
                case "24":
                    {
                        trvAgents.Nodes["Node6"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "42":
                    {
                        trvAgents.Nodes["Node7"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }
                case "43":
                    {
                        trvAgents.Nodes["Node8"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "46":
                    {
                        trvObjects.Nodes["Node1"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "47":
                    {
                        trvObjects.Nodes["Node1"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "48":
                    {
                        trvObjects.Nodes["Node2"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "49":
                    {
                        trvObjects.Nodes["Node2"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "50":
                    {
                        trvObjects.Nodes["Node3"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "51":
                    {
                        trvObjects.Nodes["Node3"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "52":
                    {
                        trvObjects.Nodes["Node3"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "53":
                    {
                        trvObjects.Nodes["Node3"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "54":
                    {
                        trvObjects.Nodes["Node3"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "55":
                    {
                        trvObjects.Nodes["Node4"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "56":
                    {
                        trvObjects.Nodes["Node4"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "57":
                    {
                        trvObjects.Nodes["Node5"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "58":
                    {
                        trvObjects.Nodes["Node5"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "59":
                    {
                        trvObjects.Nodes["Node5"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "60":
                    {
                        trvObjects.Nodes["Node6"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "61":
                    {
                        trvObjects.Nodes["Node6"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "62":
                    {
                        trvObjects.Nodes["Node6"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "63":
                    {
                        trvObjects.Nodes["Node6"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "64":
                    {
                        trvObjects.Nodes["Node6"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "65":
                    {
                        trvObjects.Nodes["Node6"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "66":
                    {
                        trvObjects.Nodes["Node7"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "67":
                    {
                        trvObjects.Nodes["Node7"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "68":
                    {
                        trvObjects.Nodes["Node7"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "69":
                    {
                        trvObjects.Nodes["Node7"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "70":
                    {
                        trvObjects.Nodes["Node8"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "71":
                    {
                        trvObjects.Nodes["Node8"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "72":
                    {
                        trvObjects.Nodes["Node8"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }

                case "73":
                    {
                        trvObjects.Nodes["Node8"].Nodes[SubId].Nodes[Acl - 1].Checked = true;
                        break;
                    }
            }
        }                 

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            this.Focus();
            if (rbtSelectProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                UpdateProfile();
                ShowSaveMessage();
            }
            if (rbtNewProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                SaveNewProfile();
                ShowSaveMessage();
            }
            if (rbtCopyProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                UpdateProfile();
                ShowSaveMessage();
            }
        }

        private void UpdateProfile()
        {
           UpdateAcl(trvAgents);
           UpdateAcl(trvObjects);
        }

        private void UpdateAcl(RadTreeView Rgv)
        {
            string _SubjectId = "";
            string _AclId = "";
            int res, _childCount, _levCount;
            int _rootCount = Rgv.Nodes.Count;
            for (int i = 0; i < _rootCount; i++)
            {
                _childCount = Rgv.Nodes[i].Nodes.Count;
                for (int m = 0; m < _childCount; m++)
                {
                    _SubjectId = Rgv.Nodes[i].Nodes[m].Name;
                    _levCount = Rgv.Nodes[i].Nodes[m].Nodes.Count;
                    for (int n = 0; n < _levCount; n++)
                    {
                        if (Rgv.Nodes[i].Nodes[m].Nodes[n].Checked == true)
                        {
                            _AclId = Convert.ToString(n+1);
                            res = lg.UpdateAclProfile(_SelectedProfileId, _SubjectId, _AclId);
                            if (res == 0)
                            {
                                _SqlError = true;
                                break;
                            }
                        }                        
                    }
                    if (_SqlError == true)
                    {
                        break;
                    }                    
                }
                if (_SqlError == true)
                {
                    break;
                }
            }        
        }

        private void ShowSaveMessage()
        {
            if (_SqlError == false)
            {
                string mes = lg.GetMessageFromDll(_langCode, "SaveRecordSucsses");
                frmShowInfoSmall_RtoL frmsh = new frmShowInfoSmall_RtoL(mes, 2);
                frmsh.ShowDialog();
            }
            else
            {
                string mes = lg.GetErrorMessage(19);
                frmShowInfoSmall_RtoL frmsh = new frmShowInfoSmall_RtoL(mes, 2);
                frmsh.ShowDialog();
            }
        }

        private void SaveNewProfile()
        {
            if (txbProfileName.Text != "")
            {
                string _lastProfileId = lg.GetLastAclProfileId();
                _SelectedProfileId = _lastProfileId;
                int res = lg.InsertAclProfile(_SelectedProfileId, txbProfileName.Text.Trim());
                if (res == 1)
                {
                    _SqlError = false;
                    SaveNewDetailsAclProfile();
                }
                else
                {
                    _SqlError = true;
                }
            }
            else
            {
                errorProvider1.SetError(txbProfileName, "Not");
                txbProfileName.Focus();
            }
        }

        private void SaveNewDetailsAclProfile()
        {
            InsertAcl(trvAgents, "1");
            InsertAcl(trvObjects , "2");
        }

        private void InsertAcl(RadTreeView Rgv, string _SGroup)
        {
            string _SubjectId = "";
            string _AclId = "";
            int res, _childCount, _levCount;
            string _SubjectGroup = _SGroup;
            int _rootCount = Rgv.Nodes.Count;
            for (int i = 0; i < _rootCount; i++)
            {
                _childCount = Rgv.Nodes[i].Nodes.Count;
                for (int m = 0; m < _childCount; m++)
                {
                    _SubjectId = Rgv.Nodes[i].Nodes[m].Name;
                    _levCount = Rgv.Nodes[i].Nodes[m].Nodes.Count;
                    for (int n = 0; n < _levCount; n++)
                    {
                        if (Rgv.Nodes[i].Nodes[m].Nodes[n].Checked == true)
                        {
                            _AclId = Convert.ToString(n + 1);
                            res = lg.InsertAclDetails(_SelectedProfileId, _SubjectId, _AclId, _SubjectGroup);
                            if (res == 0)
                            {
                                _SqlError = true;
                                break;
                            }
                        }
                    }
                    if (_SqlError == true)
                    {
                        break;
                    }
                }
                if (_SqlError == true)
                {
                    break;
                }
            }
        }

        private void rbtSelectProfile_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (rbtSelectProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                cmbProfileList.Enabled = true;
                rbtNewProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                txbProfileName.Enabled = false;
                rbtCopyProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                cmbProfileFrom.Enabled = false;
                cmbProfileTo.Enabled = false;
            }
        }

        private void rbtNewProfile_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (rbtNewProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                rbtSelectProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                txbProfileName.Enabled = true;
                rbtCopyProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                cmbProfileFrom.Enabled = false;
                cmbProfileTo.Enabled = false;
                cmbProfileList.Enabled = false;
            }
        }

        private void rbtCopyProfile_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (rbtCopyProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                rbtSelectProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                txbProfileName.Enabled = false;
                rbtNewProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                cmbProfileFrom.Enabled = true;
                cmbProfileTo.Enabled = true;
                cmbProfileList.Enabled = false;
            }
        }

        private void txbProfileName_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void cmbProfileFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtCopyProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                string _profileId = Program.AclProfileList[cmbProfileFrom.SelectedIndex].ProfileId;
                _SelectedProfileId = _profileId;
                SetAgentsAclTables(_SelectedProfileId);
                SetObjectsAclTables(_SelectedProfileId);
                FillAgentsTreeViewData();
                FillObjectsTreeViewData();            
            }
        }

        private void cmbProfileTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _SelectedProfileId = Program.AclProfileList[cmbProfileTo.SelectedIndex].ProfileId;
        }          
               
    }   
}
