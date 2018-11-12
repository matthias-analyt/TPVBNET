<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.curveLengh_ = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BdX_ = New System.Windows.Forms.NumericUpDown()
        Me.BX_ = New System.Windows.Forms.NumericUpDown()
        Me.BdY_ = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BY_ = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.AdX_ = New System.Windows.Forms.NumericUpDown()
        Me.AX_ = New System.Windows.Forms.NumericUpDown()
        Me.AdY_ = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AY_ = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nbSeg_ = New System.Windows.Forms.NumericUpDown()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.BdX_, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BX_, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BdY_, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BY_, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.AdX_, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AX_, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdY_, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AY_, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbSeg_, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.curveLengh_)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.nbSeg_)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.SplitContainer1.Size = New System.Drawing.Size(577, 346)
        Me.SplitContainer1.SplitterDistance = 225
        Me.SplitContainer1.TabIndex = 0
        '
        'curveLengh_
        '
        Me.curveLengh_.AutoSize = True
        Me.curveLengh_.Location = New System.Drawing.Point(17, 317)
        Me.curveLengh_.Name = "curveLengh_"
        Me.curveLengh_.Size = New System.Drawing.Size(60, 13)
        Me.curveLengh_.TabIndex = 11
        Me.curveLengh_.Text = "longeur = 0"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.BdX_)
        Me.GroupBox2.Controls.Add(Me.BX_)
        Me.GroupBox2.Controls.Add(Me.BdY_)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.BY_)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 204)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(185, 106)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Point B"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(121, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Y"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(67, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "X"
        '
        'BdX_
        '
        Me.BdX_.DecimalPlaces = 2
        Me.BdX_.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.BdX_.Location = New System.Drawing.Point(53, 67)
        Me.BdX_.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.BdX_.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.BdX_.Name = "BdX_"
        Me.BdX_.Size = New System.Drawing.Size(49, 20)
        Me.BdX_.TabIndex = 5
        '
        'BX_
        '
        Me.BX_.DecimalPlaces = 2
        Me.BX_.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.BX_.Location = New System.Drawing.Point(53, 41)
        Me.BX_.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.BX_.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.BX_.Name = "BX_"
        Me.BX_.Size = New System.Drawing.Size(49, 20)
        Me.BX_.TabIndex = 2
        '
        'BdY_
        '
        Me.BdY_.DecimalPlaces = 2
        Me.BdY_.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.BdY_.Location = New System.Drawing.Point(108, 67)
        Me.BdY_.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.BdY_.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.BdY_.Name = "BdY_"
        Me.BdY_.Size = New System.Drawing.Size(49, 20)
        Me.BdY_.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(14, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "A"
        '
        'BY_
        '
        Me.BY_.DecimalPlaces = 2
        Me.BY_.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.BY_.Location = New System.Drawing.Point(108, 41)
        Me.BY_.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.BY_.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.BY_.Name = "BY_"
        Me.BY_.Size = New System.Drawing.Size(49, 20)
        Me.BY_.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 71)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(22, 13)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "tan"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.AdX_)
        Me.GroupBox1.Controls.Add(Me.AX_)
        Me.GroupBox1.Controls.Add(Me.AdY_)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.AY_)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(185, 106)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Point A"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(121, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Y"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(67, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "X"
        '
        'AdX_
        '
        Me.AdX_.DecimalPlaces = 2
        Me.AdX_.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.AdX_.Location = New System.Drawing.Point(53, 67)
        Me.AdX_.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.AdX_.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.AdX_.Name = "AdX_"
        Me.AdX_.Size = New System.Drawing.Size(49, 20)
        Me.AdX_.TabIndex = 5
        '
        'AX_
        '
        Me.AX_.DecimalPlaces = 2
        Me.AX_.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.AX_.Location = New System.Drawing.Point(53, 41)
        Me.AX_.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.AX_.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.AX_.Name = "AX_"
        Me.AX_.Size = New System.Drawing.Size(49, 20)
        Me.AX_.TabIndex = 2
        '
        'AdY_
        '
        Me.AdY_.DecimalPlaces = 2
        Me.AdY_.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.AdY_.Location = New System.Drawing.Point(108, 67)
        Me.AdY_.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.AdY_.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.AdY_.Name = "AdY_"
        Me.AdY_.Size = New System.Drawing.Size(49, 20)
        Me.AdY_.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "A"
        '
        'AY_
        '
        Me.AY_.DecimalPlaces = 2
        Me.AY_.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.AY_.Location = New System.Drawing.Point(108, 41)
        Me.AY_.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.AY_.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.AY_.Name = "AY_"
        Me.AY_.Size = New System.Drawing.Size(49, 20)
        Me.AY_.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "tan"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "nombre de segments"
        '
        'nbSeg_
        '
        Me.nbSeg_.Location = New System.Drawing.Point(125, 66)
        Me.nbSeg_.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nbSeg_.Name = "nbSeg_"
        Me.nbSeg_.Size = New System.Drawing.Size(77, 20)
        Me.nbSeg_.TabIndex = 0
        Me.nbSeg_.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(577, 346)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.BdX_, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BX_, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BdY_, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BY_, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.AdX_, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AX_, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdY_, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AY_, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbSeg_, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PageSetupDialog1 As PageSetupDialog
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Label1 As Label
    Friend WithEvents nbSeg_ As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents AY_ As NumericUpDown
    Friend WithEvents AX_ As NumericUpDown
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents AdX_ As NumericUpDown
    Friend WithEvents AdY_ As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents BdX_ As NumericUpDown
    Friend WithEvents BX_ As NumericUpDown
    Friend WithEvents BdY_ As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents BY_ As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents curveLengh_ As Label
End Class
