Module modWave


    Public fPixelPerMs As Double
    Dim g As Graphics
    Dim fs As Double    'unit us
    Dim fd As Double
    Dim hx As Double
    Dim last_level As Boolean
    Public fTimeFrame(8) As Double

    Public Sub DrawWave(ByVal gg As Graphics, ByVal fStart As Double, ByVal fDuration As Double, ByVal bLang_cn As Boolean)
        fPixelPerMs = (WIDTH - 2 * MARGIN) / fDuration
        g = gg
        fs = fStart
        fd = fDuration
        hx = 0
        last_level = False

        Dim keydata As Byte
        Dim nKey As Integer
        nKey = myMain.myRCType.nPressKey

        keydata = myMain.myRCType.nSingleKey(nKey)
        'If nKey <= 90 Then
        '    keydata = myMain.myRCType.nSingleKey(nKey)
        'ElseIf nKey <= 98 Then
        '    keydata = myMain.myRCType.nDoubleKey(nKey - 91)
        'Else
        '    keydata = myMain.myRCType.nTripleKey(nKey - 99)
        'End If
        DrawAxis()

        If myMain.myRCType.bBootFrame Then
            DrawBoot(bLang_cn)
        End If
        fTimeFrame(0) = hx

        If myMain.myRCType.bUserFrame Then
            DrawUser1(keydata, bLang_cn)
        End If
        fTimeFrame(1) = hx

        If myMain.myRCType.bSplitFrame Then
            DrawSplit(bLang_cn)
        End If
        fTimeFrame(2) = hx

        If myMain.myRCType.bDataCode1 Then
            DrawData1(keydata, True, bLang_cn)
        End If
        fTimeFrame(3) = hx

        If myMain.myRCType.bUserCode2 Then
            DrawUser2(True, bLang_cn)
        End If
        fTimeFrame(4) = hx

        If myMain.myRCType.bDataCode2 Then
            DrawData2(keydata, True, bLang_cn)
        End If
        fTimeFrame(5) = hx

        If myMain.myRCType.bStopBit Then
            DrawStopBit(bLang_cn)
        End If
        fTimeFrame(6) = hx

        If myMain.myRCType.bStopCode Then
            DrawStopCode(bLang_cn)
        End If
        fTimeFrame(7) = hx

        If myMain.myRCType.bRepeatFrame Then
            If myMain.myRCType.bCompleteRepeat Then
                If myMain.myRCType.bBootCode Then
                    If myMain.myRCType.bBootFrame Then
                        DrawRepeatBoot(bLang_cn)
                    End If
                End If
                If myMain.myRCType.bUserFrame Then
                    DrawUser1(keydata, bLang_cn)
                End If
                If myMain.myRCType.bSplitFrame Then
                    DrawSplit(bLang_cn)
                End If

                If myMain.myRCType.bDataCode1 Then
                    DrawData1(keydata, Not myMain.myRCType.bData1Revert, bLang_cn)
                End If
                If myMain.myRCType.bUserCode2 Then
                    DrawUser2(Not myMain.myRCType.bUser2Revert, bLang_cn)
                End If
                If myMain.myRCType.bDataCode2 Then
                    DrawData2(keydata, Not myMain.myRCType.bData2Revert, bLang_cn)
                End If

                If myMain.myRCType.bStopBit Then
                    DrawStopBit(bLang_cn)
                End If
                If myMain.myRCType.bStopCode Then
                    DrawRepeatStopCode(bLang_cn)
                End If
            Else
                DrawCompactRepeat(bLang_cn)
                'DrawStopBit(bLang_cn)
                DrawRepeatStopCode(bLang_cn)
            End If
        End If
        fTimeFrame(8) = hx


        'HideMargin()

    End Sub

    Private Function MsToP(ByVal ms As Double) As Single
        Return Xaxis0 + (ms - fs) * fPixelPerMs
    End Function

    Private Sub HideMargin()
        g.FillRectangle(Brushes.Black, 0, WY1, Xaxis0, WY0 - WY1 + 1)
        g.FillRectangle(Brushes.Black, Xaxis1 + 1, WY1, MARGIN, WY0 - WY1 + 1)
    End Sub

    Private Sub DrawAxis()
        Dim fnt As New Font("Arial", 8)
        Dim strfmt As New StringFormat()

        Dim nMajorScale As Double
        Dim x As Integer, y As Integer
        Dim i As Integer
        Dim fScale As Double


        strfmt.Alignment = StringAlignment.Center

        g.DrawLine(Pens.Magenta, Xaxis0, Yaxis, Xaxis1, Yaxis)

        Dim numDig As Integer = Fix(Math.Log10(fd))
        Dim mainDig As Integer = Fix(fd / Math.Pow(10, numDig))

        If mainDig > 5 Then
            nMajorScale = 10 * Math.Pow(10, numDig - 1)
        ElseIf mainDig > 2 Then
            nMajorScale = 5 * Math.Pow(10, numDig - 1)
        Else
            nMajorScale = 2 * Math.Pow(10, numDig - 1)
        End If

        Dim s As Double
        s = (fs - Xaxis0 / fPixelPerMs) / nMajorScale
        For i = 0 To 20
            fScale = (CInt(s) + i) * nMajorScale
            'x = Xaxis0 + (fScale - fs) * fMsPerPixel
            x = MsToP(fScale)
            y = Yaxis
            If x >= Xaxis0 And x <= Xaxis1 Then
                g.DrawLine(Pens.Magenta, x, y, x, y - 5)
                If fScale >= 10 Then
                    g.DrawString(fScale.ToString("0.0") & "ms", fnt, Brushes.AliceBlue, x, y, strfmt)
                Else
                    g.DrawString(fScale.ToString("0.0") & "ms", fnt, Brushes.AliceBlue, x, y, strfmt)
                End If
            End If
        Next

        s = 5 * (fs - Xaxis0 / fPixelPerMs) / nMajorScale
        For i = 0 To 100
            fScale = (CInt(s) + i) * nMajorScale / 5
            x = MsToP(fScale)
            'x = Xaxis0 + (fScale - fs) * fMsPerPixel
            y = Yaxis
            If x >= Xaxis0 And x <= Xaxis1 Then
                g.DrawLine(Pens.Magenta, x, y, x, y - 3)
            End If
        Next

        'g.DrawString(fStart.ToString, fnt, Brushes.AliceBlue, MARGIN, MARGIN)
        'g.DrawString(fDuration.ToString, fnt, Brushes.AliceBlue, MARGIN, MARGIN + 20)
        'g.DrawString(fMsPerPixel.ToString, fnt, Brushes.AliceBlue, MARGIN, MARGIN + 40)
        'g.DrawString(nMajorScale.ToString, fnt, Brushes.AliceBlue, MARGIN, MARGIN + 60)
    End Sub

    'unit of hx, w is (us)
    Private Sub DrawLevel(ByVal w As Double, ByVal level As Boolean)
        Dim x0 As Single, x1 As Single
        x0 = MsToP(hx / 1000)
        x1 = MsToP(hx / 1000 + w / 1000)
        hx += w
        If Not level = last_level Then
            g.DrawLine(Pens.LawnGreen, x0, WY0, x0, WY1)
        End If
        If level Then
            g.DrawLine(Pens.LawnGreen, x0, WY1, x1, WY1)
        Else
            g.DrawLine(Pens.LawnGreen, x0, WY0, x1, WY0)
        End If
        last_level = level

        Dim fnt As New Font("Arial", 8)
        Dim strfmt As New StringFormat()
        strfmt.Alignment = StringAlignment.Center
        Dim str As String = w.ToString("0.0")
        Dim str_size As SizeF = g.MeasureString(str, fnt)
        If str_size.Width < x1 - x0 Then
            g.DrawString(str, fnt, Brushes.Gold, (x0 + x1) / 2, Y_WAVEVALUE, strfmt)
        End If

    End Sub

    Private Sub DrawFrame(ByVal sFrame As String, ByVal x0_fr As Double, ByVal x1_fr As Double)
        Dim x0 As Single, x1 As Single
        Dim pn As New Pen(Color.Coral)
        pn.DashStyle = Drawing2D.DashStyle.Dash
        x0 = MsToP(x0_fr / 1000)
        x1 = MsToP(x1_fr / 1000)
        g.DrawLine(pn, x0, WY1, x0, Y_FRAME)
        g.DrawLine(pn, x1, WY1, x1, Y_FRAME)

        Dim fnt As New Font("Arial", 8)

        Dim str_size As SizeF = g.MeasureString(sFrame, fnt)
        If str_size.Width < x1 - x0 Then
            g.DrawString(sFrame, fnt, Brushes.Coral, x0, Y_FRAME + 7)
        End If

    End Sub

    Private Sub DrawBit(ByVal b As Boolean, ByVal str As String)
        Dim lbl As String
        Dim x0 As Double, x1 As Double

        x0 = MsToP(hx / 1000)
        If Not b Then
            lbl = str & ":0"
            If myMain.myRCType.bHtoL_L0 Then
                DrawLevel(myMain.myRCType.fFirst_L0, True)
                DrawLevel(myMain.myRCType.fSecond_L0, False)
            Else
                DrawLevel(myMain.myRCType.fFirst_L0, False)
                DrawLevel(myMain.myRCType.fSecond_L0, True)
            End If
        Else
            lbl = str & ":1"
            If myMain.myRCType.bHtoL_L1 Then
                DrawLevel(myMain.myRCType.fFirst_L1, True)
                DrawLevel(myMain.myRCType.fSecond_L1, False)
            Else
                DrawLevel(myMain.myRCType.fFirst_L1, False)
                DrawLevel(myMain.myRCType.fSecond_L1, True)
            End If
        End If
        x1 = MsToP(hx / 1000)

        Dim fnt_l As New Font("Arial", 8)
        Dim strfmt As New StringFormat()
        strfmt.Alignment = StringAlignment.Near
        Dim str_size As SizeF = g.MeasureString(lbl, fnt_l)
        If str_size.Width < x1 - x0 Then
            'g.DrawString(lbl, fnt_l, Brushes.Pink, (x0 + x1) / 2, Y_LABEL, strfmt)
            g.DrawString(lbl, fnt_l, Brushes.Pink, x0, Y_LABEL, strfmt)
        End If
    End Sub

    Private Sub DrawBitEx(ByVal b As Boolean, ByVal str As String)
        Dim lbl As String
        Dim x0 As Double, x1 As Double

        x0 = MsToP(hx / 1000)
        If Not b Then
            lbl = str & ":0"
            If myMain.myRCType.bHtoL_L0 Then
                DrawLevel(2 * myMain.myRCType.fFirst_L0, True)
                DrawLevel(2 * myMain.myRCType.fSecond_L0, False)
            Else
                DrawLevel(2 * myMain.myRCType.fFirst_L0, False)
                DrawLevel(2 * myMain.myRCType.fSecond_L0, True)
            End If
        Else
            lbl = str & ":1"
            If myMain.myRCType.bHtoL_L1 Then
                DrawLevel(2 * myMain.myRCType.fFirst_L1, True)
                DrawLevel(2 * myMain.myRCType.fSecond_L1, False)
            Else
                DrawLevel(2 * myMain.myRCType.fFirst_L1, False)
                DrawLevel(2 * myMain.myRCType.fSecond_L1, True)
            End If
        End If
        x1 = MsToP(hx / 1000)

        Dim fnt_l As New Font("Arial", 8)
        Dim strfmt As New StringFormat()
        strfmt.Alignment = StringAlignment.Near
        Dim str_size As SizeF = g.MeasureString(lbl, fnt_l)
        If str_size.Width < x1 - x0 Then
            'g.DrawString(lbl, fnt_l, Brushes.Pink, (x0 + x1) / 2, Y_LABEL, strfmt)
            g.DrawString(lbl, fnt_l, Brushes.Pink, x0, Y_LABEL, strfmt)
        End If
    End Sub

    Private Sub DrawData(ByVal data As UInt32, ByVal n As Integer, ByVal prefix As String)

        Dim i As Integer
        Dim mask As UInt32

        If myMain.myRCType.bLowBitFirst Then
            mask = &H1L
            For i = 0 To n - 1
                DrawBit(data And mask, prefix & i.ToString)
                mask = mask << 1
            Next
        Else
            mask = &H1L << (n - 1)
            For i = 0 To n - 1
                DrawBit(data And mask, prefix & (n - 1 - i).ToString)
                mask = mask >> 1
            Next
        End If
    End Sub

    Private Sub DrawDataEx(ByVal data As UInt32, ByVal n As Integer, ByVal prefix As String, ByVal nExpand As Integer)

        Dim i As Integer
        Dim mask As UInt32

        If myMain.myRCType.bLowBitFirst Then
            mask = &H1L
            For i = 0 To n - 1
                If i = nExpand Then
                    DrawBitEx(data And mask, prefix & i.ToString)
                Else
                    DrawBit(data And mask, prefix & i.ToString)
                End If
                mask = mask << 1
            Next
        Else
            mask = &H1L << (n - 1)
            For i = 0 To n - 1
                If i = nExpand Then
                    DrawBitEx(data And mask, prefix & (n - 1 - i).ToString)
                Else
                    DrawBit(data And mask, prefix & (n - 1 - i).ToString)
                End If
                mask = mask >> 1
            Next
        End If
    End Sub

    Private Function TruncateHex(ByVal value As UInt32, ByVal n As Integer) As String
        'Dim str As String = ""
        Dim tmp As UInt32

        tmp = value And (&HFFFFFFFFL >> (32 - n))

        If n <= 4 Then
            'tmp = value And &HF
            Return tmp.ToString("X1") & "H"
        ElseIf n <= 8 Then
            'tmp = value And &HFF
            Return tmp.ToString("X2") & "H"
        ElseIf n <= 12 Then
            'tmp = value And &HFFF
            Return tmp.ToString("X3") & "H"
        ElseIf n <= 16 Then
            'tmp = value And &HFFFF
            Return tmp.ToString("X4") & "H"
        ElseIf n <= 20 Then
            'tmp = value And &HFFFFF
            Return tmp.ToString("X5") & "H"
        ElseIf n <= 24 Then
            'tmp = value And &HFFFFFF
            Return tmp.ToString("X6") & "H"
        ElseIf n <= 28 Then
            'tmp = value And &HFFFFFFF
            Return tmp.ToString("X7") & "H"
        Else
            'tmp = value And &HFFFFFFFF
            Return tmp.ToString("X8") & "H"
        End If
    End Function

    Private Sub DrawBoot(ByVal bLang_cn As Boolean)
        Dim x0_frame As Double, x1_frame As Double
        x0_frame = hx
        DrawLevel(myMain.myRCType.fBootHigh, True)
        DrawLevel(myMain.myRCType.fBootLow, False)
        x1_frame = hx
        If bLang_cn Then
            DrawFrame("引导码", x0_frame, x1_frame)
        Else
            DrawFrame("Boot", x0_frame, x1_frame)
        End If
    End Sub

    Private Sub DrawRepeatBoot(ByVal bLang_cn As Boolean)
        Dim x0_frame As Double, x1_frame As Double
        x0_frame = hx
        DrawLevel(myMain.myRCType.fRepeatBootHigh, True)
        DrawLevel(myMain.myRCType.fRepeatBootLow, False)
        x1_frame = hx
        If bLang_cn Then
            DrawFrame("引导码", x0_frame, x1_frame)
        Else
            DrawFrame("Boot", x0_frame, x1_frame)
        End If
    End Sub

    Private Sub DrawUser1(ByVal keydata As Byte, ByVal bLang_cn As Boolean)
        Dim x0_frame As Double, x1_frame As Double
        Dim ud As UInt32

        x0_frame = hx

        ud = myMain.myRCType.nUserCode
        If myMain.myRCType.bRevertBitHi Then
            If myMain.myRCType.bLowBitFirst Then
                ud = ud Xor (&H1L << myMain.myRCType.nPositionHi)
            Else
                If myMain.myRCType.nUserBits - myMain.myRCType.nPositionHi >= 1 Then
                    ud = ud Xor (&H1L << (myMain.myRCType.nUserBits - myMain.myRCType.nPositionHi - 1))
                End If
            End If
        End If

        If myMain.myRCType.bRevertBitLo Then
            If myMain.myRCType.bLowBitFirst Then
                ud = ud Xor (&H1L << myMain.myRCType.nPositionLo)
            Else
                If myMain.myRCType.nUserBits - myMain.myRCType.nPositionLo >= 1 Then
                    ud = ud Xor (&H1L << (myMain.myRCType.nUserBits - myMain.myRCType.nPositionLo - 1))
                End If
            End If
        End If

        If myMain.myRCType.bBit1Option Then
            If keydata <= &H3F Then
                If myMain.myRCType.bLowBitFirst Then
                    ud = ud Or &H2L
                Else
                    ud = ud Or (&H1L << (myMain.myRCType.nUserBits - 2))
                End If
            Else
                If myMain.myRCType.bLowBitFirst Then
                    ud = ud And (Not &H2L)
                Else
                    ud = ud And (Not (&H1L << (myMain.myRCType.nUserBits - 2)))
                End If
            End If
        End If
        If myMain.myRCType.bBitExpand Then
            DrawDataEx(ud, myMain.myRCType.nUserBits, "C", myMain.myRCType.nPositionLo)
        Else
            DrawData(ud, myMain.myRCType.nUserBits, "C")
        End If

        x1_frame = hx

        If bLang_cn Then
            DrawFrame("用户码1: " & TruncateHex(myMain.myRCType.nUserCode, myMain.myRCType.nUserBits), x0_frame, x1_frame)
        Else
            DrawFrame("User1: " & TruncateHex(myMain.myRCType.nUserCode, myMain.myRCType.nUserBits), x0_frame, x1_frame)
        End If

    End Sub

    Private Sub DrawSplit(ByVal bLang_cn As Boolean)
        Dim x0_frame As Double, x1_frame As Double
        x0_frame = hx
        DrawLevel(myMain.myRCType.fSplitHigh, True)
        DrawLevel(myMain.myRCType.fSplitLow, False)
        x1_frame = hx
        If bLang_cn Then
            DrawFrame("分割码", x0_frame, x1_frame)
        Else
            DrawFrame("Split", x0_frame, x1_frame)
        End If
    End Sub

    Private Sub DrawData1(ByVal data As Byte, ByVal bNotRevert As Boolean, ByVal bLang_cn As Boolean)
        Dim x0_frame As Double, x1_frame As Double

        x0_frame = hx
        Dim dx As UInt16
        Dim bits As Integer
        If myMain.myRCType.bL7464Check Then
            dx = data * &H100L + (data Xor &H80)
            bits = 16
        Else
            dx = data
            bits = myMain.myRCType.nDataCode1Bits
        End If
        If Not bNotRevert Then
            dx = Not dx
        End If
        DrawData(dx, bits, "D")
        x1_frame = hx

        If bLang_cn Then
            DrawFrame("数据码1: " & TruncateHex(dx, bits), x0_frame, x1_frame)
        Else
            DrawFrame("Data1: " & TruncateHex(dx, bits), x0_frame, x1_frame)
        End If
    End Sub

    Private Sub DrawUser2(ByVal bNotRevert As Boolean, ByVal bLang_cn As Boolean)
        Dim x0_frame As Double, x1_frame As Double

        x0_frame = hx
        Dim dx As UInt16
        If bNotRevert Then
            dx = myMain.myRCType.nUserCode2
        Else
            dx = Not myMain.myRCType.nUserCode2
        End If
        DrawData(dx, myMain.myRCType.nUserCode2Bits, "C")
        x1_frame = hx

        If bLang_cn Then
            DrawFrame("用户码2: " & TruncateHex(dx, myMain.myRCType.nUserCode2Bits), x0_frame, x1_frame)
        Else
            DrawFrame("User2: " & TruncateHex(dx, myMain.myRCType.nUserCode2Bits), x0_frame, x1_frame)
        End If
    End Sub

    Private Sub DrawData2(ByVal data As Byte, ByVal bNotRevert As Boolean, ByVal bLang_cn As Boolean)
        Dim x0_frame As Double, x1_frame As Double
        Dim ud As UInt16

        x0_frame = hx
        Dim dx As UInt16
        If myMain.myRCType.nData2Choice = 0 Then
            ud = Not data
        ElseIf myMain.myRCType.nData2Choice = 1 Then
            ud = myMain.myRCType.nDataCode2
        Else
            ud = myMain.myRCType.nChecksum
            ud += (Not data)
            ud += 1
        End If
        If bNotRevert Then
            dx = ud
        Else
            dx = Not ud
        End If

        If myMain.myRCType.nData2Choice = 1 Then
            DrawData(dx, myMain.myRCType.nDataCode2Bits, "D")
        Else
            DrawData(dx, myMain.myRCType.nDataCode1Bits, "D")
        End If

        x1_frame = hx

        If myMain.myRCType.nData2Choice = 1 Then
            If bLang_cn Then
                DrawFrame("数据码2: " & TruncateHex(dx, myMain.myRCType.nDataCode2Bits), x0_frame, x1_frame)
            Else
                DrawFrame("Data2: " & TruncateHex(dx, myMain.myRCType.nDataCode2Bits), x0_frame, x1_frame)
            End If
        Else
            If bLang_cn Then
                DrawFrame("数据码2: " & TruncateHex(dx, myMain.myRCType.nDataCode1Bits), x0_frame, x1_frame)
            Else
                DrawFrame("Data2: " & TruncateHex(dx, myMain.myRCType.nDataCode1Bits), x0_frame, x1_frame)
            End If
        End If

    End Sub

    Private Sub DrawStopBit(ByVal bLang_cn As Boolean)
        Dim x0_frame As Double, x1_frame As Double
        x0_frame = hx
        If myMain.myRCType.bHtoL_Stop Then
            DrawLevel(myMain.myRCType.fStopBitFirst, True)
            DrawLevel(myMain.myRCType.fStopBitSecond, False)
            'If myMain.myRCType.bHtoL_L0 Then
            '    DrawLevel(myMain.myRCType.fSecond_L0, False)
            'Else
            '    DrawLevel(myMain.myRCType.fFirst_L0, False)
            'End If
        Else
            DrawLevel(myMain.myRCType.fStopBitFirst, False)
            DrawLevel(myMain.myRCType.fStopBitSecond, True)
            'If myMain.myRCType.bHtoL_L0 Then
            '    DrawLevel(myMain.myRCType.fFirst_L0, True)
            'Else
            '    DrawLevel(myMain.myRCType.fSecond_L0, True)
            'End If
        End If
        'DrawLevel(myMain.myRCType.fStopTime, False)

        x1_frame = hx
        If bLang_cn Then
            DrawFrame("停止位", x0_frame, x1_frame)
        Else
            DrawFrame("Stop Bit", x0_frame, x1_frame)
        End If
    End Sub

    Private Sub DrawStopCode(ByVal bLang_cn As Boolean)
        Dim x0_frame As Double, x1_frame As Double, x As Double
        x0_frame = hx

        If (myMain.myRCType.bDefineStopTime) Then
            DrawLevel(myMain.myRCType.fStopTime, False)
        Else
            x = myMain.myRCType.fStopTime - x0_frame

            'Dim fnt_l As New Font("Arial", 8)
            'Dim strfmt As New StringFormat()
            'strfmt.Alignment = StringAlignment.Near

            'g.DrawString(x.ToString, fnt_l, Brushes.Pink, 0, 0, strfmt)

            If x > 1000 Then
                DrawLevel(x, False)
            Else
                DrawLevel(1000, False)
            End If
        End If

        x1_frame = hx
        If bLang_cn Then
            DrawFrame("停止码", x0_frame, x1_frame)
        Else
            DrawFrame("Stop Code", x0_frame, x1_frame)
        End If
    End Sub

    Private Sub DrawCompactRepeat(ByVal bLang_cn As Boolean)
        Dim x0_frame As Double, x1_frame As Double
        x0_frame = hx
        DrawLevel(myMain.myRCType.fHighRepeat, True)
        DrawLevel(myMain.myRCType.fLowRepeat, False)

        If myMain.myRCType.nRepeatHLX = 1 Then
            DrawBit(False, "R0")
        ElseIf myMain.myRCType.nRepeatHLX = 2 Then
            DrawBit(True, "R1")
        End If

        If myMain.myRCType.bHtoL_Stop Then
            DrawLevel(myMain.myRCType.fStopBitFirst, True)
            DrawLevel(myMain.myRCType.fStopBitSecond, False)
        Else
            DrawLevel(myMain.myRCType.fStopBitFirst, False)
            DrawLevel(myMain.myRCType.fStopBitSecond, True)
        End If

        x1_frame = hx
        If bLang_cn Then
            DrawFrame("简单重复码", x0_frame, x1_frame)
        Else
            DrawFrame("Compact Repeat", x0_frame, x1_frame)
        End If
    End Sub

    Private Sub DrawRepeatStopCode(ByVal bLang_cn As Boolean)
        Dim x0_frame As Double, x1_frame As Double, x As Double
        x0_frame = hx

        If (myMain.myRCType.bDefineStopTime) Then
            DrawLevel(myMain.myRCType.fStopTime, False)
        Else
            x = myMain.myRCType.fStopTime - x0_frame + fTimeFrame(7)
            If x > 1000 Then
                DrawLevel(x, False)
            Else
                DrawLevel(1000, False)
            End If
        End If

        'DrawLevel(myMain.myRCType.fRepeatStopTime, False)

        x1_frame = hx
        If bLang_cn Then
            DrawFrame("重复帧停止码", x0_frame, x1_frame)
        Else
            DrawFrame("Stop Repeat Code", x0_frame, x1_frame)
        End If
    End Sub

End Module
