Public Class RCType
    Enum CarrierDuty
        quarter = 0
        third = 1
        half = 2
    End Enum

    Enum LEDCurrent
        i1ma = 0
        i2ma = 1
        i4ma = 2
        i8ma = 3
    End Enum

    Enum IROUTCurrent
        i125ma = 0
        i250ma = 1
        i375ma = 2
        i500ma = 3
    End Enum

    Enum Debounce
        d10ms = 0
        d20ms = 1
    End Enum

    Enum ScanInterval
        s1ms = 0
        s4ms = 1
        's8ms = 1
        s16ms = 2
        s32ms = 3
    End Enum

    Public bHtoL_L0 As Boolean
    Public fFirst_L0 As Single
    Public fSecond_L0 As Single

    Public bHtoL_L1 As Boolean
    Public fFirst_L1 As Single
    Public fSecond_L1 As Single

    Public fCarrierFreq As Single
    Public nDuty As CarrierDuty

    Public bLowBitFirst As Boolean

    Public bLedEnable As Boolean
    Public nLedCurrent As LEDCurrent
    Public bLedHigh As Boolean

    Public nIroutCurrent As IROUTCurrent

    Public bCountLimit As Boolean
    Public nKeyRemainTime As Integer
    Public fDebounce As Single
    Public bScanOneTime As Boolean
    Public nScanInterval As ScanInterval
    Public nInvalidKeyCode As Byte
    Public bUpKeyEnable As Boolean
    Public nUpKeyCode As Byte
    Public bVDDKeyScan As Boolean

    Public bDoubleFrame As Boolean

    Public bBootFrame As Boolean
    Public bUserFrame As Boolean
    Public bSplitFrame As Boolean
    Public bDataFrame As Boolean
    Public bStopFrame As Boolean
    Public bRepeatFrame As Boolean
    Public bDataCode1 As Boolean
    Public bUserCode2 As Boolean
    Public bDataCode2 As Boolean
    Public bStopBit As Boolean
    Public bStopCode As Boolean
    'Public bCompact As Boolean
    'Public bComplete As Boolean

    Public fBootHigh As Single
    Public fBootLow As Single

    Public fSplitHigh As Single
    Public fSplitLow As Single

    Public nUserCode As UInt32
    Public nUserBits As Integer
    Public bRevertBitHi As Boolean
    Public nPositionHi As Integer
    Public bRevertBitLo As Boolean
    Public nPositionLo As Integer
    Public bBitExpand As Boolean
    Public bBit1Option As Boolean

    Public nDataCode1Bits As Integer
    Public bL7464Check As Boolean
    Public bL7464_Xor As Boolean
    Public b1986Enable As Boolean

    Public nUserCode2 As UInt16
    Public nUserCode2Bits As Integer

    Public nData2Choice As Integer
    Public nDataCode2Bits As Integer
    Public nDataCode2 As UInt16
    Public nChecksum As Byte

    Public bHtoL_Stop As Boolean
    Public fStopBitFirst As Single
    Public fStopBitSecond As Single

    Public bDefineStopTime As Boolean
    Public fStopTime As Single

    Public bCompleteRepeat As Boolean
    Public fHighRepeat As Single
    Public fLowRepeat As Single
    Public nRepeatHLX As Integer
    Public bBootCode As Boolean
    Public fRepeatBootHigh As Single
    Public fRepeatBootLow As Single
    Public bData1Revert As Boolean
    Public bUser2Revert As Boolean
    Public bData2Revert As Boolean
    Public fRepeatStopTime As Single

    Public bRepeatDataFrame As Boolean
    Public bRepeatModeGroup As Boolean
    Public nRepeatGroupBoundry As Byte
    Public bSameAsBoot As Boolean

    Public bMultiUser As Boolean
    Public nMultiUserBits As Integer
    Public nMultiUserBoundry1 As Byte
    Public nMultiUserBoundry2 As Byte
    Public nMultiUserCode1 As UInt16
    Public nMultiUserCode2 As UInt16
    Public nMultiUserCode3 As UInt16

    Public nPressKey As Integer
    Public nSingleKey(90) As Byte
    Public sSingleKeyLabel(90) As String
    'Public nDoubleKey(7) As Byte
    'Public sDoubleKeyLabel(7) As String
    'Public nDKX(1, 7) As Integer
    'Public nTripleKey(1) As Byte
    'Public sTripleKeyLabel(1) As String
    'Public nTKX(2, 1) As Integer

    Public sInfoName As String
    Public sInfoNote As String

    'Public nNowKeyValue As Byte

    'For Debug
    Public bFilterEnable As Boolean
    Public nTempValue As Integer
    Public bHighSpeed As Boolean
    Public bLDO17 As Boolean
    Public nDriveSpeed As Integer
    Public nIRef As Integer
    Public b150K As Boolean
    Public bNotOD As Boolean
    Public bNotConn As Boolean


    Sub Reset()
        bHtoL_L0 = True
        fFirst_L0 = 556.5
        fSecond_L0 = 556.5

        bHtoL_L1 = True
        fFirst_L1 = 556.5
        fSecond_L1 = 1696

        fCarrierFreq = 37.736
        nDuty = CarrierDuty.third

        bLowBitFirst = True

        bLedEnable = False
        nLedCurrent = LEDCurrent.i4ma
        nIroutCurrent = IROUTCurrent.i500ma
        bLedHigh = True

        bCountLimit = True
        nKeyRemainTime = 30
        fDebounce = 20
        bScanOneTime = False
        nScanInterval = ScanInterval.s16ms
        nInvalidKeyCode = &H3F
        bUpKeyEnable = False
        nUpKeyCode = &HFF
        bVDDKeyScan = False

        bDoubleFrame = False

        bBootFrame = True
        bUserFrame = True
        bSplitFrame = False
        bDataFrame = True
        bDataCode1 = True
        bUserCode2 = False
        bDataCode2 = True
        bStopFrame = True
        bStopBit = True
        bStopCode = True
        bRepeatFrame = True
        'bCompact = True
        'bComplete = True

        fBootHigh = 9010
        fBootLow = 4505

        fSplitHigh = 760.5
        fSplitLow = 760.5

        nUserCode = &HE36C
        nUserBits = 16
        bRevertBitHi = False
        nPositionHi = 17
        bRevertBitLo = False
        nPositionLo = 3
        bBitExpand = False
        bBit1Option = False

        nDataCode1Bits = 8
        bL7464Check = False
        bL7464_Xor = True
        b1986Enable = False

        nUserCode2 = &H37E4
        nUserCode2Bits = 9

        nData2Choice = 0
        nDataCode2 = &H1234
        nDataCode2Bits = 8
        nChecksum = &H53

        bHtoL_Stop = True
        fStopBitFirst = 556.5
        fStopBitSecond = 556.5

        bDefineStopTime = True
        fStopTime = 108000

        bCompleteRepeat = False
        fHighRepeat = 9010
        fLowRepeat = 2252.5
        nRepeatHLX = 2
        bBootCode = True
        fRepeatBootHigh = 9010
        fRepeatBootLow = 4505
        bData1Revert = False
        bUser2Revert = False
        bData2Revert = False
        fRepeatStopTime = 108000

        bRepeatDataFrame = False
        bRepeatModeGroup = False
        nRepeatGroupBoundry = 35
        bSameAsBoot = True

        bMultiUser = False
        nMultiUserBits = 16
        nMultiUserBoundry1 = 25
        nMultiUserBoundry2 = 50
        nMultiUserCode1 = &H1234
        nMultiUserCode2 = &H5678
        nMultiUserCode3 = &H9ABC



        Dim i As Integer
        For i = 0 To 90
            nSingleKey(i) = i
            sSingleKeyLabel(i) = "DEMO" & i.ToString
        Next

        'For i = 0 To 7
        '    nDoubleKey(i) = 91 + i
        '    sDoubleKeyLabel(i) = "DOUBLE" & i.ToString
        '    nDKX(0, i) = KEY_MATRIX(i + 1, i)
        '    nDKX(1, i) = KEY_MATRIX(i + 3, i + 2)
        'Next
        'nDKX(0, 6) = 255
        'nDKX(1, 6) = 255

        'For i = 0 To 1
        '    nTripleKey(i) = 99 + i
        '    sTripleKeyLabel(i) = "TRIPLE" & i.ToString
        '    nTKX(0, i) = KEY_MATRIX(i + 1, i)
        '    nTKX(1, i) = KEY_MATRIX(i + 3, i + 2)
        '    nTKX(2, i) = KEY_MATRIX(i + 5, i + 4)
        'Next
        'nTKX(0, 1) = 255
        'nTKX(1, 1) = 255
        'nTKX(2, 1) = 255

        nPressKey = 0
        'nNowKeyValue = 0

        sInfoName = "DEMO"
        sInfoNote = "Note:"

        'For Debug
        bFilterEnable = True
        nTempValue = 31
        bHighSpeed = True
        bLDO17 = True
        nDriveSpeed = 3
        nIRef = 1
        b150K = True
        bNotOD = True
        bNotConn = True
    End Sub

    Sub New()
        Reset()
    End Sub

End Class

