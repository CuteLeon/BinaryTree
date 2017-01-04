Public Class TreeNode
    Public Value As Integer
    Public Parent As TreeNode
    Public LeftChild As TreeNode
    Public RightChild As TreeNode

    Public Sub New(NodeValue As Integer)
        Value = NodeValue
    End Sub

    Public Function Add(ChildNode As TreeNode) As Boolean
        Dim InsTreeNode As TreeNode = Me
        Do While True
            If ChildNode.Value < InsTreeNode.Value Then
                If IsNothing(InsTreeNode.LeftChild) Then
                    Debug.Print("{0} 添加在了 {1} 的左叶子", ChildNode.Value, InsTreeNode.Value)
                    InsTreeNode.LeftChild = ChildNode : ChildNode.Parent = InsTreeNode : Return True
                Else
                    InsTreeNode = InsTreeNode.LeftChild
                End If
            ElseIf ChildNode.Value > InsTreeNode.Value Then
                If IsNothing(InsTreeNode.RightChild) Then
                    Debug.Print("{0} 添加在了 {1} 的右叶子", ChildNode.Value, InsTreeNode.Value)
                    InsTreeNode.RightChild = ChildNode : ChildNode.Parent = InsTreeNode : Return True
                Else
                    InsTreeNode = InsTreeNode.RightChild
                End If
            Else
                Return False
            End If
        Loop
        Return False
    End Function

    Public Function Add(ChildValue As Integer) As Boolean
        Dim ChildNode As TreeNode = New TreeNode(ChildValue)
        Return Me.Add(ChildNode)
    End Function

    Public Shared Function BeforeOrder(InsTreeNode As TreeNode) As String
        Dim TreePath As String = vbNullString
        TreePath &= InsTreeNode.Value & " "
        If Not IsNothing(InsTreeNode.LeftChild) Then TreePath &= BeforeOrder(InsTreeNode.LeftChild) & " "
        If Not IsNothing(InsTreeNode.RightChild) Then TreePath &= BeforeOrder(InsTreeNode.RightChild) & " "
        Return Strings.Left(TreePath, TreePath.Length - 1)
    End Function

    Public Shared Function MidOrder(InsTreeNode As TreeNode) As String
        Dim TreePath As String = vbNullString
        If Not IsNothing(InsTreeNode.LeftChild) Then TreePath &= MidOrder(InsTreeNode.LeftChild) & " "
        TreePath &= InsTreeNode.Value & " "
        If Not IsNothing(InsTreeNode.RightChild) Then TreePath &= MidOrder(InsTreeNode.RightChild) & " "
        Return Strings.Left(TreePath, TreePath.Length - 1)
    End Function

    Public Shared Function AfterOrder(InsTreeNode As TreeNode) As String
        Dim TreePath As String = vbNullString
        If Not IsNothing(InsTreeNode.LeftChild) Then TreePath &= AfterOrder(InsTreeNode.LeftChild) & " "
        If Not IsNothing(InsTreeNode.RightChild) Then TreePath &= AfterOrder(InsTreeNode.RightChild) & " "
        TreePath &= InsTreeNode.Value & " "
        Return Strings.Left(TreePath, TreePath.Length - 1)
    End Function

End Class