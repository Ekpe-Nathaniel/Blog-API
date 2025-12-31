using BlogAPI.Models;
using BlogAPI.Persistence.Interface;

namespace BlogAPI.Persistence.Repository;

public class BlogRepository : IBlogRepository
{
    private static readonly List<Blog> _blogList = new List<Blog>();
    public Blog Add(Blog blog)
    {
        _blogList.Add(blog);
        return blog;
    }

    public Blog? DeleteById(Guid id)
    {
        var blog = _blogList.FirstOrDefault(b => b.Id == id);
        if (blog == null)
        {
            return null;
        }
        blog.DeletedAt = DateTime.UtcNow.ToString();
        return blog;

    }

    public IEnumerable<Blog> GetAll()
    {
        return _blogList.Where(b => b.DeletedAt == null);
    }

    public Blog? GetById(Guid id)
    {
        var blog = _blogList.FirstOrDefault(b => b.Id == id && b.DeletedAt == null);
        if (blog == null)
        {
            return null;
        }

        return blog;
    }

    public Blog? Update(Guid id, Blog blog)
    {
        var targetBlog = _blogList.FirstOrDefault(b => b.Id == id && b.DeletedAt == null);
        if (targetBlog == null)
        {
            return blog;
        }

        targetBlog.Author = blog.Author;
        targetBlog.Title = blog.Title;
        targetBlog.Content = blog.Content;
        targetBlog.UpdatedAt = DateTime.UtcNow.ToString();

        return targetBlog;
    }

    public void Clear()
    {
        _blogList.Clear();
    }

}