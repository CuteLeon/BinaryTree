Public Class MainForm
    Dim RootNode As BinaryTreeNode = New BinaryTreeNode(100)

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Index As Integer

        For Index = 0 To 200
            Dim NewNodeValue As Integer = VBMath.Rnd * 255
            RootNode.Add(NewNodeValue)
            Debug.Print("节点路径：{0}，路径编码：{1}", RootNode.FindNode(NewNodeValue), RootNode.GetPathCode(NewNodeValue))
        Next

        Debug.Print("前序遍历")
        Debug.Print(BinaryTreeNode.BeforeOrder(RootNode))

        Debug.Print("中序遍历")
        Debug.Print(BinaryTreeNode.MidOrder(RootNode))

        Debug.Print("后序遍历")
        Debug.Print(BinaryTreeNode.AfterOrder(RootNode))

        Debug.Print("逐层遍历：")
        RootNode.PrintTree()
    End Sub

End Class
