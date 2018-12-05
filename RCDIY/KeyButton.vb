Public Class KeyButton
    Inherits Label
    Protected nKeyValue As Byte
    Protected sKeyLabel As String
    Protected nKeyNo As Integer
    Protected bSelected As Boolean
    Protected bEnable As Boolean

    Sub New(ByVal cParent As Control, _
        ByVal b As Byte, _
        ByVal s As String, _
        ByVal n As Integer, _
        ByVal x As Integer, ByVal y As Integer)

        Parent = cParent
        Size = New Size(W_BTN, H_BTN)
        Location = New Point(x, y)
        nKeyValue = b
        sKeyLabel = s
        nKeyNo = n
        bSelected = False
        bEnable = True
        SetText()

        Font = New Font("Arial Narrow", 8, FontStyle.Regular)
        ForeColor = Color.Blue
        'BackColor = Color.Tomato
        BackColor = Color.BurlyWood
        BorderStyle = Windows.Forms.BorderStyle.FixedSingle
        TextAlign = ContentAlignment.MiddleCenter
    End Sub

    Public Property KeyValue() As Byte
        Get
            Return nKeyValue
        End Get
        Set(ByVal value As Byte)
            nKeyValue = value
            SetText()
        End Set
    End Property

    Public Property KeyLabel() As String
        Get
            Return sKeyLabel
        End Get
        Set(ByVal value As String)
            sKeyLabel = value
            SetText()
        End Set
    End Property

    Public ReadOnly Property KeyNo() As Integer
        Get
            Return nKeyNo
        End Get
    End Property

    Public Property Selected() As Boolean
        Get
            Return bSelected
        End Get
        Set(ByVal value As Boolean)
            bSelected = value
            If value Then
                Me.BackColor = Color.Tomato
            Else
                'Me.BackColor = Color.BurlyWood
                If bEnable Then
                    Me.BackColor = Color.BurlyWood
                Else
                    Me.BackColor = Color.Gray
                End If
            End If
        End Set
    End Property

    Public Property Enable() As Boolean
        Get
            Return bEnable
        End Get
        Set(ByVal value As Boolean)
            bEnable = value
            If value = False Then
                Me.BackColor = Color.Gray
            Else
                If bSelected Then
                    Me.BackColor = Color.Tomato
                Else
                    Me.BackColor = Color.BurlyWood
                End If

            End If
        End Set
    End Property

    Protected Sub SetText()
        Dim s As String
        'If sKeyLabel.Length > 10 Then
        '    s = sKeyLabel.Substring(0, 10)
        'Else
        '    s = sKeyLabel
        'End If
        s = sKeyLabel
        Text = "K" & nKeyNo.ToString("00") & " (" & nKeyValue.ToString("X2") & ")" & vbCr & s
    End Sub
End Class

