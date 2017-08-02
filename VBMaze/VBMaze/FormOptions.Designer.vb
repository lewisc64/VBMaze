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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.combo_type = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numeric_spacing = New System.Windows.Forms.NumericUpDown()
        Me.button_apply = New System.Windows.Forms.Button()
        Me.button_export_png = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.button_regenerate = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.button_speed_5 = New System.Windows.Forms.Button()
        Me.button_speed_4 = New System.Windows.Forms.Button()
        Me.button_speed_3 = New System.Windows.Forms.Button()
        Me.button_speed_2 = New System.Windows.Forms.Button()
        Me.button_speed_1 = New System.Windows.Forms.Button()
        Me.button_speed_0 = New System.Windows.Forms.Button()
        Me.check_debug = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numeric_spacing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.combo_type)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.numeric_spacing)
        Me.GroupBox1.Controls.Add(Me.button_apply)
        Me.GroupBox1.Location = New System.Drawing.Point(105, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(175, 143)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Generation"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Type:"
        '
        'combo_type
        '
        Me.combo_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_type.FormattingEnabled = True
        Me.combo_type.Items.AddRange(New Object() {"Square", "Isometric", "Circular", "Random"})
        Me.combo_type.Location = New System.Drawing.Point(61, 48)
        Me.combo_type.Name = "combo_type"
        Me.combo_type.Size = New System.Drawing.Size(108, 21)
        Me.combo_type.TabIndex = 5
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
        Me.numeric_spacing.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numeric_spacing.Name = "numeric_spacing"
        Me.numeric_spacing.Size = New System.Drawing.Size(36, 20)
        Me.numeric_spacing.TabIndex = 3
        Me.numeric_spacing.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'button_apply
        '
        Me.button_apply.Location = New System.Drawing.Point(94, 114)
        Me.button_apply.Name = "button_apply"
        Me.button_apply.Size = New System.Drawing.Size(75, 23)
        Me.button_apply.TabIndex = 2
        Me.button_apply.Text = "Apply"
        Me.button_apply.UseVisualStyleBackColor = True
        '
        'button_export_png
        '
        Me.button_export_png.Location = New System.Drawing.Point(6, 42)
        Me.button_export_png.Name = "button_export_png"
        Me.button_export_png.Size = New System.Drawing.Size(75, 23)
        Me.button_export_png.TabIndex = 2
        Me.button_export_png.Text = "Export PNG"
        Me.button_export_png.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.check_debug)
        Me.GroupBox2.Controls.Add(Me.button_regenerate)
        Me.GroupBox2.Controls.Add(Me.button_export_png)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(87, 143)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Actions"
        '
        'button_regenerate
        '
        Me.button_regenerate.Location = New System.Drawing.Point(6, 71)
        Me.button_regenerate.Name = "button_regenerate"
        Me.button_regenerate.Size = New System.Drawing.Size(75, 23)
        Me.button_regenerate.TabIndex = 3
        Me.button_regenerate.Text = "Regenerate"
        Me.button_regenerate.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.button_speed_5)
        Me.GroupBox3.Controls.Add(Me.button_speed_4)
        Me.GroupBox3.Controls.Add(Me.button_speed_3)
        Me.GroupBox3.Controls.Add(Me.button_speed_2)
        Me.GroupBox3.Controls.Add(Me.button_speed_1)
        Me.GroupBox3.Controls.Add(Me.button_speed_0)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 161)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(268, 60)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Speed"
        '
        'button_speed_5
        '
        Me.button_speed_5.Location = New System.Drawing.Point(215, 19)
        Me.button_speed_5.Name = "button_speed_5"
        Me.button_speed_5.Size = New System.Drawing.Size(33, 23)
        Me.button_speed_5.TabIndex = 9
        Me.button_speed_5.Text = ">>>"
        Me.button_speed_5.UseVisualStyleBackColor = True
        '
        'button_speed_4
        '
        Me.button_speed_4.Location = New System.Drawing.Point(176, 19)
        Me.button_speed_4.Name = "button_speed_4"
        Me.button_speed_4.Size = New System.Drawing.Size(33, 23)
        Me.button_speed_4.TabIndex = 8
        Me.button_speed_4.Text = ">"
        Me.button_speed_4.UseVisualStyleBackColor = True
        '
        'button_speed_3
        '
        Me.button_speed_3.Location = New System.Drawing.Point(137, 19)
        Me.button_speed_3.Name = "button_speed_3"
        Me.button_speed_3.Size = New System.Drawing.Size(33, 23)
        Me.button_speed_3.TabIndex = 7
        Me.button_speed_3.Text = ">"
        Me.button_speed_3.UseVisualStyleBackColor = True
        '
        'button_speed_2
        '
        Me.button_speed_2.Location = New System.Drawing.Point(98, 19)
        Me.button_speed_2.Name = "button_speed_2"
        Me.button_speed_2.Size = New System.Drawing.Size(33, 23)
        Me.button_speed_2.TabIndex = 6
        Me.button_speed_2.Text = ">"
        Me.button_speed_2.UseVisualStyleBackColor = True
        '
        'button_speed_1
        '
        Me.button_speed_1.Location = New System.Drawing.Point(59, 19)
        Me.button_speed_1.Name = "button_speed_1"
        Me.button_speed_1.Size = New System.Drawing.Size(33, 23)
        Me.button_speed_1.TabIndex = 5
        Me.button_speed_1.Text = ">"
        Me.button_speed_1.UseVisualStyleBackColor = True
        '
        'button_speed_0
        '
        Me.button_speed_0.Location = New System.Drawing.Point(20, 19)
        Me.button_speed_0.Name = "button_speed_0"
        Me.button_speed_0.Size = New System.Drawing.Size(33, 23)
        Me.button_speed_0.TabIndex = 4
        Me.button_speed_0.Text = "| |"
        Me.button_speed_0.UseVisualStyleBackColor = True
        '
        'check_debug
        '
        Me.check_debug.AutoSize = True
        Me.check_debug.Location = New System.Drawing.Point(6, 19)
        Me.check_debug.Name = "check_debug"
        Me.check_debug.Size = New System.Drawing.Size(58, 17)
        Me.check_debug.TabIndex = 4
        Me.check_debug.Text = "Debug"
        Me.check_debug.UseVisualStyleBackColor = True
        '
        'FormOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 233)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormOptions"
        Me.Text = "VBMaze - Options"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.numeric_spacing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents button_apply As System.Windows.Forms.Button
    Friend WithEvents button_export_png As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents numeric_spacing As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents combo_type As System.Windows.Forms.ComboBox
    Friend WithEvents button_regenerate As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents button_speed_5 As System.Windows.Forms.Button
    Friend WithEvents button_speed_4 As System.Windows.Forms.Button
    Friend WithEvents button_speed_3 As System.Windows.Forms.Button
    Friend WithEvents button_speed_2 As System.Windows.Forms.Button
    Friend WithEvents button_speed_1 As System.Windows.Forms.Button
    Friend WithEvents button_speed_0 As System.Windows.Forms.Button
    Friend WithEvents check_debug As System.Windows.Forms.CheckBox
End Class
