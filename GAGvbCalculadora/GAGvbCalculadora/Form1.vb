Public Class GAGvbCalculadora
    Private Sub bIgual_Click(sender As Object, e As EventArgs) Handles bIgual.Click
        Dim it As Integer
        Dim num(100) As Double
        Dim parentesis(2) As Integer
        Dim longitud As Integer
        Dim conta1 As Integer
        Dim conta2 As Integer

        longitud = Len(tbIngreso.Text)

        'Retirador de espacios
        For it = 1 To longitud
            If Mid(tbIngreso.Text, it, 1) = " " Then
                tbIngreso.Text = Mid(tbIngreso.Text, 1, it - 1) & Mid(tbIngreso.Text, it + 1, longitud)
                longitud = longitud - 1
                it = it - 1
            End If
        Next

        'Revisor de cantidad de parentesis
        conta1 = 0 'Parentesis de apertura
        longitud = Len(tbIngreso.Text)

        For it = 1 To longitud
            Select Case Mid(tbIngreso.Text, it, 1)
                Case "("
                    conta1 = conta1 + 1
                Case ")"
                    conta1 = conta1 - 1
            End Select
        Next it

        If conta1 <> 0 Then
            MsgBox("No coinciden los parentesis.")
        Else
            'Solucion con parentesis para incluir más términos
            tbResultado.Text = calculoSimple(tbIngreso.Text)
            tbIngreso.Text = "(" & tbResultado.Text & ")"
            tbIngreso.Select(Len(tbIngreso.Text), 1)

        End If

    End Sub

    Private Function calculoSimple(cad As String) As String
        ' Tipo a+b , a-b, a*b a/b, a^b
        'Detecta primer número
        Dim resultado As Double
        Dim conta1 As Integer
        Dim conta2 As Integer
        Dim parentesis(2) As Integer
        Dim longitud As Integer
        Dim newCad As String
        Dim operacion(3) As Integer
        Dim num(4) As String
        Dim oper(3) As String
        Dim operPos As Integer
        Dim it As Integer

        conta1 = 0 'Parentesis de apertura
        longitud = Len(cad)

        For it = 1 To longitud
            Select Case Mid(cad, it, 1)
                Case "("
                    conta1 = conta1 + 1
                    If (conta1 = 1) Then
                        parentesis(1) = it         ' 1er nivel jerarquico
                    End If
                Case ")"
                    If conta1 = 1 Then
                        parentesis(2) = it
                    End If
                    conta1 = conta1 - 1
            End Select
        Next it

        'Calculo por parentesis
        newCad = ""
        If parentesis(1) > 1 Then
            newCad = newCad & Mid(cad, 1, parentesis(1) - 1)
        End If
        If parentesis(2) - 1 > parentesis(1) Then
            newCad = newCad & calculoSimple(Mid(cad, parentesis(1) + 1, parentesis(2) - 1 - parentesis(1)))
        End If
        If longitud > parentesis(2) Then
            newCad = newCad & Mid(cad, parentesis(2) + 1, longitud - parentesis(2))
        End If

        cad = newCad

        'A partir de aquí no hay parentesis dentro de la operación que se realizará

        'Detección de signo negativo lo cambia temporalmente por \
        conta1 = 0 'Parentesis de apertura
        longitud = Len(cad)

        'For it = 1 To longitud
        'If Mid(cad, it, 1) = "-" Then
        'If Mid(cad, it + 1, 1) <> "(" And (Val(Mid(cad, it + 1, 1)) <> 0 And Mid(cad, it + 1, 1) <> "0" And Mid(cad, it + 1, 1) <> ".") Then
        'If it > 1 Then
        'If (Mid(cad, it - 1, 1) <> ")" And Val(Mid(cad, it - 1, 1)) <> 0 And Mid(cad, it - 1, 1) <> "0" And Mid(cad, it - 1, 1) <> ".") Then
        'Mid(cad, it, 1) = "\"
        'End If
        '
        'ElseIf it = 1 Then
        'Mid(cad, it, 1) = "\"
        'End If
        'End If
        'End If
        'Next it

        'For it = 1 To longitud
        'If Mid(cad, it, 1) = "-" Then
        '
        'cad = Mid(cad, 1, it - 1) & "+(-1)*" & Mid(cad, it + 1, Len(cad) - it)
        'End If
        'Next it



        'Búsqueda de uno o dos operadores binarios
        'operacion(1) = 0
        'operacion(2) = Len(cad)
        'operacion(3) = Len(cad)
        'conta1 = 1

        operPos = 0
        For it = 1 To Len(cad)
            If (Mid(cad, it, 1) = "^") Then
                operPos = it
                it = -1
                Exit For
            End If
        Next it

        If it = -1 Then GoTo operar

        For it = 1 To Len(cad)
            If (Mid(cad, it, 1) = "*" Or Mid(cad, it, 1) = "/") Then
                operPos = it
                it = -1
                Exit For
            End If
        Next it

        If it = -1 Then GoTo operar

        For it = 1 To Len(cad)
            If (Mid(cad, it, 1) = "+" Or Mid(cad, it, 1) = "-") Then
                operPos = it
                it = -1
                Exit For
            End If
        Next it

        If it = -1 Then GoTo operar

