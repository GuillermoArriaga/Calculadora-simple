<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GAGvbCalculadora
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tbIngreso = New System.Windows.Forms.TextBox()
        Me.tbResultado = New System.Windows.Forms.TextBox()
        Me.bIgual = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'tbIngreso
        '
        Me.tbIngreso.Location = New System.Drawing.Point(53, 23)
        Me.tbIngreso.Name = "tbIngreso"
        Me.tbIngreso.Size = New System.Drawing.Size(127, 22)
        Me.tbIngreso.TabIndex = 0
        Me.tbIngreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbResultado
        '
        Me.tbResultado.Location = New System.Drawing.Point(53, 68)
        Me.tbResultado.Name = "tbResultado"
        Me.tbResultado.Size = New System.Drawing.Size(127, 22)
        Me.tbResultado.TabIndex = 1
        Me.tbResultado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bIgual
        '
        Me.bIgual.Location = New System.Drawing.Point(16, 111)
        Me.bIgual.Name = "bIgual"
        Me.bIgual.Size = New System.Drawing.Size(164, 23)
        Me.bIgual.TabIndex = 2
        Me.bIgual.Text = "="
        Me.bIgual.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "In:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Out:"
        '
        'GAGvbCalculadora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(192, 150)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bIgual)
        Me.Controls.Add(Me.tbResultado)
        Me.Controls.Add(Me.tbIngreso)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GAGvbCalculadora"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GAGcalculadora"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbIngreso As TextBox
    Friend WithEvents tbResultado As TextBox
    Friend WithEvents bIgual As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
