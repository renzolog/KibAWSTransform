Partial Public Class Gestione

    ''' <summary>
    ''' Abilita o Disabilità il log di sistema
    ''' </summary>
    ''' <param name="Value">Se true abilita il log</param>
    Public Sub SetEnabledLogSystem(Value As Boolean)

    End Sub

    ''' <summary>
    ''' Abilita o disabilita il WithStopContinue su Exception
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <remarks>Per uso interno</remarks>
    Public Sub SetWithStopContinueLogSystem(Value As Boolean)
        LogSystem.WithStopContinue = Value
    End Sub

End Class
