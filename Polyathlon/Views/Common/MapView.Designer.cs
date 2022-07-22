namespace Polyathlon.Views {
    partial class MapView {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraMap.VectorItemsLayer vectorItemsLayer1 = new DevExpress.XtraMap.VectorItemsLayer();
            DevExpress.XtraMap.ShapefileDataAdapter shapefileDataAdapter1 = new DevExpress.XtraMap.ShapefileDataAdapter();
            DevExpress.XtraMap.VectorItemsLayer vectorItemsLayer2 = new DevExpress.XtraMap.VectorItemsLayer();
            DevExpress.XtraMap.BubbleChartDataAdapter bubbleChartDataAdapter1 = new DevExpress.XtraMap.BubbleChartDataAdapter();
            DevExpress.XtraMap.MapItemAttributeMapping mapItemAttributeMapping1 = new DevExpress.XtraMap.MapItemAttributeMapping();
            DevExpress.XtraMap.MapItemAttributeMapping mapItemAttributeMapping2 = new DevExpress.XtraMap.MapItemAttributeMapping();
            DevExpress.XtraMap.VectorItemsLayer vectorItemsLayer3 = new DevExpress.XtraMap.VectorItemsLayer();
            DevExpress.XtraMap.MapItemStorage mapItemStorage1 = new DevExpress.XtraMap.MapItemStorage();
            this.mapControl = new DevExpress.XtraMap.MapControl();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mapControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.SuspendLayout();
            
            
            
            this.mapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            vectorItemsLayer1.Data = shapefileDataAdapter1;
            vectorItemsLayer1.EnableHighlighting = false;
            vectorItemsLayer1.EnableSelection = false;
            vectorItemsLayer1.ItemStyle.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            vectorItemsLayer1.ItemStyle.Stroke = System.Drawing.Color.White;
            vectorItemsLayer1.ItemStyle.StrokeWidth = 0;
            vectorItemsLayer1.SelectedItemStyle.Fill = System.Drawing.Color.White;
            vectorItemsLayer1.SelectedItemStyle.StrokeWidth = 0;
            vectorItemsLayer1.ShapeTitlesPattern = "";
            mapItemAttributeMapping1.Member = "City";
            mapItemAttributeMapping1.Name = "CI";
            mapItemAttributeMapping1.ValueType = DevExpress.XtraMap.FieldValueType.String;
            mapItemAttributeMapping2.Member = "TotalSales";
            mapItemAttributeMapping2.Name = "CV";
            mapItemAttributeMapping2.ValueType = DevExpress.XtraMap.FieldValueType.Decimal;
            bubbleChartDataAdapter1.AttributeMappings.Add(mapItemAttributeMapping1);
            bubbleChartDataAdapter1.AttributeMappings.Add(mapItemAttributeMapping2);
            bubbleChartDataAdapter1.Mappings.Latitude = "Latitude";
            bubbleChartDataAdapter1.Mappings.Longitude = "Longitude";
            bubbleChartDataAdapter1.Mappings.Value = "TotalSales";
            bubbleChartDataAdapter1.MarkerType = DevExpress.XtraMap.MarkerType.Circle;
            vectorItemsLayer2.Data = bubbleChartDataAdapter1;
            vectorItemsLayer2.ItemStyle.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(113)))), ((int)(((byte)(0)))));
            vectorItemsLayer2.ItemStyle.Stroke = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(96)))), ((int)(((byte)(0)))));
            vectorItemsLayer2.ItemStyle.StrokeWidth = 1;
            vectorItemsLayer2.SelectedItemStyle.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(81)))), ((int)(((byte)(165)))));
            vectorItemsLayer2.SelectedItemStyle.StrokeWidth = 0;
            vectorItemsLayer2.ToolTipPattern = "City: {CI} Total: {CV:c}";
            vectorItemsLayer3.Data = mapItemStorage1;
            this.mapControl.Layers.Add(vectorItemsLayer1);
            this.mapControl.Layers.Add(vectorItemsLayer2);
            this.mapControl.Layers.Add(vectorItemsLayer3);
            this.mapControl.Location = new System.Drawing.Point(0, 0);
            this.mapControl.Margin = new System.Windows.Forms.Padding(4);
            this.mapControl.Name = "mapControl";
            this.mapControl.Size = new System.Drawing.Size(804, 605);
            this.mapControl.TabIndex = 1;
            this.mapControl.ToolTipController = this.toolTipController1;
            this.mapControl.ZoomLevel = 4D;
            
            
            
            this.toolTipController1.AllowHtmlText = true;
            
            
            
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(Polyathlon.ViewModels.MapViewModel);
            
            
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mapControl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MapView";
            this.Size = new System.Drawing.Size(804, 605);
            ((System.ComponentModel.ISupportInitialize)(this.mapControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraMap.MapControl mapControl;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.Utils.ToolTipController toolTipController1;
    }
}
