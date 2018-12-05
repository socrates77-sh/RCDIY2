Module Constant
    Enum frameTreeTop
        boot = 0
        user = 1
        split = 2
        data = 3
        stop0 = 4
        repeat = 5
    End Enum

    Enum frameTreeData
        datacode1 = 0
        usercode2 = 1
        datacode2 = 2
    End Enum

    Enum frameTreeStop
        stopbit = 0
        stopcode = 1
    End Enum

    Enum frameTreeRepeat
        compact = 0
        complete = 1
    End Enum

    Enum errType
        errGlobalFormat = &HFF
        errBoot = &H300
        errSplit = &HC00
        errUser = &H1000
        errUserCode2 = &H2000
        errDataCode2 = &H4000
        errStopBit = &H8000
        errStopCode = &H10000
        errRepeat = &H60000
        errKey = &H100000
    End Enum

    Public Const HEAD_RCT_FILE As String = "Sinomcu RCDIY 9033 RCT BEGIN"
    Public Const TAIL_RCT_FILE As String = "Sinomcu RCDIY 9033 RCT END"
    'Public Const HEAD_RCP_FILE As String = "Sinomcu RCDIY 2013 RCP BEGIN"
    'Public Const TAIL_RCP_FILE As String = "Sinomcu RCDIY 2013 RCP END"
    'Public Const LEN_RCT_FILE As Integer = 135

    Public Const MARGIN As Integer = 25
    Public Const WIDTH As Integer = 990
    Public Const HEIGHT As Integer = 140
    Public Const Yaxis As Integer = HEIGHT - MARGIN + 5
    Public Const Xaxis0 As Integer = MARGIN
    Public Const Xaxis1 As Integer = WIDTH - MARGIN
    Public Const WY0 As Integer = Yaxis - 20
    Public Const WY1 As Integer = WY0 - 50
    Public Const Y_WAVEVALUE As Integer = (WY0 + WY1) / 2 - 5
    Public Const Y_LABEL As Integer = WY1 - 15
    Public Const Y_FRAME As Integer = WY1 - 40

    Public Const W_BTN As Integer = 52
    Public Const H_BTN As Integer = 35

    Public Const W_DBTN As Integer = 65
    Public Const H_DBTN As Integer = 53

    Public Const W_TBTN As Integer = 98
    Public Const H_TBTN As Integer = 53

    Public Const HRC_FREQ As Integer = 8000 'unit KHz

    Public KEY_MATRIX(,) As Byte = { _
            {255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255}, _
            {0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255}, _
            {1, 11, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255}, _
            {2, 12, 21, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255}, _
            {3, 13, 22, 30, 255, 255, 255, 255, 255, 255, 255, 255, 255}, _
            {4, 14, 23, 31, 38, 255, 255, 255, 255, 255, 255, 255, 255}, _
            {5, 15, 24, 32, 39, 45, 255, 255, 255, 255, 255, 255, 255}, _
            {6, 16, 25, 33, 40, 46, 51, 255, 255, 255, 255, 255, 255}, _
            {7, 17, 26, 34, 41, 47, 52, 56, 255, 255, 255, 255, 255}, _
            {8, 18, 27, 35, 42, 48, 53, 57, 60, 255, 255, 255, 255}, _
            {9, 19, 28, 36, 43, 49, 54, 58, 61, 63, 255, 255, 255}, _
            {10, 20, 29, 37, 44, 50, 55, 59, 62, 64, 65, 255, 255}, _
            {255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255}, _
            {255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255} _
            }

    'Public KEY_MATRIX(,) As Byte = { _
    '       {255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255}, _
    '       {0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255}, _
    '       {1, 2, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255}, _
    '       {3, 4, 5, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255}, _
    '       {6, 7, 8, 9, 255, 255, 255, 255, 255, 255, 255, 255, 255}, _
    '       {10, 11, 12, 13, 14, 255, 255, 255, 255, 255, 255, 255, 255}, _
    '       {15, 16, 17, 18, 19, 20, 255, 255, 255, 255, 255, 255, 255}, _
    '       {21, 22, 23, 24, 25, 26, 27, 255, 255, 255, 255, 255, 255}, _
    '       {28, 29, 30, 31, 32, 33, 34, 35, 255, 255, 255, 255, 255}, _
    '       {36, 37, 38, 39, 40, 41, 42, 43, 44, 255, 255, 255, 255}, _
    '       {45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 255, 255, 255}, _
    '       {55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 255, 255}, _
    '       {66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 255}, _
    '       {78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90} _
    '       }

    Public Function CheckGNDDoubleKey(ByVal k1 As Integer, ByVal k2 As Integer) As Boolean
        Dim i As Integer, j As Integer
        Dim x1 As Integer, y1 As Integer
        Dim x2 As Integer, y2 As Integer

        For i = 0 To 12
            For j = 0 To 13
                If k1 = KEY_MATRIX(j, i) Then
                    x1 = i
                    y1 = j
                End If
            Next
        Next

        For i = 0 To 12
            For j = 0 To 13
                If k2 = KEY_MATRIX(j, i) Then
                    x2 = i
                    y2 = j
                End If
            Next
        Next

        If x1 = 12 Or x2 = 12 Or y1 = 12 Or y2 = 12 Then
            'If x1 = x2 Or x1 = y2 Or y1 = y2 Or y1 = x2 Then
            Return False
        Else
            Return True
        End If

    End Function


    Public Function CheckValidDoubleKey(ByVal k1 As Integer, ByVal k2 As Integer) As Boolean
        Dim i As Integer, j As Integer
        Dim x1 As Integer, y1 As Integer
        Dim x2 As Integer, y2 As Integer

        For i = 0 To 12
            For j = 0 To 13
                If k1 = KEY_MATRIX(j, i) Then
                    x1 = i
                    y1 = j
                End If
            Next
        Next

        For i = 0 To 12
            For j = 0 To 13
                If k2 = KEY_MATRIX(j, i) Then
                    x2 = i
                    y2 = j
                End If
            Next
        Next

        If x1 = x2 Or x1 = y2 Or y1 = y2 Or y1 = x2 Or x1 = 12 Or x2 = 12 Or y1 = 12 Or y2 = 12 Then
            'If x1 = x2 Or x1 = y2 Or y1 = y2 Or y1 = x2 Then
            Return False
        Else
            Return True
        End If

    End Function

    Public Function CheckValidDoubleKeyRow(ByVal k1 As Integer, ByVal k2 As Integer) As Boolean
        Dim i As Integer, j As Integer
        Dim x1 As Integer, y1 As Integer
        Dim x2 As Integer, y2 As Integer

        For i = 0 To 12
            For j = 0 To 13
                If k1 = KEY_MATRIX(j, i) Then
                    x1 = i
                    y1 = j
                End If
            Next
        Next

        For i = 0 To 12
            For j = 0 To 13
                If k2 = KEY_MATRIX(j, i) Then
                    x2 = i
                    y2 = j
                End If
            Next
        Next

        If y1 = y2 Then
            Return False
        Else
            Return True
        End If

    End Function


    Public Function Hex2Dec(ByVal s As String)
        If s Like "[0-9]" Then
            Return Convert.ToInt16(s)
        Else
            Select Case s
                Case "A"
                    Return 10
                Case "B"
                    Return 11
                Case "C"
                    Return 12
                Case "D"
                    Return 13
                Case "E"
                    Return 14
                Case "F"
                    Return 15
                Case Else
                    Return 0
            End Select
        End If
        Return 0
    End Function



End Module
