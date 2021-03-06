using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Telerik.WinControls.UI;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.Data;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Layouts;

namespace Admin_Control_Panel.Classes
{
    public class AgentsIconVisualItem : SimpleListViewVisualItem
    {
        private LightVisualElement element1;
        private LightVisualElement _imageElementAlert;
        private StackLayoutPanel layout;

        protected override void CreateChildElements()
        {
            base.CreateChildElements();

            this.layout = new StackLayoutPanel();
            this.layout.EqualChildrenWidth = true;
            this.layout.Orientation = Orientation.Horizontal;
            this.layout.ShouldHandleMouseInput = false;
            this.layout.NotifyParentOnMouseInput = true;
            this.layout.Margin = new Padding(180, 30, 0, 0);

            _imageElementAlert = new LightVisualElement();
            _imageElementAlert.DrawText = false;
            _imageElementAlert.ImageLayout = ImageLayout.Center;
            _imageElementAlert.StretchVertically = false;
            _imageElementAlert.Margin = new Padding(10, 22, 10, 5);
            this.layout.Children.Add(_imageElementAlert);

            this.element1 = new LightVisualElement();
            element1.TextAlignment = ContentAlignment.MiddleRight;
            element1.MinSize = new Size(170, 0);
            element1.Location = new Point(25, 15);
            element1.NotifyParentOnMouseInput = true;
            element1.ShouldHandleMouseInput = false;
            this.layout.Children.Add(this.element1);

            this.Children.Add(this.layout);
        }

        protected override void SynchronizeProperties()
        {
            base.SynchronizeProperties();

            _imageElementAlert.Location = new Point(-28, 5);
            _imageElementAlert.Image = (Image)Data["AlertImageIcon"];
            this.element1.Text = "<html><span style=\"color:#45488B;font-size:9pt;font-family:Tahoma ;\">" + this.Data["Status"] + "</span>";
        }

        protected override Type ThemeEffectiveType
        {
            get
            {
                return typeof(SimpleListViewVisualItem);
            }
        }
    }
}
