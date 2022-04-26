namespace quanlykho_quang_make
{
    partial class List
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(List));
            this.bm = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbiXem = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSua = new DevExpress.XtraBars.BarButtonItem();
            this.bbiXoa = new DevExpress.XtraBars.BarButtonItem();
            this.bbiXuatExcel = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDong = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.img = new DevExpress.Utils.ImageCollection(this.components);
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.dtDen = new DevExpress.XtraEditors.DateEdit();
            this.dtTu = new DevExpress.XtraEditors.DateEdit();
            this.cbChonNgay = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gcList = new DevExpress.XtraGrid.GridControl();
            this.gbList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.rptMayTinh = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.rptMayTinhPhanTram = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.bm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDen.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTu.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbChonNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptMayTinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptMayTinhPhanTram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // bm
            // 
            this.bm.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.bm.DockControls.Add(this.barDockControlTop);
            this.bm.DockControls.Add(this.barDockControlBottom);
            this.bm.DockControls.Add(this.barDockControlLeft);
            this.bm.DockControls.Add(this.barDockControlRight);
            this.bm.Form = this;
            this.bm.Images = this.img;
            this.bm.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiXem,
            this.bbiSua,
            this.bbiXoa,
            this.bbiDong,
            this.bbiXuatExcel});
            this.bm.LargeImages = this.img;
            this.bm.MainMenu = this.bar2;
            this.bm.MaxItemId = 13;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatLocation = new System.Drawing.Point(49, 160);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiXem, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSua),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiXoa),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiXuatExcel),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiDong)});
            this.bar2.OptionsBar.AllowDelete = true;
            this.bar2.OptionsBar.DrawSizeGrip = true;
            this.bar2.Text = "Main menu";
            // 
            // bbiXem
            // 
            this.bbiXem.Caption = "Xem";
            this.bbiXem.Id = 0;
            this.bbiXem.ImageIndex = 35;
            this.bbiXem.Name = "bbiXem";
            this.bbiXem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiXem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiXem_ItemClick);
            // 
            // bbiSua
            // 
            this.bbiSua.Caption = "Sửa";
            this.bbiSua.Id = 1;
            this.bbiSua.ImageIndex = 29;
            this.bbiSua.Name = "bbiSua";
            this.bbiSua.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiXoa
            // 
            this.bbiXoa.Caption = "Xóa";
            this.bbiXoa.Id = 2;
            this.bbiXoa.ImageIndex = 16;
            this.bbiXoa.Name = "bbiXoa";
            this.bbiXoa.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiXuatExcel
            // 
            this.bbiXuatExcel.Caption = "Xuất";
            this.bbiXuatExcel.Id = 12;
            this.bbiXuatExcel.ImageIndex = 54;
            this.bbiXuatExcel.Name = "bbiXuatExcel";
            this.bbiXuatExcel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiXuatExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiXuatExcel_ItemClick);
            // 
            // bbiDong
            // 
            this.bbiDong.Caption = "Đóng";
            this.bbiDong.Id = 6;
            this.bbiDong.ImageIndex = 10;
            this.bbiDong.Name = "bbiDong";
            this.bbiDong.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1102, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 416);
            this.barDockControlBottom.Size = new System.Drawing.Size(1102, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 392);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1102, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 392);
            // 
            // img
            // 
            this.img.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("img.ImageStream")));
            this.img.Images.SetKeyName(0, "abort.png");
            this.img.Images.SetKeyName(1, "about.png");
            this.img.Images.SetKeyName(2, "accept.png");
            this.img.Images.SetKeyName(3, "add.png");
            this.img.Images.SetKeyName(4, "application.png");
            this.img.Images.SetKeyName(5, "apply.png");
            this.img.Images.SetKeyName(6, "attention.png");
            this.img.Images.SetKeyName(7, "back.png");
            this.img.Images.SetKeyName(8, "cancel.png");
            this.img.Images.SetKeyName(9, "circulation.png");
            this.img.Images.SetKeyName(10, "close.png");
            this.img.Images.SetKeyName(11, "create.png");
            this.img.Images.SetKeyName(12, "cut.png");
            this.img.Images.SetKeyName(13, "danger.png");
            this.img.Images.SetKeyName(14, "delete.png");
            this.img.Images.SetKeyName(15, "down.png");
            this.img.Images.SetKeyName(16, "erase.png");
            this.img.Images.SetKeyName(17, "error.png");
            this.img.Images.SetKeyName(18, "forward.png");
            this.img.Images.SetKeyName(19, "help.png");
            this.img.Images.SetKeyName(20, "info.png");
            this.img.Images.SetKeyName(21, "information.png");
            this.img.Images.SetKeyName(22, "logout.png");
            this.img.Images.SetKeyName(23, "minus.png");
            this.img.Images.SetKeyName(24, "move.png");
            this.img.Images.SetKeyName(25, "next.png");
            this.img.Images.SetKeyName(26, "no entry.png");
            this.img.Images.SetKeyName(27, "no.png");
            this.img.Images.SetKeyName(28, "OK.png");
            this.img.Images.SetKeyName(29, "options.png");
            this.img.Images.SetKeyName(30, "plus.png");
            this.img.Images.SetKeyName(31, "previous.png");
            this.img.Images.SetKeyName(32, "problem.png");
            this.img.Images.SetKeyName(33, "question.png");
            this.img.Images.SetKeyName(34, "redo.png");
            this.img.Images.SetKeyName(35, "refresh.png");
            this.img.Images.SetKeyName(36, "remove.png");
            this.img.Images.SetKeyName(37, "renew.png");
            this.img.Images.SetKeyName(38, "repeat.png");
            this.img.Images.SetKeyName(39, "run.png");
            this.img.Images.SetKeyName(40, "save.png");
            this.img.Images.SetKeyName(41, "search.png");
            this.img.Images.SetKeyName(42, "settings.png");
            this.img.Images.SetKeyName(43, "stop.png");
            this.img.Images.SetKeyName(44, "switch.png");
            this.img.Images.SetKeyName(45, "sync.png");
            this.img.Images.SetKeyName(46, "system.png");
            this.img.Images.SetKeyName(47, "turn off.png");
            this.img.Images.SetKeyName(48, "undo.png");
            this.img.Images.SetKeyName(49, "up.png");
            this.img.Images.SetKeyName(50, "update.png");
            this.img.Images.SetKeyName(51, "view.png");
            this.img.Images.SetKeyName(52, "warning.png");
            this.img.Images.SetKeyName(53, "yes.png");
            this.img.Images.SetKeyName(54, "Excel-icon.png");
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.layoutControl2);
            this.layoutControl1.Controls.Add(this.dtDen);
            this.layoutControl1.Controls.Add(this.dtTu);
            this.layoutControl1.Controls.Add(this.cbChonNgay);
            this.layoutControl1.Controls.Add(this.gcList);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1102, 392);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Location = new System.Drawing.Point(452, 2);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(648, 20);
            this.layoutControl2.TabIndex = 8;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(648, 20);
            this.layoutControlGroup2.Text = "layoutControlGroup2";
            this.layoutControlGroup2.TextVisible = false;
            // 
            // dtDen
            // 
            this.dtDen.EditValue = null;
            this.dtDen.Location = new System.Drawing.Point(325, 2);
            this.dtDen.MenuManager = this.bm;
            this.dtDen.Name = "dtDen";
            this.dtDen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDen.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtDen.Size = new System.Drawing.Size(123, 20);
            this.dtDen.StyleController = this.layoutControl1;
            this.dtDen.TabIndex = 7;
            // 
            // dtTu
            // 
            this.dtTu.EditValue = null;
            this.dtTu.Location = new System.Drawing.Point(175, 2);
            this.dtTu.MenuManager = this.bm;
            this.dtTu.Name = "dtTu";
            this.dtTu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTu.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtTu.Size = new System.Drawing.Size(123, 20);
            this.dtTu.StyleController = this.layoutControl1;
            this.dtTu.TabIndex = 6;
            // 
            // cbChonNgay
            // 
            this.cbChonNgay.EditValue = "Tùy chọn";
            this.cbChonNgay.Location = new System.Drawing.Point(57, 2);
            this.cbChonNgay.MenuManager = this.bm;
            this.cbChonNgay.Name = "cbChonNgay";
            this.cbChonNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbChonNgay.Properties.Items.AddRange(new object[] {
            "Tùy chọn",
            "Tất cả",
            "Tháng 1",
            "Tháng 2",
            "Tháng 3",
            "Tháng 4",
            "Tháng 5",
            "Tháng 6",
            "Tháng 7",
            "Tháng 8",
            "Tháng 9",
            "Tháng 10",
            "Tháng 11",
            "Tháng 12"});
            this.cbChonNgay.Size = new System.Drawing.Size(91, 20);
            this.cbChonNgay.StyleController = this.layoutControl1;
            this.cbChonNgay.TabIndex = 5;
            this.cbChonNgay.SelectedIndexChanged += new System.EventHandler(this.cbChonNgay_SelectedIndexChanged);
            // 
            // gcList
            // 
            this.gcList.Location = new System.Drawing.Point(2, 26);
            this.gcList.MainView = this.gbList;
            this.gcList.MenuManager = this.bm;
            this.gcList.Name = "gcList";
            this.gcList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rptMayTinh,
            this.rptMayTinhPhanTram});
            this.gcList.Size = new System.Drawing.Size(1098, 364);
            this.gcList.TabIndex = 4;
            this.gcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gbList});
            // 
            // gbList
            // 
            this.gbList.GridControl = this.gcList;
            this.gbList.GroupPanelText = "Kéo cột và thả vào đây để nhóm dữ liệu";
            this.gbList.IndicatorWidth = 40;
            this.gbList.Name = "gbList";
            this.gbList.OptionsView.ShowAutoFilterRow = true;
            this.gbList.OptionsView.ShowFooter = true;
            this.gbList.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gbList_CustomDrawRowIndicator);
            // 
            // rptMayTinh
            // 
            this.rptMayTinh.AutoHeight = false;
            this.rptMayTinh.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rptMayTinh.DisplayFormat.FormatString = "{0:##,##0.###}";
            this.rptMayTinh.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.rptMayTinh.EditFormat.FormatString = "{0:##,##0.###}";
            this.rptMayTinh.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.rptMayTinh.Name = "rptMayTinh";
            // 
            // rptMayTinhPhanTram
            // 
            this.rptMayTinhPhanTram.AutoHeight = false;
            this.rptMayTinhPhanTram.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rptMayTinhPhanTram.DisplayFormat.FormatString = "{0:##,##0.###} %";
            this.rptMayTinhPhanTram.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.rptMayTinhPhanTram.EditFormat.FormatString = "{0:##,##0.###}";
            this.rptMayTinhPhanTram.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.rptMayTinhPhanTram.Name = "rptMayTinhPhanTram";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1102, 392);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcList;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1102, 368);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cbChonNgay;
            this.layoutControlItem2.CustomizationFormText = "Tùy Chọn:";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(150, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(109, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(150, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Tùy Chọn:";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(50, 13);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dtTu;
            this.layoutControlItem3.CustomizationFormText = "Từ";
            this.layoutControlItem3.Location = new System.Drawing.Point(150, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(150, 24);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(78, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(150, 24);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Từ";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(20, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.dtDen;
            this.layoutControlItem4.CustomizationFormText = "Đến";
            this.layoutControlItem4.Location = new System.Drawing.Point(300, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(150, 24);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(78, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(150, 24);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "Đến";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(20, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.layoutControl2;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(450, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(652, 24);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 416);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "List";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.bm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDen.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTu.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbChonNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptMayTinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptMayTinhPhanTram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager bm;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem bbiXem;
        private DevExpress.XtraBars.BarButtonItem bbiSua;
        private DevExpress.XtraBars.BarButtonItem bbiXoa;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gcList;
        private DevExpress.XtraGrid.Views.Grid.GridView gbList;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.BarButtonItem bbiDong;
        private DevExpress.XtraEditors.ComboBoxEdit cbChonNgay;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.DateEdit dtDen;
        private DevExpress.XtraEditors.DateEdit dtTu;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit rptMayTinh;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit rptMayTinhPhanTram;
        private DevExpress.XtraBars.BarButtonItem bbiXuatExcel;
        private DevExpress.Utils.ImageCollection img;
    }
}

