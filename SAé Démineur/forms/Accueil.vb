﻿Public Class Accueil
    Private Sub Quitter(sender As Object, e As EventArgs) Handles LeaveButton.Click
        If (MsgBox("Voulez-vous quitter l'application ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
            Close()
        End If
    End Sub

    Private Sub Jouer(sender As Object, e As EventArgs) Handles PlayButton.Click
        Dim peutLancer As Boolean = True
        If (ComboBox1.Text.Length < 3) Then
            Label1.ForeColor = Color.Red
            Label2.Visible = True
            peutLancer = False
        End If

        If peutLancer Then
            Me.Hide()
            If Not ComboBox1.Items.Contains(ComboBox1.Text) Then
                ComboBox1.Items.Add(Trim(StrConv(ComboBox1.Text, vbProperCase)))
            End If
            Jeu.MakeProblem()
            Grille.Show()
        End If
    End Sub

    Private Sub Accueil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Parametres.Init()
        Dim nomsJoueurs As String() = Enregistrement.getNomsJoueur()
        If Not nomsJoueurs Is Nothing Then
            For Each nom As String In Enregistrement.getNomsJoueur()
                ComboBox1.Items.Add(nom)
            Next
        End If
    End Sub

    Private Sub Accueil_Close() Handles Me.Closed
        Enregistrement.ajoutJoueur()
        Parametres.SaveOptions()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles ScoreButton.Click
        Me.Hide()
        Score.Show()
    End Sub

    Private Sub OptionsButton_Click(sender As Object, e As EventArgs) Handles OptionsButton.Click
        Me.Hide()
        Options.Show()
    End Sub
End Class
