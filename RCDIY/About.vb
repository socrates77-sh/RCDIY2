'Edition history
'0.1 新建，在RCDIY基础上修改 14/5/29
'0.2 新增功能实现，VDD扫描实现 14/6/6
'0.3 原型机定稿 14/6/20
'0.4 修改上拉电阻选项bug 14/9/26
'0.5 增加温度校准调试位 14/9/28
'0.6 部分调试选项固定 14/10/11
'1.0 正式版释放 14/11/13
'1.1 修改bLDO17(HIRC电压选择为)默认值为False 18/12/5


Public NotInheritable Class About_nologo

    Private Sub About_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Version As String = "V1.1"
        Dim day As String = "2018/12/5"
        lblInfo.Text = _
            "软件名:   RCDIY2" & vbCr & _
            "版本:     " & Version & vbCr & _
            "发布时间: " & day

    End Sub


    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
End Class
