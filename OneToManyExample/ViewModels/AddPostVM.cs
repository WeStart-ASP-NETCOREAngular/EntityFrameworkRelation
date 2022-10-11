using Microsoft.AspNetCore.Mvc.Rendering;
using OneToManyExample.Models;

namespace OneToManyExample.ViewModels
{
    public class AddPostVM
    {
        public Post Post { get; set; }
        public IEnumerable<SelectListItem> categories { get; set; }    

    }
}