operar:
        If operPos > 0 Then

            'Busca los números de alrededor a operar
            For conta1 = (operPos - 1) To 1 Step -1
                If (Val(Mid(cad, conta1, 1)) = 0 And Mid(cad, conta1, 1) <> "." And Mid(cad, conta1, 1) <> "0" And Mid(cad, conta1, 1) <> "\") Then Exit For
            Next conta1
            conta1 = conta1 + 1

            For conta2 = (operPos + 1) To Len(cad)
                If (Val(Mid(cad, conta2, 1)) = 0 And Mid(cad, conta2, 1) <> "." And Mid(cad, conta2, 1) <> "0" And Mid(cad, conta2, 1) <> "\") Then Exit For
            Next conta2
            conta2 = conta2 - 1

            'Numeros a operar, de tipo string
            num(1) = Mid(cad, conta1, operPos - conta1)
            num(2) = Mid(cad, operPos + 1, conta2 - operPos)

            'Regresa el signo negativo
            'If Mid(num(1), 1, 1) = "\" Then num(1) = "-" & Mid(num(1), 2, Len(num(1)) - 1)
            'If Mid(num(2), 1, 1) = "\" Then num(2) = "-" & Mid(num(2), 2, Len(num(2)) - 1)

            'Opera
            Select Case Mid(cad, operPos, 1)
                Case "+"
                    resultado = Val(num(1)) + Val(num(2))
                Case "-"
                    resultado = Val(num(1)) - Val(num(2))
                Case "*"
                    resultado = Val(num(1)) * Val(num(2))
                Case "/"
                    resultado = Val(num(1)) / Val(num(2))
                Case "^"
                    resultado = Val(num(1)) ^ Val(num(2))
            End Select

            num(1) = ""
            num(2) = ""
            If 1 < conta1 Then num(1) = Mid(cad, 1, conta1 - 1)
            If Len(cad) > conta2 Then num(2) = Mid(cad, conta2 + 1, Len(cad) - conta2)
            If num(1) & num(2) = "" Then
                'Fin la recursión.
                Return (resultado)
            Else
                'Recursion si hay otra operación
                Return (calculoSimple(num(1) & resultado & num(2)))
            End If

        Else
            'Fin de la recursión. 
            conta1 = 0
            For conta2 = 1 To Len(cad)
                If Mid(cad, conta2, 1) = "\" Then
                    Mid(cad, conta2, 1) = "-"
                    conta1 = conta1 + 1
                End If
            Next conta2
            If conta1 > 0 Then
                Return (calculoSimple(cad)) 'Signo negativo a resta
            Else
                Return (cad)  'FIN
            End If

        End If

    End Function


    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbIngreso.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                bIgual_Click(sender, e)
            Case Keys.Delete
                tbIngreso.Clear()
        End Select
    End Sub

End Class
