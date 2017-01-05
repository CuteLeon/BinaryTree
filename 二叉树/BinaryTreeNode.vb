Public Class BinaryTreeNode
    Public Value As Integer
    Public Parent As BinaryTreeNode
    Public LeftChild As BinaryTreeNode
    Public RightChild As BinaryTreeNode

    ''' <summary>
    ''' 生成新的二叉树节点
    ''' </summary>
    ''' <param name="NodeValue"></param>
    Public Sub New(NodeValue As Integer)
        Value = NodeValue
    End Sub

    ''' <summary>
    ''' 为二叉树加入新的节点
    ''' </summary>
    ''' <param name="ChildNode">子节点</param>
    ''' <returns>是否加入成功：返回假时说明节点已经存在</returns>
    Public Function Add(ChildNode As BinaryTreeNode) As Boolean
        Dim InsTreeNode As BinaryTreeNode = Me
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

    ''' <summary>
    ''' 为二叉树加入新的节点
    ''' </summary>
    ''' <param name="ChildValue">子节点的值</param>
    ''' <returns>是否加入成功？返回假说明值已经存在</returns>
    Public Function Add(ChildValue As Integer) As Boolean
        Dim ChildNode As BinaryTreeNode = New BinaryTreeNode(ChildValue)
        Return Me.Add(ChildNode)
    End Function

    ''' <summary>
    ''' 前序遍历（共享函数，允许通过类使用）
    ''' </summary>
    ''' <param name="InsTreeNode">根节点</param>
    ''' <returns>前序遍历的结果</returns>
    Public Shared Function BeforeOrder(InsTreeNode As BinaryTreeNode) As String
        Dim TreePath As String = vbNullString
        TreePath &= InsTreeNode.Value & "-"
        If Not IsNothing(InsTreeNode.LeftChild) Then TreePath &= BeforeOrder(InsTreeNode.LeftChild) & "-"
        If Not IsNothing(InsTreeNode.RightChild) Then TreePath &= BeforeOrder(InsTreeNode.RightChild) & "-"
        Return Strings.Left(TreePath, TreePath.Length - 1)
    End Function

    ''' <summary>
    ''' 中序遍历（共享函数，允许通过类使用）
    ''' </summary>
    ''' <param name="InsTreeNode">根节点</param>
    ''' <returns>中序遍历的结果</returns>
    Public Shared Function MidOrder(InsTreeNode As BinaryTreeNode) As String
        Dim TreePath As String = vbNullString
        If Not IsNothing(InsTreeNode.LeftChild) Then TreePath &= MidOrder(InsTreeNode.LeftChild) & "-"
        TreePath &= InsTreeNode.Value & "-"
        If Not IsNothing(InsTreeNode.RightChild) Then TreePath &= MidOrder(InsTreeNode.RightChild) & "-"
        Return Strings.Left(TreePath, TreePath.Length - 1)
    End Function

    ''' <summary>
    ''' 后序遍历（共享函数，允许通过类使用）
    ''' </summary>
    ''' <param name="InsTreeNode">根节点</param>
    ''' <returns>后序遍历的结果</returns>
    Public Shared Function AfterOrder(InsTreeNode As BinaryTreeNode) As String
        Dim TreePath As String = vbNullString
        If Not IsNothing(InsTreeNode.LeftChild) Then TreePath &= AfterOrder(InsTreeNode.LeftChild) & "-"
        If Not IsNothing(InsTreeNode.RightChild) Then TreePath &= AfterOrder(InsTreeNode.RightChild) & "-"
        TreePath &= InsTreeNode.Value & "-"
        Return Strings.Left(TreePath, TreePath.Length - 1)
    End Function

    ''' <summary>
    ''' 按层优先输出二叉树
    ''' </summary>
    Public Sub PrintTree()
        Dim InsTreeNode As BinaryTreeNode
        Dim NodeQueue As Queue(Of BinaryTreeNode) = New Queue(Of BinaryTreeNode)
        NodeQueue.Enqueue(Me)
        While (NodeQueue.Count > 0)
            InsTreeNode = NodeQueue.Dequeue()
            Debug.Print(InsTreeNode.Value)
            If Not IsNothing(InsTreeNode.LeftChild) Then NodeQueue.Enqueue(InsTreeNode.LeftChild)
            If Not IsNothing(InsTreeNode.RightChild) Then NodeQueue.Enqueue(InsTreeNode.RightChild)
        End While
    End Sub

    ''' <summary>
    ''' 查找节点的路径
    ''' </summary>
    ''' <param name="Value">要找的节点值</param>
    ''' <returns>路径查找结果</returns>
    Public Function FindNode(Value As Integer) As String
        Dim PathString As String = Me.Value
        Dim InsTreeNode As BinaryTreeNode = Me
        Do While True
            If Value < InsTreeNode.Value Then
                If IsNothing(InsTreeNode.LeftChild) Then
                    Return "未找到节点 " & Value
                Else
                    InsTreeNode = InsTreeNode.LeftChild
                    PathString &= "-" & InsTreeNode.Value
                End If
            ElseIf Value > InsTreeNode.Value Then
                If IsNothing(InsTreeNode.RightChild) Then
                    Return "未找到节点 " & Value
                Else
                    InsTreeNode = InsTreeNode.RightChild
                    PathString &= "-" & InsTreeNode.Value
                End If
            Else
                Return PathString
            End If
        Loop
        Return PathString
    End Function

    ''' <summary>
    ''' 获取节点的路径编码
    ''' </summary>
    ''' <param name="Value">节点的值</param>
    ''' <returns>节点的路径编码</returns>
    Public Function GetPathCode(Value As Integer) As String
        Dim PathCode As String = vbNullString
        Dim InsTreeNode As BinaryTreeNode = Me
        Do While True
            If Value < InsTreeNode.Value Then
                If IsNothing(InsTreeNode.LeftChild) Then
                    Return "未找到节点 " & Value
                Else
                    InsTreeNode = InsTreeNode.LeftChild
                    PathCode &= "0"
                End If
            ElseIf Value > InsTreeNode.Value Then
                If IsNothing(InsTreeNode.RightChild) Then
                    Return "未找到节点 " & Value
                Else
                    InsTreeNode = InsTreeNode.RightChild
                    PathCode &= "1"
                End If
            Else
                Return PathCode
            End If
        Loop
        Return PathCode
    End Function

End Class