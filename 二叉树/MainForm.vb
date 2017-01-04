Public Class MainForm
    Dim RootNode As TreeNode

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Debug.Print("创建二叉树根")
        RootNode = New TreeNode(100)
        Debug.Print("为二叉树添加节点")
        RootNode.Add(50)
        RootNode.Add(25)
        RootNode.Add(30)
        RootNode.Add(15)
        RootNode.Add(150)
        RootNode.Add(125)
        RootNode.Add(175)
        'For Index As Integer = 0 To 200
        '    RootNode.Add(Index)
        'Next

        Debug.Print("前序遍历")
        Debug.Print(TreeNode.BeforeOrder(RootNode))

        Debug.Print("中序遍历")
        Debug.Print(TreeNode.MidOrder(RootNode))

        Debug.Print("后序遍历")
        Debug.Print(TreeNode.AfterOrder(RootNode))
    End Sub

End Class
