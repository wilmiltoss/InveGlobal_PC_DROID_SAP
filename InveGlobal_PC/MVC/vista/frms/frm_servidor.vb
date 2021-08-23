Public Class frm_servidor


    Public Const NOMBRE_CLASE As String = "frm_servidor"
    'administradores de frm
    Public oApControlador As ApControlador
    'administradores de datos
    Public oApModelo As ApModelo


#Region "CONTRUCTORES "

    Public Sub New(ByRef oApControladorParam As ApControlador)
        oApControlador = oApControladorParam

        InitializeComponent()


    End Sub


#End Region



    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        'cerramos el este formulario
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        __guardar_datos()
        'cerramos el formulario frmServidor
        Me.Close()
        oApControlador.notificar_mensaje_cierre("Cierre la aplicación para establecer los cambios", "Datos de Sistema")

    End Sub

    ''' <summary>
    ''' CARGA el "Local a cambiar"
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub __guardar_datos()

        Dim NOMBRE_METODO As String = NOMBRE_CLASE & ".__guardar_datos()"
        Dim lResultado As New List(Of Object)(New Object() {0, NOMBRE_METODO & " No Ejecutado!"})

        Try
            'Cambio de sistema al EME
            If rbEme.Checked = True Then
                lResultado = oApControlador.oApModelo.Locales_ADM().lActualizar(Me.oApControlador.Local_OTD)
                'si se ejecuto correctamente
                If lResultado(0).Equals(1) Then

                    'mensaje exitoso
                    oApControlador.notificar_exito("Datos de Sistema guardados correctamente!", "Datos de Sistema")
                Else
                    'sino, mensaje de notificacion de error
                    oApControlador.notificar_error(lResultado(1).ToString(), "Datos de Sistema")
                End If

                'Cambio de sistema al SAP
            ElseIf rbSap.Checked = True Then
                lResultado = oApControlador.oApModelo.Locales_ADM().lAgregar(Me.oApControlador.Local_OTD)

                'si se ejecuto correctamente
                If lResultado(0).Equals(1) Then

                    'mensaje exitoso
                    oApControlador.notificar_exito("Datos de Sistema guardados correctamente!", "Datos de Sistema")

                Else
                    'sino, mensaje de notificacion de error
                    oApControlador.notificar_error(lResultado(1).ToString(), "Datos de Sistema")
                End If

            End If

        Catch ex As Exception
            'en caso de error, mensaje de notificacion
            oApControlador.notificar_error(NOMBRE_METODO & " Error: " & ex.Message, "Datos de Sistema")

        End Try

        Cursor.Current = Cursors.Default

    End Sub

End Class