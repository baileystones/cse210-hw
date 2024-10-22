class Video
{
    private string _title;
    private string _author;
    private int _videoLength;
    private List<Comment> _comments;

    public Video(string title, string author, int videoLength)
    {
        _title = title;
        _author = author;
        _videoLength = videoLength;
        _comments = new List<Comment>();
    }
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int CountComments()
    {
        return _comments.Count;
    }
    public string DisplayAll()
    {
        string videoInfo = $"Title: {_title} || Author: {_author} || Length: {_videoLength} seconds || Comments: {CountComments()}";
        foreach (Comment comment in _comments)
        {
            videoInfo += $"\n{comment.Display()}";
        }
        return videoInfo;
    
    }   

}
