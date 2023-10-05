// using Xunit;
// using Moq;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.InMemory;
// using Microsoft.Extensions.Configuration;

// public class PostManagerTests
// {
//     private BlogContext _dbContext;
//     private PostManager _postManager;

//     public PostManagerTests()
//     {
//         var options = new DbContextOptionsBuilder<BlogContext>()
//             .UseInMemoryDatabase(databaseName: "TestDatabase")
//             .Options;

//         // Set up any necessary configuration mocks here

//         _dbContext = new BlogContext(options);
//         _postManager = new PostManager(_dbContext);
//     }

//     [Fact]
//     public void GetAllPosts_ShouldReturnAllPosts()
//     {
//         // Arrange
//         var posts = new List<Post>
//             {
//                 new Post { PostId = 1, Title = "Post 1", Content = "Content 1", CreatedAt = DateTime.Now },
//                 new Post { PostId = 2, Title = "Post 2", Content = "Content 2", CreatedAt = DateTime.Now },
//                 new Post { PostId = 3, Title = "Post 3", Content = "Content 3", CreatedAt = DateTime.Now }
//             };

//         _dbContext.Posts.AddRange(posts);
//         _dbContext.SaveChanges();

//         // Act
//         var result = _postManager.GetAllPosts();

//         // Assert
//         Assert.Equal(posts.Count, result.Count());
//         Assert.Equal(posts, result);
//     }

//     [Fact]
//     public void GetPostById_ExistingId_ShouldReturnPost()
//     {
//         // Arrange
//         var post = new Post { PostId = 1, Title = "Test Post", Content = "Test Content", CreatedAt = DateTime.Now };

//         _dbContext.Posts.Add(post);
//         _dbContext.SaveChanges();

//         // Act
//         var result = _postManager.GetPostById(post.PostId);

//         // Assert
//         Assert.Equal(post, result);
//     }

//     [Fact]
//     public void GetPostById_NonExistingId_ShouldReturnNull()
//     {
//         // Arrange
//         var postId = 100;

//         // Act
//         var result = _postManager.GetPostById(postId);

//         // Assert
//         Assert.Null(result);
//     }

//     [Fact]
//     public void CreatePost_ShouldAddPostToDbContext()
//     {
//         // Arrange
//         var post = new Post { PostId = 1, Title = "New Post", Content = "New Content", CreatedAt = DateTime.Now };

//         // Act
//         _postManager.CreatePost(post);

//         // Assert
//         Assert.Contains(post, _dbContext.Posts);
//     }

//     [Fact]
//     public void UpdatePost_ShouldUpdatePostInDbContext()
//     {
//         // Arrange
//         var post = new Post { PostId = 1, Title = "Existing Post", Content = "Existing Content", CreatedAt = DateTime.Now };

//         _dbContext.Posts.Add(post);
//         _dbContext.SaveChanges();

//         // Act
//         _postManager.UpdatePost(post);

//         // Assert
//         Assert.Equal(EntityState.Modified, _dbContext.Entry(post).State);
//     }

//     [Fact]
//     public void DeletePost_ExistingId_ShouldRemovePostFromDbContext()
//     {
//         // Arrange
//         var post = new Post { PostId = 1, Title = "Post", Content = "Content", CreatedAt = DateTime.Now };

//         _dbContext.Posts.Add(post);
//         _dbContext.SaveChanges();

//         // Act
//         _postManager.DeletePost(post.PostId);

//         // Assert
//         Assert.DoesNotContain(post, _dbContext.Posts);
//     }

//     [Fact]
//     public void DeletePost_NonExistingId_ShouldNotRemoveAnyPostFromDbContext()
//     {
//         // Arrange
//         var postId = 100;

//         // Act
//         _postManager.DeletePost(postId);

//         // Assert
//         Assert.Empty(_dbContext.Posts);
//     }
// }
