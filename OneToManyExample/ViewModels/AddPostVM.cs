using Microsoft.AspNetCore.Mvc.Rendering;
using OneToManyExample.Models;

namespace OneToManyExample.ViewModels
{
    public class AddPostVM
    {
        //public Post Post { get; set; }
        public string Title { get; set; }

        public string Body { get; set; }

        public int CategoryId { get; set; }

        public IFormFile Image { get; set; }

        public IEnumerable<SelectListItem> categories { get; set; }

    }
}
