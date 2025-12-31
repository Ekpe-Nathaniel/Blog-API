namespace BlogAPI.DTOs;

public record CreateBlogRequestDTO(
    string Author,
    string Title,
    string Content
);
   
