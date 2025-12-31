using BlogAPI.Models.Common;
using Microsoft.Net.Http.Headers;

namespace BlogAPI.Models;

public class Blog:Entity
{
    public string? Author { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }
}