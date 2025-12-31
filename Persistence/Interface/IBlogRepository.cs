using BlogAPI.DTOs;
using BlogAPI.Models;

namespace BlogAPI.Persistence.Interface;

public interface IBlogRepository
{
    Blog Add(Blog blog);
    Blog? GetById(Guid id);
    IEnumerable<Blog> GetAll();
    Blog? Update(Guid id, Blog blog);
    Blog? DeleteById(Guid id);

    void Clear();
}
