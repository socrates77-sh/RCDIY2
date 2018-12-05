<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class myMain
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(myMain))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("节点0")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("节点1")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("节点2")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("节点8")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("节点9")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("节点10")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("节点3", New System.Windows.Forms.TreeNode() {TreeNode4, TreeNode5, TreeNode6})
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("节点11")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("节点12")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("节点6", New System.Windows.Forms.TreeNode() {TreeNode8, TreeNode9})
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("节点7")
        Me.mnuMain = New System.Windows.Forms.MenuStrip
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuFileNew = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuFileOpen = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuFileSave = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuFileSaveAs = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuWave = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuWaveFit = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuWaveZoomIn = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuWaveZoomOut = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuTool = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuToolExportS19 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuToolImportS19 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuToolImportKeyboard = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLanguage = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLangChinese = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLangEnglish = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuHelpAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tosMain = New System.Windows.Forms.ToolStrip
        Me.tolNew = New System.Windows.Forms.ToolStripButton
        Me.tolOpen = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.tolSave = New System.Windows.Forms.ToolStripButton
        Me.tolSaveAs = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.tolFit = New System.Windows.Forms.ToolStripButton
        Me.tolZoomIn = New System.Windows.Forms.ToolStripButton
        Me.tolZoomOut = New System.Windows.Forms.ToolStripButton
        Me.panWave = New System.Windows.Forms.Panel
        Me.tabSetting = New System.Windows.Forms.TabControl
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.grpRepeat = New System.Windows.Forms.GroupBox
        Me.lblRepeatModeGroupB = New System.Windows.Forms.Label
        Me.lblRepeatGroupBRange = New System.Windows.Forms.Label
        Me.lblRepeatGroupB = New System.Windows.Forms.Label
        Me.lblRepeatModeGroupA = New System.Windows.Forms.Label
        Me.txtRepeatGroupBoundry = New System.Windows.Forms.TextBox
        Me.lblRepeatGroupARange = New System.Windows.Forms.Label
        Me.lblRepeatGroupA = New System.Windows.Forms.Label
        Me.ckbRepeatModeGroup = New System.Windows.Forms.CheckBox
        Me.grpComplete = New System.Windows.Forms.GroupBox
        Me.radSameAsBoot = New System.Windows.Forms.RadioButton
        Me.radSameAsCompact = New System.Windows.Forms.RadioButton
        Me.txtRepeatBootLow = New System.Windows.Forms.TextBox
        Me.lblRepeatStopTime = New System.Windows.Forms.Label
        Me.lblRepeatBootLow = New System.Windows.Forms.Label
        Me.txtRepeatStopTime = New System.Windows.Forms.TextBox
        Me.txtRepeatBootHigh = New System.Windows.Forms.TextBox
        Me.lblRepeatBootHigh = New System.Windows.Forms.Label
        Me.ckbUser2Revert = New System.Windows.Forms.CheckBox
        Me.ckbData1Revert = New System.Windows.Forms.CheckBox
        Me.ckbData2Revert = New System.Windows.Forms.CheckBox
        Me.ckbBootCode = New System.Windows.Forms.CheckBox
        Me.grpCompact = New System.Windows.Forms.GroupBox
        Me.txtLowRepeat = New System.Windows.Forms.TextBox
        Me.lblLowRepeat = New System.Windows.Forms.Label
        Me.txtHighRepeat = New System.Windows.Forms.TextBox
        Me.lblHighRepeat = New System.Windows.Forms.Label
        Me.radHL11 = New System.Windows.Forms.RadioButton
        Me.radHL01 = New System.Windows.Forms.RadioButton
        Me.radHL0 = New System.Windows.Forms.RadioButton
        Me.radComplete = New System.Windows.Forms.RadioButton
        Me.radCompact = New System.Windows.Forms.RadioButton
        Me.grpDataFrame = New System.Windows.Forms.GroupBox
        Me.ckbRepeatDataFrame = New System.Windows.Forms.CheckBox
        Me.grpDataCode1 = New System.Windows.Forms.GroupBox
        Me.ckb1986Enable = New System.Windows.Forms.CheckBox
        Me.radL7464_Sum = New System.Windows.Forms.RadioButton
        Me.radL7464_Xor = New System.Windows.Forms.RadioButton
        Me.ckbL7464Check = New System.Windows.Forms.CheckBox
        Me.cobDataCode1Bits = New System.Windows.Forms.ComboBox
        Me.lblDataCode1Bits = New System.Windows.Forms.Label
        Me.grpUser = New System.Windows.Forms.GroupBox
        Me.ckbBitExpand = New System.Windows.Forms.CheckBox
        Me.lblPositionLo = New System.Windows.Forms.Label
        Me.cobPositionLo = New System.Windows.Forms.ComboBox
        Me.ckbRevertBitLo = New System.Windows.Forms.CheckBox
        Me.lblPositionHi = New System.Windows.Forms.Label
        Me.lblBit1Option = New System.Windows.Forms.Label
        Me.ckbBit1Option = New System.Windows.Forms.CheckBox
        Me.cobPositionHi = New System.Windows.Forms.ComboBox
        Me.ckbRevertBitHi = New System.Windows.Forms.CheckBox
        Me.cobUserBits = New System.Windows.Forms.ComboBox
        Me.lblUserBits = New System.Windows.Forms.Label
        Me.txtUserCode = New System.Windows.Forms.TextBox
        Me.lblUserCode = New System.Windows.Forms.Label
        Me.grpDataCode2 = New System.Windows.Forms.GroupBox
        Me.cobData2ChangelessBits = New System.Windows.Forms.ComboBox
        Me.lblData2ChangelessBits = New System.Windows.Forms.Label
        Me.txtData2Code = New System.Windows.Forms.TextBox
        Me.lblData2Code = New System.Windows.Forms.Label
        Me.radData2Changeless = New System.Windows.Forms.RadioButton
        Me.radChecksum = New System.Windows.Forms.RadioButton
        Me.radRevertData1 = New System.Windows.Forms.RadioButton
        Me.txtChecksum = New System.Windows.Forms.TextBox
        Me.lblChecksum = New System.Windows.Forms.Label
        Me.grpUserCode2 = New System.Windows.Forms.GroupBox
        Me.cobUserCode2Bits = New System.Windows.Forms.ComboBox
        Me.lblUserCode2Bits = New System.Windows.Forms.Label
        Me.txtUserCode2 = New System.Windows.Forms.TextBox
        Me.lblUserCode2 = New System.Windows.Forms.Label
        Me.grpStopCode = New System.Windows.Forms.GroupBox
        Me.radDefineWholeFrame = New System.Windows.Forms.RadioButton
        Me.radDefineStopTime = New System.Windows.Forms.RadioButton
        Me.lblStopTime = New System.Windows.Forms.Label
        Me.txtStopTime = New System.Windows.Forms.TextBox
        Me.grpStopBit = New System.Windows.Forms.GroupBox
        Me.txtStopBitSecond = New System.Windows.Forms.TextBox
        Me.lblStopBitSecond = New System.Windows.Forms.Label
        Me.radLtoH_Stop = New System.Windows.Forms.RadioButton
        Me.radHtoL_Stop = New System.Windows.Forms.RadioButton
        Me.txtStopBitFirst = New System.Windows.Forms.TextBox
        Me.lblStopBitFirst = New System.Windows.Forms.Label
        Me.grpSplit = New System.Windows.Forms.GroupBox
        Me.txtSplitLow = New System.Windows.Forms.TextBox
        Me.lblSplitLow = New System.Windows.Forms.Label
        Me.txtSplitHigh = New System.Windows.Forms.TextBox
        Me.lblSplitHigh = New System.Windows.Forms.Label
        Me.grpBoot = New System.Windows.Forms.GroupBox
        Me.txtBootLow = New System.Windows.Forms.TextBox
        Me.lblBootLow = New System.Windows.Forms.Label
        Me.txtBootHigh = New System.Windows.Forms.TextBox
        Me.lblBootHigh = New System.Windows.Forms.Label
        Me.grpGlobal = New System.Windows.Forms.GroupBox
        Me.grpOthers = New System.Windows.Forms.GroupBox
        Me.lblPURes = New System.Windows.Forms.Label
        Me.rad150K = New System.Windows.Forms.RadioButton
        Me.rad60K = New System.Windows.Forms.RadioButton
        Me.ckbDoubleFrame = New System.Windows.Forms.CheckBox
        Me.grpKey = New System.Windows.Forms.GroupBox
        Me.ckbCountLimit = New System.Windows.Forms.CheckBox
        Me.ckbVDDKeyScan = New System.Windows.Forms.CheckBox
        Me.txtUpKey = New System.Windows.Forms.TextBox
        Me.ckbUpKeyEnable = New System.Windows.Forms.CheckBox
        Me.txtDebounce = New System.Windows.Forms.TextBox
        Me.txtInvalidKey = New System.Windows.Forms.TextBox
        Me.lblInvalidKey = New System.Windows.Forms.Label
        Me.cobScanInterval = New System.Windows.Forms.ComboBox
        Me.lblScanInterval = New System.Windows.Forms.Label
        Me.radScanCont = New System.Windows.Forms.RadioButton
        Me.lblDebounce = New System.Windows.Forms.Label
        Me.txtKeyRemain = New System.Windows.Forms.TextBox
        Me.lblKeyRemain = New System.Windows.Forms.Label
        Me.radScanOneTime = New System.Windows.Forms.RadioButton
        Me.grpIROUT = New System.Windows.Forms.GroupBox
        Me.cobIRCurrent = New System.Windows.Forms.ComboBox
        Me.lblIRCurrent = New System.Windows.Forms.Label
        Me.grpLED = New System.Windows.Forms.GroupBox
        Me.radLEDLo = New System.Windows.Forms.RadioButton
        Me.radLEDHi = New System.Windows.Forms.RadioButton
        Me.ckbLED = New System.Windows.Forms.CheckBox
        Me.cobLEDCurrent = New System.Windows.Forms.ComboBox
        Me.lblLEDCurrent = New System.Windows.Forms.Label
        Me.grpDataDir = New System.Windows.Forms.GroupBox
        Me.radHighBitFirst = New System.Windows.Forms.RadioButton
        Me.radLowBitFirst = New System.Windows.Forms.RadioButton
        Me.grpCarrier = New System.Windows.Forms.GroupBox
        Me.cobDuty = New System.Windows.Forms.ComboBox
        Me.lblDuty = New System.Windows.Forms.Label
        Me.txtCarrierFreq = New System.Windows.Forms.TextBox
        Me.lblCarrierFreq = New System.Windows.Forms.Label
        Me.grpLogic1 = New System.Windows.Forms.GroupBox
        Me.txtSecond_L1 = New System.Windows.Forms.TextBox
        Me.lblSecond_L1 = New System.Windows.Forms.Label
        Me.txtFirst_L1 = New System.Windows.Forms.TextBox
        Me.lblFirst_L1 = New System.Windows.Forms.Label
        Me.radLtoH_L1 = New System.Windows.Forms.RadioButton
        Me.radHtoL_L1 = New System.Windows.Forms.RadioButton
        Me.grpLogic0 = New System.Windows.Forms.GroupBox
        Me.txtSecond_L0 = New System.Windows.Forms.TextBox
        Me.lblSecond_L0 = New System.Windows.Forms.Label
        Me.txtFirst_L0 = New System.Windows.Forms.TextBox
        Me.lblFirst_L0 = New System.Windows.Forms.Label
        Me.radLtoH_L0 = New System.Windows.Forms.RadioButton
        Me.radHtoL_L0 = New System.Windows.Forms.RadioButton
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.txtMultiUserCode3 = New System.Windows.Forms.TextBox
        Me.lblMultiUserCode3 = New System.Windows.Forms.Label
        Me.txtMultiUserCode2 = New System.Windows.Forms.TextBox
        Me.lblMultiUserCode2 = New System.Windows.Forms.Label
        Me.txtMultiUserCode1 = New System.Windows.Forms.TextBox
        Me.lblMultiUserCode1 = New System.Windows.Forms.Label
        Me.lblRangeKey3 = New System.Windows.Forms.Label
        Me.lblRangeIII = New System.Windows.Forms.Label
        Me.txtMultiUserBoundry2 = New System.Windows.Forms.TextBox
        Me.lblRangeKey2 = New System.Windows.Forms.Label
        Me.lblRangeII = New System.Windows.Forms.Label
        Me.txtMultiUserBoundry1 = New System.Windows.Forms.TextBox
        Me.lblRangeKey1 = New System.Windows.Forms.Label
        Me.lblRangeI = New System.Windows.Forms.Label
        Me.cobMultiUserBits = New System.Windows.Forms.ComboBox
        Me.lblMultiUserBits = New System.Windows.Forms.Label
        Me.ckbMultiUser = New System.Windows.Forms.CheckBox
        Me.btnImportKeyboard = New System.Windows.Forms.Button
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.txtInfoNote = New System.Windows.Forms.TextBox
        Me.lblInfoNote = New System.Windows.Forms.Label
        Me.txtInfoName = New System.Windows.Forms.TextBox
        Me.lblInfoName = New System.Windows.Forms.Label
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.radConn = New System.Windows.Forms.RadioButton
        Me.radNotConn = New System.Windows.Forms.RadioButton
        Me.grpIROUTStructure = New System.Windows.Forms.GroupBox
        Me.radOD = New System.Windows.Forms.RadioButton
        Me.radNotOD = New System.Windows.Forms.RadioButton
        Me.cobIRef = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cobDriveSpeed = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.radLDO15 = New System.Windows.Forms.RadioButton
        Me.radLDO17 = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.radLowSpeed = New System.Windows.Forms.RadioButton
        Me.radHighSpeed = New System.Windows.Forms.RadioButton
        Me.cobTempValue = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.grpFilterSelect = New System.Windows.Forms.GroupBox
        Me.radFilterDisable = New System.Windows.Forms.RadioButton
        Me.radFilterEnable = New System.Windows.Forms.RadioButton
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.trvFrame = New System.Windows.Forms.TreeView
        Me.tabFrame = New System.Windows.Forms.TabControl
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.hscWave = New System.Windows.Forms.HScrollBar
        Me.mnuMain.SuspendLayout()
        Me.tosMain.SuspendLayout()
        Me.tabSetting.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.grpRepeat.SuspendLayout()
        Me.grpComplete.SuspendLayout()
        Me.grpCompact.SuspendLayout()
        Me.grpDataFrame.SuspendLayout()
        Me.grpDataCode1.SuspendLayout()
        Me.grpUser.SuspendLayout()
        Me.grpDataCode2.SuspendLayout()
        Me.grpUserCode2.SuspendLayout()
        Me.grpStopCode.SuspendLayout()
        Me.grpStopBit.SuspendLayout()
        Me.grpSplit.SuspendLayout()
        Me.grpBoot.SuspendLayout()
        Me.grpGlobal.SuspendLayout()
        Me.grpOthers.SuspendLayout()
        Me.grpKey.SuspendLayout()
        Me.grpIROUT.SuspendLayout()
        Me.grpLED.SuspendLayout()
        Me.grpDataDir.SuspendLayout()
        Me.grpCarrier.SuspendLayout()
        Me.grpLogic1.SuspendLayout()
        Me.grpLogic0.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.grpIROUTStructure.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grpFilterSelect.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.tabFrame.SuspendLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuWave, Me.mnuTool, Me.mnuLanguage, Me.mnuHelp})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Size = New System.Drawing.Size(990, 25)
        Me.mnuMain.TabIndex = 0
        Me.mnuMain.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileNew, Me.mnuFileOpen, Me.ToolStripSeparator2, Me.mnuFileSave, Me.mnuFileSaveAs, Me.ToolStripSeparator1, Me.mnuFileExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(39, 21)
        Me.mnuFile.Text = "File"
        '
        'mnuFileNew
        '
        Me.mnuFileNew.Image = CType(resources.GetObject("mnuFileNew.Image"), System.Drawing.Image)
        Me.mnuFileNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuFileNew.Name = "mnuFileNew"
        Me.mnuFileNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.mnuFileNew.Size = New System.Drawing.Size(155, 22)
        Me.mnuFileNew.Text = "New"
        '
        'mnuFileOpen
        '
        Me.mnuFileOpen.Image = CType(resources.GetObject("mnuFileOpen.Image"), System.Drawing.Image)
        Me.mnuFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuFileOpen.Name = "mnuFileOpen"
        Me.mnuFileOpen.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.mnuFileOpen.Size = New System.Drawing.Size(155, 22)
        Me.mnuFileOpen.Text = "Open"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(152, 6)
        '
        'mnuFileSave
        '
        Me.mnuFileSave.Image = CType(resources.GetObject("mnuFileSave.Image"), System.Drawing.Image)
        Me.mnuFileSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuFileSave.Name = "mnuFileSave"
        Me.mnuFileSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.mnuFileSave.Size = New System.Drawing.Size(155, 22)
        Me.mnuFileSave.Text = "Save"
        '
        'mnuFileSaveAs
        '
        Me.mnuFileSaveAs.Image = CType(resources.GetObject("mnuFileSaveAs.Image"), System.Drawing.Image)
        Me.mnuFileSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuFileSaveAs.Name = "mnuFileSaveAs"
        Me.mnuFileSaveAs.Size = New System.Drawing.Size(155, 22)
        Me.mnuFileSaveAs.Text = "SaveAs"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(152, 6)
        '
        'mnuFileExit
        '
        Me.mnuFileExit.Name = "mnuFileExit"
        Me.mnuFileExit.Size = New System.Drawing.Size(155, 22)
        Me.mnuFileExit.Text = "Exit"
        '
        'mnuWave
        '
        Me.mnuWave.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuWaveFit, Me.mnuWaveZoomIn, Me.mnuWaveZoomOut})
        Me.mnuWave.Name = "mnuWave"
        Me.mnuWave.Size = New System.Drawing.Size(52, 21)
        Me.mnuWave.Text = "&Wave"
        '
        'mnuWaveFit
        '
        Me.mnuWaveFit.Name = "mnuWaveFit"
        Me.mnuWaveFit.Size = New System.Drawing.Size(131, 22)
        Me.mnuWaveFit.Text = "Fit"
        '
        'mnuWaveZoomIn
        '
        Me.mnuWaveZoomIn.Name = "mnuWaveZoomIn"
        Me.mnuWaveZoomIn.Size = New System.Drawing.Size(131, 22)
        Me.mnuWaveZoomIn.Text = "ZoomIn"
        '
        'mnuWaveZoomOut
        '
        Me.mnuWaveZoomOut.Name = "mnuWaveZoomOut"
        Me.mnuWaveZoomOut.Size = New System.Drawing.Size(131, 22)
        Me.mnuWaveZoomOut.Text = "ZoomOut"
        '
        'mnuTool
        '
        Me.mnuTool.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuToolExportS19, Me.mnuToolImportS19, Me.ToolStripSeparator5, Me.mnuToolImportKeyboard})
        Me.mnuTool.Name = "mnuTool"
        Me.mnuTool.Size = New System.Drawing.Size(46, 21)
        Me.mnuTool.Text = "Tool"
        '
        'mnuToolExportS19
        '
        Me.mnuToolExportS19.Name = "mnuToolExportS19"
        Me.mnuToolExportS19.Size = New System.Drawing.Size(177, 22)
        Me.mnuToolExportS19.Text = "Export to S19"
        '
        'mnuToolImportS19
        '
        Me.mnuToolImportS19.Name = "mnuToolImportS19"
        Me.mnuToolImportS19.Size = New System.Drawing.Size(177, 22)
        Me.mnuToolImportS19.Text = "Import From S19"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(174, 6)
        '
        'mnuToolImportKeyboard
        '
        Me.mnuToolImportKeyboard.Name = "mnuToolImportKeyboard"
        Me.mnuToolImportKeyboard.Size = New System.Drawing.Size(177, 22)
        Me.mnuToolImportKeyboard.Text = "Import Keyboard"
        '
        'mnuLanguage
        '
        Me.mnuLanguage.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLangChinese, Me.mnuLangEnglish})
        Me.mnuLanguage.Name = "mnuLanguage"
        Me.mnuLanguage.Size = New System.Drawing.Size(77, 21)
        Me.mnuLanguage.Text = "Language"
        '
        'mnuLangChinese
        '
        Me.mnuLangChinese.Checked = True
        Me.mnuLangChinese.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuLangChinese.Name = "mnuLangChinese"
        Me.mnuLangChinese.Size = New System.Drawing.Size(121, 22)
        Me.mnuLangChinese.Text = "Chinese"
        '
        'mnuLangEnglish
        '
        Me.mnuLangEnglish.Name = "mnuLangEnglish"
        Me.mnuLangEnglish.Size = New System.Drawing.Size(121, 22)
        Me.mnuLangEnglish.Text = "English"
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelpAbout})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(47, 21)
        Me.mnuHelp.Text = "Help"
        '
        'mnuHelpAbout
        '
        Me.mnuHelpAbout.Name = "mnuHelpAbout"
        Me.mnuHelpAbout.Size = New System.Drawing.Size(111, 22)
        Me.mnuHelpAbout.Text = "About"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(40, 21)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'tosMain
        '
        Me.tosMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tolNew, Me.tolOpen, Me.ToolStripSeparator3, Me.tolSave, Me.tolSaveAs, Me.ToolStripSeparator4, Me.tolFit, Me.tolZoomIn, Me.tolZoomOut})
        Me.tosMain.Location = New System.Drawing.Point(0, 25)
        Me.tosMain.Name = "tosMain"
        Me.tosMain.Size = New System.Drawing.Size(990, 25)
        Me.tosMain.TabIndex = 1
        Me.tosMain.Text = "ToolStrip1"
        '
        'tolNew
        '
        Me.tolNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tolNew.Image = CType(resources.GetObject("tolNew.Image"), System.Drawing.Image)
        Me.tolNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tolNew.Name = "tolNew"
        Me.tolNew.Size = New System.Drawing.Size(23, 22)
        '
        'tolOpen
        '
        Me.tolOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tolOpen.Image = CType(resources.GetObject("tolOpen.Image"), System.Drawing.Image)
        Me.tolOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tolOpen.Name = "tolOpen"
        Me.tolOpen.Size = New System.Drawing.Size(23, 22)
        Me.tolOpen.Text = "ToolStripButton1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tolSave
        '
        Me.tolSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tolSave.Image = CType(resources.GetObject("tolSave.Image"), System.Drawing.Image)
        Me.tolSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tolSave.Name = "tolSave"
        Me.tolSave.Size = New System.Drawing.Size(23, 22)
        Me.tolSave.Text = "ToolStripButton1"
        '
        'tolSaveAs
        '
        Me.tolSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tolSaveAs.Image = CType(resources.GetObject("tolSaveAs.Image"), System.Drawing.Image)
        Me.tolSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tolSaveAs.Name = "tolSaveAs"
        Me.tolSaveAs.Size = New System.Drawing.Size(23, 22)
        Me.tolSaveAs.Text = "ToolStripButton1"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tolFit
        '
        Me.tolFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tolFit.Image = CType(resources.GetObject("tolFit.Image"), System.Drawing.Image)
        Me.tolFit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tolFit.Name = "tolFit"
        Me.tolFit.Size = New System.Drawing.Size(23, 22)
        Me.tolFit.Text = "tolFit"
        '
        'tolZoomIn
        '
        Me.tolZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tolZoomIn.Image = CType(resources.GetObject("tolZoomIn.Image"), System.Drawing.Image)
        Me.tolZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tolZoomIn.Name = "tolZoomIn"
        Me.tolZoomIn.Size = New System.Drawing.Size(23, 22)
        Me.tolZoomIn.Text = "ToolStripButton1"
        '
        'tolZoomOut
        '
        Me.tolZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tolZoomOut.Image = CType(resources.GetObject("tolZoomOut.Image"), System.Drawing.Image)
        Me.tolZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tolZoomOut.Name = "tolZoomOut"
        Me.tolZoomOut.Size = New System.Drawing.Size(23, 22)
        Me.tolZoomOut.Text = "ToolStripButton1"
        '
        'panWave
        '
        Me.panWave.BackColor = System.Drawing.Color.Black
        Me.panWave.Location = New System.Drawing.Point(0, 50)
        Me.panWave.Name = "panWave"
        Me.panWave.Size = New System.Drawing.Size(990, 140)
        Me.panWave.TabIndex = 2
        '
        'tabSetting
        '
        Me.tabSetting.Controls.Add(Me.TabPage3)
        Me.tabSetting.Controls.Add(Me.TabPage4)
        Me.tabSetting.Controls.Add(Me.TabPage1)
        Me.tabSetting.Controls.Add(Me.TabPage5)
        Me.tabSetting.Location = New System.Drawing.Point(232, 214)
        Me.tabSetting.Name = "tabSetting"
        Me.tabSetting.SelectedIndex = 0
        Me.tabSetting.Size = New System.Drawing.Size(752, 446)
        Me.tabSetting.TabIndex = 4
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage3.Controls.Add(Me.grpRepeat)
        Me.TabPage3.Controls.Add(Me.grpDataFrame)
        Me.TabPage3.Controls.Add(Me.grpDataCode1)
        Me.TabPage3.Controls.Add(Me.grpUser)
        Me.TabPage3.Controls.Add(Me.grpDataCode2)
        Me.TabPage3.Controls.Add(Me.grpUserCode2)
        Me.TabPage3.Controls.Add(Me.grpStopCode)
        Me.TabPage3.Controls.Add(Me.grpStopBit)
        Me.TabPage3.Controls.Add(Me.grpSplit)
        Me.TabPage3.Controls.Add(Me.grpBoot)
        Me.TabPage3.Controls.Add(Me.grpGlobal)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(744, 420)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "TabPage3"
        '
        'grpRepeat
        '
        Me.grpRepeat.BackColor = System.Drawing.SystemColors.Control
        Me.grpRepeat.Controls.Add(Me.lblRepeatModeGroupB)
        Me.grpRepeat.Controls.Add(Me.lblRepeatGroupBRange)
        Me.grpRepeat.Controls.Add(Me.lblRepeatGroupB)
        Me.grpRepeat.Controls.Add(Me.lblRepeatModeGroupA)
        Me.grpRepeat.Controls.Add(Me.txtRepeatGroupBoundry)
        Me.grpRepeat.Controls.Add(Me.lblRepeatGroupARange)
        Me.grpRepeat.Controls.Add(Me.lblRepeatGroupA)
        Me.grpRepeat.Controls.Add(Me.ckbRepeatModeGroup)
        Me.grpRepeat.Controls.Add(Me.grpComplete)
        Me.grpRepeat.Controls.Add(Me.grpCompact)
        Me.grpRepeat.Controls.Add(Me.radComplete)
        Me.grpRepeat.Controls.Add(Me.radCompact)
        Me.grpRepeat.Location = New System.Drawing.Point(3, 3)
        Me.grpRepeat.Name = "grpRepeat"
        Me.grpRepeat.Size = New System.Drawing.Size(288, 412)
        Me.grpRepeat.TabIndex = 17
        Me.grpRepeat.TabStop = False
        Me.grpRepeat.Text = "grpRepeat"
        '
        'lblRepeatModeGroupB
        '
        Me.lblRepeatModeGroupB.AutoSize = True
        Me.lblRepeatModeGroupB.Location = New System.Drawing.Point(175, 388)
        Me.lblRepeatModeGroupB.Name = "lblRepeatModeGroupB"
        Me.lblRepeatModeGroupB.Size = New System.Drawing.Size(95, 12)
        Me.lblRepeatModeGroupB.TabIndex = 17
        Me.lblRepeatModeGroupB.Text = "Complete Repeat"
        '
        'lblRepeatGroupBRange
        '
        Me.lblRepeatGroupBRange.AutoSize = True
        Me.lblRepeatGroupBRange.Location = New System.Drawing.Point(99, 388)
        Me.lblRepeatGroupBRange.Name = "lblRepeatGroupBRange"
        Me.lblRepeatGroupBRange.Size = New System.Drawing.Size(59, 12)
        Me.lblRepeatGroupBRange.TabIndex = 16
        Me.lblRepeatGroupBRange.Text = "K10 - K64"
        '
        'lblRepeatGroupB
        '
        Me.lblRepeatGroupB.AutoSize = True
        Me.lblRepeatGroupB.Location = New System.Drawing.Point(40, 388)
        Me.lblRepeatGroupB.Name = "lblRepeatGroupB"
        Me.lblRepeatGroupB.Size = New System.Drawing.Size(47, 12)
        Me.lblRepeatGroupB.TabIndex = 15
        Me.lblRepeatGroupB.Text = "Group B"
        '
        'lblRepeatModeGroupA
        '
        Me.lblRepeatModeGroupA.AutoSize = True
        Me.lblRepeatModeGroupA.Location = New System.Drawing.Point(175, 370)
        Me.lblRepeatModeGroupA.Name = "lblRepeatModeGroupA"
        Me.lblRepeatModeGroupA.Size = New System.Drawing.Size(89, 12)
        Me.lblRepeatModeGroupA.TabIndex = 14
        Me.lblRepeatModeGroupA.Text = "Compact Repeat"
        '
        'txtRepeatGroupBoundry
        '
        Me.txtRepeatGroupBoundry.Location = New System.Drawing.Point(146, 366)
        Me.txtRepeatGroupBoundry.Name = "txtRepeatGroupBoundry"
        Me.txtRepeatGroupBoundry.Size = New System.Drawing.Size(23, 21)
        Me.txtRepeatGroupBoundry.TabIndex = 13
        '
        'lblRepeatGroupARange
        '
        Me.lblRepeatGroupARange.AutoSize = True
        Me.lblRepeatGroupARange.Location = New System.Drawing.Point(99, 370)
        Me.lblRepeatGroupARange.Name = "lblRepeatGroupARange"
        Me.lblRepeatGroupARange.Size = New System.Drawing.Size(47, 12)
        Me.lblRepeatGroupARange.TabIndex = 12
        Me.lblRepeatGroupARange.Text = "K00 - K"
        '
        'lblRepeatGroupA
        '
        Me.lblRepeatGroupA.AutoSize = True
        Me.lblRepeatGroupA.Location = New System.Drawing.Point(40, 370)
        Me.lblRepeatGroupA.Name = "lblRepeatGroupA"
        Me.lblRepeatGroupA.Size = New System.Drawing.Size(47, 12)
        Me.lblRepeatGroupA.TabIndex = 11
        Me.lblRepeatGroupA.Text = "Group A"
        '
        'ckbRepeatModeGroup
        '
        Me.ckbRepeatModeGroup.AutoSize = True
        Me.ckbRepeatModeGroup.Location = New System.Drawing.Point(16, 342)
        Me.ckbRepeatModeGroup.Name = "ckbRepeatModeGroup"
        Me.ckbRepeatModeGroup.Size = New System.Drawing.Size(126, 16)
        Me.ckbRepeatModeGroup.TabIndex = 10
        Me.ckbRepeatModeGroup.Text = "Repeat Mode Group"
        Me.ckbRepeatModeGroup.UseVisualStyleBackColor = True
        '
        'grpComplete
        '
        Me.grpComplete.Controls.Add(Me.radSameAsBoot)
        Me.grpComplete.Controls.Add(Me.radSameAsCompact)
        Me.grpComplete.Controls.Add(Me.txtRepeatBootLow)
        Me.grpComplete.Controls.Add(Me.lblRepeatStopTime)
        Me.grpComplete.Controls.Add(Me.lblRepeatBootLow)
        Me.grpComplete.Controls.Add(Me.txtRepeatStopTime)
        Me.grpComplete.Controls.Add(Me.txtRepeatBootHigh)
        Me.grpComplete.Controls.Add(Me.lblRepeatBootHigh)
        Me.grpComplete.Controls.Add(Me.ckbUser2Revert)
        Me.grpComplete.Controls.Add(Me.ckbData1Revert)
        Me.grpComplete.Controls.Add(Me.ckbData2Revert)
        Me.grpComplete.Controls.Add(Me.ckbBootCode)
        Me.grpComplete.Location = New System.Drawing.Point(35, 197)
        Me.grpComplete.Name = "grpComplete"
        Me.grpComplete.Size = New System.Drawing.Size(226, 140)
        Me.grpComplete.TabIndex = 7
        Me.grpComplete.TabStop = False
        '
        'radSameAsBoot
        '
        Me.radSameAsBoot.AutoSize = True
        Me.radSameAsBoot.Location = New System.Drawing.Point(34, 79)
        Me.radSameAsBoot.Name = "radSameAsBoot"
        Me.radSameAsBoot.Size = New System.Drawing.Size(149, 16)
        Me.radSameAsBoot.TabIndex = 15
        Me.radSameAsBoot.TabStop = True
        Me.radSameAsBoot.Text = "H/L Time Same as Boot"
        Me.radSameAsBoot.UseVisualStyleBackColor = True
        '
        'radSameAsCompact
        '
        Me.radSameAsCompact.AutoSize = True
        Me.radSameAsCompact.Location = New System.Drawing.Point(34, 48)
        Me.radSameAsCompact.Name = "radSameAsCompact"
        Me.radSameAsCompact.Size = New System.Drawing.Size(167, 16)
        Me.radSameAsCompact.TabIndex = 14
        Me.radSameAsCompact.TabStop = True
        Me.radSameAsCompact.Text = "H/L Time Same as Compact"
        Me.radSameAsCompact.UseVisualStyleBackColor = True
        '
        'txtRepeatBootLow
        '
        Me.txtRepeatBootLow.Location = New System.Drawing.Point(131, 74)
        Me.txtRepeatBootLow.Name = "txtRepeatBootLow"
        Me.txtRepeatBootLow.Size = New System.Drawing.Size(78, 21)
        Me.txtRepeatBootLow.TabIndex = 13
        '
        'lblRepeatStopTime
        '
        Me.lblRepeatStopTime.Location = New System.Drawing.Point(-24, 130)
        Me.lblRepeatStopTime.Name = "lblRepeatStopTime"
        Me.lblRepeatStopTime.Size = New System.Drawing.Size(138, 23)
        Me.lblRepeatStopTime.TabIndex = 9
        Me.lblRepeatStopTime.Text = "Repeat Stop Time (us)"
        Me.lblRepeatStopTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRepeatBootLow
        '
        Me.lblRepeatBootLow.Location = New System.Drawing.Point(11, 72)
        Me.lblRepeatBootLow.Name = "lblRepeatBootLow"
        Me.lblRepeatBootLow.Size = New System.Drawing.Size(110, 23)
        Me.lblRepeatBootLow.TabIndex = 12
        Me.lblRepeatBootLow.Text = "Level Low (us)"
        Me.lblRepeatBootLow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRepeatStopTime
        '
        Me.txtRepeatStopTime.Location = New System.Drawing.Point(119, 130)
        Me.txtRepeatStopTime.Name = "txtRepeatStopTime"
        Me.txtRepeatStopTime.Size = New System.Drawing.Size(101, 21)
        Me.txtRepeatStopTime.TabIndex = 8
        '
        'txtRepeatBootHigh
        '
        Me.txtRepeatBootHigh.Location = New System.Drawing.Point(132, 46)
        Me.txtRepeatBootHigh.Name = "txtRepeatBootHigh"
        Me.txtRepeatBootHigh.Size = New System.Drawing.Size(78, 21)
        Me.txtRepeatBootHigh.TabIndex = 11
        '
        'lblRepeatBootHigh
        '
        Me.lblRepeatBootHigh.Location = New System.Drawing.Point(12, 45)
        Me.lblRepeatBootHigh.Name = "lblRepeatBootHigh"
        Me.lblRepeatBootHigh.Size = New System.Drawing.Size(110, 23)
        Me.lblRepeatBootHigh.TabIndex = 10
        Me.lblRepeatBootHigh.Text = "Level High (us)"
        Me.lblRepeatBootHigh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ckbUser2Revert
        '
        Me.ckbUser2Revert.AutoSize = True
        Me.ckbUser2Revert.Location = New System.Drawing.Point(34, 64)
        Me.ckbUser2Revert.Name = "ckbUser2Revert"
        Me.ckbUser2Revert.Size = New System.Drawing.Size(132, 16)
        Me.ckbUser2Revert.TabIndex = 5
        Me.ckbUser2Revert.Text = "User Code 2 Revert"
        Me.ckbUser2Revert.UseVisualStyleBackColor = True
        Me.ckbUser2Revert.Visible = False
        '
        'ckbData1Revert
        '
        Me.ckbData1Revert.AutoSize = True
        Me.ckbData1Revert.Location = New System.Drawing.Point(34, 110)
        Me.ckbData1Revert.Name = "ckbData1Revert"
        Me.ckbData1Revert.Size = New System.Drawing.Size(132, 16)
        Me.ckbData1Revert.TabIndex = 4
        Me.ckbData1Revert.Text = "Data Code 1 Revert"
        Me.ckbData1Revert.UseVisualStyleBackColor = True
        '
        'ckbData2Revert
        '
        Me.ckbData2Revert.AutoSize = True
        Me.ckbData2Revert.Location = New System.Drawing.Point(34, 86)
        Me.ckbData2Revert.Name = "ckbData2Revert"
        Me.ckbData2Revert.Size = New System.Drawing.Size(132, 16)
        Me.ckbData2Revert.TabIndex = 3
        Me.ckbData2Revert.Text = "Data Code 2 Revert"
        Me.ckbData2Revert.UseVisualStyleBackColor = True
        Me.ckbData2Revert.Visible = False
        '
        'ckbBootCode
        '
        Me.ckbBootCode.AutoSize = True
        Me.ckbBootCode.Location = New System.Drawing.Point(34, 20)
        Me.ckbBootCode.Name = "ckbBootCode"
        Me.ckbBootCode.Size = New System.Drawing.Size(108, 16)
        Me.ckbBootCode.TabIndex = 0
        Me.ckbBootCode.Text = "With Boot Code"
        Me.ckbBootCode.UseVisualStyleBackColor = True
        '
        'grpCompact
        '
        Me.grpCompact.Controls.Add(Me.txtLowRepeat)
        Me.grpCompact.Controls.Add(Me.lblLowRepeat)
        Me.grpCompact.Controls.Add(Me.txtHighRepeat)
        Me.grpCompact.Controls.Add(Me.lblHighRepeat)
        Me.grpCompact.Controls.Add(Me.radHL11)
        Me.grpCompact.Controls.Add(Me.radHL01)
        Me.grpCompact.Controls.Add(Me.radHL0)
        Me.grpCompact.Location = New System.Drawing.Point(35, 35)
        Me.grpCompact.Name = "grpCompact"
        Me.grpCompact.Size = New System.Drawing.Size(226, 143)
        Me.grpCompact.TabIndex = 6
        Me.grpCompact.TabStop = False
        '
        'txtLowRepeat
        '
        Me.txtLowRepeat.Location = New System.Drawing.Point(127, 46)
        Me.txtLowRepeat.Name = "txtLowRepeat"
        Me.txtLowRepeat.Size = New System.Drawing.Size(78, 21)
        Me.txtLowRepeat.TabIndex = 9
        '
        'lblLowRepeat
        '
        Me.lblLowRepeat.Location = New System.Drawing.Point(7, 44)
        Me.lblLowRepeat.Name = "lblLowRepeat"
        Me.lblLowRepeat.Size = New System.Drawing.Size(110, 23)
        Me.lblLowRepeat.TabIndex = 8
        Me.lblLowRepeat.Text = "Level Low (us)"
        Me.lblLowRepeat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtHighRepeat
        '
        Me.txtHighRepeat.Location = New System.Drawing.Point(128, 22)
        Me.txtHighRepeat.Name = "txtHighRepeat"
        Me.txtHighRepeat.Size = New System.Drawing.Size(78, 21)
        Me.txtHighRepeat.TabIndex = 7
        '
        'lblHighRepeat
        '
        Me.lblHighRepeat.Location = New System.Drawing.Point(8, 21)
        Me.lblHighRepeat.Name = "lblHighRepeat"
        Me.lblHighRepeat.Size = New System.Drawing.Size(110, 23)
        Me.lblHighRepeat.TabIndex = 6
        Me.lblHighRepeat.Text = "Level High (us)"
        Me.lblHighRepeat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'radHL11
        '
        Me.radHL11.AutoSize = True
        Me.radHL11.Location = New System.Drawing.Point(24, 115)
        Me.radHL11.Name = "radHL11"
        Me.radHL11.Size = New System.Drawing.Size(113, 16)
        Me.radHL11.TabIndex = 2
        Me.radHL11.TabStop = True
        Me.radHL11.Text = "High + Low + 11"
        Me.radHL11.UseVisualStyleBackColor = True
        '
        'radHL01
        '
        Me.radHL01.AutoSize = True
        Me.radHL01.Location = New System.Drawing.Point(24, 94)
        Me.radHL01.Name = "radHL01"
        Me.radHL01.Size = New System.Drawing.Size(113, 16)
        Me.radHL01.TabIndex = 1
        Me.radHL01.TabStop = True
        Me.radHL01.Text = "High + Low + 01"
        Me.radHL01.UseVisualStyleBackColor = True
        '
        'radHL0
        '
        Me.radHL0.AutoSize = True
        Me.radHL0.Location = New System.Drawing.Point(24, 73)
        Me.radHL0.Name = "radHL0"
        Me.radHL0.Size = New System.Drawing.Size(107, 16)
        Me.radHL0.TabIndex = 0
        Me.radHL0.TabStop = True
        Me.radHL0.Text = "High + Low + 0"
        Me.radHL0.UseVisualStyleBackColor = True
        '
        'radComplete
        '
        Me.radComplete.AutoSize = True
        Me.radComplete.Location = New System.Drawing.Point(15, 183)
        Me.radComplete.Name = "radComplete"
        Me.radComplete.Size = New System.Drawing.Size(113, 16)
        Me.radComplete.TabIndex = 1
        Me.radComplete.TabStop = True
        Me.radComplete.Text = "Complete Repeat"
        Me.radComplete.UseVisualStyleBackColor = True
        '
        'radCompact
        '
        Me.radCompact.AutoSize = True
        Me.radCompact.Location = New System.Drawing.Point(15, 20)
        Me.radCompact.Name = "radCompact"
        Me.radCompact.Size = New System.Drawing.Size(107, 16)
        Me.radCompact.TabIndex = 0
        Me.radCompact.TabStop = True
        Me.radCompact.Text = "Compact Repeat"
        Me.radCompact.UseVisualStyleBackColor = True
        '
        'grpDataFrame
        '
        Me.grpDataFrame.Controls.Add(Me.ckbRepeatDataFrame)
        Me.grpDataFrame.Location = New System.Drawing.Point(5, 5)
        Me.grpDataFrame.Name = "grpDataFrame"
        Me.grpDataFrame.Size = New System.Drawing.Size(285, 93)
        Me.grpDataFrame.TabIndex = 12
        Me.grpDataFrame.TabStop = False
        Me.grpDataFrame.Text = "grpDataFrame"
        '
        'ckbRepeatDataFrame
        '
        Me.ckbRepeatDataFrame.AutoSize = True
        Me.ckbRepeatDataFrame.Location = New System.Drawing.Point(46, 38)
        Me.ckbRepeatDataFrame.Name = "ckbRepeatDataFrame"
        Me.ckbRepeatDataFrame.Size = New System.Drawing.Size(126, 16)
        Me.ckbRepeatDataFrame.TabIndex = 0
        Me.ckbRepeatDataFrame.Text = "Repeat Data Frame"
        Me.ckbRepeatDataFrame.UseVisualStyleBackColor = True
        '
        'grpDataCode1
        '
        Me.grpDataCode1.Controls.Add(Me.ckb1986Enable)
        Me.grpDataCode1.Controls.Add(Me.radL7464_Sum)
        Me.grpDataCode1.Controls.Add(Me.radL7464_Xor)
        Me.grpDataCode1.Controls.Add(Me.ckbL7464Check)
        Me.grpDataCode1.Controls.Add(Me.cobDataCode1Bits)
        Me.grpDataCode1.Controls.Add(Me.lblDataCode1Bits)
        Me.grpDataCode1.Location = New System.Drawing.Point(3, 3)
        Me.grpDataCode1.Name = "grpDataCode1"
        Me.grpDataCode1.Size = New System.Drawing.Size(288, 117)
        Me.grpDataCode1.TabIndex = 13
        Me.grpDataCode1.TabStop = False
        Me.grpDataCode1.Text = "grpDataCode1"
        '
        'ckb1986Enable
        '
        Me.ckb1986Enable.AutoSize = True
        Me.ckb1986Enable.Location = New System.Drawing.Point(19, 92)
        Me.ckb1986Enable.Name = "ckb1986Enable"
        Me.ckb1986Enable.Size = New System.Drawing.Size(90, 16)
        Me.ckb1986Enable.TabIndex = 11
        Me.ckb1986Enable.Text = "1986 Enable"
        Me.ckb1986Enable.UseVisualStyleBackColor = True
        '
        'radL7464_Sum
        '
        Me.radL7464_Sum.AutoSize = True
        Me.radL7464_Sum.Location = New System.Drawing.Point(201, 66)
        Me.radL7464_Sum.Name = "radL7464_Sum"
        Me.radL7464_Sum.Size = New System.Drawing.Size(41, 16)
        Me.radL7464_Sum.TabIndex = 10
        Me.radL7464_Sum.TabStop = True
        Me.radL7464_Sum.Text = "SUM"
        Me.radL7464_Sum.UseVisualStyleBackColor = True
        '
        'radL7464_Xor
        '
        Me.radL7464_Xor.AutoSize = True
        Me.radL7464_Xor.Location = New System.Drawing.Point(135, 65)
        Me.radL7464_Xor.Name = "radL7464_Xor"
        Me.radL7464_Xor.Size = New System.Drawing.Size(41, 16)
        Me.radL7464_Xor.TabIndex = 9
        Me.radL7464_Xor.TabStop = True
        Me.radL7464_Xor.Text = "XOR"
        Me.radL7464_Xor.UseVisualStyleBackColor = True
        '
        'ckbL7464Check
        '
        Me.ckbL7464Check.AutoSize = True
        Me.ckbL7464Check.Location = New System.Drawing.Point(19, 67)
        Me.ckbL7464Check.Name = "ckbL7464Check"
        Me.ckbL7464Check.Size = New System.Drawing.Size(90, 16)
        Me.ckbL7464Check.TabIndex = 8
        Me.ckbL7464Check.Text = "L7464 Check"
        Me.ckbL7464Check.UseVisualStyleBackColor = True
        '
        'cobDataCode1Bits
        '
        Me.cobDataCode1Bits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobDataCode1Bits.FormattingEnabled = True
        Me.cobDataCode1Bits.Location = New System.Drawing.Point(114, 32)
        Me.cobDataCode1Bits.Name = "cobDataCode1Bits"
        Me.cobDataCode1Bits.Size = New System.Drawing.Size(101, 20)
        Me.cobDataCode1Bits.TabIndex = 7
        '
        'lblDataCode1Bits
        '
        Me.lblDataCode1Bits.Location = New System.Drawing.Point(13, 34)
        Me.lblDataCode1Bits.Name = "lblDataCode1Bits"
        Me.lblDataCode1Bits.Size = New System.Drawing.Size(95, 17)
        Me.lblDataCode1Bits.TabIndex = 6
        Me.lblDataCode1Bits.Text = "Bits"
        Me.lblDataCode1Bits.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpUser
        '
        Me.grpUser.BackColor = System.Drawing.SystemColors.Control
        Me.grpUser.Controls.Add(Me.ckbBitExpand)
        Me.grpUser.Controls.Add(Me.lblPositionLo)
        Me.grpUser.Controls.Add(Me.cobPositionLo)
        Me.grpUser.Controls.Add(Me.ckbRevertBitLo)
        Me.grpUser.Controls.Add(Me.lblPositionHi)
        Me.grpUser.Controls.Add(Me.lblBit1Option)
        Me.grpUser.Controls.Add(Me.ckbBit1Option)
        Me.grpUser.Controls.Add(Me.cobPositionHi)
        Me.grpUser.Controls.Add(Me.ckbRevertBitHi)
        Me.grpUser.Controls.Add(Me.cobUserBits)
        Me.grpUser.Controls.Add(Me.lblUserBits)
        Me.grpUser.Controls.Add(Me.txtUserCode)
        Me.grpUser.Controls.Add(Me.lblUserCode)
        Me.grpUser.Location = New System.Drawing.Point(3, 3)
        Me.grpUser.Name = "grpUser"
        Me.grpUser.Size = New System.Drawing.Size(288, 317)
        Me.grpUser.TabIndex = 9
        Me.grpUser.TabStop = False
        Me.grpUser.Text = "grpUser"
        '
        'ckbBitExpand
        '
        Me.ckbBitExpand.AutoSize = True
        Me.ckbBitExpand.Location = New System.Drawing.Point(48, 184)
        Me.ckbBitExpand.Name = "ckbBitExpand"
        Me.ckbBitExpand.Size = New System.Drawing.Size(84, 16)
        Me.ckbBitExpand.TabIndex = 16
        Me.ckbBitExpand.Text = "Bit Expand"
        Me.ckbBitExpand.UseVisualStyleBackColor = True
        '
        'lblPositionLo
        '
        Me.lblPositionLo.Location = New System.Drawing.Point(47, 210)
        Me.lblPositionLo.Name = "lblPositionLo"
        Me.lblPositionLo.Size = New System.Drawing.Size(95, 17)
        Me.lblPositionLo.TabIndex = 15
        Me.lblPositionLo.Text = "Position"
        Me.lblPositionLo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cobPositionLo
        '
        Me.cobPositionLo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobPositionLo.FormattingEnabled = True
        Me.cobPositionLo.Location = New System.Drawing.Point(148, 207)
        Me.cobPositionLo.Name = "cobPositionLo"
        Me.cobPositionLo.Size = New System.Drawing.Size(100, 20)
        Me.cobPositionLo.TabIndex = 14
        '
        'ckbRevertBitLo
        '
        Me.ckbRevertBitLo.AutoSize = True
        Me.ckbRevertBitLo.Location = New System.Drawing.Point(48, 163)
        Me.ckbRevertBitLo.Name = "ckbRevertBitLo"
        Me.ckbRevertBitLo.Size = New System.Drawing.Size(198, 16)
        Me.ckbRevertBitLo.TabIndex = 13
        Me.ckbRevertBitLo.Text = "With Revert Bit (Low 16 bits)"
        Me.ckbRevertBitLo.UseVisualStyleBackColor = True
        '
        'lblPositionHi
        '
        Me.lblPositionHi.Location = New System.Drawing.Point(47, 137)
        Me.lblPositionHi.Name = "lblPositionHi"
        Me.lblPositionHi.Size = New System.Drawing.Size(95, 17)
        Me.lblPositionHi.TabIndex = 12
        Me.lblPositionHi.Text = "Position"
        Me.lblPositionHi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBit1Option
        '
        Me.lblBit1Option.AutoSize = True
        Me.lblBit1Option.Location = New System.Drawing.Point(26, 243)
        Me.lblBit1Option.Name = "lblBit1Option"
        Me.lblBit1Option.Size = New System.Drawing.Size(71, 12)
        Me.lblBit1Option.TabIndex = 11
        Me.lblBit1Option.Text = "Bit1 Option"
        '
        'ckbBit1Option
        '
        Me.ckbBit1Option.Location = New System.Drawing.Point(48, 261)
        Me.ckbBit1Option.Name = "ckbBit1Option"
        Me.ckbBit1Option.Size = New System.Drawing.Size(163, 45)
        Me.ckbBit1Option.TabIndex = 10
        Me.ckbBit1Option.Text = "C1=1, if data1<=0x3F C1=0, if data1>0x3F"
        Me.ckbBit1Option.UseVisualStyleBackColor = True
        '
        'cobPositionHi
        '
        Me.cobPositionHi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobPositionHi.FormattingEnabled = True
        Me.cobPositionHi.Location = New System.Drawing.Point(148, 134)
        Me.cobPositionHi.Name = "cobPositionHi"
        Me.cobPositionHi.Size = New System.Drawing.Size(100, 20)
        Me.cobPositionHi.TabIndex = 9
        '
        'ckbRevertBitHi
        '
        Me.ckbRevertBitHi.AutoSize = True
        Me.ckbRevertBitHi.Location = New System.Drawing.Point(48, 112)
        Me.ckbRevertBitHi.Name = "ckbRevertBitHi"
        Me.ckbRevertBitHi.Size = New System.Drawing.Size(204, 16)
        Me.ckbRevertBitHi.TabIndex = 8
        Me.ckbRevertBitHi.Text = "With Revert Bit (High 16 bits)"
        Me.ckbRevertBitHi.UseVisualStyleBackColor = True
        '
        'cobUserBits
        '
        Me.cobUserBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobUserBits.FormattingEnabled = True
        Me.cobUserBits.Location = New System.Drawing.Point(147, 71)
        Me.cobUserBits.Name = "cobUserBits"
        Me.cobUserBits.Size = New System.Drawing.Size(101, 20)
        Me.cobUserBits.TabIndex = 7
        '
        'lblUserBits
        '
        Me.lblUserBits.Location = New System.Drawing.Point(46, 73)
        Me.lblUserBits.Name = "lblUserBits"
        Me.lblUserBits.Size = New System.Drawing.Size(95, 17)
        Me.lblUserBits.TabIndex = 6
        Me.lblUserBits.Text = "Bits"
        Me.lblUserBits.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtUserCode
        '
        Me.txtUserCode.Location = New System.Drawing.Point(147, 38)
        Me.txtUserCode.MaxLength = 8
        Me.txtUserCode.Name = "txtUserCode"
        Me.txtUserCode.Size = New System.Drawing.Size(101, 21)
        Me.txtUserCode.TabIndex = 5
        '
        'lblUserCode
        '
        Me.lblUserCode.Location = New System.Drawing.Point(46, 40)
        Me.lblUserCode.Name = "lblUserCode"
        Me.lblUserCode.Size = New System.Drawing.Size(95, 17)
        Me.lblUserCode.TabIndex = 4
        Me.lblUserCode.Text = "User Code"
        Me.lblUserCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpDataCode2
        '
        Me.grpDataCode2.Controls.Add(Me.cobData2ChangelessBits)
        Me.grpDataCode2.Controls.Add(Me.lblData2ChangelessBits)
        Me.grpDataCode2.Controls.Add(Me.txtData2Code)
        Me.grpDataCode2.Controls.Add(Me.lblData2Code)
        Me.grpDataCode2.Controls.Add(Me.radData2Changeless)
        Me.grpDataCode2.Controls.Add(Me.radChecksum)
        Me.grpDataCode2.Controls.Add(Me.radRevertData1)
        Me.grpDataCode2.Controls.Add(Me.txtChecksum)
        Me.grpDataCode2.Controls.Add(Me.lblChecksum)
        Me.grpDataCode2.Location = New System.Drawing.Point(3, 3)
        Me.grpDataCode2.Name = "grpDataCode2"
        Me.grpDataCode2.Size = New System.Drawing.Size(288, 214)
        Me.grpDataCode2.TabIndex = 14
        Me.grpDataCode2.TabStop = False
        Me.grpDataCode2.Text = "grpDataCode2"
        '
        'cobData2ChangelessBits
        '
        Me.cobData2ChangelessBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobData2ChangelessBits.FormattingEnabled = True
        Me.cobData2ChangelessBits.Location = New System.Drawing.Point(132, 118)
        Me.cobData2ChangelessBits.Name = "cobData2ChangelessBits"
        Me.cobData2ChangelessBits.Size = New System.Drawing.Size(101, 20)
        Me.cobData2ChangelessBits.TabIndex = 12
        '
        'lblData2ChangelessBits
        '
        Me.lblData2ChangelessBits.Location = New System.Drawing.Point(31, 120)
        Me.lblData2ChangelessBits.Name = "lblData2ChangelessBits"
        Me.lblData2ChangelessBits.Size = New System.Drawing.Size(95, 17)
        Me.lblData2ChangelessBits.TabIndex = 11
        Me.lblData2ChangelessBits.Text = "Bits"
        Me.lblData2ChangelessBits.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtData2Code
        '
        Me.txtData2Code.Location = New System.Drawing.Point(132, 85)
        Me.txtData2Code.MaxLength = 4
        Me.txtData2Code.Name = "txtData2Code"
        Me.txtData2Code.Size = New System.Drawing.Size(101, 21)
        Me.txtData2Code.TabIndex = 10
        '
        'lblData2Code
        '
        Me.lblData2Code.Location = New System.Drawing.Point(31, 87)
        Me.lblData2Code.Name = "lblData2Code"
        Me.lblData2Code.Size = New System.Drawing.Size(95, 17)
        Me.lblData2Code.TabIndex = 9
        Me.lblData2Code.Text = "Data Code 2"
        Me.lblData2Code.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'radData2Changeless
        '
        Me.radData2Changeless.AutoSize = True
        Me.radData2Changeless.Location = New System.Drawing.Point(25, 60)
        Me.radData2Changeless.Name = "radData2Changeless"
        Me.radData2Changeless.Size = New System.Drawing.Size(113, 16)
        Me.radData2Changeless.TabIndex = 8
        Me.radData2Changeless.TabStop = True
        Me.radData2Changeless.Text = "Changeless Code"
        Me.radData2Changeless.UseVisualStyleBackColor = True
        '
        'radChecksum
        '
        Me.radChecksum.AutoSize = True
        Me.radChecksum.Location = New System.Drawing.Point(25, 149)
        Me.radChecksum.Name = "radChecksum"
        Me.radChecksum.Size = New System.Drawing.Size(107, 16)
        Me.radChecksum.TabIndex = 7
        Me.radChecksum.TabStop = True
        Me.radChecksum.Text = "8-bit Checksum"
        Me.radChecksum.UseVisualStyleBackColor = True
        '
        'radRevertData1
        '
        Me.radRevertData1.AutoSize = True
        Me.radRevertData1.Location = New System.Drawing.Point(25, 21)
        Me.radRevertData1.Name = "radRevertData1"
        Me.radRevertData1.Size = New System.Drawing.Size(101, 16)
        Me.radRevertData1.TabIndex = 6
        Me.radRevertData1.TabStop = True
        Me.radRevertData1.Text = "Revert Data 1"
        Me.radRevertData1.UseVisualStyleBackColor = True
        '
        'txtChecksum
        '
        Me.txtChecksum.Location = New System.Drawing.Point(128, 179)
        Me.txtChecksum.MaxLength = 2
        Me.txtChecksum.Name = "txtChecksum"
        Me.txtChecksum.Size = New System.Drawing.Size(101, 21)
        Me.txtChecksum.TabIndex = 5
        '
        'lblChecksum
        '
        Me.lblChecksum.Location = New System.Drawing.Point(27, 181)
        Me.lblChecksum.Name = "lblChecksum"
        Me.lblChecksum.Size = New System.Drawing.Size(95, 17)
        Me.lblChecksum.TabIndex = 4
        Me.lblChecksum.Text = "Checksum"
        Me.lblChecksum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpUserCode2
        '
        Me.grpUserCode2.Controls.Add(Me.cobUserCode2Bits)
        Me.grpUserCode2.Controls.Add(Me.lblUserCode2Bits)
        Me.grpUserCode2.Controls.Add(Me.txtUserCode2)
        Me.grpUserCode2.Controls.Add(Me.lblUserCode2)
        Me.grpUserCode2.Location = New System.Drawing.Point(3, 3)
        Me.grpUserCode2.Name = "grpUserCode2"
        Me.grpUserCode2.Size = New System.Drawing.Size(288, 111)
        Me.grpUserCode2.TabIndex = 13
        Me.grpUserCode2.TabStop = False
        Me.grpUserCode2.Text = "grpUserCode2"
        '
        'cobUserCode2Bits
        '
        Me.cobUserCode2Bits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobUserCode2Bits.FormattingEnabled = True
        Me.cobUserCode2Bits.Location = New System.Drawing.Point(128, 71)
        Me.cobUserCode2Bits.Name = "cobUserCode2Bits"
        Me.cobUserCode2Bits.Size = New System.Drawing.Size(101, 20)
        Me.cobUserCode2Bits.TabIndex = 7
        '
        'lblUserCode2Bits
        '
        Me.lblUserCode2Bits.Location = New System.Drawing.Point(27, 73)
        Me.lblUserCode2Bits.Name = "lblUserCode2Bits"
        Me.lblUserCode2Bits.Size = New System.Drawing.Size(95, 17)
        Me.lblUserCode2Bits.TabIndex = 6
        Me.lblUserCode2Bits.Text = "Bits"
        Me.lblUserCode2Bits.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtUserCode2
        '
        Me.txtUserCode2.Location = New System.Drawing.Point(128, 38)
        Me.txtUserCode2.MaxLength = 4
        Me.txtUserCode2.Name = "txtUserCode2"
        Me.txtUserCode2.Size = New System.Drawing.Size(101, 21)
        Me.txtUserCode2.TabIndex = 5
        '
        'lblUserCode2
        '
        Me.lblUserCode2.Location = New System.Drawing.Point(27, 40)
        Me.lblUserCode2.Name = "lblUserCode2"
        Me.lblUserCode2.Size = New System.Drawing.Size(95, 17)
        Me.lblUserCode2.TabIndex = 4
        Me.lblUserCode2.Text = "User Code 2"
        Me.lblUserCode2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpStopCode
        '
        Me.grpStopCode.Controls.Add(Me.radDefineWholeFrame)
        Me.grpStopCode.Controls.Add(Me.radDefineStopTime)
        Me.grpStopCode.Controls.Add(Me.lblStopTime)
        Me.grpStopCode.Controls.Add(Me.txtStopTime)
        Me.grpStopCode.Location = New System.Drawing.Point(3, 3)
        Me.grpStopCode.Name = "grpStopCode"
        Me.grpStopCode.Size = New System.Drawing.Size(288, 112)
        Me.grpStopCode.TabIndex = 16
        Me.grpStopCode.TabStop = False
        Me.grpStopCode.Text = "grpStopCode"
        '
        'radDefineWholeFrame
        '
        Me.radDefineWholeFrame.AutoSize = True
        Me.radDefineWholeFrame.Location = New System.Drawing.Point(47, 47)
        Me.radDefineWholeFrame.Name = "radDefineWholeFrame"
        Me.radDefineWholeFrame.Size = New System.Drawing.Size(161, 16)
        Me.radDefineWholeFrame.TabIndex = 8
        Me.radDefineWholeFrame.TabStop = True
        Me.radDefineWholeFrame.Text = "Define Whole Frame Time"
        Me.radDefineWholeFrame.UseVisualStyleBackColor = True
        '
        'radDefineStopTime
        '
        Me.radDefineStopTime.AutoSize = True
        Me.radDefineStopTime.Location = New System.Drawing.Point(47, 23)
        Me.radDefineStopTime.Name = "radDefineStopTime"
        Me.radDefineStopTime.Size = New System.Drawing.Size(119, 16)
        Me.radDefineStopTime.TabIndex = 7
        Me.radDefineStopTime.TabStop = True
        Me.radDefineStopTime.Text = "Define Stop Time"
        Me.radDefineStopTime.UseVisualStyleBackColor = True
        '
        'lblStopTime
        '
        Me.lblStopTime.Location = New System.Drawing.Point(38, 76)
        Me.lblStopTime.Name = "lblStopTime"
        Me.lblStopTime.Size = New System.Drawing.Size(100, 23)
        Me.lblStopTime.TabIndex = 6
        Me.lblStopTime.Text = "Stop Time (us)"
        Me.lblStopTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtStopTime
        '
        Me.txtStopTime.Location = New System.Drawing.Point(145, 77)
        Me.txtStopTime.Name = "txtStopTime"
        Me.txtStopTime.Size = New System.Drawing.Size(101, 21)
        Me.txtStopTime.TabIndex = 5
        '
        'grpStopBit
        '
        Me.grpStopBit.Controls.Add(Me.txtStopBitSecond)
        Me.grpStopBit.Controls.Add(Me.lblStopBitSecond)
        Me.grpStopBit.Controls.Add(Me.radLtoH_Stop)
        Me.grpStopBit.Controls.Add(Me.radHtoL_Stop)
        Me.grpStopBit.Controls.Add(Me.txtStopBitFirst)
        Me.grpStopBit.Controls.Add(Me.lblStopBitFirst)
        Me.grpStopBit.Location = New System.Drawing.Point(3, 3)
        Me.grpStopBit.Name = "grpStopBit"
        Me.grpStopBit.Size = New System.Drawing.Size(288, 154)
        Me.grpStopBit.TabIndex = 15
        Me.grpStopBit.TabStop = False
        Me.grpStopBit.Text = "grpStopBit"
        '
        'txtStopBitSecond
        '
        Me.txtStopBitSecond.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.txtStopBitSecond.Location = New System.Drawing.Point(128, 118)
        Me.txtStopBitSecond.Name = "txtStopBitSecond"
        Me.txtStopBitSecond.Size = New System.Drawing.Size(101, 21)
        Me.txtStopBitSecond.TabIndex = 9
        '
        'lblStopBitSecond
        '
        Me.lblStopBitSecond.Location = New System.Drawing.Point(27, 120)
        Me.lblStopBitSecond.Name = "lblStopBitSecond"
        Me.lblStopBitSecond.Size = New System.Drawing.Size(95, 17)
        Me.lblStopBitSecond.TabIndex = 8
        Me.lblStopBitSecond.Text = "Level Low(us)"
        Me.lblStopBitSecond.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'radLtoH_Stop
        '
        Me.radLtoH_Stop.AutoSize = True
        Me.radLtoH_Stop.Location = New System.Drawing.Point(82, 53)
        Me.radLtoH_Stop.Name = "radLtoH_Stop"
        Me.radLtoH_Stop.Size = New System.Drawing.Size(89, 16)
        Me.radLtoH_Stop.TabIndex = 7
        Me.radLtoH_Stop.TabStop = True
        Me.radLtoH_Stop.Text = "Low to High"
        Me.radLtoH_Stop.UseVisualStyleBackColor = True
        '
        'radHtoL_Stop
        '
        Me.radHtoL_Stop.AutoSize = True
        Me.radHtoL_Stop.Location = New System.Drawing.Point(82, 21)
        Me.radHtoL_Stop.Name = "radHtoL_Stop"
        Me.radHtoL_Stop.Size = New System.Drawing.Size(89, 16)
        Me.radHtoL_Stop.TabIndex = 6
        Me.radHtoL_Stop.TabStop = True
        Me.radHtoL_Stop.Text = "High to Low"
        Me.radHtoL_Stop.UseVisualStyleBackColor = True
        '
        'txtStopBitFirst
        '
        Me.txtStopBitFirst.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.txtStopBitFirst.Location = New System.Drawing.Point(128, 87)
        Me.txtStopBitFirst.Name = "txtStopBitFirst"
        Me.txtStopBitFirst.Size = New System.Drawing.Size(101, 21)
        Me.txtStopBitFirst.TabIndex = 5
        '
        'lblStopBitFirst
        '
        Me.lblStopBitFirst.Location = New System.Drawing.Point(27, 89)
        Me.lblStopBitFirst.Name = "lblStopBitFirst"
        Me.lblStopBitFirst.Size = New System.Drawing.Size(95, 17)
        Me.lblStopBitFirst.TabIndex = 4
        Me.lblStopBitFirst.Text = "Level High(us)"
        Me.lblStopBitFirst.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpSplit
        '
        Me.grpSplit.Controls.Add(Me.txtSplitLow)
        Me.grpSplit.Controls.Add(Me.lblSplitLow)
        Me.grpSplit.Controls.Add(Me.txtSplitHigh)
        Me.grpSplit.Controls.Add(Me.lblSplitHigh)
        Me.grpSplit.Location = New System.Drawing.Point(3, 3)
        Me.grpSplit.Name = "grpSplit"
        Me.grpSplit.Size = New System.Drawing.Size(288, 111)
        Me.grpSplit.TabIndex = 8
        Me.grpSplit.TabStop = False
        Me.grpSplit.Text = "grpSplit"
        '
        'txtSplitLow
        '
        Me.txtSplitLow.Location = New System.Drawing.Point(148, 70)
        Me.txtSplitLow.Name = "txtSplitLow"
        Me.txtSplitLow.Size = New System.Drawing.Size(101, 21)
        Me.txtSplitLow.TabIndex = 7
        '
        'lblSplitLow
        '
        Me.lblSplitLow.Location = New System.Drawing.Point(47, 73)
        Me.lblSplitLow.Name = "lblSplitLow"
        Me.lblSplitLow.Size = New System.Drawing.Size(95, 17)
        Me.lblSplitLow.TabIndex = 6
        Me.lblSplitLow.Text = "Level High(us)"
        Me.lblSplitLow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSplitHigh
        '
        Me.txtSplitHigh.Location = New System.Drawing.Point(148, 38)
        Me.txtSplitHigh.Name = "txtSplitHigh"
        Me.txtSplitHigh.Size = New System.Drawing.Size(101, 21)
        Me.txtSplitHigh.TabIndex = 5
        '
        'lblSplitHigh
        '
        Me.lblSplitHigh.Location = New System.Drawing.Point(47, 40)
        Me.lblSplitHigh.Name = "lblSplitHigh"
        Me.lblSplitHigh.Size = New System.Drawing.Size(95, 17)
        Me.lblSplitHigh.TabIndex = 4
        Me.lblSplitHigh.Text = "Level High(us)"
        Me.lblSplitHigh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpBoot
        '
        Me.grpBoot.Controls.Add(Me.txtBootLow)
        Me.grpBoot.Controls.Add(Me.lblBootLow)
        Me.grpBoot.Controls.Add(Me.txtBootHigh)
        Me.grpBoot.Controls.Add(Me.lblBootHigh)
        Me.grpBoot.Location = New System.Drawing.Point(3, 3)
        Me.grpBoot.Name = "grpBoot"
        Me.grpBoot.Size = New System.Drawing.Size(288, 111)
        Me.grpBoot.TabIndex = 1
        Me.grpBoot.TabStop = False
        Me.grpBoot.Text = "grpBoot"
        '
        'txtBootLow
        '
        Me.txtBootLow.Location = New System.Drawing.Point(148, 71)
        Me.txtBootLow.Name = "txtBootLow"
        Me.txtBootLow.Size = New System.Drawing.Size(101, 21)
        Me.txtBootLow.TabIndex = 7
        '
        'lblBootLow
        '
        Me.lblBootLow.Location = New System.Drawing.Point(47, 73)
        Me.lblBootLow.Name = "lblBootLow"
        Me.lblBootLow.Size = New System.Drawing.Size(95, 17)
        Me.lblBootLow.TabIndex = 6
        Me.lblBootLow.Text = "Level High(us)"
        Me.lblBootLow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBootHigh
        '
        Me.txtBootHigh.Location = New System.Drawing.Point(148, 38)
        Me.txtBootHigh.Name = "txtBootHigh"
        Me.txtBootHigh.Size = New System.Drawing.Size(101, 21)
        Me.txtBootHigh.TabIndex = 5
        '
        'lblBootHigh
        '
        Me.lblBootHigh.Location = New System.Drawing.Point(47, 40)
        Me.lblBootHigh.Name = "lblBootHigh"
        Me.lblBootHigh.Size = New System.Drawing.Size(95, 17)
        Me.lblBootHigh.TabIndex = 4
        Me.lblBootHigh.Text = "Level High(us)"
        Me.lblBootHigh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpGlobal
        '
        Me.grpGlobal.BackColor = System.Drawing.SystemColors.Control
        Me.grpGlobal.Controls.Add(Me.grpOthers)
        Me.grpGlobal.Controls.Add(Me.grpKey)
        Me.grpGlobal.Controls.Add(Me.grpIROUT)
        Me.grpGlobal.Controls.Add(Me.grpLED)
        Me.grpGlobal.Controls.Add(Me.grpDataDir)
        Me.grpGlobal.Controls.Add(Me.grpCarrier)
        Me.grpGlobal.Controls.Add(Me.grpLogic1)
        Me.grpGlobal.Controls.Add(Me.grpLogic0)
        Me.grpGlobal.Dock = System.Windows.Forms.DockStyle.Right
        Me.grpGlobal.Location = New System.Drawing.Point(291, 3)
        Me.grpGlobal.Name = "grpGlobal"
        Me.grpGlobal.Size = New System.Drawing.Size(448, 412)
        Me.grpGlobal.TabIndex = 0
        Me.grpGlobal.TabStop = False
        Me.grpGlobal.Text = "Global Format Option"
        '
        'grpOthers
        '
        Me.grpOthers.Controls.Add(Me.lblPURes)
        Me.grpOthers.Controls.Add(Me.rad150K)
        Me.grpOthers.Controls.Add(Me.rad60K)
        Me.grpOthers.Controls.Add(Me.ckbDoubleFrame)
        Me.grpOthers.Location = New System.Drawing.Point(6, 334)
        Me.grpOthers.Name = "grpOthers"
        Me.grpOthers.Size = New System.Drawing.Size(216, 75)
        Me.grpOthers.TabIndex = 10
        Me.grpOthers.TabStop = False
        Me.grpOthers.Text = "Others"
        '
        'lblPURes
        '
        Me.lblPURes.AutoSize = True
        Me.lblPURes.Location = New System.Drawing.Point(19, 50)
        Me.lblPURes.Name = "lblPURes"
        Me.lblPURes.Size = New System.Drawing.Size(65, 12)
        Me.lblPURes.TabIndex = 4
        Me.lblPURes.Text = "Pullup Res"
        '
        'rad150K
        '
        Me.rad150K.AutoSize = True
        Me.rad150K.Location = New System.Drawing.Point(155, 48)
        Me.rad150K.Name = "rad150K"
        Me.rad150K.Size = New System.Drawing.Size(47, 16)
        Me.rad150K.TabIndex = 3
        Me.rad150K.TabStop = True
        Me.rad150K.Text = "100K"
        Me.rad150K.UseVisualStyleBackColor = True
        '
        'rad60K
        '
        Me.rad60K.AutoSize = True
        Me.rad60K.Location = New System.Drawing.Point(108, 48)
        Me.rad60K.Name = "rad60K"
        Me.rad60K.Size = New System.Drawing.Size(41, 16)
        Me.rad60K.TabIndex = 2
        Me.rad60K.TabStop = True
        Me.rad60K.Text = "50K"
        Me.rad60K.UseVisualStyleBackColor = True
        '
        'ckbDoubleFrame
        '
        Me.ckbDoubleFrame.AutoSize = True
        Me.ckbDoubleFrame.Location = New System.Drawing.Point(21, 20)
        Me.ckbDoubleFrame.Name = "ckbDoubleFrame"
        Me.ckbDoubleFrame.Size = New System.Drawing.Size(126, 16)
        Me.ckbDoubleFrame.TabIndex = 0
        Me.ckbDoubleFrame.Text = "Double Frame Mode"
        Me.ckbDoubleFrame.UseVisualStyleBackColor = True
        '
        'grpKey
        '
        Me.grpKey.Controls.Add(Me.ckbCountLimit)
        Me.grpKey.Controls.Add(Me.ckbVDDKeyScan)
        Me.grpKey.Controls.Add(Me.txtUpKey)
        Me.grpKey.Controls.Add(Me.ckbUpKeyEnable)
        Me.grpKey.Controls.Add(Me.txtDebounce)
        Me.grpKey.Controls.Add(Me.txtInvalidKey)
        Me.grpKey.Controls.Add(Me.lblInvalidKey)
        Me.grpKey.Controls.Add(Me.cobScanInterval)
        Me.grpKey.Controls.Add(Me.lblScanInterval)
        Me.grpKey.Controls.Add(Me.radScanCont)
        Me.grpKey.Controls.Add(Me.lblDebounce)
        Me.grpKey.Controls.Add(Me.txtKeyRemain)
        Me.grpKey.Controls.Add(Me.lblKeyRemain)
        Me.grpKey.Controls.Add(Me.radScanOneTime)
        Me.grpKey.Location = New System.Drawing.Point(226, 134)
        Me.grpKey.Name = "grpKey"
        Me.grpKey.Size = New System.Drawing.Size(216, 272)
        Me.grpKey.TabIndex = 7
        Me.grpKey.TabStop = False
        Me.grpKey.Text = "Key Option"
        '
        'ckbCountLimit
        '
        Me.ckbCountLimit.AutoSize = True
        Me.ckbCountLimit.Location = New System.Drawing.Point(20, 29)
        Me.ckbCountLimit.Name = "ckbCountLimit"
        Me.ckbCountLimit.Size = New System.Drawing.Size(15, 14)
        Me.ckbCountLimit.TabIndex = 20
        Me.ckbCountLimit.UseVisualStyleBackColor = True
        '
        'ckbVDDKeyScan
        '
        Me.ckbVDDKeyScan.AutoSize = True
        Me.ckbVDDKeyScan.Location = New System.Drawing.Point(72, 232)
        Me.ckbVDDKeyScan.Name = "ckbVDDKeyScan"
        Me.ckbVDDKeyScan.Size = New System.Drawing.Size(96, 16)
        Me.ckbVDDKeyScan.TabIndex = 19
        Me.ckbVDDKeyScan.Text = "VDD Key Scan"
        Me.ckbVDDKeyScan.UseVisualStyleBackColor = True
        '
        'txtUpKey
        '
        Me.txtUpKey.AcceptsTab = True
        Me.txtUpKey.Location = New System.Drawing.Point(157, 193)
        Me.txtUpKey.MaxLength = 2
        Me.txtUpKey.Name = "txtUpKey"
        Me.txtUpKey.Size = New System.Drawing.Size(42, 21)
        Me.txtUpKey.TabIndex = 18
        '
        'ckbUpKeyEnable
        '
        Me.ckbUpKeyEnable.AutoSize = True
        Me.ckbUpKeyEnable.Location = New System.Drawing.Point(72, 198)
        Me.ckbUpKeyEnable.Name = "ckbUpKeyEnable"
        Me.ckbUpKeyEnable.Size = New System.Drawing.Size(60, 16)
        Me.ckbUpKeyEnable.TabIndex = 17
        Me.ckbUpKeyEnable.Text = "Up Key"
        Me.ckbUpKeyEnable.UseVisualStyleBackColor = True
        '
        'txtDebounce
        '
        Me.txtDebounce.Location = New System.Drawing.Point(127, 63)
        Me.txtDebounce.Name = "txtDebounce"
        Me.txtDebounce.Size = New System.Drawing.Size(69, 21)
        Me.txtDebounce.TabIndex = 16
        '
        'txtInvalidKey
        '
        Me.txtInvalidKey.Location = New System.Drawing.Point(156, 160)
        Me.txtInvalidKey.MaxLength = 2
        Me.txtInvalidKey.Name = "txtInvalidKey"
        Me.txtInvalidKey.Size = New System.Drawing.Size(42, 21)
        Me.txtInvalidKey.TabIndex = 15
        '
        'lblInvalidKey
        '
        Me.lblInvalidKey.Location = New System.Drawing.Point(12, 163)
        Me.lblInvalidKey.Name = "lblInvalidKey"
        Me.lblInvalidKey.Size = New System.Drawing.Size(142, 15)
        Me.lblInvalidKey.TabIndex = 14
        Me.lblInvalidKey.Text = "Invalid Key Code(hex)"
        Me.lblInvalidKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cobScanInterval
        '
        Me.cobScanInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobScanInterval.FormattingEnabled = True
        Me.cobScanInterval.Items.AddRange(New Object() {"1ms", "8ms", "16ms", "32ms"})
        Me.cobScanInterval.Location = New System.Drawing.Point(138, 133)
        Me.cobScanInterval.Name = "cobScanInterval"
        Me.cobScanInterval.Size = New System.Drawing.Size(62, 20)
        Me.cobScanInterval.TabIndex = 13
        '
        'lblScanInterval
        '
        Me.lblScanInterval.Location = New System.Drawing.Point(48, 134)
        Me.lblScanInterval.Name = "lblScanInterval"
        Me.lblScanInterval.Size = New System.Drawing.Size(84, 17)
        Me.lblScanInterval.TabIndex = 12
        Me.lblScanInterval.Text = "Scan Interval"
        Me.lblScanInterval.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'radScanCont
        '
        Me.radScanCont.AutoSize = True
        Me.radScanCont.Location = New System.Drawing.Point(20, 114)
        Me.radScanCont.Name = "radScanCont"
        Me.radScanCont.Size = New System.Drawing.Size(149, 16)
        Me.radScanCont.TabIndex = 11
        Me.radScanCont.TabStop = True
        Me.radScanCont.Text = "Scan Key Continuously"
        Me.radScanCont.UseVisualStyleBackColor = True
        '
        'lblDebounce
        '
        Me.lblDebounce.Location = New System.Drawing.Point(2, 64)
        Me.lblDebounce.Name = "lblDebounce"
        Me.lblDebounce.Size = New System.Drawing.Size(121, 18)
        Me.lblDebounce.TabIndex = 8
        Me.lblDebounce.Text = "Debounce Time (ms)"
        Me.lblDebounce.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtKeyRemain
        '
        Me.txtKeyRemain.Location = New System.Drawing.Point(156, 26)
        Me.txtKeyRemain.Name = "txtKeyRemain"
        Me.txtKeyRemain.Size = New System.Drawing.Size(40, 21)
        Me.txtKeyRemain.TabIndex = 7
        '
        'lblKeyRemain
        '
        Me.lblKeyRemain.Location = New System.Drawing.Point(50, 16)
        Me.lblKeyRemain.Name = "lblKeyRemain"
        Me.lblKeyRemain.Size = New System.Drawing.Size(104, 48)
        Me.lblKeyRemain.TabIndex = 6
        Me.lblKeyRemain.Text = "LIMIT Count of Frame while key pressed"
        Me.lblKeyRemain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'radScanOneTime
        '
        Me.radScanOneTime.AutoSize = True
        Me.radScanOneTime.Location = New System.Drawing.Point(20, 90)
        Me.radScanOneTime.Name = "radScanOneTime"
        Me.radScanOneTime.Size = New System.Drawing.Size(125, 16)
        Me.radScanOneTime.TabIndex = 0
        Me.radScanOneTime.TabStop = True
        Me.radScanOneTime.Text = "Scan Key One Time"
        Me.radScanOneTime.UseVisualStyleBackColor = True
        '
        'grpIROUT
        '
        Me.grpIROUT.Controls.Add(Me.cobIRCurrent)
        Me.grpIROUT.Controls.Add(Me.lblIRCurrent)
        Me.grpIROUT.Location = New System.Drawing.Point(6, 289)
        Me.grpIROUT.Name = "grpIROUT"
        Me.grpIROUT.Size = New System.Drawing.Size(216, 45)
        Me.grpIROUT.TabIndex = 9
        Me.grpIROUT.TabStop = False
        Me.grpIROUT.Text = "IROUT Driver"
        '
        'cobIRCurrent
        '
        Me.cobIRCurrent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobIRCurrent.FormattingEnabled = True
        Me.cobIRCurrent.Items.AddRange(New Object() {"125mA", "250mA", "375mA", "500mA"})
        Me.cobIRCurrent.Location = New System.Drawing.Point(128, 15)
        Me.cobIRCurrent.Name = "cobIRCurrent"
        Me.cobIRCurrent.Size = New System.Drawing.Size(68, 20)
        Me.cobIRCurrent.TabIndex = 7
        '
        'lblIRCurrent
        '
        Me.lblIRCurrent.Location = New System.Drawing.Point(33, 18)
        Me.lblIRCurrent.Name = "lblIRCurrent"
        Me.lblIRCurrent.Size = New System.Drawing.Size(89, 12)
        Me.lblIRCurrent.TabIndex = 4
        Me.lblIRCurrent.Text = "IROUT Current"
        Me.lblIRCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpLED
        '
        Me.grpLED.Controls.Add(Me.radLEDLo)
        Me.grpLED.Controls.Add(Me.radLEDHi)
        Me.grpLED.Controls.Add(Me.ckbLED)
        Me.grpLED.Controls.Add(Me.cobLEDCurrent)
        Me.grpLED.Controls.Add(Me.lblLEDCurrent)
        Me.grpLED.Location = New System.Drawing.Point(6, 227)
        Me.grpLED.Name = "grpLED"
        Me.grpLED.Size = New System.Drawing.Size(216, 63)
        Me.grpLED.TabIndex = 8
        Me.grpLED.TabStop = False
        Me.grpLED.Text = "LED Driver"
        '
        'radLEDLo
        '
        Me.radLEDLo.AutoSize = True
        Me.radLEDLo.Location = New System.Drawing.Point(112, 39)
        Me.radLEDLo.Name = "radLEDLo"
        Me.radLEDLo.Size = New System.Drawing.Size(83, 16)
        Me.radLEDLo.TabIndex = 10
        Me.radLEDLo.TabStop = True
        Me.radLEDLo.Text = "Active Low"
        Me.radLEDLo.UseVisualStyleBackColor = True
        '
        'radLEDHi
        '
        Me.radLEDHi.AutoSize = True
        Me.radLEDHi.Location = New System.Drawing.Point(19, 39)
        Me.radLEDHi.Name = "radLEDHi"
        Me.radLEDHi.Size = New System.Drawing.Size(89, 16)
        Me.radLEDHi.TabIndex = 9
        Me.radLEDHi.TabStop = True
        Me.radLEDHi.Text = "Active High"
        Me.radLEDHi.UseVisualStyleBackColor = True
        '
        'ckbLED
        '
        Me.ckbLED.AutoSize = True
        Me.ckbLED.Location = New System.Drawing.Point(19, 18)
        Me.ckbLED.Name = "ckbLED"
        Me.ckbLED.Size = New System.Drawing.Size(15, 14)
        Me.ckbLED.TabIndex = 8
        Me.ckbLED.UseVisualStyleBackColor = True
        '
        'cobLEDCurrent
        '
        Me.cobLEDCurrent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobLEDCurrent.FormattingEnabled = True
        Me.cobLEDCurrent.Items.AddRange(New Object() {"1mA", "2mA", "4mA", "8mA"})
        Me.cobLEDCurrent.Location = New System.Drawing.Point(128, 15)
        Me.cobLEDCurrent.Name = "cobLEDCurrent"
        Me.cobLEDCurrent.Size = New System.Drawing.Size(68, 20)
        Me.cobLEDCurrent.TabIndex = 7
        '
        'lblLEDCurrent
        '
        Me.lblLEDCurrent.Location = New System.Drawing.Point(49, 18)
        Me.lblLEDCurrent.Name = "lblLEDCurrent"
        Me.lblLEDCurrent.Size = New System.Drawing.Size(72, 12)
        Me.lblLEDCurrent.TabIndex = 4
        Me.lblLEDCurrent.Text = "LED Current"
        Me.lblLEDCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpDataDir
        '
        Me.grpDataDir.Controls.Add(Me.radHighBitFirst)
        Me.grpDataDir.Controls.Add(Me.radLowBitFirst)
        Me.grpDataDir.Location = New System.Drawing.Point(6, 187)
        Me.grpDataDir.Name = "grpDataDir"
        Me.grpDataDir.Size = New System.Drawing.Size(216, 40)
        Me.grpDataDir.TabIndex = 6
        Me.grpDataDir.TabStop = False
        Me.grpDataDir.Text = "Data Send Direction"
        '
        'radHighBitFirst
        '
        Me.radHighBitFirst.AutoSize = True
        Me.radHighBitFirst.Location = New System.Drawing.Point(107, 19)
        Me.radHighBitFirst.Name = "radHighBitFirst"
        Me.radHighBitFirst.Size = New System.Drawing.Size(107, 16)
        Me.radHighBitFirst.TabIndex = 1
        Me.radHighBitFirst.TabStop = True
        Me.radHighBitFirst.Text = "High bit First"
        Me.radHighBitFirst.UseVisualStyleBackColor = True
        '
        'radLowBitFirst
        '
        Me.radLowBitFirst.AutoSize = True
        Me.radLowBitFirst.Location = New System.Drawing.Point(7, 19)
        Me.radLowBitFirst.Name = "radLowBitFirst"
        Me.radLowBitFirst.Size = New System.Drawing.Size(101, 16)
        Me.radLowBitFirst.TabIndex = 0
        Me.radLowBitFirst.TabStop = True
        Me.radLowBitFirst.Text = "Low Bit First"
        Me.radLowBitFirst.UseVisualStyleBackColor = True
        '
        'grpCarrier
        '
        Me.grpCarrier.Controls.Add(Me.cobDuty)
        Me.grpCarrier.Controls.Add(Me.lblDuty)
        Me.grpCarrier.Controls.Add(Me.txtCarrierFreq)
        Me.grpCarrier.Controls.Add(Me.lblCarrierFreq)
        Me.grpCarrier.Location = New System.Drawing.Point(6, 116)
        Me.grpCarrier.Name = "grpCarrier"
        Me.grpCarrier.Size = New System.Drawing.Size(216, 69)
        Me.grpCarrier.TabIndex = 6
        Me.grpCarrier.TabStop = False
        Me.grpCarrier.Text = "Carrier Option"
        '
        'cobDuty
        '
        Me.cobDuty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobDuty.FormattingEnabled = True
        Me.cobDuty.Items.AddRange(New Object() {"1/4", "1/3", "1/2"})
        Me.cobDuty.Location = New System.Drawing.Point(142, 43)
        Me.cobDuty.Name = "cobDuty"
        Me.cobDuty.Size = New System.Drawing.Size(54, 20)
        Me.cobDuty.TabIndex = 7
        '
        'lblDuty
        '
        Me.lblDuty.Location = New System.Drawing.Point(12, 46)
        Me.lblDuty.Name = "lblDuty"
        Me.lblDuty.Size = New System.Drawing.Size(124, 12)
        Me.lblDuty.TabIndex = 4
        Me.lblDuty.Text = "Duty"
        Me.lblDuty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCarrierFreq
        '
        Me.txtCarrierFreq.Location = New System.Drawing.Point(142, 17)
        Me.txtCarrierFreq.Name = "txtCarrierFreq"
        Me.txtCarrierFreq.Size = New System.Drawing.Size(53, 21)
        Me.txtCarrierFreq.TabIndex = 3
        '
        'lblCarrierFreq
        '
        Me.lblCarrierFreq.Location = New System.Drawing.Point(11, 21)
        Me.lblCarrierFreq.Name = "lblCarrierFreq"
        Me.lblCarrierFreq.Size = New System.Drawing.Size(125, 17)
        Me.lblCarrierFreq.TabIndex = 2
        Me.lblCarrierFreq.Text = "Carrier Freq.(KHz)"
        Me.lblCarrierFreq.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpLogic1
        '
        Me.grpLogic1.Controls.Add(Me.txtSecond_L1)
        Me.grpLogic1.Controls.Add(Me.lblSecond_L1)
        Me.grpLogic1.Controls.Add(Me.txtFirst_L1)
        Me.grpLogic1.Controls.Add(Me.lblFirst_L1)
        Me.grpLogic1.Controls.Add(Me.radLtoH_L1)
        Me.grpLogic1.Controls.Add(Me.radHtoL_L1)
        Me.grpLogic1.Location = New System.Drawing.Point(226, 20)
        Me.grpLogic1.Name = "grpLogic1"
        Me.grpLogic1.Size = New System.Drawing.Size(216, 108)
        Me.grpLogic1.TabIndex = 6
        Me.grpLogic1.TabStop = False
        Me.grpLogic1.Text = "Logic 1"
        '
        'txtSecond_L1
        '
        Me.txtSecond_L1.Location = New System.Drawing.Point(113, 75)
        Me.txtSecond_L1.Name = "txtSecond_L1"
        Me.txtSecond_L1.Size = New System.Drawing.Size(83, 21)
        Me.txtSecond_L1.TabIndex = 5
        '
        'lblSecond_L1
        '
        Me.lblSecond_L1.Location = New System.Drawing.Point(12, 79)
        Me.lblSecond_L1.Name = "lblSecond_L1"
        Me.lblSecond_L1.Size = New System.Drawing.Size(95, 12)
        Me.lblSecond_L1.TabIndex = 4
        Me.lblSecond_L1.Text = "Level Low(us)"
        Me.lblSecond_L1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFirst_L1
        '
        Me.txtFirst_L1.Location = New System.Drawing.Point(112, 47)
        Me.txtFirst_L1.Name = "txtFirst_L1"
        Me.txtFirst_L1.Size = New System.Drawing.Size(83, 21)
        Me.txtFirst_L1.TabIndex = 3
        '
        'lblFirst_L1
        '
        Me.lblFirst_L1.Location = New System.Drawing.Point(11, 51)
        Me.lblFirst_L1.Name = "lblFirst_L1"
        Me.lblFirst_L1.Size = New System.Drawing.Size(95, 17)
        Me.lblFirst_L1.TabIndex = 2
        Me.lblFirst_L1.Text = "Level High(us)"
        Me.lblFirst_L1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'radLtoH_L1
        '
        Me.radLtoH_L1.AutoSize = True
        Me.radLtoH_L1.Location = New System.Drawing.Point(110, 21)
        Me.radLtoH_L1.Name = "radLtoH_L1"
        Me.radLtoH_L1.Size = New System.Drawing.Size(89, 16)
        Me.radLtoH_L1.TabIndex = 1
        Me.radLtoH_L1.TabStop = True
        Me.radLtoH_L1.Text = "Low to High"
        Me.radLtoH_L1.UseVisualStyleBackColor = True
        '
        'radHtoL_L1
        '
        Me.radHtoL_L1.AutoSize = True
        Me.radHtoL_L1.Location = New System.Drawing.Point(7, 21)
        Me.radHtoL_L1.Name = "radHtoL_L1"
        Me.radHtoL_L1.Size = New System.Drawing.Size(89, 16)
        Me.radHtoL_L1.TabIndex = 0
        Me.radHtoL_L1.TabStop = True
        Me.radHtoL_L1.Text = "High to Low"
        Me.radHtoL_L1.UseVisualStyleBackColor = True
        '
        'grpLogic0
        '
        Me.grpLogic0.Controls.Add(Me.txtSecond_L0)
        Me.grpLogic0.Controls.Add(Me.lblSecond_L0)
        Me.grpLogic0.Controls.Add(Me.txtFirst_L0)
        Me.grpLogic0.Controls.Add(Me.lblFirst_L0)
        Me.grpLogic0.Controls.Add(Me.radLtoH_L0)
        Me.grpLogic0.Controls.Add(Me.radHtoL_L0)
        Me.grpLogic0.Location = New System.Drawing.Point(6, 20)
        Me.grpLogic0.Name = "grpLogic0"
        Me.grpLogic0.Size = New System.Drawing.Size(216, 96)
        Me.grpLogic0.TabIndex = 0
        Me.grpLogic0.TabStop = False
        Me.grpLogic0.Text = "Logic 0"
        '
        'txtSecond_L0
        '
        Me.txtSecond_L0.Location = New System.Drawing.Point(113, 69)
        Me.txtSecond_L0.Name = "txtSecond_L0"
        Me.txtSecond_L0.Size = New System.Drawing.Size(83, 21)
        Me.txtSecond_L0.TabIndex = 5
        '
        'lblSecond_L0
        '
        Me.lblSecond_L0.Location = New System.Drawing.Point(12, 73)
        Me.lblSecond_L0.Name = "lblSecond_L0"
        Me.lblSecond_L0.Size = New System.Drawing.Size(95, 12)
        Me.lblSecond_L0.TabIndex = 4
        Me.lblSecond_L0.Text = "Level Low(us)"
        Me.lblSecond_L0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFirst_L0
        '
        Me.txtFirst_L0.Location = New System.Drawing.Point(112, 44)
        Me.txtFirst_L0.Name = "txtFirst_L0"
        Me.txtFirst_L0.Size = New System.Drawing.Size(83, 21)
        Me.txtFirst_L0.TabIndex = 3
        '
        'lblFirst_L0
        '
        Me.lblFirst_L0.Location = New System.Drawing.Point(11, 48)
        Me.lblFirst_L0.Name = "lblFirst_L0"
        Me.lblFirst_L0.Size = New System.Drawing.Size(95, 17)
        Me.lblFirst_L0.TabIndex = 2
        Me.lblFirst_L0.Text = "Level High(us)"
        Me.lblFirst_L0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'radLtoH_L0
        '
        Me.radLtoH_L0.AutoSize = True
        Me.radLtoH_L0.Location = New System.Drawing.Point(110, 21)
        Me.radLtoH_L0.Name = "radLtoH_L0"
        Me.radLtoH_L0.Size = New System.Drawing.Size(89, 16)
        Me.radLtoH_L0.TabIndex = 1
        Me.radLtoH_L0.TabStop = True
        Me.radLtoH_L0.Text = "Low to High"
        Me.radLtoH_L0.UseVisualStyleBackColor = True
        '
        'radHtoL_L0
        '
        Me.radHtoL_L0.AutoSize = True
        Me.radHtoL_L0.Location = New System.Drawing.Point(7, 21)
        Me.radHtoL_L0.Name = "radHtoL_L0"
        Me.radHtoL_L0.Size = New System.Drawing.Size(89, 16)
        Me.radHtoL_L0.TabIndex = 0
        Me.radHtoL_L0.TabStop = True
        Me.radHtoL_L0.Text = "High to Low"
        Me.radHtoL_L0.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.AutoScroll = True
        Me.TabPage4.BackColor = System.Drawing.Color.Transparent
        Me.TabPage4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage4.Controls.Add(Me.txtMultiUserCode3)
        Me.TabPage4.Controls.Add(Me.lblMultiUserCode3)
        Me.TabPage4.Controls.Add(Me.txtMultiUserCode2)
        Me.TabPage4.Controls.Add(Me.lblMultiUserCode2)
        Me.TabPage4.Controls.Add(Me.txtMultiUserCode1)
        Me.TabPage4.Controls.Add(Me.lblMultiUserCode1)
        Me.TabPage4.Controls.Add(Me.lblRangeKey3)
        Me.TabPage4.Controls.Add(Me.lblRangeIII)
        Me.TabPage4.Controls.Add(Me.txtMultiUserBoundry2)
        Me.TabPage4.Controls.Add(Me.lblRangeKey2)
        Me.TabPage4.Controls.Add(Me.lblRangeII)
        Me.TabPage4.Controls.Add(Me.txtMultiUserBoundry1)
        Me.TabPage4.Controls.Add(Me.lblRangeKey1)
        Me.TabPage4.Controls.Add(Me.lblRangeI)
        Me.TabPage4.Controls.Add(Me.cobMultiUserBits)
        Me.TabPage4.Controls.Add(Me.lblMultiUserBits)
        Me.TabPage4.Controls.Add(Me.ckbMultiUser)
        Me.TabPage4.Controls.Add(Me.btnImportKeyboard)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(744, 420)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "TabPage4"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'txtMultiUserCode3
        '
        Me.txtMultiUserCode3.Location = New System.Drawing.Point(632, 171)
        Me.txtMultiUserCode3.Name = "txtMultiUserCode3"
        Me.txtMultiUserCode3.Size = New System.Drawing.Size(45, 21)
        Me.txtMultiUserCode3.TabIndex = 25
        '
        'lblMultiUserCode3
        '
        Me.lblMultiUserCode3.AutoSize = True
        Me.lblMultiUserCode3.Location = New System.Drawing.Point(596, 175)
        Me.lblMultiUserCode3.Name = "lblMultiUserCode3"
        Me.lblMultiUserCode3.Size = New System.Drawing.Size(29, 12)
        Me.lblMultiUserCode3.TabIndex = 24
        Me.lblMultiUserCode3.Text = "Code"
        '
        'txtMultiUserCode2
        '
        Me.txtMultiUserCode2.Location = New System.Drawing.Point(632, 147)
        Me.txtMultiUserCode2.Name = "txtMultiUserCode2"
        Me.txtMultiUserCode2.Size = New System.Drawing.Size(45, 21)
        Me.txtMultiUserCode2.TabIndex = 23
        '
        'lblMultiUserCode2
        '
        Me.lblMultiUserCode2.AutoSize = True
        Me.lblMultiUserCode2.Location = New System.Drawing.Point(596, 151)
        Me.lblMultiUserCode2.Name = "lblMultiUserCode2"
        Me.lblMultiUserCode2.Size = New System.Drawing.Size(29, 12)
        Me.lblMultiUserCode2.TabIndex = 22
        Me.lblMultiUserCode2.Text = "Code"
        '
        'txtMultiUserCode1
        '
        Me.txtMultiUserCode1.Location = New System.Drawing.Point(632, 121)
        Me.txtMultiUserCode1.Name = "txtMultiUserCode1"
        Me.txtMultiUserCode1.Size = New System.Drawing.Size(45, 21)
        Me.txtMultiUserCode1.TabIndex = 21
        '
        'lblMultiUserCode1
        '
        Me.lblMultiUserCode1.AutoSize = True
        Me.lblMultiUserCode1.Location = New System.Drawing.Point(596, 125)
        Me.lblMultiUserCode1.Name = "lblMultiUserCode1"
        Me.lblMultiUserCode1.Size = New System.Drawing.Size(29, 12)
        Me.lblMultiUserCode1.TabIndex = 20
        Me.lblMultiUserCode1.Text = "Code"
        '
        'lblRangeKey3
        '
        Me.lblRangeKey3.AutoSize = True
        Me.lblRangeKey3.Location = New System.Drawing.Point(511, 175)
        Me.lblRangeKey3.Name = "lblRangeKey3"
        Me.lblRangeKey3.Size = New System.Drawing.Size(59, 12)
        Me.lblRangeKey3.TabIndex = 19
        Me.lblRangeKey3.Text = "K00 - K65"
        '
        'lblRangeIII
        '
        Me.lblRangeIII.AutoSize = True
        Me.lblRangeIII.Location = New System.Drawing.Point(444, 175)
        Me.lblRangeIII.Name = "lblRangeIII"
        Me.lblRangeIII.Size = New System.Drawing.Size(59, 12)
        Me.lblRangeIII.TabIndex = 18
        Me.lblRangeIII.Text = "Range III"
        '
        'txtMultiUserBoundry2
        '
        Me.txtMultiUserBoundry2.Location = New System.Drawing.Point(558, 147)
        Me.txtMultiUserBoundry2.Name = "txtMultiUserBoundry2"
        Me.txtMultiUserBoundry2.Size = New System.Drawing.Size(22, 21)
        Me.txtMultiUserBoundry2.TabIndex = 17
        '
        'lblRangeKey2
        '
        Me.lblRangeKey2.AutoSize = True
        Me.lblRangeKey2.Location = New System.Drawing.Point(511, 151)
        Me.lblRangeKey2.Name = "lblRangeKey2"
        Me.lblRangeKey2.Size = New System.Drawing.Size(47, 12)
        Me.lblRangeKey2.TabIndex = 16
        Me.lblRangeKey2.Text = "K00 - K"
        '
        'lblRangeII
        '
        Me.lblRangeII.AutoSize = True
        Me.lblRangeII.Location = New System.Drawing.Point(444, 151)
        Me.lblRangeII.Name = "lblRangeII"
        Me.lblRangeII.Size = New System.Drawing.Size(53, 12)
        Me.lblRangeII.TabIndex = 15
        Me.lblRangeII.Text = "Range II"
        '
        'txtMultiUserBoundry1
        '
        Me.txtMultiUserBoundry1.Location = New System.Drawing.Point(558, 121)
        Me.txtMultiUserBoundry1.Name = "txtMultiUserBoundry1"
        Me.txtMultiUserBoundry1.Size = New System.Drawing.Size(22, 21)
        Me.txtMultiUserBoundry1.TabIndex = 14
        '
        'lblRangeKey1
        '
        Me.lblRangeKey1.AutoSize = True
        Me.lblRangeKey1.Location = New System.Drawing.Point(511, 125)
        Me.lblRangeKey1.Name = "lblRangeKey1"
        Me.lblRangeKey1.Size = New System.Drawing.Size(47, 12)
        Me.lblRangeKey1.TabIndex = 13
        Me.lblRangeKey1.Text = "K00 - K"
        '
        'lblRangeI
        '
        Me.lblRangeI.AutoSize = True
        Me.lblRangeI.Location = New System.Drawing.Point(444, 125)
        Me.lblRangeI.Name = "lblRangeI"
        Me.lblRangeI.Size = New System.Drawing.Size(47, 12)
        Me.lblRangeI.TabIndex = 12
        Me.lblRangeI.Text = "Range I"
        '
        'cobMultiUserBits
        '
        Me.cobMultiUserBits.FormattingEnabled = True
        Me.cobMultiUserBits.Location = New System.Drawing.Point(494, 90)
        Me.cobMultiUserBits.Name = "cobMultiUserBits"
        Me.cobMultiUserBits.Size = New System.Drawing.Size(44, 20)
        Me.cobMultiUserBits.TabIndex = 11
        '
        'lblMultiUserBits
        '
        Me.lblMultiUserBits.AutoSize = True
        Me.lblMultiUserBits.Location = New System.Drawing.Point(444, 94)
        Me.lblMultiUserBits.Name = "lblMultiUserBits"
        Me.lblMultiUserBits.Size = New System.Drawing.Size(29, 12)
        Me.lblMultiUserBits.TabIndex = 10
        Me.lblMultiUserBits.Text = "Bits"
        '
        'ckbMultiUser
        '
        Me.ckbMultiUser.AutoSize = True
        Me.ckbMultiUser.Location = New System.Drawing.Point(444, 62)
        Me.ckbMultiUser.Name = "ckbMultiUser"
        Me.ckbMultiUser.Size = New System.Drawing.Size(114, 16)
        Me.ckbMultiUser.TabIndex = 9
        Me.ckbMultiUser.Text = "Multi User Code"
        Me.ckbMultiUser.UseVisualStyleBackColor = True
        '
        'btnImportKeyboard
        '
        Me.btnImportKeyboard.Location = New System.Drawing.Point(570, 5)
        Me.btnImportKeyboard.Name = "btnImportKeyboard"
        Me.btnImportKeyboard.Size = New System.Drawing.Size(144, 39)
        Me.btnImportKeyboard.TabIndex = 0
        Me.btnImportKeyboard.Text = "Import Keyboard Data From RCT File"
        Me.btnImportKeyboard.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.txtInfoNote)
        Me.TabPage1.Controls.Add(Me.lblInfoNote)
        Me.TabPage1.Controls.Add(Me.txtInfoName)
        Me.TabPage1.Controls.Add(Me.lblInfoName)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(744, 420)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtInfoNote
        '
        Me.txtInfoNote.Location = New System.Drawing.Point(83, 64)
        Me.txtInfoNote.MaxLength = 512
        Me.txtInfoNote.Multiline = True
        Me.txtInfoNote.Name = "txtInfoNote"
        Me.txtInfoNote.Size = New System.Drawing.Size(639, 333)
        Me.txtInfoNote.TabIndex = 3
        '
        'lblInfoNote
        '
        Me.lblInfoNote.AutoSize = True
        Me.lblInfoNote.Location = New System.Drawing.Point(32, 67)
        Me.lblInfoNote.Name = "lblInfoNote"
        Me.lblInfoNote.Size = New System.Drawing.Size(29, 12)
        Me.lblInfoNote.TabIndex = 2
        Me.lblInfoNote.Text = "Note"
        '
        'txtInfoName
        '
        Me.txtInfoName.Location = New System.Drawing.Point(83, 22)
        Me.txtInfoName.MaxLength = 64
        Me.txtInfoName.Name = "txtInfoName"
        Me.txtInfoName.Size = New System.Drawing.Size(639, 21)
        Me.txtInfoName.TabIndex = 1
        '
        'lblInfoName
        '
        Me.lblInfoName.AutoSize = True
        Me.lblInfoName.Location = New System.Drawing.Point(32, 26)
        Me.lblInfoName.Name = "lblInfoName"
        Me.lblInfoName.Size = New System.Drawing.Size(29, 12)
        Me.lblInfoName.TabIndex = 0
        Me.lblInfoName.Text = "Name"
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage5.Controls.Add(Me.GroupBox4)
        Me.TabPage5.Controls.Add(Me.grpIROUTStructure)
        Me.TabPage5.Controls.Add(Me.cobIRef)
        Me.TabPage5.Controls.Add(Me.Label3)
        Me.TabPage5.Controls.Add(Me.cobDriveSpeed)
        Me.TabPage5.Controls.Add(Me.Label2)
        Me.TabPage5.Controls.Add(Me.GroupBox3)
        Me.TabPage5.Controls.Add(Me.GroupBox2)
        Me.TabPage5.Controls.Add(Me.cobTempValue)
        Me.TabPage5.Controls.Add(Me.Label1)
        Me.TabPage5.Controls.Add(Me.grpFilterSelect)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(744, 420)
        Me.TabPage5.TabIndex = 3
        Me.TabPage5.Text = "内部调试用"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.radConn)
        Me.GroupBox4.Controls.Add(Me.radNotConn)
        Me.GroupBox4.Location = New System.Drawing.Point(330, 181)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(216, 64)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "HIRC与LED引脚连接"
        '
        'radConn
        '
        Me.radConn.AutoSize = True
        Me.radConn.Location = New System.Drawing.Point(107, 28)
        Me.radConn.Name = "radConn"
        Me.radConn.Size = New System.Drawing.Size(47, 16)
        Me.radConn.TabIndex = 1
        Me.radConn.TabStop = True
        Me.radConn.Text = "允许"
        Me.radConn.UseVisualStyleBackColor = True
        '
        'radNotConn
        '
        Me.radNotConn.AutoSize = True
        Me.radNotConn.Location = New System.Drawing.Point(17, 28)
        Me.radNotConn.Name = "radNotConn"
        Me.radNotConn.Size = New System.Drawing.Size(47, 16)
        Me.radNotConn.TabIndex = 0
        Me.radNotConn.TabStop = True
        Me.radNotConn.Text = "禁止"
        Me.radNotConn.UseVisualStyleBackColor = True
        '
        'grpIROUTStructure
        '
        Me.grpIROUTStructure.Controls.Add(Me.radOD)
        Me.grpIROUTStructure.Controls.Add(Me.radNotOD)
        Me.grpIROUTStructure.Location = New System.Drawing.Point(330, 86)
        Me.grpIROUTStructure.Name = "grpIROUTStructure"
        Me.grpIROUTStructure.Size = New System.Drawing.Size(216, 64)
        Me.grpIROUTStructure.TabIndex = 10
        Me.grpIROUTStructure.TabStop = False
        Me.grpIROUTStructure.Text = "发射引脚结构"
        '
        'radOD
        '
        Me.radOD.AutoSize = True
        Me.radOD.Location = New System.Drawing.Point(107, 28)
        Me.radOD.Name = "radOD"
        Me.radOD.Size = New System.Drawing.Size(47, 16)
        Me.radOD.TabIndex = 1
        Me.radOD.TabStop = True
        Me.radOD.Text = "开漏"
        Me.radOD.UseVisualStyleBackColor = True
        '
        'radNotOD
        '
        Me.radNotOD.AutoSize = True
        Me.radNotOD.Location = New System.Drawing.Point(17, 28)
        Me.radNotOD.Name = "radNotOD"
        Me.radNotOD.Size = New System.Drawing.Size(59, 16)
        Me.radNotOD.TabIndex = 0
        Me.radNotOD.TabStop = True
        Me.radNotOD.Text = "不开漏"
        Me.radNotOD.UseVisualStyleBackColor = True
        '
        'cobIRef
        '
        Me.cobIRef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobIRef.FormattingEnabled = True
        Me.cobIRef.Items.AddRange(New Object() {"6uA", "3uA", "1.5uA", "0.75uA"})
        Me.cobIRef.Location = New System.Drawing.Point(421, 38)
        Me.cobIRef.Name = "cobIRef"
        Me.cobIRef.Size = New System.Drawing.Size(101, 20)
        Me.cobIRef.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(320, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 17)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "基准电流选择"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cobDriveSpeed
        '
        Me.cobDriveSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobDriveSpeed.FormattingEnabled = True
        Me.cobDriveSpeed.Items.AddRange(New Object() {"10ns", "2us", "1us", "500ns"})
        Me.cobDriveSpeed.Location = New System.Drawing.Point(133, 323)
        Me.cobDriveSpeed.Name = "cobDriveSpeed"
        Me.cobDriveSpeed.Size = New System.Drawing.Size(101, 20)
        Me.cobDriveSpeed.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(32, 325)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "开关管驱动速率"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.radLDO15)
        Me.GroupBox3.Controls.Add(Me.radLDO17)
        Me.GroupBox3.Location = New System.Drawing.Point(26, 242)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(216, 64)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "LDO电压选择"
        '
        'radLDO15
        '
        Me.radLDO15.AutoSize = True
        Me.radLDO15.Location = New System.Drawing.Point(107, 28)
        Me.radLDO15.Name = "radLDO15"
        Me.radLDO15.Size = New System.Drawing.Size(47, 16)
        Me.radLDO15.TabIndex = 1
        Me.radLDO15.TabStop = True
        Me.radLDO15.Text = "1.5V"
        Me.radLDO15.UseVisualStyleBackColor = True
        '
        'radLDO17
        '
        Me.radLDO17.AutoSize = True
        Me.radLDO17.Location = New System.Drawing.Point(17, 28)
        Me.radLDO17.Name = "radLDO17"
        Me.radLDO17.Size = New System.Drawing.Size(47, 16)
        Me.radLDO17.TabIndex = 0
        Me.radLDO17.TabStop = True
        Me.radLDO17.Text = "1.7V"
        Me.radLDO17.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.radLowSpeed)
        Me.GroupBox2.Controls.Add(Me.radHighSpeed)
        Me.GroupBox2.Location = New System.Drawing.Point(26, 153)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(216, 64)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "读OTP速度"
        '
        'radLowSpeed
        '
        Me.radLowSpeed.AutoSize = True
        Me.radLowSpeed.Location = New System.Drawing.Point(107, 28)
        Me.radLowSpeed.Name = "radLowSpeed"
        Me.radLowSpeed.Size = New System.Drawing.Size(47, 16)
        Me.radLowSpeed.TabIndex = 1
        Me.radLowSpeed.TabStop = True
        Me.radLowSpeed.Text = "低速"
        Me.radLowSpeed.UseVisualStyleBackColor = True
        '
        'radHighSpeed
        '
        Me.radHighSpeed.AutoSize = True
        Me.radHighSpeed.Location = New System.Drawing.Point(17, 28)
        Me.radHighSpeed.Name = "radHighSpeed"
        Me.radHighSpeed.Size = New System.Drawing.Size(47, 16)
        Me.radHighSpeed.TabIndex = 0
        Me.radHighSpeed.TabStop = True
        Me.radHighSpeed.Text = "高速"
        Me.radHighSpeed.UseVisualStyleBackColor = True
        '
        'cobTempValue
        '
        Me.cobTempValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobTempValue.FormattingEnabled = True
        Me.cobTempValue.Location = New System.Drawing.Point(133, 109)
        Me.cobTempValue.Name = "cobTempValue"
        Me.cobTempValue.Size = New System.Drawing.Size(101, 20)
        Me.cobTempValue.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(32, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "温度校准值"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpFilterSelect
        '
        Me.grpFilterSelect.Controls.Add(Me.radFilterDisable)
        Me.grpFilterSelect.Controls.Add(Me.radFilterEnable)
        Me.grpFilterSelect.Location = New System.Drawing.Point(26, 29)
        Me.grpFilterSelect.Name = "grpFilterSelect"
        Me.grpFilterSelect.Size = New System.Drawing.Size(216, 64)
        Me.grpFilterSelect.TabIndex = 7
        Me.grpFilterSelect.TabStop = False
        Me.grpFilterSelect.Text = "滤波选择"
        '
        'radFilterDisable
        '
        Me.radFilterDisable.AutoSize = True
        Me.radFilterDisable.Location = New System.Drawing.Point(107, 28)
        Me.radFilterDisable.Name = "radFilterDisable"
        Me.radFilterDisable.Size = New System.Drawing.Size(71, 16)
        Me.radFilterDisable.TabIndex = 1
        Me.radFilterDisable.TabStop = True
        Me.radFilterDisable.Text = "滤波无效"
        Me.radFilterDisable.UseVisualStyleBackColor = True
        '
        'radFilterEnable
        '
        Me.radFilterEnable.AutoSize = True
        Me.radFilterEnable.Location = New System.Drawing.Point(17, 28)
        Me.radFilterEnable.Name = "radFilterEnable"
        Me.radFilterEnable.Size = New System.Drawing.Size(71, 16)
        Me.radFilterEnable.TabIndex = 0
        Me.radFilterEnable.TabStop = True
        Me.radFilterEnable.Text = "滤波有效"
        Me.radFilterEnable.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Transparent
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage2.Controls.Add(Me.trvFrame)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(218, 420)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'trvFrame
        '
        Me.trvFrame.BackColor = System.Drawing.SystemColors.Control
        Me.trvFrame.CheckBoxes = True
        Me.trvFrame.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvFrame.Location = New System.Drawing.Point(3, 3)
        Me.trvFrame.Name = "trvFrame"
        TreeNode1.Name = "节点0"
        TreeNode1.Text = "节点0"
        TreeNode2.Name = "节点1"
        TreeNode2.Text = "节点1"
        TreeNode3.Name = "节点2"
        TreeNode3.Text = "节点2"
        TreeNode4.Name = "节点8"
        TreeNode4.Text = "节点8"
        TreeNode5.Name = "节点9"
        TreeNode5.Text = "节点9"
        TreeNode6.Name = "节点10"
        TreeNode6.Text = "节点10"
        TreeNode7.Name = "节点3"
        TreeNode7.Text = "节点3"
        TreeNode8.Name = "节点11"
        TreeNode8.Text = "节点11"
        TreeNode9.Name = "节点12"
        TreeNode9.Text = "节点12"
        TreeNode10.Name = "节点6"
        TreeNode10.Text = "节点6"
        TreeNode11.Name = "节点7"
        TreeNode11.Text = "节点7"
        Me.trvFrame.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode7, TreeNode10, TreeNode11})
        Me.trvFrame.Size = New System.Drawing.Size(210, 412)
        Me.trvFrame.TabIndex = 0
        '
        'tabFrame
        '
        Me.tabFrame.Controls.Add(Me.TabPage2)
        Me.tabFrame.Location = New System.Drawing.Point(5, 214)
        Me.tabFrame.Name = "tabFrame"
        Me.tabFrame.SelectedIndex = 0
        Me.tabFrame.Size = New System.Drawing.Size(226, 446)
        Me.tabFrame.TabIndex = 1
        Me.tabFrame.TabStop = False
        '
        'errProvider
        '
        Me.errProvider.BlinkRate = 500
        Me.errProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.errProvider.ContainerControl = Me
        '
        'hscWave
        '
        Me.hscWave.Location = New System.Drawing.Point(0, 190)
        Me.hscWave.Name = "hscWave"
        Me.hscWave.Size = New System.Drawing.Size(990, 20)
        Me.hscWave.TabIndex = 5
        '
        'myMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(984, 662)
        Me.Controls.Add(Me.hscWave)
        Me.Controls.Add(Me.tabSetting)
        Me.Controls.Add(Me.tabFrame)
        Me.Controls.Add(Me.panWave)
        Me.Controls.Add(Me.tosMain)
        Me.Controls.Add(Me.mnuMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnuMain
        Me.MaximizeBox = False
        Me.Name = "myMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.tosMain.ResumeLayout(False)
        Me.tosMain.PerformLayout()
        Me.tabSetting.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.grpRepeat.ResumeLayout(False)
        Me.grpRepeat.PerformLayout()
        Me.grpComplete.ResumeLayout(False)
        Me.grpComplete.PerformLayout()
        Me.grpCompact.ResumeLayout(False)
        Me.grpCompact.PerformLayout()
        Me.grpDataFrame.ResumeLayout(False)
        Me.grpDataFrame.PerformLayout()
        Me.grpDataCode1.ResumeLayout(False)
        Me.grpDataCode1.PerformLayout()
        Me.grpUser.ResumeLayout(False)
        Me.grpUser.PerformLayout()
        Me.grpDataCode2.ResumeLayout(False)
        Me.grpDataCode2.PerformLayout()
        Me.grpUserCode2.ResumeLayout(False)
        Me.grpUserCode2.PerformLayout()
        Me.grpStopCode.ResumeLayout(False)
        Me.grpStopCode.PerformLayout()
        Me.grpStopBit.ResumeLayout(False)
        Me.grpStopBit.PerformLayout()
        Me.grpSplit.ResumeLayout(False)
        Me.grpSplit.PerformLayout()
        Me.grpBoot.ResumeLayout(False)
        Me.grpBoot.PerformLayout()
        Me.grpGlobal.ResumeLayout(False)
        Me.grpOthers.ResumeLayout(False)
        Me.grpOthers.PerformLayout()
        Me.grpKey.ResumeLayout(False)
        Me.grpKey.PerformLayout()
        Me.grpIROUT.ResumeLayout(False)
        Me.grpLED.ResumeLayout(False)
        Me.grpLED.PerformLayout()
        Me.grpDataDir.ResumeLayout(False)
        Me.grpDataDir.PerformLayout()
        Me.grpCarrier.ResumeLayout(False)
        Me.grpCarrier.PerformLayout()
        Me.grpLogic1.ResumeLayout(False)
        Me.grpLogic1.PerformLayout()
        Me.grpLogic0.ResumeLayout(False)
        Me.grpLogic0.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.grpIROUTStructure.ResumeLayout(False)
        Me.grpIROUTStructure.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grpFilterSelect.ResumeLayout(False)
        Me.grpFilterSelect.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.tabFrame.ResumeLayout(False)
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tosMain As System.Windows.Forms.ToolStrip
    Friend WithEvents panWave As System.Windows.Forms.Panel
    Friend WithEvents tabSetting As System.Windows.Forms.TabControl
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents mnuLanguage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLangChinese As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLangEnglish As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grpGlobal As System.Windows.Forms.GroupBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents trvFrame As System.Windows.Forms.TreeView
    Friend WithEvents tabFrame As System.Windows.Forms.TabControl
    Friend WithEvents grpBoot As System.Windows.Forms.GroupBox
    Friend WithEvents grpLogic0 As System.Windows.Forms.GroupBox
    Friend WithEvents radLtoH_L0 As System.Windows.Forms.RadioButton
    Friend WithEvents radHtoL_L0 As System.Windows.Forms.RadioButton
    Friend WithEvents txtFirst_L0 As System.Windows.Forms.TextBox
    Friend WithEvents lblFirst_L0 As System.Windows.Forms.Label
    Friend WithEvents txtSecond_L0 As System.Windows.Forms.TextBox
    Friend WithEvents lblSecond_L0 As System.Windows.Forms.Label
    Friend WithEvents grpCarrier As System.Windows.Forms.GroupBox
    Friend WithEvents lblDuty As System.Windows.Forms.Label
    Friend WithEvents txtCarrierFreq As System.Windows.Forms.TextBox
    Friend WithEvents lblCarrierFreq As System.Windows.Forms.Label
    Friend WithEvents grpLogic1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSecond_L1 As System.Windows.Forms.TextBox
    Friend WithEvents lblSecond_L1 As System.Windows.Forms.Label
    Friend WithEvents txtFirst_L1 As System.Windows.Forms.TextBox
    Friend WithEvents lblFirst_L1 As System.Windows.Forms.Label
    Friend WithEvents radLtoH_L1 As System.Windows.Forms.RadioButton
    Friend WithEvents radHtoL_L1 As System.Windows.Forms.RadioButton
    Friend WithEvents grpDataDir As System.Windows.Forms.GroupBox
    Friend WithEvents radHighBitFirst As System.Windows.Forms.RadioButton
    Friend WithEvents radLowBitFirst As System.Windows.Forms.RadioButton
    Friend WithEvents grpLED As System.Windows.Forms.GroupBox
    Friend WithEvents ckbLED As System.Windows.Forms.CheckBox
    Friend WithEvents cobLEDCurrent As System.Windows.Forms.ComboBox
    Friend WithEvents lblLEDCurrent As System.Windows.Forms.Label
    Friend WithEvents cobDuty As System.Windows.Forms.ComboBox
    Friend WithEvents grpIROUT As System.Windows.Forms.GroupBox
    Friend WithEvents cobIRCurrent As System.Windows.Forms.ComboBox
    Friend WithEvents lblIRCurrent As System.Windows.Forms.Label
    Friend WithEvents grpKey As System.Windows.Forms.GroupBox
    Friend WithEvents radScanOneTime As System.Windows.Forms.RadioButton
    Friend WithEvents lblDebounce As System.Windows.Forms.Label
    Friend WithEvents txtKeyRemain As System.Windows.Forms.TextBox
    Friend WithEvents lblKeyRemain As System.Windows.Forms.Label
    Friend WithEvents radScanCont As System.Windows.Forms.RadioButton
    Friend WithEvents cobScanInterval As System.Windows.Forms.ComboBox
    Friend WithEvents lblScanInterval As System.Windows.Forms.Label
    Friend WithEvents txtInvalidKey As System.Windows.Forms.TextBox
    Friend WithEvents lblInvalidKey As System.Windows.Forms.Label
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents mnuFileSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFileSaveAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFileOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtBootHigh As System.Windows.Forms.TextBox
    Friend WithEvents lblBootHigh As System.Windows.Forms.Label
    Friend WithEvents txtBootLow As System.Windows.Forms.TextBox
    Friend WithEvents lblBootLow As System.Windows.Forms.Label
    Friend WithEvents grpSplit As System.Windows.Forms.GroupBox
    Friend WithEvents lblSplitLow As System.Windows.Forms.Label
    Friend WithEvents txtSplitHigh As System.Windows.Forms.TextBox
    Friend WithEvents lblSplitHigh As System.Windows.Forms.Label
    Friend WithEvents txtSplitLow As System.Windows.Forms.TextBox
    Friend WithEvents grpUser As System.Windows.Forms.GroupBox
    Friend WithEvents lblUserBits As System.Windows.Forms.Label
    Friend WithEvents txtUserCode As System.Windows.Forms.TextBox
    Friend WithEvents lblUserCode As System.Windows.Forms.Label
    Friend WithEvents cobUserBits As System.Windows.Forms.ComboBox
    Friend WithEvents ckbRevertBitHi As System.Windows.Forms.CheckBox
    Friend WithEvents cobPositionHi As System.Windows.Forms.ComboBox
    Friend WithEvents lblBit1Option As System.Windows.Forms.Label
    Friend WithEvents ckbBit1Option As System.Windows.Forms.CheckBox
    Friend WithEvents lblPositionHi As System.Windows.Forms.Label
    Friend WithEvents grpDataCode1 As System.Windows.Forms.GroupBox
    Friend WithEvents cobDataCode1Bits As System.Windows.Forms.ComboBox
    Friend WithEvents lblDataCode1Bits As System.Windows.Forms.Label
    Friend WithEvents grpUserCode2 As System.Windows.Forms.GroupBox
    Friend WithEvents cobUserCode2Bits As System.Windows.Forms.ComboBox
    Friend WithEvents lblUserCode2Bits As System.Windows.Forms.Label
    Friend WithEvents txtUserCode2 As System.Windows.Forms.TextBox
    Friend WithEvents lblUserCode2 As System.Windows.Forms.Label
    Friend WithEvents grpDataCode2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtChecksum As System.Windows.Forms.TextBox
    Friend WithEvents lblChecksum As System.Windows.Forms.Label
    Friend WithEvents radChecksum As System.Windows.Forms.RadioButton
    Friend WithEvents radRevertData1 As System.Windows.Forms.RadioButton
    Friend WithEvents grpStopBit As System.Windows.Forms.GroupBox
    Friend WithEvents radLtoH_Stop As System.Windows.Forms.RadioButton
    Friend WithEvents radHtoL_Stop As System.Windows.Forms.RadioButton
    Friend WithEvents txtStopBitFirst As System.Windows.Forms.TextBox
    Friend WithEvents lblStopBitFirst As System.Windows.Forms.Label
    Friend WithEvents grpStopCode As System.Windows.Forms.GroupBox
    Friend WithEvents grpRepeat As System.Windows.Forms.GroupBox
    Friend WithEvents radComplete As System.Windows.Forms.RadioButton
    Friend WithEvents radCompact As System.Windows.Forms.RadioButton
    Friend WithEvents grpCompact As System.Windows.Forms.GroupBox
    Friend WithEvents txtLowRepeat As System.Windows.Forms.TextBox
    Friend WithEvents lblLowRepeat As System.Windows.Forms.Label
    Friend WithEvents txtHighRepeat As System.Windows.Forms.TextBox
    Friend WithEvents lblHighRepeat As System.Windows.Forms.Label
    Friend WithEvents radHL11 As System.Windows.Forms.RadioButton
    Friend WithEvents radHL01 As System.Windows.Forms.RadioButton
    Friend WithEvents radHL0 As System.Windows.Forms.RadioButton
    Friend WithEvents grpComplete As System.Windows.Forms.GroupBox
    Friend WithEvents ckbBootCode As System.Windows.Forms.CheckBox
    Friend WithEvents tolNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tolOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tolSaveAs As System.Windows.Forms.ToolStripButton
    Friend WithEvents hscWave As System.Windows.Forms.HScrollBar
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tolZoomIn As System.Windows.Forms.ToolStripButton
    Friend WithEvents tolZoomOut As System.Windows.Forms.ToolStripButton
    Private WithEvents tolFit As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelpAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWaveZoomIn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWaveFit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWaveZoomOut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTool As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuToolExportS19 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuToolImportS19 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuToolImportKeyboard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImportKeyboard As System.Windows.Forms.Button
    Friend WithEvents txtInfoName As System.Windows.Forms.TextBox
    Friend WithEvents lblInfoName As System.Windows.Forms.Label
    Friend WithEvents lblInfoNote As System.Windows.Forms.Label
    Friend WithEvents txtInfoNote As System.Windows.Forms.TextBox
    Friend WithEvents lblStopTime As System.Windows.Forms.Label
    Friend WithEvents txtStopTime As System.Windows.Forms.TextBox
    Friend WithEvents lblRepeatStopTime As System.Windows.Forms.Label
    Friend WithEvents txtRepeatStopTime As System.Windows.Forms.TextBox
    Friend WithEvents txtStopBitSecond As System.Windows.Forms.TextBox
    Friend WithEvents lblStopBitSecond As System.Windows.Forms.Label
    Friend WithEvents radDefineWholeFrame As System.Windows.Forms.RadioButton
    Friend WithEvents radDefineStopTime As System.Windows.Forms.RadioButton
    Friend WithEvents ckbData2Revert As System.Windows.Forms.CheckBox
    Friend WithEvents ckbUser2Revert As System.Windows.Forms.CheckBox
    Friend WithEvents ckbData1Revert As System.Windows.Forms.CheckBox
    Friend WithEvents txtDebounce As System.Windows.Forms.TextBox
    Friend WithEvents radData2Changeless As System.Windows.Forms.RadioButton
    Friend WithEvents cobData2ChangelessBits As System.Windows.Forms.ComboBox
    Friend WithEvents lblData2ChangelessBits As System.Windows.Forms.Label
    Friend WithEvents txtData2Code As System.Windows.Forms.TextBox
    Friend WithEvents lblData2Code As System.Windows.Forms.Label
    Friend WithEvents lblPositionLo As System.Windows.Forms.Label
    Friend WithEvents cobPositionLo As System.Windows.Forms.ComboBox
    Friend WithEvents ckbRevertBitLo As System.Windows.Forms.CheckBox
    Friend WithEvents txtRepeatBootLow As System.Windows.Forms.TextBox
    Friend WithEvents lblRepeatBootLow As System.Windows.Forms.Label
    Friend WithEvents txtRepeatBootHigh As System.Windows.Forms.TextBox
    Friend WithEvents lblRepeatBootHigh As System.Windows.Forms.Label
    Friend WithEvents grpOthers As System.Windows.Forms.GroupBox
    Friend WithEvents ckbDoubleFrame As System.Windows.Forms.CheckBox
    Friend WithEvents ckbL7464Check As System.Windows.Forms.CheckBox
    Friend WithEvents ckbBitExpand As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents grpFilterSelect As System.Windows.Forms.GroupBox
    Friend WithEvents radFilterDisable As System.Windows.Forms.RadioButton
    Friend WithEvents radFilterEnable As System.Windows.Forms.RadioButton
    Friend WithEvents cobTempValue As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents radLowSpeed As System.Windows.Forms.RadioButton
    Friend WithEvents radHighSpeed As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents radLDO15 As System.Windows.Forms.RadioButton
    Friend WithEvents radLDO17 As System.Windows.Forms.RadioButton
    Friend WithEvents cobDriveSpeed As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cobIRef As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grpIROUTStructure As System.Windows.Forms.GroupBox
    Friend WithEvents radOD As System.Windows.Forms.RadioButton
    Friend WithEvents radNotOD As System.Windows.Forms.RadioButton
    Friend WithEvents rad150K As System.Windows.Forms.RadioButton
    Friend WithEvents rad60K As System.Windows.Forms.RadioButton
    Friend WithEvents lblPURes As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents radConn As System.Windows.Forms.RadioButton
    Friend WithEvents radNotConn As System.Windows.Forms.RadioButton
    Friend WithEvents radLEDHi As System.Windows.Forms.RadioButton
    Friend WithEvents radLEDLo As System.Windows.Forms.RadioButton
    Friend WithEvents radL7464_Sum As System.Windows.Forms.RadioButton
    Friend WithEvents radL7464_Xor As System.Windows.Forms.RadioButton
    Friend WithEvents ckb1986Enable As System.Windows.Forms.CheckBox
    Friend WithEvents ckbUpKeyEnable As System.Windows.Forms.CheckBox
    Friend WithEvents txtUpKey As System.Windows.Forms.TextBox
    Friend WithEvents ckbMultiUser As System.Windows.Forms.CheckBox
    Friend WithEvents lblMultiUserBits As System.Windows.Forms.Label
    Friend WithEvents lblRangeKey3 As System.Windows.Forms.Label
    Friend WithEvents lblRangeIII As System.Windows.Forms.Label
    Friend WithEvents txtMultiUserBoundry2 As System.Windows.Forms.TextBox
    Friend WithEvents lblRangeKey2 As System.Windows.Forms.Label
    Friend WithEvents lblRangeII As System.Windows.Forms.Label
    Friend WithEvents txtMultiUserBoundry1 As System.Windows.Forms.TextBox
    Friend WithEvents lblRangeKey1 As System.Windows.Forms.Label
    Friend WithEvents lblRangeI As System.Windows.Forms.Label
    Friend WithEvents cobMultiUserBits As System.Windows.Forms.ComboBox
    Friend WithEvents txtMultiUserCode3 As System.Windows.Forms.TextBox
    Friend WithEvents lblMultiUserCode3 As System.Windows.Forms.Label
    Friend WithEvents txtMultiUserCode2 As System.Windows.Forms.TextBox
    Friend WithEvents lblMultiUserCode2 As System.Windows.Forms.Label
    Friend WithEvents txtMultiUserCode1 As System.Windows.Forms.TextBox
    Friend WithEvents lblMultiUserCode1 As System.Windows.Forms.Label
    Friend WithEvents grpDataFrame As System.Windows.Forms.GroupBox
    Friend WithEvents ckbRepeatDataFrame As System.Windows.Forms.CheckBox
    Friend WithEvents ckbRepeatModeGroup As System.Windows.Forms.CheckBox
    Friend WithEvents lblRepeatModeGroupB As System.Windows.Forms.Label
    Friend WithEvents lblRepeatGroupBRange As System.Windows.Forms.Label
    Friend WithEvents lblRepeatGroupB As System.Windows.Forms.Label
    Friend WithEvents lblRepeatModeGroupA As System.Windows.Forms.Label
    Friend WithEvents txtRepeatGroupBoundry As System.Windows.Forms.TextBox
    Friend WithEvents lblRepeatGroupARange As System.Windows.Forms.Label
    Friend WithEvents lblRepeatGroupA As System.Windows.Forms.Label
    Friend WithEvents radSameAsBoot As System.Windows.Forms.RadioButton
    Friend WithEvents radSameAsCompact As System.Windows.Forms.RadioButton
    Friend WithEvents ckbVDDKeyScan As System.Windows.Forms.CheckBox
    Friend WithEvents ckbCountLimit As System.Windows.Forms.CheckBox


End Class
