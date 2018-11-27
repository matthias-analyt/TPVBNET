Public Class Bezier

    Private A_, B_ As PointF 'points de la courbe
    Private Ad_, Bd_ As PointF 'points des tangentes
    Private nbseg_ As Integer


    Public Sub New(A As PointF, B As PointF, Ad As PointF, Bd As PointF)

        A_ = A
        B_ = B
        Ad_ = Ad
        Bd_ = Bd
        nbseg_ = 10


    End Sub


    Public Property A() As PointF
        Get
            Return A_
        End Get
        Set(ByVal value As PointF)
            A_ = value
        End Set
    End Property

    Public Property B() As PointF
        Get
            Return B_
        End Get
        Set(ByVal value As PointF)
            B_ = value
        End Set
    End Property

    Public Property Ad() As PointF
        Get
            Return Ad_
        End Get
        Set(ByVal value As PointF)
            Ad_ = value
        End Set
    End Property

    Public Property Bd() As PointF
        Get
            Return Bd_
        End Get
        Set(ByVal value As PointF)
            Bd_ = value
        End Set
    End Property

    Public Property nbseg() As Integer
        Get
            Return nbseg_
        End Get
        Set(ByVal value As Integer)
            nbseg_ = value
        End Set
    End Property


End Class
