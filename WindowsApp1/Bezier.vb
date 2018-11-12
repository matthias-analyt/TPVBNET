Public Class Bezier

    Private A_, B_ As Point 'points de la courbe
    Private Ad_, Bd_ As Point 'points des tangentes

    Public Property A() As Point
        Get
            Return A_
        End Get
        Set(ByVal value As Point)
            A_ = value
        End Set
    End Property

    Public Property B() As Point
        Get
            Return B_
        End Get
        Set(ByVal value As Point)
            B_ = value
        End Set
    End Property

    Public Property Ad() As Point
        Get
            Return Ad_
        End Get
        Set(ByVal value As Point)
            Ad_ = value
        End Set
    End Property

    Public Property Bd() As Point
        Get
            Return Bd_
        End Get
        Set(ByVal value As Point)
            Bd_ = value
        End Set
    End Property


End Class
