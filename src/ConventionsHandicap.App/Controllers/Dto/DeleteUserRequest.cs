using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.Controller.Dto
{
    public class DeleteUserRequest
    {
        [JsonProperty("workspaceId")]
        [Required(ErrorMessage = "WorkspaceId is required")]
        public Guid? WorkspaceId { get; set; }
        [JsonProperty("userId")]
        [Required(ErrorMessage = "UserId is required")]
        public Guid? UserId { get; set; }
    }
}