Public Class SettingSingleKey
    Inherits Form
    Public sKeyLabel As String
    Public nKeyValue As Byte
    Private txtKeyLabel As TextBox
    Private txtKeyValue As TextBox
    Private bLang_cn As Boolean

    Sub New(ByVal btnkey As KeyButton, ByVal bLang As Boolean)
        sKeyLabel = btnkey.KeyLabel
        nKeyValue = btnkey.KeyValue
        bLang_cn = bLang

        FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        ControlBox = False
        MaximizeBox = False
        MinimizeBox = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        Size = New Size(200, 160)

        Dim lblKeyNo As New Label
        lblKeyNo.Parent = Me
        lblKeyNo.Left = 0
        lblKeyNo.Top = 10
        lblKeyNo.Size = New Size(70, 20)
        lblKeyNo.TextAlign = ContentAlignment.BottomRight

        Dim lbl As New Label
        lbl.Parent = Me
        lbl.Left = lblKeyNo.Right + 5
        lbl.Top = lblKeyNo.Top
        lbl.Size = New Size(70, 20)
        lbl.TextAlign = ContentAlignment.BottomLeft
        lbl.Text = "K" & btnkey.KeyNo.ToString("00")

        Dim lblKeyValue As New Label
        lblKeyValue.Parent = Me
        lblKeyValue.Left = 0
        lblKeyValue.Top = lblKeyNo.Bottom + 5
        lblKeyValue.Size = New Size(70, 20)
        lblKeyValue.TextAlign = ContentAlignment.BottomRight
        'lblKeyValue.BorderStyle = BorderStyle.FixedSingle

        Dim lblKeyLabel As New Label
        lblKeyLabel.Parent = Me
        lblKeyLabel.Left = lblKeyValue.Left
        lblKeyLabel.Top = lblKeyValue.Bottom + 5
        lblKeyLabel.Size = lblKeyValue.Size
        lblKeyLabel.TextAlign = ContentAlignment.BottomRight
        'lblKeyLabel.BorderStyle = BorderStyle.FixedSingle

        txtKeyValue = New TextBox
        txtKeyValue.Parent = Me
        txtKeyValue.Left = lblKeyValue.Right + 5
        txtKeyValue.Top = lblKeyValue.Top
        txtKeyValue.Size = New Size(100, 20)
        txtKeyValue.MaxLength = 2
        txtKeyValue.Text = nKeyValue.ToString("X2")

        txtKeyLabel = New TextBox
        txtKeyLabel.Parent = Me
        txtKeyLabel.Left = lblKeyLabel.Right + 5
        txtKeyLabel.Top = lblKeyLabel.Top
        txtKeyLabel.Size = New Size(100, 20)
        txtKeyLabel.MaxLength = 32
        txtKeyLabel.Text = sKeyLabel

        Dim btnOK As New Button
        btnOK.Parent = Me
        btnOK.Left = 25
        btnOK.Top = lblKeyLabel.Bottom + 10
        btnOK.Size = New Size(70, 25)
        AddHandler btnOK.Click, AddressOf OnButtonOKClick

        Dim btnCancel As New Button
        btnCancel.Parent = Me
        btnCancel.Left = btnOK.Right + 10
        btnCancel.Top = btnOK.Top
        btnCancel.Size = btnOK.Size
        AddHandler btnCancel.Click, AddressOf OnButtonCancelClick

        If bLang Then
            Text = "设置按键K" & btnkey.KeyNo.ToString("00")
            btnOK.Text = "确认"
            btnCancel.Text = "取消"
            lblKeyNo.Text = "单键编号"
            lblKeyValue.Text = "键码"
            lblKeyLabel.Text = "按键标识"
        Else
            Text = "Setting Key K" & btnkey.KeyNo.ToString("00")
            btnOK.Text = "OK"
            btnCancel.Text = "Cancel"
            lblKeyNo.Text = "Key No."
            lblKeyValue.Text = "Key Code"
            lblKeyLabel.Text = "Key Label"
        End If
    End Sub


    Sub OnButtonOKClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim str As String
        Dim s(1) As Char

        str = txtKeyValue.Text.ToUpper

        If str.Length = 2 And str Like "[0-9A-Fa-f][0-9A-Fa-f]" Then
            txtKeyValue.Text = str.ToUpper
            s(1) = Convert.ToChar(str.Substring(0, 1))
            s(0) = Convert.ToChar(str.Substring(1, 1))
            nKeyValue = Hex2Dec(s(1)) * 16 + Hex2Dec(s(0))
            sKeyLabel = txtKeyLabel.Text
            DialogResult = Windows.Forms.DialogResult.OK
        Else
            If bLang_cn Then
                MessageBox.Show("键码必须是8位16进制数，如00,EF等", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Key Code must be an 8-bit Hex digits, e.g. 00, EF etc", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            txtKeyValue.Select(0, str.Length)
            txtKeyValue.Focus()
        End If
    End Sub

    Sub OnButtonCancelClick(ByVal sender As Object, ByVal e As EventArgs)
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

End Class

Public Class DoubleKeyButton
    Inherits KeyButton

    Public lblKey1 As Label
    Public lblKey2 As Label
    Public lblMain As Label
    Private nKey1 As Integer
    Private nKey2 As Integer

    Sub New(ByVal cParent As Control, _
        ByVal b As Byte, _
        ByVal s As String, _
        ByVal n As Integer, _
        ByVal k1 As Integer, _
        ByVal k2 As Integer, _
        ByVal x As Integer, ByVal y As Integer)

        MyBase.New(cParent, b, s, n, x, y)
        Size = New Size(W_DBTN, H_DBTN)

        nKey1 = k1
        nKey2 = k2

        lblKey1 = New Label
        lblKey1.Parent = Me
        lblKey1.Font = New Font("Arial Narrow", 8, FontStyle.Regular)
        lblKey1.ForeColor = Color.Blue
        lblKey1.TextAlign = ContentAlignment.MiddleCenter
        lblKey1.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
        lblKey1.Top = -1
        lblKey1.Left = -1
        lblKey1.Size = New Size((W_DBTN + 1) \ 2, 20)

        lblKey2 = New Label
        lblKey2.Parent = Me
        lblKey2.Font = lblKey1.Font
        lblKey2.ForeColor = lblKey1.ForeColor
        lblKey2.TextAlign = lblKey1.TextAlign
        lblKey2.BorderStyle = lblKey1.BorderStyle
        lblKey2.Top = -1
        lblKey2.Left = lblKey1.Right - 1
        lblKey2.Size = lblKey1.Size

        lblMain = New Label
        lblMain.Parent = Me
        lblMain.Font = lblKey1.Font
        lblMain.ForeColor = lblKey1.ForeColor
        lblMain.TextAlign = lblKey1.TextAlign
        lblMain.BorderStyle = lblKey1.BorderStyle
        lblMain.Top = lblKey1.Bottom - 1
        lblMain.Left = -1
        lblMain.Width = W_DBTN
        lblMain.Height = H_DBTN - lblKey1.Height + 2

        SetText()

    End Sub

    Public Overloads Sub SetText()
        Dim s As String
        'If sKeyLabel.Length > 10 Then
        '    s = sKeyLabel.Substring(0, 10)
        'Else
        '    s = sKeyLabel
        'End If
        If nKey1 > 90 Then
            lblKey1.Text = "NA"
        Else
            lblKey1.Text = "K" & nKey1.ToString("00")
        End If
        If nKey2 > 90 Then
            lblKey2.Text = "NA"
        Else
            lblKey2.Text = "K" & nKey2.ToString("00")
        End If


        s = sKeyLabel
        lblMain.Text = "DK" & nKeyNo.ToString("0") & " (" & nKeyValue.ToString("X2") & ")" & vbCr & s
    End Sub

    Public Property Key1() As Integer
        Get
            Return nKey1
        End Get
        Set(ByVal value As Integer)
            nKey1 = value
            SetText()
        End Set
    End Property

    Public Property Key2() As Integer
        Get
            Return nKey2
        End Get
        Set(ByVal value As Integer)
            nKey2 = value
            SetText()
        End Set
    End Property

    Public Overloads Property KeyValue() As Byte
        Get
            Return nKeyValue
        End Get
        Set(ByVal value As Byte)
            nKeyValue = value
            SetText()
        End Set
    End Property

    Public Overloads Property KeyLabel() As String
        Get
            Return sKeyLabel
        End Get
        Set(ByVal value As String)
            sKeyLabel = value
            SetText()
        End Set
    End Property

End Class

Public Class TripleKeyButton
    Inherits KeyButton

    Public lblKey1 As Label
    Public lblKey2 As Label
    Public lblKey3 As Label
    Public lblMain As Label
    Private nKey1 As Integer
    Private nKey2 As Integer
    Private nKey3 As Integer

    Sub New(ByVal cParent As Control, _
        ByVal b As Byte, _
        ByVal s As String, _
        ByVal n As Integer, _
        ByVal k1 As Integer, _
        ByVal k2 As Integer, _
        ByVal k3 As Integer, _
        ByVal x As Integer, ByVal y As Integer)

        MyBase.New(cParent, b, s, n, x, y)
        Size = New Size(W_TBTN - 1, H_TBTN)

        nKey1 = k1
        nKey2 = k2
        nKey3 = k3

        lblKey1 = New Label
        lblKey1.Parent = Me
        lblKey1.Font = New Font("Arial Narrow", 8, FontStyle.Regular)
        lblKey1.ForeColor = Color.Blue
        lblKey1.TextAlign = ContentAlignment.MiddleCenter
        lblKey1.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
        lblKey1.Top = -1
        lblKey1.Left = -1
        lblKey1.Size = New Size((W_TBTN + 1) \ 3, 20)

        lblKey2 = New Label
        lblKey2.Parent = Me
        lblKey2.Font = lblKey1.Font
        lblKey2.ForeColor = lblKey1.ForeColor
        lblKey2.TextAlign = lblKey1.TextAlign
        lblKey2.BorderStyle = lblKey1.BorderStyle
        lblKey2.Top = -1
        lblKey2.Left = lblKey1.Right - 1
        lblKey2.Size = lblKey1.Size

        lblKey3 = New Label
        lblKey3.Parent = Me
        lblKey3.Font = lblKey1.Font
        lblKey3.ForeColor = lblKey1.ForeColor
        lblKey3.TextAlign = lblKey1.TextAlign
        lblKey3.BorderStyle = lblKey1.BorderStyle
        lblKey3.Top = -1
        lblKey3.Left = lblKey2.Right - 1
        lblKey3.Size = lblKey1.Size

        lblMain = New Label
        lblMain.Parent = Me
        lblMain.Font = lblKey1.Font
        lblMain.ForeColor = lblKey1.ForeColor
        lblMain.TextAlign = lblKey1.TextAlign
        lblMain.BorderStyle = lblKey1.BorderStyle
        lblMain.Top = lblKey1.Bottom - 1
        lblMain.Left = -1
        lblMain.Width = W_TBTN
        lblMain.Height = H_TBTN - lblKey1.Height + 2

        SetText()

    End Sub

    Overloads Sub SetText()
        Dim s As String
        'If sKeyLabel.Length > 10 Then
        '    s = sKeyLabel.Substring(0, 10)
        'Else
        '    s = sKeyLabel
        'End If
        If nKey1 > 90 Then
            lblKey1.Text = "NA"
        Else
            lblKey1.Text = "K" & nKey1.ToString("00")
        End If
        If nKey2 > 90 Then
            lblKey2.Text = "NA"
        Else
            lblKey2.Text = "K" & nKey2.ToString("00")
        End If
        If nKey3 > 90 Then
            lblKey3.Text = "NA"
        Else
            lblKey3.Text = "K" & nKey3.ToString("00")
        End If

        s = sKeyLabel

        lblMain.Text = "TK" & nKeyNo.ToString("0") & " (" & nKeyValue.ToString("X2") & ")" & vbCr & s

    End Sub

    Public Property Key1() As Integer
        Get
            Return nKey1
        End Get
        Set(ByVal value As Integer)
            nKey1 = value
            SetText()
        End Set
    End Property

    Public Property Key2() As Integer
        Get
            Return nKey2
        End Get
        Set(ByVal value As Integer)
            nKey2 = value
            SetText()
        End Set
    End Property

    Public Property Key3() As Integer
        Get
            Return nKey3
        End Get
        Set(ByVal value As Integer)
            nKey3 = value
            SetText()
        End Set
    End Property

End Class

Public Class SettingDoubleKey
    Inherits Form
    Public sKeyLabel As String
    Public nKeyValue As Byte
    Public nKey1 As Integer
    Public nKey2 As Integer
    Private txtKeyLabel As TextBox
    Private txtKeyValue As TextBox
    Private bLang_cn As Boolean
    Private btnAll(90) As KeyButton
    Private nKey1Temp As Integer
    Private nKey2Temp As Integer


    Sub New(ByVal btnkey As DoubleKeyButton, ByVal bLang As Boolean)
        sKeyLabel = btnkey.KeyLabel
        nKeyValue = btnkey.KeyValue
        nKey1 = btnkey.Key1
        nKey2 = btnkey.Key2
        bLang_cn = bLang
        nKey1Temp = nKey1
        nKey2Temp = nKey2

        FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        ControlBox = False
        MaximizeBox = False
        MinimizeBox = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        Size = New Size(740, 540)

        Dim lblKeyNo As New Label
        lblKeyNo.Parent = Me
        lblKeyNo.Left = 520
        lblKeyNo.Top = 10
        lblKeyNo.Size = New Size(70, 20)
        lblKeyNo.TextAlign = ContentAlignment.BottomRight

        Dim lbl As New Label
        lbl.Parent = Me
        lbl.Left = lblKeyNo.Right + 5
        lbl.Top = lblKeyNo.Top
        lbl.Size = New Size(70, 20)
        lbl.TextAlign = ContentAlignment.BottomLeft
        lbl.Text = "DK" & btnkey.KeyNo.ToString("0")

        Dim lblKeyValue As New Label
        lblKeyValue.Parent = Me
        lblKeyValue.Left = 520
        lblKeyValue.Top = lblKeyNo.Bottom + 5
        lblKeyValue.Size = New Size(70, 20)
        lblKeyValue.TextAlign = ContentAlignment.BottomRight
        'lblKeyValue.BorderStyle = BorderStyle.FixedSingle

        Dim lblKeyLabel As New Label
        lblKeyLabel.Parent = Me
        lblKeyLabel.Left = lblKeyValue.Left
        lblKeyLabel.Top = lblKeyValue.Bottom + 5
        lblKeyLabel.Size = lblKeyValue.Size
        lblKeyLabel.TextAlign = ContentAlignment.BottomRight
        'lblKeyLabel.BorderStyle = BorderStyle.FixedSingle

        txtKeyValue = New TextBox
        txtKeyValue.Parent = Me
        txtKeyValue.Left = lblKeyValue.Right + 5
        txtKeyValue.Top = lblKeyValue.Top
        txtKeyValue.Size = New Size(100, 20)
        txtKeyValue.MaxLength = 2
        txtKeyValue.Text = nKeyValue.ToString("X2")

        txtKeyLabel = New TextBox
        txtKeyLabel.Parent = Me
        txtKeyLabel.Left = lblKeyLabel.Right + 5
        txtKeyLabel.Top = lblKeyLabel.Top
        txtKeyLabel.Size = New Size(100, 20)
        txtKeyLabel.MaxLength = 32
        txtKeyLabel.Text = sKeyLabel

        Dim btnOK As New Button
        btnOK.Parent = Me
        btnOK.Left = 545
        btnOK.Top = lblKeyLabel.Bottom + 10
        btnOK.Size = New Size(70, 25)
        AddHandler btnOK.Click, AddressOf OnButtonOKClick

        Dim btnCancel As New Button
        btnCancel.Parent = Me
        btnCancel.Left = btnOK.Right + 10
        btnCancel.Top = btnOK.Top
        btnCancel.Size = btnOK.Size
        AddHandler btnCancel.Click, AddressOf OnButtonCancelClick

        If bLang Then
            Text = "设置按键DK" & btnkey.KeyNo.ToString("0")
            btnOK.Text = "确认"
            btnCancel.Text = "取消"
            lblKeyNo.Text = "双键编号"
            lblKeyValue.Text = "键码"
            lblKeyLabel.Text = "按键标识"
        Else
            Text = "Setting Key DK" & btnkey.KeyNo.ToString("0")
            btnOK.Text = "OK"
            btnCancel.Text = "Cancel"
            lblKeyNo.Text = "DblKey No."
            lblKeyValue.Text = "Key Code"
            lblKeyLabel.Text = "Key Label"
        End If

        Dim i As Integer, j As Integer, n As Integer
        Dim btn As KeyButton
        n = 0
        For i = 1 To 13
            For j = 1 To i
                btn = New KeyButton(Me, myMain.myRCType.nSingleKey(n), myMain.myRCType.sSingleKeyLabel(n), n, 30 + (j - 1) * (W_BTN + 1), 10 + (i - 1) * (H_BTN + 1))
                btnAll(n) = btn
                n += 1
                AddHandler btn.MouseClick, AddressOf OnKeyClick
            Next
        Next
        For i = 78 To 90
            btnAll(i).Visible = False
        Next
        If nKey1 <= 90 Then btnAll(nKey1).Selected = True
        If nKey2 <= 90 Then btnAll(nKey2).Selected = True
        'btnAll(10).Enable = False

        'Dim lbl As Label
        Dim fnt As New Font("Arial", 8, FontStyle.Regular)
        For i = 1 To 11
            lbl = New Label
            lbl.Parent = Me
            lbl.Location = New Point(0, 10 + (i - 1) * (H_BTN + 1))
            lbl.Size = New Size(30, H_BTN)
            'lbl.AutoSize = True
            lbl.Font = fnt
            lbl.ForeColor = Color.Green
            lbl.TextAlign = ContentAlignment.MiddleRight
            'lbl.BorderStyle = BorderStyle.FixedSingle
            lbl.Text = "S" & i.ToString
        Next
        lbl = New Label
        lbl.Parent = Me
        lbl.Location = New Point(0, 10 + (i - 1) * (H_BTN + 1))
        lbl.Size = New Size(30, H_BTN)
        'lbl.AutoSize = True
        lbl.Font = fnt
        lbl.ForeColor = Color.Green
        lbl.TextAlign = ContentAlignment.MiddleRight
        lbl.Text = "GND"

        For i = 0 To 11
            lbl = New Label
            lbl.Parent = Me
            lbl.Location = New Point(30 + i * (W_BTN + 1), 13 * (H_BTN + 1) - 25)
            lbl.Size = New Size(W_BTN, 20)
            lbl.Font = fnt
            lbl.ForeColor = Color.Green
            lbl.TextAlign = ContentAlignment.TopCenter
            'lbl.BorderStyle = BorderStyle.FixedSingle
            lbl.Text = "S" & i.ToString
        Next

        lbl = New Label
        lbl.Parent = Me
        lbl.Font = New Font("微软雅黑", 9, FontStyle.Regular)
        lbl.ForeColor = Color.Red
        lbl.Location = New Point(300, 10)
        lbl.Size = New Size(180, 40)
        If bLang Then
            lbl.Text = "鼠标左键: 选择按键" & vbCr & "鼠标右键: 取消选择"
        Else
            lbl.Text = "  Mouse Left: Select Key" & vbCr & "Mouse Right: Deselect Key"
        End If
    End Sub

    Sub OnButtonOKClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim str As String
        Dim s(1) As Char
        If nKey1Temp > 90 And nKey2Temp > 90 Then
            nKey1 = 255
            nKey2 = 255
        ElseIf nKey1Temp <= 90 And nKey2Temp <= 90 Then
            If CheckGNDDoubleKey(nKey1Temp, nKey2Temp) Then
                nKey1 = Math.Min(nKey1Temp, nKey2Temp)
                nKey2 = Math.Max(nKey1Temp, nKey2Temp)
            Else
                If bLang_cn Then
                    MessageBox.Show("双键不能用GND", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("Double Keys shouldn't use GND", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Return
            End If
        Else
            If bLang_cn Then
                MessageBox.Show("必须选中2个按键或不选", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Must select 2 keys or none", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return

        End If

        str = txtKeyValue.Text.ToUpper
        If str.Length = 2 And str Like "[0-9A-Fa-f][0-9A-Fa-f]" Then
            txtKeyValue.Text = str.ToUpper
            s(1) = Convert.ToChar(str.Substring(0, 1))
            s(0) = Convert.ToChar(str.Substring(1, 1))
            nKeyValue = Hex2Dec(s(1)) * 16 + Hex2Dec(s(0))
            sKeyLabel = txtKeyLabel.Text
            DialogResult = Windows.Forms.DialogResult.OK
        Else
            If bLang_cn Then
                MessageBox.Show("键码必须是8位16进制数，如00,EF等", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Key Code must be an 8-bit Hex digits, e.g. 00, EF etc", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            txtKeyValue.Select(0, str.Length)
            txtKeyValue.Focus()
        End If
    End Sub

    Sub OnButtonCancelClick(ByVal sender As Object, ByVal e As EventArgs)
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub OnKeyClick(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim btn As KeyButton = CType(sender, KeyButton)
        Dim bLogic0 As Boolean, bLogic1 As Boolean
        'Dim sx As Integer, sy As Integer
        'Dim i As Integer, j As Integer

        If btn.Enable = False Then Return

        bLogic0 = (nKey1Temp <= 90)
        bLogic1 = (nKey2Temp <= 90)


        If e.Button = Windows.Forms.MouseButtons.Left Then
            If bLogic0 = False And bLogic1 = False Then
                btn.Selected = True
                nKey1Temp = btn.KeyNo
            ElseIf bLogic0 = False And bLogic1 = True Then
                If btn.KeyNo <> nKey2Temp Then
                    btn.Selected = True
                    nKey1Temp = btn.KeyNo
                End If
            ElseIf bLogic0 = True And bLogic1 = False Then
                If btn.KeyNo <> nKey1Temp Then
                    btn.Selected = True
                    nKey2Temp = btn.KeyNo
                End If
            End If

        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            If btn.Selected Then
                btn.Selected = False
                If nKey1Temp = btn.KeyNo Then
                    nKey1Temp = 255
                Else
                    nKey2Temp = 255
                End If
            End If
        End If
    End Sub

End Class

Public Class SettingTripleKey
    Inherits Form
    Public sKeyLabel As String
    Public nKeyValue As Byte
    Public nKey1 As Integer
    Public nKey2 As Integer
    Public nKey3 As Integer
    Private txtKeyLabel As TextBox
    Private txtKeyValue As TextBox
    Private bLang_cn As Boolean
    Private btnAll(90) As KeyButton
    Private nKey1Temp As Integer
    Private nKey2Temp As Integer
    Private nKey3Temp As Integer


    Sub New(ByVal btnkey As TripleKeyButton, ByVal bLang As Boolean)
        sKeyLabel = btnkey.KeyLabel
        nKeyValue = btnkey.KeyValue
        nKey1 = btnkey.Key1
        nKey2 = btnkey.Key2
        nKey3 = btnkey.Key3
        bLang_cn = bLang
        nKey1Temp = nKey1
        nKey2Temp = nKey2
        nKey3Temp = nKey3

        FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        ControlBox = False
        MaximizeBox = False
        MinimizeBox = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        Size = New Size(740, 540)

        Dim lblKeyNo As New Label
        lblKeyNo.Parent = Me
        lblKeyNo.Left = 520
        lblKeyNo.Top = 10
        lblKeyNo.Size = New Size(70, 20)
        lblKeyNo.TextAlign = ContentAlignment.BottomRight

        Dim lbl As New Label
        lbl.Parent = Me
        lbl.Left = lblKeyNo.Right + 5
        lbl.Top = lblKeyNo.Top
        lbl.Size = New Size(70, 20)
        lbl.TextAlign = ContentAlignment.BottomLeft
        lbl.Text = "TK" & btnkey.KeyNo.ToString("0")

        Dim lblKeyValue As New Label
        lblKeyValue.Parent = Me
        lblKeyValue.Left = 520
        lblKeyValue.Top = lblKeyNo.Bottom + 5
        lblKeyValue.Size = New Size(70, 20)
        lblKeyValue.TextAlign = ContentAlignment.BottomRight
        'lblKeyValue.BorderStyle = BorderStyle.FixedSingle

        Dim lblKeyLabel As New Label
        lblKeyLabel.Parent = Me
        lblKeyLabel.Left = lblKeyValue.Left
        lblKeyLabel.Top = lblKeyValue.Bottom + 5
        lblKeyLabel.Size = lblKeyValue.Size
        lblKeyLabel.TextAlign = ContentAlignment.BottomRight
        'lblKeyLabel.BorderStyle = BorderStyle.FixedSingle

        txtKeyValue = New TextBox
        txtKeyValue.Parent = Me
        txtKeyValue.Left = lblKeyValue.Right + 5
        txtKeyValue.Top = lblKeyValue.Top
        txtKeyValue.Size = New Size(100, 20)
        txtKeyValue.MaxLength = 2
        txtKeyValue.Text = nKeyValue.ToString("X2")

        txtKeyLabel = New TextBox
        txtKeyLabel.Parent = Me
        txtKeyLabel.Left = lblKeyLabel.Right + 5
        txtKeyLabel.Top = lblKeyLabel.Top
        txtKeyLabel.Size = New Size(100, 20)
        txtKeyLabel.MaxLength = 32
        txtKeyLabel.Text = sKeyLabel

        Dim btnOK As New Button
        btnOK.Parent = Me
        btnOK.Left = 545
        btnOK.Top = lblKeyLabel.Bottom + 10
        btnOK.Size = New Size(70, 25)
        AddHandler btnOK.Click, AddressOf OnButtonOKClick

        Dim btnCancel As New Button
        btnCancel.Parent = Me
        btnCancel.Left = btnOK.Right + 10
        btnCancel.Top = btnOK.Top
        btnCancel.Size = btnOK.Size
        AddHandler btnCancel.Click, AddressOf OnButtonCancelClick

        If bLang Then
            Text = "设置按键TK" & btnkey.KeyNo.ToString("0")
            btnOK.Text = "确认"
            btnCancel.Text = "取消"
            lblKeyNo.Text = "三键编号"
            lblKeyValue.Text = "键码"
            lblKeyLabel.Text = "按键标识"
        Else
            Text = "Setting Key TK" & btnkey.KeyNo.ToString("0")
            btnOK.Text = "OK"
            btnCancel.Text = "Cancel"
            lblKeyNo.Text = "TriKey No."
            lblKeyValue.Text = "Key Code"
            lblKeyLabel.Text = "Key Label"
        End If

        Dim i As Integer, j As Integer, n As Integer
        Dim btn As KeyButton
        n = 0
        For i = 1 To 13
            For j = 1 To i
                btn = New KeyButton(Me, myMain.myRCType.nSingleKey(n), myMain.myRCType.sSingleKeyLabel(n), n, 30 + (j - 1) * (W_BTN + 1), 10 + (i - 1) * (H_BTN + 1))
                btnAll(n) = btn
                n += 1
                AddHandler btn.MouseClick, AddressOf OnKeyClick
            Next
        Next
        For i = 78 To 90
            btnAll(i).Visible = False
        Next
        If nKey1 <= 90 Then btnAll(nKey1).Selected = True
        If nKey2 <= 90 Then btnAll(nKey2).Selected = True
        If nKey3 <= 90 Then btnAll(nKey3).Selected = True

        'Dim lbl As Label
        Dim fnt As New Font("Arial", 8, FontStyle.Regular)
        For i = 1 To 11
            lbl = New Label
            lbl.Parent = Me
            lbl.Location = New Point(0, 10 + (i - 1) * (H_BTN + 1))
            lbl.Size = New Size(30, H_BTN)
            'lbl.AutoSize = True
            lbl.Font = fnt
            lbl.ForeColor = Color.Green
            lbl.TextAlign = ContentAlignment.MiddleRight
            'lbl.BorderStyle = BorderStyle.FixedSingle
            lbl.Text = "S" & i.ToString
        Next
        lbl = New Label
        lbl.Parent = Me
        lbl.Location = New Point(0, 10 + (i - 1) * (H_BTN + 1))
        lbl.Size = New Size(30, H_BTN)
        'lbl.AutoSize = True
        lbl.Font = fnt
        lbl.ForeColor = Color.Green
        lbl.TextAlign = ContentAlignment.MiddleRight
        lbl.Text = "GND"

        For i = 0 To 11
            lbl = New Label
            lbl.Parent = Me
            lbl.Location = New Point(30 + i * (W_BTN + 1), 13 * (H_BTN + 1) - 25)
            lbl.Size = New Size(W_BTN, 20)
            lbl.Font = fnt
            lbl.ForeColor = Color.Green
            lbl.TextAlign = ContentAlignment.TopCenter
            'lbl.BorderStyle = BorderStyle.FixedSingle
            lbl.Text = "S" & i.ToString
        Next

        lbl = New Label
        lbl.Parent = Me
        lbl.Font = New Font("微软雅黑", 9, FontStyle.Regular)
        lbl.ForeColor = Color.Red
        lbl.Location = New Point(300, 10)
        lbl.Size = New Size(180, 40)
        If bLang Then
            lbl.Text = "鼠标左键: 选择按键" & vbCr & "鼠标右键: 取消选择"
        Else
            lbl.Text = "  Mouse Left: Select Key" & vbCr & "Mouse Right: Deselect Key"
        End If
    End Sub

    Sub OnButtonOKClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim str As String
        Dim s(1) As Char
        If nKey1Temp > 90 And nKey2Temp > 90 And nKey3Temp > 90 Then
            nKey1 = 255
            nKey2 = 255
            nKey3 = 255
        ElseIf nKey1Temp <= 90 And nKey2Temp <= 90 And nKey3Temp <= 90 Then
            If CheckValidDoubleKey(nKey1Temp, nKey2Temp) _
                And CheckValidDoubleKey(nKey1Temp, nKey3Temp) _
                And CheckValidDoubleKey(nKey2Temp, nKey3Temp) Then

                nKey1 = nKey1Temp

                If nKey2Temp > nKey1 Then
                    nKey2 = nKey2Temp
                Else
                    nKey2 = nKey1
                    nKey1 = nKey2Temp
                End If

                If nKey3Temp > nKey2 Then
                    nKey3 = nKey3Temp
                ElseIf nKey3Temp > nKey1 Then
                    nKey3 = nKey2
                    nKey2 = nKey3Temp
                Else
                    nKey3 = nKey2
                    nKey2 = nKey1
                    nKey1 = nKey3Temp
                End If

            Else
                If bLang_cn Then
                    MessageBox.Show("三键不能共用端口，且不能用GND", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("Triple Keys shouldn't use same port or include GND", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Return
            End If
        Else
            If bLang_cn Then
                MessageBox.Show("必须选中3个按键或不选", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Must select 3 keys or none", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return

        End If

        str = txtKeyValue.Text.ToUpper
        If str.Length = 2 And str Like "[0-9A-Fa-f][0-9A-Fa-f]" Then
            txtKeyValue.Text = str.ToUpper
            s(1) = Convert.ToChar(str.Substring(0, 1))
            s(0) = Convert.ToChar(str.Substring(1, 1))
            nKeyValue = Hex2Dec(s(1)) * 16 + Hex2Dec(s(0))
            sKeyLabel = txtKeyLabel.Text
            DialogResult = Windows.Forms.DialogResult.OK
        Else
            If bLang_cn Then
                MessageBox.Show("键码必须是8位16进制数，如00,EF等", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Key Code must be an 8-bit Hex digits, e.g. 00, EF etc", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            txtKeyValue.Select(0, str.Length)
            txtKeyValue.Focus()
        End If
    End Sub

    Sub OnButtonCancelClick(ByVal sender As Object, ByVal e As EventArgs)
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub OnKeyClick(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim btn As KeyButton = CType(sender, KeyButton)
        Dim bLogic0 As Boolean, bLogic1 As Boolean, bLogic2 As Boolean

        bLogic0 = (nKey1Temp <= 90)
        bLogic1 = (nKey2Temp <= 90)
        bLogic2 = (nKey3Temp <= 90)

        If e.Button = Windows.Forms.MouseButtons.Left Then
            If bLogic0 = False And bLogic1 = False And bLogic2 = False Then
                btn.Selected = True
                nKey1Temp = btn.KeyNo
            ElseIf bLogic0 = False And bLogic1 = False And bLogic2 = True Then
                If btn.KeyNo <> nKey3Temp Then
                    btn.Selected = True
                    nKey1Temp = btn.KeyNo
                End If
            ElseIf bLogic0 = False And bLogic1 = True And bLogic2 = False Then
                If btn.KeyNo <> nKey2Temp Then
                    btn.Selected = True
                    nKey1Temp = btn.KeyNo
                End If
            ElseIf bLogic0 = False And bLogic1 = True And bLogic2 = True Then
                If btn.KeyNo <> nKey2Temp And btn.KeyNo <> nKey3Temp Then
                    btn.Selected = True
                    nKey1Temp = btn.KeyNo
                End If
            ElseIf bLogic0 = True And bLogic1 = False And bLogic2 = False Then
                If btn.KeyNo <> nKey1Temp Then
                    btn.Selected = True
                    nKey2Temp = btn.KeyNo
                End If
            ElseIf bLogic0 = True And bLogic1 = False And bLogic2 = True Then
                If btn.KeyNo <> nKey1Temp And btn.KeyNo <> nKey3Temp Then
                    btn.Selected = True
                    nKey2Temp = btn.KeyNo
                End If
            ElseIf bLogic0 = True And bLogic1 = True And bLogic2 = False Then
                If btn.KeyNo <> nKey1Temp And btn.KeyNo <> nKey2Temp Then
                    btn.Selected = True
                    nKey3Temp = btn.KeyNo
                End If
            End If

        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            If btn.Selected Then
                btn.Selected = False
                If nKey1Temp = btn.KeyNo Then
                    nKey1Temp = 255
                ElseIf nKey2Temp = btn.KeyNo Then
                    nKey2Temp = 255
                Else
                    nKey3Temp = 255
                End If
            End If
        End If
    End Sub

End Class

