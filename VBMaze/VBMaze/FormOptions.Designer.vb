<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOptions
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numeric_spacing = New System.Windows.Forms.NumericUpDown()
        Me.button_random = New System.Windows.Forms.Button()
        Me.button_isometric = New System.Windows.Forms.Button()
        Me.button_square = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numeric_spacing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.numeric_spacing)
        Me.GroupBox1.Controls.Add(Me.button_random)
        Me.GroupBox1.Controls.Add(Me.button_isometric)
        Me.GroupBox1.Controls.Add(Me.button_square)
        Me.GroupBox1.Location = New System.Drawing.Point(136, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(175, 143)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Grid Types"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Spacing:"
        '
        'numeric_spacing
        '
        Me.numeric_spacing.Location = New System.Drawing.Point(61, 22)
        Me.numeric_spacing.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.numeric_spacing.Name = "numeric_spacing"
        Me.numeric_spacing.Size = New System.Drawing.Size(36, 20)
        Me.numeric_spacing.TabIndex = 3
        Me.numeric_spacing.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'button_random
        '
        Me.button_random.Location = New System.Drawing.Point(6, 84)
        Me.button_random.Name = "button_random"
        Me.button_random.Size = New System.Drawing.Size(75, 23)
        Me.button_random.TabIndex = 2
        Me.button_random.Text = "Random"
        Me.button_random.UseVisualStyleBackColor = True
        '
        'button_isometric
        '
        Me.button_isometric.Location = New System.Drawing.Point(87, 55)
        Me.button_isometric.Name = "button_isometric"
        Me.button_isometric.Size = New System.Drawing.Size(75, 23)
        Me.button_isometric.TabIndex = 1
        Me.button_isometric.Text = "Isometric"
        Me.button_isometric.UseVisualStyleBackColor = True
        '
        'button_square
        '
        Me.button_square.Location = New System.Drawing.Point(6, 55)
        Me.button_square.Name = "button_square"
        Me.button_square.Size = New System.Drawing.Size(75, 23)
        Me.button_square.TabIndex = 0
        Me.button_square.Text = "Square"
        Me.button_square.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(22, 19)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 2
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button4)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(118, 143)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Actions"
        '
        'FormOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(323, 280)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormOptions"
        Me.Text = "FormOptions"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.numeric_spacing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents button_random As System.Windows.Forms.Button
    Friend WithEvents button_isometric As System.Windows.Forms.Button
    Friend WithEvents button_square As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents numeric_spacing As System.Windows.Forms.NumericUpDown
End Class
