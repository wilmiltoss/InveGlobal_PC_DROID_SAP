﻿Imports CdgPersistencia.ClasesBases

Public Class ExistenciasVwADM_SAP
    Inherits ADMbase

#Region "ATRIBUTOS"

    Public Const NOMBRE_CLASE As String = "ExistenciasADM_SAP"

    Private __oApModelo As ApModelo



#End Region


#Region "CONSTRUCTORES"

    Public Sub New(ByVal ApModeloParam As ApModelo)
        MyBase.New(ApModeloParam.Get_conector())

        __oApModelo = ApModelo.Get_instancia()
        Set_tabla(New ExistenciasVwTBL_SAP())

    End Sub



#End Region


#Region "Miembros de ADMbase"

    Public Overrides Function lAgregar(ByVal oOTDbase As OTDbase) As List(Of Object)
        Throw New NotImplementedException()
    End Function

    Public Overrides Function lActualizar(ByVal oOTDbase As OTDbase) As List(Of Object)
        Throw New NotImplementedException()
    End Function

    Public Overrides Function lEliminar(ByVal oOTDbase As OTDbase) As List(Of Object)
        Throw New NotImplementedException()
    End Function

    Public Overrides Function lGet_elemento(ByVal oSectorParam As OTDbase) As List(Of Object)
        Throw New NotImplementedException()
    End Function

    Public Overrides Function lGet_elementos(ByVal cFiltroWhere As String) As List(Of Object)

        Dim NOMBRE_METODO As String = NOMBRE_CLASE + ".lGet_elementos()"

        'resultado por defecto del metodo
        Dim lResultado As New List(Of Object)(New Object() {0, NOMBRE_METODO & " No Ejecutado!"})

        'intentamos recuperar los datos
        Try
            'ensamblamos la consulta sql
            Dim cConsulta As String = String.Format(_Select_sql & cFiltroWhere)

            'busqueda filtrada
            lResultado = _oConector.lEjecutar_consulta(cConsulta)

            'si se ejecuto correctamente
            If lResultado(0).Equals(1) Then
                'instancias auxiliares
                Dim lExistenciasVw As New List(Of ExistenciaVwOTD_SAP)()
                Dim dtResultado As DataTable = CType(lResultado(1), DataTable)

                'recorremos las filas devueltas
                For Each dr As DataRow In dtResultado.Rows
                    'lo agregamos a la lista
                    lExistenciasVw.Add(New ExistenciaVwOTD_SAP(Long.Parse(dr(ExistenciasVwTBL_SAP.ID_INVENTARIO.nIndice).ToString()) _
                                                            , DateTime.Parse(dr(ExistenciasVwTBL_SAP.FECHA_INVENTARIO.nIndice).ToString()) _
                                                            , dr(ExistenciasVwTBL_SAP.ID_SECTOR.nIndice).ToString() _
                                                            , dr(ExistenciasVwTBL_SAP.NOMBRE_SECTOR.nIndice).ToString() _
                                                            , dr(ExistenciasVwTBL_SAP.SCANNING.nIndice).ToString() _
                                                            , dr(ExistenciasVwTBL_SAP.DESCRIPCION.nIndice).ToString() _
                                                            , Double.Parse(dr(ExistenciasVwTBL_SAP.COSTO.nIndice).ToString()) _
                                                            , Double.Parse(dr(ExistenciasVwTBL_SAP.CANTIDAD_TEORICA.nIndice).ToString()) _
                                                            , Double.Parse(dr(ExistenciasVwTBL_SAP.CONTEO_1.nIndice).ToString()) _
                                                            , Double.Parse(dr(ExistenciasVwTBL_SAP.CONTEO_2.nIndice).ToString()) _
                                                            , Double.Parse(dr(ExistenciasVwTBL_SAP.CONTEO_3.nIndice).ToString()) _
                                                            , Double.Parse(dr(ExistenciasVwTBL_SAP.CANTIDAD_AJUSTE.nIndice).ToString()) _
                                                            , Boolean.Parse(dr(ExistenciasVwTBL_SAP.AJUSTAR.nIndice).ToString()) _
                                                            , Boolean.Parse(dr(ExistenciasVwTBL_SAP.AJUSTADO.nIndice).ToString()) _
                                                            , Boolean.Parse(dr(ExistenciasVwTBL_SAP.PESABLE.nIndice).ToString()) _
                                                            , dr(ExistenciasVwTBL_SAP.ID_SISTEMA.nIndice).ToString() _
                                                            , dr(ExistenciasVwTBL_SAP.ID_EN_SISTEMA.nIndice).ToString() _
                                                            , (dr(ExistenciasVwTBL_SAP.CANT_SALON.nIndice).ToString()) _
                                                            , (dr(ExistenciasVwTBL_SAP.CANT_DESPOSITO.nIndice).ToString()) _
                                                            , (dr(ExistenciasVwTBL_SAP.CANT_DEVOLUCIONES.nIndice).ToString())
                                            ))

                Next

                'establecemos el resultado del metodo
                lResultado = New List(Of Object)(New Object() {1, lExistenciasVw, dtResultado})

            End If

        Catch ex As Exception

            'en caso de error
            lResultado = New List(Of Object)(New Object() {-1, NOMBRE_METODO & " Error: " & ex.Message})

        End Try

        'devolvemos el resultado del metodo
        Return lResultado

    End Function

#End Region


#Region "ESPECIFICOS"


#End Region



End Class
