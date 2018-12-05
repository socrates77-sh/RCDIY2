<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About_nologo
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
        Me.lblInfo = New System.Windows.Forms.Label
        Me.cmdClose = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Location = New System.Drawing.Point(65, 23)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(41, 12)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "Label1"
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(97, 91)
        Me.cmdClose.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Text = "关闭"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'About_nologo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(270, 134)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.lblInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "About_nologo"
        Me.Padding = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents cmdClose As System.Windows.Forms.Button

End Class
