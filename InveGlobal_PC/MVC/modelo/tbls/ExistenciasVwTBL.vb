Imports CdgPersistencia.ClasesBases
Imports CdgPersistencia.Componentes

Public Class ExistenciasVwTBL
    Inherits TBLbase

#Region "ATRIBUTOS"


    Public Const NOMBRE_CLASE As String = "ExistenciasVwTBL"
    Public Shadows Const NOMBRE_TABLA As String = "VW_EXISTENCIAS_TOTALES"


    'nombres de campos
    Public Shared ID_INVENTARIO As New Campo("ID_INVENTARIO", 0, False, GetType(Long))
    Public Shared FECHA_INVENTARIO As New Campo("FECHA_INVENTARIO", 1, False, GetType(DateTime))
    Public Shared ID_SECTOR As New Campo("ID_SECTOR", 2, False, GetType(Integer))
    Public Shared NOMBRE_SECTOR As New Campo("NOMBRE_SECTOR", 3, False, GetType(String))

    Public Shared SCANNING As New Campo("SCANNING", 4, False, GetType(Long))
    Public Shared DESCRIPCION As New Campo("DESCRIPCION", 5, False, GetType(String))
    Public Shared COSTO As New Campo("COSTO", 6, False, GetType(Double))
    Public Shared CANTIDAD_TEORICA As New Campo("CANTIDAD_TEORICA", 7, False, GetType(Double))

    Public Shared CONTEO_1 As New Campo("CONTEO_1", 8, False, GetType(Double))
    Public Shared CONTEO_2 As New Campo("CONTEO_2", 9, False, GetType(Double))
    Public Shared DIFERENCIA_12 As New Campo("DIFERENCIA_1_2", 10, False, GetType(Double))
    Public Shared CONTEO_3 As New Campo("CONTEO_3", 11, False, GetType(Double))

    Public Shared CANTIDAD_AJUSTE As New Campo("CANTIDAD_AJUSTE", 12, False, GetType(Double))
    Public Shared DIF_VALORIZADO As New Campo("DIF_VALORIZADO", 13, False, GetType(Double))

    Public Shared AJUSTAR As New Campo("AJUSTAR", 14, False, GetType(Boolean))
    Public Shared AJUSTADO As New Campo("AJUSTADO", 15, False, GetType(Boolean))
    Public Shared PESABLE As New Campo("PESABLE", 16, False, GetType(Boolean))



#End Region


#Region "CONSTRUCTORES"

    ''' <summary>
    ''' Constructor de la clase
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        MyBase.New()
        'asignamos la coleccion de campos
        CAMPOS = New Campo() {ID_INVENTARIO, FECHA_INVENTARIO, ID_SECTOR, NOMBRE_SECTOR _
                            , SCANNING, DESCRIPCION, COSTO, CANTIDAD_TEORICA _
                            , CONTEO_1, CONTEO_2, DIFERENCIA_12, CONTEO_3 _
                            , CANTIDAD_AJUSTE, DIF_VALORIZADO, AJUSTAR, AJUSTADO, PESABLE _
                            }

    End Sub



#End Region


    Public Overrides Function Get_nombre_tabla() As String
        Return NOMBRE_TABLA
    End Function


End Class

