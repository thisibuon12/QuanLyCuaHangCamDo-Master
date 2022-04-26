
using System.Diagnostics;
using DevExpress.XtraBars;
using System.ComponentModel;
using System.Windows.Forms;
using System;
using System.Drawing;



namespace Phan_Mem_Quan_Ly_Cam_Do.GiaoDienChinh
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class DanhSachChucNang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>

        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /// 
        [DebuggerNonUserCode()]
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
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DanhSachChucNang));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            this.rbcMain = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.img = new DevExpress.Utils.ImageCollection(this.components);
            this.bbiHangHoa = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAuthor = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCamDo = new DevExpress.XtraBars.BarButtonItem();
            this.bbiChuocDo = new DevExpress.XtraBars.BarButtonItem();
            this.lblServer = new DevExpress.XtraBars.BarStaticItem();
            this.lblDatabase = new DevExpress.XtraBars.BarStaticItem();
            this.ISystem = new DevExpress.XtraBars.BarButtonItem();
            this.IInit = new DevExpress.XtraBars.BarButtonItem();
            this.IInward = new DevExpress.XtraBars.BarButtonItem();
            this.IOutward = new DevExpress.XtraBars.BarButtonItem();
            this.ITransfer = new DevExpress.XtraBars.BarButtonItem();
            this.IAdjustment = new DevExpress.XtraBars.BarButtonItem();
            this.IInventory = new DevExpress.XtraBars.BarButtonItem();
            this.IPacket = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUserGroup = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUsers = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUpdateOnline = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUpdateOffline = new DevExpress.XtraBars.BarButtonItem();
            this.biiHelpNormal = new DevExpress.XtraBars.BarButtonItem();
            this.biiHelpVideo = new DevExpress.XtraBars.BarButtonItem();
            this.bbIThuChi = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaoLuu = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPhucHoi = new DevExpress.XtraBars.BarButtonItem();
            this.bbiQuyTienMat = new DevExpress.XtraBars.BarButtonItem();
            this.rbpChucNang = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbpgQuanLy = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpHeThong = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.rbsMain = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.tabMdi = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rbcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMdi)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcMain
            // 
            this.rbcMain.ApplicationCaption = "Phần Mềm Quản Lý Cầm Đồ";
            this.rbcMain.AutoSizeItems = true;
            this.rbcMain.ExpandCollapseItem.Id = 0;
            this.rbcMain.Images = this.img;
            this.rbcMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rbcMain.ExpandCollapseItem,
            this.bbiHangHoa,
            this.bbiAuthor,
            this.bbiCamDo,
            this.bbiChuocDo,
            this.lblServer,
            this.lblDatabase,
            this.ISystem,
            this.IInit,
            this.IInward,
            this.IOutward,
            this.ITransfer,
            this.IAdjustment,
            this.IInventory,
            this.IPacket,
            this.bbiClose,
            this.bbiUserGroup,
            this.bbiUsers,
            this.bbiUpdateOnline,
            this.bbiUpdateOffline,
            this.biiHelpNormal,
            this.biiHelpVideo,
            this.bbIThuChi,
            this.bbiSaoLuu,
            this.bbiPhucHoi,
            this.bbiQuyTienMat});
            this.rbcMain.LargeImages = this.img;
            this.rbcMain.Location = new System.Drawing.Point(0, 0);
            this.rbcMain.MaxItemId = 321;
            this.rbcMain.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            this.rbcMain.Name = "rbcMain";
            this.rbcMain.PageHeaderItemLinks.Add(this.lblServer);
            this.rbcMain.PageHeaderItemLinks.Add(this.lblDatabase);
            this.rbcMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbpChucNang});
            this.rbcMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.rbcMain.ShowCategoryInCaption = false;
            this.rbcMain.Size = new System.Drawing.Size(1016, 143);
            this.rbcMain.StatusBar = this.rbsMain;
            this.rbcMain.TransparentEditors = true;
            // 
            // img
            // 
            this.img.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("img.ImageStream")));
            this.img.Images.SetKeyName(0, "24-7.png");
            this.img.Images.SetKeyName(1, "A-baby-cot.png");
            this.img.Images.SetKeyName(2, "Account.png");
            this.img.Images.SetKeyName(3, "Add Event.png");
            this.img.Images.SetKeyName(4, "Alarm-clock.png");
            this.img.Images.SetKeyName(5, "A-rollaway-bed.png");
            this.img.Images.SetKeyName(6, "Autoship.png");
            this.img.Images.SetKeyName(7, "Baby.png");
            this.img.Images.SetKeyName(8, "Binary-tree.png");
            this.img.Images.SetKeyName(9, "Breakfast.png");
            this.img.Images.SetKeyName(10, "Business-info.png");
            this.img.Images.SetKeyName(11, "Calendar-selection-all.png");
            this.img.Images.SetKeyName(12, "Calendar-selection-day.png");
            this.img.Images.SetKeyName(13, "calendar-selection-month.png");
            this.img.Images.SetKeyName(14, "Calendar-selection-week.png");
            this.img.Images.SetKeyName(15, "Contact.png");
            this.img.Images.SetKeyName(16, "Couple.png");
            this.img.Images.SetKeyName(17, "Create-ticket.png");
            this.img.Images.SetKeyName(18, "Direct-walkway.png");
            this.img.Images.SetKeyName(19, "Distributor-report.png");
            this.img.Images.SetKeyName(20, "Download.png");
            this.img.Images.SetKeyName(21, "Drive.png");
            this.img.Images.SetKeyName(22, "Earning-statement.png");
            this.img.Images.SetKeyName(23, "Event-search.png");
            this.img.Images.SetKeyName(24, "Female-user-accept.png");
            this.img.Images.SetKeyName(25, "Female-user-add.png");
            this.img.Images.SetKeyName(26, "Female-user-edit.png");
            this.img.Images.SetKeyName(27, "Female-user-help.png");
            this.img.Images.SetKeyName(28, "Female-user-info.png");
            this.img.Images.SetKeyName(29, "Female-user-remove.png");
            this.img.Images.SetKeyName(30, "Female-user-search.png");
            this.img.Images.SetKeyName(31, "Female-user-warning.png");
            this.img.Images.SetKeyName(32, "Geology-view.png");
            this.img.Images.SetKeyName(33, "Globe-download.png");
            this.img.Images.SetKeyName(34, "Globe-warning.png");
            this.img.Images.SetKeyName(35, "Gift.png");
            this.img.Images.SetKeyName(36, "Insert-hyperlink.png");
            this.img.Images.SetKeyName(37, "Library.png");
            this.img.Images.SetKeyName(38, "Library2.png");
            this.img.Images.SetKeyName(39, "Link.png");
            this.img.Images.SetKeyName(40, "Mail-search.png");
            this.img.Images.SetKeyName(41, "Message-already-read.png");
            this.img.Images.SetKeyName(42, "My-tickets.png");
            this.img.Images.SetKeyName(43, "Order-history.png");
            this.img.Images.SetKeyName(44, "Ordering.png");
            this.img.Images.SetKeyName(45, "Packing1.png");
            this.img.Images.SetKeyName(46, "Payment-card.png");
            this.img.Images.SetKeyName(47, "Product-sale-report.png");
            this.img.Images.SetKeyName(48, "Rank History.png");
            this.img.Images.SetKeyName(49, "Reports.png");
            this.img.Images.SetKeyName(50, "Sales-by-payment-method.png");
            this.img.Images.SetKeyName(51, "Sales-report.png");
            this.img.Images.SetKeyName(52, "Search-globe.png");
            this.img.Images.SetKeyName(53, "Select-language.png");
            this.img.Images.SetKeyName(54, "Upline.png");
            this.img.Images.SetKeyName(55, "Upload.png");
            this.img.Images.SetKeyName(56, "Web-management.png");
            this.img.Images.SetKeyName(57, "Woman.png");
            this.img.Images.SetKeyName(58, "Zoom-in.png");
            this.img.Images.SetKeyName(59, "Zoom-out.png");
            // 
            // bbiHangHoa
            // 
            this.bbiHangHoa.Caption = "Hàng Hoá";
            this.bbiHangHoa.Id = 27;
            this.bbiHangHoa.ImageIndex = 47;
            this.bbiHangHoa.LargeImageIndex = 47;
            this.bbiHangHoa.Name = "bbiHangHoa";
            toolTipItem1.Text = "Quản lý hàng hoá, dịch vụ";
            superToolTip1.Items.Add(toolTipItem1);
            this.bbiHangHoa.SuperTip = superToolTip1;
            // 
            // bbiAuthor
            // 
            this.bbiAuthor.Caption = "Tác giả";
            this.bbiAuthor.Id = 38;
            this.bbiAuthor.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiAuthor.LargeGlyph")));
            this.bbiAuthor.Name = "bbiAuthor";
            // 
            // bbiCamDo
            // 
            this.bbiCamDo.Caption = "Cầm Đồ";
            this.bbiCamDo.Description = "Quản lý cầm đồ";
            this.bbiCamDo.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiCamDo.Glyph")));
            this.bbiCamDo.Hint = "Quản lý nhập kho";
            this.bbiCamDo.Id = 136;
            this.bbiCamDo.LargeImageIndex = 44;
            this.bbiCamDo.Name = "bbiCamDo";
            toolTipItem2.Text = "Quản lý nhập kho";
            superToolTip2.Items.Add(toolTipItem2);
            this.bbiCamDo.SuperTip = superToolTip2;
            this.bbiCamDo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCamDo_ItemClick);
            // 
            // bbiChuocDo
            // 
            this.bbiChuocDo.Caption = "Chuộc Đồ";
            this.bbiChuocDo.Description = "Quản lý chuộc đồ";
            this.bbiChuocDo.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiChuocDo.Glyph")));
            this.bbiChuocDo.Hint = "Quản lý xuất kho";
            this.bbiChuocDo.Id = 138;
            this.bbiChuocDo.LargeImageIndex = 43;
            this.bbiChuocDo.Name = "bbiChuocDo";
            toolTipItem3.Text = "Quản lý xuất kho\r\n";
            superToolTip3.Items.Add(toolTipItem3);
            this.bbiChuocDo.SuperTip = superToolTip3;
            this.bbiChuocDo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiChuocDo_ItemClick);
            // 
            // lblServer
            // 
            this.lblServer.Caption = "Máy Chủ: ";
            this.lblServer.Id = 227;
            this.lblServer.ImageIndex = 70;
            this.lblServer.Name = "lblServer";
            toolTipTitleItem1.Text = "Nhấn đúp chuột vào để mở phần mềm quản lý cơ sở dữ liệu";
            toolTipItem4.LeftIndent = 6;
            toolTipItem4.Text = "Chú ý: mọi thao tác trên trên phần mềm quản lý cơ sở dữ liệu đều phải sao lưu dữ " +
    "liệu trước, phòng trường hợp thao tác nhằm, hoặc lỗi do sự cố ngoài ý muốn...";
            superToolTip4.Items.Add(toolTipTitleItem1);
            superToolTip4.Items.Add(toolTipItem4);
            this.lblServer.SuperTip = superToolTip4;
            this.lblServer.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblDatabase
            // 
            this.lblDatabase.Caption = "CSDL:";
            this.lblDatabase.Id = 237;
            this.lblDatabase.ImageIndex = 72;
            this.lblDatabase.Name = "lblDatabase";
            toolTipTitleItem2.Text = "Nhấn đúp chuột vào đây để sử dụng một cơ sở dữ liệu khác.";
            toolTipItem5.LeftIndent = 6;
            toolTipItem5.Text = "Chú ý: Sau khi cấu hình thành công, khởi động lại phần mềm để nạp cấu hình mới.";
            superToolTip5.Items.Add(toolTipTitleItem2);
            superToolTip5.Items.Add(toolTipItem5);
            this.lblDatabase.SuperTip = superToolTip5;
            this.lblDatabase.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ISystem
            // 
            this.ISystem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.ISystem.Caption = "Hệ Thống";
            this.ISystem.Id = 255;
            this.ISystem.ImageIndex = 78;
            this.ISystem.LargeImageIndex = 78;
            this.ISystem.Name = "ISystem";
            this.ISystem.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // IInit
            // 
            this.IInit.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.IInit.Caption = "Nhập Số Dư Ban Đầu";
            this.IInit.Id = 256;
            this.IInit.ImageIndex = 79;
            this.IInit.LargeImageIndex = 79;
            this.IInit.Name = "IInit";
            this.IInit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // IInward
            // 
            this.IInward.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.IInward.Caption = "Nhập Kho";
            this.IInward.Id = 257;
            this.IInward.ImageIndex = 28;
            this.IInward.LargeImageIndex = 28;
            this.IInward.Name = "IInward";
            this.IInward.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // IOutward
            // 
            this.IOutward.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.IOutward.Caption = "Xuất Kho";
            this.IOutward.Id = 258;
            this.IOutward.ImageIndex = 31;
            this.IOutward.LargeImageIndex = 31;
            this.IOutward.Name = "IOutward";
            this.IOutward.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // ITransfer
            // 
            this.ITransfer.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.ITransfer.Caption = "Chuyển Kho";
            this.ITransfer.Id = 259;
            this.ITransfer.ImageIndex = 25;
            this.ITransfer.LargeImageIndex = 25;
            this.ITransfer.Name = "ITransfer";
            this.ITransfer.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // IAdjustment
            // 
            this.IAdjustment.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.IAdjustment.Caption = "Kiểm Kê";
            this.IAdjustment.Id = 260;
            this.IAdjustment.ImageIndex = 27;
            this.IAdjustment.LargeImageIndex = 27;
            this.IAdjustment.Name = "IAdjustment";
            this.IAdjustment.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // IInventory
            // 
            this.IInventory.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.IInventory.Caption = "Tồn Kho";
            this.IInventory.Id = 261;
            this.IInventory.ImageIndex = 30;
            this.IInventory.LargeImageIndex = 30;
            this.IInventory.Name = "IInventory";
            this.IInventory.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // IPacket
            // 
            this.IPacket.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.IPacket.Caption = "Đóng Gói";
            this.IPacket.Id = 264;
            this.IPacket.ImageIndex = 26;
            this.IPacket.LargeImageIndex = 26;
            this.IPacket.Name = "IPacket";
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Kết Thúc";
            this.bbiClose.Description = "Kết thúc";
            this.bbiClose.Hint = "Kết thúc";
            this.bbiClose.Id = 132;
            this.bbiClose.ImageIndex = 0;
            this.bbiClose.LargeImageIndex = 20;
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiCloseItemClick);
            // 
            // bbiUserGroup
            // 
            this.bbiUserGroup.Caption = "Vai Trò && Quyền Hạn";
            this.bbiUserGroup.Id = 295;
            this.bbiUserGroup.ImageIndex = 2;
            this.bbiUserGroup.LargeImageIndex = 2;
            this.bbiUserGroup.Name = "bbiUserGroup";
            this.bbiUserGroup.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bbiUsers
            // 
            this.bbiUsers.Caption = "Người Dùng";
            this.bbiUsers.Id = 296;
            this.bbiUsers.ImageIndex = 1;
            this.bbiUsers.LargeImageIndex = 1;
            this.bbiUsers.Name = "bbiUsers";
            this.bbiUsers.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bbiUpdateOnline
            // 
            this.bbiUpdateOnline.Caption = "Cập Nhật Trực Tuyến";
            this.bbiUpdateOnline.Id = 300;
            this.bbiUpdateOnline.ImageIndex = 86;
            this.bbiUpdateOnline.Name = "bbiUpdateOnline";
            // 
            // bbiUpdateOffline
            // 
            this.bbiUpdateOffline.Caption = "Cập Nhật Thông Thường";
            this.bbiUpdateOffline.Id = 301;
            this.bbiUpdateOffline.ImageIndex = 85;
            this.bbiUpdateOffline.Name = "bbiUpdateOffline";
            // 
            // biiHelpNormal
            // 
            this.biiHelpNormal.Caption = "Tài Liệu Hướng Dẫn";
            this.biiHelpNormal.Id = 306;
            this.biiHelpNormal.ImageIndex = 89;
            this.biiHelpNormal.LargeImageIndex = 89;
            this.biiHelpNormal.Name = "biiHelpNormal";
            // 
            // biiHelpVideo
            // 
            this.biiHelpVideo.Caption = "Video Hướng Dẫn";
            this.biiHelpVideo.Id = 307;
            this.biiHelpVideo.ImageIndex = 90;
            this.biiHelpVideo.LargeImageIndex = 90;
            this.biiHelpVideo.Name = "biiHelpVideo";
            // 
            // bbIThuChi
            // 
            this.bbIThuChi.Caption = "Thu Chi";
            this.bbIThuChi.Id = 315;
            this.bbIThuChi.ImageIndex = 33;
            this.bbIThuChi.LargeImageIndex = 48;
            this.bbIThuChi.Name = "bbIThuChi";
            this.bbIThuChi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbIThuChi_ItemClick);
            // 
            // bbiSaoLuu
            // 
            this.bbiSaoLuu.Caption = "Sao Lưu";
            this.bbiSaoLuu.Id = 316;
            this.bbiSaoLuu.LargeImageIndex = 40;
            this.bbiSaoLuu.Name = "bbiSaoLuu";
            this.bbiSaoLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSaoLuu_ItemClick);
            // 
            // bbiPhucHoi
            // 
            this.bbiPhucHoi.Caption = "Phục Hồi";
            this.bbiPhucHoi.Id = 317;
            this.bbiPhucHoi.LargeImageIndex = 41;
            this.bbiPhucHoi.Name = "bbiPhucHoi";
            this.bbiPhucHoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPhucHoi_ItemClick);
            // 
            // bbiQuyTienMat
            // 
            this.bbiQuyTienMat.Caption = "Quỹ Tiền Mặt";
            this.bbiQuyTienMat.Id = 318;
            this.bbiQuyTienMat.LargeImageIndex = 22;
            this.bbiQuyTienMat.Name = "bbiQuyTienMat";
            this.bbiQuyTienMat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiQuyTienMat_ItemClick);
            // 
            // rbpChucNang
            // 
            this.rbpChucNang.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbpgQuanLy,
            this.rbpHeThong});
            this.rbpChucNang.Name = "rbpChucNang";
            this.rbpChucNang.Text = "Chức Năng";
            // 
            // rbpgQuanLy
            // 
            this.rbpgQuanLy.ItemLinks.Add(this.bbiCamDo);
            this.rbpgQuanLy.ItemLinks.Add(this.bbiChuocDo);
            this.rbpgQuanLy.ItemLinks.Add(this.bbIThuChi);
            this.rbpgQuanLy.ItemLinks.Add(this.bbiQuyTienMat);
            this.rbpgQuanLy.Name = "rbpgQuanLy";
            this.rbpgQuanLy.ShowCaptionButton = false;
            this.rbpgQuanLy.Text = "Quản Lý";
            // 
            // rbpHeThong
            // 
            this.rbpHeThong.ItemLinks.Add(this.bbiPhucHoi);
            this.rbpHeThong.ItemLinks.Add(this.bbiSaoLuu);
            this.rbpHeThong.ItemLinks.Add(this.bbiClose);
            this.rbpHeThong.Name = "rbpHeThong";
            this.rbpHeThong.Text = "Hệ Thống";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // rbsMain
            // 
            this.rbsMain.Location = new System.Drawing.Point(0, 736);
            this.rbsMain.Name = "rbsMain";
            this.rbsMain.Ribbon = this.rbcMain;
            this.rbsMain.Size = new System.Drawing.Size(1016, 31);
            // 
            // tabMdi
            // 
            this.tabMdi.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPagesAndTabControlHeader;
            this.tabMdi.HeaderButtons = ((DevExpress.XtraTab.TabButtons)((((DevExpress.XtraTab.TabButtons.Prev | DevExpress.XtraTab.TabButtons.Next) 
            | DevExpress.XtraTab.TabButtons.Close) 
            | DevExpress.XtraTab.TabButtons.Default)));
            this.tabMdi.HeaderButtonsShowMode = DevExpress.XtraTab.TabButtonShowMode.Always;
            this.tabMdi.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.tabMdi.Images = this.img;
            this.tabMdi.MdiParent = this;
            this.tabMdi.SetNextMdiChildMode = DevExpress.XtraTabbedMdi.SetNextMdiChildMode.Windows;
            this.tabMdi.ShowHeaderFocus = DevExpress.Utils.DefaultBoolean.True;
            this.tabMdi.ShowToolTips = DevExpress.Utils.DefaultBoolean.True;
            // 
            // DanhSachChucNang
            // 
            this.ClientSize = new System.Drawing.Size(1016, 767);
            this.Controls.Add(this.rbsMain);
            this.Controls.Add(this.rbcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "DanhSachChucNang";
            this.Ribbon = this.rbcMain;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.rbsMain;
            this.Text = "Phần Mềm Quản Lý Cầm Đồ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.rbcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMdi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl rbcMain;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar rbsMain;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpChucNang;
        private DevExpress.XtraBars.BarButtonItem bbiHangHoa;
        private DevExpress.XtraBars.BarButtonItem bbiAuthor;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager tabMdi;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbpgQuanLy;
        private DevExpress.XtraBars.BarButtonItem bbiCamDo;
        private DevExpress.XtraBars.BarButtonItem bbiChuocDo;
        private DevExpress.XtraBars.BarStaticItem lblServer;

        private DevExpress.XtraBars.BarStaticItem lblDatabase;
        private DevExpress.XtraBars.BarButtonItem ISystem;
        private DevExpress.XtraBars.BarButtonItem IInit;
        private DevExpress.XtraBars.BarButtonItem IInward;
        private DevExpress.XtraBars.BarButtonItem IOutward;
        private DevExpress.XtraBars.BarButtonItem ITransfer;
        private DevExpress.XtraBars.BarButtonItem IAdjustment;
        private DevExpress.XtraBars.BarButtonItem IPacket;
        private DevExpress.XtraBars.BarButtonItem IInventory;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private BarButtonItem bbiUserGroup;
        private BarButtonItem bbiUsers;
        private BarButtonItem bbiUpdateOnline;
        private BarButtonItem bbiUpdateOffline;
        private BarButtonItem biiHelpNormal;
        private BarButtonItem biiHelpVideo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private BarButtonItem bbIThuChi;
        private BarButtonItem bbiSaoLuu;
        private BarButtonItem bbiPhucHoi;
        private BarButtonItem bbiQuyTienMat;
        private DevExpress.Utils.ImageCollection img;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbpHeThong;

        
    }
}