Namespace Autenthicate
    Public MustInherit Class BaseProtect
        Protected Friend ReadOnly User As User
        Public Sub New(User As User)
            Me.User = User
        End Sub
    End Class
End Namespace