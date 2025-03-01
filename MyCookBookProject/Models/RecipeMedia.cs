namespace MyCookBookProject.Models
{
    public class RecipeMedia
    {
        public string Url { get; set; } //Firebase Storage URL
        public string Type { get; set; } //Image/Video
        public int Order { get; set; }//Display Order
    }
}
