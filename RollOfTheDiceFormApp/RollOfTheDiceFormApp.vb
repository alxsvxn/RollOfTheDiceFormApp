'Alexis Villagran
'Rcet 0265 
'Spring 2025
'RollOfTheDieTWO
'

Option Explicit On
Option Strict On
Public Class RollOfTheDiceFormApp

    Dim rand As New Random()
    Dim rollCounts(10) As Integer

    Private Sub RollButton_Click(sender As Object, e As EventArgs) Handles RollButton.Click
        Array.Clear(rollCounts, 0, rollCounts.Length)
        For i As Integer = 1 To 1000
            Dim die1 As Integer = RandomNumberBetween(1, 6)
            Dim die2 As Integer = RandomNumberBetween(1, 6)
            Dim sum As Integer = die1 + die2
            rollCounts(sum - 2) += 1
        Next
        DisplayResults()
    End Sub
    Private Sub DisplayResults()
        ResultListBox.Items.Clear()

        Dim header As String = String.Join(" | ", {"Dice Value", "Times Rolled"})

        ResultListBox.Items.Add(header)

        Dim separator As String = New String("-"c, header.Length)

        ResultListBox.Items.Add(separator)

        Dim diceValues As String = String.Join(" | ", Enumerable.Range(2, 11).Select(Function(i) i.ToString().PadLeft(7)))
        Dim rollCountsDisplay As String = String.Join(" | ", rollCounts.Select(Function(count) count.ToString().PadLeft(6)))

        ResultListBox.Items.Add(diceValues)
        ResultListBox.Items.Add(rollCountsDisplay)

        ResultListBox.Items.Add(separator)

        Dim maxIndex As Integer = Array.IndexOf(rollCounts, rollCounts.Max())
        ResultListBox.Items.Add($"Most Frequent Roll: {maxIndex}")
    End Sub
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        ResultListBox.Items.Clear()
        Array.Clear(rollCounts, 0, rollCounts.Length)
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Function RandomNumberBetween(min As Integer, max As Integer) As Integer
        Return rand.Next(min, max + 1)
    End Function
End Class
