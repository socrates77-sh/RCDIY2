Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing



Public Class myMain
    Dim n As Integer
    Public myRCType As RCType
    'Dim bSaved As Boolean
    'Dim bnew As Boolean
    Dim sCurrentPath As String
    Dim sCurrentFile As String
    Dim fWaveStart As Double
    Dim fWaveDuration As Double
    Dim bInit As Boolean
    Dim bPan As Boolean
    Dim bZoom As Boolean
    Dim fMouseStart As Double
    Dim fMouseEnd As Double
    Dim nMouseX0 As Integer
    Dim nMouseX1 As Integer
    Dim fWaveStart0 As Double
    'Dim bZoomStart As Boolean

    Dim btnAllSingle(90) As KeyButton
    'Dim btnAllDouble(7) As DoubleKeyButton
    'Dim btnAllTriple(1) As TripleKeyButton
    Dim lblSingleKeyNote As Label
    Dim lblUsageNote As Label
    'Dim lblDoubleKeyNote As Label
    'Dim lblTripleKeyNote As Label
    'Dim lblInfoName As Label
    'Dim lblInfoNote As Label
    'Dim txtInfoName As TextBox
    'Dim txtInfoNote As TextBox

    'Dim OTP(255) As Byte
    Dim lblVDDS10 As Label
    Dim lblS10 As Label


    Private Sub myMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim prompt As String
        Dim sFullName As String

        sFullName = My.Computer.FileSystem.CombinePath(sCurrentPath, sCurrentFile)
        If mnuLangEnglish.Checked Then
            prompt = "Save " & sFullName & " or not?"
        Else
            prompt = sFullName & "需要保存吗?"
        End If

        Dim result As Windows.Forms.DialogResult
        result = MessageBox.Show(prompt, "Closing", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        If result = Windows.Forms.DialogResult.Cancel Then
            e.Cancel = True
        ElseIf result = Windows.Forms.DialogResult.Yes Then
            Me.ActiveControl = CType(cobDuty, Control)
            If CheckError() Then
                'FormToRCType()
                SaveRCTFile(sFullName)
            End If
            e.Cancel = False
        Else
            e.Cancel = False
        End If

    End Sub

    Private Sub myMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim x0 As Integer, y0 As Integer, w0 As Integer, h0 As Integer
        bInit = True
        'Me.Icon = My.Resources.icon_zj
        Me.AutoScroll = True
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
        If My.Computer.Screen.WorkingArea.Width > 1000 Then
            w0 = 1000
        Else
            w0 = My.Computer.Screen.WorkingArea.Width
        End If
        If My.Computer.Screen.WorkingArea.Height > 700 Then
            h0 = 700
        Else
            h0 = My.Computer.Screen.WorkingArea.Height
        End If
        Me.Size = New Size(w0, h0)
        y0 = (My.Computer.Screen.WorkingArea.Height - Me.Size.Height) / 2
        x0 = (My.Computer.Screen.WorkingArea.Width - Me.Size.Width) / 2
        Me.Location = New Point(x0, y0)
        'Me.StartPosition = FormStartPosition.CenterScreen

        panWave.Size = New Size(Me.ClientRectangle.Width, 150)
        sCurrentPath = My.Computer.FileSystem.CurrentDirectory
        sCurrentFile = "new.rct"

        Dim i As Integer

        For i = 1 To 32
            cobUserBits.Items.Add(i.ToString)
        Next

        For i = 16 To 31
            cobPositionHi.Items.Add("Bit" & i.ToString)
        Next

        For i = 0 To 15
            cobPositionLo.Items.Add("Bit" & i.ToString)
        Next

        For i = 1 To 8
            cobDataCode1Bits.Items.Add(i.ToString)
        Next

        For i = 1 To 16
            cobUserCode2Bits.Items.Add(i.ToString)
        Next

        For i = 1 To 16
            cobData2ChangelessBits.Items.Add(i.ToString)
        Next

        For i = 1 To 16
            cobMultiUserBits.Items.Add(i.ToString)
        Next

        'for Debug
        For i = 0 To 31
            cobTempValue.Items.Add(i.ToString("X2"))
        Next

        myRCType = New RCType()

        'lblVDDS10 = New Label
        'lblVDDS10.Parent = tabSetting.TabPages(1)
        'lblS10 = New Label
        'lblS10.Parent = tabSetting.TabPages(1)

        RefreshForm()
        InitKeyControl()
        TextChineseVersion()
        'bSaved = False
        mnuFileSave.Enabled = False
        tolSave.Enabled = False
        mnuToolImportS19.Enabled = False
        'grpComplete.Enabled = False

        radSameAsBoot.Visible = False
        radSameAsCompact.Visible = False

        lblRepeatStopTime.Visible = False
        txtRepeatStopTime.Visible = False

        tolNew.Image = mnuFileNew.Image
        tolOpen.Image = mnuFileOpen.Image
        tolSaveAs.Image = mnuFileSaveAs.Image
        tolSave.Image = mnuFileSave.Image
        mnuWaveFit.Image = tolFit.Image
        mnuWaveZoomIn.Image = tolZoomIn.Image
        mnuWaveZoomOut.Image = tolZoomOut.Image

        'panWave.Size = New Size(Me.ClientSize.Width, 140)
        'panWave.Location = New Point(0, mnuMain.Size.Height + tosMain.Size.Height)
        'hscWave.Size = New Size(Me.ClientSize.Width, 20)
        'hscWave.Location = New Point(0, panWave.Location.Y + panWave.Size.Height)
        fWaveStart = 0
        fWaveDuration = 100
        UpdateScroll()

        bInit = False
        bPan = False
        bZoom = False

        'For i = 0 To 255
        '    OTP(i) = &HFF
        'Next

        'lblKeyRemain.Enabled = False
        'txtKeyRemain.Enabled = False
        'lblDebounce.Enabled = False
        'cobDebounce.Enabled = False
        'radScanOneTime.Enabled = False
        'radScanCont.Enabled = False
        'lblScanInterval.Enabled = False
        'cobScanInterval.Enabled = False
        'lblLEDCurrent.Enabled = False
        'ckbLED.Enabled = False
        'cobLEDCurrent.Enabled = False
        'lblIRCurrent.Enabled = False
        'cobIRCurrent.Enabled = False
        'ckbRevertBitHi.Enabled = False
        'lblPostionHi.Enabled = False
        cobPositionHi.Enabled = False
        'lblBit1Option.Enabled = False
        'ckbBit1Option.Enabled = False
        lblData2Code.Enabled = False
        txtData2Code.Enabled = False
        lblData2ChangelessBits.Enabled = False
        cobData2ChangelessBits.Enabled = False
        lblChecksum.Enabled = False
        txtChecksum.Enabled = False
        'ckbData1Revert.Enabled = False
        ckbData2Revert.Enabled = False
        ckbUser2Revert.Enabled = False
        radChecksum.Visible = False
        lblChecksum.Visible = False
        txtChecksum.Visible = False
        radL7464_Xor.Enabled = False
        radL7464_Sum.Enabled = False
        txtUpKey.Enabled = False
        'lblRepeatDataBoundry.Visible = False
        'txtRepeatDataBoundry.Visible = False
        lblMultiUserBits.Visible = False
        lblRangeI.Visible = False
        lblRangeII.Visible = False
        lblRangeIII.Visible = False
        lblRangeKey1.Visible = False
        lblRangeKey2.Visible = False
        lblRangeKey3.Visible = False
        txtMultiUserCode1.Visible = False
        txtMultiUserCode2.Visible = False
        txtMultiUserCode3.Visible = False
        txtMultiUserBoundry1.Visible = False
        txtMultiUserBoundry2.Visible = False
        cobMultiUserBits.Visible = False
        lblMultiUserCode1.Visible = False
        lblMultiUserCode2.Visible = False
        lblMultiUserCode3.Visible = False

        lblRepeatGroupA.Enabled = False
        lblRepeatGroupB.Enabled = False
        lblRepeatModeGroupA.Enabled = False
        lblRepeatModeGroupB.Enabled = False
        lblRepeatGroupARange.Enabled = False
        lblRepeatGroupBRange.Enabled = False
        txtRepeatGroupBoundry.Enabled = False

        UpdateLabelRangeKey()

        '调试页隐藏
        tabSetting.TabPages(3).Parent = Nothing
        grpIROUTStructure.Visible = False
        grpFilterSelect.Visible = False

        'RemoveHandler trvFrame.DoubleClick, AddressOf trvFrame_DoubleClick

    End Sub

    Private Sub TextEnglishVersion()
        'Me.Text = My.Resources.Title

        mnuFile.Text = My.Resources.mnuFile
        mnuFileNew.Text = My.Resources.mnuFileNew
        mnuFileOpen.Text = My.Resources.mnuFileOpen
        mnuFileSave.Text = My.Resources.mnuFileSave
        mnuFileSaveAs.Text = My.Resources.mnuFileSaveAs
        mnuFileExit.Text = My.Resources.mnuFileExit
        mnuLanguage.Text = My.Resources.mnuLanguage
        mnuLangEnglish.Text = My.Resources.mnuLangEnglish
        mnuLangChinese.Text = My.Resources.mnuLangChinese_cn
        mnuHelp.Text = My.Resources.mnuHelp
        mnuHelpAbout.Text = My.Resources.mnuHelpAbout
        mnuWave.Text = My.Resources.mnuWave
        mnuWaveFit.Text = My.Resources.tolFit
        mnuWaveZoomIn.Text = My.Resources.tolZoomIn
        mnuWaveZoomOut.Text = My.Resources.tolZoomOut
        mnuTool.Text = My.Resources.mnuTool
        mnuToolExportS19.Text = My.Resources.mnuToolExportS19
        mnuToolImportS19.Text = My.Resources.mnuToolImportS19
        mnuToolImportKeyboard.Text = My.Resources.mnuToolImportKeyboard

        tabFrame.TabPages(0).Text = My.Resources.tabFrame
        tabSetting.TabPages(0).Text = My.Resources.tabSetting0
        tabSetting.TabPages(1).Text = My.Resources.tabSetting1
        tabSetting.TabPages(2).Text = My.Resources.tabSetting2

        trvFrame.Nodes(frameTreeTop.boot).Text = My.Resources.trvFrameBoot
        trvFrame.Nodes(frameTreeTop.user).Text = My.Resources.trvFrameUser
        trvFrame.Nodes(frameTreeTop.split).Text = My.Resources.trvFrameSplit
        trvFrame.Nodes(frameTreeTop.data).Text = My.Resources.trvFrameData
        trvFrame.Nodes(frameTreeTop.data).Nodes(frameTreeData.datacode1).Text = My.Resources.trvFrameDataCode1
        trvFrame.Nodes(frameTreeTop.data).Nodes(frameTreeData.usercode2).Text = My.Resources.trvFrameUserCode2
        trvFrame.Nodes(frameTreeTop.data).Nodes(frameTreeData.datacode2).Text = My.Resources.trvFrameDataCode2
        trvFrame.Nodes(frameTreeTop.stop0).Text = My.Resources.trvFrameStop
        trvFrame.Nodes(frameTreeTop.stop0).Nodes(frameTreeStop.stopbit).Text = My.Resources.trvFrameStopBit
        trvFrame.Nodes(frameTreeTop.stop0).Nodes(frameTreeStop.stopcode).Text = My.Resources.trvFrameStopCode
        trvFrame.Nodes(frameTreeTop.repeat).Text = My.Resources.trvFrameRepeat
        'trvFrame.Nodes(frameTreeTop.repeat).Nodes(frameTreeRepeat.compact).Text = My.Resources.trvFrameCompactRepeat
        'trvFrame.Nodes(frameTreeTop.repeat).Nodes(frameTreeRepeat.complete).Text = My.Resources.trvFrameCompleteRepeat

        grpGlobal.Text = My.Resources.grpGlobal

        grpLogic0.Text = My.Resources.grpLogic0
        grpLogic1.Text = My.Resources.grpLogic1
        grpCarrier.Text = My.Resources.grpCarrier
        grpDataDir.Text = My.Resources.grpDataDir
        grpLED.Text = My.Resources.grpLED
        grpIROUT.Text = My.Resources.grpIROUT
        grpKey.Text = My.Resources.grpKey
        grpOthers.Text = My.Resources.grpOthers

        radHtoL_L0.Text = My.Resources.radHighToLow
        radLtoH_L0.Text = My.Resources.radLowToHigh
        'lblFirst_L0.Text = My.Resources.lblLevelHigh
        'lblSecond_L0.Text = My.Resources.lblLevelLow
        radHtoL_L1.Text = My.Resources.radHighToLow
        radLtoH_L1.Text = My.Resources.radLowToHigh
        'lblFirst_L1.Text = My.Resources.lblLevelHigh
        'lblSecond_L1.Text = My.Resources.lblLevelLow
        lblDuty.Text = My.Resources.lblDuty
        lblCarrierFreq.Text = My.Resources.lblCarrierFreq
        radLowBitFirst.Text = My.Resources.radLowBitFirst
        radHighBitFirst.Text = My.Resources.radHighBitFirst
        lblLEDCurrent.Text = My.Resources.lblLEDCurrent
        radLEDHi.Text = My.Resources.radLEDHi
        radLEDLo.Text = My.Resources.radLEDLo
        lblIRCurrent.Text = My.Resources.lblIRCurrent
        lblKeyRemain.Text = My.Resources.lblKeyRemain
        lblDebounce.Text = My.Resources.lblDebounce
        radScanOneTime.Text = My.Resources.radScanOneTime
        radScanCont.Text = My.Resources.radScanCont
        lblScanInterval.Text = My.Resources.lblScanInterval
        lblInvalidKey.Text = My.Resources.lblInvalidKey
        ckbUpKeyEnable.Text = My.Resources.ckbUpKeyEnable
        ckbVDDKeyScan.Text = My.Resources.ckbVDDKeyScan
        ckbDoubleFrame.Text = My.Resources.ckbDoubleFrame
        ckbRepeatDataFrame.Text = My.Resources.ckbRepeatDataFrame
        ckbRepeatModeGroup.Text = My.Resources.ckbRepeatModeGroup
        lblRepeatGroupA.Text = My.Resources.lblRepeatGroupA
        lblRepeatGroupB.Text = My.Resources.lblRepeatGroupB
        lblRepeatModeGroupA.Text = My.Resources.radCompact
        lblRepeatModeGroupB.Text = My.Resources.radComplete
        ckbMultiUser.Text = My.Resources.ckbMultiUser
        lblMultiUserBits.Text = My.Resources.lblDataCode1Bits
        lblRangeI.Text = My.Resources.lblRangeI
        lblRangeII.Text = My.Resources.lblRangeII
        lblRangeIII.Text = My.Resources.lblRangeIII
        lblMultiUserCode1.Text = My.Resources.lblMultiUserCode
        lblMultiUserCode2.Text = My.Resources.lblMultiUserCode
        lblMultiUserCode3.Text = My.Resources.lblMultiUserCode

        FirstSecondLabel(False)
        FirstSecondLabel(True)

        grpBoot.Text = My.Resources.trvFrameBoot
        lblBootHigh.Text = My.Resources.lblLevelHigh
        lblBootLow.Text = My.Resources.lblLevelLow

        grpSplit.Text = My.Resources.trvFrameSplit
        lblSplitHigh.Text = My.Resources.lblLevelHigh
        lblSplitLow.Text = My.Resources.lblLevelLow

        grpUser.Text = My.Resources.trvFrameUser
        lblUserCode.Text = My.Resources.lblUserCode
        lblUserBits.Text = My.Resources.lblUserBits
        ckbRevertBitHi.Text = My.Resources.ckbRevertBitHi
        lblPositionHi.Text = My.Resources.lblPosition
        ckbRevertBitLo.Text = My.Resources.ckbRevertBitLo
        lblPositionLo.Text = My.Resources.lblPosition
        ckbBitExpand.Text = My.Resources.ckbBitExpand
        lblBit1Option.Text = My.Resources.lblBit1Option
        ckbBit1Option.Text = My.Resources.ckbBit1Option

        grpDataFrame.Text = My.Resources.grpDataFrame
        grpDataCode1.Text = My.Resources.trvFrameDataCode1
        lblDataCode1Bits.Text = My.Resources.lblDataCode1Bits
        ckbL7464Check.Text = My.Resources.ckbL7464Check
        radL7464_Xor.Text = My.Resources.radL7464_Xor
        radL7464_Sum.Text = My.Resources.radL7464_Sum
        ckb1986Enable.Text = My.Resources.ckb1986Enable

        grpUserCode2.Text = My.Resources.trvFrameUserCode2
        lblUserCode2.Text = My.Resources.trvFrameUserCode2
        lblUserCode2Bits.Text = My.Resources.lblDataCode1Bits

        grpDataCode2.Text = My.Resources.trvFrameDataCode2
        radRevertData1.Text = My.Resources.radRevertCode1
        radChecksum.Text = My.Resources.radChecksum
        lblChecksum.Text = My.Resources.lblChecksum
        radData2Changeless.Text = My.Resources.radData2Changeless
        lblData2Code.Text = My.Resources.lblData2Code
        lblData2ChangelessBits.Text = My.Resources.lblDataCode1Bits

        grpStopBit.Text = My.Resources.trvFrameStopBit
        radHtoL_Stop.Text = My.Resources.radHtoL_Stop
        radLtoH_Stop.Text = My.Resources.radLtoH_Stop
        If (radHtoL_Stop.Checked) Then
            lblStopBitFirst.Text = My.Resources.lblLevelHigh
            lblStopBitSecond.Text = My.Resources.lblLevelLow
        Else
            lblStopBitFirst.Text = My.Resources.lblLevelLow
            lblStopBitSecond.Text = My.Resources.lblLevelHigh
        End If

        grpStopCode.Text = My.Resources.trvFrameStopCode

        radDefineStopTime.Text = My.Resources.radDefineStopTime
        radDefineWholeFrame.Text = My.Resources.radDefineWholeFrame
        lblStopTime.Text = My.Resources.lblStopTime

        grpRepeat.Text = My.Resources.trvFrameRepeat
        radCompact.Text = My.Resources.radCompact
        radComplete.Text = My.Resources.radComplete
        lblHighRepeat.Text = My.Resources.lblLevelHigh
        lblLowRepeat.Text = My.Resources.lblLevelLow
        radHL0.Text = My.Resources.radHL0
        radHL01.Text = My.Resources.radHL01
        radHL11.Text = My.Resources.radHL11
        ckbBootCode.Text = My.Resources.ckbBootCode
        lblRepeatBootHigh.Text = My.Resources.lblLevelHigh
        lblRepeatBootLow.Text = My.Resources.lblLevelLow
        radSameAsCompact.Text = My.Resources.radSameAsCompact
        radSameAsBoot.Text = My.Resources.radSameAsBoot
        'radData1Repeat.Text = My.Resources.radData1Repeat
        ckbData1Revert.Text = My.Resources.ckbData1Revert
        ckbUser2Revert.Text = My.Resources.ckbUser2Revert
        ckbData2Revert.Text = My.Resources.ckbData2Revert
        lblRepeatStopTime.Text = My.Resources.lblRepeatStopTime

        tolNew.ToolTipText = My.Resources.mnuFileNew
        tolOpen.ToolTipText = My.Resources.mnuFileOpen
        tolSave.ToolTipText = My.Resources.mnuFileSave
        tolSaveAs.ToolTipText = My.Resources.mnuFileSaveAs
        tolZoomOut.ToolTipText = My.Resources.tolZoomOut
        tolZoomIn.ToolTipText = My.Resources.tolZoomIn
        tolFit.ToolTipText = My.Resources.tolFit

        lblPURes.Text = My.Resources.lblPURes

        btnImportKeyboard.Text = My.Resources.btnImportKeyboard

        lblSingleKeyNote.Text = "Single Key Setting"
        lblUsageNote.Text = "  Mouse Left: Select Key" & vbCr & "Mouse Right: Modify Key"
        'lblDoubleKeyNote.Text = "Double Key Setting"
        'lblTripleKeyNote.Text = "Triple Key Setting"
        lblInfoName.Text = "Name"
        lblInfoNote.Text = "Note"

        panWave.Invalidate()
    End Sub

    Private Sub TextChineseVersion()
        'Me.Text = My.Resources.Title

        mnuFile.Text = My.Resources.mnuFile_cn
        mnuFileNew.Text = My.Resources.mnuFileNew_cn
        mnuFileOpen.Text = My.Resources.mnuFileOpen_cn
        mnuFileSave.Text = My.Resources.mnuFileSave_cn
        mnuFileSaveAs.Text = My.Resources.mnuFileSaveAs_cn
        mnuFileExit.Text = My.Resources.mnuFileExit_cn
        mnuLanguage.Text = My.Resources.mnuLanguage_cn
        mnuLangEnglish.Text = My.Resources.mnuLangEnglish
        mnuLangChinese.Text = My.Resources.mnuLangChinese_cn
        mnuHelp.Text = My.Resources.mnuHelp_cn
        mnuHelpAbout.Text = My.Resources.mnuHelpAbout_cn
        mnuWave.Text = My.Resources.mnuWave_cn
        mnuWaveFit.Text = My.Resources.tolFit_cn
        mnuWaveZoomIn.Text = My.Resources.tolZoomIn_cn
        mnuWaveZoomOut.Text = My.Resources.tolZoomOut_cn
        mnuTool.Text = My.Resources.mnuTool_cn
        mnuToolExportS19.Text = My.Resources.mnuToolExportS19_cn
        mnuToolImportS19.Text = My.Resources.mnuToolImportS19_cn
        mnuToolImportKeyboard.Text = My.Resources.mnuToolImportKeyboard_cn

        tabFrame.TabPages(0).Text = My.Resources.tabFrame_cn
        tabSetting.TabPages(0).Text = My.Resources.tabSetting0_cn
        tabSetting.TabPages(1).Text = My.Resources.tabSetting1_cn
        tabSetting.TabPages(2).Text = My.Resources.tabSetting2_cn

        trvFrame.Nodes(frameTreeTop.boot).Text = My.Resources.trvFrameBoot_cn
        trvFrame.Nodes(frameTreeTop.user).Text = My.Resources.trvFrameUser_cn
        trvFrame.Nodes(frameTreeTop.split).Text = My.Resources.trvFrameSplit_cn
        trvFrame.Nodes(frameTreeTop.data).Text = My.Resources.trvFrameData_cn
        trvFrame.Nodes(frameTreeTop.data).Nodes(frameTreeData.datacode1).Text = My.Resources.trvFrameDataCode1_cn
        trvFrame.Nodes(frameTreeTop.data).Nodes(frameTreeData.usercode2).Text = My.Resources.trvFrameUserCode2_cn
        trvFrame.Nodes(frameTreeTop.data).Nodes(frameTreeData.datacode2).Text = My.Resources.trvFrameDataCode2_cn
        trvFrame.Nodes(frameTreeTop.stop0).Text = My.Resources.trvFrameStop_cn
        trvFrame.Nodes(frameTreeTop.stop0).Nodes(frameTreeStop.stopbit).Text = My.Resources.trvFrameStopBit_cn
        trvFrame.Nodes(frameTreeTop.stop0).Nodes(frameTreeStop.stopcode).Text = My.Resources.trvFrameStopCode_cn
        trvFrame.Nodes(frameTreeTop.repeat).Text = My.Resources.trvFrameRepeat_cn
        'trvFrame.Nodes(frameTreeTop.repeat).Nodes(frameTreeRepeat.compact).Text = My.Resources.trvFrameCompactRepeat_cn
        'trvFrame.Nodes(frameTreeTop.repeat).Nodes(frameTreeRepeat.complete).Text = My.Resources.trvFrameCompleteRepeat_cn

        grpGlobal.Text = My.Resources.grpGlobal_cn

        grpLogic0.Text = My.Resources.grpLogic0_cn
        grpLogic1.Text = My.Resources.grpLogic1_cn
        grpCarrier.Text = My.Resources.grpCarrier_cn
        grpDataDir.Text = My.Resources.grpDataDir_cn
        grpLED.Text = My.Resources.grpLED_cn
        grpIROUT.Text = My.Resources.grpIROUT_cn
        grpKey.Text = My.Resources.grpKey_cn
        grpOthers.Text = My.Resources.grpOthers_cn

        radHtoL_L0.Text = My.Resources.radHighToLow_cn
        radLtoH_L0.Text = My.Resources.radLowToHigh_cn
        'lblFirst_L0.Text = My.Resources.lblLevelHigh_cn
        'lblSecond_L0.Text = My.Resources.lblLevelLow_cn
        radHtoL_L1.Text = My.Resources.radHighToLow_cn
        radLtoH_L1.Text = My.Resources.radLowToHigh_cn
        'lblFirst_L1.Text = My.Resources.lblLevelHigh_cn
        'lblSecond_L1.Text = My.Resources.lblLevelLow_cn
        lblDuty.Text = My.Resources.lblDuty_cn
        lblCarrierFreq.Text = My.Resources.lblCarrierFreq_cn
        radLowBitFirst.Text = My.Resources.radLowBitFirst_cn
        radHighBitFirst.Text = My.Resources.radHighBitFirst_cn
        lblLEDCurrent.Text = My.Resources.lblLEDCurrent_cn
        radLEDHi.Text = My.Resources.radLEDHi_cn
        radLEDLo.Text = My.Resources.radLEDLo_cn
        lblIRCurrent.Text = My.Resources.lblIRCurrent_cn
        lblKeyRemain.Text = My.Resources.lblKeyRemain_cn
        lblDebounce.Text = My.Resources.lblDebounce_cn
        radScanOneTime.Text = My.Resources.radScanOneTime_cn
        radScanCont.Text = My.Resources.radScanCont_cn
        lblScanInterval.Text = My.Resources.lblScanInterval_cn
        lblInvalidKey.Text = My.Resources.lblInvalidKey_cn
        ckbUpKeyEnable.Text = My.Resources.ckbUpKeyEnable_cn
        ckbVDDKeyScan.Text = My.Resources.ckbVDDKeyScan_cn
        ckbDoubleFrame.Text = My.Resources.ckbDoubleFrame_cn
        ckbRepeatDataFrame.Text = My.Resources.ckbRepeatDataFrame_cn
        ckbRepeatModeGroup.Text = My.Resources.ckbRepeatModeGroup_cn
        lblRepeatGroupA.Text = My.Resources.lblRepeatGroupA_cn
        lblRepeatGroupB.Text = My.Resources.lblRepeatGroupB_cn
        lblRepeatModeGroupA.Text = My.Resources.radCompact_cn
        lblRepeatModeGroupB.Text = My.Resources.radComplete_cn

        ckbMultiUser.Text = My.Resources.ckbMultiUser_cn
        lblMultiUserBits.Text = My.Resources.lblDataCode1Bits_cn
        lblRangeI.Text = My.Resources.lblRangeI_cn
        lblRangeII.Text = My.Resources.lblRangeII_cn
        lblRangeIII.Text = My.Resources.lblRangeIII_cn
        lblMultiUserCode1.Text = My.Resources.lblMultiUserCode_cn
        lblMultiUserCode2.Text = My.Resources.lblMultiUserCode_cn
        lblMultiUserCode3.Text = My.Resources.lblMultiUserCode_cn

        FirstSecondLabel(False)
        FirstSecondLabel(True)

        grpBoot.Text = My.Resources.trvFrameBoot_cn
        lblBootHigh.Text = My.Resources.lblLevelHigh_cn
        lblBootLow.Text = My.Resources.lblLevelLow_cn

        grpSplit.Text = My.Resources.trvFrameSplit_cn
        lblSplitHigh.Text = My.Resources.lblLevelHigh_cn
        lblSplitLow.Text = My.Resources.lblLevelLow_cn

        grpUser.Text = My.Resources.trvFrameUser_cn
        lblUserCode.Text = My.Resources.lblUserCode_cn
        lblUserBits.Text = My.Resources.lblUserBits_cn
        ckbRevertBitHi.Text = My.Resources.ckbRevertBitHi_cn
        lblPositionHi.Text = My.Resources.lblPosition_cn
        ckbRevertBitLo.Text = My.Resources.ckbRevertBitLo_cn
        lblPositionLo.Text = My.Resources.lblPosition_cn
        ckbBitExpand.Text = My.Resources.ckbBitExpand_cn
        lblBit1Option.Text = My.Resources.lblBit1Option_cn
        ckbBit1Option.Text = My.Resources.ckbBit1Option_cn

        grpDataFrame.Text = My.Resources.grpDataFrame_cn
        grpDataCode1.Text = My.Resources.trvFrameDataCode1_cn
        lblDataCode1Bits.Text = My.Resources.lblDataCode1Bits_cn
        ckbL7464Check.Text = My.Resources.ckbL7464Check_cn
        radL7464_Xor.Text = My.Resources.radL7464_Xor_cn
        radL7464_Sum.Text = My.Resources.radL7464_Sum_cn
        ckb1986Enable.Text = My.Resources.ckb1986Enable_cn

        grpUserCode2.Text = My.Resources.trvFrameUserCode2_cn
        lblUserCode2.Text = My.Resources.trvFrameUserCode2_cn
        lblUserCode2Bits.Text = My.Resources.lblDataCode1Bits_cn

        grpDataCode2.Text = My.Resources.trvFrameDataCode2_cn
        radRevertData1.Text = My.Resources.radRevertCode1_cn
        radChecksum.Text = My.Resources.radChecksum_cn
        lblChecksum.Text = My.Resources.lblChecksum_cn
        radData2Changeless.Text = My.Resources.radData2Changeless_cn
        lblData2Code.Text = My.Resources.lblData2Code_cn
        lblData2ChangelessBits.Text = My.Resources.lblDataCode1Bits_cn

        grpStopBit.Text = My.Resources.trvFrameStopBit_cn
        radHtoL_Stop.Text = My.Resources.radHtoL_Stop_cn
        radLtoH_Stop.Text = My.Resources.radLtoH_Stop_cn

        If (radHtoL_Stop.Checked) Then
            lblStopBitFirst.Text = My.Resources.lblLevelHigh_cn
            lblStopBitSecond.Text = My.Resources.lblLevelLow_cn
        Else
            lblStopBitFirst.Text = My.Resources.lblLevelLow_cn
            lblStopBitSecond.Text = My.Resources.lblLevelHigh_cn
        End If

        grpStopCode.Text = My.Resources.trvFrameStopCode_cn

        radDefineStopTime.Text = My.Resources.radDefineStopTime_cn
        radDefineWholeFrame.Text = My.Resources.radDefineWholeFrame_cn
        lblStopTime.Text = My.Resources.lblStopTime_cn

        grpRepeat.Text = My.Resources.trvFrameRepeat_cn
        radCompact.Text = My.Resources.radCompact_cn
        radComplete.Text = My.Resources.radComplete_cn
        lblHighRepeat.Text = My.Resources.lblLevelHigh_cn
        lblLowRepeat.Text = My.Resources.lblLevelLow_cn
        radHL0.Text = My.Resources.radHL0_cn
        radHL01.Text = My.Resources.radHL01_cn
        radHL11.Text = My.Resources.radHL11_cn
        ckbBootCode.Text = My.Resources.ckbBootCode_cn
        lblRepeatBootHigh.Text = My.Resources.lblLevelHigh_cn
        lblRepeatBootLow.Text = My.Resources.lblLevelLow_cn
        radSameAsCompact.Text = My.Resources.radSameAsCompact_cn
        radSameAsBoot.Text = My.Resources.radSameAsBoot_cn
        'radData1Repeat.Text = My.Resources.radData1Repeat_cn
        ckbData1Revert.Text = My.Resources.ckbData1Revert_cn
        ckbUser2Revert.Text = My.Resources.ckbUser2Revert_cn
        ckbData2Revert.Text = My.Resources.ckbData2Revert_cn
        lblRepeatStopTime.Text = My.Resources.lblRepeatStopTime_cn

        tolNew.ToolTipText = My.Resources.mnuFileNew_cn
        tolOpen.ToolTipText = My.Resources.mnuFileOpen_cn
        tolSave.ToolTipText = My.Resources.mnuFileSave_cn
        tolSaveAs.ToolTipText = My.Resources.mnuFileSaveAs_cn
        tolZoomOut.ToolTipText = My.Resources.tolZoomOut_cn
        tolZoomIn.ToolTipText = My.Resources.tolZoomIn_cn
        tolFit.ToolTipText = My.Resources.tolFit_cn

        lblPURes.Text = My.Resources.lblPURes_cn

        btnImportKeyboard.Text = My.Resources.btnImportKeyboard_cn

        lblSingleKeyNote.Text = "单键设置"
        lblUsageNote.Text = "鼠标左键: 选择按键" & vbCr & "鼠标右键: 配置按键"
        'lblDoubleKeyNote.Text = "双键设置"
        'lblTripleKeyNote.Text = "三键设置"
        lblInfoName.Text = "命名"
        lblInfoNote.Text = "备注"

        panWave.Invalidate()
    End Sub

    Private Sub mnuLangChinese_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuLangChinese.Click
        mnuLangChinese.Checked = True
        mnuLangEnglish.Checked = False
        TextChineseVersion()
    End Sub

    Private Sub mnuLangEnglish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuLangEnglish.Click
        mnuLangChinese.Checked = False
        mnuLangEnglish.Checked = True
        TextEnglishVersion()
    End Sub

    Private Sub RefreshForm()
        Me.Text = My.Resources.Title & " [" & sCurrentFile & "]"

        radHtoL_L0.Checked = myRCType.bHtoL_L0
        radLtoH_L0.Checked = Not myRCType.bHtoL_L0
        txtFirst_L0.Text = myRCType.fFirst_L0.ToString("0.000")
        txtSecond_L0.Text = myRCType.fSecond_L0.ToString("0.000")
        FirstSecondLabel(False)

        radHtoL_L1.Checked = myRCType.bHtoL_L1
        radLtoH_L1.Checked = Not myRCType.bHtoL_L1
        txtFirst_L1.Text = myRCType.fFirst_L1.ToString("0.000")
        txtSecond_L1.Text = myRCType.fSecond_L1.ToString("0.000")
        FirstSecondLabel(True)

        txtCarrierFreq.Text = myRCType.fCarrierFreq.ToString("0.000")
        cobDuty.SelectedIndex = myRCType.nDuty

        radLowBitFirst.Checked = myRCType.bLowBitFirst
        radHighBitFirst.Checked = Not myRCType.bLowBitFirst

        ckbLED.Visible = True
        ckbLED.Checked = myRCType.bLedEnable
        cobLEDCurrent.Enabled = ckbLED.Checked
        cobLEDCurrent.SelectedIndex = myRCType.nLedCurrent
        radLEDHi.Checked = myRCType.bLedHigh
        radLEDLo.Checked = Not myRCType.bLedHigh

        cobIRCurrent.SelectedIndex = myRCType.nIroutCurrent

        ckbCountLimit.Checked = myRCType.bCountLimit
        txtKeyRemain.Enabled = myRCType.bCountLimit
        txtKeyRemain.Text = myRCType.nKeyRemainTime.ToString
        txtDebounce.Text = myRCType.fDebounce.ToString("0.000")
        radScanOneTime.Checked = myRCType.bScanOneTime
        radScanCont.Checked = Not myRCType.bScanOneTime
        cobScanInterval.Enabled = radScanCont.Checked
        cobScanInterval.SelectedIndex = myRCType.nScanInterval
        txtInvalidKey.Text = myRCType.nInvalidKeyCode.ToString("X2")
        ckbUpKeyEnable.Checked = myRCType.bUpKeyEnable
        txtUpKey.Text = myRCType.nUpKeyCode.ToString("X2")
        ckbVDDKeyScan.Checked = myRCType.bVDDKeyScan
        ckbDoubleFrame.Checked = myRCType.bDoubleFrame
        ckbRepeatDataFrame.Checked = myRCType.bRepeatDataFrame
        ckbRepeatModeGroup.Checked = myRCType.bRepeatModeGroup
        ckbMultiUser.Checked = myRCType.bMultiUser

        trvFrame.ExpandAll()
        trvFrame.Nodes(frameTreeTop.boot).Checked = myRCType.bBootFrame
        trvFrame.Nodes(frameTreeTop.user).Checked = myRCType.bUserFrame
        trvFrame.Nodes(frameTreeTop.split).Checked = myRCType.bSplitFrame
        trvFrame.Nodes(frameTreeTop.data).Checked = myRCType.bDataFrame
        trvFrame.Nodes(frameTreeTop.data).Nodes(frameTreeData.datacode1).Checked = myRCType.bDataCode1
        trvFrame.Nodes(frameTreeTop.data).Nodes(frameTreeData.usercode2).Checked = myRCType.bUserCode2
        trvFrame.Nodes(frameTreeTop.data).Nodes(frameTreeData.datacode2).Checked = myRCType.bDataCode2
        trvFrame.Nodes(frameTreeTop.stop0).Checked = myRCType.bStopFrame
        trvFrame.Nodes(frameTreeTop.stop0).Nodes(frameTreeStop.stopbit).Checked = myRCType.bStopBit
        trvFrame.Nodes(frameTreeTop.stop0).Nodes(frameTreeStop.stopcode).Checked = myRCType.bStopCode
        trvFrame.Nodes(frameTreeTop.repeat).Checked = myRCType.bRepeatFrame
        'trvFrame.Nodes(frameTreeTop.repeat).Nodes(frameTreeRepeat.compact).Checked = myRCType.bCompact
        'trvFrame.Nodes(frameTreeTop.repeat).Nodes(frameTreeRepeat.complete).Checked = Not myRCType.bCompact

        txtBootHigh.Text = myRCType.fBootHigh.ToString("0.000")
        txtBootLow.Text = myRCType.fBootLow.ToString("0.000")

        txtSplitHigh.Text = myRCType.fSplitHigh.ToString("0.000")
        txtSplitLow.Text = myRCType.fSplitLow.ToString("0.000")

        txtUserCode.Text = myRCType.nUserCode.ToString("X8")
        cobUserBits.SelectedIndex = myRCType.nUserBits - 1
        ckbRevertBitHi.Checked = myRCType.bRevertBitHi
        cobPositionHi.Enabled = myRCType.bRevertBitHi
        lblPositionHi.Enabled = myRCType.bRevertBitHi
        cobPositionHi.SelectedIndex = myRCType.nPositionHi - 16
        ckbRevertBitLo.Checked = myRCType.bRevertBitLo
        cobPositionLo.Enabled = myRCType.bRevertBitLo Or myRCType.bBitExpand
        lblPositionLo.Enabled = cobPositionLo.Enabled
        cobPositionLo.SelectedIndex = myRCType.nPositionLo
        ckbBitExpand.Checked = myRCType.bBitExpand
        ckbBit1Option.Checked = myRCType.bBit1Option

        cobDataCode1Bits.SelectedIndex = myRCType.nDataCode1Bits - 1
        ckbL7464Check.Checked = myRCType.bL7464Check
        radL7464_Xor.Checked = myRCType.bL7464_Xor
        radL7464_Sum.Checked = Not myRCType.bL7464_Xor
        ckb1986Enable.Checked = myRCType.b1986Enable

        txtUserCode2.Text = myRCType.nUserCode2.ToString("X4")
        cobUserCode2Bits.SelectedIndex = myRCType.nUserCode2Bits - 1

        If myRCType.nData2Choice = 0 Then
            radRevertData1.Checked = True
            radData2Changeless.Checked = False
            radChecksum.Checked = False
        ElseIf myRCType.nData2Choice = 1 Then
            radRevertData1.Checked = False
            radData2Changeless.Checked = True
            radChecksum.Checked = False
        Else
            radRevertData1.Checked = False
            radData2Changeless.Checked = False
            radChecksum.Checked = True
        End If

        txtData2Code.Text = myRCType.nDataCode2.ToString("X4")
        cobData2ChangelessBits.SelectedIndex = myRCType.nDataCode2Bits - 1
        txtChecksum.Text = myRCType.nChecksum.ToString("X2")

        radHtoL_Stop.Checked = myRCType.bHtoL_Stop
        radLtoH_Stop.Checked = Not myRCType.bHtoL_Stop
        txtStopBitFirst.Text = myRCType.fStopBitFirst.ToString("0.000")
        txtStopBitSecond.Text = myRCType.fStopBitSecond.ToString("0.000")

        radDefineStopTime.Checked = myRCType.bDefineStopTime
        radDefineWholeFrame.Checked = Not myRCType.bDefineStopTime
        txtStopTime.Text = myRCType.fStopTime.ToString("0.000")

        radCompact.Checked = Not myRCType.bCompleteRepeat
        radComplete.Checked = myRCType.bCompleteRepeat
        txtHighRepeat.Text = myRCType.fHighRepeat.ToString("0.000")
        txtLowRepeat.Text = myRCType.fLowRepeat.ToString("0.000")
        If myRCType.nRepeatHLX = 0 Then
            radHL0.Checked = True
            radHL01.Checked = False
            radHL11.Checked = False
        ElseIf myRCType.nRepeatHLX = 1 Then
            radHL0.Checked = False
            radHL01.Checked = True
            radHL11.Checked = False
        Else
            radHL0.Checked = False
            radHL01.Checked = False
            radHL11.Checked = True
        End If
        ckbBootCode.Checked = myRCType.bBootCode
        txtRepeatBootHigh.Text = myRCType.fRepeatBootHigh.ToString("0.000")
        txtRepeatBootLow.Text = myRCType.fRepeatBootLow.ToString("0.000")
        ckbData1Revert.Checked = myRCType.bData1Revert
        ckbUser2Revert.Checked = myRCType.bUser2Revert
        ckbData2Revert.Checked = myRCType.bData2Revert
        'radData1Revert.Checked = Not myRCType.bData1Repeat
        txtRepeatStopTime.Text = myRCType.fRepeatStopTime.ToString("0.000")

        txtRepeatGroupBoundry.Text = myRCType.nRepeatGroupBoundry.ToString("00")
        radSameAsBoot.Checked = myRCType.bSameAsBoot

        cobMultiUserBits.SelectedIndex = myRCType.nMultiUserBits - 1
        txtMultiUserBoundry1.Text = myRCType.nMultiUserBoundry1.ToString("00")
        txtMultiUserBoundry2.Text = myRCType.nMultiUserBoundry2.ToString("00")
        txtMultiUserCode1.Text = myRCType.nMultiUserCode1.ToString("X4")
        txtMultiUserCode2.Text = myRCType.nMultiUserCode2.ToString("X4")
        txtMultiUserCode3.Text = myRCType.nMultiUserCode3.ToString("X4")

        txtInfoName.Text = myRCType.sInfoName
        txtInfoNote.Text = myRCType.sInfoNote

        'For debug
        radFilterEnable.Checked = myRCType.bFilterEnable
        radFilterDisable.Checked = Not myRCType.bFilterEnable
        cobTempValue.SelectedIndex = myRCType.nTempValue
        radHighSpeed.Checked = myRCType.bHighSpeed
        radLowSpeed.Checked = Not myRCType.bHighSpeed
        radLDO17.Checked = myRCType.bLDO17
        radLDO15.Checked = Not myRCType.bLDO17
        cobDriveSpeed.SelectedIndex = myRCType.nDriveSpeed
        cobIRef.SelectedIndex = myRCType.nIRef
        rad60K.Checked = Not myRCType.b150K
        rad150K.Checked = myRCType.b150K
        radNotOD.Checked = myRCType.bNotOD
        radOD.Checked = Not myRCType.bNotOD
        radNotConn.Checked = myRCType.bNotConn
        radConn.Checked = Not myRCType.bNotConn

    End Sub

    Private Sub radHtoL_L0_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radHtoL_L0.CheckedChanged
        FirstSecondLabel(False)
        If Not bInit Then
            myRCType.bHtoL_L0 = radHtoL_L0.Checked
            panWave.Invalidate()
        End If

    End Sub

    Private Sub radHtoL_L1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radHtoL_L1.CheckedChanged
        FirstSecondLabel(True)
        If Not bInit Then
            myRCType.bHtoL_L1 = radHtoL_L1.Checked
            panWave.Invalidate()
        End If
    End Sub

    Private Sub FirstSecondLabel(ByVal sel As Boolean)
        Dim rad As RadioButton
        Dim lbl1 As Label
        Dim lbl2 As Label
        If (sel) Then
            rad = radHtoL_L1
            lbl1 = lblFirst_L1
            lbl2 = lblSecond_L1
        Else
            rad = radHtoL_L0
            lbl1 = lblFirst_L0
            lbl2 = lblSecond_L0
        End If

        If rad.Checked Then
            If mnuLangEnglish.Checked Then
                lbl1.Text = My.Resources.lblLevelHigh
                lbl2.Text = My.Resources.lblLevelLow
            Else
                lbl1.Text = My.Resources.lblLevelHigh_cn
                lbl2.Text = My.Resources.lblLevelLow_cn
            End If
        Else
            If mnuLangEnglish.Checked Then
                lbl1.Text = My.Resources.lblLevelLow
                lbl2.Text = My.Resources.lblLevelHigh
            Else
                lbl1.Text = My.Resources.lblLevelLow_cn
                lbl2.Text = My.Resources.lblLevelHigh_cn
            End If
        End If
    End Sub

    Private Sub ckbLED_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbLED.CheckedChanged
        cobLEDCurrent.Enabled = ckbLED.Checked
        radLEDHi.Enabled = ckbLED.Checked
        radLEDLo.Enabled = ckbLED.Checked

        If Not bInit Then
            myRCType.bLedEnable = ckbLED.Checked
            'panWave.Invalidate()
        End If
    End Sub


    Private Sub ckbCountLimit_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbCountLimit.CheckedChanged
        txtKeyRemain.Enabled = ckbCountLimit.Checked
        If Not bInit Then
            myRCType.bCountLimit = ckbCountLimit.Checked
            'panWave.Invalidate()
        End If
    End Sub


    Private Sub ckbDoubleFrame_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbDoubleFrame.CheckedChanged
        If Not bInit Then
            myRCType.bDoubleFrame = ckbDoubleFrame.Checked
            'panWave.Invalidate()
        End If
    End Sub

    Private Sub ckbRepeatDataFrame_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbRepeatDataFrame.CheckedChanged
        'lblRepeatDataBoundry.Visible = ckbRepeatDataFrame.Checked
        'txtRepeatDataBoundry.Visible = ckbRepeatDataFrame.Checked
        If Not bInit Then
            myRCType.bRepeatDataFrame = ckbRepeatDataFrame.Checked
            panWave.Invalidate()
        End If
    End Sub

    Private Sub ckbRepeatModeGroup_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbRepeatModeGroup.CheckedChanged
        lblRepeatGroupA.Enabled = ckbRepeatModeGroup.Checked
        lblRepeatGroupB.Enabled = ckbRepeatModeGroup.Checked
        lblRepeatModeGroupA.Enabled = ckbRepeatModeGroup.Checked
        lblRepeatModeGroupB.Enabled = ckbRepeatModeGroup.Checked
        lblRepeatGroupARange.Enabled = ckbRepeatModeGroup.Checked
        lblRepeatGroupBRange.Enabled = ckbRepeatModeGroup.Checked
        txtRepeatGroupBoundry.Enabled = ckbRepeatModeGroup.Checked

        radSameAsBoot.Visible = ckbRepeatModeGroup.Checked
        radSameAsCompact.Visible = ckbRepeatModeGroup.Checked
        lblRepeatBootHigh.Visible = Not ckbRepeatModeGroup.Checked
        lblRepeatBootLow.Visible = Not ckbRepeatModeGroup.Checked
        txtRepeatBootHigh.Visible = Not ckbRepeatModeGroup.Checked
        txtRepeatBootLow.Visible = Not ckbRepeatModeGroup.Checked

        If Not bInit Then
            myRCType.bRepeatModeGroup = ckbRepeatModeGroup.Checked
            panWave.Invalidate()
        End If
    End Sub

    Private Sub ckbMultiUser_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbMultiUser.CheckedChanged
        lblMultiUserBits.Visible = ckbMultiUser.Checked
        lblRangeI.Visible = ckbMultiUser.Checked
        lblRangeII.Visible = ckbMultiUser.Checked
        lblRangeIII.Visible = ckbMultiUser.Checked
        lblRangeKey1.Visible = ckbMultiUser.Checked
        lblRangeKey2.Visible = ckbMultiUser.Checked
        lblRangeKey3.Visible = ckbMultiUser.Checked
        txtMultiUserCode1.Visible = ckbMultiUser.Checked
        txtMultiUserCode2.Visible = ckbMultiUser.Checked
        txtMultiUserCode3.Visible = ckbMultiUser.Checked
        txtMultiUserBoundry1.Visible = ckbMultiUser.Checked
        txtMultiUserBoundry2.Visible = ckbMultiUser.Checked
        cobMultiUserBits.Visible = ckbMultiUser.Checked
        lblMultiUserCode1.Visible = ckbMultiUser.Checked
        lblMultiUserCode2.Visible = ckbMultiUser.Checked
        lblMultiUserCode3.Visible = ckbMultiUser.Checked
        grpUser.Enabled = Not ckbMultiUser.Checked
        grpUserCode2.Enabled = Not ckbMultiUser.Checked

        If Not bInit Then
            myRCType.bMultiUser = ckbMultiUser.Checked
            panWave.Invalidate()
        End If
    End Sub

    Private Sub ckbL7464Check_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbL7464Check.CheckedChanged
        lblDataCode1Bits.Enabled = Not ckbL7464Check.Checked
        cobDataCode1Bits.Enabled = Not ckbL7464Check.Checked
        radL7464_Xor.Enabled = ckbL7464Check.Checked
        radL7464_Sum.Enabled = ckbL7464Check.Checked
        If Not bInit Then
            myRCType.bL7464Check = ckbL7464Check.Checked
            panWave.Invalidate()
        End If
    End Sub

    Private Sub ckb1986Enable_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckb1986Enable.CheckedChanged
        If Not bInit Then
            myRCType.b1986Enable = ckb1986Enable.Checked
            panWave.Invalidate()
        End If
    End Sub

    Private Sub ckbUpKeyEnable_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbUpKeyEnable.CheckedChanged
        txtUpKey.Enabled = ckbUpKeyEnable.Checked
        If Not bInit Then
            myRCType.bUpKeyEnable = ckbUpKeyEnable.Checked
            'panWave.Invalidate()
        End If
    End Sub

    Private Sub ckbVDDKeyScan_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbVDDKeyScan.CheckedChanged
        If Not bInit Then
            myRCType.bVDDKeyScan = ckbVDDKeyScan.Checked
            'panWave.Invalidate()
            If ckbVDDKeyScan.Checked Then
                lblVDDS10.Text = "VDD"
                lblS10.Text = ""
                btnAllSingle(65).Visible = False
            Else
                lblVDDS10.Text = "S10"
                lblS10.Text = "S10"
                btnAllSingle(65).Visible = True
            End If
        End If
    End Sub


    Private Sub radScanCont_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radScanCont.CheckedChanged
        cobScanInterval.Enabled = radScanCont.Checked
    End Sub

    Private Function CheckError() As Boolean
        'Dim i As Integer, j As Integer
        Dim dkey(1, 6) As Byte
        'Dim sx1 As Integer, sy1 As Integer
        'Dim sx2 As Integer, sy2 As Integer

        If errProvider.Tag And errType.errGlobalFormat Then
            If mnuLangEnglish.Checked Then
                MessageBox.Show("Input Error" & vbCr & My.Resources.grpGlobal, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("输入错误" & vbCr & My.Resources.grpGlobal_cn, "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        ElseIf errProvider.Tag And errType.errBoot Then
            If mnuLangEnglish.Checked Then
                MessageBox.Show("Input Error" & vbCr & My.Resources.trvFrameBoot, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("输入错误" & vbCr & My.Resources.trvFrameBoot_cn, "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        ElseIf errProvider.Tag And errType.errSplit Then
            If mnuLangEnglish.Checked Then
                MessageBox.Show("Input Error" & vbCr & My.Resources.trvFrameSplit, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("输入错误" & vbCr & My.Resources.trvFrameSplit_cn, "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        ElseIf errProvider.Tag And errType.errUser Then
            If mnuLangEnglish.Checked Then
                MessageBox.Show("Input Error" & vbCr & My.Resources.trvFrameUser, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("输入错误" & vbCr & My.Resources.trvFrameUser_cn, "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        ElseIf errProvider.Tag And errType.errUserCode2 Then
            If mnuLangEnglish.Checked Then
                MessageBox.Show("Input Error" & vbCr & My.Resources.trvFrameUserCode2, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("输入错误" & vbCr & My.Resources.trvFrameUserCode2_cn, "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        ElseIf errProvider.Tag And errType.errDataCode2 Then
            If mnuLangEnglish.Checked Then
                MessageBox.Show("Input Error" & vbCr & My.Resources.trvFrameDataCode2, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("输入错误" & vbCr & My.Resources.trvFrameDataCode2_cn, "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        ElseIf errProvider.Tag And errType.errStopBit Then
            If mnuLangEnglish.Checked Then
                MessageBox.Show("Input Error" & vbCr & My.Resources.trvFrameStopBit, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("输入错误" & vbCr & My.Resources.trvFrameStopBit_cn, "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        ElseIf errProvider.Tag And errType.errStopCode Then
            If mnuLangEnglish.Checked Then
                MessageBox.Show("Input Error" & vbCr & My.Resources.trvFrameStopCode, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("输入错误" & vbCr & My.Resources.trvFrameStopCode_cn, "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        ElseIf errProvider.Tag And errType.errRepeat Then
            If mnuLangEnglish.Checked Then
                MessageBox.Show("Input Error" & vbCr & My.Resources.trvFrameRepeat, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("输入错误" & vbCr & My.Resources.trvFrameRepeat_cn, "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        ElseIf errProvider.Tag And errType.errKey Then
            If mnuLangEnglish.Checked Then
                MessageBox.Show("Input Error" & vbCr & My.Resources.tabSetting1, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("输入错误" & vbCr & My.Resources.tabSetting1_cn, "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        Else
            'For i = 0 To 6

            '    If GetKeyXY(myRCType.nDKX(0, i), sx1, sy1) = False Or GetKeyXY(myRCType.nDKX(1, i), sx2, sy2) = False Then
            '        dkey(0, i) = &HFF
            '        dkey(1, i) = &HFF
            '    Else
            '        If sx1 = sx2 Or sy1 = sx2 Then
            '            dkey(0, i) = sx1 * 16 + sy1
            '            dkey(1, i) = sx1 * 16 + sy2
            '        ElseIf sx1 = sy2 Then
            '            dkey(0, i) = sx2 * 16 + sy1
            '            dkey(1, i) = sx2 * 16 + sy2
            '        ElseIf sy1 = sy2 Then
            '            If sx1 < sx2 Then
            '                dkey(0, i) = sx1 * 16 + sx2
            '                dkey(1, i) = sx1 * 16 + sy2
            '            Else
            '                dkey(0, i) = sx2 * 16 + sx1
            '                dkey(1, i) = sx2 * 16 + sy2
            '            End If
            '        Else
            '            dkey(0, i) = sx1 * 16 + sy1
            '            dkey(1, i) = sx2 * 16 + sy2
            '        End If
            '    End If
            'Next i

            'For i = 1 To 6

            '    For j = 0 To i - 1
            '        If dkey(0, i) = dkey(0, j) And dkey(1, i) = dkey(1, j) _
            '                And dkey(0, j) <> &HFF And dkey(1, j) <> &HFF Then
            '            If mnuLangEnglish.Checked Then
            '                MessageBox.Show("Double Key Conflict" & vbCr & "DK" & j.ToString & " & DK" & i.ToString, "Double Key Conflict", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '            Else
            '                MessageBox.Show("双键冲突" & vbCr & "DK" & j.ToString & " & DK" & i.ToString, "双键冲突", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '            End If
            '            Return False
            '        End If
            '    Next
            'Next
            'If myRCType.nTKX(0, 0) = myRCType.nTKX(0, 1) And myRCType.nTKX(1, 0) = myRCType.nTKX(1, 1) And myRCType.nTKX(2, 0) = myRCType.nTKX(2, 1) _
            '                And myRCType.nTKX(0, 0) <> &HFF And myRCType.nTKX(1, 0) <> &HFF And myRCType.nTKX(2, 0) <> &HFF Then
            '    If mnuLangEnglish.Checked Then
            '        MessageBox.Show("Triple Key Conflict" & vbCr & "TK0 & TK1", "Triple Key Conflict", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Else
            '        MessageBox.Show("三键冲突" & vbCr & "TK0 & TK1", "三键冲突", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    End If
            '    Return False
            'End If
            Return True
        End If
    End Function

    'Private Sub FormToRCType()
    '    Dim s(8) As Char

    '    myRCType.bHtoL_L0 = radHtoL_L0.Checked
    '    myRCType.fFirst_L0 = Convert.ToSingle(txtFirst_L0.Text)
    '    myRCType.fSecond_L0 = Convert.ToSingle(txtSecond_L0.Text)
    '    myRCType.bHtoL_L1 = radHtoL_L1.Checked
    '    myRCType.fFirst_L1 = Convert.ToSingle(txtFirst_L1.Text)
    '    myRCType.fSecond_L1 = Convert.ToSingle(txtSecond_L1.Text)
    '    myRCType.fCarrierFreq = Convert.ToSingle(txtCarrierFreq.Text)
    '    myRCType.nDuty = cobDuty.SelectedIndex
    '    myRCType.bLowBitFirst = radLowBitFirst.Checked
    '    myRCType.bLedEnable = ckbLED.Checked
    '    myRCType.nLedCurrent = cobLEDCurrent.SelectedIndex
    '    myRCType.nIroutCurrent = cobIRCurrent.SelectedIndex
    '    myRCType.fKeyRemainTime = Convert.ToSingle(txtKeyRemain.Text)
    '    myRCType.nDebounce = cobDebounce.SelectedIndex
    '    myRCType.bScanOneTime = radScanOneTime.Checked
    '    myRCType.nScanInterval = cobScanInterval.SelectedIndex
    '    s(1) = Convert.ToChar(txtInvalidKey.Text.Substring(0, 1))
    '    s(0) = Convert.ToChar(txtInvalidKey.Text.Substring(1, 1))
    '    myRCType.nInvalidKeyCode = Hex2Dec(s(1)) * 16 + Hex2Dec(s(0))
    '    myRCType.bBootFrame = trvFrame.Nodes(frameTreeTop.boot).Checked
    '    myRCType.bUserFrame = trvFrame.Nodes(frameTreeTop.user).Checked
    '    myRCType.bSplitFrame = trvFrame.Nodes(frameTreeTop.split).Checked
    '    myRCType.bDataFrame = trvFrame.Nodes(frameTreeTop.data).Checked
    '    myRCType.bDataCode1 = trvFrame.Nodes(frameTreeTop.data).Nodes(frameTreeData.datacode1).Checked
    '    myRCType.bUserCode2 = trvFrame.Nodes(frameTreeTop.data).Nodes(frameTreeData.usercode2).Checked
    '    myRCType.bDataCode2 = trvFrame.Nodes(frameTreeTop.data).Nodes(frameTreeData.datacode2).Checked
    '    myRCType.bStopFrame = trvFrame.Nodes(frameTreeTop.stop0).Checked
    '    myRCType.bStopBit = trvFrame.Nodes(frameTreeTop.stop0).Nodes(frameTreeStop.stopbit).Checked
    '    myRCType.bStopCode = trvFrame.Nodes(frameTreeTop.stop0).Nodes(frameTreeStop.stopcode).Checked
    '    myRCType.bRepeatFrame = trvFrame.Nodes(frameTreeTop.repeat).Checked
    '    'myRCType.bCompact = trvFrame.Nodes(frameTreeTop.repeat).Nodes(frameTreeRepeat.compact).Checked
    '    'myRCType.bComplete = trvFrame.Nodes(frameTreeTop.repeat).Nodes(frameTreeRepeat.complete).Checked
    '    myRCType.fBootHigh = Convert.ToSingle(txtBootHigh.Text)
    '    myRCType.fBootLow = Convert.ToSingle(txtBootLow.Text)
    '    myRCType.fSplitHigh = Convert.ToSingle(txtSplitHigh.Text)
    '    myRCType.fSplitLow = Convert.ToSingle(txtSplitLow.Text)
    '    s(7) = Convert.ToChar(txtUserCode.Text.Substring(0, 1))
    '    s(6) = Convert.ToChar(txtUserCode.Text.Substring(1, 1))
    '    s(5) = Convert.ToChar(txtUserCode.Text.Substring(2, 1))
    '    s(4) = Convert.ToChar(txtUserCode.Text.Substring(3, 1))
    '    s(3) = Convert.ToChar(txtUserCode.Text.Substring(4, 1))
    '    s(2) = Convert.ToChar(txtUserCode.Text.Substring(5, 1))
    '    s(1) = Convert.ToChar(txtUserCode.Text.Substring(6, 1))
    '    s(0) = Convert.ToChar(txtUserCode.Text.Substring(7, 1))
    '    myRCType.nUserCode = Hex2Dec(s(7)) * &H10000000 + Hex2Dec(s(6)) * &H1000000 + Hex2Dec(s(5)) * &H100000 + Hex2Dec(s(4)) * &H10000 + _
    '        Hex2Dec(s(3)) * &H1000 + Hex2Dec(s(2)) * &H100 + Hex2Dec(s(1)) * &H10 + Hex2Dec(s(0))
    '    myRCType.nUserBits = cobUserBits.SelectedIndex + 2
    '    myRCType.bRevertBit = ckbRevertBit.Checked
    '    myRCType.nPosition = cobPosition.SelectedIndex
    '    myRCType.bBit1Option = ckbBit1Option.Checked
    '    myRCType.nDataCode1Bits = cobDataCode1Bits.SelectedIndex + 2
    '    s(3) = Convert.ToChar(txtUserCode2.Text.Substring(0, 1))
    '    s(2) = Convert.ToChar(txtUserCode2.Text.Substring(1, 1))
    '    s(1) = Convert.ToChar(txtUserCode2.Text.Substring(2, 1))
    '    s(0) = Convert.ToChar(txtUserCode2.Text.Substring(3, 1))
    '    myRCType.nUserCode2 = Hex2Dec(s(3)) * &H1000 + Hex2Dec(s(2)) * &H100 + Hex2Dec(s(1)) * &H10 + Hex2Dec(s(0))
    '    myRCType.nUserCode2Bits = cobUserCode2Bits.SelectedIndex + 1
    '    myRCType.bRevertData1 = radRevertData1.Checked
    '    s(1) = Convert.ToChar(txtChecksum.Text.Substring(0, 1))
    '    s(0) = Convert.ToChar(txtChecksum.Text.Substring(1, 1))
    '    myRCType.nChecksum = Hex2Dec(s(1)) * 16 + Hex2Dec(s(0))
    '    myRCType.bHtoL_Stop = radHtoL_Stop.Checked
    '    myRCType.fStopBitTime = Convert.ToSingle(txtStopBitTime.Text)
    '    myRCType.fStopTime = Convert.ToSingle(txtStopTime.Text)
    '    myRCType.bCompleteRepeat = radComplete.Checked
    '    myRCType.fHighRepeat = Convert.ToSingle(txtHighRepeat.Text)
    '    myRCType.fLowRepeat = Convert.ToSingle(txtLowRepeat.Text)
    '    If radHL0.Checked Then
    '        myRCType.nRepeatHLX = 0
    '    ElseIf radHL01.Checked Then
    '        myRCType.nRepeatHLX = 1
    '    Else
    '        myRCType.nRepeatHLX = 2
    '    End If
    '    myRCType.bBootCode = ckbBootCode.Checked
    '    myRCType.bData1Repeat = radData1Repeat.Checked

    'End Sub

    Private Sub mnuFileSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileSave.Click, tolSave.Click
        Me.ActiveControl = CType(cobDuty, Control)
        If CheckError() Then
            'FormToRCType()
            SaveRCTFile(My.Computer.FileSystem.CombinePath(sCurrentPath, sCurrentFile))
        End If
    End Sub


    Private Sub SaveRCTFile(ByVal sName As String)

        Dim bw As BinaryWriter
        Dim i As Integer
        Try
            bw = New BinaryWriter(File.Open(sName, FileMode.Create))
            bw.Write(HEAD_RCT_FILE)
            bw.Write(myRCType.bHtoL_L0)
            bw.Write(myRCType.fFirst_L0)
            bw.Write(myRCType.fSecond_L0)
            bw.Write(myRCType.bHtoL_L1)
            bw.Write(myRCType.fFirst_L1)
            bw.Write(myRCType.fSecond_L1)
            bw.Write(myRCType.fCarrierFreq)
            bw.Write(myRCType.nDuty)
            bw.Write(myRCType.bLowBitFirst)
            bw.Write(myRCType.bLedEnable)
            bw.Write(myRCType.nLedCurrent)
            bw.Write(myRCType.bLedHigh)
            bw.Write(myRCType.nIroutCurrent)
            If myRCType.bCountLimit Then
                bw.Write(myRCType.nKeyRemainTime)
            Else
                bw.Write(myRCType.nKeyRemainTime + 100000)
            End If
            bw.Write(myRCType.fDebounce)
            bw.Write(myRCType.bScanOneTime)
            bw.Write(myRCType.nScanInterval)
            bw.Write(myRCType.nInvalidKeyCode)
            bw.Write(myRCType.bUpKeyEnable)
            bw.Write(myRCType.nUpKeyCode)
            bw.Write(myRCType.bVDDKeyScan)
            bw.Write(myRCType.bDoubleFrame)
            bw.Write(myRCType.bBootFrame)
            bw.Write(myRCType.bUserFrame)
            bw.Write(myRCType.bSplitFrame)
            bw.Write(myRCType.bDataFrame)
            bw.Write(myRCType.bDataCode1)
            bw.Write(myRCType.bUserCode2)
            bw.Write(myRCType.bDataCode2)
            bw.Write(myRCType.bStopFrame)
            bw.Write(myRCType.bStopBit)
            bw.Write(myRCType.bStopCode)
            bw.Write(myRCType.bRepeatFrame)
            'bw.Write(myRCType.bCompact)
            'bw.Write(myRCType.bComplete)
            bw.Write(myRCType.fBootHigh)
            bw.Write(myRCType.fBootLow)
            bw.Write(myRCType.fSplitHigh)
            bw.Write(myRCType.fSplitLow)
            bw.Write(myRCType.nUserCode)
            bw.Write(myRCType.nUserBits)
            bw.Write(myRCType.bRevertBitHi)
            bw.Write(myRCType.nPositionHi)
            bw.Write(myRCType.bRevertBitLo)
            bw.Write(myRCType.bBitExpand)
            bw.Write(myRCType.nPositionLo)
            bw.Write(myRCType.bBit1Option)
            bw.Write(myRCType.nDataCode1Bits)
            bw.Write(myRCType.bL7464Check)
            bw.Write(myRCType.bL7464_Xor)
            bw.Write(myRCType.b1986Enable)
            bw.Write(myRCType.nUserCode2)
            bw.Write(myRCType.nUserCode2Bits)
            bw.Write(myRCType.nData2Choice)
            bw.Write(myRCType.nDataCode2Bits)
            bw.Write(myRCType.nDataCode2)
            bw.Write(myRCType.nChecksum)
            bw.Write(myRCType.bHtoL_Stop)
            bw.Write(myRCType.fStopBitFirst)
            bw.Write(myRCType.fStopBitSecond)
            bw.Write(myRCType.bDefineStopTime)
            bw.Write(myRCType.fStopTime)
            bw.Write(myRCType.bCompleteRepeat)
            bw.Write(myRCType.fHighRepeat)
            bw.Write(myRCType.fLowRepeat)
            bw.Write(myRCType.nRepeatHLX)
            bw.Write(myRCType.bBootCode)
            bw.Write(myRCType.fRepeatBootHigh)
            bw.Write(myRCType.fRepeatBootLow)
            bw.Write(myRCType.bData1Revert)
            bw.Write(myRCType.bUser2Revert)
            bw.Write(myRCType.bData2Revert)
            bw.Write(myRCType.fRepeatStopTime)
            bw.Write(myRCType.nPressKey)

            bw.Write(myRCType.bRepeatDataFrame)
            bw.Write(myRCType.bMultiUser)
            bw.Write(myRCType.nMultiUserBits)
            bw.Write(myRCType.nMultiUserBoundry1)
            bw.Write(myRCType.nMultiUserBoundry2)
            bw.Write(myRCType.nMultiUserCode1)
            bw.Write(myRCType.nMultiUserCode2)
            bw.Write(myRCType.nMultiUserCode3)
            bw.Write(myRCType.bRepeatModeGroup)
            bw.Write(myRCType.nRepeatGroupBoundry)
            bw.Write(myRCType.bSameAsBoot)

            For i = 0 To 90
                bw.Write(myRCType.nSingleKey(i))
                bw.Write(myRCType.sSingleKeyLabel(i))
            Next

            'For i = 0 To 7
            '    bw.Write(myRCType.nDoubleKey(i))
            '    bw.Write(myRCType.sDoubleKeyLabel(i))
            '    bw.Write(myRCType.nDKX(0, i))
            '    bw.Write(myRCType.nDKX(1, i))
            'Next

            'For i = 0 To 1
            '    bw.Write(myRCType.nTripleKey(i))
            '    bw.Write(myRCType.sTripleKeyLabel(i))
            '    bw.Write(myRCType.nTKX(0, i))
            '    bw.Write(myRCType.nTKX(1, i))
            '    bw.Write(myRCType.nTKX(2, i))
            'Next

            Dim nNull As Byte = 0
            Dim sNull As String = "null"
            Dim inNull As Integer = 0

            For i = 0 To 7
                bw.Write(nNull)
                bw.Write(sNull)
                bw.Write(inNull)
                bw.Write(inNull)
            Next

            For i = 0 To 1
                bw.Write(nNull)
                bw.Write(sNull)
                bw.Write(inNull)
                bw.Write(inNull)
                bw.Write(inNull)
            Next


            bw.Write(myRCType.sInfoName)
            bw.Write(myRCType.sInfoNote)

            'For Debug
            bw.Write(myRCType.bFilterEnable)
            bw.Write(myRCType.nTempValue)
            bw.Write(myRCType.bHighSpeed)
            bw.Write(myRCType.bLDO17)
            bw.Write(myRCType.nDriveSpeed)
            bw.Write(myRCType.nIRef)
            bw.Write(myRCType.b150K)
            bw.Write(myRCType.bNotOD)
            bw.Write(myRCType.bNotConn)

            bw.Write(TAIL_RCT_FILE)
            bw.Close()

            If mnuLangEnglish.Checked Then
                MessageBox.Show(sName & " saved.", "Save")
            Else
                MessageBox.Show(sName & " 保存完毕.", "保存")
            End If
            Me.Text = My.Resources.Title & " [" & sCurrentFile & "]"
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Function LoadRCTFile(ByVal sName As String) As Boolean
        Dim br As BinaryReader
        Dim i As Integer
        Try
            'If My.Computer.FileSystem.GetFileInfo(sName).Length <> LEN_RCT_FILE Then
            '    MessageBox.Show("RCT File size incorrect!")
            '    Return False
            'End If
            br = New BinaryReader(File.Open(sName, FileMode.Open))
            If Not br.ReadString() = HEAD_RCT_FILE Then
                MessageBox.Show("RCT Head error!")
                Return False
            End If

            br.BaseStream.Seek(-TAIL_RCT_FILE.Length - 1, SeekOrigin.End)
            'Dim a As Byte = br.ReadByte
            If Not br.ReadString() = TAIL_RCT_FILE Then
                MessageBox.Show("RCT Tail error!")
                Return False
            End If

            br.BaseStream.Seek(0, SeekOrigin.Begin)
            br.ReadString()

            myRCType.bHtoL_L0 = br.ReadBoolean
            myRCType.fFirst_L0 = br.ReadSingle
            myRCType.fSecond_L0 = br.ReadSingle
            myRCType.bHtoL_L1 = br.ReadBoolean
            myRCType.fFirst_L1 = br.ReadSingle
            myRCType.fSecond_L1 = br.ReadSingle
            myRCType.fCarrierFreq = br.ReadSingle
            myRCType.nDuty = br.ReadInt32
            myRCType.bLowBitFirst = br.ReadBoolean
            myRCType.bLedEnable = br.ReadBoolean
            myRCType.nLedCurrent = br.ReadInt32
            myRCType.bLedHigh = br.ReadBoolean
            myRCType.nIroutCurrent = br.ReadInt32
            myRCType.nKeyRemainTime = br.ReadInt32
            If myRCType.nKeyRemainTime >= 100000 Then
                myRCType.nKeyRemainTime -= 100000
                myRCType.bCountLimit = False
            Else
                myRCType.bCountLimit = True
            End If
            myRCType.fDebounce = br.ReadSingle
            myRCType.bScanOneTime = br.ReadBoolean
            myRCType.nScanInterval = br.ReadInt32
            myRCType.nInvalidKeyCode = br.ReadByte
            myRCType.bUpKeyEnable = br.ReadBoolean
            myRCType.nUpKeyCode = br.ReadByte
            myRCType.bVDDKeyScan = br.ReadBoolean
            myRCType.bDoubleFrame = br.ReadBoolean
            myRCType.bBootFrame = br.ReadBoolean
            myRCType.bUserFrame = br.ReadBoolean
            myRCType.bSplitFrame = br.ReadBoolean
            myRCType.bDataFrame = br.ReadBoolean
            myRCType.bDataCode1 = br.ReadBoolean
            myRCType.bUserCode2 = br.ReadBoolean
            myRCType.bDataCode2 = br.ReadBoolean
            myRCType.bStopFrame = br.ReadBoolean
            myRCType.bStopBit = br.ReadBoolean
            myRCType.bStopCode = br.ReadBoolean
            myRCType.bRepeatFrame = br.ReadBoolean
            'myRCType.bCompact = br.ReadBoolean
            'myRCType.bComplete = br.ReadBoolean
            myRCType.fBootHigh = br.ReadSingle
            myRCType.fBootLow = br.ReadSingle
            myRCType.fSplitHigh = br.ReadSingle
            myRCType.fSplitLow = br.ReadSingle
            myRCType.nUserCode = br.ReadUInt32
            myRCType.nUserBits = br.ReadInt32
            myRCType.bRevertBitHi = br.ReadBoolean
            myRCType.nPositionHi = br.ReadInt32
            myRCType.bRevertBitLo = br.ReadBoolean
            myRCType.bBitExpand = br.ReadBoolean
            myRCType.nPositionLo = br.ReadInt32
            myRCType.bBit1Option = br.ReadBoolean
            myRCType.nDataCode1Bits = br.ReadInt32
            myRCType.bL7464Check = br.ReadBoolean
            myRCType.bL7464_Xor = br.ReadBoolean
            myRCType.b1986Enable = br.ReadBoolean
            myRCType.nUserCode2 = br.ReadUInt16
            myRCType.nUserCode2Bits = br.ReadInt32
            myRCType.nData2Choice = br.ReadInt32
            myRCType.nDataCode2Bits = br.ReadInt32
            myRCType.nDataCode2 = br.ReadUInt16
            myRCType.nChecksum = br.ReadByte
            myRCType.bHtoL_Stop = br.ReadBoolean
            myRCType.fStopBitFirst = br.ReadSingle
            myRCType.fStopBitSecond = br.ReadSingle
            myRCType.bDefineStopTime = br.ReadBoolean
            myRCType.fStopTime = br.ReadSingle
            myRCType.bCompleteRepeat = br.ReadBoolean
            myRCType.fHighRepeat = br.ReadSingle
            myRCType.fLowRepeat = br.ReadSingle
            myRCType.nRepeatHLX = br.ReadInt32
            myRCType.bBootCode = br.ReadBoolean
            myRCType.fRepeatBootHigh = br.ReadSingle
            myRCType.fRepeatBootLow = br.ReadSingle
            myRCType.bData1Revert = br.ReadBoolean
            myRCType.bUser2Revert = br.ReadBoolean
            myRCType.bData2Revert = br.ReadBoolean
            myRCType.fRepeatStopTime = br.ReadSingle
            myRCType.nPressKey = br.ReadInt32
            myRCType.bRepeatDataFrame = br.ReadBoolean
            myRCType.bMultiUser = br.ReadBoolean
            myRCType.nMultiUserBits = br.ReadInt32
            myRCType.nMultiUserBoundry1 = br.ReadByte
            myRCType.nMultiUserBoundry2 = br.ReadByte
            myRCType.nMultiUserCode1 = br.ReadUInt16
            myRCType.nMultiUserCode2 = br.ReadUInt16
            myRCType.nMultiUserCode3 = br.ReadUInt16
            myRCType.bRepeatModeGroup = br.ReadBoolean
            myRCType.nRepeatGroupBoundry = br.ReadByte
            myRCType.bSameAsBoot = br.ReadBoolean

            For i = 0 To 90
                myRCType.nSingleKey(i) = br.ReadByte
                myRCType.sSingleKeyLabel(i) = br.ReadString
            Next
            'For i = 0 To 7
            '    myRCType.nDoubleKey(i) = br.ReadByte
            '    myRCType.sDoubleKeyLabel(i) = br.ReadString
            '    myRCType.nDKX(0, i) = br.ReadInt32
            '    myRCType.nDKX(1, i) = br.ReadInt32
            'Next
            'For i = 0 To 1
            '    myRCType.nTripleKey(i) = br.ReadByte
            '    myRCType.sTripleKeyLabel(i) = br.ReadString
            '    myRCType.nTKX(0, i) = br.ReadInt32
            '    myRCType.nTKX(1, i) = br.ReadInt32
            '    myRCType.nTKX(2, i) = br.ReadInt32
            'Next

            For i = 0 To 7
                br.ReadByte()
                br.ReadString()
                br.ReadInt32()
                br.ReadInt32()
            Next
            For i = 0 To 1
                br.ReadByte()
                br.ReadString()
                br.ReadInt32()
                br.ReadInt32()
                br.ReadInt32()
            Next
            myRCType.sInfoName = br.ReadString
            myRCType.sInfoNote = br.ReadString

            'for Debug
            myRCType.bFilterEnable = br.ReadBoolean
            myRCType.nTempValue = br.ReadInt32
            myRCType.bHighSpeed = br.ReadBoolean
            myRCType.bLDO17 = br.ReadBoolean
            myRCType.nDriveSpeed = br.ReadInt32
            myRCType.nIRef = br.ReadInt32
            myRCType.b150K = br.ReadBoolean
            myRCType.bNotOD = br.ReadBoolean
            myRCType.bNotConn = br.ReadBoolean

            br.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
            Return False
        End Try
    End Function

    Private Sub mnuFileSaveAs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileSaveAs.Click, tolSaveAs.Click
        Dim sfDlg As New SaveFileDialog
        Dim getInfo As System.IO.FileInfo

        If mnuLangEnglish.Checked Then
            sfDlg.Filter = "RCT files (*.rct)|*.rct"
        Else
            sfDlg.Filter = "RCT文件 (*.rct)|*.rct"
        End If
        'sfDlg.InitialDirectory = sCurrentPath
        sfDlg.FileName = sCurrentFile

        Me.ActiveControl = CType(cobDuty, Control)
        If CheckError() Then
            'FormToRCType()
            If sfDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
                getInfo = My.Computer.FileSystem.GetFileInfo(sfDlg.FileName)
                sCurrentFile = getInfo.Name
                sCurrentPath = getInfo.DirectoryName
                SaveRCTFile(sfDlg.FileName)
                mnuFileSave.Enabled = True
                tolSave.Enabled = True
            End If
        End If
    End Sub

    Private Sub mnuFileNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileNew.Click, tolNew.Click
        Dim nResult As Integer

        If mnuLangEnglish.Checked Then
            nResult = MessageBox.Show("All the data will be restored. Confirm?", "New", MessageBoxButtons.OKCancel)
        Else
            nResult = MessageBox.Show("所有数据都会恢复到初始值，确认？", "新建", MessageBoxButtons.OKCancel)
        End If
        If nResult = Windows.Forms.DialogResult.OK Then
            myRCType.Reset()
            sCurrentFile = "new.rct"
            RefreshForm()
            RefreshKeyPage()
            UpdateLabelRangeKey()
            mnuFileSave.Enabled = False
            tolSave.Enabled = False
            'FormToRCType()
            panWave.Invalidate()
        End If
    End Sub

    Private Sub mnuFileOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileOpen.Click, tolOpen.Click
        Dim ofDlg As New OpenFileDialog
        Dim nResult As Integer
        Dim getInfo As System.IO.FileInfo

        ofDlg.Filter = "RCT files (*.rct)|*.rct"
        'ofDlg.InitialDirectory = sCurrentPath

        If ofDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If mnuLangEnglish.Checked Then
                nResult = MessageBox.Show("All the data will be overwritten. Confirm?", "Open", MessageBoxButtons.OKCancel)
            Else
                nResult = MessageBox.Show("所有数据都会被覆盖，确认？", "打开", MessageBoxButtons.OKCancel)
            End If
            If nResult = Windows.Forms.DialogResult.OK Then
                If LoadRCTFile(ofDlg.FileName) Then
                    mnuFileSave.Enabled = True
                    tolSave.Enabled = True
                    getInfo = My.Computer.FileSystem.GetFileInfo(ofDlg.FileName)
                    sCurrentFile = getInfo.Name
                    sCurrentPath = getInfo.DirectoryName
                    RefreshKeyPage()
                    UpdateLabelRangeKey()
                    RefreshForm()
                    'FormToRCType()
                    panWave.Invalidate()
                End If

            End If
        End If

    End Sub

    Private Sub mnuFileExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
        Me.Close()
        End
    End Sub

    Private Sub trvFrame_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvFrame.AfterCheck
        If Not bInit Then
            If e.Node Is trvFrame.Nodes(frameTreeTop.boot) Then
                myRCType.bBootFrame = trvFrame.Nodes(frameTreeTop.boot).Checked
            ElseIf e.Node Is trvFrame.Nodes(frameTreeTop.user) Then
                myRCType.bUserFrame = trvFrame.Nodes(frameTreeTop.user).Checked
            ElseIf e.Node Is trvFrame.Nodes(frameTreeTop.split) Then
                myRCType.bSplitFrame = trvFrame.Nodes(frameTreeTop.split).Checked
            ElseIf e.Node Is trvFrame.Nodes(frameTreeTop.data) Then
                myRCType.bDataFrame = trvFrame.Nodes(frameTreeTop.data).Checked
            ElseIf e.Node Is trvFrame.Nodes(frameTreeTop.data).Nodes(frameTreeData.datacode1) Then
                myRCType.bDataCode1 = trvFrame.Nodes(frameTreeTop.data).Nodes(frameTreeData.datacode1).Checked
            ElseIf e.Node Is trvFrame.Nodes(frameTreeTop.data).Nodes(frameTreeData.usercode2) Then
                myRCType.bUserCode2 = trvFrame.Nodes(frameTreeTop.data).Nodes(frameTreeData.usercode2).Checked
            ElseIf e.Node Is trvFrame.Nodes(frameTreeTop.data).Nodes(frameTreeData.datacode2) Then
                myRCType.bDataCode2 = trvFrame.Nodes(frameTreeTop.data).Nodes(frameTreeData.datacode2).Checked
            ElseIf e.Node Is trvFrame.Nodes(frameTreeTop.stop0) Then
                myRCType.bStopFrame = trvFrame.Nodes(frameTreeTop.stop0).Checked
            ElseIf e.Node Is trvFrame.Nodes(frameTreeTop.stop0).Nodes(frameTreeStop.stopbit) Then
                myRCType.bStopBit = trvFrame.Nodes(frameTreeTop.stop0).Nodes(frameTreeStop.stopbit).Checked
            ElseIf e.Node Is trvFrame.Nodes(frameTreeTop.stop0).Nodes(frameTreeStop.stopcode) Then
                myRCType.bStopCode = trvFrame.Nodes(frameTreeTop.stop0).Nodes(frameTreeStop.stopcode).Checked
            ElseIf e.Node Is trvFrame.Nodes(frameTreeTop.repeat) Then
                myRCType.bRepeatFrame = trvFrame.Nodes(frameTreeTop.repeat).Checked
            End If
            panWave.Invalidate()
        End If
    End Sub

    Private Sub trvFrame_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvFrame.AfterSelect
        Dim trv As TreeView
        trv = CType(sender, TreeView)
        If trv.SelectedNode Is trvFrame.Nodes(frameTreeTop.boot) Then
            grpBoot.Visible = True
            grpUser.Visible = False
            grpSplit.Visible = False
            grpDataCode1.Visible = False
            grpUserCode2.Visible = False
            grpDataCode2.Visible = False
            grpStopBit.Visible = False
            grpStopCode.Visible = False
            grpRepeat.Visible = False
            grpDataFrame.Visible = False
            fWaveStart = 0
            UpdateScroll()
            panWave.Invalidate()
        ElseIf trv.SelectedNode Is trvFrame.Nodes(frameTreeTop.user) Then
            grpBoot.Visible = False
            grpUser.Visible = True
            grpSplit.Visible = False
            grpDataCode1.Visible = False
            grpUserCode2.Visible = False
            grpDataCode2.Visible = False
            grpStopBit.Visible = False
            grpStopCode.Visible = False
            grpRepeat.Visible = False
            grpDataFrame.Visible = False
            fWaveStart = fTimeFrame(0) / 1000
            UpdateScroll()
            panWave.Invalidate()
        ElseIf trv.SelectedNode Is trvFrame.Nodes(frameTreeTop.split) Then
            grpBoot.Visible = False
            grpUser.Visible = False
            grpSplit.Visible = True
            grpDataCode1.Visible = False
            grpUserCode2.Visible = False
            grpDataCode2.Visible = False
            grpStopBit.Visible = False
            grpStopCode.Visible = False
            grpRepeat.Visible = False
            grpDataFrame.Visible = False
            fWaveStart = fTimeFrame(1) / 1000
            UpdateScroll()
            panWave.Invalidate()
        ElseIf trv.SelectedNode Is trvFrame.Nodes(frameTreeTop.data) Then
            grpBoot.Visible = False
            grpUser.Visible = False
            grpSplit.Visible = False
            grpDataCode1.Visible = False
            grpUserCode2.Visible = False
            grpDataCode2.Visible = False
            grpStopBit.Visible = False
            grpStopCode.Visible = False
            grpRepeat.Visible = False
            grpDataFrame.Visible = True
            fWaveStart = fTimeFrame(2) / 1000
            UpdateScroll()
            panWave.Invalidate()
        ElseIf trv.SelectedNode Is trvFrame.Nodes(frameTreeTop.data).Nodes(frameTreeData.datacode1) Then
            grpBoot.Visible = False
            grpUser.Visible = False
            grpSplit.Visible = False
            grpDataCode1.Visible = True
            grpUserCode2.Visible = False
            grpDataCode2.Visible = False
            grpStopBit.Visible = False
            grpStopCode.Visible = False
            grpRepeat.Visible = False
            grpDataFrame.Visible = False
            fWaveStart = fTimeFrame(2) / 1000
            UpdateScroll()
            panWave.Invalidate()
        ElseIf trv.SelectedNode Is trvFrame.Nodes(frameTreeTop.data).Nodes(frameTreeData.usercode2) Then
            grpBoot.Visible = False
            grpUser.Visible = False
            grpSplit.Visible = False
            grpDataCode1.Visible = False
            grpUserCode2.Visible = True
            grpDataCode2.Visible = False
            grpStopBit.Visible = False
            grpStopCode.Visible = False
            grpRepeat.Visible = False
            grpDataFrame.Visible = False
            fWaveStart = fTimeFrame(3) / 1000
            UpdateScroll()
            panWave.Invalidate()
        ElseIf trv.SelectedNode Is trvFrame.Nodes(frameTreeTop.data).Nodes(frameTreeData.datacode2) Then
            grpBoot.Visible = False
            grpUser.Visible = False
            grpSplit.Visible = False
            grpDataCode1.Visible = False
            grpUserCode2.Visible = False
            grpDataCode2.Visible = True
            grpStopBit.Visible = False
            grpStopCode.Visible = False
            grpRepeat.Visible = False
            grpDataFrame.Visible = False
            fWaveStart = fTimeFrame(4) / 1000
            UpdateScroll()
            panWave.Invalidate()
        ElseIf trv.SelectedNode Is trvFrame.Nodes(frameTreeTop.stop0) Then
            grpBoot.Visible = False
            grpUser.Visible = False
            grpSplit.Visible = False
            grpDataCode1.Visible = False
            grpUserCode2.Visible = False
            grpDataCode2.Visible = False
            grpStopBit.Visible = False
            grpStopCode.Visible = False
            grpRepeat.Visible = False
            grpDataFrame.Visible = False
            fWaveStart = fTimeFrame(5) / 1000
            UpdateScroll()
            panWave.Invalidate()
        ElseIf trv.SelectedNode Is trvFrame.Nodes(frameTreeTop.stop0).Nodes(frameTreeStop.stopbit) Then
            grpBoot.Visible = False
            grpUser.Visible = False
            grpSplit.Visible = False
            grpDataCode1.Visible = False
            grpUserCode2.Visible = False
            grpDataCode2.Visible = False
            grpStopBit.Visible = True
            grpStopCode.Visible = False
            grpRepeat.Visible = False
            grpDataFrame.Visible = False
            fWaveStart = fTimeFrame(5) / 1000
            UpdateScroll()
            panWave.Invalidate()
        ElseIf trv.SelectedNode Is trvFrame.Nodes(frameTreeTop.stop0).Nodes(frameTreeStop.stopcode) Then
            grpBoot.Visible = False
            grpUser.Visible = False
            grpSplit.Visible = False
            grpDataCode1.Visible = False
            grpUserCode2.Visible = False
            grpDataCode2.Visible = False
            grpStopBit.Visible = False
            grpStopCode.Visible = True
            grpRepeat.Visible = False
            grpDataFrame.Visible = False
            fWaveStart = fTimeFrame(6) / 1000
            UpdateScroll()
            panWave.Invalidate()
        ElseIf trv.SelectedNode Is trvFrame.Nodes(frameTreeTop.repeat) Then
            grpBoot.Visible = False
            grpUser.Visible = False
            grpSplit.Visible = False
            grpDataCode1.Visible = False
            grpUserCode2.Visible = False
            grpDataCode2.Visible = False
            grpStopBit.Visible = False
            grpStopCode.Visible = False
            grpRepeat.Visible = True
            grpDataFrame.Visible = False
            fWaveStart = fTimeFrame(7) / 1000
            UpdateScroll()
            panWave.Invalidate()
            'ElseIf trv.SelectedNode Is trvFrame.Nodes(frameTreeTop.repeat).Nodes(frameTreeRepeat.compact) Then
            '    grpBoot.Visible = False
            '    grpUser.Visible = False
            '    grpSplit.Visible = False
            '    grpDataCode1.Visible = False
            '    grpUserCode2.Visible = False
            '    grpDataCode2.Visible = False
            '    grpStopBit.Visible = False
            'ElseIf trv.SelectedNode Is trvFrame.Nodes(frameTreeTop.repeat).Nodes(frameTreeRepeat.complete) Then
            '    grpBoot.Visible = False
            '    grpUser.Visible = False
            '    grpSplit.Visible = False
            '    grpDataCode1.Visible = False
            '    grpUserCode2.Visible = False
            '    grpDataCode2.Visible = False
            '    grpStopBit.Visible = False
        End If
    End Sub

    Private Sub txtBootLow_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtBootLow.Validating
        If Not Check_BootLow() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_BootLow() As Boolean
        Dim fValue As Single
        Dim err As Integer
        Dim max As Single, min As Single

        err = &H200

        max = 50000
        min = 1000 / myRCType.fCarrierFreq
        Try
            fValue = Convert.ToSingle(txtBootLow.Text)
            If fValue < min Or fValue > max Then
                If mnuLangEnglish.Checked Then
                    errProvider.SetError(txtBootLow, "Exceed value range: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                Else
                    errProvider.SetError(txtBootLow, "设置超出范围: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                End If
                errProvider.Tag = errProvider.Tag Or err
                txtBootLow.SelectAll()
                Return False
            Else
                errProvider.SetError(txtBootLow, "")
                errProvider.Tag = errProvider.Tag And (Not err)
                txtBootLow.Text = fValue.ToString("0.000")
                myRCType.fBootLow = Convert.ToSingle(txtBootLow.Text)
                panWave.Invalidate()
                Return True
            End If
        Catch ex As Exception
            errProvider.SetError(txtBootLow, ex.Message.ToString)
            errProvider.Tag = errProvider.Tag Or err
        End Try
    End Function

    Private Sub txtBootHigh_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtBootHigh.Validating
        If Not Check_BootHigh() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_BootHigh() As Boolean
        Dim fValue As Single
        Dim err As Integer
        Dim max As Single, min As Single

        err = &H100

        max = 50000
        min = 1000 / myRCType.fCarrierFreq
        Try
            fValue = Convert.ToSingle(txtBootHigh.Text)
            If fValue < min Or fValue > max Then
                If mnuLangEnglish.Checked Then
                    errProvider.SetError(txtBootHigh, "Exceed value range: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                Else
                    errProvider.SetError(txtBootHigh, "设置超出范围: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                End If
                errProvider.Tag = errProvider.Tag Or err
                txtBootHigh.SelectAll()
                Return False
            Else
                errProvider.SetError(txtBootHigh, "")
                errProvider.Tag = errProvider.Tag And (Not err)
                txtBootHigh.Text = fValue.ToString("0.000")
                myRCType.fBootHigh = Convert.ToSingle(txtBootHigh.Text)
                panWave.Invalidate()
                Return True
            End If
        Catch ex As Exception
            errProvider.SetError(txtBootHigh, ex.Message.ToString)
            errProvider.Tag = errProvider.Tag Or err
        End Try
    End Function

    Private Sub txtDebounce_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDebounce.Validating
        If Not Check_Debounce() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_Debounce() As Boolean
        Dim fValue As Single
        Dim err As Integer
        Dim max As Single, min As Single

        err = &H1
        Try
            fValue = Convert.ToSingle(txtDebounce.Text)
            max = 255 * 16 / myRCType.fCarrierFreq
            min = 16 / myRCType.fCarrierFreq
            If fValue < min Or fValue > max Then
                If mnuLangEnglish.Checked Then
                    errProvider.SetError(txtDebounce, "Exceed value range: " & min.ToString("0.0") & " ~ " & max.ToString("0.0ms"))
                Else
                    errProvider.SetError(txtDebounce, "设置超出范围: " & min.ToString("0.0") & " ~ " & max.ToString("0.0ms"))
                End If
                errProvider.Tag = errProvider.Tag Or err
                txtDebounce.SelectAll()
                Return False
            Else
                errProvider.SetError(txtDebounce, "")
                errProvider.Tag = errProvider.Tag And (Not err)
                txtDebounce.Text = fValue.ToString("0.000")
                myRCType.fDebounce = Convert.ToSingle(txtDebounce.Text)
                panWave.Invalidate()
                Return True
            End If
        Catch ex As Exception
            errProvider.SetError(txtDebounce, ex.Message.ToString)
            errProvider.Tag = errProvider.Tag Or err
        End Try
    End Function

    Private Sub txtFirst_L0_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFirst_L0.Validating
        If Not Check_First_L0() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_First_L0() As Boolean
        Dim fValue As Single
        Dim err As Integer
        Dim max As Single, min As Single

        err = &H1

        max = 20000
        min = 1000 / myRCType.fCarrierFreq
        Try
            fValue = Convert.ToSingle(txtFirst_L0.Text)
            If fValue < min Or fValue > max Then
                If mnuLangEnglish.Checked Then
                    errProvider.SetError(txtFirst_L0, "Exceed value range: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                Else
                    errProvider.SetError(txtFirst_L0, "设置超出范围: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                End If
                errProvider.Tag = errProvider.Tag Or err
                txtFirst_L0.SelectAll()
                Return False
            Else
                errProvider.SetError(txtFirst_L0, "")
                errProvider.Tag = errProvider.Tag And (Not err)
                txtFirst_L0.Text = fValue.ToString("0.000")
                myRCType.fFirst_L0 = Convert.ToSingle(txtFirst_L0.Text)
                panWave.Invalidate()
                Return True
            End If
        Catch ex As Exception
            errProvider.SetError(txtFirst_L0, ex.Message.ToString)
            errProvider.Tag = errProvider.Tag Or err
        End Try
    End Function

    Private Sub txtSecond_L0_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSecond_L0.Validating
        If Not Check_Second_L0() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_Second_L0() As Boolean
        Dim fValue As Single
        Dim err As Integer
        Dim max As Single, min As Single

        err = &H2

        max = 20000
        min = 1000 / myRCType.fCarrierFreq
        Try
            fValue = Convert.ToSingle(txtSecond_L0.Text)
            If fValue < min Or fValue > max Then
                If mnuLangEnglish.Checked Then
                    errProvider.SetError(txtSecond_L0, "Exceed value range: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                Else
                    errProvider.SetError(txtSecond_L0, "设置超出范围: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                End If
                errProvider.Tag = errProvider.Tag Or err
                txtSecond_L0.SelectAll()
                Return False
            Else
                errProvider.SetError(txtSecond_L0, "")
                errProvider.Tag = errProvider.Tag And (Not err)
                txtSecond_L0.Text = fValue.ToString("0.000")
                myRCType.fSecond_L0 = Convert.ToSingle(txtSecond_L0.Text)
                panWave.Invalidate()
                Return True
            End If
        Catch ex As Exception
            errProvider.SetError(txtSecond_L0, ex.Message.ToString)
            errProvider.Tag = errProvider.Tag Or err
        End Try
    End Function

    Private Sub txtFirst_L1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFirst_L1.Validating
        If Not Check_First_L1() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_First_L1() As Boolean
        Dim fValue As Single
        Dim err As Integer
        Dim max As Single, min As Single

        err = &H4
        max = 20000
        min = 1000 / myRCType.fCarrierFreq

        Try
            fValue = Convert.ToSingle(txtFirst_L1.Text)
            If fValue < min Or fValue > max Then
                If mnuLangEnglish.Checked Then
                    errProvider.SetError(txtFirst_L1, "Exceed value range: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                Else
                    errProvider.SetError(txtFirst_L1, "设置超出范围: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                End If
                errProvider.Tag = errProvider.Tag Or err
                txtFirst_L1.SelectAll()
                Return False
            Else
                errProvider.SetError(txtFirst_L1, "")
                errProvider.Tag = errProvider.Tag And (Not err)
                txtFirst_L1.Text = fValue.ToString("0.000")
                myRCType.fFirst_L1 = Convert.ToSingle(txtFirst_L1.Text)
                panWave.Invalidate()
                Return True
            End If
        Catch ex As Exception
            errProvider.SetError(txtFirst_L1, ex.Message.ToString)
            errProvider.Tag = errProvider.Tag Or err
        End Try
    End Function

    Private Sub txtSecond_L1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSecond_L1.Validating
        If Not Check_Second_L1() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_Second_L1() As Boolean
        Dim fValue As Single
        Dim err As Integer
        Dim max As Single, min As Single

        err = &H8
        max = 20000
        min = 1000 / myRCType.fCarrierFreq
        Try
            fValue = Convert.ToSingle(txtSecond_L1.Text)
            If fValue < min Or fValue > max Then
                If mnuLangEnglish.Checked Then
                    errProvider.SetError(txtSecond_L1, "Exceed value range: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                Else
                    errProvider.SetError(txtSecond_L1, "设置超出范围: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                End If
                errProvider.Tag = errProvider.Tag Or err
                txtSecond_L1.SelectAll()
                Return False
            Else
                errProvider.SetError(txtSecond_L1, "")
                errProvider.Tag = errProvider.Tag And (Not err)
                txtSecond_L1.Text = fValue.ToString("0.000")
                myRCType.fSecond_L1 = Convert.ToSingle(txtSecond_L1.Text)
                panWave.Invalidate()
                Return True
            End If
        Catch ex As Exception
            errProvider.SetError(txtSecond_L1, ex.Message.ToString)
            errProvider.Tag = errProvider.Tag Or err
        End Try
    End Function

    Private Sub txtCarrierFreq_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCarrierFreq.Validating
        If Not Check_CarrierFreq() Then
            e.Cancel = True
        Else
            Check_BootHigh()
            Check_BootLow()
            Check_First_L0()
            Check_Second_L0()
            Check_First_L1()
            Check_Second_L1()
            Check_SplitHigh()
            Check_SplitLow()
            Check_StopBitFirst()
            Check_StopBitSecond()
            Check_RepeatBootLow()
            Check_RepeatBootHigh()
            Check_LowRepeat()
            Check_HighRepeat()

        End If
    End Sub

    Private Function Check_CarrierFreq() As Boolean
        Dim fValue As Single
        Dim err As Integer

        err = &H10

        Try
            fValue = Convert.ToSingle(txtCarrierFreq.Text)
            If fValue < 5 Or fValue > 60 Then
                If mnuLangEnglish.Checked Then
                    errProvider.SetError(txtCarrierFreq, "Exceed value range: 5K~60KHz")
                Else
                    errProvider.SetError(txtCarrierFreq, "设置超出范围: 5K~60KHz")
                End If
                errProvider.Tag = errProvider.Tag Or err
                'txtCarrierFreq.Select(0, txtCarrierFreq.Text.Length)
                txtCarrierFreq.SelectAll()
                Return False
            Else
                errProvider.SetError(txtCarrierFreq, "")
                errProvider.Tag = errProvider.Tag And (Not err)
                txtCarrierFreq.Text = fValue.ToString("0.000")
                myRCType.fCarrierFreq = Convert.ToSingle(txtCarrierFreq.Text)
                Return True
            End If
        Catch ex As Exception
            errProvider.SetError(txtCarrierFreq, ex.Message.ToString)
            errProvider.Tag = errProvider.Tag Or err
        End Try
    End Function

    Private Sub txtKeyRemain_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtKeyRemain.Validating
        If Not Check_KeyRemain() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_KeyRemain() As Boolean
        Dim nValue As Integer
        Dim err As Integer

        err = &H20
        Try
            nValue = Convert.ToSingle(txtKeyRemain.Text)
            If (Not myRCType.bDoubleFrame) And (nValue < 2 Or nValue > 65536) Then
                If mnuLangEnglish.Checked Then
                    errProvider.SetError(txtKeyRemain, "Exceed value range: 2~65536")
                Else
                    errProvider.SetError(txtKeyRemain, "设置超出范围: 2~65536")
                End If
                errProvider.Tag = errProvider.Tag Or err
                txtKeyRemain.SelectAll()
                Return False
            ElseIf myRCType.bDoubleFrame And (nValue < 1 Or nValue > 32768) Then
                If mnuLangEnglish.Checked Then
                    errProvider.SetError(txtKeyRemain, "Exceed value range: 1~32768")
                Else
                    errProvider.SetError(txtKeyRemain, "设置超出范围: 1~32768")
                End If
                errProvider.Tag = errProvider.Tag Or err
                txtKeyRemain.SelectAll()
                Return False
            Else
                errProvider.SetError(txtKeyRemain, "")
                errProvider.Tag = errProvider.Tag And (Not err)
                txtKeyRemain.Text = nValue.ToString
                myRCType.nKeyRemainTime = Convert.ToSingle(txtKeyRemain.Text)
                Return True
            End If
        Catch ex As Exception
            errProvider.SetError(txtKeyRemain, ex.Message.ToString)
            errProvider.Tag = errProvider.Tag Or err
        End Try
    End Function

    Private Sub txtInvalidKey_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtInvalidKey.Validating
        If Not Check_InvalidKey() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_InvalidKey() As Boolean
        Dim err As Integer
        Dim str As String
        Dim s(1) As Char

        err = &H40
        str = txtInvalidKey.Text.ToUpper
        'If s.Length = 2 And (s.Substring(0, 1) Like "*[0-9A-Fa-f]") And (s.Substring(1, 1) Like "*[0-9A-Fa-f]") Then
        If str.Length = 2 And str Like "[0-9A-Fa-f][0-9A-Fa-f]" Then
            txtInvalidKey.Text = str.ToUpper
            errProvider.SetError(txtInvalidKey, "")
            errProvider.Tag = errProvider.Tag And (Not err)
            s(1) = Convert.ToChar(str.Substring(0, 1))
            s(0) = Convert.ToChar(str.Substring(1, 1))
            myRCType.nInvalidKeyCode = Hex2Dec(s(1)) * 16 + Hex2Dec(s(0))
            panWave.Invalidate()
            Return True
        Else
            If mnuLangEnglish.Checked Then
                errProvider.SetError(txtInvalidKey, "Must be an 8-bit Hex digits, e.g. 00, EF etc")
            Else
                errProvider.SetError(txtInvalidKey, "必须是8位16进制数，如00,EF等")
            End If
            errProvider.Tag = errProvider.Tag Or err
            txtInvalidKey.SelectAll()
            Return False
        End If
    End Function


    Private Sub txtUpKey_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtUpKey.Validating
        If Not Check_UpKey() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_UpKey() As Boolean
        Dim err As Integer
        Dim str As String
        Dim s(1) As Char

        err = &H40
        str = txtUpKey.Text.ToUpper
        'If s.Length = 2 And (s.Substring(0, 1) Like "*[0-9A-Fa-f]") And (s.Substring(1, 1) Like "*[0-9A-Fa-f]") Then
        If str.Length = 2 And str Like "[0-9A-Fa-f][0-9A-Fa-f]" Then
            txtUpKey.Text = str.ToUpper
            errProvider.SetError(txtUpKey, "")
            errProvider.Tag = errProvider.Tag And (Not err)
            s(1) = Convert.ToChar(str.Substring(0, 1))
            s(0) = Convert.ToChar(str.Substring(1, 1))
            myRCType.nUpKeyCode = Hex2Dec(s(1)) * 16 + Hex2Dec(s(0))
            panWave.Invalidate()
            Return True
        Else
            If mnuLangEnglish.Checked Then
                errProvider.SetError(txtUpKey, "Must be an 8-bit Hex digits, e.g. 00, EF etc")
            Else
                errProvider.SetError(txtUpKey, "必须是8位16进制数，如00,EF等")
            End If
            errProvider.Tag = errProvider.Tag Or err
            txtUpKey.SelectAll()
            Return False
        End If
    End Function

    Private Sub txtMultiUserBoundry1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMultiUserBoundry1.Validating
        If Not Check_MultiUserBoundry1() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_MultiUserBoundry1() As Boolean
        Dim nValue As Integer
        Dim err As Integer

        err = errType.errKey
        Try
            nValue = Convert.ToSingle(txtMultiUserBoundry1.Text)
            If nValue < 0 Or nValue > 64 Or nValue >= myRCType.nMultiUserBoundry2 Then
                If mnuLangEnglish.Checked Then
                    errProvider.SetError(txtMultiUserBoundry1, "Must range 0~64 and LESS than BELOW value")
                Else
                    errProvider.SetError(txtMultiUserBoundry1, "范围须在0~64，且小于下值")
                End If
                errProvider.Tag = errProvider.Tag Or err
                txtMultiUserBoundry1.SelectAll()
                Return False
            Else
                errProvider.SetError(txtMultiUserBoundry1, "")
                errProvider.Tag = errProvider.Tag And (Not err)
                txtMultiUserBoundry1.Text = nValue.ToString("00")
                myRCType.nMultiUserBoundry1 = Convert.ToSingle(txtMultiUserBoundry1.Text)
                UpdateLabelRangeKey()
                Return True
            End If
        Catch ex As Exception
            errProvider.SetError(txtMultiUserBoundry1, ex.Message.ToString)
            errProvider.Tag = errProvider.Tag Or err
        End Try
    End Function

    Private Sub txtMultiUserBoundry2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMultiUserBoundry2.Validating
        If Not Check_MultiUserBoundry2() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_MultiUserBoundry2() As Boolean
        Dim nValue As Integer
        Dim err As Integer

        err = errType.errKey
        Try
            nValue = Convert.ToSingle(txtMultiUserBoundry2.Text)
            If nValue < 1 Or nValue > 64 Or nValue <= myRCType.nMultiUserBoundry1 Then
                If mnuLangEnglish.Checked Then
                    errProvider.SetError(txtMultiUserBoundry2, "Must range 1~64 and GREATER than UPPER value")
                Else
                    errProvider.SetError(txtMultiUserBoundry2, "范围须在1~64，且大于上值")
                End If
                errProvider.Tag = errProvider.Tag Or err
                txtMultiUserBoundry2.SelectAll()
                Return False
            Else
                errProvider.SetError(txtMultiUserBoundry2, "")
                errProvider.Tag = errProvider.Tag And (Not err)
                txtMultiUserBoundry2.Text = nValue.ToString("00")
                myRCType.nMultiUserBoundry2 = Convert.ToSingle(txtMultiUserBoundry2.Text)
                UpdateLabelRangeKey()
                Return True
            End If
        Catch ex As Exception
            errProvider.SetError(txtMultiUserBoundry2, ex.Message.ToString)
            errProvider.Tag = errProvider.Tag Or err
        End Try
    End Function

    Private Sub txtRepeatGroupBoundry_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtRepeatGroupBoundry.Validating
        If Not Check_RepeatGroupBoundry() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_RepeatGroupBoundry() As Boolean
        Dim nValue As Integer
        Dim err As Integer

        err = errType.errKey
        Try
            nValue = Convert.ToSingle(txtRepeatGroupBoundry.Text)
            If nValue < 0 Or nValue > 65 Then
                If mnuLangEnglish.Checked Then
                    errProvider.SetError(txtRepeatGroupBoundry, "Exceed value range: 0~65")
                Else
                    errProvider.SetError(txtRepeatGroupBoundry, "设置超出范围: 0~65")
                End If
                errProvider.Tag = errProvider.Tag Or err
                txtRepeatGroupBoundry.SelectAll()
                Return False
            Else
                errProvider.SetError(txtRepeatGroupBoundry, "")
                errProvider.Tag = errProvider.Tag And (Not err)
                txtRepeatGroupBoundry.Text = nValue.ToString("00")
                myRCType.nRepeatGroupBoundry = Convert.ToSingle(txtRepeatGroupBoundry.Text)
                UpdateLabelRangeKey()
                Return True
            End If
        Catch ex As Exception
            errProvider.SetError(txtRepeatGroupBoundry, ex.Message.ToString)
            errProvider.Tag = errProvider.Tag Or err
        End Try
    End Function

    Private Sub txtSplitHigh_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSplitHigh.Validating
        If Not Check_SplitHigh() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_SplitHigh() As Boolean
        Dim fValue As Single
        Dim err As Integer
        Dim max As Single, min As Single

        err = &H400
        Try
            max = 50000
            min = 1000 / myRCType.fCarrierFreq
            fValue = Convert.ToSingle(txtSplitHigh.Text)
            If fValue < min Or fValue > max Then
                If mnuLangEnglish.Checked Then
                    errProvider.SetError(txtSplitHigh, "Exceed value range: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                Else
                    errProvider.SetError(txtSplitHigh, "设置超出范围: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                End If
                errProvider.Tag = errProvider.Tag Or err
                txtSplitHigh.SelectAll()
                Return False
            Else
                errProvider.SetError(txtSplitHigh, "")
                errProvider.Tag = errProvider.Tag And (Not err)
                txtSplitHigh.Text = fValue.ToString("0.000")
                myRCType.fSplitHigh = Convert.ToSingle(txtSplitHigh.Text)
                panWave.Invalidate()
                Return True
            End If
        Catch ex As Exception
            errProvider.SetError(txtSplitHigh, ex.Message.ToString)
            errProvider.Tag = errProvider.Tag Or err
        End Try
    End Function

    Private Sub txtSplitLow_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSplitLow.Validating
        If Not Check_SplitLow() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_SplitLow() As Boolean
        Dim fValue As Single
        Dim err As Integer
        Dim max As Single, min As Single

        err = &H800
        Try
            max = 50000
            min = 1000 / myRCType.fCarrierFreq
            fValue = Convert.ToSingle(txtSplitLow.Text)
            If fValue < min Or fValue > max Then
                If mnuLangEnglish.Checked Then
                    errProvider.SetError(txtSplitLow, "Exceed value range: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                Else
                    errProvider.SetError(txtSplitLow, "设置超出范围: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                End If
                errProvider.Tag = errProvider.Tag Or err
                txtSplitLow.SelectAll()
                Return False
            Else
                errProvider.SetError(txtSplitLow, "")
                errProvider.Tag = errProvider.Tag And (Not err)
                txtSplitLow.Text = fValue.ToString("0.000")
                myRCType.fSplitLow = Convert.ToSingle(txtSplitLow.Text)
                panWave.Invalidate()
                Return True
            End If
        Catch ex As Exception
            errProvider.SetError(txtSplitLow, ex.Message.ToString)
            errProvider.Tag = errProvider.Tag Or err
        End Try
    End Function

    Private Sub txtUserCode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtUserCode.Validating
        If Not Check_UserCode() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_UserCode() As Boolean
        Dim err As Integer
        Dim str As String
        Dim s(7) As Char

        err = &H1000
        str = txtUserCode.Text.ToUpper
        If str.Length = 8 And str Like "[0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f]" Then
            txtUserCode.Text = str.ToUpper
            errProvider.SetError(txtUserCode, "")
            errProvider.Tag = errProvider.Tag And (Not err)
            s(7) = Convert.ToChar(txtUserCode.Text.Substring(0, 1))
            s(6) = Convert.ToChar(txtUserCode.Text.Substring(1, 1))
            s(5) = Convert.ToChar(txtUserCode.Text.Substring(2, 1))
            s(4) = Convert.ToChar(txtUserCode.Text.Substring(3, 1))
            s(3) = Convert.ToChar(txtUserCode.Text.Substring(4, 1))
            s(2) = Convert.ToChar(txtUserCode.Text.Substring(5, 1))
            s(1) = Convert.ToChar(txtUserCode.Text.Substring(6, 1))
            s(0) = Convert.ToChar(txtUserCode.Text.Substring(7, 1))
            myRCType.nUserCode = Hex2Dec(s(7)) * &H10000000 + Hex2Dec(s(6)) * &H1000000 + Hex2Dec(s(5)) * &H100000 + Hex2Dec(s(4)) * &H10000 + _
                Hex2Dec(s(3)) * &H1000 + Hex2Dec(s(2)) * &H100 + Hex2Dec(s(1)) * &H10 + Hex2Dec(s(0))
            panWave.Invalidate()
            Return True
        Else
            If mnuLangEnglish.Checked Then
                errProvider.SetError(txtUserCode, "Must be an 32-bit Hex digits, e.g. 000055AA, C30E03F2 etc")
            Else
                errProvider.SetError(txtUserCode, "必须是32位16进制数，如000055AA,C30E03F2等")
            End If
            errProvider.Tag = errProvider.Tag Or err
            txtUserCode.SelectAll()
            Return False
        End If
    End Function

    Private Sub ckbRevertBitHi_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbRevertBitHi.CheckedChanged
        cobPositionHi.Enabled = ckbRevertBitHi.Checked
        lblPositionHi.Enabled = ckbRevertBitHi.Checked
        If Not bInit Then
            myRCType.bRevertBitHi = ckbRevertBitHi.Checked
            panWave.Invalidate()
        End If
    End Sub

    Private Sub ckbRevertBitLo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbRevertBitLo.CheckedChanged
        cobPositionLo.Enabled = ckbRevertBitLo.Checked Or ckbBitExpand.Checked
        lblPositionLo.Enabled = cobPositionLo.Enabled
        If Not bInit Then
            myRCType.bRevertBitLo = ckbRevertBitLo.Checked
            panWave.Invalidate()
        End If
    End Sub

    Private Sub ckbBitExpand_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbBitExpand.CheckedChanged
        cobPositionLo.Enabled = ckbRevertBitLo.Checked Or ckbBitExpand.Checked
        lblPositionLo.Enabled = cobPositionLo.Enabled
        If Not bInit Then
            myRCType.bBitExpand = ckbBitExpand.Checked
            panWave.Invalidate()
        End If
    End Sub

    Private Sub trvFrame_BeforeCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles trvFrame.BeforeCheck
        If e.Node.Checked And _
                (e.Node Is trvFrame.Nodes(frameTreeTop.data) Or _
                e.Node Is trvFrame.Nodes(frameTreeTop.stop0) Or _
                e.Node Is trvFrame.Nodes(frameTreeTop.repeat) Or _
                e.Node Is trvFrame.Nodes(frameTreeTop.data).Nodes(frameTreeData.datacode1) Or _
                e.Node Is trvFrame.Nodes(frameTreeTop.stop0).Nodes(frameTreeStop.stopcode)) Then
            e.Cancel = True
        End If
    End Sub


    Private Sub txtUserCode2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtUserCode2.Validating
        If Not Check_UserCode2() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_UserCode2() As Boolean
        Dim err As Integer
        Dim str As String
        Dim s(3) As Char

        err = &H2000
        str = txtUserCode2.Text.ToUpper
        If str.Length = 4 And str Like "[0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f]" Then
            txtUserCode2.Text = str.ToUpper
            errProvider.SetError(txtUserCode2, "")
            errProvider.Tag = errProvider.Tag And (Not err)
            s(3) = Convert.ToChar(txtUserCode2.Text.Substring(0, 1))
            s(2) = Convert.ToChar(txtUserCode2.Text.Substring(1, 1))
            s(1) = Convert.ToChar(txtUserCode2.Text.Substring(2, 1))
            s(0) = Convert.ToChar(txtUserCode2.Text.Substring(3, 1))
            myRCType.nUserCode2 = Hex2Dec(s(3)) * &H1000 + Hex2Dec(s(2)) * &H100 + Hex2Dec(s(1)) * &H10 + Hex2Dec(s(0))
            panWave.Invalidate()
            Return True
        Else
            If mnuLangEnglish.Checked Then
                errProvider.SetError(txtUserCode2, "Must be an 16-bit Hex digits, e.g. 55AA, 03F2 etc")
            Else
                errProvider.SetError(txtUserCode2, "必须是16位16进制数，如55AA,03F2等")
            End If
            errProvider.Tag = errProvider.Tag Or err
            txtUserCode2.SelectAll()
            Return False
        End If
    End Function

    Private Sub txtMultiUserCode1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMultiUserCode1.Validating
        If Not Check_MultiUserCode1() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_MultiUserCode1() As Boolean
        Dim err As Integer
        Dim str As String
        Dim s(3) As Char

        err = errType.errKey
        str = txtMultiUserCode1.Text.ToUpper
        If str.Length = 4 And str Like "[0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f]" Then
            txtMultiUserCode1.Text = str.ToUpper
            errProvider.SetError(txtMultiUserCode1, "")
            errProvider.Tag = errProvider.Tag And (Not err)
            s(3) = Convert.ToChar(txtMultiUserCode1.Text.Substring(0, 1))
            s(2) = Convert.ToChar(txtMultiUserCode1.Text.Substring(1, 1))
            s(1) = Convert.ToChar(txtMultiUserCode1.Text.Substring(2, 1))
            s(0) = Convert.ToChar(txtMultiUserCode1.Text.Substring(3, 1))
            myRCType.nMultiUserCode1 = Hex2Dec(s(3)) * &H1000 + Hex2Dec(s(2)) * &H100 + Hex2Dec(s(1)) * &H10 + Hex2Dec(s(0))
            panWave.Invalidate()
            Return True
        Else
            If mnuLangEnglish.Checked Then
                errProvider.SetError(txtMultiUserCode1, "Must be an 16-bit Hex digits, e.g. 55AA, 03F2 etc")
            Else
                errProvider.SetError(txtMultiUserCode1, "必须是16位16进制数，如55AA,03F2等")
            End If
            errProvider.Tag = errProvider.Tag Or err
            txtMultiUserCode1.SelectAll()
            Return False
        End If
    End Function

    Private Sub txtMultiUserCode2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMultiUserCode2.Validating
        If Not Check_MultiUserCode2() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_MultiUserCode2() As Boolean
        Dim err As Integer
        Dim str As String
        Dim s(3) As Char

        err = errType.errKey
        str = txtMultiUserCode2.Text.ToUpper
        If str.Length = 4 And str Like "[0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f]" Then
            txtMultiUserCode2.Text = str.ToUpper
            errProvider.SetError(txtMultiUserCode2, "")
            errProvider.Tag = errProvider.Tag And (Not err)
            s(3) = Convert.ToChar(txtMultiUserCode2.Text.Substring(0, 1))
            s(2) = Convert.ToChar(txtMultiUserCode2.Text.Substring(1, 1))
            s(1) = Convert.ToChar(txtMultiUserCode2.Text.Substring(2, 1))
            s(0) = Convert.ToChar(txtMultiUserCode2.Text.Substring(3, 1))
            myRCType.nMultiUserCode2 = Hex2Dec(s(3)) * &H1000 + Hex2Dec(s(2)) * &H100 + Hex2Dec(s(1)) * &H10 + Hex2Dec(s(0))
            panWave.Invalidate()
            Return True
        Else
            If mnuLangEnglish.Checked Then
                errProvider.SetError(txtMultiUserCode2, "Must be an 16-bit Hex digits, e.g. 55AA, 03F2 etc")
            Else
                errProvider.SetError(txtMultiUserCode2, "必须是16位16进制数，如55AA,03F2等")
            End If
            errProvider.Tag = errProvider.Tag Or err
            txtMultiUserCode2.SelectAll()
            Return False
        End If
    End Function

    Private Sub txtMultiUserCode3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMultiUserCode3.Validating
        If Not Check_MultiUserCode3() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_MultiUserCode3() As Boolean
        Dim err As Integer
        Dim str As String
        Dim s(3) As Char

        err = errType.errKey
        str = txtMultiUserCode3.Text.ToUpper
        If str.Length = 4 And str Like "[0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f]" Then
            txtMultiUserCode3.Text = str.ToUpper
            errProvider.SetError(txtMultiUserCode3, "")
            errProvider.Tag = errProvider.Tag And (Not err)
            s(3) = Convert.ToChar(txtMultiUserCode3.Text.Substring(0, 1))
            s(2) = Convert.ToChar(txtMultiUserCode3.Text.Substring(1, 1))
            s(1) = Convert.ToChar(txtMultiUserCode3.Text.Substring(2, 1))
            s(0) = Convert.ToChar(txtMultiUserCode3.Text.Substring(3, 1))
            myRCType.nMultiUserCode3 = Hex2Dec(s(3)) * &H1000 + Hex2Dec(s(2)) * &H100 + Hex2Dec(s(1)) * &H10 + Hex2Dec(s(0))
            panWave.Invalidate()
            Return True
        Else
            If mnuLangEnglish.Checked Then
                errProvider.SetError(txtMultiUserCode3, "Must be an 16-bit Hex digits, e.g. 55AA, 03F2 etc")
            Else
                errProvider.SetError(txtMultiUserCode3, "必须是16位16进制数，如55AA,03F2等")
            End If
            errProvider.Tag = errProvider.Tag Or err
            txtMultiUserCode3.SelectAll()
            Return False
        End If
    End Function

    Private Sub txtData2Code_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtData2Code.Validating
        If Not Check_Data2Code() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_Data2Code() As Boolean
        Dim err As Integer
        Dim str As String
        Dim s(3) As Char

        err = &H4000
        str = txtData2Code.Text.ToUpper
        If str.Length = 4 And str Like "[0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f]" Then
            txtData2Code.Text = str.ToUpper
            errProvider.SetError(txtData2Code, "")
            errProvider.Tag = errProvider.Tag And (Not err)
            s(3) = Convert.ToChar(txtData2Code.Text.Substring(0, 1))
            s(2) = Convert.ToChar(txtData2Code.Text.Substring(1, 1))
            s(1) = Convert.ToChar(txtData2Code.Text.Substring(2, 1))
            s(0) = Convert.ToChar(txtData2Code.Text.Substring(3, 1))
            myRCType.nDataCode2 = Hex2Dec(s(3)) * &H1000 + Hex2Dec(s(2)) * &H100 + Hex2Dec(s(1)) * &H10 + Hex2Dec(s(0))
            panWave.Invalidate()
            Return True
        Else
            If mnuLangEnglish.Checked Then
                errProvider.SetError(txtData2Code, "Must be an 16-bit Hex digits, e.g. 55AA, 03F2 etc")
            Else
                errProvider.SetError(txtData2Code, "必须是16位16进制数，如55AA,03F2等")
            End If
            errProvider.Tag = errProvider.Tag Or err
            txtData2Code.SelectAll()
            Return False
        End If
    End Function


    Private Sub radRevertData1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radRevertData1.CheckedChanged, radData2Changeless.CheckedChanged, radChecksum.CheckedChanged
        If Not bInit Then
            If radRevertData1.Checked Then
                myRCType.nData2Choice = 0
                lblData2Code.Enabled = False
                txtData2Code.Enabled = False
                lblData2ChangelessBits.Enabled = False
                cobData2ChangelessBits.Enabled = False
                lblChecksum.Enabled = False
                txtChecksum.Enabled = False
            ElseIf radData2Changeless.Checked Then
                myRCType.nData2Choice = 1
                lblData2Code.Enabled = True
                txtData2Code.Enabled = True
                lblData2ChangelessBits.Enabled = True
                cobData2ChangelessBits.Enabled = True
                lblChecksum.Enabled = False
                txtChecksum.Enabled = False
            Else
                myRCType.nData2Choice = 2
                lblData2Code.Enabled = False
                txtData2Code.Enabled = False
                lblData2ChangelessBits.Enabled = False
                cobData2ChangelessBits.Enabled = False
                lblChecksum.Enabled = True
                txtChecksum.Enabled = True
            End If
            panWave.Invalidate()
        End If
    End Sub

    Private Sub txtChecksum_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtChecksum.Validating
        If Not Check_Checksum() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_Checksum() As Boolean
        Dim err As Integer
        Dim str As String
        Dim s(1) As Char

        err = &H4000
        str = txtChecksum.Text.ToUpper
        'If s.Length = 2 And (s.Substring(0, 1) Like "*[0-9A-Fa-f]") And (s.Substring(1, 1) Like "*[0-9A-Fa-f]") Then
        If str.Length = 2 And str Like "[0-9A-Fa-f][0-9A-Fa-f]" Then
            txtChecksum.Text = str.ToUpper
            errProvider.SetError(txtChecksum, "")
            errProvider.Tag = errProvider.Tag And (Not err)
            s(1) = Convert.ToChar(txtChecksum.Text.Substring(0, 1))
            s(0) = Convert.ToChar(txtChecksum.Text.Substring(1, 1))
            myRCType.nChecksum = Hex2Dec(s(1)) * 16 + Hex2Dec(s(0))
            panWave.Invalidate()
            Return True
        Else
            If mnuLangEnglish.Checked Then
                errProvider.SetError(txtChecksum, "Must be an 8-bit Hex digits, e.g. 00, EF etc")
            Else
                errProvider.SetError(txtChecksum, "必须是8位16进制数，如00,EF等")
            End If
            errProvider.Tag = errProvider.Tag Or err
            txtChecksum.SelectAll()
            Return False
        End If
    End Function

    Private Sub radHtoL_Stop_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radHtoL_Stop.CheckedChanged
        If mnuLangEnglish.Checked Then
            If (radHtoL_Stop.Checked) Then
                lblStopBitFirst.Text = My.Resources.lblLevelHigh
                lblStopBitSecond.Text = My.Resources.lblLevelLow
            Else
                lblStopBitFirst.Text = My.Resources.lblLevelLow
                lblStopBitSecond.Text = My.Resources.lblLevelHigh
            End If
        Else
            If (radHtoL_Stop.Checked) Then
                lblStopBitFirst.Text = My.Resources.lblLevelHigh_cn
                lblStopBitSecond.Text = My.Resources.lblLevelLow_cn
            Else
                lblStopBitFirst.Text = My.Resources.lblLevelLow_cn
                lblStopBitSecond.Text = My.Resources.lblLevelHigh_cn
            End If
        End If
        If Not bInit Then
            myRCType.bHtoL_Stop = radHtoL_Stop.Checked
            panWave.Invalidate()
        End If
    End Sub

    Private Sub txtStopBitFirst_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtStopBitFirst.Validating
        If Not Check_StopBitFirst() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_StopBitFirst() As Boolean
        Dim fValue As Single
        Dim err As Integer
        Dim max As Single, min As Single

        err = &H8000
        Try
            max = 50000
            min = 1000 / myRCType.fCarrierFreq
            fValue = Convert.ToSingle(txtStopBitFirst.Text)
            If fValue < min Or fValue > max Then
                If mnuLangEnglish.Checked Then
                    errProvider.SetError(txtStopBitFirst, "Exceed value range: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                Else
                    errProvider.SetError(txtStopBitFirst, "设置超出范围: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                End If
                errProvider.Tag = errProvider.Tag Or err
                txtStopBitFirst.SelectAll()
                Return False
            Else
                errProvider.SetError(txtStopBitFirst, "")
                errProvider.Tag = errProvider.Tag And (Not err)
                txtStopBitFirst.Text = fValue.ToString("0.000")
                myRCType.fStopBitFirst = Convert.ToSingle(txtStopBitFirst.Text)
                panWave.Invalidate()
                Return True
            End If
        Catch ex As Exception
            errProvider.SetError(txtStopBitFirst, ex.Message.ToString)
            errProvider.Tag = errProvider.Tag Or err
        End Try
    End Function

    Private Sub txtStopBitSecond_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtStopBitSecond.Validating
        If Not Check_StopBitSecond() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_StopBitSecond() As Boolean
        Dim fValue As Single
        Dim err As Integer
        Dim max As Single, min As Single

        err = &H8000
        Try
            max = 50000
            min = 1000 / myRCType.fCarrierFreq
            fValue = Convert.ToSingle(txtStopBitSecond.Text)
            If fValue < min Or fValue > max Then
                If mnuLangEnglish.Checked Then
                    errProvider.SetError(txtStopBitSecond, "Exceed value range: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                Else
                    errProvider.SetError(txtStopBitSecond, "设置超出范围: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                End If
                errProvider.Tag = errProvider.Tag Or err
                txtStopBitSecond.SelectAll()
                Return False
            Else
                errProvider.SetError(txtStopBitSecond, "")
                errProvider.Tag = errProvider.Tag And (Not err)
                txtStopBitSecond.Text = fValue.ToString("0.000")
                myRCType.fStopBitSecond = Convert.ToSingle(txtStopBitSecond.Text)
                panWave.Invalidate()
                Return True
            End If
        Catch ex As Exception
            errProvider.SetError(txtStopBitSecond, ex.Message.ToString)
            errProvider.Tag = errProvider.Tag Or err
        End Try
    End Function

    Private Sub txtStopTime_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtStopTime.Validating
        If Not Check_StopTime() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_StopTime() As Boolean
        Dim fValue As Single
        Dim err As Integer

        err = &H10000
        Try
            fValue = Convert.ToSingle(txtStopTime.Text)
            If myRCType.bDefineStopTime And (fValue < 0 Or fValue > 500000) Then
                If mnuLangEnglish.Checked Then
                    errProvider.SetError(txtStopTime, "Exceed value range: 0~500000us")
                Else
                    errProvider.SetError(txtStopTime, "设置超出范围: 0~500000us")
                End If
                errProvider.Tag = errProvider.Tag Or err
                txtStopTime.SelectAll()
                Return False
            ElseIf Not myRCType.bDefineStopTime And (fValue < fTimeFrame(6) + 1000 Or fValue > 500000) Then
                If mnuLangEnglish.Checked Then
                    errProvider.SetError(txtStopTime, "Exceed value range: " & (fTimeFrame(6) + 1000).ToString(0.0) & "us~500000us")
                Else
                    errProvider.SetError(txtStopTime, "设置超出范围: " & (fTimeFrame(6) + 1000).ToString(0.0) & "us~500000us")
                End If
                errProvider.Tag = errProvider.Tag Or err
                txtStopTime.SelectAll()
                Return False
            Else
                errProvider.SetError(txtStopTime, "")
                errProvider.Tag = errProvider.Tag And (Not err)
                txtStopTime.Text = fValue.ToString("0.000")
                myRCType.fStopTime = Convert.ToSingle(txtStopTime.Text)
                panWave.Invalidate()
                Return True
            End If
        Catch ex As Exception
            errProvider.SetError(txtStopTime, ex.Message.ToString)
            errProvider.Tag = errProvider.Tag Or err
        End Try
    End Function

    Private Sub radComplete_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radComplete.CheckedChanged
        'grpCompact.Enabled = Not radComplete.Checked
        'grpComplete.Enabled = radComplete.Checked
        If mnuLangEnglish.Checked Then
            If radComplete.Checked Then
                lblRepeatModeGroupA.Text = My.Resources.radComplete
                lblRepeatModeGroupB.Text = My.Resources.radCompact
            Else
                lblRepeatModeGroupB.Text = My.Resources.radComplete
                lblRepeatModeGroupA.Text = My.Resources.radCompact
            End If
        Else
            If radComplete.Checked Then
                lblRepeatModeGroupA.Text = My.Resources.radComplete_cn
                lblRepeatModeGroupB.Text = My.Resources.radCompact_cn
            Else
                lblRepeatModeGroupB.Text = My.Resources.radComplete_cn
                lblRepeatModeGroupA.Text = My.Resources.radCompact_cn
            End If
        End If
        If Not bInit Then
            myRCType.bCompleteRepeat = radComplete.Checked
            panWave.Invalidate()
        End If
    End Sub

    Private Sub txtHighRepeat_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtHighRepeat.Validating
        If Not Check_HighRepeat() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_HighRepeat() As Boolean
        Dim fValue As Single
        Dim err As Integer
        Dim max As Single, min As Single

        err = &H20000
        Try
            max = 50000
            min = 1000 / myRCType.fCarrierFreq
            fValue = Convert.ToSingle(txtHighRepeat.Text)
            If fValue < min Or fValue > max Then
                If mnuLangEnglish.Checked Then
                    errProvider.SetError(txtHighRepeat, "Exceed value range: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                Else
                    errProvider.SetError(txtHighRepeat, "设置超出范围: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                End If
                errProvider.Tag = errProvider.Tag Or err
                txtHighRepeat.SelectAll()
                Return False
            Else
                errProvider.SetError(txtHighRepeat, "")
                errProvider.Tag = errProvider.Tag And (Not err)
                txtHighRepeat.Text = fValue.ToString("0.000")
                myRCType.fHighRepeat = Convert.ToSingle(txtHighRepeat.Text)
                panWave.Invalidate()
                Return True
            End If
        Catch ex As Exception
            errProvider.SetError(txtHighRepeat, ex.Message.ToString)
            errProvider.Tag = errProvider.Tag Or err
        End Try
    End Function

    Private Sub txtLowRepeat_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLowRepeat.Validating
        If Not Check_LowRepeat() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_LowRepeat() As Boolean
        Dim fValue As Single
        Dim err As Integer
        Dim max As Single, min As Single

        err = &H40000
        Try
            max = 50000
            min = 1000 / myRCType.fCarrierFreq
            fValue = Convert.ToSingle(txtLowRepeat.Text)
            If fValue < min Or fValue > max Then
                If mnuLangEnglish.Checked Then
                    errProvider.SetError(txtLowRepeat, "Exceed value range: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                Else
                    errProvider.SetError(txtLowRepeat, "设置超出范围: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                End If
                errProvider.Tag = errProvider.Tag Or err
                txtLowRepeat.SelectAll()
                Return False
            Else
                errProvider.SetError(txtLowRepeat, "")
                errProvider.Tag = errProvider.Tag And (Not err)
                txtLowRepeat.Text = fValue.ToString("0.000")
                myRCType.fLowRepeat = Convert.ToSingle(txtLowRepeat.Text)
                panWave.Invalidate()
                Return True
            End If
        Catch ex As Exception
            errProvider.SetError(txtLowRepeat, ex.Message.ToString)
            errProvider.Tag = errProvider.Tag Or err
        End Try
    End Function

    Private Sub txtRepeatBootHigh_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtRepeatBootHigh.Validating
        If Not Check_RepeatBootHigh() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_RepeatBootHigh() As Boolean
        Dim fValue As Single
        Dim err As Integer
        Dim max As Single, min As Single

        err = &H40000
        Try
            max = 50000
            min = 1000 / myRCType.fCarrierFreq
            fValue = Convert.ToSingle(txtRepeatBootHigh.Text)
            If fValue < min Or fValue > max Then
                If mnuLangEnglish.Checked Then
                    errProvider.SetError(txtRepeatBootHigh, "Exceed value range: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                Else
                    errProvider.SetError(txtRepeatBootHigh, "设置超出范围: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                End If
                errProvider.Tag = errProvider.Tag Or err
                txtRepeatBootHigh.SelectAll()
                Return False
            Else
                errProvider.SetError(txtRepeatBootHigh, "")
                errProvider.Tag = errProvider.Tag And (Not err)
                txtRepeatBootHigh.Text = fValue.ToString("0.000")
                myRCType.fRepeatBootHigh = Convert.ToSingle(txtRepeatBootHigh.Text)
                panWave.Invalidate()
                Return True
            End If
        Catch ex As Exception
            errProvider.SetError(txtRepeatBootHigh, ex.Message.ToString)
            errProvider.Tag = errProvider.Tag Or err
        End Try
    End Function

    Private Sub txtRepeatBootLow_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtRepeatBootLow.Validating
        If Not Check_RepeatBootLow() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_RepeatBootLow() As Boolean
        Dim fValue As Single
        Dim err As Integer
        Dim max As Single, min As Single

        err = &H40000
        Try
            max = 50000
            min = 1000 / myRCType.fCarrierFreq
            fValue = Convert.ToSingle(txtRepeatBootLow.Text)
            If fValue < min Or fValue > max Then
                If mnuLangEnglish.Checked Then
                    errProvider.SetError(txtRepeatBootLow, "Exceed value range: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                Else
                    errProvider.SetError(txtRepeatBootLow, "设置超出范围: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                End If
                errProvider.Tag = errProvider.Tag Or err
                txtRepeatBootLow.SelectAll()
                Return False
            Else
                errProvider.SetError(txtRepeatBootLow, "")
                errProvider.Tag = errProvider.Tag And (Not err)
                txtRepeatBootLow.Text = fValue.ToString("0.000")
                myRCType.fRepeatBootLow = Convert.ToSingle(txtRepeatBootLow.Text)
                panWave.Invalidate()
                Return True
            End If
        Catch ex As Exception
            errProvider.SetError(txtRepeatBootLow, ex.Message.ToString)
            errProvider.Tag = errProvider.Tag Or err
        End Try
    End Function

    Private Sub panWave_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panWave.MouseDown
        nMouseX0 = e.X
        nMouseX1 = e.X
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Cursor = Cursors.NoMoveHoriz
            fWaveStart0 = fWaveStart
            bPan = True
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            Me.Cursor = Cursors.VSplit
            bZoom = True
            panWave.Invalidate()
        End If
    End Sub

    Private Sub panWave_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panWave.MouseMove
        nMouseX1 = e.X
        If bZoom Then
            'If Math.Abs(nMouseX1 - e.X) > 20 Then
            panWave.Invalidate()
            'End IF
        ElseIf bPan Then
            Dim f As Double = fWaveStart0 - (nMouseX1 - nMouseX0) / fPixelPerMs
            fWaveStart = f
            If f < 0 Then fWaveStart = 0
            If f > 1000 - fWaveDuration Then fWaveStart = 1000 - fWaveDuration
            panWave.Invalidate()
        End If

    End Sub

    Private Sub panWave_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panWave.MouseUp
        Me.Cursor = Cursors.Default
        'If bPan Then
        '    Me.Cursor = Cursors.AppStarting
        '    Return
        'End If
        If bZoom Then
            fMouseStart = fWaveStart + (nMouseX0 - Xaxis0) / fPixelPerMs
            fMouseEnd = fWaveStart + (e.X - Xaxis0) / fPixelPerMs
            If fMouseEnd > 1000 Then fMouseEnd = 1000
            If fMouseStart > 1000 Then fMouseStart = 1000
            If fMouseEnd < 0 Then fMouseEnd = 0
            If fMouseStart < 0 Then fMouseStart = 0

            Dim f As Double = Math.Abs(fMouseStart - fMouseEnd)


            If f < 1 Then
                'fWaveDuration = 1

            ElseIf f < 0.01 * fWaveDuration Then
                fWaveDuration = fWaveDuration
            Else
                fWaveDuration = f
                fWaveStart = Math.Min(fMouseStart, fMouseEnd)
            End If
            panWave.Invalidate()
        End If


        bPan = False
        bZoom = False
    End Sub

    Private Sub panWave_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles panWave.Paint
        Dim g As Graphics
        g = e.Graphics

        'Dim fnt As New Font("Arial", 8)
        'g.DrawString(fWaveStart.ToString, fnt, Brushes.White, 0, 0)
        'g.DrawString(nMouseX0.ToString, fnt, Brushes.White, 0, 10)
        'g.DrawString(nMouseX1.ToString, fnt, Brushes.White, 0, 20)

        'g.FillRectangle(Brushes.Black, 0, 0, panWave.Width, panWave.Height)
        DrawWave(g, fWaveStart, fWaveDuration, mnuLangChinese.Checked)
        If bZoom Then
            Dim pn As New Pen(Color.Yellow)

            pn.DashStyle = Drawing2D.DashStyle.Dot

            'If bZoomStart Then
            Dim y0 As Integer = (Yaxis - 5 + Y_LABEL) \ 2
            g.DrawLine(pn, nMouseX0, Yaxis - 5, nMouseX0, Y_LABEL)
            g.DrawLine(pn, nMouseX1, Yaxis - 5, nMouseX1, Y_LABEL)

            pn.StartCap = Drawing2D.LineCap.ArrowAnchor
            pn.EndCap = Drawing2D.LineCap.ArrowAnchor
            pn.DashStyle = Drawing2D.DashStyle.Solid
            pn.Width = 3
            g.DrawLine(pn, nMouseX0, y0, nMouseX1, y0)

            'End If
            'End If
        End If

    End Sub

    Private Sub tolZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tolZoomOut.Click, mnuWaveZoomOut.Click
        Dim fTempDuration As Double

        fTempDuration = fWaveDuration * 1.25
        'fTempStart = fWaveStart + fWaveDuration / 2
        If fTempDuration > 1000 Then
            fWaveDuration = 1000
        Else
            fWaveDuration = fTempDuration
        End If

        'fTempStart = fTempStart - fWaveDuration / 2
        'If fTempStart < 0 Then
        '    fWaveStart = 0
        'Else
        '    fWaveStart = fTempStart
        'End If
        UpdateScroll()
        panWave.Invalidate()
    End Sub

    Private Sub tolZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tolZoomIn.Click, mnuWaveZoomIn.Click
        Dim fTempDuration As Double

        fTempDuration = fWaveDuration * 0.8
        'fTempStart = fWaveStart + fWaveDuration / 2
        If fTempDuration < 1 Then
            fWaveDuration = 1
        Else
            fWaveDuration = fTempDuration
        End If

        'fTempStart = fTempStart - fWaveDuration / 2
        'If fTempStart < 0 Then
        '    fWaveStart = 0
        'Else
        '    fWaveStart = fTempStart
        'End If
        UpdateScroll()
        panWave.Invalidate()
    End Sub

    Private Sub hscWave_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hscWave.ValueChanged
        fWaveStart = hscWave.Value
        panWave.Invalidate()
    End Sub

    Private Sub UpdateScroll()
        hscWave.LargeChange = fWaveDuration / 5 + 1
        hscWave.SmallChange = fWaveDuration / 20 + 1
        hscWave.Minimum = 0
        hscWave.Maximum = 1000 - fWaveDuration + fWaveDuration / 5
        'hscWave.Maximum = 1000
        hscWave.Value = fWaveStart
    End Sub

    Private Sub tolFit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tolFit.Click, mnuWaveFit.Click
        fWaveStart = 0
        fWaveDuration = fTimeFrame(8) / 1000
        UpdateScroll()
        panWave.Invalidate()
    End Sub

    Private Sub cobUserBits_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobUserBits.SelectedIndexChanged
        If Not bInit Then
            myRCType.nUserBits = cobUserBits.SelectedIndex + 1
            panWave.Invalidate()
        End If

    End Sub

    Private Sub cobPositionHi_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobPositionHi.SelectedIndexChanged
        If Not bInit Then
            myRCType.nPositionHi = cobPositionHi.SelectedIndex + 16
            panWave.Invalidate()
        End If
    End Sub

    Private Sub cobPositionLo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobPositionLo.SelectedIndexChanged
        If Not bInit Then
            myRCType.nPositionLo = cobPositionLo.SelectedIndex
            panWave.Invalidate()
        End If
    End Sub

    Private Sub ckbBit1Option_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbBit1Option.CheckedChanged
        If Not bInit Then
            myRCType.bBit1Option = ckbBit1Option.Checked
            panWave.Invalidate()
        End If
    End Sub

    Private Sub cobDataCode1Bits_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobDataCode1Bits.SelectedIndexChanged
        If Not bInit Then
            myRCType.nDataCode1Bits = cobDataCode1Bits.SelectedIndex + 1
            panWave.Invalidate()
        End If
    End Sub

    Private Sub cobUserCode2Bits_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobUserCode2Bits.SelectedIndexChanged
        If Not bInit Then
            myRCType.nUserCode2Bits = cobUserCode2Bits.SelectedIndex + 1
            panWave.Invalidate()
        End If
    End Sub


    Private Sub cobMultiUserBits_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobMultiUserBits.SelectedIndexChanged
        If Not bInit Then
            myRCType.nMultiUserBits = cobMultiUserBits.SelectedIndex + 1
            panWave.Invalidate()
        End If
    End Sub

    Private Sub cobData2ChangelessBits_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobData2ChangelessBits.SelectedIndexChanged
        If Not bInit Then
            myRCType.nDataCode2Bits = cobData2ChangelessBits.SelectedIndex + 1
            panWave.Invalidate()
        End If
    End Sub

    Private Sub radHL0_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radHL0.CheckedChanged, radHL01.CheckedChanged, radHL11.CheckedChanged
        If Not bInit Then
            If radHL0.Checked Then
                myRCType.nRepeatHLX = 0
            ElseIf radHL01.Checked Then
                myRCType.nRepeatHLX = 1
            Else
                myRCType.nRepeatHLX = 2
            End If
            panWave.Invalidate()
        End If
    End Sub

    Private Sub ckbBootCode_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbBootCode.CheckedChanged
        If Not bInit Then
            myRCType.bBootCode = ckbBootCode.Checked
            If Not ckbBootCode.Checked Then
                lblRepeatBootHigh.Enabled = False
                lblRepeatBootLow.Enabled = False
                txtRepeatBootHigh.Enabled = False
                txtRepeatBootLow.Enabled = False
            Else
                lblRepeatBootHigh.Enabled = True
                lblRepeatBootLow.Enabled = True
                txtRepeatBootHigh.Enabled = True
                txtRepeatBootLow.Enabled = True
            End If
            panWave.Invalidate()
        End If
    End Sub

    Private Sub ckbData1Revert_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbData1Revert.CheckedChanged
        If Not bInit Then
            myRCType.bData1Revert = ckbData1Revert.Checked
            panWave.Invalidate()
        End If
    End Sub

    Private Sub ckbUser2Revert_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbUser2Revert.CheckedChanged
        If Not bInit Then
            myRCType.bUser2Revert = ckbUser2Revert.Checked
            panWave.Invalidate()
        End If
    End Sub

    Private Sub ckbData2Revert_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbData2Revert.CheckedChanged
        If Not bInit Then
            myRCType.bData2Revert = ckbData2Revert.Checked
            panWave.Invalidate()
        End If
    End Sub

    Private Sub mnuHelpAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuHelpAbout.Click
        About_nologo.ShowDialog()
    End Sub

    Private Sub InitKeyControl()
        Dim i As Integer, j As Integer, n As Integer

        'tabSetting.TabPages(1).Invalidate()

        lblSingleKeyNote = New Label
        lblSingleKeyNote.Parent = tabSetting.TabPages(1)
        lblSingleKeyNote.Font = New Font("微软雅黑", 12, FontStyle.Regular)
        lblSingleKeyNote.ForeColor = Color.Red
        lblSingleKeyNote.Location = New Point(25, 5)
        lblSingleKeyNote.Size = New Size(150, 25)
        'lblSingleKeyNote.BorderStyle = BorderStyle.FixedSingle

        lblUsageNote = New Label
        lblUsageNote.Parent = tabSetting.TabPages(1)
        lblUsageNote.Font = New Font("微软雅黑", 9, FontStyle.Regular)
        lblUsageNote.ForeColor = Color.Red
        lblUsageNote.Location = New Point(400, 5)
        lblUsageNote.Size = New Size(180, 40)
        'lblUsageNote.TextAlign = ContentAlignment.TopRight
        'lblUsageNote.BorderStyle = BorderStyle.FixedSingle

        Dim btn As KeyButton
        n = 0
        For i = 1 To 11
            For j = 1 To 11 - i + 1
                btn = New KeyButton(tabSetting.TabPages(1), myRCType.nSingleKey(n), myRCType.sSingleKeyLabel(n), n, 60 + (i - 1) * (W_BTN + 1), 30 + (j - 1 + i - 1) * (H_BTN + 1))
                btnAllSingle(n) = btn
                n += 1
                AddHandler btn.MouseClick, AddressOf OnSingleKeyClick
            Next
        Next
        btnAllSingle(65).Visible = True
        For i = 66 To 90
            btn = New KeyButton(tabSetting.TabPages(1), myRCType.nSingleKey(n), myRCType.sSingleKeyLabel(n), n, 0, 0)
            btnAllSingle(i) = btn
            btnAllSingle(i).Visible = False
        Next

        'btnAllSingle(myRCType.nPressKey).Selected = True

        Dim lbl As Label
        Dim fnt As New Font("Arial", 8, FontStyle.Regular)
        'For i = 1 To 11
        For i = 1 To 9
            lbl = New Label
            lbl.Parent = tabSetting.TabPages(1)
            lbl.Location = New Point(0, 30 + (i - 1) * (H_BTN + 1))
            lbl.Size = New Size(60, H_BTN)
            'lbl.AutoSize = True
            lbl.Font = fnt
            lbl.ForeColor = Color.Green
            lbl.TextAlign = ContentAlignment.MiddleRight
            'lbl.BorderStyle = BorderStyle.FixedSingle
            lbl.Text = "S" & i.ToString
        Next

        lblVDDS10 = New Label
        lblVDDS10.Parent = tabSetting.TabPages(1)
        lblVDDS10.Location = New Point(0, 30 + (i - 1) * (H_BTN + 1))
        lblVDDS10.Size = New Size(60, H_BTN)
        'lbl.AutoSize = True
        lblVDDS10.Font = fnt
        lblVDDS10.ForeColor = Color.Green
        lblVDDS10.TextAlign = ContentAlignment.MiddleRight
        lblVDDS10.Text = "S10"

        lbl = New Label
        lbl.Parent = tabSetting.TabPages(1)
        lbl.Location = New Point(0, 30 + i * (H_BTN + 1))
        lbl.Size = New Size(60, H_BTN)
        'lbl.AutoSize = True
        lbl.Font = fnt
        lbl.ForeColor = Color.Green
        lbl.TextAlign = ContentAlignment.MiddleRight
        lbl.Text = "GND"

        'For i = 0 To 11
        For i = 0 To 9
            lbl = New Label
            lbl.Parent = tabSetting.TabPages(1)
            lbl.Location = New Point(60 + i * (W_BTN + 1), 12 * (H_BTN + 1) - 5)
            lbl.Size = New Size(W_BTN, 20)
            lbl.Font = fnt
            lbl.ForeColor = Color.Green
            lbl.TextAlign = ContentAlignment.TopCenter
            'lbl.BorderStyle = BorderStyle.FixedSingle
            lbl.Text = "S" & i.ToString
        Next

        lblS10 = New Label
        lblS10.Parent = tabSetting.TabPages(1)
        lblS10.Location = New Point(60 + i * (W_BTN + 1), 12 * (H_BTN + 1) - 5)
        lblS10.Size = New Size(W_BTN, 20)
        lblS10.Font = fnt
        lblS10.ForeColor = Color.Green
        lblS10.TextAlign = ContentAlignment.TopCenter
        'lbl.BorderStyle = BorderStyle.FixedSingle
        lblS10.Text = "S10"

        'lblDoubleKeyNote = New Label
        'lblDoubleKeyNote.Parent = tabSetting.TabPages(1)
        'lblDoubleKeyNote.Font = New Font("微软雅黑", 12, FontStyle.Regular)
        'lblDoubleKeyNote.ForeColor = Color.Red
        'lblDoubleKeyNote.Location = New Point(25, 14 * (H_BTN + 1) + 20)
        'lblDoubleKeyNote.Size = New Size(170, 25)
        ''lblSingleKeyNote.BorderStyle = BorderStyle.FixedSingle

        'Dim dblkeybtn As DoubleKeyButton
        'For i = 0 To 7
        '    dblkeybtn = New DoubleKeyButton(tabSetting.TabPages(1), _
        '            myRCType.nDoubleKey(i), myRCType.sDoubleKeyLabel(i), _
        '            i, myRCType.nDKX(0, i), myRCType.nDKX(1, i), _
        '            30 + i * (W_DBTN + 1), lblDoubleKeyNote.Bottom + 5)
        '    btnAllDouble(i) = dblkeybtn
        '    AddHandler dblkeybtn.lblMain.MouseClick, AddressOf OnDoubleKeyClick
        '    AddHandler dblkeybtn.lblKey1.MouseClick, AddressOf OnDoubleKeyClick
        '    AddHandler dblkeybtn.lblKey2.MouseClick, AddressOf OnDoubleKeyClick
        'Next
        ''btnAllDouble(6).Visible = False
        'btnAllDouble(7).Visible = False

        'lblTripleKeyNote = New Label
        'lblTripleKeyNote.Parent = tabSetting.TabPages(1)
        'lblTripleKeyNote.Font = New Font("微软雅黑", 12, FontStyle.Regular)
        'lblTripleKeyNote.ForeColor = Color.Red
        'lblTripleKeyNote.Location = New Point(25, lblDoubleKeyNote.Bottom + 70)
        'lblTripleKeyNote.Size = New Size(170, 25)

        'Dim trpkeybtn As TripleKeyButton
        'For i = 0 To 1
        '    trpkeybtn = New TripleKeyButton(tabSetting.TabPages(1), _
        '            myRCType.nTripleKey(i), myRCType.sTripleKeyLabel(i), _
        '            i, myRCType.nTKX(0, i), myRCType.nTKX(1, i), myRCType.nTKX(2, i), _
        '            30 + i * W_TBTN, lblTripleKeyNote.Bottom + 5)
        '    btnAllTriple(i) = trpkeybtn
        '    AddHandler trpkeybtn.lblMain.MouseClick, AddressOf OnTripleKeyClick
        '    AddHandler trpkeybtn.lblKey1.MouseClick, AddressOf OnTripleKeyClick
        '    AddHandler trpkeybtn.lblKey2.MouseClick, AddressOf OnTripleKeyClick
        '    AddHandler trpkeybtn.lblKey3.MouseClick, AddressOf OnTripleKeyClick
        'Next

        'Margin
        Dim lblMargin As New Label
        lblMargin = New Label
        lblMargin.Parent = tabSetting.TabPages(1)
        'lblMargin.Location = New Point(25, lblTripleKeyNote.Bottom + 70)
        lblMargin.Location = New Point(25, lbl.Bottom + 70)
        lblMargin.Size = New Size(100, 25)


    End Sub

    Private Sub RefreshKeyPage()
        Dim i As Integer
        For i = 0 To 90
            btnAllSingle(i).KeyValue = myRCType.nSingleKey(i)
            btnAllSingle(i).KeyLabel = myRCType.sSingleKeyLabel(i)
        Next
        'For i = 0 To 7
        '    btnAllDouble(i).KeyValue = myRCType.nDoubleKey(i)
        '    btnAllDouble(i).KeyLabel = myRCType.sDoubleKeyLabel(i)
        '    btnAllDouble(i).Key1 = myRCType.nDKX(0, i)
        '    btnAllDouble(i).Key2 = myRCType.nDKX(1, i)
        'Next
        'For i = 0 To 1
        '    btnAllTriple(i).KeyValue = myRCType.nTripleKey(i)
        '    btnAllTriple(i).KeyLabel = myRCType.sTripleKeyLabel(i)
        '    btnAllTriple(i).Key1 = myRCType.nTKX(0, i)
        '    btnAllTriple(i).Key2 = myRCType.nTKX(1, i)
        '    btnAllTriple(i).Key3 = myRCType.nTKX(2, i)
        'Next

        For Each btnx As KeyButton In btnAllSingle
            btnx.Selected = False
        Next
        'For Each btnx As DoubleKeyButton In btnAllDouble
        '    btnx.Selected = False
        'Next
        'For Each btnx As TripleKeyButton In btnAllTriple
        '    btnx.Selected = False
        'Next
        Dim nkey As Integer = myRCType.nPressKey
        btnAllSingle(nkey).Selected = True
        'If nkey <= 90 Then
        '    btnAllSingle(nkey).Selected = True
        'ElseIf nkey <= 98 Then
        '    btnAllDouble(nkey - 91).Selected = True
        'Else
        '    btnAllTriple(nkey - 99).Selected = True
        'End If

    End Sub

    Private Sub OnSingleKeyClick(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim btn As KeyButton = CType(sender, KeyButton)
        Dim dlg As SettingSingleKey
        'Dim btnx As KeyButton
        If e.Button = Windows.Forms.MouseButtons.Left Then
            For Each btnx As KeyButton In btnAllSingle
                btnx.Selected = False
            Next
            'For Each btnx As KeyButton In btnAllDouble
            '    btnx.Selected = False
            'Next
            'For Each btnx As KeyButton In btnAllTriple
            '    btnx.Selected = False
            'Next
            btn.Selected = True
            myRCType.nPressKey = btn.KeyNo
            panWave.Invalidate()
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            dlg = New SettingSingleKey(btn, mnuLangChinese.Checked)
            If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
                btn.KeyValue = dlg.nKeyValue
                btn.KeyLabel = dlg.sKeyLabel
                myRCType.nSingleKey(btn.KeyNo) = dlg.nKeyValue
                myRCType.sSingleKeyLabel(btn.KeyNo) = dlg.sKeyLabel
                'MsgBox(btn.KeyLabel & vbCr & btn.KeyValue.ToString("X2"))
                panWave.Invalidate()
            End If
        End If
    End Sub

    'Private Sub OnDoubleKeyClick(ByVal sender As Object, ByVal e As MouseEventArgs)
    '    Dim btn As DoubleKeyButton = CType(sender, Label).Parent
    '    Dim dlg As SettingDoubleKey

    '    If e.Button = Windows.Forms.MouseButtons.Left Then
    '        For Each btnx As KeyButton In btnAllSingle
    '            btnx.Selected = False
    '        Next
    '        For Each btnx As KeyButton In btnAllDouble
    '            btnx.Selected = False
    '        Next
    '        For Each btnx As KeyButton In btnAllTriple
    '            btnx.Selected = False
    '        Next
    '        btn.Selected = True
    '        myRCType.nPressKey = btn.KeyNo + 91
    '        panWave.Invalidate()
    '    ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
    '        dlg = New SettingDoubleKey(btn, mnuLangChinese.Checked)
    '        If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '            btn.KeyValue = dlg.nKeyValue
    '            btn.KeyLabel = dlg.sKeyLabel
    '            btn.Key1 = dlg.nKey1
    '            btn.Key2 = dlg.nKey2
    '            myRCType.nDoubleKey(btn.KeyNo) = dlg.nKeyValue
    '            myRCType.sDoubleKeyLabel(btn.KeyNo) = dlg.sKeyLabel
    '            myRCType.nDKX(0, btn.KeyNo) = dlg.nKey1
    '            myRCType.nDKX(1, btn.KeyNo) = dlg.nKey2
    '            'MsgBox(btn.KeyLabel & vbCr & btn.KeyValue.ToString("X2"))
    '            panWave.Invalidate()
    '        End If
    '    End If
    'End Sub

    'Private Sub OnTripleKeyClick(ByVal sender As Object, ByVal e As MouseEventArgs)
    '    Dim btn As TripleKeyButton = CType(sender, Label).Parent
    '    Dim dlg As SettingTripleKey

    '    If e.Button = Windows.Forms.MouseButtons.Left Then
    '        For Each btnx As KeyButton In btnAllSingle
    '            btnx.Selected = False
    '        Next
    '        For Each btnx As KeyButton In btnAllDouble
    '            btnx.Selected = False
    '        Next
    '        For Each btnx As KeyButton In btnAllTriple
    '            btnx.Selected = False
    '        Next
    '        btn.Selected = True
    '        myRCType.nPressKey = btn.KeyNo + 99
    '        panWave.Invalidate()
    '    ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
    '        dlg = New SettingTripleKey(btn, mnuLangChinese.Checked)
    '        If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '            btn.KeyValue = dlg.nKeyValue
    '            btn.KeyLabel = dlg.sKeyLabel
    '            btn.Key1 = dlg.nKey1
    '            btn.Key2 = dlg.nKey2
    '            btn.Key3 = dlg.nKey3
    '            myRCType.nTripleKey(btn.KeyNo) = dlg.nKeyValue
    '            myRCType.sTripleKeyLabel(btn.KeyNo) = dlg.sKeyLabel
    '            myRCType.nTKX(0, btn.KeyNo) = dlg.nKey1
    '            myRCType.nTKX(1, btn.KeyNo) = dlg.nKey2
    '            myRCType.nTKX(2, btn.KeyNo) = dlg.nKey3
    '            'MsgBox(btn.KeyLabel & vbCr & btn.KeyValue.ToString("X2"))
    '            panWave.Invalidate()
    '        End If
    '    End If
    'End Sub


    Private Sub mnuToolExportS19_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuToolExportS19.Click
        Dim sfDlg As New SaveFileDialog
        Dim getInfo As System.IO.FileInfo

        If mnuLangEnglish.Checked Then
            sfDlg.Filter = "S19 files (*.s19)|*.s19"
        Else
            sfDlg.Filter = "S19文件 (*.s19)|*.s19"
        End If
        'sfDlg.InitialDirectory = sCurrentPath
        'sfDlg.FileName = sCurrentFile

        Me.ActiveControl = CType(cobDuty, Control)
        If CheckError() Then
            'FormToRCType()
            If sfDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
                getInfo = My.Computer.FileSystem.GetFileInfo(sfDlg.FileName)

                sCurrentPath = getInfo.DirectoryName
                SaveS19File(sfDlg.FileName)
                'mnuFileSave.Enabled = True
                'tolSave.Enabled = True
            End If
        End If
    End Sub

    Private Sub mnuToolImportS19_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuToolImportS19.Click
        Dim ofDlg As New OpenFileDialog
        Dim nResult As Integer
        Dim getInfo As System.IO.FileInfo

        ofDlg.Filter = "S19 files (*.s19)|*.s19"
        'ofDlg.InitialDirectory = sCurrentPath

        If ofDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If mnuLangEnglish.Checked Then
                nResult = MessageBox.Show("All the data will be overwritten. Confirm?", "Open", MessageBoxButtons.OKCancel)
            Else
                nResult = MessageBox.Show("所有数据都会被覆盖，确认？", "打开", MessageBoxButtons.OKCancel)
            End If
            If nResult = Windows.Forms.DialogResult.OK Then
                If True Then
                    'mnuFileSave.Enabled = True
                    'tolSave.Enabled = True
                    getInfo = My.Computer.FileSystem.GetFileInfo(ofDlg.FileName)
                    'sCurrentFile = getInfo.Name
                    sCurrentPath = getInfo.DirectoryName
                    'RefreshKeyPage()
                    'RefreshForm()
                    ''FormToRCType()
                    'panWave.Invalidate()
                End If

            End If
        End If
    End Sub


    Private Sub mnuToolImportKeyboard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuToolImportKeyboard.Click, btnImportKeyboard.Click
        Dim ofDlg As New OpenFileDialog
        Dim nResult As Integer
        Dim getInfo As System.IO.FileInfo

        ofDlg.Filter = "RCT files (*.rct)|*.rct"
        'ofDlg.InitialDirectory = sCurrentPath

        If ofDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If mnuLangEnglish.Checked Then
                nResult = MessageBox.Show("Keyboard data will be overwritten. Confirm?", "Open", MessageBoxButtons.OKCancel)
            Else
                nResult = MessageBox.Show("覆盖键盘数据，确认？", "打开", MessageBoxButtons.OKCancel)
            End If
            If nResult = Windows.Forms.DialogResult.OK Then
                If LoadKeyboard(ofDlg.FileName) Then
                    mnuFileSave.Enabled = True
                    tolSave.Enabled = True
                    getInfo = My.Computer.FileSystem.GetFileInfo(ofDlg.FileName)
                    sCurrentFile = getInfo.Name
                    sCurrentPath = getInfo.DirectoryName
                    RefreshKeyPage()
                    RefreshForm()
                    'FormToRCType()
                    panWave.Invalidate()
                End If
            End If
        End If
    End Sub

    Private Function LoadKeyboard(ByVal sName As String) As Boolean
        Dim br As BinaryReader
        Dim i As Integer
        Try
            'If My.Computer.FileSystem.GetFileInfo(sName).Length <> LEN_RCT_FILE Then
            '    MessageBox.Show("RCT File size incorrect!")
            '    Return False
            'End If
            br = New BinaryReader(File.Open(sName, FileMode.Open))
            If Not br.ReadString() = HEAD_RCT_FILE Then
                MessageBox.Show("RCT Head error!")
                Return False
            End If

            br.BaseStream.Seek(-27, SeekOrigin.End)
            'Dim a As Byte = br.ReadByte
            If Not br.ReadString() = TAIL_RCT_FILE Then
                MessageBox.Show("RCT Tail error!")
                Return False
            End If

            br.BaseStream.Seek(0, SeekOrigin.Begin)
            br.ReadString()

            br.ReadBoolean()
            br.ReadSingle()
            br.ReadSingle()
            br.ReadBoolean()
            br.ReadSingle()
            br.ReadSingle()
            br.ReadSingle()
            br.ReadInt32()
            br.ReadBoolean()
            br.ReadBoolean()
            br.ReadInt32()
            br.ReadInt32()
            br.ReadInt32()
            br.ReadSingle()
            br.ReadBoolean()
            br.ReadInt32()
            br.ReadByte()
            br.ReadBoolean()
            br.ReadBoolean()
            br.ReadBoolean()
            br.ReadBoolean()
            br.ReadBoolean()
            br.ReadBoolean()
            br.ReadBoolean()
            br.ReadBoolean()
            br.ReadBoolean()
            br.ReadBoolean()
            br.ReadBoolean()
            br.ReadBoolean()
            'myRCType.bCompact = br.ReadBoolean
            'myRCType.bComplete = br.ReadBoolean
            br.ReadSingle()
            br.ReadSingle()
            br.ReadSingle()
            br.ReadSingle()
            br.ReadUInt32()
            br.ReadInt32()
            br.ReadBoolean()
            br.ReadInt32()
            br.ReadBoolean()
            br.ReadBoolean()
            br.ReadInt32()
            br.ReadBoolean()
            br.ReadInt32()
            br.ReadBoolean()
            br.ReadUInt16()
            br.ReadInt32()
            br.ReadInt32()
            br.ReadInt32()
            br.ReadUInt16()
            br.ReadByte()
            br.ReadBoolean()
            br.ReadSingle()
            br.ReadSingle()
            br.ReadBoolean()
            br.ReadSingle()
            br.ReadBoolean()
            br.ReadSingle()
            br.ReadSingle()
            br.ReadInt32()
            br.ReadBoolean()
            br.ReadSingle()
            br.ReadSingle()
            br.ReadBoolean()
            br.ReadBoolean()
            br.ReadBoolean()
            br.ReadSingle()
            br.ReadInt32()
            For i = 0 To 90
                myRCType.nSingleKey(i) = br.ReadByte
                myRCType.sSingleKeyLabel(i) = br.ReadString
            Next
            'For i = 0 To 7
            '    myRCType.nDoubleKey(i) = br.ReadByte
            '    myRCType.sDoubleKeyLabel(i) = br.ReadString
            '    myRCType.nDKX(0, i) = br.ReadInt32
            '    myRCType.nDKX(1, i) = br.ReadInt32
            'Next
            'For i = 0 To 1
            '    myRCType.nTripleKey(i) = br.ReadByte
            '    myRCType.sTripleKeyLabel(i) = br.ReadString
            '    myRCType.nTKX(0, i) = br.ReadInt32
            '    myRCType.nTKX(1, i) = br.ReadInt32
            '    myRCType.nTKX(2, i) = br.ReadInt32
            'Next
            'myRCType.sInfoName = br.ReadString
            'myRCType.sInfoNote = br.ReadString
            br.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
            Return False
        End Try
    End Function

    Private Sub txtInfoName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtInfoName.Validating
        myRCType.sInfoName = txtInfoName.Text
    End Sub


    Private Sub txtInfoNote_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtInfoNote.Validating
        myRCType.sInfoNote = txtInfoNote.Text
    End Sub

    Private Sub txtRepeatStopTime_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtRepeatStopTime.Validating
        If Not Check_RepeatStopTime() Then
            e.Cancel = True
        End If
    End Sub

    Private Function Check_RepeatStopTime() As Boolean
        Dim fValue As Single
        Dim err As Integer
        Dim max As Single, min As Single

        err = &H40000
        Try
            max = 50000
            min = 1000 / myRCType.fCarrierFreq
            fValue = Convert.ToSingle(txtRepeatStopTime.Text)
            If fValue < min Or fValue > max Then
                If mnuLangEnglish.Checked Then
                    errProvider.SetError(txtRepeatStopTime, "Exceed value range: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                Else
                    errProvider.SetError(txtRepeatStopTime, "设置超出范围: " & min.ToString("0.0") & " ~ " & max.ToString("0.0") & "us")
                End If
                errProvider.Tag = errProvider.Tag Or err
                txtRepeatStopTime.SelectAll()
                Return False
            Else
                errProvider.SetError(txtRepeatStopTime, "")
                errProvider.Tag = errProvider.Tag And (Not err)
                txtRepeatStopTime.Text = fValue.ToString("0.000")
                myRCType.fRepeatStopTime = Convert.ToSingle(txtRepeatStopTime.Text)
                panWave.Invalidate()
                Return True
            End If
        Catch ex As Exception
            errProvider.SetError(txtRepeatStopTime, ex.Message.ToString)
            errProvider.Tag = errProvider.Tag Or err
        End Try
    End Function

    Private Sub cobDuty_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobDuty.SelectedIndexChanged
        If Not bInit Then
            myRCType.nDuty = cobDuty.SelectedIndex
            'panWave.Invalidate()
        End If
    End Sub

    Private Sub radLowBitFirst_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radLowBitFirst.CheckedChanged
        If Not bInit Then
            myRCType.bLowBitFirst = radLowBitFirst.Checked
            panWave.Invalidate()
        End If
    End Sub

    Private Sub radLEDHi_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radLEDHi.CheckedChanged
        If Not bInit Then
            myRCType.bLedHigh = radLEDHi.Checked
            'panWave.Invalidate()
        End If
    End Sub

    Private Sub radL7464_Xor_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radL7464_Xor.CheckedChanged
        If Not bInit Then
            myRCType.bL7464_Xor = radL7464_Xor.Checked
            panWave.Invalidate()
        End If
    End Sub

    Private Sub cobLEDCurrent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobLEDCurrent.SelectedIndexChanged
        If Not bInit Then
            myRCType.nLedCurrent = cobLEDCurrent.SelectedIndex
            'panWave.Invalidate()
        End If
    End Sub

    Private Sub cobIRCurrent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobIRCurrent.SelectedIndexChanged
        If Not bInit Then
            myRCType.nIroutCurrent = cobIRCurrent.SelectedIndex
            Select Case myRCType.nIroutCurrent
                Case RCType.IROUTCurrent.i125ma
                    myRCType.nIRef = 3
                Case RCType.IROUTCurrent.i500ma
                    myRCType.nIRef = 1
                Case Else
                    myRCType.nIRef = 2
            End Select
            'panWave.Invalidate()
        End If
    End Sub

    Private Sub radScanOneTime_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radScanOneTime.CheckedChanged
        If Not bInit Then
            myRCType.bScanOneTime = radScanOneTime.Checked
            'panWave.Invalidate()
        End If
    End Sub

    Private Sub radSameAsBoot_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radSameAsBoot.CheckedChanged
        If Not bInit Then
            myRCType.bSameAsBoot = radSameAsBoot.Checked
            'panWave.Invalidate()
        End If
    End Sub

    Private Sub cobScanInterval_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobScanInterval.SelectedIndexChanged
        If Not bInit Then
            myRCType.nScanInterval = cobScanInterval.SelectedIndex
            'panWave.Invalidate()
        End If
    End Sub

    Private Sub radDefineStopTime_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radDefineStopTime.CheckedChanged
        If Not bInit Then
            myRCType.bDefineStopTime = radDefineStopTime.Checked
            panWave.Invalidate()
        End If
    End Sub


    Private Sub SaveS19File(ByVal sName As String)

        Dim sw As StreamWriter
        Dim OTP(127) As Byte
        Dim i As Integer, j As Integer
        Dim bRevert As Boolean

        For i = 0 To 127
            OTP(i) = &HFF
        Next

        bRevert = myRCType.bLowBitFirst

        '单键键值地址
        '//S0    S1    S2    S3    S4    S5    S6    S7    S8    S9    S10
        '  0X01,	                             	                           //S1   
        '  0X02, 0X12,	                       	                               //S2   
        '  0X03, 0X13, 0X23,	                 	                           //S3   
        '  0X04, 0X14, 0X24, 0X34,	           	                               //S4   
        '  0X05, 0X15, 0X25, 0X35, 0X45,      	                               //S5   
        '  0X06, 0X16, 0X26, 0X36, 0X46, 0X56,	                               //S6   
        '  0X07, 0X17, 0X27, 0X37, 0X47, 0X57,	                               //S7   
        '  0X08, 0X18, 0X28, 0X38, 0X48, 0X58,	                               //S8   
        '  0X09, 0X19, 0X29, 0X39, 0X49, 0X59,	                               //S9   
        '  0X0a, 0X1a, 0X2a, 0X3a, 0X4a, 0X5a,	                               //S10
        '  0X0b, 0X1b, 0X2b, 0X3b, 0X4b, 0X5b,	                               //GND 

        For i = 0 To 5
            For j = i + 1 To 11
                OTP(j + &H10 * i) = ArrangeData(GetKeyValue(i, j), myRCType.nDataCode1Bits, bRevert)
            Next
        Next

        '//S0    S1    S2    S3    S4    S5    S6    S7    S8    S9    S10
        '                                                                        //S1   
        '                                                                        //S2    
        '                                                                        //S3   
        '                                                                        //S4   
        '                                                                        //S5   
        '                                                                        //S6   
        '                                      0X55,	                         //S7   
        '                                      0X54, 0X44,	                     //S8   
        '                                      0X53, 0X43, 0X33,	             //S9   
        '                                      0X52, 0X42, 0X32, 0X22,	         //S10 
        '                                      0X51, 0X41, 0X31, 0X21, 0X11      //GND  

        For i = 0 To 4
            For j = 0 To i
                OTP(j + 1 + &H10 * (i + 1)) = ArrangeData(GetKeyValue(10 - i, 11 - j), myRCType.nDataCode1Bits, bRevert)
            Next
        Next

        ''双按键地址:  任意一个要求高4位值小于低4位值, 不能重复
        ''  0XA1-0XAE 
        ''双按键组合地址:
        ''  0XD0-0XD6
        ''双按键键值地址:
        ''  0X91-0X97
        'Dim sx1 As Integer, sy1 As Integer
        'Dim sx2 As Integer, sy2 As Integer
        'Dim tag_db_key(13) As Byte

        'For i = 0 To 6
        '    'If GetKeyXY(myRCType.nDKX(0, i), sx, sy) Then
        '    '    OTP(&HA1 + i * 2) = sx * 16 + sy
        '    'Else
        '    '    OTP(&HA1 + i * 2) = &HFF
        '    'End If

        '    'If GetKeyXY(myRCType.nDKX(1, i), sx, sy) Then
        '    '    OTP(&HA2 + i * 2) = sx * 16 + sy
        '    'Else
        '    '    OTP(&HA2 + i * 2) = &HFF
        '    'End If
        '    If GetKeyXY(myRCType.nDKX(0, i), sx1, sy1) = False Or GetKeyXY(myRCType.nDKX(1, i), sx2, sy2) = False Then
        '        OTP(&HA1 + i * 2) = &HFF
        '        OTP(&HA2 + i * 2) = &HFF
        '    Else
        '        If sx1 = sx2 Or sy1 = sx2 Then
        '            OTP(&HA1 + i * 2) = sx1 * 16 + sy1
        '            OTP(&HA2 + i * 2) = sx1 * 16 + sy2
        '        ElseIf sx1 = sy2 Then
        '            OTP(&HA1 + i * 2) = sx2 * 16 + sy1
        '            OTP(&HA2 + i * 2) = sx2 * 16 + sy2
        '        ElseIf sy1 = sy2 Then
        '            If sx1 < sx2 Then
        '                OTP(&HA1 + i * 2) = sx1 * 16 + sx2
        '                OTP(&HA2 + i * 2) = sx1 * 16 + sy2
        '            Else
        '                OTP(&HA1 + i * 2) = sx2 * 16 + sx1
        '                OTP(&HA2 + i * 2) = sx2 * 16 + sy2
        '            End If
        '        Else
        '            OTP(&HA1 + i * 2) = sx1 * 16 + sy1
        '            OTP(&HA2 + i * 2) = sx2 * 16 + sy2
        '        End If

        '    End If
        '    OTP(&H91 + i) = ArrangeData(myRCType.nDoubleKey(i), myRCType.nDataCode1Bits, bRevert)
        'Next
        'For i = 0 To 13
        '    tag_db_key(i) = i + 2
        'Next
        'If OTP(&HA1) = &HFF Then tag_db_key(0) = &HFF
        'For i = 1 To 13
        '    If OTP(&HA1 + i) = &HFF Then
        '        tag_db_key(i) = &HFF
        '    Else
        '        For j = 0 To i - 1
        '            If OTP(&HA1 + i) = OTP(&HA1 + j) Then
        '                tag_db_key(i) = j + 2
        '                OTP(&HA1 + i) = &HFF
        '                Exit For
        '            End If
        '        Next
        '    End If
        'Next
        'For i = 0 To 6
        '    If tag_db_key(2 * i) <> &HFF And tag_db_key(2 * i + 1) <> &HFF Then
        '        OTP(&HD0 + i) = tag_db_key(2 * i) * &H10 + tag_db_key(2 * i + 1)
        '    End If
        'Next

        ''三按键地址:  任意一个要求高4位值大于低4位值, 不能重复
        ''  0XB1-0XB6
        ''三按键组合地址:
        ''  0XD7-0XDa
        ''三按键键值地址:
        ''  0X99，0X9b
        'Dim tag_tr_key(5) As Byte
        'Dim sx As Integer, sy As Integer
        'For i = 0 To 1
        '    If GetKeyXY(myRCType.nTKX(0, i), sx, sy) Then
        '        OTP(&HB1 + i * 3) = sy * 16 + sx
        '    Else
        '        OTP(&HB1 + i * 3) = &HFF
        '    End If

        '    If GetKeyXY(myRCType.nTKX(1, i), sx, sy) Then
        '        OTP(&HB2 + i * 3) = sy * 16 + sx
        '    Else
        '        OTP(&HB2 + i * 3) = &HFF
        '    End If

        '    If GetKeyXY(myRCType.nTKX(2, i), sx, sy) Then
        '        OTP(&HB3 + i * 3) = sy * 16 + sx
        '    Else
        '        OTP(&HB3 + i * 3) = &HFF
        '    End If

        '    OTP(&H99 + 2 * i) = ArrangeData(myRCType.nTripleKey(i), myRCType.nDataCode1Bits, bRevert)
        'Next

        'For i = 0 To 5
        '    tag_tr_key(i) = i + 2
        'Next
        'If OTP(&HB1) = &HFF Then tag_tr_key(0) = &HFF
        'For i = 1 To 5
        '    If OTP(&HB1 + i) = &HFF Then
        '        tag_tr_key(i) = &HFF
        '    Else
        '        For j = 0 To i - 1
        '            If OTP(&HB1 + i) = OTP(&HB1 + j) Then
        '                tag_tr_key(i) = j + 2
        '                OTP(&HB1 + i) = &HFF
        '                Exit For
        '            End If
        '        Next
        '    End If
        'Next
        'For i = 0 To 1
        '    If tag_tr_key(3 * i) <> &HFF And tag_tr_key(3 * i + 1) <> &HFF And tag_tr_key(3 * i + 2) <> &HFF Then
        '        OTP(&HD7 + 2 * i) = tag_tr_key(3 * i)
        '        OTP(&HD7 + 2 * i + 1) = tag_tr_key(3 * i + 1) * &H10 + tag_tr_key(3 * i + 2)
        '    End If
        'Next

        '0X0C 0X0D 数据0高电平时间
        '0X0E 0X0F 数据1高电平时间
        '0X1C 0X1D 数据0低电平时间
        '0X1E 0X1F 数据1低电平时间  
        Dim tmp_u16 As UInt16
        'If myRCType.bHtoL_L0 Then
        tmp_u16 = UsToCycle(myRCType.fFirst_L0)
        OTP(&HC) = GetHiByte(tmp_u16)
        OTP(&HD) = GetLoByte(tmp_u16)
        tmp_u16 = UsToCycle(myRCType.fSecond_L0)
        OTP(&H1C) = GetHiByte(tmp_u16)
        OTP(&H1D) = GetLoByte(tmp_u16)
        'Else
        'tmp_u16 = UsToCycle(myRCType.fSecond_L0)
        'OTP(&HB8) = GetHiByte(tmp_u16)
        'OTP(&HB9) = GetLoByte(tmp_u16)
        'tmp_u16 = UsToCycle(myRCType.fFirst_L0)
        'OTP(&HBC) = GetHiByte(tmp_u16)
        'OTP(&HBD) = GetLoByte(tmp_u16)
        'End If

        'If myRCType.bHtoL_L1 Then
        tmp_u16 = UsToCycle(myRCType.fFirst_L1)
        OTP(&HE) = GetHiByte(tmp_u16)
        OTP(&HF) = GetLoByte(tmp_u16)
        tmp_u16 = UsToCycle(myRCType.fSecond_L1)
        OTP(&H1E) = GetHiByte(tmp_u16)
        OTP(&H1F) = GetLoByte(tmp_u16)
        'Else
        'tmp_u16 = UsToCycle(myRCType.fSecond_L1)
        'OTP(&HBA) = GetHiByte(tmp_u16)
        'OTP(&HBB) = GetLoByte(tmp_u16)
        'tmp_u16 = UsToCycle(myRCType.fFirst_L1)
        'OTP(&HBE) = GetHiByte(tmp_u16)
        'OTP(&HBF) = GetLoByte(tmp_u16)
        'End If

        '0X4F      无效键值
        OTP(&H4F) = myRCType.nInvalidKeyCode

        '0X60 0X61 引导帧高电平时间
        '0X62 0X63 引导帧低电平时间 
        tmp_u16 = UsToCycle(myRCType.fBootHigh)
        OTP(&H60) = GetHiByte(tmp_u16)
        OTP(&H61) = GetLoByte(tmp_u16)
        tmp_u16 = UsToCycle(myRCType.fBootLow)
        OTP(&H62) = GetHiByte(tmp_u16)
        OTP(&H63) = GetLoByte(tmp_u16)

        '0X2C 0X2D 用户帧[15:0]数据
        '0X2E      用户帧[15:0]位数
        '0X3C 0X3D 用户帧[32:16]数据
        '0X3E      用户帧[32:16]位数 
        Dim tmp_u32 As UInt32

        If myRCType.bMultiUser Then
            tmp_u16 = ArrangeData(myRCType.nMultiUserCode1, myRCType.nMultiUserBits, bRevert)
            OTP(&H3C) = GetHiByte(tmp_u16)
            OTP(&H3D) = GetLoByte(tmp_u16)
            tmp_u16 = ArrangeData(myRCType.nMultiUserCode2, myRCType.nMultiUserBits, bRevert)
            OTP(&H2C) = GetHiByte(tmp_u16)
            OTP(&H2D) = GetLoByte(tmp_u16)
            OTP(&H2E) = myRCType.nMultiUserBits - 1
            OTP(&H3E) = myRCType.nMultiUserBits - 1
        Else
            tmp_u32 = ArrangeData(myRCType.nUserCode, myRCType.nUserBits, bRevert)
            OTP(&H3C) = (tmp_u32 And &HFF000000L) >> 24
            OTP(&H3D) = (tmp_u32 And &HFF0000L) >> 16
            OTP(&H2C) = (tmp_u32 And &HFF00L) >> 8
            OTP(&H2D) = tmp_u32 And &HFFL
            If myRCType.nUserBits > 16 Then
                OTP(&H3E) = myRCType.nUserBits - 16 - 1
                OTP(&H2E) = 15
            Else
                OTP(&H3E) = 0
                OTP(&H2E) = myRCType.nUserBits - 1
            End If
        End If


        '0X64 0X65 分割帧高电平时间
        '0X66 0X67 分割帧低电平时间
        tmp_u16 = UsToCycle(myRCType.fSplitHigh)
        OTP(&H64) = GetHiByte(tmp_u16)
        OTP(&H65) = GetLoByte(tmp_u16)
        tmp_u16 = UsToCycle(myRCType.fSplitLow)
        OTP(&H66) = GetHiByte(tmp_u16)
        OTP(&H67) = GetLoByte(tmp_u16)

        '0X7E      数据码1位数  
        If Not myRCType.bL7464Check Then
            OTP(&H7E) = myRCType.nDataCode1Bits - 1
        Else
            OTP(&H7E) = 15
        End If

        '0X4C 0X4D 用户码2 16位数据
        '0X4E(用户码2位数)
        If myRCType.bMultiUser Then
            tmp_u16 = ArrangeData(myRCType.nMultiUserCode3, myRCType.nMultiUserBits, bRevert)
            OTP(&H4E) = myRCType.nMultiUserBits - 1
        Else
            tmp_u16 = ArrangeData(myRCType.nUserCode2, myRCType.nUserCode2Bits, bRevert)
            OTP(&H4E) = myRCType.nUserCode2Bits - 1
        End If
        OTP(&H4C) = GetHiByte(tmp_u16)
        OTP(&H4D) = GetLoByte(tmp_u16)

        '0X5C 0X5D 数据码2 16位数据
        '0X5E(数据码2位数)
        tmp_u16 = ArrangeData(myRCType.nDataCode2, myRCType.nDataCode2Bits, bRevert)
        OTP(&H5C) = GetHiByte(tmp_u16)
        OTP(&H5D) = GetLoByte(tmp_u16)
        OTP(&H5E) = myRCType.nDataCode2Bits - 1

        '0X68 0X69 停止帧高电平时间
        '0X6A 0X6B 停止帧低电平时间
        'If myRCType.bHtoL_Stop Then
        tmp_u16 = UsToCycle(myRCType.fStopBitFirst)
        OTP(&H68) = GetHiByte(tmp_u16)
        OTP(&H69) = GetLoByte(tmp_u16)
        tmp_u16 = UsToCycle(myRCType.fStopBitSecond)
        OTP(&H6A) = GetHiByte(tmp_u16)
        OTP(&H6B) = GetLoByte(tmp_u16)
        'Else
        'tmp_u16 = UsToCycle(myRCType.fStopBitSecond)
        'OTP(&HC8) = GetHiByte(tmp_u16)
        'OTP(&HC9) = GetLoByte(tmp_u16)
        'tmp_u16 = UsToCycle(myRCType.fStopBitFirst)
        'OTP(&HCA) = GetHiByte(tmp_u16)
        'OTP(&HCB) = GetLoByte(tmp_u16)
        'End If

        '0X7A 0X7B 帧周期
        tmp_u16 = UsToCycle(myRCType.fStopTime)
        OTP(&H7A) = GetHiByte(tmp_u16)
        OTP(&H7B) = GetLoByte(tmp_u16)

        Dim tmp_byte As Byte
        '0X7C 0X7D 发码时长
        If Not myRCType.bCountLimit Then
            OTP(&H7C) = 0
            OTP(&H7D) = 0
        Else
            If Not myRCType.bDoubleFrame Then
                OTP(&H7C) = (myRCType.nKeyRemainTime - 1) \ 256
                OTP(&H7D) = (myRCType.nKeyRemainTime - 1) Mod 256
            Else
                OTP(&H7C) = (2 * myRCType.nKeyRemainTime - 1) \ 256
                OTP(&H7D) = (2 * myRCType.nKeyRemainTime - 1) Mod 256
            End If
        End If


        '0X2F(抬手码)
        OTP(&H2F) = myRCType.nUpKeyCode

        '0X3F(滤波时间)
        tmp_byte = myRCType.fDebounce * myRCType.fCarrierFreq / 16
        OTP(&H3F) = tmp_byte

        '0X6C 0X6D 重复帧高电平时间
        '0X6E 0X6F 重复帧低电平时间
        If myRCType.bRepeatModeGroup Then
            tmp_u16 = UsToCycle(myRCType.fHighRepeat)
            OTP(&H6C) = GetHiByte(tmp_u16)
            OTP(&H6D) = GetLoByte(tmp_u16)
            tmp_u16 = UsToCycle(myRCType.fLowRepeat)
            OTP(&H6E) = GetHiByte(tmp_u16)
            OTP(&H6F) = GetLoByte(tmp_u16)
        Else
            If myRCType.bCompleteRepeat Then
                tmp_u16 = UsToCycle(myRCType.fRepeatBootHigh)
                OTP(&H6C) = GetHiByte(tmp_u16)
                OTP(&H6D) = GetLoByte(tmp_u16)
                tmp_u16 = UsToCycle(myRCType.fRepeatBootLow)
                OTP(&H6E) = GetHiByte(tmp_u16)
                OTP(&H6F) = GetLoByte(tmp_u16)
            Else
                tmp_u16 = UsToCycle(myRCType.fHighRepeat)
                OTP(&H6C) = GetHiByte(tmp_u16)
                OTP(&H6D) = GetLoByte(tmp_u16)
                tmp_u16 = UsToCycle(myRCType.fLowRepeat)
                OTP(&H6E) = GetHiByte(tmp_u16)
                OTP(&H6F) = GetLoByte(tmp_u16)
            End If
        End If

        '0X74(占空比低8位)
        '0X75(周期低8位)
        '0X76(占空比高4位 + 周期高4位)
        Dim period As UInt16
        Dim duty_low As UInt16
        period = HRC_FREQ / myRCType.fCarrierFreq - 1
        If myRCType.nDuty = RCType.CarrierDuty.quarter Then
            duty_low = 3 * period / 4 - 1
        ElseIf myRCType.nDuty = RCType.CarrierDuty.third Then
            duty_low = 2 * period / 3 - 1
        Else
            duty_low = period / 2 - 1
        End If
        OTP(&H74) = GetLoByte(duty_low)
        OTP(&H75) = GetLoByte(period)
        'tmp_u16 = GetHiByte(duty_low)
        OTP(&H76) = GetHiByte(duty_low) * &H10 + GetHiByte(period)

        '0X70      
        '7-6: 扫描周期 00：32ms 01：16ms 10：4ms 11：1ms 
        '5：1:vdd扫描使能    
        '4：1:60K 0:150K  					
        '3：1:led使能
        '2：1:led高有效 0:led低有效  		
        '1-0：led电流 00：1ma 01：2ma 10：4ma 11：8ma   
        OTP(&H70) = 0
        If myRCType.nScanInterval = RCType.ScanInterval.s32ms Then
            OTP(&H70) += 0
        ElseIf myRCType.nScanInterval = RCType.ScanInterval.s16ms Then
            OTP(&H70) += &H40
        ElseIf myRCType.nScanInterval = RCType.ScanInterval.s4ms Then
            OTP(&H70) += &H80
        Else
            OTP(&H70) += &HC0
        End If
        If myRCType.bVDDKeyScan Then
            OTP(&H70) = OTP(&H70) Or &H20
        End If
        If myRCType.b150K Then
            OTP(&H70) = OTP(&H70) Or &H10
        End If
        If myRCType.bLedEnable Then
            OTP(&H70) = OTP(&H70) Or &H8
        End If
        If myRCType.bLedHigh Then
            OTP(&H70) = OTP(&H70) Or &H4
        End If
        If myRCType.nLedCurrent = RCType.LEDCurrent.i2ma Then
            OTP(&H70) += &H1
        ElseIf myRCType.nLedCurrent = RCType.LEDCurrent.i4ma Then
            OTP(&H70) += &H2
        ElseIf myRCType.nLedCurrent = RCType.LEDCurrent.i8ma Then
            OTP(&H70) += &H3
        End If

        '0X73      
        '7：  fcpus OTP读时间 1：高速 0：低速 
        '6-5：基准电流选择 00：6u 01:3u 10:1.5u 11:0.75u  					
        '4：  LDO电压 1:1.5V 0:1.44V
        '3-2：开关管驱动速率 00:10ns  01：2us  10：1us  11：500n
        '1-0：REM电流  00:125mA  01：250mA 10：375mA 11：500mA
        OTP(&H73) = 0
        If myRCType.bHighSpeed Then
            OTP(&H73) = OTP(&H73) Or &H80
        End If
        If myRCType.nIRef = 0 Then
            OTP(&H73) += 0
        ElseIf myRCType.nIRef = 1 Then
            OTP(&H73) += &H20
        ElseIf myRCType.nIRef = 2 Then
            OTP(&H73) += &H40
        Else
            OTP(&H73) += &H60
        End If
        If myRCType.bLDO17 Then
            OTP(&H73) = OTP(&H73) Or &H10
        End If
        If myRCType.nDriveSpeed = 0 Then
            OTP(&H73) += 0
        ElseIf myRCType.nDriveSpeed = 1 Then
            OTP(&H73) += 4
        ElseIf myRCType.nDriveSpeed = 2 Then
            OTP(&H73) += 8
        Else
            OTP(&H73) += &HC
        End If
        If myRCType.nIroutCurrent = RCType.IROUTCurrent.i125ma Then
            OTP(&H73) += 0
        ElseIf myRCType.nIroutCurrent = RCType.IROUTCurrent.i250ma Then
            OTP(&H73) += 1
        ElseIf myRCType.nIroutCurrent = RCType.IROUTCurrent.i375ma Then
            OTP(&H73) += 2
        Else
            OTP(&H73) += 3
        End If

        '0X00      
        '  7：1-引导帧使能
        '  6：1-用户帧[15:0]使能
        '  5：1-用户帧[31:16]使能
        '  4：1-分割帧使能
        '  3：1-用户码2使能
        '  2：1-数据码2使能
        '  1：1-LC7464校验使能，同时需要将数据码1的位数设置为16位
        '  0：1-停止位使能
        OTP(0) = 0
        If myRCType.bBootFrame Then
            OTP(0) = OTP(0) Or &H80
        End If
        If myRCType.bUserFrame Then
            OTP(0) = OTP(0) Or &H40
        End If
        If myRCType.nUserBits > 16 And myRCType.bUserFrame Then
            OTP(0) = OTP(0) Or &H20
        End If
        If myRCType.bSplitFrame Then
            OTP(0) = OTP(0) Or &H10
        End If
        If myRCType.bUserCode2 Then
            OTP(0) = OTP(0) Or &H8
        End If
        If myRCType.bDataCode2 Then
            OTP(0) = OTP(0) Or &H4
        End If
        If myRCType.bL7464Check Then
            OTP(0) = OTP(0) Or &H2
        End If
        If myRCType.bStopBit Then
            OTP(0) = OTP(0) Or &H1
        End If


        '0X10      
        '  7：1-结束码时间定义使能 0-帧周期
        '  6：1-简单重复码 0-完整重复码
        '  5：1-简单重复码带数据位 0-简单重复码无数据位
        '  4：1-简单重复码数据位为1 0-简单重复码数据位为0
        '  3：1-完整重复码引导使能
        '  2：1-完整重复码数据码交替取反使能
        '  1：1-用户帧[15:0]按位取反使能
        '  0：1-用户帧[31:16]按位取反使能  

        OTP(&H10) = 0
        If myRCType.bDefineStopTime Then
            OTP(&H10) = OTP(&H10) Or &H80
        End If
        If Not myRCType.bCompleteRepeat Then
            OTP(&H10) = OTP(&H10) Or &H40
        End If
        If myRCType.nRepeatHLX = 1 Then
            OTP(&H10) = OTP(&H10) Or &H20
        End If
        If myRCType.nRepeatHLX = 2 Then
            OTP(&H10) = OTP(&H10) Or &H30
        End If
        If myRCType.bBootCode Then
            OTP(&H10) = OTP(&H10) Or &H8
        End If
        If myRCType.bData1Revert Then
            OTP(&H10) = OTP(&H10) Or &H4
        End If

        If myRCType.bRevertBitLo Then
            OTP(&H10) = OTP(&H10) Or &H2
        End If
        If myRCType.bRevertBitHi Then
            OTP(&H10) = OTP(&H10) Or &H1
        End If


        '0X20 
        '  7：1-位扩展使能,时间双倍使能
        '  6：1-双帧发送模式
        '  5：1-结束码期间扫描单次
        '  4：1-bit1 3F使能   
        '  3：1-数据码2为数据码的反码  
        '  2：1-数据0先低后高 0-数据0先高后低
        '  1：1-数据1先低后高 0-数据1先高后低
        '  0：1-停止位先低后高 0-停止位先高后低 
        OTP(&H20) = 0

        If myRCType.bBitExpand Then
            OTP(&H20) = OTP(&H20) Or &H80
        End If
        If myRCType.bDoubleFrame Then
            OTP(&H20) = OTP(&H20) Or &H40
        End If
        If myRCType.bScanOneTime Then
            OTP(&H20) = OTP(&H20) Or &H20
        End If
        If myRCType.bBit1Option Then
            OTP(&H20) = OTP(&H20) Or &H10
        End If
        If myRCType.nData2Choice = 0 Then
            OTP(&H20) = OTP(&H20) Or &H8
        End If
        If Not myRCType.bHtoL_L0 Then
            OTP(&H20) = OTP(&H20) Or &H4
        End If
        If Not myRCType.bHtoL_L1 Then
            OTP(&H20) = OTP(&H20) Or &H2
        End If
        If Not myRCType.bHtoL_Stop Then
            OTP(&H20) = OTP(&H20) Or &H1
        End If

        '0X30
        '7-4：用户帧[15:0]按位取反位置            
        '3-0：用户帧[32:16]按位取反位置 
        OTP(&H30) = myRCType.nPositionLo * 16 + (myRCType.nPositionHi - 16)

        '0X40      
        '7: 1-
        '6：1-
        '5：1-完全重复码选择引导帧时间(60-63) 0-选择简单重复码时间（6C-6F)
        '4：1-hirc输出到led管脚  
        '3：1-1986格式使能          
        '2：1-7464异或校验 0-7464求和校验
        '1：1-重复数据帧使能
        '0：1-抬手码使能  
        OTP(&H40) = 0
        If myRCType.bSameAsBoot Then
            OTP(&H40) = OTP(&H40) Or &H20
        End If
        If Not myRCType.bNotConn Then
            OTP(&H40) = OTP(&H40) Or &H10
        End If
        If myRCType.b1986Enable Then
            OTP(&H40) = OTP(&H40) Or &H8
        End If
        If myRCType.bL7464_Xor Then
            OTP(&H40) = OTP(&H40) Or &H4
        End If
        If myRCType.bRepeatDataFrame Then
            OTP(&H40) = OTP(&H40) Or &H2
        End If
        If myRCType.bUpKeyEnable Then
            OTP(&H40) = OTP(&H40) Or &H1
        End If

        Dim sx As Integer, sy As Integer
        '0X50(重复码模式设置)
        'OTP(&H50) = myRCType.nRepeatGroupBoundry
        If GetKeyXY(myRCType.nRepeatGroupBoundry, sx, sy) And myRCType.bRepeatModeGroup Then
            OTP(&H50) = sx * 16 + sy
        Else
            OTP(&H50) = &HFF
        End If

        '0X78      用户码A（用户帧[31:16])设置
        '0X79      用户码B(用户码2)设置
        If myRCType.bMultiUser Then
            If GetKeyXY(myRCType.nMultiUserBoundry1, sx, sy) Then
                OTP(&H78) = sx * 16 + sy
            Else
                OTP(&H78) = &HFF
            End If
            If GetKeyXY(myRCType.nMultiUserBoundry2, sx, sy) Then
                OTP(&H79) = sx * 16 + sy
            Else
                OTP(&H79) = &HFF
            End If
            'OTP(&H78) = myRCType.nMultiUserBoundry1
            'OTP(&H79) = myRCType.nMultiUserBoundry2
        Else
            OTP(&H78) = 0
            OTP(&H79) = &HFF
        End If

        ''For beta1
        'OTP(&H40) = 0
        'OTP(&H78) = 0

        '0X72
        '7-3：温度校准位   
        OTP(&H72) = myRCType.nTempValue * 8 + 7

        Dim sum As UInt32
        Try
            sw = New StreamWriter(sName)
            For i = 0 To 7
                sum = 0
                sw.Write("S123{0:X4}", i * 32)
                For j = 0 To 15
                    sw.Write("{0:X2}00", OTP(i * 16 + j))
                    sum += OTP(i * 16 + j)
                Next
                sw.WriteLine("{0:X2}", sum And &HFF)
            Next
            sw.WriteLine("S903FFFFFE")
            'For i = 0 To 255
            '    sw.WriteLine("{0:X2} {1:X2}", i, OTP(i))
            'Next
            sw.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try

        Dim bw As BinaryWriter
        Try
            bw = New BinaryWriter(File.Open(sName.Substring(0, sName.Length - 4) & ".TXT", FileMode.Create))
            For i = 0 To 127
                bw.Write(OTP(i))
            Next
            bw.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Function GetKeyValue(ByVal SX As Integer, ByVal SY As Integer)
        'Dim n As Integer
        'n = KEY_MATRIX(SY, SX)
        'If n >= 78 And n <= 89 Then
        '    Return myRCType.nSingleKey(n - 12)
        'Else
        '    Return myRCType.nSingleKey(n)
        'End If
        Return myRCType.nSingleKey(KEY_MATRIX(SY, SX))
    End Function

    Private Function GetKeyXY(ByVal key As Integer, ByRef SX As Integer, ByRef SY As Integer) As Boolean
        Dim i As Integer, j As Integer
        If key > 90 Then
            SX = &HFF
            SY = &HFF
            Return False
        End If

        For i = 0 To 12
            For j = 0 To 13
                If key = KEY_MATRIX(j, i) Then
                    SX = i
                    If j = 13 Then
                        SY = 12
                    Else
                        SY = j
                    End If
                    Return True
                End If
            Next
        Next

    End Function

    Private Function UsToCycle(ByVal t As Single) As UInt16
        Return t * myRCType.fCarrierFreq / 1000 - 1
    End Function

    Private Function GetHiByte(ByVal u16 As UInt16) As Byte
        Return (u16 And &HFF00) >> 8
    End Function

    Private Function GetLoByte(ByVal u16 As UInt16) As Byte
        Return u16 And &HFF
    End Function

    Private Function ArrangeData(ByVal u32 As UInt32, ByVal n As Integer, ByVal bRevert As Boolean) As UInt32
        Dim i As Integer
        Dim mask As UInt64, tmp As UInt32

        If Not bRevert Then
            mask = &H1L
            tmp = tmp Or (u32 And mask)
            For i = 1 To n - 1
                mask <<= 1
                tmp <<= 1
                If u32 And mask Then
                    tmp = tmp Or &H1
                End If
                'tmp = tmp Or (u32 And mask)
            Next
            mask = &HFFFFFFFFUL << n
            Return tmp Or (mask And u32)
        Else
            'mask = &HFFFFFFFFL >> (32 - n)
            'Return (u32 And mask)
            Return u32
        End If
    End Function

    'for Debug
    Private Sub radFilterEnable_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radFilterEnable.CheckedChanged
        If Not bInit Then
            myRCType.bFilterEnable = radFilterEnable.Checked
            'panWave.Invalidate()
        End If
    End Sub

    Private Sub cobTempValue_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobTempValue.SelectedIndexChanged
        If Not bInit Then
            myRCType.nTempValue = cobTempValue.SelectedIndex
            'panWave.Invalidate()
        End If
    End Sub

    Private Sub radHighSpeed_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radHighSpeed.CheckedChanged
        If Not bInit Then
            myRCType.bHighSpeed = radHighSpeed.Checked
            'panWave.Invalidate()
        End If
    End Sub

    Private Sub radLDO15_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radLDO15.CheckedChanged
        If Not bInit Then
            myRCType.bLDO17 = radLDO17.Checked
            'panWave.Invalidate()
        End If
    End Sub

    Private Sub cobDriveSpeed_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobDriveSpeed.SelectedIndexChanged
        If Not bInit Then
            myRCType.nDriveSpeed = cobDriveSpeed.SelectedIndex
            'panWave.Invalidate()
        End If
    End Sub

    Private Sub cobIRef_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobIRef.SelectedIndexChanged
        If Not bInit Then
            myRCType.nIRef = cobIRef.SelectedIndex
            'panWave.Invalidate()
        End If
    End Sub


    Private Sub rad150K_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rad150K.CheckedChanged
        If Not bInit Then
            myRCType.b150K = rad150K.Checked
            'panWave.Invalidate()
        End If
    End Sub


    Private Sub radNotOD_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radNotOD.CheckedChanged
        If Not bInit Then
            myRCType.bNotOD = radNotOD.Checked
            'panWave.Invalidate()
        End If
    End Sub


    Private Sub radConn_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radConn.CheckedChanged
        If Not bInit Then
            myRCType.bNotConn = radNotConn.Checked
            'panWave.Invalidate()
        End If
    End Sub

    Private Sub UpdateLabelRangeKey()
        'lblRangeKey1.Text = "K00 - K" & myRCType.nMultiUserBoundry1.ToString("00")
        lblRangeKey2.Text = "K" & (myRCType.nMultiUserBoundry1 + 1).ToString("00") & " - K"
        lblRangeKey3.Text = "K" & (myRCType.nMultiUserBoundry2 + 1).ToString("00") & " - K65"
        lblRepeatGroupBRange.Text = "K" & (myRCType.nRepeatGroupBoundry + 1).ToString("00") & " - K65"
    End Sub


End Class