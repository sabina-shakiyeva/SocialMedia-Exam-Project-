using Microsoft.EntityFrameworkCore;
using Social.Project.DAL.Context;
using Social.Project.DAL.Repositories.Concrete;
using Social.Project.Models.Entities.Concrete;

namespace SocialMedia;
public class Program
{
    public static async Task Main(string[] args)
    {
        using (var context=new SocialDbContext())
        {
            var userRepository = new BaseRepository<User>(context);
            var userDetailsRepository = new BaseRepository<UserDetails>(context);
            var postRepository = new BaseRepository<Post>(context);
            var commentRepository = new BaseRepository<Comment>(context);

            
            while (true)
            {
                Console.WriteLine("Choice:");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Add User Detail");
                Console.WriteLine("3. AddPost");
                Console.WriteLine("4. AddComment");
                Console.WriteLine("5. Get All Users");
                Console.WriteLine("6.Get All Posts");
                Console.WriteLine("7. Get All Comments");
                Console.WriteLine("8. Update User");
                Console.WriteLine("9. Update Post");
                Console.WriteLine("10. Delete User");
                Console.WriteLine("11. Delete Post");
                Console.WriteLine("12. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": 
                        Console.WriteLine("Enter user name:");
                        string userName = Console.ReadLine();

                        Console.WriteLine("Enter user surname:");
                        string userSurname = Console.ReadLine();

                        Console.WriteLine("Enter birthday (yyyy-mm-dd):");
                        DateTime birthday = DateTime.Parse(Console.ReadLine());

                        var userDetails = new UserDetails
                        {
                            Name = userName,
                            Surname = userSurname,
                            Birthday = birthday,
                            Role = Role.User
                        };

                        userDetailsRepository.Add(userDetails);
                        userDetailsRepository.SaveChanges();

                        var newUser = new User
                        {
                            UserDetails = userDetails
                        };
                        userRepository.Add(newUser);
                        userRepository.SaveChanges();

                        Console.WriteLine("User Added");
                        break;

                    case "2": 
                        Console.WriteLine("Enter user detail name:");
                        string detailName = Console.ReadLine();

                        Console.WriteLine("Enter user detail surname:");
                        string detailSurname = Console.ReadLine();

                        Console.WriteLine("Enter birthday (yyyy-mm-dd):");
                        DateTime detailBirthday = DateTime.Parse(Console.ReadLine());

                        var newUserDetail = new UserDetails
                        {
                            Name = detailName,
                            Surname = detailSurname,
                            Birthday = detailBirthday,
                            Role = Role.User
                        };

                        userDetailsRepository.Add(newUserDetail);
                        userDetailsRepository.SaveChanges();
                        Console.WriteLine("User Detail Added");
                        break;

                    case "3":

                       
                        Console.WriteLine("Enter post text:");
                        string postText = Console.ReadLine();

                        Console.WriteLine("Enter User ID:");
                        int userId = int.Parse(Console.ReadLine());

                       
                        var user = context.Users.Find(userId);
                        if (user == null)
                        {
                            Console.WriteLine("User not found. Please check the User ID.");
                        }
                        else
                        {
                            var post = new Post
                            {
                                Text = postText,
                                LikeCount = 0,
                                CreatedDate = DateTime.Now,
                                UserId = userId
                            };

                            context.Posts.Add(post);

                           
                            await context.SaveChangesAsync();
                            Console.WriteLine("Post added successfully.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Enter comment text:");
                        string commentText = Console.ReadLine();

                        Console.WriteLine("Enter post ID for the comment:");
                        int postId = int.Parse(Console.ReadLine());

                        var newComment = new Comment
                        {
                            Text = commentText,
                            LikeCount = 0,
                            PostId = postId,
                            CreatedDate = DateTime.Now
                        };

                        commentRepository.Add(newComment);
                        commentRepository.SaveChanges();
                        Console.WriteLine("Commment Added!");
                        break;

                    case "5": 
                        var users = userRepository.GetAll();
                        foreach (var userr in users)
                        {
                            if (userr.UserDetails != null)
                            {
                                Console.WriteLine($"User ID: {userr.Id}, Name: {userr.UserDetails.Name}, Surname: {userr.UserDetails.Surname}, Role: {userr.UserDetails.Role}");
                            }
                            else
                            {
                                Console.WriteLine($"User ID: {userr.Id} has no details.");
                            }
                        }


                        break;

                    case "6":
                        var posts = postRepository.GetAll();
                        foreach (var post in posts)
                        {
                            Console.WriteLine($"Post ID: {post.Id}, Text: {post.Text}, Likes: {post.LikeCount}");
                        }
                        break;

                    case "7": 
                        var comments = commentRepository.GetAll();
                        foreach (var comment in comments)
                        {
                            Console.WriteLine($"Comment ID: {comment.Id}, Text: {comment.Text}, Post ID: {comment.PostId}, Likes: {comment.LikeCount}");
                        }
                        break;

                    case "8": 
                        Console.WriteLine("Enter User Id for update:");
                        int userIdToUpdate = int.Parse(Console.ReadLine());

                        var userToUpdate = userRepository.GetById(userIdToUpdate);
                        if (userToUpdate != null)
                        {
                            Console.WriteLine("New Name:");
                            userToUpdate.UserDetails.Name = Console.ReadLine();
                            Console.WriteLine("New Surname:");
                            userToUpdate.UserDetails.Surname = Console.ReadLine();
                            userRepository.Update(userToUpdate.Id);
                            userRepository.SaveChanges();
                            Console.WriteLine("User updated.");
                        }
                        else
                        {
                            Console.WriteLine("User not found.");
                        }
                        break;

                    case "9": 
                        Console.WriteLine("Enter Post Id for update:");
                        int postIdToUpdate = int.Parse(Console.ReadLine());

                        var postToUpdate = postRepository.GetById(postIdToUpdate);
                        if (postToUpdate != null)
                        {
                            Console.WriteLine("new post text:");
                            postToUpdate.Text = Console.ReadLine();
                            postRepository.Update(postToUpdate.Id);
                            postRepository.SaveChanges();
                            Console.WriteLine("Post updated.");
                        }
                        else
                        {
                            Console.WriteLine("Post not found.");
                        }
                        break;

                    case "10": 
                        Console.WriteLine("Enter User Id for delete:");
                        int userIdToDelete = int.Parse(Console.ReadLine());

                        var userToDelete = userRepository.GetById(userIdToDelete);
                        if (userToDelete != null)
                        {
                            userRepository.Delete(userToDelete.Id);
                            userRepository.SaveChanges();
                            Console.WriteLine("User Deleted.");
                        }
                        else
                        {
                            Console.WriteLine("User not found.");
                        }
                        break;

                    case "11": 
                        Console.WriteLine("Enter Post Id for Delete:");
                        int postIdToDelete = int.Parse(Console.ReadLine());

                        var postToDelete = postRepository.GetById(postIdToDelete);
                        if (postToDelete != null)
                        {
                            postRepository.Delete(postToDelete.Id);
                            postRepository.SaveChanges();
                            Console.WriteLine("Post Deleted.");
                        }
                        else
                        {
                            Console.WriteLine("Post not found.");
                        }
                        break;

                    case "12": 
                        Console.WriteLine("Exit...");
                        return;

                    default:
                        Console.WriteLine("Wrong Choice!!");
                        break;
                }
            }

        }
    }
}
    

